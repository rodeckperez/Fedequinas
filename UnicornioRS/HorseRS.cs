using BusinessRules;
using Common;
using CommonEntity;
using Newtonsoft.Json;
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
        public BaseResponse<QueryHorses> GetHorsesWithoutFilters(BaseRequest<RequestQueryHorses> query)
        {
            HorseBL bl = new HorseBL();

            var Fields = query.Request.PkAccount.ToString()+query.Request.Start.ToString()+query.Request.Fetch.ToString()+query.Request.Search+ query.Timestamp.ToString();
            if (RequestValidation.ValidateRequest(Fields, query.Token, query.Timestamp))
            {
                return bl.GetHorsesWithoutFilters(query.Request);
            }
            else
            {
                if (RequestValidation.ParameterDB.DataBaseActionOk == false)
                {
                    BaseResponse<QueryHorses> baseResponse = new BaseResponse<QueryHorses>();
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

        public BaseResponse<List<string>> GetFairsByHorsePartipation(BaseRequest<SimpleRequest> baseRequest)
        {
            HorseBL bl = new HorseBL();
            int pkHorse;
            try
            {
                pkHorse = Int32.Parse(baseRequest.Request.Text);
                var Fields = pkHorse.ToString() + baseRequest.Timestamp.ToString();
                if (RequestValidation.ValidateRequest(Fields, baseRequest.Token, baseRequest.Timestamp))
                {
                    return bl.GetFairsByHorsePartipation(pkHorse);
                }
                else
                {
                    if (RequestValidation.ParameterDB.DataBaseActionOk == false)
                    {
                        BaseResponse<List<string>> baseResponse = new BaseResponse<List<string>>();
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


        public BaseResponse<List<Photo>> GetHorsePhotos(BaseRequest<SimpleRequest> simpleRequest)
        {
            HorseBL bl = new HorseBL();
            int FkHorse;
            try
            {
                FkHorse = Int32.Parse(simpleRequest.Request.Text);
                var Fields = FkHorse.ToString() + simpleRequest.Timestamp.ToString();
                if (RequestValidation.ValidateRequest(Fields, simpleRequest.Token, simpleRequest.Timestamp))
                {
                    return bl.GetHorsePhotos(FkHorse);
                }
                else
                {
                    if (RequestValidation.ParameterDB.DataBaseActionOk == false)
                    {
                        BaseResponse<List<Photo>> baseResponse = new BaseResponse<List<Photo>>();
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
            catch(Exception e)
            {
                OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                response.StatusCode = HttpStatusCode.NotFound;
                response.StatusDescription = "";
                return null;
            }
        }

        public BaseResponse<List<Horse>> GetHorseDescendancy(BaseRequest<RequestQueryAccountHorse> query)
        {
            HorseBL bl = new HorseBL();
            
            var Fields = query.Request.FkAccount.ToString() + query.Request.FkHorse.ToString()+query.Request.Gender+query.Request.Walk+ query.Timestamp.ToString();
            if (RequestValidation.ValidateRequest(Fields, query.Token, query.Timestamp))
            {
                return bl.GetHorseDescendancy(query.Request);
            }
            else
            {
                if (RequestValidation.ParameterDB.DataBaseActionOk == false)
                {
                    BaseResponse<List<Horse>> baseResponse = new BaseResponse<List<Horse>>();
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

        public BaseResponse<List<ParticipationRecord>> GetParticipationRecord(BaseRequest<RequestParticipationRecord> baseRequest)
        {
            HorseBL bl = new HorseBL();

            var Fields = baseRequest.Request.PkHorse.ToString()+baseRequest.Request.Year.ToString() + baseRequest.Timestamp.ToString();
            if (RequestValidation.ValidateRequest(Fields, baseRequest.Token, baseRequest.Timestamp))
            {
                return bl.GetParticipationRecord(baseRequest.Request);
            }
            else
            {
                if (RequestValidation.ParameterDB.DataBaseActionOk == false)
                {
                    BaseResponse<List<ParticipationRecord>> baseResponse = new BaseResponse<List<ParticipationRecord>>();
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


        public BaseResponse<SimpleResponse> GetHorseGenealogy(BaseRequest<RequestQueryAccountHorse> query)
        {
            HorseBL bl = new HorseBL();

            var Fields = query.Request.FkAccount.ToString() + query.Request.FkHorse.ToString() + query.Timestamp.ToString();
            if (RequestValidation.ValidateRequest(Fields, query.Token, query.Timestamp))
            {
                return bl.GetHorseGenealogy(query.Request);
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

        public BaseResponse<SimpleResponse> Simulator(BaseRequest<RequestSimulador> query)
        {
            HorseBL bl = new HorseBL();

            var Fields = query.Request.Male.FkHorse.ToString() + query.Request.Female.FkHorse.ToString() + query.Timestamp.ToString();
            if (RequestValidation.ValidateRequest(Fields, query.Token, query.Timestamp))
            {
                return bl.Simulator(query.Request);
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

        public BaseResponse<QueryHorses> GetHorsesByGender(BaseRequest<RequestGetHorsesByGender> query)
        {
            var Fields = query.Request.Gender + query.Request.Search + query.Timestamp.ToString();

            if (RequestValidation.ValidateRequest(Fields, query.Token, query.Timestamp))
            {
                HorseBL bl = new HorseBL();
                return bl.GetHorsesByGender(query.Request);
            }
            else
            {
                if (RequestValidation.ParameterDB.DataBaseActionOk == false)
                {
                    BaseResponse<QueryHorses> baseResponse = new BaseResponse<QueryHorses>();
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

        public BaseResponse<SimpleResponse> DeleteHorsePhoto(BaseRequest<SimpleRequest> simpleRequest)
        {
            HorseBL bl = new HorseBL();
            int FkHorsePhoto;
            try
            {
                FkHorsePhoto = Int32.Parse(simpleRequest.Request.Text);
                var Fields = FkHorsePhoto.ToString() + simpleRequest.Timestamp.ToString();
                if (RequestValidation.ValidateRequest(Fields, simpleRequest.Token, simpleRequest.Timestamp))
                {
                    return bl.DeleteHorsePhoto(FkHorsePhoto);
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
            catch (Exception e)
            {
                OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                response.StatusCode = HttpStatusCode.NotFound;
                response.StatusDescription = "";
                return null;
            }
        }

        public BaseResponse<List<DescendancyByGender>> GetHorseDescendancyByGender(BaseRequest<SimpleRequest> baseRequest)
        {
            HorseBL bl = new HorseBL();
            int FkHorse;
            try
            {
                FkHorse = Int32.Parse(baseRequest.Request.Text);
                var Fields = FkHorse.ToString() + baseRequest.Timestamp.ToString();
                if (RequestValidation.ValidateRequest(Fields, baseRequest.Token, baseRequest.Timestamp))
                {
                    return bl.GetHorseDescendancyByGender(FkHorse);
                }
                else
                {
                    if (RequestValidation.ParameterDB.DataBaseActionOk == false)
                    {
                        BaseResponse<List<DescendancyByGender>> baseResponse = new BaseResponse<List<DescendancyByGender>>();
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

        public BaseResponse<List<DescendancyByGenderWalk>> GetHorseDescendancyByGenderWalk(BaseRequest<RequestHorseDescendancyByGenderWalk> baseRequest)
        {
            var Fields = baseRequest.Request.FkHorse.ToString() + baseRequest.Request.Gender + baseRequest.Timestamp.ToString();
            if (RequestValidation.ValidateRequest(Fields, baseRequest.Token, baseRequest.Timestamp))
            {
                HorseBL bl = new HorseBL();
                return bl.GetHorseDescendancyByGenderWalk(baseRequest.Request);
            }
            else
            {
                if (RequestValidation.ParameterDB.DataBaseActionOk == false)
                {
                    BaseResponse<List<DescendancyByGenderWalk>> baseResponse = new BaseResponse<List<DescendancyByGenderWalk>>();
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

        public BaseResponse<SimpleResponse> Version()
        {
            BaseResponse<SimpleResponse> baseResponse = new BaseResponse<SimpleResponse>();
            baseResponse.Message = "VERSIÓN PRUEBA FEDEQUINAS FROM GOOGLE PLAY";

            return baseResponse;
        }
    }
}