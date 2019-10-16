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
    /// Windows Form für Länder
    /// </summary>
    /// <remarks>
    /// Wird aufgerufen, um Länder anzulegen, zu bearbeiten und zu löschen
    /// </remarks>
    public partial class LaenderView : Form
    {
        /// <summary>
        /// Hier werden die eingegebenen Daten zwischengespeichert, 
        /// um sie dann an den <see cref="Core.Handler"/> zu übergeben, oder in der <see cref="LaenderView"/> anzuzeigen.
        /// </summary>
        /// <value>
        /// Wird durch <see cref="FillLand"/> oder <see cref="MainView"/> gefüllt
        /// und gibt seine Daten an <see cref="FillControls"/>, um sie in der View anzuzeigen.
        /// </value>
        public Land LandInfo { get; set; }

        /// <summary>
        /// Konstruktor für die <see cref="LaenderView"/>
        /// </summary>
        public LaenderView(string titel, string connection)
        {
            LandInfo = new Land();
            InitializeComponent();
            Text = titel;
        }

        /// <summary>
        /// Konstruktor für die <see cref="LaenderView"/>
        /// </summary>
        public LaenderView(string titel, Land land, string connection)
        {
            InitializeComponent();
            Text = titel; 
            if (titel == "Land Löschen")
            {
                butSpeichern.Text = "Löschen";
            }
            LandInfo = land;
            FillControls(LandInfo);
        }

        /// <summary>
        /// Packt die Eingaben in den Controls in einen <see cref="Land"/>.
        /// </summary>
        /// <returns>Mitarbeiter aus den Eingaben in den Controls</returns>
        private void FillLand()
        {
            try
            {
                LandInfo.Name = tbName.Text;
                LandInfo.Kuerzel = tbKuerzel.Text;
                LandInfo.Vorwahl = tbVorwahl.Text;
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
        private void FillControls(Land land)
        {
            tbName.Text = land.Name;
            tbKuerzel.Text = land.Kuerzel;
            tbVorwahl.Text = land.Vorwahl;
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
            else
            {
                FillLand();
                this.DialogResult = DialogResult.OK;
                this.Hide();
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
    }
}
