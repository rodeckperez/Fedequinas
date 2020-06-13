using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table
{
    public class Photo
    {
        public string ContentBase64 { set; get; }
        public string FileName { set; get; }
        public string Url { set; get; }
        public string MymeType { set; get; }
        public int PkHorse { set; get; }
        public int PkHorsePhoto { set; get; }
    }

    public class PhotoFair
    {
        public string ContentBase64 { set; get; }
        public string FileName { set; get; }
        public string Url { set; get; }
        public string MymeType { set; get; }
        public int FkFair { set; get; }
    }
}