using BusinessRules;
using Common;
using CommonEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using System.Web;
using Table;
using UnicornioRS;

namespace RestService
{
    public partial class UnicornioRS : IUnicornioRS
    {
        public BaseResponse<List<Asociation>> GetAsociations(BaseRequest<SimpleRequest> simpleRequest)
        {
            var Fields = simpleRequest.Timestamp.ToString();
            if (RequestValidation.ValidateRequest(Fields, simpleRequest.Token, simpleRequest.Timestamp))
            {
                FairBL bl = new FairBL();
                return bl.GetAsociations();
            }
            else
            {
                if (RequestValidation.ParameterDB.DataBaseActionOk == false)
                {
                    BaseResponse<List<Asociation>> baseResponse = new BaseResponse<List<Asociation>>();
                    baseResponse.BusinessActionOk = false;
                    baseResponse.ServerActionOk = false;
                    baseResponse.Message = RequestValidation.ParameterDB.Message;

                    return baseResponse;
                }
                else
                {
                    OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.StatusDescription = "";
                    return null;
                }
            }
        }

        public BaseResponse<SimpleResponse> InsertFairPhoto(BaseRequest<FairPhoto> query)
        {
            FairBL bl = new FairBL();
            var Fields = query.Request.FkFair.ToString() + query.Request.Base64.ToString()+query.Request.FileName+ query.Request.MimeType + query.Timestamp.ToString();
            if (RequestValidation.ValidateRequest(Fields, query.Token, query.Timestamp))
            {
                return bl.InsertFairPhoto(query.Request);
            }
            else
            {
                if (RequestValidation.ParameterDB.DataBaseActionOk == false)
                {
                    BaseResponse<SimpleResponse> baseResponse = new BaseResponse<SimpleResponse>();
                    baseResponse.BusinessActionOk = false;
                    baseResponse.ServerActionOk = false;
                    baseResponse.Message = RequestValidation.ParameterDB.Message;

                    return baseResponse;
                }
                else
                {
                    OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.StatusDescription = "";
                    return null;
                }
            }
        }

        public BaseResponse<QueryFairs> GetFairsByAsociation(BaseRequest<RequestQueryFairsByAsociation> query)
        {
            FairBL bl = new FairBL();

            var Fields = query.Request.Start.ToString() + query.Request.Fetch.ToString() + query.Request.FkAsociation.ToString() + query.Timestamp.ToString();
            if (RequestValidation.ValidateRequest(Fields, query.Token, query.Timestamp))
            {
                return bl.GetFairsByAsociation(query.Request);
            }
            else
            {
                if (RequestValidation.ParameterDB.DataBaseActionOk == false)
                {
                    BaseResponse<QueryFairs> baseResponse = new BaseResponse<QueryFairs>();
                    baseResponse.BusinessActionOk = false;
                    baseResponse.ServerActionOk = false;
                    baseResponse.Message = RequestValidation.ParameterDB.Message;

                    return baseResponse;
                }
                else
                {
                    OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.StatusDescription = "";
                    return null;
                }
            }
        }
        public BaseResponse<QueryFairs> GetFairsByDate(BaseRequest<RequestQueryFairsByDate> query)
        {
            FairBL bl = new FairBL();

            var Fields = query.Request.Start.ToString() + query.Request.Fetch.ToString() + query.Request.StartDate.ToString() + query.Request.EndDate.ToString() + query.Timestamp.ToString();
            if (RequestValidation.ValidateRequest(Fields, query.Token, query.Timestamp))
            {
                return bl.GetFairsByDate(query.Request);
            }
            else
            {
                if (RequestValidation.ParameterDB.DataBaseActionOk == false)
                {
                    BaseResponse<QueryFairs> baseResponse = new BaseResponse<QueryFairs>();
                    baseResponse.BusinessActionOk = false;
                    baseResponse.ServerActionOk = false;
                    baseResponse.Message = RequestValidation.ParameterDB.Message;

                    return baseResponse;
                }
                else
                {
                    OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.StatusDescription = "";
                    return null;
                }
            }
        }
        public BaseResponse<QueryFairs> GetFairs(BaseRequest<RequestQueryFairs> query)
        {
            FairBL bl = new FairBL();

            var Fields = query.Request.Start.ToString() + query.Request.Fetch.ToString() + query.Request.Search.ToString() + query.Timestamp.ToString();
            if (RequestValidation.ValidateRequest(Fields, query.Token, query.Timestamp))
            {
                return bl.GetFairs(query.Request);
            }
            else
            {
                if (RequestValidation.ParameterDB.DataBaseActionOk == false)
                {
                    BaseResponse<QueryFairs> baseResponse = new BaseResponse<QueryFairs>();
                    baseResponse.BusinessActionOk = false;
                    baseResponse.ServerActionOk = false;
                    baseResponse.Message = RequestValidation.ParameterDB.Message;

                    return baseResponse;
                }
                else
                {
                    OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.StatusDescription = "";
                    return null;
                }
            }
        }

        public BaseResponse<List<FairCategory>> GetFairCategories(BaseRequest<GetFairCateogiries> query)
        {
            FairBL bl = new FairBL();
            try
            {
                var Fields = query.Request.PkFair.ToString() + query.Request.Walk + query.Timestamp.ToString();
                if (RequestValidation.ValidateRequest(Fields, query.Token, query.Timestamp))
                {
                    return bl.GetFairCategories(query.Request);
                }
                else
                {
                    if (RequestValidation.ParameterDB.DataBaseActionOk == false)
                    {
                        BaseResponse<List<FairCategory>> baseResponse = new BaseResponse<List<FairCategory>>();
                        baseResponse.BusinessActionOk = false;
                        baseResponse.ServerActionOk = false;
                        baseResponse.Message = RequestValidation.ParameterDB.Message;

                        return baseResponse;
                    }
                    else
                    {
                        OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                        response.StatusCode = HttpStatusCode.NotFound;
                        response.StatusDescription = "";
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                response.StatusCode = HttpStatusCode.NotFound;
                response.StatusDescription = "";
                return null;
            }
        }

        public BaseResponse<List<FairResult>> GetFairResultsByCategory(BaseRequest<RequestGetFairResultsByCategory> query)
        {
            FairBL bl = new FairBL();

            var Fields = query.Request.PkFairCategory.ToString() + query.Request.PkFair.ToString() + query.Timestamp.ToString();
            if (RequestValidation.ValidateRequest(Fields, query.Token, query.Timestamp))
            {
                return bl.GetFairResultsByCategory(query.Request);
            }
            else
            {
                if (RequestValidation.ParameterDB.DataBaseActionOk == false)
                {
                    BaseResponse<List<FairResult>> baseResponse = new BaseResponse<List<FairResult>>();
                    baseResponse.BusinessActionOk = false;
                    baseResponse.ServerActionOk = false;
                    baseResponse.Message = RequestValidation.ParameterDB.Message;

                    return baseResponse;
                }
                else
                {
                    OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.StatusDescription = "";
                    return null;
                }
            }
        }
    }
}