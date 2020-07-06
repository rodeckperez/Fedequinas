using Base;
using Common;
using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Configuration;
using Table;
using Util;

namespace BusinessRules
{
    public class FairBL
    {
        public BaseResponse<List<Asociation>> GetAsociations()
        {
            BaseResponse<List<Asociation>> baseResponse = new BaseResponse<List<Asociation>>();
            baseResponse.Response = new List<Asociation>();
            FairDB db = new FairDB(new SqlServer());
            baseResponse.Response =  db.GetAsociations();

            if (db.DataBaseActionOk)
            {
                baseResponse.BusinessActionOk = true;
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

        private void CreatePhotoFile(string Base64,string FileName,string MimeType)
        {
            Utility utility = new Utility();
            utility.Text64 = Base64;
            utility.Path = WebConfigurationManager.AppSettings["PathFairPhotos"] + FileName + "." + MimeType;
            ThreadStart threadDelegated = new ThreadStart(utility.String64ToFile);
            Thread thread = new Thread(threadDelegated);
            thread.Start();
        }

        public BaseResponse<SimpleResponse> InsertFairPhoto(FairPhoto fairPhoto)
        {
            BaseResponse<SimpleResponse> baseResponse = new BaseResponse<SimpleResponse>();
            baseResponse.Response = new SimpleResponse();
            FairDB db = new FairDB(new SqlServer());
            fairPhoto.UlrPhoto = fairPhoto.FileName + "." + fairPhoto. MimeType;
            db.InsertFairPhoto(fairPhoto);

            CreatePhotoFile(fairPhoto.Base64,fairPhoto.FileName,fairPhoto.MimeType);

            if (db.DataBaseActionOk)
            {
                baseResponse.BusinessActionOk = true;
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

        public BaseResponse<QueryFairs> GetFairsByDate(RequestQueryFairsByDate query)
        {
            BaseResponse<QueryFairs> baseResponse = new BaseResponse<QueryFairs>();
            FairDB db = new FairDB(new SqlServer());

            QueryFairs queryFairs = db.GetFairsByDate(query);
            if (db.DataBaseActionOk)
            {
                baseResponse.BusinessActionOk = true;
                baseResponse.ServerActionOk = true;
                baseResponse.Message = "";
                baseResponse.Response = queryFairs;
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

        public BaseResponse<QueryFairs> GetFairsByAsociation(RequestQueryFairsByAsociation query)
        {
            BaseResponse<QueryFairs> baseResponse = new BaseResponse<QueryFairs>();
            FairDB db = new FairDB(new SqlServer());

            QueryFairs queryFairs = db.GetFairsByAsociation(query);
            if (db.DataBaseActionOk)
            {
                baseResponse.BusinessActionOk = true;
                baseResponse.ServerActionOk = true;
                baseResponse.Message = "";
                baseResponse.Response = queryFairs;
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

        public BaseResponse<QueryFairs> GetFairs(RequestQueryFairs query)
        {
            BaseResponse<QueryFairs> baseResponse = new BaseResponse<QueryFairs>();
            FairDB db = new FairDB(new SqlServer());

            QueryFairs queryFairs = db.GetFairs(query);
            if (db.DataBaseActionOk)
            {
                baseResponse.BusinessActionOk = true;
                baseResponse.ServerActionOk = true;
                baseResponse.Message = "";
                baseResponse.Response = queryFairs;
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

        public BaseResponse<Fair> GetFairByID(RequestQueryFairDetail query)
        {
            BaseResponse<Fair> baseResponse = new BaseResponse<Fair>();
            FairDB db = new FairDB(new SqlServer());
            Fair queryFairs = db.GetFairsByID(query);
            if (db.DataBaseActionOk)
            {
                baseResponse.BusinessActionOk = true;
                baseResponse.ServerActionOk = true;
                baseResponse.Message = "";
                baseResponse.Response = queryFairs;
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

        public BaseResponse<List<FairCategory>> GetFairCategories(GetFairCateogiries getFfair)
        {
            BaseResponse<List<FairCategory>> baseResponse = new BaseResponse<List<FairCategory>>();
            FairDB db = new FairDB(new SqlServer());

            List<FairCategory> fairCategories = db.GetFairCategories(getFfair);
            if (db.DataBaseActionOk)
            {
                baseResponse.BusinessActionOk = true;
                baseResponse.ServerActionOk = true;
                baseResponse.Message = "";
                baseResponse.Response = fairCategories;
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

        public BaseResponse<List<FairResult>> GetFairResultsByCategory(RequestGetFairResultsByCategory query)
        {
            BaseResponse<List<FairResult>> baseResponse = new BaseResponse<List<FairResult>>();
            FairDB db = new FairDB(new SqlServer());

            List<FairResult> fairResults = db.GetFairResultsByCategory(query);
            if (db.DataBaseActionOk)
            {
                baseResponse.BusinessActionOk = true;
                baseResponse.ServerActionOk = true;
                baseResponse.Message = "";
                baseResponse.Response = fairResults;
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
    }
}
