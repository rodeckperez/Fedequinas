using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public class SqlServer : IDataBase
    {
        protected SqlConnection con;
        protected SqlCommand sqlCommand;
        protected SqlParameter parameter;
        protected SqlDataAdapter dataAdapter;
        protected DataSet dataSet;

        public void AddParameter(DbType type, string Name, int Size, ParameterDirection Direcction, object Value, bool AssignValue)
        {
            parameter = new SqlParameter();
            parameter.DbType = type;
            parameter.ParameterName = Name;
            if (Size > 0)
            {
                parameter.Size = Size;
            }

            parameter.Direction = Direcction;

            if (AssignValue)
            {
                parameter.Value = Value;
            }

            sqlCommand.Parameters.Add(parameter);
        }
        public void AddParameter(SqlDbType type, string Name, int Size, ParameterDirection Direcction, object Value, bool AssignValue)
        {
            parameter = new SqlParameter();
            parameter.SqlDbType = type;
            parameter.ParameterName = Name;
            if (Size > 0)
            {
                parameter.Size = Size;
            }

            parameter.Direction = Direcction;

            if (AssignValue)
            {
                parameter.Value = Value;
            }

            sqlCommand.Parameters.Add(parameter);
        }

        public void ConfigExecution(string ConexionString, string sql, CommandType Type)
        {
            con = new SqlConnection(ConexionString);
            con.Open();
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = con;
            sqlCommand.CommandText = sql;
            sqlCommand.CommandType = Type;
        }

        public void Query()
        {
            dataAdapter = new SqlDataAdapter(sqlCommand);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            con.Close();
        }

        public void NonQuery()
        {
            sqlCommand.ExecuteNonQuery();
            con.Close();
        }

        public DataSet GetDataSet()
        {
            return this.dataSet;
        }

        public void UpdateOrDelete()
        {
            try
            {
                this.sqlCommand.ExecuteNonQuery();
            }
            catch (Exception E) { }
        }
        public void Dispose()
        {
            this.dataAdapter.Dispose();
            this.sqlCommand.Dispose();
        }
    }
}
