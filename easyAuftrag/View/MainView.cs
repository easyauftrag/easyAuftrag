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
using easyAuftrag.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyAuftrag
{
    /// <summary>
    /// Windows Form, welche beim Start des Programms aufgerufen wird.
    /// </summary>
    public partial class MainView : Form
    {
        Handler _handler = new Handler();

        /// <summary>
        /// Konstruktor für die <see cref="MainView"/>
        /// </summary>
        public MainView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Methode zum laden und aktualisieren der Aufträge im <see cref="DataGridView"/>
        /// </summary>
        public void TabelleNeu()
        {
            try
            {
                using (var db = new EasyAuftragContext())
                {
                    if (cbErledigt.Checked)
                    {
                        List<Auftrag> auftraege = (from k in db.Auftraege where k.Erledigt == true select k).ToList();
                        dgvMain.DataSource = auftraege;
                    }
                    else
                    {
                        List<Auftrag> auftraege = (from k in db.Auftraege select k).ToList();
                        dgvMain.DataSource = auftraege;
                    }
                    //TODO Spalten abändern, ID ausblenden
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        /// <summary>
        /// Action beim Klick auf den "Neuer Kunde" Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButKunde_Click(object sender, EventArgs e)
        {
            KundeView kundeV = new KundeView("Neuer Kunde");
            if (kundeV.ShowDialog() == DialogResult.OK)
            {
                // MessageBox.Show("OK");
                _handler.KundeAnlegen(kundeV.KundenInfo);
            }
            this.BringToFront();
            this.Activate();
            TabelleNeu();
        }

        /// <summary>
        /// Action beim Klick auf den "Neuer Mitarbeiter" Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButMitarbeiter_Click(object sender, EventArgs e)
        {
            MitarbeiterView mitarbeiterV = new MitarbeiterView("Neuer Mitarbeiter");
            if (mitarbeiterV.ShowDialog() == DialogResult.OK)
            {
                // MessageBox.Show("OK");
                _handler.MitarbeiterAnlegen(mitarbeiterV.MitarbeiterInfo);
            }
            this.BringToFront();
            this.Activate();
            TabelleNeu();
        }

        /// <summary>
        /// Action beim Klick auf den "Neuer Auftrag" Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButAuftrag_Click(object sender, EventArgs e)
        {
            AuftragView auftragV = new AuftragView("Neuer Auftrag");
            if (auftragV.ShowDialog() == DialogResult.OK)
            {
                // MessageBox.Show("OK");
                _handler.AuftragAnlegen(auftragV.AuftragInfo);
            }
            this.BringToFront();
            this.Activate();
            TabelleNeu();
        }

        /// <summary>
        /// Action beim Aktivieren der Checkbox "Erledigte Aufträge"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbErledigt_CheckedChanged(object sender, EventArgs e)
        {
            TabelleNeu();
        }

        /// <summary>
        /// Action beim Laden der Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainView_Load(object sender, EventArgs e)
        {
            TabelleNeu();
        }

        private void DgvMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cxtMain.Show(dgvMain, e.X, e.Y);
            }
        }

        private void NeuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AuftragView auftragV = new AuftragView("Neuer Auftrag");
            if (auftragV.ShowDialog() == DialogResult.OK)
            {
                // MessageBox.Show("OK");
                _handler.AuftragAnlegen(auftragV.AuftragInfo);
            }
            this.BringToFront();
            this.Activate();
            TabelleNeu();
        }

        private void BearbeitenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dgvMain.SelectedRows.Count > 0)
            {
                int auftragID = Convert.ToInt32(dgvMain.SelectedRows[0].Cells["AuftragID"].Value);
                // AuftragLaden hier aufrufen und Auftrag statt auftragID an AuftragView weitergeben
                AuftragView auftragV = new AuftragView("Auftrag Bearbeiten", auftrag: _handler.AuftragLaden(auftragID));
                if (auftragV.ShowDialog() == DialogResult.OK)
                {
                    // MessageBox.Show("OK");
                    _handler.AuftragBearbeiten(auftragV.AuftragInfo, auftragID);
                }
            }
            this.BringToFront();
            this.Activate();
            TabelleNeu();
        }

        private void ButExport_Click(object sender, EventArgs e)
        {

        }

        private void ButNachweis_Click(object sender, EventArgs e)
        {

        }
    }
}
