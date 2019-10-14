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

        /// <summary>
        /// Konstruktor für die <see cref="AdresseView"/>
        /// </summary>
        /// <param name="titel"></param>
        public AdresseView(string titel)
        {
            AdresseInfo = new Adresse();
            InitializeComponent();
            Text = titel;
        }
        /// <summary>
        /// Konstruktor für die <see cref="AdresseView"/>
        /// </summary>
        /// <param name="titel"></param>
        /// <param name="adresse"></param>
        public AdresseView(string titel, Adresse adresse)
        {
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
        }
        /// <summary>
        /// Aktion beim Klick auf den "Speichen" Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButSpeichern_Click(object sender, EventArgs e)
        {
            // Zwischenpeichern der ausgewälten Adresse zur Übergabe an KundeView
            FillAdresse();
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
    }
}
