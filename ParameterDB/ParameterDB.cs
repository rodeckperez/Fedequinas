using Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class ParameterDB : CommonSql
    {
        private IDataBase DataBase;
        public ParameterDB(IDataBase DataBase)
        {
            this.DataBase = DataBase;
        }
        public string GetParameterValue(string Parameter)
        {
            try
            {
                this.DataBase.ConfigExecution(this.ConnectionString, "APP_GetParameterValue", CommandType.StoredProcedure);
                this.DataBase.AddParameter(DbType.String, "Parameter", 20, ParameterDirection.Input, Parameter, true);

                this.DataBase.Query();
                this.DataBaseActionOk = true;
                return this.DataBase.GetDataSet().Tables[0].Rows[0][0].ToString();
            }
            catch (Exception e)
            {
                this.DataBaseActionOk = false;
                this.Message = "Error de ejecución en base de datos (ParameterDB.GetParameterValue) "+e.Message;
                return "";
            }
        }
    }
}