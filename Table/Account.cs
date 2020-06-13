using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table
{
    public class Account
    {
        public string Email { set; get; }
        public string Password { set; get; }
        public string FullName { set; get; }
        public int PkAccount { set; get; }
        public string RecordState { set; get; }

        public string Document { set; get; }

        public string AccountType { set; get; }
    }

    public class ChangePassword
    {
        public int PkAccount { set; get; }
        public string Password { set; get; }

    }
}