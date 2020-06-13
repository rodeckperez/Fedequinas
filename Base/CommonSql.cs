using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Base
{
    public class CommonSql
    {
        public bool DataBaseActionOk { set; get; }
        public string Message { set; get; }
        protected string ConnectionString { set; get; }

        public CommonSql()
        {
            //this.ConnectionString = "Data Source = WEBNESS-CO;Initial Catalog=Unicornio;User id=Jope;Password=Santiag0%;";
            //this.ConnectionString = "Server = 204.110.52.87\\SOFT2014,50761;Database=Unicornio;User ID=galzate;Password=1upyRw3Lj75a;";
            this.ConnectionString = WebConfigurationManager.AppSettings["ConnectionString"];
        }
    }
}
