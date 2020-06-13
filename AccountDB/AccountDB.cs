using Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Table;

namespace DataBase
{
    public class AccountDB : CommonSql
    {
        private IDataBase iDataBase;

        public AccountDB(IDataBase _iDataBase)
        {
            this.iDataBase = _iDataBase;
        }

        public string GetPassword(string email)
        {
            string password = "";

            this.iDataBase.ConfigExecution(this.ConnectionString, "APP_GetPassword", CommandType.StoredProcedure);
            this.iDataBase.AddParameter(DbType.String, "Email", 100, ParameterDirection.Input, email, true);

            try
            {
                this.iDataBase.Query();
                password = this.iDataBase.GetDataSet().Tables[0].Rows[0]["Password"].ToString();
                this.DataBaseActionOk = true;
            }
            catch (Exception e)
            {
                this.DataBaseActionOk = false;
                this.Message = "Error de ejecución en base de datos (AccountDB.AddAccessFail)";
                password = "";
            }

            return password;
        }

        public bool AccountExists(string email)
        {
            this.iDataBase.ConfigExecution(this.ConnectionString, "APP_AccountExists", CommandType.StoredProcedure);
            this.iDataBase.AddParameter(DbType.String, "Email", 100, ParameterDirection.Input, email, true);
            bool exists = false;
            try
            {
                this.iDataBase.Query();
                exists = this.iDataBase.GetDataSet().Tables[0].Rows[0][0].ToString().Equals("0") ? false : true;
                this.DataBaseActionOk = true;
            }
            catch (Exception e)
            {

                this.DataBaseActionOk = false;
                this.Message = "Error de ejecución en base de datos (AccountDB.AccountExists)";
            }

            return exists;
        }

        public void ChangePassword(string email, string password)
        {
            this.iDataBase.ConfigExecution(this.ConnectionString, "APP_ChangePassword", CommandType.StoredProcedure);
            this.iDataBase.AddParameter(DbType.String, "Email", 100, ParameterDirection.Input, email, true);
            this.iDataBase.AddParameter(DbType.String, "Password", 64, ParameterDirection.Input, password, true);

            bool exists = false;
            try
            {
                this.iDataBase.NonQuery();
                this.DataBaseActionOk = true;
            }
            catch (Exception e)
            {

                this.DataBaseActionOk = false;
                this.Message = "Error de ejecución en base de datos (AccountDB.ChangePassword)";
            }
        }

        public void ChangePassword(int PkAccount, string password)
        {
            this.iDataBase.ConfigExecution(this.ConnectionString, "APP_ChangePasswordById", CommandType.StoredProcedure);
            this.iDataBase.AddParameter(DbType.Int32, "PkAccount", 0, ParameterDirection.Input, PkAccount, true);
            this.iDataBase.AddParameter(DbType.String, "Password", 64, ParameterDirection.Input, password, true);

            try
            {
                this.iDataBase.NonQuery();
                this.DataBaseActionOk = true;
            }
            catch (Exception e)
            {

                this.DataBaseActionOk = false;
                this.Message = "Error de ejecución en base de datos (AccountDB.ChangePasswordById)";
            }
        }

        public Account GetAccountData(string email)
        {
            Account account = new Account();

            this.iDataBase.ConfigExecution(this.ConnectionString, "APP_GetAccountData", CommandType.StoredProcedure);
            this.iDataBase.AddParameter(DbType.String, "Email", 100, ParameterDirection.Input, email, true);

            try
            {
                this.iDataBase.Query();
                account = BuildAccountData(this.iDataBase.GetDataSet().Tables[0].Rows[0]);
                this.DataBaseActionOk = true;
            }
            catch (Exception e)
            {
                this.DataBaseActionOk = false;
                this.Message = "Error de ejecución en base de datos (AccountDB.AddAccessFail)";
            }

            return account;
        }

        private Account BuildAccountData(DataRow row)
        {
            Account account = new Account()
            {
                Email = row["Email"].ToString(),
                FullName = row["FullName"].ToString(),
                PkAccount = Int32.Parse(row["PkAccount"].ToString()),
                RecordState = row["RecordState"].ToString()
            };

            return account;
        }

        public void InsertAccessFail(string UserName)
        {
            this.iDataBase.ConfigExecution(this.ConnectionString, "APP_InsertAccessFail", CommandType.StoredProcedure);
            this.iDataBase.AddParameter(DbType.String, "Email", 100, ParameterDirection.Input, UserName, true);

            try
            {
                this.iDataBase.NonQuery();
                this.DataBaseActionOk = true;
            }
            catch (Exception e)
            {
                this.DataBaseActionOk = false;
                this.Message = "Error de ejecución en base de datos (AccountDB.AddAccessFail)";
            }
        }

        public void DeletePersonAccessfail(int PkPerson)
        {
            this.iDataBase.ConfigExecution(this.ConnectionString, "APP_DeletePersonAccessfail", CommandType.StoredProcedure);
            this.iDataBase.AddParameter(DbType.Int32, "PkAccount", 0, ParameterDirection.Input, PkPerson, true);

            try
            {
                this.iDataBase.NonQuery();
                this.DataBaseActionOk = true;
            }
            catch (Exception e)
            {
                this.DataBaseActionOk = false;
                this.Message = "Error de ejecución en base de datos (AccountDB.DeletePersonAccessfail)";
            }
        }


        public bool CanCreateAccount(Account account)
        {
            this.iDataBase.ConfigExecution(this.ConnectionString, "APP_CanCreateAccount", CommandType.StoredProcedure);
            this.iDataBase.AddParameter(DbType.String, "Email", 100, ParameterDirection.Input, account.Email, true);
            
            try
            {
                this.iDataBase.Query();
                bool canCreate = this.iDataBase.GetDataSet().Tables[0].Rows[0][0].ToString().Equals("1") ? true:false;

                if  (!canCreate)
                {
                    this.Message = this.iDataBase.GetDataSet().Tables[0].Rows[0][1].ToString();
                }
                this.DataBaseActionOk = true;

                return canCreate;
            }
            catch (Exception e)
            {
                this.DataBaseActionOk = false;
                this.Message = "Error de ejecución en base de datos (AccountDB.CanCreateAccount)";

                return false;
            }
        }

        public Account InsertAccount(Account account)
        {
            this.iDataBase.ConfigExecution(this.ConnectionString, "APP_InsertAccount", CommandType.StoredProcedure);
            this.iDataBase.AddParameter(DbType.String, "Email", 100, ParameterDirection.Input, account.Email, true);
            this.iDataBase.AddParameter(DbType.String, "Password", 64, ParameterDirection.Input, account.Password, true);
            this.iDataBase.AddParameter(DbType.String, "FullName", 100, ParameterDirection.Input, account.FullName, true);
            this.iDataBase.AddParameter(DbType.String, "RecordState", 2, ParameterDirection.Input, "CA", true);
            this.iDataBase.AddParameter(DbType.String, "Document", 20, ParameterDirection.Input, account.Document, true);

            try
            {
                this.iDataBase.Query();
                account.PkAccount = Int32.Parse(this.iDataBase.GetDataSet().Tables[0].Rows[0][0].ToString());
                this.DataBaseActionOk = true;
            }
            catch (Exception e)
            {
                this.DataBaseActionOk = false;
                this.Message = "Error de ejecución en base de datos (AccountDB.InsertAccount)";
                account.PkAccount = -1;
            }

            return account;
        }
    }
}