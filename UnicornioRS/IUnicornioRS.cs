using Common;
using CommonEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Table;

namespace RestService
{
    [ServiceContract]
    public interface IUnicornioRS
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "/ValidateCredentials", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        BaseResponse<Account> ValidateCredentials(BaseRequest<Account> person);

        [OperationContract]
        [WebInvoke(UriTemplate = "/InsertAccount", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        BaseResponse<Account> InsertAccount(BaseRequest<Account> account);

        [OperationContract]
        [WebInvoke(UriTemplate = "/UploadPhoto", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        BaseResponse<SimpleResponse> UploadPhoto(BaseRequest<Photo> photo);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetHorsesWithoutFilters", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        BaseResponse<QueryHorses> GetHorsesWithoutFilters(BaseRequest<RequestQueryHorses> query);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetHorsePhotos", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        BaseResponse<List<Photo>> GetHorsePhotos(BaseRequest<SimpleRequest> simpleRequest);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetHorseDescendancy", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        BaseResponse<List<Horse>> GetHorseDescendancy(BaseRequest<RequestQueryAccountHorse> query);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetHorseGenealogy", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        BaseResponse<SimpleResponse> GetHorseGenealogy(BaseRequest<RequestQueryAccountHorse> query);


        [OperationContract]
        [WebInvoke(UriTemplate = "/GetFairs", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        BaseResponse<QueryFairs> GetFairs(BaseRequest<RequestQueryFairs> query);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetFairsByID", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        BaseResponse<Fair> GetFairsByID(BaseRequest<RequestQueryFairDetail> query);

        [OperationContract]
        [WebInvoke(UriTemplate = "/InsertFairPhoto", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        BaseResponse<SimpleResponse> InsertFairPhoto(BaseRequest<FairPhoto> query);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetFairCategories", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        BaseResponse<List<FairCategory>> GetFairCategories(BaseRequest<GetFairCateogiries> query);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetFairResultsByCategory", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        BaseResponse<List<FairResult>> GetFairResultsByCategory(BaseRequest<RequestGetFairResultsByCategory> query);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetHorsesByGender", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        BaseResponse<QueryHorses> GetHorsesByGender(BaseRequest<RequestGetHorsesByGender> query);

        [OperationContract]
        [WebInvoke(UriTemplate = "/DeleteHorsePhoto", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        BaseResponse<SimpleResponse> DeleteHorsePhoto(BaseRequest<SimpleRequest> query);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetAsociations", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        BaseResponse<List<Asociation>> GetAsociations(BaseRequest<SimpleRequest> simpleRequest);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetFairsByDate", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        BaseResponse<QueryFairs> GetFairsByDate(BaseRequest<RequestQueryFairsByDate> query);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetFairsByAsociation", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        BaseResponse<QueryFairs> GetFairsByAsociation(BaseRequest<RequestQueryFairsByAsociation> query);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetFairsByHorsePartipation", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        BaseResponse<List<string>> GetFairsByHorsePartipation(BaseRequest<SimpleRequest> baseRequest);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetParticipationRecord", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        BaseResponse<List<ParticipationRecord>> GetParticipationRecord(BaseRequest<RequestParticipationRecord> baseRequest);

        [OperationContract]
        [WebInvoke(UriTemplate = "/Simulator", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        BaseResponse<SimpleResponse> Simulator(BaseRequest<RequestSimulador> query);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetHorseDescendancyByGender", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        BaseResponse<List<DescendancyByGender>> GetHorseDescendancyByGender(BaseRequest<SimpleRequest> baseRequest);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetHorseDescendancyByGenderWalk", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        BaseResponse<List<DescendancyByGenderWalk>> GetHorseDescendancyByGenderWalk(BaseRequest<RequestHorseDescendancyByGenderWalk> baseRequest);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetHorseDetail", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        BaseResponse<Horse> GetHorseDetail(BaseRequest<RequestQueryHorseDetail> baseRequest);


        [OperationContract]
        [WebInvoke(UriTemplate = "/Version", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "GET", BodyStyle = WebMessageBodyStyle.Bare)]
        BaseResponse<SimpleResponse> Version();

        [OperationContract]
        [WebInvoke(UriTemplate = "/NewPassword", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        BaseResponse<SimpleResponse> NewPassword(BaseRequest<SimpleRequest> request);

        [OperationContract]
        [WebInvoke(UriTemplate = "/ChangePassword", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        BaseResponse<SimpleResponse> ChangePassword(BaseRequest<ChangePassword> request);
    }
}