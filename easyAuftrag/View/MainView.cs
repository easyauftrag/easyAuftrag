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
        private Handler _handler = new Handler();
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
                    var auftraege = (from a in db.Auftraege where a.Abgerechnet == false && a.Erledigt == true select a).ToList();
                    tssLabNummer.Text = auftraege.Count().ToString();

                    if (!string.IsNullOrEmpty(suchControlMain._sucheInfo.TbSuche.Text))
                    {
                        if (suchControlMain._sucheInfo.CbErledigt.Checked && suchControlMain._sucheInfo.CbAbgerechnet.Checked)
                        {
                            var auft = (from a in db.Auftraege
                                        join k in db.Kunden on a.KundeID equals k.KundeID
                                        where a.Abgerechnet != suchControlMain._sucheInfo.CbAbgerechnet.Checked 
                                        && a.Erledigt == suchControlMain._sucheInfo.CbErledigt.Checked
                                        && a.AuftragNummer == suchControlMain._sucheInfo.TbSuche.Text | k.Name == suchControlMain._sucheInfo.TbSuche.Text
                                        select new { a.AuftragID, a.AuftragNummer, k.Name, a.Eingang, a.Erteilt, a.Erledigt, a.Abgerechnet }).ToList();
                            dgvMain.DataSource = auft;
                            dgvMain.Columns["auftragID"].Visible = false;
                            dgvMain.Columns["Name"].HeaderText = "Kundenname";
                        }
                        else if (suchControlMain._sucheInfo.CbErledigt.Checked)
                        {
                            var auft = (from a in db.Auftraege
                                        join k in db.Kunden on a.KundeID equals k.KundeID
                                        where a.Erledigt == true
                                        && a.AuftragNummer == suchControlMain._sucheInfo.TbSuche.Text | k.Name == suchControlMain._sucheInfo.TbSuche.Text
                                        select new { a.AuftragID, a.AuftragNummer, k.Name, a.Eingang, a.Erteilt, a.Erledigt, a.Abgerechnet }).ToList();
                            dgvMain.DataSource = auft;
                            dgvMain.Columns["auftragID"].Visible = false;
                            dgvMain.Columns["Name"].HeaderText = "Kundenname";
                        }
                        else if (suchControlMain._sucheInfo.CbAbgerechnet.Checked)
                        {
                            var auft = (from a in db.Auftraege
                                        join k in db.Kunden on a.KundeID equals k.KundeID
                                        where a.Abgerechnet == false 
                                        && a.AuftragNummer == suchControlMain._sucheInfo.TbSuche.Text | k.Name == suchControlMain._sucheInfo.TbSuche.Text
                                        select new { a.AuftragID, a.AuftragNummer, k.Name, a.Eingang, a.Erteilt, a.Erledigt, a.Abgerechnet }).ToList();
                            dgvMain.DataSource = auft;
                            dgvMain.Columns["auftragID"].Visible = false;
                            dgvMain.Columns["Name"].HeaderText = "Kundenname";
                        }
                        else
                        {
                            var auft = (from a in db.Auftraege
                                        join k in db.Kunden on a.KundeID equals k.KundeID
                                        where a.AuftragNummer == suchControlMain._sucheInfo.TbSuche.Text | k.Name == suchControlMain._sucheInfo.TbSuche.Text
                                        select new { a.AuftragID, a.AuftragNummer, k.Name, a.Eingang, a.Erteilt, a.Erledigt, a.Abgerechnet }).ToList();
                            dgvMain.DataSource = auft;
                            dgvMain.Columns["auftragID"].Visible = false;
                            dgvMain.Columns["Name"].HeaderText = "Kundenname";
                        }
                    }
                    else if (suchControlMain._sucheInfo.CbErledigt.Checked && suchControlMain._sucheInfo.CbAbgerechnet.Checked)
                    {
                        var auft = (from a in db.Auftraege join k in db.Kunden on a.KundeID equals k.KundeID
                                    where a.Abgerechnet != suchControlMain._sucheInfo.CbAbgerechnet.Checked && a.Erledigt == suchControlMain._sucheInfo.CbErledigt.Checked
                                    select new { a.AuftragID, a.AuftragNummer, k.Name, a.Eingang, a.Erteilt, a.Erledigt, a.Abgerechnet }).ToList();
                        dgvMain.DataSource = auft;
                        dgvMain.Columns["auftragID"].Visible = false;
                        dgvMain.Columns["Name"].HeaderText = "Kundenname";
                    }
                    else if(suchControlMain._sucheInfo.CbErledigt.Checked)
                    {
                        var auft = (from a in db.Auftraege join k in db.Kunden on a.KundeID equals k.KundeID
                                    where a.Erledigt == true
                                    select new { a.AuftragID, a.AuftragNummer, k.Name, a.Eingang, a.Erteilt, a.Erledigt, a.Abgerechnet }).ToList();
                        dgvMain.DataSource = auft;
                        dgvMain.Columns["auftragID"].Visible = false;
                        dgvMain.Columns["Name"].HeaderText = "Kundenname";
                    }
                    else if(suchControlMain._sucheInfo.CbAbgerechnet.Checked)
                    {
                        var auft = (from a in db.Auftraege join k in db.Kunden on a.KundeID equals k.KundeID
                                    where a.Abgerechnet == false
                                    select new { a.AuftragID, a.AuftragNummer, k.Name, a.Eingang, a.Erteilt, a.Erledigt, a.Abgerechnet }).ToList();
                        dgvMain.DataSource = auft;
                        dgvMain.Columns["auftragID"].Visible = false;
                        dgvMain.Columns["Name"].HeaderText = "Kundenname";
                    }
                    else
                    {
                        var auft = (from a in db.Auftraege join k in db.Kunden on a.KundeID equals k.KundeID
                                    select new { a.AuftragID, a.AuftragNummer, k.Name, a.Eingang, a.Erteilt, a.Erledigt, a.Abgerechnet }).ToList();
                        dgvMain.DataSource = auft;
                        dgvMain.Columns["auftragID"].Visible = false;
                        dgvMain.Columns["Name"].HeaderText = "Kundenname";
                    }
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
                _handler.KundeAnlegen(kundeV.KundenInfo);
            }
            this.BringToFront();
            this.Activate();
            //TabelleNeu();
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
                _handler.MitarbeiterAnlegen(mitarbeiterV.MitarbeiterInfo);
            }
            this.BringToFront();
            this.Activate();
            //TabelleNeu();
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
                _handler.AuftragAnlegen(auftragV.AuftragInfo);
            }
            this.BringToFront();
            this.Activate();
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
            BuildTreeView();
        }

        private void DgvMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cxtMain.Show(dgvMain, e.X, e.Y);
            }
        }

        private void TSMIneu_Click(object sender, EventArgs e)
        {
            AuftragView auftragV = new AuftragView("Neuer Auftrag");
            if (auftragV.ShowDialog() == DialogResult.OK)
            {
                _handler.AuftragAnlegen(auftragV.AuftragInfo);
            }
            this.BringToFront();
            this.Activate();
            TabelleNeu();
        }

        private void TSMIbearbeiten_Click(object sender, EventArgs e)
        {
            if (dgvMain.SelectedRows.Count > 0)
            {
                int auftragID = Convert.ToInt32(dgvMain.SelectedRows[0].Cells["AuftragID"].Value);
                AuftragView auftragV = new AuftragView("Auftrag Bearbeiten", auftrag: _handler.AuftragLaden(auftragID));
                if (auftragV.ShowDialog() == DialogResult.OK)
                {
                    _handler.AuftragBearbeiten(auftragV.AuftragInfo, auftragID);
                }
            }
            this.BringToFront();
            this.Activate();
            TabelleNeu();
        }
        private void TSMIloeschen_Click(object sender, EventArgs e)
        {
            if (dgvMain.SelectedRows.Count > 0)
            {
                int auftragID = Convert.ToInt32(dgvMain.SelectedRows[0].Cells["AuftragID"].Value);
                AuftragView auftragV = new AuftragView("Auftrag Löschen", auftrag: _handler.AuftragLaden(auftragID));
                if (auftragV.ShowDialog() == DialogResult.OK)
                {
                    _handler.AuftragLoeschen(auftragID);
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

        private void BuildTreeView()
        {
            try
            {
                using (var db = new EasyAuftragContext())
                {
                    List<Kunde> kun = (from k in db.Kunden select k).ToList();
                    foreach (Kunde k in kun)
                    {
                        TreeNode nKunde = new TreeNode(k.Name);
                        nKunde.Tag = "Kunde_" + k.KundeID.ToString();
                        tvMain.Nodes["Kunden"].Nodes.Add(nKunde);
                    }
                    List<Mitarbeiter> mit = (from m in db.Mitarbeiters select m).ToList();
                    foreach (Mitarbeiter m in mit)
                    {
                        TreeNode nMitarbeiter = new TreeNode(m.Name);
                        nMitarbeiter.Tag = "Mitarbeiter_" + m.MitarbeiterID.ToString();
                        tvMain.Nodes["Mitarbeiter"].Nodes.Add(nMitarbeiter);
                    }
                    List<Auftrag> auf = (from a in db.Auftraege select a).ToList();
                    foreach (Auftrag a in auf)
                    {
                        TreeNode nAuftrag = new TreeNode(a.AuftragNummer);
                        nAuftrag.Tag = "Auftrag_" + a.AuftragID.ToString();
                        tvMain.Nodes["Auftraege"].Nodes.Add(nAuftrag);
                    }
                }

            }
            catch (Exception ex)
            {

                ErrorHandler.ErrorHandle(ex);
            }
        }
        private void tvMain_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (tvMain.SelectedNode != null)
                    {
                        if (tvMain.SelectedNode.Tag.ToString().Contains("_"))
                        {
                            toolStripBearbeiten.Enabled = true;
                            toolStripLoeschen.Enabled = true;
                            ctxTree.Show(tvMain, e.X, e.Y);
                        }
                        else
                        {
                            toolStripBearbeiten.Enabled = false;
                            toolStripLoeschen.Enabled = false;
                            ctxTree.Show(tvMain, e.X, e.Y);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                ErrorHandler.ErrorHandle(ex);
            }
        }

        private void toolStripNeu_Click(object sender, EventArgs e)
        {
            try
            {
                if (tvMain.SelectedNode.Tag.ToString().StartsWith("Kun"))
                {
                    Kunde kunde = new Kunde();
                }
                if (tvMain.SelectedNode.Tag.ToString().StartsWith("Mit"))
                {
                    Mitarbeiter mitarbeiter = new Mitarbeiter();
                }
                if (tvMain.SelectedNode.Tag.ToString().StartsWith("Auf"))
                {
                    Auftrag auftrag = new Auftrag();
                }
                if (tvMain.SelectedNode.Tag.ToString().StartsWith("Tae"))
                {
                    Taetigkeit taetigkeit = new Taetigkeit();
                }
            }
            catch (Exception ex)
            {

                ErrorHandler.ErrorHandle(ex);
            }
        }

        private void toolStripBearbeiten_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLoeschen_Click(object sender, EventArgs e)
        {

        }

        
    }
}
