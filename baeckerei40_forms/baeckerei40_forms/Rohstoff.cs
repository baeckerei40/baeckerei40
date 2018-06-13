using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baeckerei40_forms
{
    class Rohstoff
    {
        public String RohstoffID { get; set; }
        public String RohstoffName { get; set; }
        public Double RohstoffPreis { get; set; }
        public String RohstoffEinheit { get; set; }
        public Double Lagermenge { get; set; }
        public Double Meldebestand { get; set; }
    }
}
