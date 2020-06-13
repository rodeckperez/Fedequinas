using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class BaseResponse<T> where T : class
    {
        public bool ServerActionOk { set; get; }
        public bool BusinessActionOk { set; get; }
        public string Message { set; get; }
        public T Response { set; get; }
    }

    public class SimpleResponse
    {
        public string Text { set; get; }
    }
}