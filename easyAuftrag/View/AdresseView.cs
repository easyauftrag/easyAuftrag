﻿/*
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
    /// Windows Form für Adressen
    /// </summary>
    /// <remarks>
    /// Wird aufgerufen, um Adressen anzulegen, zu bearbeiten und zu löschen
    /// </remarks>
    public partial class AdresseView : Form
    {
        /// <summary>
        /// Hier werden die eingegebenen Daten zwischengespeichert, 
        /// um sie dann an den <see cref="Core.Handler"/> zu übergeben, oder in der <see cref="AdresseView"/> anzuzeigen.
        /// </summary>
        /// <value>
        /// Wird durch <see cref="FillAdresse"/> oder <see cref="MainView"/> gefüllt
        /// und gibt seine Daten an <see cref="FillControls"/>, um sie in der View anzuzeigen.
        /// </value>
        public Adresse AdresseInfo { get; set; }
        private string _connection;

        /// <summary>
        /// Konstruktor für die <see cref="AdresseView"/>
        /// </summary>
        /// <param name="titel"></param>
        public AdresseView(string titel, string connection)
        {
            _connection = connection;
            AdresseInfo = new Adresse();
            InitializeComponent();
            Text = titel;
        }
        /// <summary>
        /// Konstruktor für die <see cref="AdresseView"/>
        /// </summary>
        /// <param name="titel"></param>
        /// <param name="adresse"></param>
        public AdresseView(string titel, Adresse adresse, string connection)
        {
            _connection = connection;
            InitializeComponent();
            Text = titel;
            if (titel == "Adresse Löschen")
            {
                butSpeichern.Text = "Löschen";
            }
            // Zwischenpeichern der ausgewälten Adresse zur Weiterverarbeitung
            AdresseInfo = adresse;
            // Übergeben der Adresse zum Anzeigen in den Controls
            FillControls(AdresseInfo);
        }
        /// <summary>
        /// Übergeben der Eingaben in den Controls an eine <see cref="Adresse"/>.
        /// </summary>
        private void FillAdresse()
        {
            try
            {
                AdresseInfo.Strasse = tbStraße.Text;
                AdresseInfo.Hausnr = tbHaus.Text;
                AdresseInfo.PLZ = tbPLZ.Text;
                AdresseInfo.Wohnort = tbStadt.Text;
                AdresseInfo.LandID = Convert.ToInt32(cmbLand.SelectedValue);
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }
        /// <summary>
        /// Zeigt die übergebene <see cref="Adresse"/> in den Controls an.
        /// </summary>
        /// <param name="adresse"></param>
        private void FillControls(Adresse adresse)
        {
            tbStraße.Text = adresse.Strasse;
            tbHaus.Text = adresse.Hausnr;
            tbPLZ.Text = adresse.PLZ;
            tbStadt.Text = adresse.Wohnort;
            using (var db = new EasyAuftragContext(_connection))
            {
                int[] landIDs = (from lnd in db.Laender select lnd.LandID).ToArray();
                var cbLandEintraege = (from lnd in db.Laender select lnd).ToList();
                cmbLand.DataSource = cbLandEintraege;
                cmbLand.DisplayMember = "Name";
                cmbLand.ValueMember = "LandID";
                cmbLand.SelectedIndex = Array.IndexOf(landIDs, adresse.LandID);
            }
        }
        /// <summary>
        /// Aktion beim Klick auf den "Speichen" Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButSpeichern_Click(object sender, EventArgs e)
        {
            errProv.Clear();
            if (String.IsNullOrEmpty(tbStraße.Text))
            {
                errProv.SetError(tbStraße, "Straße darf nicht leer sein.");
            }
            else if (String.IsNullOrEmpty(tbHaus.Text))
            {
                errProv.SetError(tbHaus, "Hausnr. darf nicht leer sein.");
            }
            else if (String.IsNullOrEmpty(tbStadt.Text))
            {
                errProv.SetError(tbStadt, "Stadt darf nicht leer sein.");
            }
            else if (String.IsNullOrEmpty(tbPLZ.Text))
            {
                errProv.SetError(tbPLZ, "PLZ darf nicht leer sein.");
            }
            else if (!Regex.IsMatch(tbPLZ.Text, @"^([0]{1}[1-9]{1}|[1-9]{1}[0-9]{1})[0-9]{3}$"))
            {
                errProv.SetError(tbPLZ, "Bitte gültige PLZ eingeben.");
            }
            else
            {
                // Zwischenpeichern der ausgewälten Adresse zur Übergabe an KundeView
                FillAdresse();
                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
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
        /// Aktion beim Halten der Maus über das PLZ Label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabPLZ_MouseHover(object sender, EventArgs e)
        {
            toolTipPLZ.Show("5-Stellige Zahl", labPLZ);
        }
        /// <summary>
        /// Aktion beim Halten der Maus über die PLZ Textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbPLZ_MouseHover(object sender, EventArgs e)
        {
            toolTipPLZ.Show("5-Stellige Zahl", tbPLZ);
        }

        private void AdresseView_Load(object sender, EventArgs e)
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
