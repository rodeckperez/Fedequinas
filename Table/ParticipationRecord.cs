using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table
{
    public class ParticipationRecord
    {
        public string Feria { set; get; }
        public string Grado { set; get; }
        public string Year { set; get; } 
        public string Andar { set; get; }
        public string Categoria { set; get; }
        public int Puesto { set; get; }
        public string Zona { set; get; }
        public int Puntos { get; set; }
    }

    public class RequestParticipationRecord
    {
        public int PkHorse { set; get; }
        public int Year { set; get; }
    }
}
