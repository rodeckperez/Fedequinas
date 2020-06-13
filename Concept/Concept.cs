using Common;
using CommonEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Table;

namespace Util
{
    public class Concept
    {
        private delegate void DelegateWebService(BaseRequest<Photo> request);

        private static BaseRequest<Photo>  request_1,request_2, request_3, request_4, request_5, request_6, request_7, request_8, request_9, request_10,
                                    request_11,request_12, request_13, request_14, request_15, request_16, request_17, request_18, request_19, request_20,
                                    request_21, request_22, request_23, request_24, request_25, request_26, request_27, request_28, request_29, request_30,
                                    request_31, request_32, request_33, request_34, request_35, request_36, request_37, request_38, request_39, request_40,
                                    request_41, request_42, request_43, request_44, request_45, request_46, request_47, request_48, request_49, request_50;

        private static DelegateWebService  delegate_1, delegate_2, delegate_3, delegate_4, delegate_5, delegate_6, delegate_7, delegate_8, delegate_9, delegate_10,
                                    delegate_11, delegate_12, delegate_13, delegate_14,delegate_15, delegate_16, delegate_17, delegate_18, delegate_19, delegate_20,
                                    delegate_21, delegate_22, delegate_23, delegate_24,delegate_25, delegate_26, delegate_27, delegate_28, delegate_29, delegate_30,
                                    delegate_31, delegate_32, delegate_33, delegate_34,delegate_35, delegate_36, delegate_37, delegate_38, delegate_39, delegate_40,
                                    delegate_41, delegate_42, delegate_43, delegate_44,delegate_45, delegate_46, delegate_47, delegate_48, delegate_49, delegate_50 = new DelegateWebService(CallService);
        
        private static BaseRequest<Photo> GetRequest(int i)
        {
            return new BaseRequest<Photo>()
            {
                Request = new Photo()
                {
                    ContentBase64 = "541654564564564564564654654564564564564654564564654654654sdfsdfsf",
                    FileName ="Caballo_"+i,
                    MymeType="png",
                    PkHorse=i,
                    Url=""
                },
                Timestamp=234165416,
                Token="5651561ajkafsd854f86asf"
            };
        }

        private static void SetRequest()
        {
            request_1 = GetRequest(1);
            request_2 = GetRequest(2);
            request_3 = GetRequest(3);
            request_4 = GetRequest(4);
            request_5 = GetRequest(5);
            request_6 = GetRequest(6);
            request_7 = GetRequest(7);
            request_8 = GetRequest(8);
            request_9 = GetRequest(9);
            request_10 = GetRequest(10);
            request_11 = GetRequest(11);
            request_12 = GetRequest(12);
            request_13 = GetRequest(13);
            request_14 = GetRequest(14);
            request_15 = GetRequest(15);
            request_16 = GetRequest(16);
            request_17 = GetRequest(17);
            request_18 = GetRequest(18);
            request_19 = GetRequest(19);
            request_20 = GetRequest(20);
            request_21 = GetRequest(21);
            request_22 = GetRequest(22);
            request_23 = GetRequest(23);
            request_24 = GetRequest(24);
            request_25 = GetRequest(25);
            request_26 = GetRequest(26);
            request_27 = GetRequest(27);
            request_28 = GetRequest(28);
            request_29 = GetRequest(29);
            request_30 = GetRequest(30);
            request_31 = GetRequest(30);
            request_32 = GetRequest(32);
            request_33 = GetRequest(33);
            request_34 = GetRequest(34);
            request_35 = GetRequest(35);
            request_36 = GetRequest(36);
            request_37 = GetRequest(37);
            request_38 = GetRequest(38);
            request_39 = GetRequest(39);
            request_40 = GetRequest(40);
            request_41 = GetRequest(41);
            request_42 = GetRequest(42);
            request_43 = GetRequest(43);
            request_44 = GetRequest(44);
            request_45 = GetRequest(45);
            request_46 = GetRequest(46);
            request_47 = GetRequest(47);
            request_48 = GetRequest(48);
            request_49 = GetRequest(49);
            request_50 = GetRequest(50);
        }

        private static void SetDelegate()
        {
            delegate_1.BeginInvoke(request_1, null, null);
            delegate_2.BeginInvoke(request_2, null, null);
            delegate_3.BeginInvoke(request_3, null, null);
            delegate_4.BeginInvoke(request_4, null, null);
            delegate_5.BeginInvoke(request_5, null, null);
            delegate_6.BeginInvoke(request_6, null, null);
            delegate_7.BeginInvoke(request_7, null, null);
            delegate_8.BeginInvoke(request_8, null, null);
            delegate_9.BeginInvoke(request_9, null, null);
            delegate_10.BeginInvoke(request_10, null, null);
            delegate_11.BeginInvoke(request_11, null, null);
            delegate_12.BeginInvoke(request_12, null, null);
            delegate_13.BeginInvoke(request_13, null, null);
            delegate_14.BeginInvoke(request_14, null, null);
            delegate_15.BeginInvoke(request_15, null, null);
            delegate_16.BeginInvoke(request_16, null, null);
            delegate_17.BeginInvoke(request_17, null, null);
            delegate_18.BeginInvoke(request_18, null, null);
            delegate_19.BeginInvoke(request_19, null, null);
            delegate_20.BeginInvoke(request_20, null, null);
            delegate_21.BeginInvoke(request_21, null, null);
            delegate_22.BeginInvoke(request_22, null, null);
            delegate_23.BeginInvoke(request_23, null, null);
            delegate_24.BeginInvoke(request_24, null, null);
            delegate_25.BeginInvoke(request_25, null, null);
            delegate_26.BeginInvoke(request_26, null, null);
            delegate_27.BeginInvoke(request_27, null, null);
            delegate_28.BeginInvoke(request_28, null, null);
            delegate_29.BeginInvoke(request_29, null, null);
            delegate_30.BeginInvoke(request_30, null, null);
            delegate_31.BeginInvoke(request_31, null, null);
            delegate_32.BeginInvoke(request_32, null, null);
            delegate_33.BeginInvoke(request_33, null, null);
            delegate_34.BeginInvoke(request_34, null, null);
            delegate_35.BeginInvoke(request_35, null, null);
            delegate_36.BeginInvoke(request_36, null, null);
            delegate_37.BeginInvoke(request_37, null, null);
            delegate_38.BeginInvoke(request_38, null, null);
            delegate_39.BeginInvoke(request_39, null, null);
            delegate_40.BeginInvoke(request_40, null, null);
            delegate_41.BeginInvoke(request_41, null, null);
            delegate_42.BeginInvoke(request_42, null, null);
            delegate_43.BeginInvoke(request_43, null, null);
            delegate_44.BeginInvoke(request_44, null, null);
            delegate_45.BeginInvoke(request_45, null, null);
            delegate_46.BeginInvoke(request_46, null, null);
            delegate_47.BeginInvoke(request_47, null, null);
            delegate_48.BeginInvoke(request_48, null, null);
            delegate_49.BeginInvoke(request_49, null, null);
            delegate_50.BeginInvoke(request_50, null, null);
        }

        public static void main (string[] args)
        {
            SetRequest();
            SetDelegate();
        }

        private static void CallService(BaseRequest<Photo> request)
        {
            Console.WriteLine("LLAMADO #"+request.Request.PkHorse);

        }
    }
}
