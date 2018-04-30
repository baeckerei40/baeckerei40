using System.Windows.Controls;
using System.Configuration; //Library für die Konfiguration mittels App.config Datei 
using System.Data.SqlClient; //Library für die SQL-Verbindung
using System.Data; // Library für DataTable

namespace baeckerei40
{
    /// <summary>
    /// Interaktionslogik für Bestellung.xaml
    /// </summary>
    public partial class Bestellung : UserControl
    {
        public Bestellung()
        {
            InitializeComponent();
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
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
    }
}
