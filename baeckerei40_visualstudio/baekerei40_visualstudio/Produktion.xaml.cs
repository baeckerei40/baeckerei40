using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;

namespace baeckerei40
{
    using System.Data;
    using System.Data.OleDb;
    /// <summary>
    /// Interaktionslogik für Produktion.xaml
    /// </summary>
    public partial class Produktion : UserControl
    {
        OleDbDataAdapter da = null;
        DataSet ds = null;

        public Produktion()
        {
            InitializeComponent();
            FillDataGrid();
        }
        private void FillDataGrid()
        {
            // Daten lesen:
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=baeckerei40.mdb;");
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Kunden;", conn);
            da = new OleDbDataAdapter(cmd);
            OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds, "Kunden");
            dataGridProduktion.DataContext = ds.Tables[0];
        }

        private void dataGridProduktion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

}