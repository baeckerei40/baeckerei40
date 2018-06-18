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

        public baeckerei40(Mitarbeiter m)
        {
            InitializeComponent();
            labelBenutzer.Text = "Benutzer: " + m.Benutzername;
            //Zeige Tabs nach Berechtigung
            switch (m.Benutzername)
            {
                case "Manager":                    
                    break;
                case "Verkauf":
                    this.tabControlWrapper.TabPages.Remove(tabPageControlling);
                    this.tabControlWrapper.TabPages.Remove(tabPageRohstoffe);
                    this.tabControlWrapper.TabPages.Remove(tabPageProduktion);
                    break;
                case "Bäcker":
                    this.tabControlWrapper.TabPages.Remove(tabPageBestellung);
                    this.tabControlWrapper.TabPages.Remove(tabPageControlling);
                    this.tabControlWrapper.TabPages.Remove(tabPageKomissionierung);
                    break;
                default:
                    break;
            }


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
            textBoxTelefonnummer.Text = dataGridKundenliste.Rows[e.RowIndex].Cells[3].Value.ToString();
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
                MessageBox.Show("Update failed\n" + ex);
            }
        }

        private void dataGridKundenliste_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void baeckerei40_Load(object sender, EventArgs e)
        {
            this.bestellungEnthaeltTableAdapter.Fill(this.baeckerei40DataSet.BestellungEnthaelt);
            this.bestellungenTableAdapter.Fill(this.baeckerei40DataSet.Bestellungen);
            this.produkteTableAdapter.Fill(this.baeckerei40DataSet.Produkte);
            this.kundenTableAdapter.Fill(this.baeckerei40DataSet.Kunden);

        }

        private void buttonBestelllisteSpeichern_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.dataGridViewBestellliste.EndEdit();
                this.bestellungenTableAdapter.Update(this.baeckerei40DataSet.Bestellungen);
                MessageBox.Show("Update successful");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Update failed\n" + ex);
            }
        }

        private void baeckerei40_FormClosing(object sender, FormClosingEventArgs e)
        {
            //End all Forms (also hidden Login Form)
            Environment.Exit(0);
        }
    }
}
