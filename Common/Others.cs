using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class KeyValue
    {
        public int Key { set; get; }
        public string Value { set; get; }
        public int Parent { set; get; }
    }

    public class PushNotification
    {
        public List<string> registration_ids { set; get; }
        public Notification notification { set; get; }
        public int PkPerson { set; get; }
        public string priority { set; get; }
    }

    public class Notification
    {
        public string title { set; get; }
        public string body { set; get; }
    }
}
