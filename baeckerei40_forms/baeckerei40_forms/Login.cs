using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baeckerei40_forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string user = textBoxUser.Text;
            string password = textBoxPassword.Text;

            Mitarbeiter m = new Mitarbeiter();
            m.Password = password;
            m.Benutzername = user;
            m.RollenID = 1;


            Boolean validUser = validateUser(user,password);

            if (validUser)
            {
                Form backerei40 = new baeckerei40(m);
                backerei40.Show();
                this.Hide();
            }
        }

        private bool validateUser(string user, string password)
        {
            //Hier könnte der Datenbank zugriff für einen Check stehen.
            //Das Passwort sollte eigentlich gehasht werden, etc. -> nicht teil der Veranstaltung
            if (user == "Manager" | user == "Bäcker" | user == "Verkauf")
                return true;
            else
                return false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBoxBeschreibung_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
