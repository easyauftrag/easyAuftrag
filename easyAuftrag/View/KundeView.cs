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
        public Kunde KundenInfo { get; set; }

        /// <summary>
        /// Konstruktor für die <see cref="KundeView"/>
        /// </summary>
        /// <param name="titel">Titel des Fensters</param>
        public KundeView(string titel)
        {
            KundenInfo = new Kunde();
            InitializeComponent();
            Text = titel;
        }

        /// <summary>
        /// Konstruktor für die <see cref="KundeView"/>
        /// </summary>
        /// <param name="titel">Titel des Fensters</param>
        /// <param name="kunde">Zu bearbeitender/löschender Kunde</param>
        public KundeView(string titel, Kunde kunde)
        {
            InitializeComponent();
            Text = titel;
            KundenInfo = kunde;
            FillControls(KundenInfo);
        }

        /// <summary>
        /// Packt die Eingaben in den Controls in einen <see cref="Kunde"/>.
        /// </summary>
        /// <returns>Kunde aus den Eingaben in den Controls</returns>
        private void FillKunde()
        {
            try
            {
                // errorInfo.Clear();

                KundenInfo.Name = tbName.Text;
                KundenInfo.RechnungsAdresse.Strasse = tbStraße.Text;
                KundenInfo.RechnungsAdresse.Hausnr = tbHaus.Text;
                KundenInfo.RechnungsAdresse.PLZ = tbPLZ.Text;
                KundenInfo.RechnungsAdresse.Wohnort = tbStadt.Text;
                KundenInfo.TelefonNr = tbTelefon.Text;

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
            tbStraße.Text = kunde.RechnungsAdresse.Strasse;
            tbHaus.Text = kunde.RechnungsAdresse.Hausnr;
            tbPLZ.Text = kunde.RechnungsAdresse.PLZ;
            tbStadt.Text = kunde.RechnungsAdresse.Wohnort;
            tbTelefon.Text = kunde.TelefonNr;

        }

        /// <summary>
        /// Action beim Klick auf den "Speichen" Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButSpeichern_Click(object sender, EventArgs e)
        {
            FillKunde();
            this.DialogResult = DialogResult.OK;
            this.Hide();
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
    }
}
