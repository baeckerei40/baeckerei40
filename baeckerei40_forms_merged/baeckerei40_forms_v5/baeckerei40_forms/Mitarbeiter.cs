using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baeckerei40_forms
{
    public class Mitarbeiter:Person
    {
        public int MitarbeiterID { get; set; }
        public int RollenID { get; set; }
        public String Benutzername { get; set; }
        public String Password { get; set; }
    }
}
