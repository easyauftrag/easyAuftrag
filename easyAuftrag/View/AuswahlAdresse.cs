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
    /// Wird aufgerufen, um Adressen auszuwählen
    /// </remarks>
    /// <seealso cref="Adresse"/>
    public partial class AuswahlAdresse : Form
    {
        /// <summary>
        /// Hier werden die eingegebenen Daten zwischengespeichert, 
        /// um sie dann an <see cref="easyAuftrag.Logik.Drucken"/> zu übergeben, oder in der <see cref="AuswahlAdresse"/> anzuzeigen.
        /// </summary>
        /// <value>
        /// Wird durch <see cref="ButAuswahl_Click"/> gefüllt
        /// und gibt seine Daten an <see cref="FillControls"/>, um sie in der View anzuzeigen.
        /// </value>
        public Adresse AdresseInfo { get; set; }
        private List<Adresse> _adressen = new List<Adresse>();

        /// <summary>
        /// Konstruktor für <see cref="AuswahlAdresse"/>
        /// </summary>
        /// <param name="kunde"></param>
        /// <param name="connection"></param>
        /// <seealso cref="EasyAuftragContext"/>
        public AuswahlAdresse(Kunde kunde, List<Adresse> adrlist)
        {
            AdresseInfo = new Adresse();
            _adressen = adrlist;
            InitializeComponent();
            try
            {
                Adresse rechnungsadresse = new Adresse
                {
                    KundeID = kunde.KundeID,
                    Strasse = kunde.Strasse,
                    Hausnr = kunde.Hausnr,
                    PLZ = kunde.PLZ,
                    Wohnort = kunde.Wohnort
                };
                List<(Adresse ad, string adName)> adr = new List<(Adresse, string)>();
                // Zusammenfügen von Adressen und Name zur Anzeige in der ComboBox
                foreach (var item in _adressen)
                {
                    adr.Add((item, "Adresse " + item.AdresseID + ", " + kunde.Name));
                }   
                //Hinzufügen der Rechnungsadresse zur Liste
                adr.Add((rechnungsadresse,"Rechnungsadresse"));
                cbAdresse.DataSource = adr;
                // "Adresse X, Kundename" wird in der ComboBox angezeigt
                cbAdresse.DisplayMember = "adName";
                cbAdresse.ValueMember = "ad";
                // Starten mit "Rechnungsadresse" 
                cbAdresse.SelectedIndex = adr.Count()-1;
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }
        /// <summary>
        /// Methode zum Anzeigen der übergebenen <see cref="Adresse"/> in den Controls
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
        /// Aktion beim Ändern der Auswahl in der <see cref="ComboBox"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbAdresse_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Zwischenpeichern der ausgewälten Adresse zur Weiterverarbeitung
            AdresseInfo = _adressen.ElementAt(cbAdresse.SelectedIndex);
            // Übergeben der Adresse zum Anzeigen in den Controls
            FillControls(AdresseInfo);
        }
        /// <summary>
        /// Aktion beim Klick auf den "Auswahl" Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButAuswahl_Click(object sender, EventArgs e)
        {
            // Zwischenpeichern der ausgewälten Adresse zur Übergabe an "Auftragzettel" im MainView
            AdresseInfo = _adressen.ElementAt(cbAdresse.SelectedIndex);
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
