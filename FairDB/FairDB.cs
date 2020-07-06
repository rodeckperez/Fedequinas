using Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using Table;

namespace DataBase
{
    public class FairDB : CommonSql
    {
        private IDataBase iDataBase;
        public FairDB(IDataBase _iDataBase)
        {
            this.iDataBase = _iDataBase;
        }

        public QueryFairs GetFairs(RequestQueryFairs query)
        {
            this.iDataBase.ConfigExecution(this.ConnectionString, "APP_GetFairs", CommandType.StoredProcedure);
            this.iDataBase.AddParameter(DbType.Int32, "Start", 0, ParameterDirection.Input, query.Start, true);
            this.iDataBase.AddParameter(DbType.Int32, "Fetch", 0, ParameterDirection.Input, query.Fetch, true);
            this.iDataBase.AddParameter(DbType.String, "Search", 40, ParameterDirection.Input, query.Search, true);
            this.iDataBase.AddParameter(DbType.Int32, "FkAccount", 0, ParameterDirection.Input, query.FkAccount, true);

            try
            {
                this.iDataBase.Query();
                this.DataBaseActionOk = true;
                return BuildQueryFairs();

            }
            catch (Exception e)
            {
                this.DataBaseActionOk = false;
                this.Message = "Error de ejecución en base de datos (FairDB.GetFairs) " + e.Message;
            }

            return null;
        }


        public Fair GetFairsByID(RequestQueryFairDetail query)
        {
            this.iDataBase.ConfigExecution(this.ConnectionString, "APP_GetFairByID", CommandType.StoredProcedure);
            this.iDataBase.AddParameter(DbType.Int32, "FkAccount", 0, ParameterDirection.Input, query.PkAccount, true);
            this.iDataBase.AddParameter(DbType.Int32, "FkFair", 0, ParameterDirection.Input, query.FkFair, true);


            try
            {
                this.iDataBase.Query();
                this.DataBaseActionOk = true;
                return BuildFair(this.iDataBase.GetDataSet().Tables[0].Rows[0]);

            }
            catch (Exception e)
            {
                this.DataBaseActionOk = false;
                this.Message = "Error de ejecución en base de datos (FairDB.GetFairs) " + e.Message;
            }

            return null;
        }
        public QueryFairs GetFairsByAsociation(RequestQueryFairsByAsociation query)
        {
            this.iDataBase.ConfigExecution(this.ConnectionString, "APP_GetFairsByAsociation", CommandType.StoredProcedure);
            this.iDataBase.AddParameter(DbType.String, "FkAsociation", 4, ParameterDirection.Input, query.FkAsociation, true);
            this.iDataBase.AddParameter(DbType.Int32, "Start", 0, ParameterDirection.Input, query.Start, true);
            this.iDataBase.AddParameter(DbType.Int32, "Fetch", 0, ParameterDirection.Input, query.Fetch, true);
            this.iDataBase.AddParameter(DbType.Int32, "FkAccount", 0, ParameterDirection.Input, query.FkAccount, true);

            try
            {
                this.iDataBase.Query();
                this.DataBaseActionOk = true;
                return BuildQueryFairs();

            }
            catch (Exception e)
            {
                this.DataBaseActionOk = false;
                this.Message = "Error de ejecución en base de datos (FairDB.GetFairsByAsociation) " + e.Message;
            }

            return null;
        }

        public QueryFairs GetFairsByDate(RequestQueryFairsByDate query)
        {
            this.iDataBase.ConfigExecution(this.ConnectionString, "APP_GetFairsByDate", CommandType.StoredProcedure);
            this.iDataBase.AddParameter(DbType.String, "StartDate", 10, ParameterDirection.Input, query.StartDate, true);
            this.iDataBase.AddParameter(DbType.String, "EndDate", 10, ParameterDirection.Input, query.EndDate, true);
            this.iDataBase.AddParameter(DbType.Int32, "Start", 0, ParameterDirection.Input, query.Start, true);
            this.iDataBase.AddParameter(DbType.Int32, "Fetch", 0, ParameterDirection.Input, query.Fetch, true);
            this.iDataBase.AddParameter(DbType.Int32, "FkAccount", 0, ParameterDirection.Input, query.FkAccount, true);

            try
            {
                this.iDataBase.Query();
                this.DataBaseActionOk = true;
                return BuildQueryFairs();

            }
            catch (Exception e)
            {
                this.DataBaseActionOk = false;
                this.Message = "Error de ejecución en base de datos (FairDB.GetFairsByDate) " + e.Message;
            }

            return null;
        }

        public List<FairCategory> GetFairCategories(GetFairCateogiries getFair)
        {
            this.iDataBase.ConfigExecution(this.ConnectionString, "APP_GetFairCategories", CommandType.StoredProcedure);
            this.iDataBase.AddParameter(DbType.Int32, "PkFair", 0, ParameterDirection.Input, getFair.PkFair, true);
            this.iDataBase.AddParameter(DbType.String, "Walk", 2, ParameterDirection.Input, getFair.Walk, true);

            try
            {
                this.iDataBase.Query();
                this.DataBaseActionOk = true;
                return BuildFairCategories(this.iDataBase.GetDataSet().Tables[0].Rows);

            }
            catch (Exception e)
            {
                this.DataBaseActionOk = false;
                this.Message = "Error de ejecución en base de datos (FairDB.GetFairCategories) " + e.Message;
            }

            return null;
        }

        public bool InsertFairPhoto(FairPhoto fairPhoto)
        {
            this.iDataBase.ConfigExecution(this.ConnectionString, "APP_InsertFairPhoto", CommandType.StoredProcedure);
            this.iDataBase.AddParameter(DbType.Int32, "FkFair", 0, ParameterDirection.Input, fairPhoto.FkFair, true);
            this.iDataBase.AddParameter(DbType.String, "UrlPhoto", 250, ParameterDirection.Input, fairPhoto.UlrPhoto, true);

            try
            {
                this.iDataBase.NonQuery();
                this.DataBaseActionOk = true;
                return true;

            }
            catch (Exception e)
            {
                this.DataBaseActionOk = false;
                this.Message = "Error de ejecución en base de datos (FairDB.InsertFairPhoto) " + e.Message;
                return false;
            }
        }

        public List<FairResult> GetFairResultsByCategory(RequestGetFairResultsByCategory query)
        {
            this.iDataBase.ConfigExecution(this.ConnectionString, "APP_GetFairResultsByCategory", CommandType.StoredProcedure);
            this.iDataBase.AddParameter(DbType.Int32, "PkFairCategory", 0, ParameterDirection.Input, query.PkFairCategory, true);
            this.iDataBase.AddParameter(DbType.Int32, "PkFair", 0, ParameterDirection.Input, query.PkFair, true);
            this.iDataBase.AddParameter(DbType.String, "Walk", 2, ParameterDirection.Input, query.Walk, true);
            //this.iDataBase.AddParameter(DbType.Int32, "Gender", 0, ParameterDirection.Input, query.Gender, true);

            try
            {
                this.iDataBase.Query();
                this.DataBaseActionOk = true;
                return BuildFairResults(this.iDataBase.GetDataSet().Tables[0].Rows);

            }
            catch (Exception e)
            {
                this.DataBaseActionOk = false;
                this.Message = "Error de ejecución en base de datos (FairDB.GetFairResultsByCategory) " + e.Message;
            }

            return null;
        }

        public List<Asociation> GetAsociations()
        {
            this.iDataBase.ConfigExecution(this.ConnectionString, "APP_GetAsociations", CommandType.StoredProcedure);

            try
            {
                this.iDataBase.Query();
                this.DataBaseActionOk = true;
                return BuildAsociations(this.iDataBase.GetDataSet().Tables[0].Rows);

            }
            catch (Exception e)
            {
                this.DataBaseActionOk = false;
                this.Message = "Error de ejecución en base de datos (FairDB.GetAsociations) " + e.Message;
            }

            return null;
        }

        private List<Asociation> BuildAsociations(DataRowCollection Rows)
        {
            List<Asociation> list = new List<Asociation>();
            foreach (DataRow Row in Rows)
            {
                list.Add(BuildAsociation(Row));
            }

            return list;
        }

        private Asociation BuildAsociation(DataRow row)
        {
            return new Asociation()
            {
                AsociationCode = row["AsociationCode"].ToString(),
                Name = row["Name"].ToString(),
                UrlPhoto = WebConfigurationManager.AppSettings["UrlFotosAsociaciones"] + row["UrlPhoto"].ToString()
            };
        }

        private FairResult BuildFairResult(DataRow row)
        {
            return new FairResult()
            {
                HorseName = row["HorseName"].ToString(),
                PkHorse = Int32.Parse(row["PkHorse"].ToString()),
                Result = row["Result"].ToString(),
            };
        }

        private List<FairResult> BuildFairResults(DataRowCollection Rows)
        {
            List<FairResult> list = new List<FairResult>();
            foreach (DataRow Row in Rows)
            {
                list.Add(BuildFairResult(Row));
            }

            return list;
        }

        private List<FairCategory> BuildFairCategories(DataRowCollection Rows)
        {
            List<FairCategory> list = new List<FairCategory>();
            foreach (DataRow Row in Rows)
            {
                list.Add(BuildFairCategory(Row));
            }

            return list;
        }

        private FairCategory BuildFairCategory(DataRow row)
        {
            return new FairCategory()
            {
                Name = row["Name"].ToString(),
                PkFairCategory = Int32.Parse(row["PkFairCategory"].ToString())
            };
        }

        private QueryFairs BuildQueryFairs()
        {
            return new QueryFairs()
            {
                TotalRecords = Int32.Parse(this.iDataBase.GetDataSet().Tables[1].Rows[0][0].ToString()),
                Fairs = BuildFairs(this.iDataBase.GetDataSet().Tables[0].Rows)
            };
        }

        private List<Fair> BuildFairs(DataRowCollection Rows)
        {
            List<Fair> fairs = new List<Fair>();
            foreach (DataRow Row in Rows)
            {
                if (fairs.Where(x => x.PkFair == Int32.Parse(Row["PkFair"].ToString())).FirstOrDefault() == null)
                {
                    fairs.Add(BuildFair(Row));
                }

            }

            return fairs;
        }

        private Fair BuildFair(DataRow row)
        {
            return new Fair()
            {
                Zona = String.IsNullOrEmpty(row["Zona"].ToString()) == true ? "" : row["Zona"].ToString(),
                Asociation = String.IsNullOrEmpty(row["Asociation"].ToString()) == true ? "" : row["Asociation"].ToString(),
                EndDate = String.IsNullOrEmpty(row["EndDate"].ToString()) == true ? "" : row["EndDate"].ToString(),
                Grade = String.IsNullOrEmpty(row["Grade"].ToString()) == true ? "" : row["Grade"].ToString(),
                Name = row["Name"].ToString(),
                PkFair = Int32.Parse(row["PkFair"].ToString()),
                StartDate = String.IsNullOrEmpty(row["StartDate"].ToString()) == true ? "" : row["StartDate"].ToString(),
                UrlPhoto = WebConfigurationManager.AppSettings["UrlFotosFerias"] + row["UrlPhoto"].ToString(),
                UploadPhoto = row["UploadPhoto"].ToString().Equals("0") ? false : true
            };
        }


    }
}