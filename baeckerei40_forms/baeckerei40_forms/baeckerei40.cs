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

        int actualRowIndex;
        List<Produkt> Warenkorb = new List<Produkt>();

        public baeckerei40(Mitarbeiter m)
        {
            InitializeComponent();
            labelBenutzer.Text = "Benutzer: " + m.Benutzername;
            //Zeige Tabs je nach Berechtigung
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

        private void baeckerei40_Load(object sender, EventArgs e)
        {
            this.bestellungEnthaeltTableAdapter.Fill(this.baeckerei40DataSet.BestellungEnthaelt);
            this.bestellungenTableAdapter.Fill(this.baeckerei40DataSet.Bestellungen);
            this.produkteTableAdapter.Fill(this.baeckerei40DataSet.Produkte);
            this.kundenTableAdapter.Fill(this.baeckerei40DataSet.Kunden);
        }

        private void dataGridKundenliste_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxKundennummer.Text = dataGridKundenliste.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBoxVorname.Text = dataGridKundenliste.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBoxNachname.Text = dataGridKundenliste.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBoxTelefonnummer.Text = dataGridKundenliste.Rows[e.RowIndex].Cells[3].Value.ToString();
            actualRowIndex = e.RowIndex;
        }

        private void buttonBearbeiten_Click(object sender, EventArgs e)
        {
            try
            {
                this.dataGridKundenliste.Rows[actualRowIndex].Cells[0].Value = textBoxKundennummer.Text;
                this.dataGridKundenliste.Rows[actualRowIndex].Cells[1].Value = textBoxVorname.Text;
                this.dataGridKundenliste.Rows[actualRowIndex].Cells[2].Value = textBoxNachname.Text;
                this.dataGridKundenliste.Rows[actualRowIndex].Cells[3].Value = textBoxTelefonnummer.Text;

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


        private void buttonHinzufügen_Click(object sender, EventArgs e)
        {
            try
            {
                this.kundenTableAdapter.Insert(textBoxVorname.Text, textBoxNachname.Text, textBoxTelefonnummer.Text, "","","","");
                this.kundenTableAdapter.Fill(this.baeckerei40DataSet.Kunden);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Hinzufügen fehlgeschlagen.\n" + ex.Message);
            }
        }

        private void buttonKundenlisteChange_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.dataGridKundenliste.EndEdit();
                this.kundenTableAdapter.Update(this.baeckerei40DataSet.Kunden);
                MessageBox.Show("Update successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed\n" + ex);
            }
        }

        private void dataGridKundenliste_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
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
            catch (Exception ex)
            {
                MessageBox.Show("Update failed\n" + ex);
            }
        }

        private void buttonWarenkorbHinzufuegen_Click(object sender, EventArgs e)
        {
            try
            {
                Produkt p = new Produkt();
                var cellIndex = dataGridViewProduktliste.SelectedCells[0].RowIndex;
                var cellCollection = dataGridViewProduktliste.Rows[cellIndex].Cells[0];

                p.ProduktID = (int)dataGridViewProduktliste.Rows[cellIndex].Cells[0].Value;
                p.Produktname = (string)dataGridViewProduktliste.Rows[cellIndex].Cells[1].Value;
                p.ProduktPreis = Double.Parse(dataGridViewProduktliste.Rows[cellIndex].Cells[2].Value.ToString());
                this.listBoxWarenkorb.Items.Add(p.ProduktID.ToString() + " - " + p.Produktname.ToString());
                this.Warenkorb.Add(p);
                double gesamtpreis = 0;
                foreach (Produkt x in this.Warenkorb)
                {
                    gesamtpreis += x.ProduktPreis;
                }
                labelGesamtpreis.Text = "Gesamt-Preis: " + gesamtpreis.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kein Produkt ausgewählt. \n" + ex);
            }
        }

        private void buttonWarenkorbEntfernen_Click(object sender, EventArgs e)
        {
            try
            {
                this.listBoxWarenkorb.Items.RemoveAt(this.listBoxWarenkorb.SelectedIndex);
                this.Warenkorb.RemoveAt(this.listBoxWarenkorb.SelectedIndex+1);

                double gesamtpreis = 0;

                foreach (Produkt x in Warenkorb)
                {
                    gesamtpreis = gesamtpreis + x.ProduktPreis;
                }

                labelGesamtpreis.Text = "Gesamt-Preis: " + gesamtpreis.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Kein Produkt ausgewählt. \n" + ex);
            }

        }

        private void baeckerei40_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Alle Forms beenden (auch Login)
            Environment.Exit(0);
        }
    }
}
