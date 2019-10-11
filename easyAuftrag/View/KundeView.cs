/*
    Dieses Programm mit dem Namen "easyAuftrag" ist eine Verwaltungssoftware 
    zur Digitalisierung von Auftragszetteln für kleine und mittelständische Handwerksunternehmen.

    
    Copyright (C) 2019  Torben Hettrich (torben.hettrich@kzvbw.de)
    Copyright (C) 2019  Jeremias Weber (jeremias.weber@kzvbw.de)

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License version 3 as published by
    the Free Software Foundation.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.

    Contact us:
    Torben Hettrich & Jeremias Weber
    KZV BW Zahnärztehaus Freiburg
    Merzhauser Str. 114-116
    79100 Freiburg im Breisgau
    DE - Germany
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Model;
using Core;

namespace easyAuftrag.View
{
    /// <summary>
    /// Windows Form für Kunden
    /// </summary>
    /// <remarks>
    /// Wird aufgerufen, um Kunden anzulegen, zu bearbeiten und zu löschen.
    /// </remarks>
    public partial class KundeView : Form
    {
        /// <summary>
        /// Hier werden die eingegebenen Daten zwischengespeichert, 
        /// um sie dann an den <see cref="Handler"/> zu übergeben, oder in der <see cref="KundeView"/> anzuzeigen.
        /// </summary>
        /// <value>
        /// Wird durch <see cref="FillKunde"/> oder <see cref="MainView"/> gefüllt
        /// und gibt seine Daten an <see cref="FillControls"/>, um sie in der View anzuzeigen.
        /// </value>
        public Kunde KundeInfo { get; set; }

        private List<Adresse> _adrlist = new List<Adresse>();
        private BindingSource _bind = new BindingSource();
        private Handler _handler = new Handler();
        private string _connection;

        /// <summary>
        /// Konstruktor für die <see cref="KundeView"/>
        /// </summary>
        /// <param name="titel">Titel des Fensters</param>
        public KundeView(string titel, string connection)
        {
            _connection = connection;
            KundeInfo = new Kunde();
            InitializeComponent();
            Text = titel;
        }

        /// <summary>
        /// Konstruktor für die <see cref="KundeView"/>
        /// </summary>
        /// <param name="titel">Titel des Fensters</param>
        /// <param name="kunde">Zu bearbeitender/löschender Kunde</param>
        public KundeView(string titel, Kunde kunde, string connection)
        {
            try
            {
                _connection = connection;
                // Zwischenpeichern des ausgewälten Kunden zur Weiterverarbeitung
                KundeInfo = kunde;
                InitializeComponent();
                Text = titel;
                if (titel == "Kunde Löschen")
                {
                    butSpeichern.Text = "Löschen";
                }
                // Übergeben des Kunden zum Anzeigen in den Controls
                FillControls(KundeInfo);
                DataGridNeu();
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        private void DataGridNeu()
        {
            try
            {
                using (var db = new EasyAuftragContext(_connection))
                {
                    // Laden aller zugehörigen Adressen
                    _adrlist = (from ad in db.Adressen where ad.KundeID == KundeInfo.KundeID select ad).ToList();
                }
                _bind.DataSource = _adrlist;
                dgvKunde.DataSource = _bind;
                // AdresseID wird später benötigt, soll aber für den User nicht sichtbar sein
                dgvKunde.Columns["AdresseID"].Visible = false;
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }
        /// <summary>
        /// Packt die Eingaben in den Controls in einen <see cref="Kunde"/>.
        /// </summary>
        /// <returns>Kunde aus den Eingaben in den Controls</returns>
        private void FillKunde()
        {
            try
            {
                KundeInfo.Name = tbName.Text;
                KundeInfo.Strasse = tbStraße.Text;
                KundeInfo.Hausnr = tbHaus.Text;
                KundeInfo.PLZ = tbPLZ.Text;
                KundeInfo.Wohnort = tbStadt.Text;
                KundeInfo.TelefonNr = tbTelefon.Text;
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        /// <summary>
        /// Zeigt den übergebenen <see cref="Kunde"/> in den Controls an.
        /// </summary>
        /// <param name="kunde"></param>
        private void FillControls(Kunde kunde)
        {
            tbName.Text = kunde.Name;
            tbStraße.Text = kunde.Strasse;
            tbHaus.Text = kunde.Hausnr;
            tbPLZ.Text = kunde.PLZ;
            tbStadt.Text = kunde.Wohnort;
            tbTelefon.Text = kunde.TelefonNr;
        }

        /// <summary>
        /// Aktion beim Klick auf den "Speichen" Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButSpeichern_Click(object sender, EventArgs e)
        {
            // Zwischenpeichern des ausgewälten Kunden zur Übergabe an MainView
            FillKunde();
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        /// <summary>
        /// Aktion beim Klick auf den "Abbrechen" Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButAbbr_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        /// <summary>
        /// Aktion beim Klick auf den "Weitere Adresse" Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButAdresse_Click(object sender, EventArgs e)
        {
            NeueAdresse();
        }
        
        /// <summary>
        /// Aktion beim Rechtsklick auf die <see cref="DataGridView"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvKunde_MouseUp(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                cxtKunde.Show(dgvKunde, e.X, e.Y);
            }
        }
        /// <summary>
        /// Aktion beim Klick auf "Neu" im Kontextmenu auf der <see cref="DataGridView"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NeuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NeueAdresse();
        }
        /// <summary>
        /// Aktion beim Klick auf "Bearbeiten" im Kontextmenu auf der <see cref="DataGridView"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BearbeitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int adresseID = Convert.ToInt32(dgvKunde.SelectedRows[0].Cells["AdresseID"].Value);
            AdresseView adresseV = new AdresseView("Adresse Bearbeiten", adresse: _handler.AdresseLaden(adresseID, out bool success, _connection));
            if (success == false)
            {
                MessageBox.Show("Adresse nicht in der Datenbank gefunden");
            }
            else if (adresseV.ShowDialog() == DialogResult.OK)
            {
                if (!_handler.AdresseBearbeiten(adresseV.AdresseInfo, adresseID, _connection))
                {
                    MessageBox.Show("Adresse nicht in der Datenbank gefunden");
                }
            }
            this.BringToFront();
            this.Activate();
            DataGridNeu();
        }
        /// <summary>
        /// Aktion beim Klick auf "Löschen" im Kontextmenu auf der <see cref="DataGridView"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoeschenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int adresseID = Convert.ToInt32(dgvKunde.SelectedRows[0].Cells["AdresseID"].Value);
            AdresseView adresseV = new AdresseView("Adresse Löschen", adresse: _handler.AdresseLaden(adresseID, out bool success, _connection));
            if (success == false)
            {
                MessageBox.Show("Adresse nicht in der Datenbank gefunden");
            }
            else if (adresseV.ShowDialog() == DialogResult.OK)
            {
                if (!_handler.AdresseLoeschen(adresseID, _connection))
                {
                    MessageBox.Show("Adresse nicht in der Datenbank gefunden");
                }
            }
            this.BringToFront();
            this.Activate();
            DataGridNeu();
        }
        /// <summary>
        /// Methode zum Anlegen einer neuen Tätigkeit
        /// </summary>
        /// <remarks>
        /// Öffnet <see cref="AdresseView"/> und legt eine neue Adresse an, falls erstere <see cref="DialogResult.OK"/> zurückgibt.
        /// </remarks>
        private void NeueAdresse()
        {
            AdresseView adresseV = new AdresseView("Neue Adresse");
            if (adresseV.ShowDialog() == DialogResult.OK)
            {
                KundeInfo.WeitereAdressen.Add(adresseV.AdresseInfo);
                _bind.Add(adresseV.AdresseInfo);
            }
            this.BringToFront();
            this.Activate();
        }
    }
}
