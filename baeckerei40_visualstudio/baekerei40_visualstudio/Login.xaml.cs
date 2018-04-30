using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace baeckerei40
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary> 
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {

            if (textBoxUsername.Text.Length == 0)
            {
                errormessage.Text = "Eingabefehler! Bitte geben Sie einen existierenden Benutzernamen ein.";
                textBoxUsername.Focus();
                /*
               else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
               { 
                   errormessage.Text = "Enter a valid email.";
                   textBoxEmail.Select(0, textBoxEmail.Text.Length);
                   textBoxEmail.Focus();
               }
               else
               { 
                   string email = textBoxEmail.Text;
                   string password = passwordBox.Password;
                   SqlConnection con = new SqlConnection("Data Source=TESTPURU;Initial Catalog=Data;User ID=sa;Password=wintellect");
                   con.Open();
                   SqlCommand cmd = new SqlCommand("Select * from Registration where Email='" + email + "'  and password='" + password + "'", con);
                   cmd.CommandType = CommandType.Text;
                   SqlDataAdapter adapter = new SqlDataAdapter();
                   adapter.SelectCommand = cmd;
                   DataSet dataSet = new DataSet();
                   adapter.Fill(dataSet);
                   if (dataSet.Tables[0].Rows.Count > 0)
                   {
                       string username = dataSet.Tables[0].Rows[0]["FirstName"].ToString() + " " + dataSet.Tables[0].Rows[0]["LastName"].ToString();
                       welcome.TextBlockName.Text = username;//Sending value from one form to another form.
                       welcome.Show();
                       Close();
                   }
                   else
                   {
                       errormessage.Text = "Eingabefehler! Bitte geben Sie eine existierende E-Mail Adresse und Ihr Passwort ein.";
                   }
                   con.Close();
                   */
            }
            else
            {
                Main main = new Main();
                main.Show();
                main.setActiveUser(textBoxUsername.Text);
                Close();
            }
        }

        //Abbrechen Button
        private void buttonAbbrechen_Click(object sender, RoutedEventArgs e)
        {
            //Schließe das Fenster
            this.Close();
        }
    }
}