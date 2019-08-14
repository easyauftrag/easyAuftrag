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
using Core;
using Core.Model;
using easyAuftrag.View;

namespace easyAuftrag.View
{
    /// <summary>
    /// Windows Form für Aufträge
    /// </summary>
    /// <remarks>
    /// Wird aufgerufen, um Aufträge anzulegen, zu bearbeiten und zu löschen.
    /// </remarks>
    /// <seealso cref="Auftrag"/>
    public partial class AuftragView : Form
    {
        /// <summary>
        /// Hier werden die eingegebenen Daten zwischengespeichert, 
        /// um sie dann an den <see cref="Handler"/> zu übergeben, oder in der <see cref="AuftragView"/> anzuzeigen.
        /// </summary>
        /// <value>
        /// Wird durch <see cref="FillAuftrag"/> oder <see cref="MainView"/> gefüllt
        /// und gibt seine Daten an <see cref="FillControls"/>, um sie in der View anzuzeigen.
        /// </value>
        public Auftrag AuftragInfo { get; set; }
        private List<Taetigkeit> Tatlist { get; set; }
        private BindingSource Bs = new BindingSource();

        /// <summary>
        /// Konstruktor für die <see cref="AuftragView"/>
        /// </summary>
        /// <param name="titel">Titel für das Fenster</param>
        public AuftragView(string titel)
        {
            AuftragInfo = new Auftrag();
            InitializeComponent();
            Text = titel;
            using (var db = new EasyAuftragContext())
            {
                var kunden = (from k in db.Kunden select new { ID = k.KundeID, kName = k.Name }).ToList();
                cbKunde.DataSource = kunden;
                cbKunde.DisplayMember = "kName";
                cbKunde.ValueMember = "ID";
            }
           
        }

        /// <summary>
        /// Konstruktor für die <see cref="AuftragView"/>
        /// </summary>
        /// <param name="titel">Titel für das Fenster</param>
        /// <param name="auftrag">Zu bearbeitender/löschender Auftrag</param>
        public AuftragView(string titel, Auftrag auftrag)
        {
            InitializeComponent();
            Text = titel;
            AuftragInfo = auftrag;
            FillControls(AuftragInfo);
            using (var db = new EasyAuftragContext())
            {
                Tatlist = (from t in db.Taetigkeiten where t.AuftragID == auftrag.AuftragID select t).ToList();
            }
            Bs.DataSource = Tatlist;
            dgvAuftrag.DataSource = Bs;
        }


        /// <summary>
        /// Packt die Eingaben in den Controls in einen <see cref="Auftrag"/>.
        /// </summary>
        /// <returns>Auftrag aus den Eingaben in den Controls</returns>
        private void FillAuftrag()
        {

            try
            {
                AuftragInfo.AuftragNummer = tbAuftragNr.Text;
                AuftragInfo.KundeID = Convert.ToInt32(cbKunde.SelectedValue);
                AuftragInfo.Eingang = dtpEingang.Value;
                AuftragInfo.Erteilt = dtpErteilt.Value;
                AuftragInfo.Erledigt = cbErledigt.Checked;
                AuftragInfo.Abgerechnet = cbAbgerechnet.Checked;

            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        /// <summary>
        /// Zeigt den übergebenen <see cref="Auftrag"/> in den Controls an.
        /// </summary>
        /// <param name="auftrag"></param>
        private void FillControls(Auftrag auftrag)
        {
            tbAuftragNr.Text = auftrag.AuftragNummer;
            using (var db = new EasyAuftragContext())
            {
                int[] kundenIDs = (from k in db.Kunden select k.KundeID).ToArray();
                var cbKundeEintraege = (from k in db.Kunden select new { ID = k.KundeID, kName = k.Name }).ToList();
                cbKunde.DataSource = cbKundeEintraege;
                cbKunde.DisplayMember = "kName";
                cbKunde.ValueMember = "ID";
                cbKunde.SelectedValue = Array.IndexOf(kundenIDs, auftrag.KundeID) + 1;
            }
            dtpEingang.Value = auftrag.Eingang;
            dtpErteilt.Value = auftrag.Erteilt;
            cbErledigt.Checked = auftrag.Erledigt;
            cbAbgerechnet.Checked = auftrag.Abgerechnet;
            tbGesamt.Text = auftrag.ZeitGesamt.ToString();
        }

        /// <summary>
        /// Action beim Klick auf den "Speichen" Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButSpeichern_Click(object sender, EventArgs e)
        {
            FillAuftrag();
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

        /// <summary>
        /// Action beim Klick auf den "Neue Tätigkeit" Button
        /// </summary>
        /// <remarks>
        /// Öffnet <see cref="TaetigkeitView"/> und legt eine neue Taetigkeit an, falls erstere <see cref="DialogResult.OK"/> zurückgibt.
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButNeueTaetigkeit_Click(object sender, EventArgs e)
        {
            TaetigkeitView taetigkeitV = new TaetigkeitView("Neue Tätigkeit");
            if (taetigkeitV.ShowDialog() == DialogResult.OK)
            {
                AuftragInfo.Taetigkeiten.Add(taetigkeitV.TaetigkeitInfo);
                Bs.Add(taetigkeitV.TaetigkeitInfo);
            }
            this.BringToFront();
            this.Activate();
        }

    }
}
