using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table
{
    public class Horse
    {
        public int? PkHorse { set; get; }
        public string Name { set; get; }
        public string Gender { set; get; }
        public string Walk { set; get; }     
        public string UrlMainPhoto { set; get; }
        public bool MyHorse { set; get; }
        public List<Photo> Photos { set; get; }
        public string Microchip { set; get; }
        public int Year { set; get; }
        public string Color { set; get; }
        public string Gg { set; get; }

        public int Months { set; get; }
        public string BornDate { set; get; }
        public string Breeder { set; get; }
        public string Association { set; get; }
        public string Genotyping { set; get; }
        public string EquineType { set; get; }

        public Horse Father { set; get; }
        public Horse Mother { set; get; }
        public string Node { set; get; }
        public string NodeParent{ set; get; }

        public int Done { set; get; }
    }

    public class Simulador
    {
        public List<Horse> FromMale { set; get; }
        public List<Horse> FromFemale { set; get; }
    }

    public class RequestSimulador
    {
        public RequestQueryAccountHorse Male { set; get; }
        public RequestQueryAccountHorse Female { set; get; }
    }

    public class QueryHorses
    {
        public List<Horse> Horses { set; get; }
        public int TotalRecords { set; get; }
    }

    public class RequestQueryHorses
    {
        public int PkAccount { set; get; }
        public int Start { set; get; }
        public int Fetch { set; get; }
        public string Search { set; get; }
    }

    public class RequestQueryHorseDetail
    {
        public int PkAccount { set; get; }
        public int FkHorse { set; get; }
    }

    public class RequestQueryAccountHorse
    {
        public int FkAccount { set; get; }
        public int FkHorse { set; get; }
        public string Gender { set; get; }
        public string Walk { set; get; }
    }

    public class RequestGetHorsesByGender
    {
        public string Gender { set; get; }
        public string Search { set; get; }
        public int Start { set; get; }
        public int Fetch { set; get; }
    }

    public class DescendancyByGender
    {
        public int Total { set; get; }
        public string Gender { set; get; }
    }

    public class RequestHorseDescendancyByGenderWalk
    {
        public int FkHorse { set; get; }
        public string Gender { set; get; }
    }

    public class DescendancyByGenderWalk
    {
        public int Total { set; get; }
        public string Walk { set; get; }
    }
}