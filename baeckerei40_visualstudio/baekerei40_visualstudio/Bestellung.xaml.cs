using System.Windows.Controls;
using System.Configuration; //Library für die Konfiguration mittels App.config Datei 
using System.Data; // Library für DataTable
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Windows;
using System;
using System.Windows.Data;

namespace baeckerei40
{

        /// <summary>
        /// Interaktionslogik für Bestellung.xaml
        /// </summary>
        public partial class Bestellung : UserControl
    {
        OleDbDataAdapter da = null;
        DataSet ds = null;
    
        public Bestellung()
        {
            InitializeComponent();
            FillWarenkorb();
            FillProdukte();
            FillKunden();
        }

        //Ansatz für echte SQL - Datenbank
        /*private void FillDataGrid()
               {
                   string ConString = ConfigurationManager.ConnectionStrings["ConStringSQL"].ConnectionString;
                   string CmdString = string.Empty;
                   using (SqlConnection con = new SqlConnection(ConString))
                   {
                       CmdString = "SELECT * FROM Kunden";
                       SqlCommand cmd = new SqlCommand(CmdString, con);
                       SqlDataAdapter sda = new SqlDataAdapter(cmd);
                       DataTable dt = new DataTable("Employee");
                       sda.Fill(dt);
                       dataGridBestellung.ItemsSource = dt.DefaultView;
                   }
               }

        */

        private void FillWarenkorb()
        {
            // Warenkorb
            using (OleDbConnection myCon = new OleDbConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
            {
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM Bestellungen;", myCon);
                da = new OleDbDataAdapter(cmd);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                ds = new DataSet();
                da.Fill(ds, "Warenkorb");
                dataGridWarenkorb.DataContext = ds.Tables[0];
            }
        }

        private void FillProdukte()
        {
            // Warenkorb
            using (OleDbConnection myCon = new OleDbConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
            {
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM Produkte;", myCon);
                da = new OleDbDataAdapter(cmd);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                ds = new DataSet();
                da.Fill(ds, "Warenkorb");
                dataGridProdukte.DataContext = ds.Tables[0];
            }
        }

        private void FillKunden()
        {
            // Warenkorb
            using (OleDbConnection myCon = new OleDbConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
            {
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM Kunden;", myCon);
                da = new OleDbDataAdapter(cmd);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                ds = new DataSet();
                da.Fill(ds, "Kunden");
                dataGridKunden.DataContext = ds.Tables[0];
            }
        }



        private void buttonBestellung_Click(object sender, RoutedEventArgs e)
        {
            using (OleDbConnection myCon = new OleDbConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString()))
            {
                Kunde testKunde = new Kunde();
                Bestellung testBestellung = new Bestellung();
                testKunde.KundenID = 0815;
                testBestellung.BestellID = 123;

                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Bestellungen ([KundenID],[Abholdatum],[Abholzeit]) values (?,?,?);";
                cmd.Parameters.AddWithValue("@KundenID", testKunde.KundenID);
                cmd.Parameters.AddWithValue("@Abholdatum", testBestellung.BestellID);
                cmd.Parameters.AddWithValue("@Abholzeit", DateTime.Now);
                cmd.Connection = myCon;
                myCon.Open();
                cmd.ExecuteNonQuery();
                message.Content = "Die Bestellung wurde hinzugefügt.";
                InitializeComponent();
            }
        }

        private void buttonWarenkorbLeeren_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
