using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baeckerei40_forms
{
    class Kunde:Person
    {
        public int KundenID { get; set; }
        public string Telefonnummer { get; set; }
        public string EMail { get; set; }
        public string Adresse { get; set; }
        public string PLZ { get; set; }
        public string Ort { get; set; }
    }
}
