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
        //globale Zuweisungen
        List<Produkt> Warenkorb = new List<Produkt>();
        int AusgewaehlterKunde;

        public baeckerei40(Mitarbeiter m)
        {
            InitializeComponent();

            //Zeige den Benutzername im dafür vorgesehenen Label an.
            labelBenutzer.Text = "Benutzer: " + m.Benutzername;

            //Zeige Tabs je nach Berechtigung
            switch (m.Benutzername)
            {
                case "Manager":
                    // Controlling-Tab auch für Manager ausblenden
                    this.tabControlWrapper.TabPages.Remove(tabPageControlling);
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

        // Exit-Event
        private void baeckerei40_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Alle Forms beenden, wenn auf Schließen geklickt wird (auch Login)
            Environment.Exit(0);
        }


        // Initialisierung der DB Adapter
        private void baeckerei40_Load(object sender, EventArgs e)
        {
            this.bestellungenTableAdapter2.Fill(this.baeckerei40DataSet10.Bestellungen);
            this.bestellungEnthaeltTableAdapter1.Fill(this.baeckerei40DataSet9.BestellungEnthaelt);
            this.bestellungenTableAdapter1.Fill(this.baeckerei40DataSet8.Bestellungen);
            this.produkteTableAdapter1.Fill(this.baeckerei40DataSet6.Produkte);
            this.rezeptverwaltungTableAdapter.Fill(this.baeckerei40DataSet5.Rezeptverwaltung);
            this.bestellungEnthaeltTableAdapter.Fill(this.baeckerei40DataSet.BestellungEnthaelt);
            this.bestellungenTableAdapter.Fill(this.baeckerei40DataSet.Bestellungen);
            this.produkteTableAdapter.Fill(this.baeckerei40DataSet.Produkte);
            this.kundenTableAdapter.Fill(this.baeckerei40DataSet.Kunden);
            this.rohstoffeTableAdapter.Fill(this.baeckerei40DataSet1.Rohstoffe);
            rohstoffeBindingSource.DataSource = this.baeckerei40DataSet1.Rohstoffe;
            rezeptverwaltungBindingSource.DataSource = this.baeckerei40DataSet5.Rezeptverwaltung;
            bestellungenBindingSource.DataSource = this.baeckerei40DataSet10.Bestellungen;

            //Panels mit Textfeldern standardmäßig deaktiviert
            panel.Enabled = false;
            panelRez.Enabled = false;
            panelKom.Enabled = false;
        }
        //#######################################- Tab Bestellung -#########################################

        // Clickevent für den Button "Kunde hinzufügen"
        private void buttonKundeHinzufuegen_Click(object sender, EventArgs e)
        {
            try
            {
                AusgewaehlterKunde = this.kundenTableAdapter.MaxKundenID(baeckerei40DataSet.Kunden);
                textBoxKundennummer.Text = AusgewaehlterKunde.ToString();
                this.kundenTableAdapter.Insert(textBoxVorname.Text, textBoxNachname.Text, textBoxTelefonnummer.Text, "", "", "", "");
                this.kundenTableAdapter.Fill(this.baeckerei40DataSet.Kunden);         
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hinzufügen fehlgeschlagen.\n" + ex.Message);
            }
        }

        // Clickevent für den Button "Kunde bearbeiten"
        private void buttonKundeBearbeiten_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.dataGridKundenliste.EndEdit();
                this.kundenTableAdapter.Update(this.baeckerei40DataSet.Kunden);
                MessageBox.Show("Änderung erfolgreich!");
                dataGridKundenliste.Update();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Update fehlgeschlagen!\n" + ex);
            }
        }

        // Clickevent für das Kunden DataGrid 
        private void dataGridKundenliste_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Wähle den Kunden aus, der in der angeklickten (Doppelklick) Zeile steht
            textBoxKundennummer.Text = dataGridKundenliste.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBoxVorname.Text = dataGridKundenliste.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBoxNachname.Text = dataGridKundenliste.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBoxTelefonnummer.Text = dataGridKundenliste.Rows[e.RowIndex].Cells[3].Value.ToString();
            AusgewaehlterKunde = e.RowIndex;
        }

        // Clickevent für die Produktliste
        private void buttonAenderungProduktliste_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.dataGridViewProduktliste.EndEdit();
            this.produkteTableAdapter.Update(this.baeckerei40DataSet.Produkte);
            MessageBox.Show("Änderung erfolgreich!");
        }

        // Clickevent für die Bestellliste
        private void buttonBestelllisteSpeichern_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.dataGridViewBestellliste.EndEdit();
                this.bestellungenTableAdapter.Update(this.baeckerei40DataSet.Bestellungen);
                MessageBox.Show("Änderung erfolgreich!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update fehlgeschlagen!\n" + ex);
            }
        }

        // "<<"-Button Klickevent
        private void buttonWarenkorbHinzufuegen_Click(object sender, EventArgs e)
        {
            try
            {
                // Neues Produktobjekt anlegen
                Produkt p = new Produkt();
                // Eigenschaften des ausgewählten Produkts bestimmen
                var cellIndex = dataGridViewProduktliste.SelectedCells[0].RowIndex;
                var cellCollection = dataGridViewProduktliste.Rows[cellIndex].Cells[0];
                p.ProduktID = (int)dataGridViewProduktliste.Rows[cellIndex].Cells[0].Value;
                p.Produktname = (string)dataGridViewProduktliste.Rows[cellIndex].Cells[1].Value;
                p.ProduktPreis = Double.Parse(dataGridViewProduktliste.Rows[cellIndex].Cells[2].Value.ToString());
                // Anzahl der Produkte (Combobox) berücksichtigen
                p.ProduktAnzahl = int.Parse(comboBoxWarenkorbAnzahl.Text);

                this.listBoxWarenkorb.Items.Add("Prod.-ID: " + p.ProduktID.ToString() + " - Prod.-Name: " + p.Produktname.ToString() + " - Anzahl: " + p.ProduktAnzahl.ToString());
                this.Warenkorb.Add(p);
                double gesamtpreis = 0;
                foreach (Produkt x in this.Warenkorb)
                {
                    gesamtpreis = gesamtpreis + ( x.ProduktPreis * x.ProduktAnzahl );
                }
                labelGesamtpreis.Text = "Gesamt-Preis: " + gesamtpreis.ToString() + " €";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kein Produkt ausgewählt. \n" + ex);
            }
        }

        // Clickevent für das Produktliste DataGrid (füge bei Doppelklick auch ein Produkt zum Warenkorb hinzu).
        private void dataGridViewdataGridViewProduktliste_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonWarenkorbHinzufuegen_Click(sender, e);
        }

        // Klickevent für den ">>"-Button (Entferne Elemente aus dem Warenkorb)
        private void buttonWarenkorbEntfernen_Click(object sender, EventArgs e)
        {
            try
            {
                this.listBoxWarenkorb.Items.RemoveAt(this.listBoxWarenkorb.SelectedIndex);
                this.Warenkorb.RemoveAt(this.listBoxWarenkorb.SelectedIndex + 1);
                double gesamtpreis = 0;
                foreach (Produkt x in this.Warenkorb)
                {
                    gesamtpreis = gesamtpreis + (x.ProduktPreis * x.ProduktAnzahl);
                }
               labelGesamtpreis.Text = "Gesamt-Preis: " + gesamtpreis.ToString() + " €";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kein Produkt zum Entfernen ausgewählt. \n" + ex);
            }
        }

        // Klickevent für den Bestellbutton
        private void buttonBestellen_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBoxKundennummer.Text == "")
                {
                    // Fehler, falls kein Kunde ausgewählt
                    MessageBox.Show("Kein Kunde ausgewählt! \n");
                } else {
                    // Tabellen füllen
                    this.bestellungenTableAdapter.Insert(int.Parse(textBoxKundennummer.Text), dateTimePickerAbholdatum.Value, dateTimePickerAbholzeit.Value.ToString());
                    bestellungenTableAdapter.ClearBeforeFill = true;
                    bestellungenTableAdapter.Fill(this.baeckerei40DataSet.Bestellungen);
                    int BestellID = (int)bestellungenTableAdapter.MaxBestellID();
                    foreach (Produkt p in Warenkorb)
                    {
                        this.bestellungEnthaeltTableAdapter.Insert(BestellID,p.ProduktID,p.ProduktAnzahl);
                        this.bestellungEnthaeltTableAdapter.Fill(this.baeckerei40DataSet.BestellungEnthaelt);
                    }
                    this.dataGridViewBestellliste.Update();
                    MessageBox.Show("Bestellung erforgreich erstellt. \n");

                    // Warenkorb resetten
                    this.Warenkorb.Clear();
                    this.listBoxWarenkorb.Items.Clear();

                    // DataGrid neu laden, damit die Änderungen angezeigt werden.
                    bestellungenBindingSource.DataSource = baeckerei40DataSet.Bestellungen;
                    bestellungenBindingSource.ResetBindings(true);
                    this.dataGridViewBestellliste.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bestellung fehlgeschlagen. \n" + ex);
            }
        }

        //#######################################-Tab Produktion-#########################################

        // Klickevent für Produktion speichern Button
        private void buttonProduktionSpeichern_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.dataGridViewProduktionsliste.EndEdit();
                this.bestellungEnthaeltTableAdapter.Update(this.baeckerei40DataSet.BestellungEnthaelt);
                MessageBox.Show("Änderungen gespeichert!");
                dataGridViewProduktliste.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Speichern fehlgeschlagen. \n" + ex);
            }
        }

        //#######################################-Tab Lager-#########################################

        // Button zum hinzufügen eines Rohstoffes, Panel zur Eingabe wird aktiviert, Eingabe kann erfolgen, Bei Fehleingaben erfolgt eine Fehlermeldung
        private void RHinzufügen_Click(object sender, EventArgs e)
        {
            try
            {
                panel.Enabled = true;
                RID.Focus();
                this.baeckerei40DataSet1.Rohstoffe.AddRohstoffeRow(this.baeckerei40DataSet1.Rohstoffe.NewRohstoffeRow());
                rohstoffeBindingSource.MoveLast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rohstoffeBindingSource.ResetBindings(false);
            }
        }

        // Eingaben werden als String interpretiert, den jeweiligen Eingabefeldern wird ein Ausgabefeld im DataGrid zugeordnet
        private void dataGridViewLager_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                RID.Text = dataGridViewLager.Rows[e.RowIndex].Cells[0].Value.ToString();
                RName.Text = dataGridViewLager.Rows[e.RowIndex].Cells[1].Value.ToString();
                REinheit.Text = dataGridViewLager.Rows[e.RowIndex].Cells[2].Value.ToString();
                RPreis.Text = dataGridViewLager.Rows[e.RowIndex].Cells[3].Value.ToString();
                LMenge.Text = dataGridViewLager.Rows[e.RowIndex].Cells[4].Value.ToString();
            }

        }

        // Button zum bearbeiten eines Rohstoffes (panel wird aktiviert)
        private void RBearbeiten_Click(object sender, EventArgs e)
        {
            panel.Enabled = true;
            RID.Focus();
        }

        // Durch "ENTF" Taste kann ein Eintrag gelöscht werden, es folgt ein Bestätigungsfenster (JA/NEIN), Bei Löschung wird der Eintrag entfernt
        private void dataGridViewLager_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Falls Sie dieses Objekt löschen wollen, klicken Sie auf >Yes< und dann wählen Sie >Speichern<.", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    rohstoffeBindingSource.RemoveCurrent();
                rohstoffeBindingSource.EndEdit();
            }
        }

        //  Button zum speichern eines Rohstoffes -> muss nach jedem Update der Daten betätigt werden, Panel wird deaktiviert und alle Veränderungen werden durch den "tableAdapter" endgültig in der Datenbank gespeichert
        private void RSpeichern_Click(object sender, EventArgs e)
        {
            try
            {
                rohstoffeBindingSource.EndEdit();
                rohstoffeTableAdapter.Update(this.baeckerei40DataSet1.Rohstoffe);
                panel.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rohstoffeBindingSource.ResetBindings(false);
            }
        }

        //Panel deaktiviert und Änderungen verworfen
        private void RAbbrechen_Click(object sender, EventArgs e)
        {
            panel.Enabled = false;
            rohstoffeBindingSource.ResetBindings(false);
        }


        //#######################################-Tab Rezeptverwaltung-#########################################

        // Eingaben werden als String interpretiert, den jeweiligen Eingabefeldern wird ein Ausgabefeld im DataGrid zugeordnet
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RezID.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            Rezname.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            Rohname.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            Rohmenge.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            Roheinheit.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
            Rohname1.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
            Rohmenge1.Text = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
            Roheinheit1.Text = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
            Rohname2.Text = dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString();
            Rohmenge2.Text = dataGridView2.Rows[e.RowIndex].Cells[9].Value.ToString();
            Roheinheit2.Text = dataGridView2.Rows[e.RowIndex].Cells[10].Value.ToString();
            Rohname3.Text = dataGridView2.Rows[e.RowIndex].Cells[11].Value.ToString();
            Rohmenge3.Text = dataGridView2.Rows[e.RowIndex].Cells[12].Value.ToString();
            Roheinheit3.Text = dataGridView2.Rows[e.RowIndex].Cells[13].Value.ToString();
        }

        // Buttons haben gleiche Funktionsweise, siehe Reiter: "Lager"
        // Button zum hinzufügen eines Rezeptes, Panel zur Eingabe wird aktiviert, Eingaben werden in der Datenbank gespeichert, Bei Fehleingaben erfolgt eine Fehlermeldung
        private void RezHinzu_Click(object sender, EventArgs e)
        {
            try
            {
                panelRez.Enabled = true;
                RezID.Focus();
                this.baeckerei40DataSet5.Rezeptverwaltung.AddRezeptverwaltungRow(this.baeckerei40DataSet5.Rezeptverwaltung.NewRezeptverwaltungRow());
                rezeptverwaltungBindingSource.MoveLast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rezeptverwaltungBindingSource.ResetBindings(false);
            }
        }


        private void RezBearb_Click(object sender, EventArgs e)
        {

            panelRez.Enabled = true;
            RezID.Focus();
        }

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Falls Sie dieses Objekt löschen wollen, klicken Sie auf >Yes< und dann wählen Sie >Speichern<.", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    rezeptverwaltungBindingSource.RemoveCurrent();
                rezeptverwaltungBindingSource.EndEdit();
            }
        }

        private void RezAbbr_Click(object sender, EventArgs e)
        {
            panelRez.Enabled = false;
            rezeptverwaltungBindingSource.ResetBindings(true);
            rezeptverwaltungBindingSource.EndEdit();
        }

        private void RezSp_Click(object sender, EventArgs e)
        {
            try
            {
                rezeptverwaltungBindingSource.EndEdit();
                rezeptverwaltungTableAdapter.Update(this.baeckerei40DataSet5.Rezeptverwaltung);
                panelRez.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rezeptverwaltungBindingSource.ResetBindings(false);
            }
        }


        //#######################################-Tab Kommissionierung-#########################################

        // Taschenrechner zum Berechnen des Gesamtpreises
        double ersterWert;
        string operation;


        private void button1_Click(object sender, EventArgs e)
        {
            textBox_anzeige.AppendText("1");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox_anzeige.AppendText("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox_anzeige.AppendText("3");
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            textBox_anzeige.AppendText("4");
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            textBox_anzeige.AppendText("5");
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            textBox_anzeige.AppendText("6");
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            textBox_anzeige.AppendText("7");
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            textBox_anzeige.AppendText("8");
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            textBox_anzeige.AppendText("9");
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            textBox_anzeige.AppendText("0");
        }


        //Berechnungen
        private void button_istgleich_Click_1(object sender, EventArgs e)
        {
            {
                double zweiterWert = Double.Parse(textBox_anzeige.Text);
                double ergebnis;

                switch (operation)
                {
                    case "+":
                        ergebnis = ersterWert + zweiterWert;
                        break;
                    case "-":
                        ergebnis = ersterWert - zweiterWert;
                        break;
                    case "*":
                        ergebnis = ersterWert * zweiterWert;
                        break;
                    default:
                        ergebnis = -1;
                        break;
                }

                textBox_anzeige.Text = ergebnis.ToString();

            }
        }

        //Buttons für Rechenopertionen
        private void btn_minus_Click_1(object sender, EventArgs e)
        {
            ersterWert = Double.Parse(textBox_anzeige.Text);
            operation = "-";
            textBox_anzeige.Text = null;
        }

        private void button_clear_Click_1(object sender, EventArgs e)
        {
            textBox_anzeige.Text = null;
        }

        private void button_mult_Click_1(object sender, EventArgs e)
        {
            ersterWert = Double.Parse(textBox_anzeige.Text);
            operation = "*";
            textBox_anzeige.Text = null;
        }

        private void plus_Click_1(object sender, EventArgs e)
        {
            ersterWert = Double.Parse(textBox_anzeige.Text);
            operation = "+";
            textBox_anzeige.Text = null;
        }


        //Hinzufügen einer Checkbox für Warenausgabe
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCheckBoxColumn CheckBoxColumn = new DataGridViewCheckBoxColumn();
        }

        //Button zum Hinzufügen des Gesamtpreises einer Bestellung
        private void Kom_bearb_Click(object sender, EventArgs e)
        {
            panelKom.Enabled = true;
            tb_BestellID.Focus();
        }

        //Button zum Speichern der Änderungen
        private void Kom_speichern_Click(object sender, EventArgs e)
        {
            try
            {
                bestellungenBindingSource.EndEdit();
                bestellungenTableAdapter.Update(this.baeckerei40DataSet.Bestellungen);
                panelKom.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bestellungenBindingSource.ResetBindings(false);
            }
        }
    }
}

