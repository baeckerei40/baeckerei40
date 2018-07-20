using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baeckerei40_forms
{
    class Bestellung
    {
        public int BestellID { get; set; }
        public DateTime Abholdatum { get; set; }
        public Kunde Besteller { get; set; }
        public List<Produkt> Produkte { get; set; }
        public List<int> AnzahlProdukte { get; set; }
        public DateTime Bestelldatum { get; set; }
        public Boolean WareGeliefert { get; set; }


    }
}
