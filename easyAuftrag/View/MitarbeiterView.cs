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

using Core;
using Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyAuftrag.View
{
    /// <summary>
    /// Windows Form für Mitarbeiter
    /// </summary>
    /// <remarks>
    /// Wird aufgerufen, um Mitarbeiter anzulegen, zu bearbeiten und zu löschen
    /// </remarks>
    public partial class MitarbeiterView : Form
    {
        /// <summary>
        /// Hier werden die eingegebenen Daten zwischengespeichert, 
        /// um sie dann an den <see cref="Core.Handler"/> zu übergeben, oder in der <see cref="MitarbeiterView"/> anzuzeigen.
        /// </summary>
        /// <value>
        /// Wird durch <see cref="FillMitarbeiter"/> oder <see cref="MainView"/> gefüllt
        /// und gibt seine Daten an <see cref="FillControls"/>, um sie in der View anzuzeigen.
        /// </value>
        public Mitarbeiter MitarbeiterInfo { get; set; }
        private string _connection;

        /// <summary>
        /// Konstruktor für die <see cref="MitarbeiterView"/>
        /// </summary>
        public MitarbeiterView(string titel, string connection)
        {
            _connection = connection;
            MitarbeiterInfo = new Mitarbeiter();
            InitializeComponent();
            Text = titel;
        }

        /// <summary>
        /// Konstruktor für die <see cref="MitarbeiterView"/>
        /// </summary>
        public MitarbeiterView(string titel, Mitarbeiter mitarbeiter, string connection)
        {
            _connection = connection;
            InitializeComponent();
            Text = titel; 
            if (titel == "Mitarbeiter Löschen")
            {
                butSpeichern.Text = "Löschen";
            }
            MitarbeiterInfo = mitarbeiter;
            FillControls(MitarbeiterInfo);
        }

        /// <summary>
        /// Packt die Eingaben in den Controls in einen <see cref="Mitarbeiter"/>.
        /// </summary>
        /// <returns>Mitarbeiter aus den Eingaben in den Controls</returns>
        private void FillMitarbeiter()
        {
            try
            {
                MitarbeiterInfo.Name = tbName.Text;
                MitarbeiterInfo.Strasse = tbStraße.Text;
                MitarbeiterInfo.Hausnr = tbHaus.Text;
                MitarbeiterInfo.PLZ = tbPLZ.Text;
                MitarbeiterInfo.LandID = Convert.ToInt32(cmbLand.SelectedValue);
                MitarbeiterInfo.Wohnort = tbStadt.Text;
                MitarbeiterInfo.TelefonNr = tbTelefon.Text;
                int auslastung;
                if (! string.IsNullOrEmpty(tbAuslastung.Text))
                {
                    if (int.TryParse(tbAuslastung.Text, out auslastung))
                    {
                        MitarbeiterInfo.AuslastungStelle = auslastung;
                    }
                    else
                    {
                        errorInfo.SetError(tbAuslastung, "Bitte korrekte Auslastung eingeben!");
                    }
                }
                else
                {
                    MitarbeiterInfo.AuslastungStelle = 100;
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        /// <summary>
        /// Zeigt den übergebenen <see cref="Mitarbeiter"/> in den Controls an.
        /// </summary>
        /// <param name="mitarbeiter"></param>
        private void FillControls(Mitarbeiter mitarbeiter)
        {
            tbName.Text = mitarbeiter.Name;
            tbStraße.Text = mitarbeiter.Strasse;
            tbHaus.Text = mitarbeiter.Hausnr;
            tbPLZ.Text = mitarbeiter.PLZ;
            tbStadt.Text = mitarbeiter.Wohnort;
            tbTelefon.Text = mitarbeiter.TelefonNr;
            tbAuslastung.Text = mitarbeiter.AuslastungStelle.ToString();
            using (var db = new EasyAuftragContext(_connection))
            {
                int[] landIDs = (from lnd in db.Laender select lnd.LandID).ToArray();
                var cbLandEintraege = (from lnd in db.Laender select lnd).ToList();
                cmbLand.DataSource = cbLandEintraege;
                cmbLand.DisplayMember = "Name";
                cmbLand.ValueMember = "LandID";
                cmbLand.SelectedIndex = Array.IndexOf(landIDs, mitarbeiter.LandID);
            }
        }

        /// <summary>
        /// Action beim Klick auf den "Speichen" Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButSpeichern_Click(object sender, EventArgs e)
        {
            errorInfo.Clear();
            if (String.IsNullOrEmpty(tbName.Text))
            {
                errorInfo.SetError(tbName, "Name darf nicht leer sein.");
            }
            if (String.IsNullOrEmpty(tbPLZ.Text))
            {
                if (!Regex.IsMatch(tbPLZ.Text, @"^([0]{1}[1-9]{1}|[1-9]{1}[0-9]{1})[0-9]{3}$"))
                    {
                        errorInfo.SetError(tbPLZ, "Bitte gültige PLZ eingeben.");
                    }
            }
            else
            {
                FillMitarbeiter();
                if (errorInfo.GetError(tbAuslastung) == "")
                {
                    this.DialogResult = DialogResult.OK;
                    this.Hide();
                }
            }
        }

        /// <summary>
        /// Action beim Klick auf den "Abbrechen" Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButAbbr_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }
        /// <summary>
        /// Aktion beim Halten der Maus über das PLZ Label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabPLZ_MouseHover(object sender, EventArgs e)
        {
            toolTipMitarbeiter.Show("5-stellige Zahl", labPLZ);
        }
        /// <summary>
        /// Aktion beim Halten der Maus über die PLZ Textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbPLZ_MouseHover(object sender, EventArgs e)
        {
            toolTipMitarbeiter.Show("5-stellige Zahl", tbPLZ);
        }
        /// <summary>
        /// Aktion beim Halten der Maus über das "Auslastung Stelle" Label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabAuslastung_MouseHover(object sender, EventArgs e)
        {
            toolTipMitarbeiter.Show("Prozentangabe (0-100)", labAuslastung);
        }
        /// <summary>
        /// Aktion beim Halten der Maus über die "Auslastung Stelle" Textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbAuslastung_MouseHover(object sender, EventArgs e)
        {
            toolTipMitarbeiter.Show("Prozentangabe (0-100)", tbAuslastung);
        }

        private void MitarbeiterView_Load(object sender, EventArgs e)
        {
            using (var db = new EasyAuftragContext(_connection))
            {
                int[] landIDs = (from lnd in db.Laender select lnd.LandID).ToArray();
                var cbLandEintraege = (from lnd in db.Laender select lnd).ToList();
                cmbLand.DataSource = cbLandEintraege;
                cmbLand.DisplayMember = "Name";
                cmbLand.ValueMember = "LandID";
            }
        }

        /// <summary>
        /// Aktion beim Konvertieren des Länderformats
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LandFormat(object sender, ListControlConvertEventArgs e)
        {
            string kuerzel = ((Land)e.ListItem).Kuerzel;
            string name = ((Land)e.ListItem).Name;
            string vorwahl = ((Land)e.ListItem).Vorwahl;
            e.Value = kuerzel + " - " + name + " (" + vorwahl + ")";
        }
    }
}
