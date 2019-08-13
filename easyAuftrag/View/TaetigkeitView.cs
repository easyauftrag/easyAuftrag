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

using Core.Model;
using Core;
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
    /// Windows Form für Tätigkeiten
    /// </summary>
    /// <remarks>
    /// Wird aufgerufen, um Tätigkeiten anzulegen, zu bearbeiten und zu löschen
    /// </remarks>
    public partial class TaetigkeitView : Form
    {
        /// <summary>
        /// Hier werden die eingegebenen Daten zwischengespeichert, 
        /// um sie dann an den <see cref="Core.Handler"/> zu übergeben, oder in der <see cref="TaetigkeitView"/> anzuzeigen.
        /// </summary>
        /// <value>
        /// Wird durch <see cref="FillTaetigkeit"/> oder <see cref="MainView"/> gefüllt
        /// und gibt seine Daten an <see cref="FillControls"/>, um sie in der View anzuzeigen.
        /// </value>
        public Taetigkeit TaetigkeitInfo { get; set; }

        /// <summary>
        /// Konstruktor für die <see cref="TaetigkeitView"/>
        /// </summary>
        /// <param name="titel"></param>
        public TaetigkeitView(string titel)
        {
            TaetigkeitInfo = new Taetigkeit();
            InitializeComponent();
            Text = titel;
            using (var db = new EasyAuftragContext())
            {
                var mitarbeiter = (from k in db.Mitarbeiters select new { ID = k.MitarbeiterID, mName = k.Name }).ToList();
                cbMitarbeiter.DataSource = mitarbeiter;
                cbMitarbeiter.DisplayMember = "mName";
                cbMitarbeiter.ValueMember = "ID";
            }
        }

        Handler _handler = new Handler();
        /// <summary>
        /// Konstruktor für die <see cref="TaetigkeitView"/>
        /// </summary>
        /// <param name="titel"></param>
        /// <param name="taetigkeit"></param>
        public TaetigkeitView(string titel, Taetigkeit taetigkeit)
        {
            InitializeComponent();
            Text = titel;
            TaetigkeitInfo = taetigkeit;
            FillControls(TaetigkeitInfo);
        }

        /// <summary>
        /// Packt die Eingaben in den Controls in eine <see cref="Taetigkeit"/>.
        /// </summary>
        /// <returns>Taetigkeit aus den Eingaben in den Controls</returns>
        private void FillTaetigkeit()
        {
            try
            {
                TaetigkeitInfo.MitarbeiterID = Convert.ToInt32(cbMitarbeiter.SelectedValue);
                TaetigkeitInfo.Datum = dtpDatum.Value;
                TaetigkeitInfo.Name = tbName.Text;
                TimeSpan start;
                if (TimeSpan.TryParse(tbStart.Text, out start))
                {
                    TaetigkeitInfo.StartZeit = start;
                }
                else
                {
                    errorInfo.SetError(tbStart, "Bitte korrekte Uhrzeit eingeben!");
                }
                TimeSpan ende;
                if (TimeSpan.TryParse(tbEnde.Text, out ende))
                {
                    TaetigkeitInfo.EndZeit = ende;
                }
                else
                {
                    errorInfo.SetError(tbEnde, "Bitte korrekte Uhrzeit eingeben!");
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }

        }

        /// <summary>
        /// Zeigt die übergebene <see cref="Taetigkeit"/> in den Controls an.
        /// </summary>
        /// <param name="taetigkeit"></param>
        private void FillControls(Taetigkeit taetigkeit)
        {
            // TODO MitarbeiterID
            using (var db = new EasyAuftragContext())
            {
                int[] mitarbeiterIDs = (from k in db.Mitarbeiters select k.MitarbeiterID).ToArray();
                var cbMitarbeiterEintraege = (from k in db.Mitarbeiters select new { ID = k.MitarbeiterID, mName = k.Name }).ToList();
                cbMitarbeiter.DataSource = cbMitarbeiterEintraege;
                cbMitarbeiter.DisplayMember = "mName";
                cbMitarbeiter.ValueMember = "ID";
                cbMitarbeiter.SelectedValue = Array.IndexOf(mitarbeiterIDs, TaetigkeitInfo.MitarbeiterID) + 1;
            }
            dtpDatum.Value = taetigkeit.Datum;
            tbName.Text = taetigkeit.Name;
            tbStart.Text = taetigkeit.StartZeit.ToString();
            tbEnde.Text = taetigkeit.EndZeit.ToString();

        }

        /// <summary>
        /// Action beim Klick auf den "Speichen" Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButSpeichern_Click(object sender, EventArgs e)
        {
            FillTaetigkeit();
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