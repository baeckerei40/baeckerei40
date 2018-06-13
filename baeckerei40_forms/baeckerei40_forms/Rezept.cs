using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baeckerei40_forms
{
    class Rezept
    {
        public String RezeptID { get; set; }
        List<Rohstoff> Rohstoffe { get; set; }
        List<Double> MengeRohstoffe { get; set; }


    }
}
