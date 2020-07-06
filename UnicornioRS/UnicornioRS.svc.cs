using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Common;
using CommonEntity;
using Table;
using UnicornioRS;
using BusinessRules;
using System.Net;
using System.IO;
using System.Threading;
using Util;

namespace RestService
{
    //USED TO IMPLEMENT Account methods
    public partial class UnicornioRS : IUnicornioRS
    {
        public BaseResponse<SimpleResponse> NewPassword(BaseRequest<SimpleRequest> request)
        {
            BaseResponse<SimpleResponse> baseResponse = new BaseResponse<SimpleResponse>();
            var Fields = request.Request.Text + request.Timestamp.ToString();
            if (RequestValidation.ValidateRequest(Fields, request.Token, request.Timestamp))
            {
                try
                {
                    AccountBL bl = new AccountBL();
                    return bl.NewPassword(request.Request.Text);
                }
                catch (Exception e)
                {
                    baseResponse.BusinessActionOk = false;
                    baseResponse.ServerActionOk = false;
                    baseResponse.Message = "Error en el servicio-->" + e.Message;
                    return baseResponse;
                }
            }
            else
            {
                if (RequestValidation.ParameterDB.DataBaseActionOk == false)
                {
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

        public BaseResponse<SimpleResponse> ChangePassword(BaseRequest<ChangePassword> request)
        {
            BaseResponse<SimpleResponse> baseResponse = new BaseResponse<SimpleResponse>();
            var Fields = request.Request.PkAccount.ToString() + request.Request.Password + request.Timestamp.ToString();
            if (RequestValidation.ValidateRequest(Fields, request.Token, request.Timestamp))
            {
                try
                {
                    AccountBL bl = new AccountBL();
                    return bl.ChangePassword(request.Request);
                }
                catch (Exception e)
                {
                    baseResponse.BusinessActionOk = false;
                    baseResponse.ServerActionOk = false;
                    baseResponse.Message = "Error en el servicio-->" + e.Message;
                    return baseResponse;
                }
            }
            else
            {
                if (RequestValidation.ParameterDB.DataBaseActionOk == false)
                {
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
        public BaseResponse<SimpleResponse> UploadPhoto(BaseRequest<Photo> photo)
        {
            BaseResponse<SimpleResponse> baseResponse = new BaseResponse<SimpleResponse>();
            var Fields = photo.Request.ContentBase64 + photo.Request.FileName + photo.Request.MymeType + photo.Request.PkHorse.ToString() + photo.Timestamp.ToString();
            //if (RequestValidation.ValidateRequest(Fields, photo.Token, photo.Timestamp))
            if (true)
            {
                try
                {
                    HorseBL bl = new HorseBL();
                    return bl.UploadPhoto(photo.Request);
                }
                catch (Exception e)
                {
                    baseResponse.BusinessActionOk = false;
                    baseResponse.ServerActionOk = false;
                    baseResponse.Message = "Error en el servicio-->" + e.Message;
                    return baseResponse;
                }
            }
            else
            {
                if (RequestValidation.ParameterDB.DataBaseActionOk == false)
                {
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

        public BaseResponse<Account> InsertAccount(BaseRequest<Account> account)
        {
            AccountBL accountBl = new AccountBL();

            var Fields = account.Request.Email + account.Request.Password + account.Request.FullName + account.Timestamp;
            if (RequestValidation.ValidateRequest(Fields, account.Token, account.Timestamp))
            {
                return accountBl.InsertAccount(account.Request);
            }
            else
            {
                if (RequestValidation.ParameterDB.DataBaseActionOk == false)
                {
                    BaseResponse<Account> baseResponse = new BaseResponse<Account>();
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

        public BaseResponse<Horse> GetHorseDetail(BaseRequest<RequestQueryHorseDetail> baseRequest)
        {
            HorseBL horseBL = new HorseBL();

            var Fields = baseRequest.Request.PkAccount.ToString() + baseRequest.Request.FkHorse.ToString() + baseRequest.Timestamp.ToString();
            if (RequestValidation.ValidateRequest(Fields, baseRequest.Token, baseRequest.Timestamp))
            {
                return horseBL.GetHorseDetail(baseRequest.Request);
            }
            else
            {
                if (RequestValidation.ParameterDB.DataBaseActionOk == false)
                {
                    BaseResponse<Horse> baseResponse = new BaseResponse<Horse>();
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

        public BaseResponse<Account> ValidateCredentials(BaseRequest<Account> request)
        {
            AccountBL accountBl = new AccountBL();

            var Fields = request.Request.Email + request.Request.Password + request.Timestamp;
            if (RequestValidation.ValidateRequest(Fields, request.Token, request.Timestamp))
            {
                return accountBl.ValidateCredentials(request.Request);
            }
            else
            {
                if (RequestValidation.ParameterDB.DataBaseActionOk == false)
                {
                    BaseResponse<Account> baseResponse = new BaseResponse<Account>();
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

        public BaseResponse<Fair> GetFairsByID(BaseRequest<RequestQueryFairDetail> query)
        {
            FairBL fairBL = new FairBL();

            var Fields = query.Request.PkAccount.ToString() + query.Request.FkFair.ToString() + query.Timestamp.ToString();
            if (RequestValidation.ValidateRequest(Fields, query.Token, query.Timestamp))
            {
                return fairBL.GetFairByID(query.Request);
            }
            else
            {
                if (RequestValidation.ParameterDB.DataBaseActionOk == false)
                {
                    BaseResponse<Fair> baseResponse = new BaseResponse<Fair>();
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