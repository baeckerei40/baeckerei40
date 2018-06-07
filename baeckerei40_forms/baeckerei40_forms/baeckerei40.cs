using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baeckerei40_forms
{
    public partial class baeckerei40 : Form
    {
        private OleDbDataAdapter da;
        private DataSet ds;

        public baeckerei40()
        {
            InitializeComponent();
            fillGrid();
        }

        public void fillGrid()
        {
            // Daten lesen:
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=baeckerei40.mdb;");
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Kunden;", conn);
            da = new OleDbDataAdapter(cmd);
            OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
            DataSet ds = new DataSet("Kunden");
            da.Fill(ds, "Kunden");
            DataTable KundenTable = ds.Tables["Kunden"];

            List<Kunde> list = new List<Kunde>();



            dataGridKundenliste.DataSource = KundenTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridKundenliste_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
