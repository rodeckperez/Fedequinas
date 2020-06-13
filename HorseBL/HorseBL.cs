using Base;
using Common;
using CommonEntity;
using DataBase;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Configuration;
using Table;
using Util;

namespace BusinessRules
{
    public class HorseBL
    {
        private List<string> HorseNodes = new List<string>();
        private List<string> NodesToShow = new List<string>();
        private int NodeCounter = 1;
        private string JsonNodes = "";
        private string NodeParent = "";
        private List<string> Pendings = new List<string>();
        private List<Horse> GenealogyHorses = new List<Horse>();
        private bool IsSimulator = false;

        private string UrlPage { set; get; }
        private string PageName { set; get; }


        public BaseResponse<List<DescendancyByGenderWalk>> GetHorseDescendancyByGenderWalk(RequestHorseDescendancyByGenderWalk request)
        {
            BaseResponse<List<DescendancyByGenderWalk>> baseResponse = new BaseResponse<List<DescendancyByGenderWalk>>();
            AccountDB db = new AccountDB(new SqlServer());

            var list = db.GetHorseDescendancyByGenderWalk(request);

            if (db.DataBaseActionOk)
            {
                baseResponse.BusinessActionOk = true;
                baseResponse.ServerActionOk = true;
                baseResponse.Response = list;
            }
            else
            {
                baseResponse.BusinessActionOk = false;
                baseResponse.ServerActionOk = false;
                baseResponse.Message = db.Message;
                baseResponse.Response = new List<DescendancyByGenderWalk>();
            }

            return baseResponse;
        }

        public BaseResponse<List<DescendancyByGender>> GetHorseDescendancyByGender(int FkHorse)
        {
            BaseResponse<List<DescendancyByGender>> baseResponse = new BaseResponse<List<DescendancyByGender>>();
            AccountDB db = new AccountDB(new SqlServer());

            var list = db.GetHorseDescendancyByGender(FkHorse);

            if (db.DataBaseActionOk)
            {
                baseResponse.BusinessActionOk = true;
                baseResponse.ServerActionOk = true;
                baseResponse.Response = list;
            }
            else
            {
                baseResponse.BusinessActionOk = false;
                baseResponse.ServerActionOk = false;
                baseResponse.Message = db.Message;
                baseResponse.Response = new List<DescendancyByGender>();
            }

            return baseResponse;
        }

        public BaseResponse<Horse> GetHorseDetail(RequestQueryHorseDetail query)
        {
            BaseResponse<Horse> baseResponse = new BaseResponse<Horse>();
            AccountDB db = new AccountDB(new SqlServer());

            var horse = db.GetHorseDetail(query);

            if (db.DataBaseActionOk)
            {
                baseResponse.BusinessActionOk = true;
                baseResponse.ServerActionOk = true;
                baseResponse.Response = horse;
            }
            else
            {
                baseResponse.BusinessActionOk = false;
                baseResponse.ServerActionOk = false;
                baseResponse.Message = db.Message;
                baseResponse.Response = new Horse();
            }

            return baseResponse;
        }

        public BaseResponse<List<ParticipationRecord>> GetParticipationRecord(RequestParticipationRecord request)
        {
            BaseResponse<List<ParticipationRecord>> baseResponse = new BaseResponse<List<ParticipationRecord>>();
            AccountDB db = new AccountDB(new SqlServer());

            var list = db.GetParticipationRecord(request);

            if (db.DataBaseActionOk)
            {
                baseResponse.BusinessActionOk = true;
                baseResponse.Response = list;
                baseResponse.ServerActionOk = true;
            }
            else
            {
                baseResponse.BusinessActionOk = false;
                baseResponse.ServerActionOk = false;
                baseResponse.Message = db.Message;
            }

            return baseResponse;
        }

        public BaseResponse<List<string>> GetFairsByHorsePartipation(int pkHorse)
        {
            BaseResponse<List<string>> baseResponse = new BaseResponse<List<string>>();
            AccountDB db = new AccountDB(new SqlServer());

            var list = db.GetFairsByHorsePartipation(pkHorse);

            if (db.DataBaseActionOk)
            {
                baseResponse.BusinessActionOk = true;
                baseResponse.Response = list;
                baseResponse.ServerActionOk = true;
            }
            else
            {
                baseResponse.BusinessActionOk = false;
                baseResponse.ServerActionOk = false;
                baseResponse.Message = db.Message;
            }

            return baseResponse;
        }

        public BaseResponse<QueryHorses> GetHorsesWithoutFilters(RequestQueryHorses query)
        {
            BaseResponse<QueryHorses> baseResponse = new BaseResponse<QueryHorses>();
            AccountDB db = new AccountDB(new SqlServer());

            QueryHorses queryHorses = db.GetHorsesWithoutFilters(query);
            if (db.DataBaseActionOk)
            {
                baseResponse.BusinessActionOk = true;
                baseResponse.ServerActionOk = true;
                baseResponse.Message = "";
                baseResponse.Response = queryHorses;
            }
            else
            {
                baseResponse.BusinessActionOk = false;
                baseResponse.ServerActionOk = false;
                baseResponse.Response = null;
                baseResponse.Message = db.Message;
            }

            return baseResponse;
        }

        public BaseResponse<List<Photo>> GetHorsePhotos(int FkHorse)
        {
            BaseResponse<List<Photo>> baseResponse = new BaseResponse<List<Photo>>();
            AccountDB db = new AccountDB(new SqlServer());
            baseResponse.Response = db.GetHorsePhotos(FkHorse);

            if (db.DataBaseActionOk)
            {
                baseResponse.ServerActionOk = true;
                baseResponse.BusinessActionOk = true;
            }
            else
            {
                baseResponse.BusinessActionOk = false;
                baseResponse.ServerActionOk = false;
                baseResponse.Message = db.Message;
            }

            return baseResponse;
        }

        public BaseResponse<List<Horse>> GetHorseDescendancy(RequestQueryAccountHorse query)
        {
            BaseResponse<List<Horse>> baseResponse = new BaseResponse<List<Horse>>();
            AccountDB db = new AccountDB(new SqlServer());
            baseResponse.Response = db.GetHorseDescendancy(query);

            if (db.DataBaseActionOk)
            {
                baseResponse.ServerActionOk = true;
                baseResponse.BusinessActionOk = true;
            }
            else
            {
                baseResponse.BusinessActionOk = false;
                baseResponse.ServerActionOk = false;
                baseResponse.Message = db.Message;
            }

            return baseResponse;
        }

        public BaseResponse<SimpleResponse> UploadPhoto(Photo photo)
        {
            BaseResponse<SimpleResponse> response = new BaseResponse<SimpleResponse>();
            if (CanUploadPhoto(photo.PkHorse))
            {
                CreatePhotoFile(photo);
                InsertEjemplarFoto(photo);
                response.BusinessActionOk = true;
                response.ServerActionOk = true;
                response.Message = "";
            }
            else
            {
                response.BusinessActionOk = false;
                response.ServerActionOk = true;
                response.Message = "Ha superado el límite de fotos por ejemplar";
            }
            
            return response;
        }

        private bool CanUploadPhoto(int fkHorse)
        {
            AccountDB db = new AccountDB(new SqlServer());

            return db.CanUploadPhoto(fkHorse);
        }

        private void CreatePhotoFile(Photo photo)
        {
            Utility utility = new Utility();
            utility.Text64 = photo.ContentBase64;
            utility.Path = WebConfigurationManager.AppSettings["PathHorsePhotos"] + photo.FileName + "." + photo.MymeType;
            ThreadStart threadDelegated = new ThreadStart(utility.String64ToFile);
            Thread thread = new Thread(threadDelegated);
            thread.Start();
        }

        private void InsertEjemplarFoto(Photo photo)
        {
            AccountDB db = new AccountDB(new SqlServer());
            photo.Url = photo.FileName + "." + photo.MymeType;
            db.Photo = photo;

            ThreadStart threadDelegated = new ThreadStart(db.InsertEjemplarFoto);
            Thread thread = new Thread(threadDelegated);
            thread.Start();
        }

        private void CreateCurrentNode(int i, int FkHorse)
        {
            Horse horse;
            string UrlPhoto;

            //EL NODO SE ASUME QUE YA EXISTE DEBIDO A QUE PUDO HABER SIDO CREADO
            //CUANDO SE CREARON PADRES O MADRES
            //SI EL NODO EXISTE, NO HACE NADA-->SIGUE EL CONTROL AL METODO CreateParentChild()

            //NODO NO EXISTE

            if (!HorseNodes.Contains("Node_" + GenealogyHorses[i].PkHorse))
            {
                //AGREGA A PENDIENTES
                Pendings.Add(i.ToString());
            }
        }
        
        private void CreateParentNode(Horse horse)
        {
            string UrlPhoto;

            UrlPhoto = horse.UrlMainPhoto != "" ? horse.UrlMainPhoto : WebConfigurationManager.AppSettings["UrlHoseDefault"];
            UrlPhoto = horse.Name.Contains("FC") || horse.Name.Contains("F.C") ? WebConfigurationManager.AppSettings["UrlColombiaPhoto"] : UrlPhoto;

            if (!this.IsSimulator)
            {
                JsonNodes += @"Node_" + NodeCounter + "={text: { name: \"" + horse.Name + "\"," +
                                                            "contact:{val: \"" + horse.Name + "-" + horse.Association + " " + horse.PkHorse + "-" + horse.EquineType + " " + horse.Genotyping + " " + horse.Gender + "\"," +
                                                                    "href: \""+UrlPage+"?PkHorse=" + horse.PkHorse + "\"," +
                                                                    "target: \"_self\"" +
                                                                    "}" +
                                                        "}," +
                                                    "image: \"" + UrlPhoto + "\"," +
                                                    "HTMLclass: \"nodeExample1\"" +
                                                    "};";
            }
            else
            {
                JsonNodes += @"Node_" + NodeCounter + "={parent: NODE_PARENT,text: { name: \"" + horse.Name + "\"," +
                                                            "contact:{val: \"" + horse.Name + "-" + horse.Association + " " + horse.PkHorse + "-" + horse.EquineType + " " + horse.Genotyping + " " + horse.Gender + "\"," +
                                                                    "href: \""+UrlPage+"?PkHorse=" + horse.PkHorse + "\"," +
                                                                    "target: \"_self\"" +
                                                                    "}" +
                                                        "}," +
                                                    "image: \"" + UrlPhoto + "\"," +
                                                    "HTMLclass: \"nodeExample1\"" +
                                                    "};";
            }
            

            HorseNodes.Add("Node_" + horse.PkHorse);
            NodesToShow.Add("Node_" + NodeCounter);
            GenealogyHorses[0].Node = "Node_" + NodeCounter;
            NodeCounter++;
        }

        private void CreateSimulatorNodeParent()
        {

            string UrlPhoto;
            UrlPhoto = WebConfigurationManager.AppSettings["UrlHoseDefault"];

            JsonNodes += "NODE_PARENT={text: { name: \"Ejemplar Simulado\"" +                                                           
                                                    "}," +
                                       "image: \"" + UrlPhoto + "\"," +
                                        "HTMLclass: \"nodeExample1\"};";
            HorseNodes.Add("NODE_PARENT");
            NodesToShow.Add("NODE_PARENT");
        }

        private void CreateParentChild(int i,bool parent)
        {

            string UrlPhoto;
            int? parentPk = 0;

            if (parent)
            {
                parentPk = GenealogyHorses[i].Father.PkHorse;
            }
            else
            {
                parentPk = GenealogyHorses[i].Mother.PkHorse;
            }

            
            NodeParent = GenealogyHorses[i].Node;

            if (NodeParent != "")
            {
                if (parentPk != 0)
                {
                    for (int j = 0; j < GenealogyHorses.Count; j++)
                    {
                        if (GenealogyHorses[j].PkHorse == parentPk)
                        {
                            if (NodeCounter == 23)
                            {

                            }
                            Horse child = GenealogyHorses[j];
                            UrlPhoto = child.UrlMainPhoto != "" ? child.UrlMainPhoto : WebConfigurationManager.AppSettings["UrlHoseDefault"];
                            UrlPhoto = child.Name.Contains("FC") || child.Name.Contains("F.C") ? WebConfigurationManager.AppSettings["UrlColombiaPhoto"] : UrlPhoto;


                            HorseNodes.Add("Node_" + child.PkHorse);
                            NodesToShow.Add("Node_" + NodeCounter);
                            JsonNodes += @"Node_" + NodeCounter + "={parent: " + NodeParent + "," +
                                                                    "text: { name: \"" + child.Name + "\"," +
                                                                            "contact:{val: \"" + child.Name + "-" + child.Association + " " + child.PkHorse + "-" + child.EquineType + " " + child.Genotyping + " " + child.Gender + "\"," +
                                                                                    "href: \""+UrlPage+"?PkHorse=" + child.PkHorse + "\"," +
                                                                                    "target: \"_self\"" +
                                                                                    "}" +
                                                                            "}," +
                                                                     "image: \"" + UrlPhoto + "\"," +
                                                                      "HTMLclass: \"nodeExample1\"" +
                                                                     "}; ";

                            GenealogyHorses[j].Node = "Node_" + NodeCounter;
                            GenealogyHorses[j].NodeParent = NodeParent;
                            NodeCounter++;
                            if (Pendings.Contains(j.ToString()))
                            {
                                //j esta en los pendientes
                                CreateParentChild(j, true);
                                GenealogyHorses[i].Done = 1;
                                CreateParentChild(j, false);
                                GenealogyHorses[i].Done = 2;
                            }

                        }
                    }
                }
                else
                {

                    //EL NO EJEMPLAR TIENE PADRE
                    HorseNodes.Add("Node_" + NodeCounter);
                    NodesToShow.Add("Node_" + NodeCounter);
                    UrlPhoto = WebConfigurationManager.AppSettings["UrlNoNoMorePhoto"];
                    JsonNodes += @"Node_" + NodeCounter + "={parent: " + NodeParent + "," +
                                                                "image: \"" + UrlPhoto + "\"," +
                                                                "HTMLclass: \"nodeExample2\"" +
                                                                "}; ";

                    NodeCounter++;
                }
            }
            else
            {
                //ejemplar no ha sido procesado
                Pendings.Add(i.ToString());
            }
        }

        private string BuildGenealogyNodes(List<Horse> horses,int FkHorse,bool IsSimulator)
        {
            this.IsSimulator = IsSimulator;
            GenealogyHorses = horses;
            JsonNodes = "";
                
            if (this.IsSimulator && !HorseNodes.Contains("NODE_PARENT"))
            {
                CreateSimulatorNodeParent();
            }
            CreateParentNode(horses[0]);

            CreateParentChild(0, true);
            CreateParentChild(0, false);
            GenealogyHorses[0].Done = 2;

            for (int i=1; i<horses.Count;i++)
            {
                //ELEMENTO ACTUAL NO ESTA CREADO
                CreateCurrentNode(i,FkHorse);

                if (!Pendings.Contains(i.ToString()))
                {
                    CreateParentChild(i, true);
                    GenealogyHorses[i].Done = 1;
                    CreateParentChild(i, false);
                    GenealogyHorses[i].Done = 2;
                }
            }

            return JsonNodes;

        }

        public BaseResponse<SimpleResponse> GetHorseGenealogy(RequestQueryAccountHorse query)
        {
            AccountDB db = new AccountDB(new SqlServer());
            ParameterDB parameterDB = new ParameterDB(new SqlServer());
            string HtmlGenealogy = parameterDB.GetParameterValue("HtmlGenealogy");
            BaseResponse<SimpleResponse> baseResponse = new BaseResponse<SimpleResponse>();
            List<Horse> horses = db.GetHorseGenalogy(query);

            PageName = WebConfigurationManager.AppSettings["PathHtmlPages"] + query.FkHorse + "_" + query.FkAccount + "_" + (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds + ".html";
            UrlPage = PageName.Replace(WebConfigurationManager.AppSettings["PathHtmlPages"], WebConfigurationManager.AppSettings["UrlHtmlPages"]);

            HtmlGenealogy= HtmlGenealogy.Replace("{NODE_DETAILS}", BuildGenealogyNodes(horses, query.FkHorse,false));
            HtmlGenealogy = HtmlGenealogy.Replace("{NODE_VAR_NAMES}", string.Join(", ",NodesToShow));

            File.WriteAllText(PageName, HtmlGenealogy);

            baseResponse.Response = new SimpleResponse()
            {
                Text = UrlPage
            };

            if (db.DataBaseActionOk)
            {
                baseResponse.ServerActionOk = true;
                baseResponse.BusinessActionOk = true;
            }
            else
            {
                baseResponse.ServerActionOk = false;
                baseResponse.BusinessActionOk = false;
                baseResponse.Message = db.Message;
            }

            return baseResponse;
        }

        public BaseResponse<SimpleResponse> Simulator(RequestSimulador query)
        {
            AccountDB db = new AccountDB(new SqlServer());
            ParameterDB parameterDB = new ParameterDB(new SqlServer());
            string HtmlGenealogy = parameterDB.GetParameterValue("HtmlSimulator");
            BaseResponse<SimpleResponse> baseResponse = new BaseResponse<SimpleResponse>();

            List<Horse> horses = db.GetHorseGenalogy(query.Male);
            string malesHtml = BuildGenealogyNodes(horses, query.Male.FkHorse,true);

            horses = db.GetHorseGenalogy(query.Female);
            string femalesHtml = BuildGenealogyNodes(horses, query.Female.FkHorse,true);


            HtmlGenealogy = HtmlGenealogy.Replace("{NODE_DETAILS}", malesHtml+femalesHtml);
            HtmlGenealogy = HtmlGenealogy.Replace("{NODE_VAR_NAMES}", string.Join(", ", NodesToShow));

            string fileName = WebConfigurationManager.AppSettings["PathHtmlPages"] + query.Male.FkHorse + "_" + query.Male.FkAccount + "_" + (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds + ".html";
            string UrlPage = fileName.Replace(WebConfigurationManager.AppSettings["PathHtmlPages"], WebConfigurationManager.AppSettings["UrlHtmlPages"]);
            File.WriteAllText(fileName, HtmlGenealogy);

            baseResponse.Response = new SimpleResponse()
            {
                Text = UrlPage
            };

            if (db.DataBaseActionOk)
            {
                baseResponse.ServerActionOk = true;
                baseResponse.BusinessActionOk = true;
            }
            else
            {
                baseResponse.ServerActionOk = false;
                baseResponse.BusinessActionOk = false;
                baseResponse.Message = db.Message;
            }

            return baseResponse;
        }

        public BaseResponse<QueryHorses> GetHorsesByGender(RequestGetHorsesByGender query)
        {
            AccountDB db = new AccountDB(new SqlServer());
            BaseResponse<QueryHorses> baseResponse = new BaseResponse<QueryHorses>();
            baseResponse.Response = db.GetHorsesByGender(query);

            if (db.DataBaseActionOk)
            {
                baseResponse.ServerActionOk = true;
                baseResponse.BusinessActionOk = true;
            }
            else
            {
                baseResponse.ServerActionOk = false;
                baseResponse.BusinessActionOk = false;
                baseResponse.Message = db.Message;
            }

            return baseResponse;
        }

        private void DeleteFile(int PkHorsePhoto)
        {
            AccountDB db = new AccountDB(new SqlServer());
                        
            try
            {
                File.Delete(@"C:\inetpub\wwwroot\UnicornioRS\FotosCaballos\" + db.GetHorsePhotoName(PkHorsePhoto));
            }
            catch(Exception e)
            { }
            
        }

        public BaseResponse<SimpleResponse> DeleteHorsePhoto(int PkHorsePhoto)
        {
            AccountDB db = new AccountDB(new SqlServer());
            BaseResponse<SimpleResponse> baseResponse = new BaseResponse<SimpleResponse>();
            DeleteFile(PkHorsePhoto);
            db.DeleteHorsePhoto(PkHorsePhoto);

            if (db.DataBaseActionOk)
            {
                baseResponse.ServerActionOk = true;
                baseResponse.BusinessActionOk = true;
            }
            else
            {
                baseResponse.ServerActionOk = false;
                baseResponse.BusinessActionOk = false;
                baseResponse.Message = db.Message;
            }

            return baseResponse;
        }
    }
}