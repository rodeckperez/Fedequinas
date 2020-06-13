using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    using System.Data;

    public interface IDataBase
    {
        void AddParameter(DbType type, string Name, int Size, ParameterDirection Direcction, object Value, bool AssignValue);
        void AddParameter(SqlDbType type, string Name, int Size, ParameterDirection Direcction, object Value, bool AssignValue);
        void ConfigExecution(string ConexionString, string sql, System.Data.CommandType Type);
        void Query();
        void UpdateOrDelete();
        DataSet GetDataSet();
        void NonQuery();
        void Dispose();
    }
}