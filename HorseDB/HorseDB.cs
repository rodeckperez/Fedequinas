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
    public class AccountDB : CommonSql
    {
        private IDataBase iDataBase;
        private Horse tree = new Horse();

        public AccountDB(IDataBase _iDataBase)
        {
            this.iDataBase = _iDataBase;
        }
        public Photo Photo { set; get; }
        public QueryHorses GetHorsesWithoutFilters(RequestQueryHorses query)
      {
            this.iDataBase.ConfigExecution(this.ConnectionString, "APP_GetHorsesWithoutFilters", CommandType.StoredProcedure);
            this.iDataBase.AddParameter(DbType.Int32, "FkAccount", 0, ParameterDirection.Input, query.PkAccount, true);
            this.iDataBase.AddParameter(DbType.Int32, "Start", 0, ParameterDirection.Input, query.Start, true);
            this.iDataBase.AddParameter(DbType.Int32, "Fetch", 0, ParameterDirection.Input, query.Fetch, true);
            this.iDataBase.AddParameter(DbType.String, "Search", 40, ParameterDirection.Input, query.Search, true);

            try
            {
                this.iDataBase.Query();
                this.DataBaseActionOk = true;
                return BuildQueryHorses();
                
            }
            catch (Exception e)
            {
                this.DataBaseActionOk = false;
                this.Message = "Error de ejecución en base de datos (HorseDBs.GetHorsesWithoutFilters) "+e.Message;
            }

            return null;
        }

        public Horse GetHorseDetail(RequestQueryHorseDetail query)
        {
            this.iDataBase.ConfigExecution(this.ConnectionString, "APP_GetHorseDetail", CommandType.StoredProcedure);
            this.iDataBase.AddParameter(DbType.Int32, "FkAccount", 0, ParameterDirection.Input, query.PkAccount, true);
            this.iDataBase.AddParameter(DbType.Int32, "FkHorse", 0, ParameterDirection.Input, query.FkHorse, true);
            
            try
            {
                this.iDataBase.Query();
                this.DataBaseActionOk = true;
                return BuildHorse(this.iDataBase.GetDataSet().Tables[0].Rows[0]);

            }
            catch (Exception e)
            {
                this.DataBaseActionOk = false;
                this.Message = "Error de ejecución en base de datos (HorseDBs.GetHorseDetail) " + e.Message;
            }

            return null;
        }

        public List<string> GetFairsByHorsePartipation(int pkHorse)
        {
            this.iDataBase.ConfigExecution(this.ConnectionString, "APP_GetFairsByHorsePartipation", CommandType.StoredProcedure);
            this.iDataBase.AddParameter(DbType.Int32, "PkHorse", 0, ParameterDirection.Input, pkHorse, true);
            
            try
            {
                this.iDataBase.Query();
                this.DataBaseActionOk = true;
                return BuildListString();

            }
            catch (Exception e)
            {
                this.DataBaseActionOk = false;
                this.Message = "Error de ejecución en base de datos (HorseDBs.GetFairsByHorsePartipation) " + e.Message;
            }

            return null;
        }

        public List<ParticipationRecord> GetParticipationRecord(RequestParticipationRecord request)
        {
            this.iDataBase.ConfigExecution(this.ConnectionString, "APP_GetParticipationRecord", CommandType.StoredProcedure);
            this.iDataBase.AddParameter(DbType.Int32, "PkHorse", 0, ParameterDirection.Input, request.PkHorse, true);
            this.iDataBase.AddParameter(DbType.Int32, "Year", 0, ParameterDirection.Input, request.Year, true);

            try
            {
                this.iDataBase.Query();
                this.DataBaseActionOk = true;
                return BuildParticipationRecords();

            }
            catch (Exception e)
            {
                this.DataBaseActionOk = false;
                this.Message = "Error de ejecución en base de datos (HorseDBs.GetParticipationRecord) " + e.Message;
            }

            return null;
        }

        private List<ParticipationRecord> BuildParticipationRecords()
        {
            List<ParticipationRecord> list = new List<ParticipationRecord>();
            foreach (DataRow row in this.iDataBase.GetDataSet().Tables[0].Rows)
            {
                list.Add(BuildParticipationRecord(row));
            }

            return list;
        }

        private ParticipationRecord BuildParticipationRecord(DataRow row)
        {
            return new ParticipationRecord()
            {
                Andar = row["Andar"].ToString(),
                Categoria = row["Categoria"].ToString(),
                Grado= row["Grado"].ToString(),
                Puesto = Int32.Parse(row["Puesto"].ToString()),
                Feria = row["Feria"].ToString(),
                Zona = row["ZONA"].ToString()
            };
        }

        private List<string> BuildListString()
        {
            List<string> list = new List<string>();
            foreach(DataRow row in this.iDataBase.GetDataSet().Tables[0].Rows)
            {
                list.Add(row[0].ToString());
            }

            return list;
        }

        public bool CanUploadPhoto(int fkHorse)
        {
            this.iDataBase.ConfigExecution(this.ConnectionString, "APP_CanUploadHorsePhoto", CommandType.StoredProcedure);
            this.iDataBase.AddParameter(DbType.Int32, "FkHorse", 0, ParameterDirection.Input, fkHorse, true);
            
            try
            {
                this.iDataBase.Query();
                this.DataBaseActionOk = true;
                return this.iDataBase.GetDataSet().Tables[0].Rows[0][0].ToString().Equals("0") ? false:true;

            }
            catch (Exception e)
            {
                this.DataBaseActionOk = false;
                this.Message = "Error de ejecución en base de datos (HorseDBs.CanUploadPhoto) " + e.Message;
                return false;
            }
        }

        public List<Photo> GetHorsePhotos(int FkHorse)
        {
            this.iDataBase.ConfigExecution(this.ConnectionString, "APP_GetHorsePhotos", CommandType.StoredProcedure);
            this.iDataBase.AddParameter(DbType.Int32, "FkHorse", 0, ParameterDirection.Input, FkHorse, true);
            
            try
            {
                this.iDataBase.Query();
                this.DataBaseActionOk = true;
                return BuildHorsePhotos(this.iDataBase.GetDataSet().Tables[0].Rows);

            }
            catch (Exception e)
            {
                this.DataBaseActionOk = false;
                this.Message = "Error de ejecución en base de datos (HorseDBs.GetHorsePhotos) " + e.Message;
            }

            return null;
        }

        public void InsertEjemplarFoto()
        {
            this.iDataBase.ConfigExecution(this.ConnectionString, "APP_InsertEjemplarFoto", CommandType.StoredProcedure);
            this.iDataBase.AddParameter(DbType.Int32, "FkEjemplar", 0, ParameterDirection.Input, Photo.PkHorse, true);
            this.iDataBase.AddParameter(DbType.String, "RutaFoto", 200, ParameterDirection.Input, Photo.Url, true);

            try
            {
                this.iDataBase.NonQuery();
                this.DataBaseActionOk = true;

            }
            catch (Exception e)
            {
                this.DataBaseActionOk = false;
                this.Message = "Error de ejecución en base de datos (HorseDBs.InsertEjemplarFoto) " + e.Message;
            }
        }

        public string GetHorsePhotoName(int PkHorsePhoto)
        {
            this.iDataBase.ConfigExecution(this.ConnectionString, "APP_GetHorsePhotoName", CommandType.StoredProcedure);
            this.iDataBase.AddParameter(DbType.Int32, "PkHorsePhoto", 0, ParameterDirection.Input, PkHorsePhoto, true);

            try
            {
                this.iDataBase.Query();
                this.DataBaseActionOk = true;
                return this.iDataBase.GetDataSet().Tables[0].Rows[0][0].ToString();
            }
            catch (Exception e)
            {
                this.DataBaseActionOk = false;
                this.Message = "Error de ejecución en base de datos (HorseDBs.GetHorsePhotoName) " + e.Message;
                return "";
            }
        }

        public void DeleteHorsePhoto(int PkHorsePhoto)
        {
            this.iDataBase.ConfigExecution(this.ConnectionString, "APP_DeleteHorsePhoto", CommandType.StoredProcedure);
            this.iDataBase.AddParameter(DbType.Int32, "PkHorsePhoto", 0, ParameterDirection.Input, PkHorsePhoto, true);
            
            try
            {
                this.iDataBase.NonQuery();
                this.DataBaseActionOk = true;

            }
            catch (Exception e)
            {
                this.DataBaseActionOk = false;
                this.Message = "Error de ejecución en base de datos (HorseDBs.PkHorsePhoto) " + e.Message;
            }
        }

        private List<Photo> BuildHorsePhotos(DataRowCollection Rows)
        {
            List<Photo> photos = new List<Photo>();
            foreach (DataRow Row in Rows)
            {
                photos.Add(new Photo() {
                    PkHorsePhoto = Int32.Parse(Row[1].ToString()),
                    Url = WebConfigurationManager.AppSettings["UrlHorsePhoto"] +Row[0].ToString(),
                });
            }

            return photos;
        }

        private QueryHorses BuildQueryHorses()
        {
            return new QueryHorses()
            {
                TotalRecords = Int32.Parse(this.iDataBase.GetDataSet().Tables[1].Rows[0][0].ToString()),
                Horses = BuildHorses(this.iDataBase.GetDataSet().Tables[0].Rows)
            };
        }


        public QueryHorses GetHorsesByGender(RequestGetHorsesByGender query)
        {
            this.iDataBase.ConfigExecution(this.ConnectionString, "APP_GetHorsesByGender", CommandType.StoredProcedure);
            this.iDataBase.AddParameter(DbType.String, "Gender", 10, ParameterDirection.Input, query.Gender, true);
            this.iDataBase.AddParameter(DbType.String, "Search", 40, ParameterDirection.Input, query.Search, true);
            this.iDataBase.AddParameter(DbType.Int32, "Start", 0, ParameterDirection.Input, query.Start, true);
            this.iDataBase.AddParameter(DbType.Int32, "Fetch", 0, ParameterDirection.Input, query.Fetch, true);

            try
            {
                this.iDataBase.Query();
                this.DataBaseActionOk = true;
                return BuildQueryHorses();

            }
            catch (Exception e)
            {
                this.DataBaseActionOk = false;
                this.Message = "Error de ejecución en base de datos (HorseDBs.GetHorsesByGender) " + e.Message;
            }

            return null;
        }

        private List<Horse> BuildHorses(DataRowCollection Rows)
        {
            List<Horse> Horses = new List<Horse>();
            foreach(DataRow Row in Rows)
            {
                Horses.Add(BuildHorse(Row));
            }

            return Horses;
        }

        private List<DescendancyByGender> BuildDescendancyByGender(DataRowCollection Rows)
        {
            List<DescendancyByGender> list = new List<DescendancyByGender>();
            foreach (DataRow Row in Rows)
            {
                list.Add(new DescendancyByGender() {
                    Gender = Row["Gender"].ToString(),
                    Total = Int32.Parse(Row["Total"].ToString())
                });
            }

            return list;
        }

        private List<DescendancyByGenderWalk> BuildDescendancyByGenderWalk(DataRowCollection Rows)
        {
            List<DescendancyByGenderWalk> list = new List<DescendancyByGenderWalk>();
            foreach (DataRow Row in Rows)
            {
                list.Add(new DescendancyByGenderWalk()
                {
                    Walk = Row["Walk"].ToString(),
                    Total = Int32.Parse(Row["Total"].ToString())
                });
            }

            return list;
        }

        private Horse BuildHorse(DataRow row)
        {
            var Url = "";
            if (!row["UrlMainPhoto"].ToString().Trim().Equals(""))
                Url = WebConfigurationManager.AppSettings["UrlHorsePhoto"] + row["UrlMainPhoto"].ToString();
            return new Horse()
            {
                Color = row["Color"].ToString(),
                Father = new Horse()
                {
                    PkHorse = Int32.Parse(row["PkFather"].ToString()),
                    Name = row["NameFather"].ToString()
                },
                Gender = row["Gender"].ToString(),
                Gg = "",
                Microchip = row["Microchip"].ToString(),
                Mother = new Horse()
                {
                    PkHorse = Int32.Parse(row["PkMother"].ToString()),
                    Name = row["NameMother"].ToString()
                },
                MyHorse = row["MyHorse"].ToString() == "1" ? true : false,
                Name = row["Name"].ToString(),
                PkHorse = Int32.Parse(row["PkHorse"].ToString()),
                UrlMainPhoto = Url,
                Year = Int32.Parse(row["Year"].ToString()),
                Walk = row["Walk"].ToString(),

                Association = row["Association"].ToString(),
                BornDate = row["BornDate"].ToString(),
                Breeder = row["Breeder"].ToString(),
                EquineType = row["EquineType"].ToString(),
                Genotyping = row["Genotyping"].ToString(),
                Months = Int32.Parse(row["Months"].ToString()),
                Node = "",
                NodeParent = "",
                Done = 0,
                Photos = new List<Photo>()
            };
        }

        public List<Horse> GetHorseDescendancy(RequestQueryAccountHorse query)
        {
            this.iDataBase.ConfigExecution(this.ConnectionString, "APP_GetHorseDescendancy", CommandType.StoredProcedure);
            this.iDataBase.AddParameter(DbType.Int32, "FkAccount", 0, ParameterDirection.Input, query.FkAccount, true);
            this.iDataBase.AddParameter(DbType.Int32, "FkHorse", 0, ParameterDirection.Input, query.FkHorse, true);
            this.iDataBase.AddParameter(DbType.String, "Gender", 1, ParameterDirection.Input, query.Gender, true);
            this.iDataBase.AddParameter(DbType.String, "Walk", 2, ParameterDirection.Input, query.Walk, true);

            try
            {
                this.iDataBase.Query();
                this.DataBaseActionOk = true;
                return BuildHorses(this.iDataBase.GetDataSet().Tables[0].Rows);

            }
            catch (Exception e)
            {
                this.DataBaseActionOk = false;
                this.Message = "Error de ejecución en base de datos (HorseDB.GetHorseDescendancy) " + e.Message;
            }

            return null;
        }

        public List<DescendancyByGender> GetHorseDescendancyByGender(int FkHorse)
        {
            this.iDataBase.ConfigExecution(this.ConnectionString, "APP_GetHorseDescendancyByGender", CommandType.StoredProcedure);
            this.iDataBase.AddParameter(DbType.Int32, "FkHorse", 0, ParameterDirection.Input, FkHorse, true);
            
            try
            {
                this.iDataBase.Query();
                this.DataBaseActionOk = true;
                return BuildDescendancyByGender(this.iDataBase.GetDataSet().Tables[0].Rows);

            }
            catch (Exception e)
            {
                this.DataBaseActionOk = false;
                this.Message = "Error de ejecución en base de datos (HorseDB.GetHorseDescendancy) " + e.Message;
            }

            return null;
        }

        public List<DescendancyByGenderWalk> GetHorseDescendancyByGenderWalk(RequestHorseDescendancyByGenderWalk request)
        {
            this.iDataBase.ConfigExecution(this.ConnectionString, "APP_GetHorseDescendancyByGenderWalk", CommandType.StoredProcedure);
            this.iDataBase.AddParameter(DbType.Int32, "FkHorse", 0, ParameterDirection.Input, request.FkHorse, true);
            this.iDataBase.AddParameter(DbType.String, "Gender", 0, ParameterDirection.Input, request.Gender, true);

            try
            {
                this.iDataBase.Query();
                this.DataBaseActionOk = true;
                return BuildDescendancyByGenderWalk(this.iDataBase.GetDataSet().Tables[0].Rows);

            }
            catch (Exception e)
            {
                this.DataBaseActionOk = false;
                this.Message = "Error de ejecución en base de datos (HorseDB.GetHorseDescendancy) " + e.Message;
            }

            return null;
        }

        public List<Horse> GetHorseGenalogy(RequestQueryAccountHorse query)
        {
            this.iDataBase.ConfigExecution(this.ConnectionString, "APP_Genealogy", CommandType.StoredProcedure);
            this.iDataBase.AddParameter(DbType.Int32, "FkHorse", 0, ParameterDirection.Input, query.FkHorse, true);
            this.iDataBase.AddParameter(DbType.Int32, "FkAccount", 0, ParameterDirection.Input, query.FkAccount, true);
            
            try
            {
                this.iDataBase.Query();
                this.DataBaseActionOk = true;
                return BuildHorses(this.iDataBase.GetDataSet().Tables[0].Rows);
            }
            catch (Exception e)
            {
                this.DataBaseActionOk = false;
                this.Message = "Error de ejecución en base de datos (HorseDB.GetHorseGenalogy) " + e.Message;
            }

            return null;
        }
    }
}