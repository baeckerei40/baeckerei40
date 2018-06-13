using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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

        public baeckerei40()
        {
            InitializeComponent();
        }

        private void buttonHinzufuegen_Click(object sender, EventArgs e)
        {
            try
            {
                Kunde k = new Kunde();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hinzufügen fehlgeschlagen.\n" + ex.Message);
            }
        }

        private void dataGridKundenliste_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxKundennummer.Text = dataGridKundenliste.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBoxVorname.Text = dataGridKundenliste.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBoxNachname.Text = dataGridKundenliste.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void buttonBearbeiten_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.dataGridKundenliste.EndEdit();
                this.kundenTableAdapter.Update(this.baeckerei40DataSet.Kunden);
                MessageBox.Show("Update successful");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Update failed");
            }
        }

        private void dataGridKundenliste_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void baeckerei40_Load(object sender, EventArgs e)
        {
            // TODO: Diese Codezeile lädt Daten in die Tabelle "baeckerei40DataSet.BestellungEnthaelt". Sie können sie bei Bedarf verschieben oder entfernen.
            this.bestellungEnthaeltTableAdapter.Fill(this.baeckerei40DataSet.BestellungEnthaelt);
            // TODO: Diese Codezeile lädt Daten in die Tabelle "baeckerei40DataSet.Bestellungen". Sie können sie bei Bedarf verschieben oder entfernen.
            this.bestellungenTableAdapter.Fill(this.baeckerei40DataSet.Bestellungen);
            // TODO: Diese Codezeile lädt Daten in die Tabelle "baeckerei40DataSet.Produkte". Sie können sie bei Bedarf verschieben oder entfernen.
            this.produkteTableAdapter.Fill(this.baeckerei40DataSet.Produkte);
            // TODO: Diese Codezeile lädt Daten in die Tabelle "baeckerei40DataSet.Kunden". Sie können sie bei Bedarf verschieben oder entfernen.
            this.kundenTableAdapter.Fill(this.baeckerei40DataSet.Kunden);

        }
    }
}
