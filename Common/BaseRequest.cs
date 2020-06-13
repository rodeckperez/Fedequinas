using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonEntity
{
    public class BaseRequest<T> where T : class
    {
        public string Token { set; get; }
        public int Timestamp { set; get; }
        public T Request { set; get; }
    }

    public class SimpleRequest
    {
        public string Text { set; get; }
    }
}