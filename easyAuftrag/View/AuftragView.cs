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
using easyAuftrag.Logik;

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

        private List<Taetigkeit> _tatlist = new List<Taetigkeit>();
        private BindingSource _bind = new BindingSource();
        private Handler _handler = new Handler();
        private string _connection;

        /// <summary>
        /// Konstruktor für die <see cref="AuftragView"/>
        /// </summary>
        /// <param name="titel">Titel für das Fenster</param>
        /// <seealso cref="EasyAuftragContext"/>
        public AuftragView(string titel, string connection)
        {
            _connection = connection;
            AuftragInfo = new Auftrag();
            InitializeComponent();
            Text = titel;
            using (var db = new EasyAuftragContext(connection))
            {
                // Laden aller Kunden IDs und Namen, um sie in der ComboBox anzuzeigen
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
        public AuftragView(string titel, Auftrag auftrag, string connection)
        {
            _connection = connection;
            InitializeComponent();
            Text = titel;
            if (titel == "Auftrag Löschen")
            {
                butSpeichern.Text = "Löschen";
            }
            // Zwischenpeichern des ausgewälten Auftrags zur Weiterverarbeitung
            AuftragInfo = auftrag;
            // Übergeben des Auftrags zum Anzeigen in den Controls
            FillControls(AuftragInfo);
            DataGridNeu();
        }
        /// <summary>
        /// Methode zum Laden und Aktualisieren der Tätigkeiten im <see cref="DataGridView"/>
        /// </summary>
        /// <seealso cref="EasyAuftragContext"/>
        private void DataGridNeu()
        {
            try
            {
                using (var db = new EasyAuftragContext(_connection))
                {
                    //Laden aller zugehörigen Tätigkeiten
                    _tatlist = (from t in db.Taetigkeiten where t.AuftragID == AuftragInfo.AuftragID select t).ToList();
                }
                _bind.DataSource = _tatlist;
                dgvAuftrag.DataSource = _bind;
                dgvAuftrag.Columns["TaetigkeitID"].Visible = false;
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }

        }
        /// <summary>
        /// Methode zum Transferieren der Werte in den Controls in einen <see cref="Auftrag"/>.
        /// </summary>
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
        /// Methode zum Anzeigen des übergebenen <see cref="Auftrag"/> in den Controls
        /// </summary>
        /// <param name="auftrag"></param>
        /// <seealso cref="EasyAuftragContext"/>
        private void FillControls(Auftrag auftrag)
        {
            tbAuftragNr.Text = auftrag.AuftragNummer;
            using (var db = new EasyAuftragContext(_connection))
            {
                int[] kundenIDs = (from k in db.Kunden select k.KundeID).ToArray();
                var cbKundeEintraege = (from k in db.Kunden select new { ID = k.KundeID, kName = k.Name }).ToList();
                cbKunde.DataSource = cbKundeEintraege;
                cbKunde.DisplayMember = "kName";
                cbKunde.ValueMember = "ID";
                cbKunde.SelectedIndex = Array.IndexOf(kundenIDs, auftrag.KundeID);
            }
            dtpEingang.Value = auftrag.Eingang;
            dtpErteilt.Value = auftrag.Erteilt;
            cbErledigt.Checked = auftrag.Erledigt;
            cbAbgerechnet.Checked = auftrag.Abgerechnet;
            tbGesamt.Text = Math.Round(Berechnung.AuftragZeitGesamt(_tatlist)/60, 2).ToString();
        }

        /// <summary>
        /// Aktion beim Klick auf den "Speichen" Button
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
        /// Aktion beim Klick auf den "Neue Tätigkeit" Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButNeueTaetigkeit_Click(object sender, EventArgs e)
        {
            NeueTaetigkeit();
        }

        /// <summary>
        /// Aktion beim Rechtsklick auf die <see cref="DataGridView"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvAuftrag_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cxtAuftrag.Show(dgvAuftrag, e.X, e.Y);
            }
        }

        /// <summary>
        /// Aktion beim Klick auf "Neu" im Kontextmenu auf der <see cref="DataGridView"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NeuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NeueTaetigkeit();
        }

        /// <summary>
        /// Aktion beim Klick auf "Bearbeiten" im Kontextmenu auf der <see cref="DataGridView"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BearbeitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int taetigkeitID = Convert.ToInt32(dgvAuftrag.SelectedRows[0].Cells["TaetigkeitID"].Value);
            TaetigkeitView taetigkeitV = new TaetigkeitView("Tätigkeit Bearbeiten", taetigkeit: _handler.TaetigkeitLaden(taetigkeitID, out bool success, _connection), _connection);
            if (success == false)
            {
                MessageBox.Show("Tätigkeit nicht in der Datenbank gefunden");
            }
            else if (taetigkeitV.ShowDialog() == DialogResult.OK)
            {
                if (!_handler.TaetigkeitBearbeiten(taetigkeitV.TaetigkeitInfo, taetigkeitID, _connection))
                {
                    MessageBox.Show("Tätigkeit nicht in der Datenbank gefunden");
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
            int taetigkeitID = Convert.ToInt32(dgvAuftrag.SelectedRows[0].Cells["TaetigkeitID"].Value);
            TaetigkeitView taetigkeitV = new TaetigkeitView("Tätigkeit Löschen", taetigkeit: _handler.TaetigkeitLaden(taetigkeitID, out bool success, _connection), _connection);
            if (success == false)
            {
                MessageBox.Show("Tätigkeit nicht in der Datenbank gefunden");
            }
            else if (taetigkeitV.ShowDialog() == DialogResult.OK)
            {
                if (!_handler.TaetigkeitLoeschen(taetigkeitID, _connection))
                {
                    MessageBox.Show("Tätigkeit nicht in der Datenbank gefunden");
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
        /// Öffnet <see cref="TaetigkeitView"/> und legt eine neue Taetigkeit an, falls erstere <see cref="DialogResult.OK"/> zurückgibt.
        /// </remarks>
        private void NeueTaetigkeit()
        {
            TaetigkeitView taetigkeitV = new TaetigkeitView("Neue Tätigkeit", _connection);
            if (taetigkeitV.ShowDialog() == DialogResult.OK)
            {
                AuftragInfo.Taetigkeiten.Add(taetigkeitV.TaetigkeitInfo);
                _bind.Add(taetigkeitV.TaetigkeitInfo);
            }
            this.BringToFront();
            this.Activate();
        }
    }
}
