using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baeckerei40_forms
{
    class Rechnung
    {
        public int RechnungsID { get; set; }
        public Kunde Kunde { get; set; }
        public List<Bestellung> Bestellungen { get; set; }
        public Double Rechnungsbetrag { get; set; }
        public DateTime Rechnungsdatum { get; set; }
        public Boolean bezahlt { get; set; }
    }
}
