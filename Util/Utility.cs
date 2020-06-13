using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class Utility
    {
        public string Text64 { set; get; }
        public string Path { set; get; }
       

        public void String64ToFile()
        {
            try
            {
                byte[] imageBytes = Convert.FromBase64String(Text64);
                string filePath = Path;
                File.WriteAllBytes(filePath, imageBytes);
            }
            catch (Exception e)
            {

            }
        }
    }
}
