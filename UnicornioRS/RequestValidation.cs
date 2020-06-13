using Base;
using Common;
using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Util;

namespace UnicornioRS
{
    public static class RequestValidation
    {
        public static ParameterDB ParameterDB { set; get; }
        public static bool ValidateRequest(string Fields, string Token, int Timestamp)
        {
            ParameterDB = new ParameterDB(new SqlServer());

            if (Sha256.Generate(Fields).Equals(Token))
            {
                int CurrentTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                try
                {
                    if (CurrentTimestamp - Timestamp < Double.Parse(ParameterDB.GetParameterValue("TimeToRequest")))
                        return true;
                    else
                        return false;
                }
                catch(Exception e)
                {
                    return false;
                }
            }
            else
            {
                ParameterDB.DataBaseActionOk = true;
                return false;
            }
        }
    }
}