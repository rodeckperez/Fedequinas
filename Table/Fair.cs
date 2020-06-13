using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table
{
    public class Fair
    {
        public int PkFair { set; get; }
        public string Name { set; get; }
        public string Zona { set; get; }
        public string Asociation { set; get; }
        public string Grade { set; get; }
        public string StartDate { set; get; }
        public string EndDate { set; get; }
        public string UrlPhoto { set; get; }
        public bool UploadPhoto { set; get; }
    }

    public class QueryFairs
    {
        public int TotalRecords { set; get; }
        public List<Fair> Fairs { set; get; }
    }

    public class RequestQueryFairs
    {
        public int Start { set; get; }
        public int Fetch { set; get; }
        public string Search { set; get; }
        public int FkAccount { set; get; }
    }

    public class FairPhoto
    {
        public int FkFair { set; get; }
        public string UlrPhoto { set; get; }
        public string Base64 { set; get; }
        public string MimeType { set; get; }
        public string FileName { set; get; }
    }

    public class GetFairCateogiries
    {
        public int PkFair { set; get; }
        public string Walk { set; get; }
    }

    public class RequestQueryFairsByAsociation
    {
        public int Start { set; get; }
        public int Fetch { set; get; }
        public string FkAsociation { set; get; }
        public int FkAccount { set; get; }
    }

    public class RequestQueryFairsByDate
    {
        public int Start { set; get; }
        public int Fetch { set; get; }
        public string StartDate { set; get; }
        public string EndDate { set; get; }
        public int FkAccount { set; get; }
    }

    public class FairCategory
    {
        public int PkFairCategory { set; get; }
        public string Name { set; get; }
    }

    public class FairResult
    {
        public string HorseName { set; get; }
        public string Result { set; get; }
        public int PkHorse { set; get; }
    }

    public class RequestGetFairResultsByCategory
    {
        public int PkFairCategory { set; get; }
        public int PkFair { set; get; }
        public string Walk { set;get; }
        public int Gender { set; get; }

    }

    public class Asociation
    {
        public string AsociationCode { set; get; }
        public string UrlPhoto { set; get; }
        public string Name { set; get; }
    }
}