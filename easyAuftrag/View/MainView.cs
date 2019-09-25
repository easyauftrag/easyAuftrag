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
using easyAuftrag.Logik;
using easyAuftrag.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Austausch;

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
        /// Action beim Laden der Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainView_Load(object sender, EventArgs e)
        {
            try
            {
                TabelleNeu();
                TreeViewNeu();
                List<string> lstSpalten = new List<string>();
                int s = dgvMain.Columns.Count;
                for (int i = 1; i < s; i++)
                {
                    lstSpalten.Add(dgvMain.Columns[i].ToString().Split('=')[1].Split(',')[0]);
                }
                suchControlMain.Spalten = lstSpalten;
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        /// <summary>
        /// Methode zum Laden und Aktualisieren der Aufträge im <see cref="DataGridView"/>
        /// </summary>
        /// <seealso cref="EasyAuftragContext"/>
        public void TabelleNeu()
        {
            try
            {
                using (var db = new EasyAuftragContext())
                {
                    var auftraege = (from a in db.Auftraege where a.Abgerechnet == false && a.Erledigt == true select a).ToList();
                    tssLabNummer.Text = auftraege.Count().ToString();
                    var auftr = (from a in db.Auftraege
                                 join k in db.Kunden on a.KundeID equals k.KundeID
                                 select new { a.AuftragID, a.AuftragNummer, k.Name, a.Eingang, a.Erteilt, a.Erledigt, a.Abgerechnet }).ToList();
                    dgvMain.DataSource = auftr;
                    dgvMain.Columns["auftragID"].Visible = false;
                    dgvMain.Columns["Name"].HeaderText = "Kundenname";
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        /// <summary>
        /// Methode zum Laden und Aktualisieren der Einträge im <see cref="TreeView"/>
        /// </summary>
        /// <seealso cref="EasyAuftragContext"/>
        private void TreeViewNeu()
        {
            tvMain.Nodes["Kunden"].Nodes.Clear();
            tvMain.Nodes["Mitarbeiter"].Nodes.Clear();
            tvMain.Nodes["Auftraege"].Nodes.Clear();
            try
            {
                using (var db = new EasyAuftragContext())
                {
                    List<Kunde> kun = (from k in db.Kunden select k).ToList();
                    foreach (Kunde k in kun)
                    {
                        TreeNode nKunde = new TreeNode(k.Name)
                        {
                            Tag = "Kunde_" + k.KundeID.ToString()
                        };
                        tvMain.Nodes["Kunden"].Nodes.Add(nKunde);
                    }
                    List<Mitarbeiter> mit = (from m in db.Mitarbeiters select m).ToList();
                    foreach (Mitarbeiter m in mit)
                    {
                        TreeNode nMitarbeiter = new TreeNode(m.Name)
                        {
                            Tag = "Mitarbeiter_" + m.MitarbeiterID.ToString()
                        };
                        tvMain.Nodes["Mitarbeiter"].Nodes.Add(nMitarbeiter);
                    }
                    List<Auftrag> auf = (from a in db.Auftraege select a).ToList();
                    foreach (Auftrag a in auf)
                    {
                        TreeNode nAuftrag = new TreeNode(a.AuftragNummer)
                        {
                            Tag = "Auftrag_" + a.AuftragID.ToString()
                        };
                        tvMain.Nodes["Auftraege"].Nodes.Add(nAuftrag);
                        List<Taetigkeit> tat = (from t in db.Taetigkeiten where t.AuftragID == a.AuftragID select t).ToList();
                        foreach (Taetigkeit t in tat)
                        {
                            TreeNode nTaetigkeit = new TreeNode(t.Name)
                            {
                                Tag = "Taetigkeit_" + t.TaetigkeitID.ToString()
                            };
                            tvMain.Nodes["Auftraege"].LastNode.Nodes.Add(nTaetigkeit);
                        }
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
            try
            {
                KundeView kundeV = new KundeView("Neuer Kunde");
                if (kundeV.ShowDialog() == DialogResult.OK)
                {
                    _handler.KundeAnlegen(kundeV.KundenInfo);
                }
                this.BringToFront();
                this.Activate();
                TreeViewNeu();
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        /// <summary>
        /// Action beim Klick auf den "Neuer Mitarbeiter" Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButMitarbeiter_Click(object sender, EventArgs e)
        {
            try
            {
                MitarbeiterView mitarbeiterV = new MitarbeiterView("Neuer Mitarbeiter");
                if (mitarbeiterV.ShowDialog() == DialogResult.OK)
                {
                    _handler.MitarbeiterAnlegen(mitarbeiterV.MitarbeiterInfo);
                }
                this.BringToFront();
                this.Activate();
                TreeViewNeu();
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        /// <summary>
        /// Action beim Klick auf den "Neuer Auftrag" Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButAuftrag_Click(object sender, EventArgs e)
        {
            try
            {
                AuftragView auftragV = new AuftragView("Neuer Auftrag");
                if (auftragV.ShowDialog() == DialogResult.OK)
                {
                    _handler.AuftragAnlegen(auftragV.AuftragInfo);
                }
                this.BringToFront();
                this.Activate();
                TabelleNeu();
                TreeViewNeu();
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        /// <summary>
        /// Action beim Rechtsklick auf die <see cref="DataGridView"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cxtMain.Show(dgvMain, e.X, e.Y);
            }
        }

        /// <summary>
        /// Action beim Klick auf "Neu" im Kontextmenu auf der <see cref="DataGridView"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TSMIneu_Click(object sender, EventArgs e)
        {
            try
            {
                AuftragView auftragV = new AuftragView("Neuer Auftrag");
                if (auftragV.ShowDialog() == DialogResult.OK)
                {
                    _handler.AuftragAnlegen(auftragV.AuftragInfo);
                }
                this.BringToFront();
                this.Activate();
                TabelleNeu();
                TreeViewNeu();
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        /// <summary>
        /// Action beim Klick auf "Bearbeiten" im Kontextmenu auf der <see cref="DataGridView"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TSMIbearbeiten_Click(object sender, EventArgs e)
        {
            try
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
                TreeViewNeu();
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        /// <summary>
        /// Action beim Klick auf "Löschen" im Kontextmenu auf der <see cref="DataGridView"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TSMIloeschen_Click(object sender, EventArgs e)
        {
            try
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
                TreeViewNeu();
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        /// <summary>
        /// Action beim Klick auf den "Datei Export" Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButExport_Click(object sender, EventArgs e)
        {
            ExportView exportV = new ExportView("Export");
            if (exportV.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var db = new EasyAuftragContext())
                    {
                        List<Auftrag> auftraege = new List<Auftrag>();
                        List<Kunde> kunden = new List<Kunde>();
                        List<Mitarbeiter> mitarbeiters = new List<Mitarbeiter>();
                        List<Taetigkeit> taetigkeiten = new List<Taetigkeit>();

                        SaveFileDialog dlg = new SaveFileDialog();
                        if (exportV.DateiFormat == ExportView.Format.CSV)
                        {
                            dlg.Filter = "CSV|*.csv|All Files|*.*|Text File|*.txt";
                            dlg.DefaultExt = "*.csv*";

                            CSVConfig cSVConfig = new CSVConfig();
                            if (dlg.ShowDialog() == DialogResult.OK)
                            {
                                if (cSVConfig.ShowDialog() == DialogResult.OK)
                                {
                                    AustauschCSV austauschCSV = new AustauschCSV(cSVConfig.Typen.TrennerDezimal, cSVConfig.Typen.TrennerDaten);
                                    if (exportV.ExportArt == ExportView.Art.Auftrag)
                                    {
                                        auftraege = (from a in db.Auftraege select a).ToList();
                                        austauschCSV.AuftragSchreiben(dlg.FileName, auftraege);
                                    }
                                    else if (exportV.ExportArt == ExportView.Art.Kunde)
                                    {
                                        kunden = (from k in db.Kunden select k).ToList();
                                        austauschCSV.KundeSchreiben(dlg.FileName, kunden);
                                    }
                                    else if (exportV.ExportArt == ExportView.Art.Mitarbeiter)
                                    {
                                        mitarbeiters = (from m in db.Mitarbeiters select m).ToList();
                                        austauschCSV.MitarbeiterSchreiben(dlg.FileName, mitarbeiters);
                                    }
                                    else if (exportV.ExportArt == ExportView.Art.Taetigkeit)
                                    {
                                        taetigkeiten = (from t in db.Taetigkeiten select t).ToList();
                                        austauschCSV.TaetigkeitSchreiben(dlg.FileName, taetigkeiten);
                                    }
                                }
                            }
                        }
                        else if (exportV.DateiFormat == ExportView.Format.XML)
                        {
                            dlg.Filter = "XML|*.xml|All Files|*.*|Text File|*.txt";
                            dlg.DefaultExt = "*.xml*";

                            if (dlg.ShowDialog() == DialogResult.OK)
                            {
                                AustauschXML austauschXML = new AustauschXML();
                                if (exportV.ExportArt == ExportView.Art.Auftrag)
                                {
                                    auftraege = (from a in db.Auftraege select a).ToList();
                                    austauschXML.AuftragSchreiben(dlg.FileName, auftraege);
                                }
                                else if (exportV.ExportArt == ExportView.Art.Kunde)
                                {
                                    kunden = (from k in db.Kunden select k).ToList();
                                    austauschXML.KundeSchreiben(dlg.FileName, kunden);
                                }
                                else if (exportV.ExportArt == ExportView.Art.Mitarbeiter)
                                {
                                    mitarbeiters = (from m in db.Mitarbeiters select m).ToList();
                                    austauschXML.MitarbeiterSchreiben(dlg.FileName, mitarbeiters);
                                }
                                else if (exportV.ExportArt == ExportView.Art.Taetigkeit)
                                {
                                    taetigkeiten = (from t in db.Taetigkeiten select t).ToList();
                                    austauschXML.TaetigkeitSchreiben(dlg.FileName, taetigkeiten);
                                }
                            }
                        }
                        else if (exportV.DateiFormat == ExportView.Format.JSON)
                        {
                            dlg.Filter = "JSON|*.json|All Files|*.*|Text File|*.txt";
                            dlg.DefaultExt = "*.json*";

                            if (dlg.ShowDialog() == DialogResult.OK)
                            {
                                AustauschJSON austauschJSON = new AustauschJSON();
                                if (exportV.ExportArt == ExportView.Art.Auftrag)
                                {
                                    auftraege = (from a in db.Auftraege select a).ToList();
                                    austauschJSON.AuftragSchreiben(dlg.FileName, auftraege);
                                }
                                else if (exportV.ExportArt == ExportView.Art.Kunde)
                                {
                                    kunden = (from k in db.Kunden select k).ToList();
                                    austauschJSON.KundeSchreiben(dlg.FileName, kunden);
                                }
                                else if (exportV.ExportArt == ExportView.Art.Mitarbeiter)
                                {
                                    mitarbeiters = (from m in db.Mitarbeiters select m).ToList();
                                    austauschJSON.MitarbeiterSchreiben(dlg.FileName, mitarbeiters);
                                }
                                else if (exportV.ExportArt == ExportView.Art.Taetigkeit)
                                {
                                    taetigkeiten = (from t in db.Taetigkeiten select t).ToList();
                                    austauschJSON.TaetigkeitSchreiben(dlg.FileName, taetigkeiten);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorHandler.ErrorHandle(ex);
                }
            }
        }

        /// <summary>
        /// Action beim Klick auf den "Auftrag drucken" Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <seealso cref="EasyAuftragContext"/>
        private void ButAuftragZettel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMain.SelectedRows.Count > 0)
                {
                    int auftragID = Convert.ToInt32(dgvMain.SelectedRows[0].Cells["AuftragID"].Value);
                    using (var db = new EasyAuftragContext())
                    {
                        DruckDoc doc = new DruckDoc();
                        Auftrag auftrag = (from a in db.Auftraege where a.AuftragID == auftragID select a).First();
                        Kunde kunde = (from k in db.Kunden where k.KundeID == auftrag.KundeID select k).First();
                        List<Taetigkeit> Tatlist = (from t in db.Taetigkeiten where t.AuftragID == auftrag.AuftragID select t).ToList();
                        List<Mitarbeiter> MitList = new List<Mitarbeiter>();
                        foreach (Taetigkeit t in Tatlist)
                        {
                            MitList.Add((from m in db.Mitarbeiters where m.MitarbeiterID == t.MitarbeiterID select m).First());
                        }
                        doc.AuftragNr = auftrag.AuftragNummer;
                        doc.KundeName = kunde.Name;
                        doc.KundeAnschrift = kunde.Strasse + " " + kunde.Hausnr + ", " + kunde.PLZ + " " + kunde.Wohnort;
                        doc.KundeTelefon = kunde.TelefonNr;
                        doc.TatListe = Tatlist;
                        doc.MitList = MitList;
                        Drucken druck = new Drucken();
                        druck.Druck(doc);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        /// <summary>
        /// Action beim Klick auf den "Stundennachweis drucken" Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButStundenZettel_Click(object sender, EventArgs e)
        {
            try
            {
                StundenView stundV = new StundenView();
                if (stundV.ShowDialog() == DialogResult.OK)
                {
                    Drucken druck = new Drucken();
                    druck.StundenDruck(stundV.stundenDoc);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        /// <summary>
        /// Action beim Rechtsklick auf die <see cref="TreeView"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TvMain_MouseUp(object sender, MouseEventArgs e)
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

        /// <summary>
        /// Action beim Klick auf "Neu" im Kontextmenu auf der <see cref="TreeView"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripNeu_Click(object sender, EventArgs e)
        {
            try
            {
                string[] item = tvMain.SelectedNode.Tag.ToString().Split('_');
                if (item[0].ToLower().StartsWith("kun"))
                {
                    KundeView kundeV = new KundeView("Neuer Kunde");
                    if (kundeV.ShowDialog() == DialogResult.OK)
                    {
                        _handler.KundeAnlegen(kundeV.KundenInfo);
                    }
                    this.BringToFront();
                    this.Activate();
                    TreeViewNeu();
                }
                if (item[0].ToLower().StartsWith("mit"))
                {
                    MitarbeiterView mitarbeiterV = new MitarbeiterView("Neuer Mitarbeiter");
                    if (mitarbeiterV.ShowDialog() == DialogResult.OK)
                    {
                        _handler.MitarbeiterAnlegen(mitarbeiterV.MitarbeiterInfo);
                    }
                    this.BringToFront();
                    this.Activate();
                    TreeViewNeu();
                }
                if (item[0].ToLower().StartsWith("auf"))
                {
                    AuftragView auftragV = new AuftragView("Neuer Auftrag");
                    if (auftragV.ShowDialog() == DialogResult.OK)
                    {
                        _handler.AuftragAnlegen(auftragV.AuftragInfo);
                    }
                    this.BringToFront();
                    this.Activate();
                    TabelleNeu();
                    TreeViewNeu();
                }
                if (item[0].ToLower().StartsWith("tae"))
                {
                    string[] itemParent = tvMain.SelectedNode.Parent.Tag.ToString().Split('_');
                    AuftragView auftragV = new AuftragView("Auftrag Bearbeiten", auftrag: _handler.AuftragLaden(Convert.ToInt32(itemParent[1])));
                    if (auftragV.ShowDialog() == DialogResult.OK)
                    {
                        _handler.AuftragBearbeiten(auftragV.AuftragInfo, Convert.ToInt32(itemParent[1]));
                    }
                    this.BringToFront();
                    this.Activate();
                    TabelleNeu();
                    TreeViewNeu();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        /// <summary>
        /// Action beim Klick auf "Bearbeiten" im Kontextmenu auf der <see cref="TreeView"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripBearbeiten_Click(object sender, EventArgs e)
        {
            try
            {
                string[] item = tvMain.SelectedNode.Tag.ToString().Split('_');
                if (item[0].ToLower().StartsWith("kun"))
                {
                    KundeView kundeV = new KundeView("Kunde Bearbeiten", kunde: _handler.KundeLaden(Convert.ToInt32(item[1])));
                    if (kundeV.ShowDialog() == DialogResult.OK)
                    {
                        _handler.KundeBearbeiten(kundeV.KundenInfo, Convert.ToInt32(item[1]));
                    }
                    this.BringToFront();
                    this.Activate();
                    TreeViewNeu();
                }
                if (item[0].ToLower().StartsWith("mit"))
                {
                    MitarbeiterView mitarbeiterV = new MitarbeiterView("Mitarbeiter Bearbeiten", mitarbeiter: _handler.MitarbeiterLaden(Convert.ToInt32(item[1])));
                    if (mitarbeiterV.ShowDialog() == DialogResult.OK)
                    {
                        _handler.MitarbeiterBearbeiten(mitarbeiterV.MitarbeiterInfo, Convert.ToInt32(item[1]));
                    }
                    this.BringToFront();
                    this.Activate();
                    TreeViewNeu();
                }
                if (item[0].ToLower().StartsWith("auf"))
                {
                    AuftragView auftragV = new AuftragView("Auftrag Bearbeiten", auftrag: _handler.AuftragLaden(Convert.ToInt32(item[1])));
                    if (auftragV.ShowDialog() == DialogResult.OK)
                    {
                        _handler.AuftragBearbeiten(auftragV.AuftragInfo, Convert.ToInt32(item[1]));
                    }
                    this.BringToFront();
                    this.Activate();
                    TabelleNeu();
                    TreeViewNeu();
                }
                if (item[0].ToLower().StartsWith("tae"))
                {
                    TaetigkeitView taetigkeitV = new TaetigkeitView("Tätigkeit Bearbeiten", taetigkeit: _handler.TaetigkeitLaden(Convert.ToInt32(item[1])));
                    if (taetigkeitV.ShowDialog() == DialogResult.OK)
                    {
                        _handler.TaetigkeitBearbeiten(taetigkeitV.TaetigkeitInfo, Convert.ToInt32(item[1]));
                    }
                    this.BringToFront();
                    this.Activate();
                    TreeViewNeu();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        /// <summary>
        /// Action beim Klick auf "Löschen" im Kontextmenu auf der <see cref="TreeView"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripLoeschen_Click(object sender, EventArgs e)
        {
            try
            {
                string[] item = tvMain.SelectedNode.Tag.ToString().Split('_');
                if (item[0].ToLower().StartsWith("kun"))
                {
                    KundeView kundeV = new KundeView("Kunde Löschen", kunde: _handler.KundeLaden(Convert.ToInt32(item[1])));
                    if (kundeV.ShowDialog() == DialogResult.OK)
                    {
                        _handler.KundeLoeschen(Convert.ToInt32(item[1]));
                    }
                    this.BringToFront();
                    this.Activate();
                    TreeViewNeu();
                }
                if (item[0].ToLower().StartsWith("mit"))
                {
                    MitarbeiterView mitarbeiterV = new MitarbeiterView("Mitarbeiter Löschen", mitarbeiter: _handler.MitarbeiterLaden(Convert.ToInt32(item[1])));
                    if (mitarbeiterV.ShowDialog() == DialogResult.OK)
                    {
                        _handler.MitarbeiterLoeschen(Convert.ToInt32(item[1]));
                    }
                    this.BringToFront();
                    this.Activate();
                    TreeViewNeu();
                }
                if (item[0].ToLower().StartsWith("auf"))
                {
                    AuftragView auftragV = new AuftragView("Auftrag Löschen", auftrag: _handler.AuftragLaden(Convert.ToInt32(item[1])));
                    if (auftragV.ShowDialog() == DialogResult.OK)
                    {
                        _handler.AuftragLoeschen(Convert.ToInt32(item[1]));
                    }
                    this.BringToFront();
                    this.Activate();
                    TabelleNeu();
                    TreeViewNeu();
                }
                if (item[0].ToLower().StartsWith("tae"))
                {
                    TaetigkeitView taetigkeitV = new TaetigkeitView("Tätigkeit Löschen", taetigkeit: _handler.TaetigkeitLaden(Convert.ToInt32(item[1])));
                    if (taetigkeitV.ShowDialog() == DialogResult.OK)
                    {
                        _handler.TaetigkeitLoeschen(Convert.ToInt32(item[1]));
                    }
                    this.BringToFront();
                    this.Activate();
                    TreeViewNeu();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        /// <summary>
        /// Methode zum Filtern der Aufträge in der <see cref="DataGridView"/> nach den Kriterien im <see cref="SuchControl"/>
        /// </summary>
        /// <seealso cref="EasyAuftragContext"/>
        private void SuchControlMain_SuchEvent()
        {
            try
            {
                using (var db = new EasyAuftragContext())
                {
                    var auft = (from a in db.Auftraege
                                join k in db.Kunden on a.KundeID equals k.KundeID
                                select new { a.AuftragID, a.AuftragNummer, k.Name, a.Eingang, a.Erteilt, a.Erledigt, a.Abgerechnet }).ToList();
                    List<string> suchBedingungen = new List<string>();
                    foreach (var item in suchControlMain.Suche)
                    {
                        if (string.IsNullOrWhiteSpace(item.LinkControl.Text))
                        {
                            if (!string.IsNullOrEmpty(item.SpalteControl.Text))
                            {
                                switch (item.SpalteControl.Text)
                                {
                                    case "AuftragNummer":
                                        if (!string.IsNullOrWhiteSpace(item.ValueControl.Text))
                                        {
                                            suchBedingungen.Add("AuftragNummer == \"" + item.ValueControl.Text + "\"");
                                        }
                                        break;
                                    case "Name":
                                        if (!string.IsNullOrWhiteSpace(item.ValueControl.Text))
                                        {
                                            suchBedingungen.Add("Name == \"" + item.ValueControl.Text + "\"");
                                        }
                                        break;
                                    case "Eingang":
                                        suchBedingungen.Add("Eingang >= DateTime("
                                            + item.AnfangControl.Value.Year + ","
                                            + item.AnfangControl.Value.Month + ","
                                            + item.AnfangControl.Value.Day + ")"
                                            + " && Eingang <= DateTime("
                                            + item.EndeControl.Value.Year + ","
                                            + item.EndeControl.Value.Month + ","
                                            + item.EndeControl.Value.Day + ")");
                                        break;
                                    case "Erteilt":
                                        suchBedingungen.Add("Erteilt >= DateTime("
                                            + item.AnfangControl.Value.Year + ","
                                            + item.AnfangControl.Value.Month + ","
                                            + item.AnfangControl.Value.Day + ")"
                                            + " && Erteilt <= DateTime("
                                            + item.EndeControl.Value.Year + ","
                                            + item.EndeControl.Value.Month + ","
                                            + item.EndeControl.Value.Day + ")");
                                        break;
                                    case "Abgerechnet":
                                        suchBedingungen.Add("Abgerechnet != " + item.AbgerechnetControl.Checked);
                                        break;
                                    case "Erledigt":
                                        suchBedingungen.Add("Erledigt == " + item.ErledigtControl.Checked);
                                        break;
                                }
                            }
                        }
                        else if (item.LinkControl.Text == "und")
                        {
                            if (!string.IsNullOrEmpty(item.SpalteControl.Text))
                            {
                                switch (item.SpalteControl.Text)
                                {
                                    case "AuftragNummer":
                                        if (!string.IsNullOrWhiteSpace(item.ValueControl.Text))
                                        {
                                            suchBedingungen.Add(" && AuftragNummer == \"" + item.ValueControl.Text + "\"");
                                        }
                                        break;
                                    case "Name":
                                        if (!string.IsNullOrWhiteSpace(item.ValueControl.Text))
                                        {
                                            suchBedingungen.Add(" && Name == \"" + item.ValueControl.Text + "\"");
                                        }
                                        break;
                                    case "Eingang":
                                        suchBedingungen.Add(" && Eingang >= DateTime("
                                            + item.AnfangControl.Value.Year + ","
                                            + item.AnfangControl.Value.Month + ","
                                            + item.AnfangControl.Value.Day + ")"
                                            + " && Eingang <= DateTime("
                                            + item.EndeControl.Value.Year + ","
                                            + item.EndeControl.Value.Month + ","
                                            + item.EndeControl.Value.Day + ")");
                                        break;
                                    case "Erteilt":
                                        suchBedingungen.Add(" && Erteilt >= DateTime("
                                            + item.AnfangControl.Value.Year + ","
                                            + item.AnfangControl.Value.Month + ","
                                            + item.AnfangControl.Value.Day + ")"
                                            + " && Erteilt <= DateTime("
                                            + item.EndeControl.Value.Year + ","
                                            + item.EndeControl.Value.Month + ","
                                            + item.EndeControl.Value.Day + ")");
                                        break;
                                    case "Abgerechnet":
                                        suchBedingungen.Add(" && Abgerechnet != " + item.AbgerechnetControl.Checked);
                                        break;
                                    case "Erledigt":
                                        suchBedingungen.Add(" && Erledigt == " + item.ErledigtControl.Checked);
                                        break;
                                }
                            }
                        }
                        else if (!string.IsNullOrEmpty(item.SpalteControl.Text))
                        {
                            switch (item.SpalteControl.Text)
                            {
                                case "AuftragNummer":
                                    if (!string.IsNullOrWhiteSpace(item.ValueControl.Text))
                                    {
                                        suchBedingungen.Add(" || AuftragNummer == \"" + item.ValueControl.Text + "\"");
                                    }
                                    break;
                                case "Name":
                                    if (!string.IsNullOrWhiteSpace(item.ValueControl.Text))
                                    {
                                        suchBedingungen.Add(" || Name == \"" + item.ValueControl.Text + "\"");
                                    }
                                    break;
                                case "Eingang":
                                    suchBedingungen.Add(" || (Eingang >= DateTime("
                                        + item.AnfangControl.Value.Year + ","
                                        + item.AnfangControl.Value.Month + ","
                                        + item.AnfangControl.Value.Day + ")"
                                        + " && Eingang <= DateTime("
                                        + item.EndeControl.Value.Year + ","
                                        + item.EndeControl.Value.Month + ","
                                        + item.EndeControl.Value.Day + ")");
                                    break;
                                case "Erteilt":
                                    suchBedingungen.Add(" || (Erteilt >= DateTime("
                                        + item.AnfangControl.Value.Year + ","
                                        + item.AnfangControl.Value.Month + ","
                                        + item.AnfangControl.Value.Day + ")"
                                        + " && Erteilt <= DateTime("
                                        + item.EndeControl.Value.Year + ","
                                        + item.EndeControl.Value.Month + ","
                                        + item.EndeControl.Value.Day + ")");
                                    break;
                                case "Abgerechnet":
                                    suchBedingungen.Add(" || Abgerechnet != " + item.AbgerechnetControl.Checked);
                                    break;
                                case "Erledigt":
                                    suchBedingungen.Add(" || Erledigt == " + item.ErledigtControl.Checked);
                                    break;
                            }
                        }
                    }
                    string finalSuche = "";
                    foreach (var inhalt in suchBedingungen)
                    {
                        finalSuche += inhalt;
                    }
                    auft = auft.Where(finalSuche).ToList();

                    dgvMain.DataSource = auft;
                    dgvMain.Columns["auftragID"].Visible = false;
                    dgvMain.Columns["Name"].HeaderText = "Kundenname";
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        private void butImport_Click(object sender, EventArgs e)
        {
            ExportView importV = new ExportView("Import");
            if (importV.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (importV.ExportArt == ExportView.Art.Auftrag)
                    {
                        OpenFileDialog dlgImport = new OpenFileDialog();
                        if (importV.DateiFormat == ExportView.Format.CSV)
                        {
                            dlgImport.Filter = "CSV|*.csv|All Files|*.*";
                            dlgImport.DefaultExt = "*.csv*";
                            CSVConfig cSVConfig = new CSVConfig();
                            if (dlgImport.ShowDialog() == DialogResult.OK)
                            {
                                if (cSVConfig.ShowDialog() == DialogResult.OK)
                                {
                                    AustauschCSV austauschCSV = new AustauschCSV(cSVConfig.Typen.TrennerDezimal, cSVConfig.Typen.TrennerDaten);
                                    var aufListe = austauschCSV.AuftragLesen(dlgImport.FileName);
                                    ImportBestaetigenView import = new ImportBestaetigenView(aufListe);
                                    if (import.ShowDialog() == DialogResult.OK)
                                    {
                                        foreach (Auftrag auf in aufListe)
                                        {
                                            _handler.AuftragAnlegen(auf);
                                        }
                                        TabelleNeu();
                                        TreeViewNeu();
                                    }
                                }
                            }
                        }
                        else if (importV.DateiFormat == ExportView.Format.XML)
                        {
                            dlgImport.Filter = "XML|*.xml|All Files|*.*";
                            dlgImport.DefaultExt = "*.xml*";
                            if (dlgImport.ShowDialog() == DialogResult.OK)
                            {
                                AustauschXML austauschXML = new AustauschXML();
                                var aufListe = austauschXML.AuftragLesen(dlgImport.FileName);
                                ImportBestaetigenView import = new ImportBestaetigenView(aufListe);
                                if (import.ShowDialog() == DialogResult.OK)
                                {
                                    foreach (Auftrag auf in aufListe)
                                    {
                                        _handler.AuftragAnlegen(auf);
                                    }
                                    TabelleNeu();
                                    TreeViewNeu();
                                }
                            }
                        }
                        else if (importV.DateiFormat == ExportView.Format.JSON)
                        {
                            dlgImport.Filter = "JSON|*.json|All Files|*.*";
                            dlgImport.DefaultExt = "*.json*";
                            if (dlgImport.ShowDialog() == DialogResult.OK)
                            {
                                AustauschJSON austauschJSON = new AustauschJSON();
                                var aufListe = austauschJSON.AuftragLesen(dlgImport.FileName);
                                ImportBestaetigenView import = new ImportBestaetigenView(aufListe);
                                if (import.ShowDialog() == DialogResult.OK)
                                {
                                    foreach (Auftrag auf in aufListe)
                                    {
                                        _handler.AuftragAnlegen(auf);
                                    }
                                    TabelleNeu();
                                    TreeViewNeu();
                                }
                            }
                        }
                    }
                    else if (importV.ExportArt == ExportView.Art.Kunde)
                    {
                        OpenFileDialog dlgImport = new OpenFileDialog();
                        if (importV.DateiFormat == ExportView.Format.CSV)
                        {
                            dlgImport.Filter = "CSV|*.csv|All Files|*.*";
                            dlgImport.DefaultExt = "*.csv*";
                            CSVConfig cSVConfig = new CSVConfig();
                            if (dlgImport.ShowDialog() == DialogResult.OK)
                            {
                                if (cSVConfig.ShowDialog() == DialogResult.OK)
                                {
                                    AustauschCSV austauschCSV = new AustauschCSV(cSVConfig.Typen.TrennerDezimal, cSVConfig.Typen.TrennerDaten);
                                    var kunListe = austauschCSV.KundeLesen(dlgImport.FileName);
                                    ImportBestaetigenView import = new ImportBestaetigenView(kunListe);
                                    if (import.ShowDialog() == DialogResult.OK)
                                    {
                                        foreach (Kunde kun in kunListe)
                                        {
                                            _handler.KundeAnlegen(kun);
                                        }
                                        TreeViewNeu();
                                    }
                                }
                            }
                        }
                        else if (importV.DateiFormat == ExportView.Format.XML)
                        {
                            dlgImport.Filter = "XML|*.xml|All Files|*.*";
                            dlgImport.DefaultExt = "*.xml*";
                            if (dlgImport.ShowDialog() == DialogResult.OK)
                            {
                                AustauschXML austauschXML = new AustauschXML();
                                var kunListe = austauschXML.KundeLesen(dlgImport.FileName);
                                ImportBestaetigenView import = new ImportBestaetigenView(kunListe);
                                if (import.ShowDialog() == DialogResult.OK)
                                {
                                    foreach (Kunde kun in kunListe)
                                    {
                                        _handler.KundeAnlegen(kun);
                                    }
                                    TreeViewNeu();
                                }
                            }
                        }
                        else if (importV.DateiFormat == ExportView.Format.JSON)
                        {
                            dlgImport.Filter = "JSON|*.json|All Files|*.*";
                            dlgImport.DefaultExt = "*.json*";
                            if (dlgImport.ShowDialog() == DialogResult.OK)
                            {
                                AustauschJSON austauschJSON = new AustauschJSON();
                                var kunListe = austauschJSON.KundeLesen(dlgImport.FileName);
                                ImportBestaetigenView import = new ImportBestaetigenView(kunListe);
                                if (import.ShowDialog() == DialogResult.OK)
                                {
                                    foreach (Kunde kun in kunListe)
                                    {
                                        _handler.KundeAnlegen(kun);
                                    }
                                    TreeViewNeu();
                                }
                            }
                        }
                    }
                    else if (importV.ExportArt == ExportView.Art.Mitarbeiter)
                    {
                        OpenFileDialog dlgImport = new OpenFileDialog();
                        if (importV.DateiFormat == ExportView.Format.CSV)
                        {
                            dlgImport.Filter = "CSV|*.csv|All Files|*.*";
                            dlgImport.DefaultExt = "*.csv*";
                            CSVConfig cSVConfig = new CSVConfig();
                            if (dlgImport.ShowDialog() == DialogResult.OK)
                            {
                                if (cSVConfig.ShowDialog() == DialogResult.OK)
                                {
                                    AustauschCSV austauschCSV = new AustauschCSV(cSVConfig.Typen.TrennerDezimal, cSVConfig.Typen.TrennerDaten);
                                    var mitListe = austauschCSV.MitarbeiterLesen(dlgImport.FileName);
                                    ImportBestaetigenView import = new ImportBestaetigenView(mitListe);
                                    if (import.ShowDialog() == DialogResult.OK)
                                    {
                                        foreach (Mitarbeiter mit in mitListe)
                                        {
                                            _handler.MitarbeiterAnlegen(mit);
                                        }
                                        TreeViewNeu();
                                    }
                                }
                            }
                        }
                        else if (importV.DateiFormat == ExportView.Format.XML)
                        {
                            dlgImport.Filter = "XML|*.xml|All Files|*.*";
                            dlgImport.DefaultExt = "*.xml*";
                            if (dlgImport.ShowDialog() == DialogResult.OK)
                            {
                                AustauschXML austauschXML = new AustauschXML();
                                var mitListe = austauschXML.MitarbeiterLesen(dlgImport.FileName);
                                ImportBestaetigenView import = new ImportBestaetigenView(mitListe);
                                if (import.ShowDialog() == DialogResult.OK)
                                {
                                    foreach (Mitarbeiter mit in mitListe)
                                    {
                                        _handler.MitarbeiterAnlegen(mit);
                                    }
                                    TreeViewNeu();
                                }
                            }
                        }
                        else if (importV.DateiFormat == ExportView.Format.JSON)
                        {
                            dlgImport.Filter = "JSON|*.json|All Files|*.*";
                            dlgImport.DefaultExt = "*.json*";
                            if (dlgImport.ShowDialog() == DialogResult.OK)
                            {
                                AustauschJSON austauschJSON = new AustauschJSON();
                                var mitListe = austauschJSON.MitarbeiterLesen(dlgImport.FileName);
                                ImportBestaetigenView import = new ImportBestaetigenView(mitListe);
                                if (import.ShowDialog() == DialogResult.OK)
                                {
                                    foreach (Mitarbeiter mit in mitListe)
                                    {
                                        _handler.MitarbeiterAnlegen(mit);
                                    }
                                    TreeViewNeu();
                                }
                            }
                        }
                    }
                    else if (importV.ExportArt == ExportView.Art.Taetigkeit)
                    {
                        OpenFileDialog dlgImport = new OpenFileDialog();
                        if (importV.DateiFormat == ExportView.Format.CSV)
                        {
                            dlgImport.Filter = "CSV|*.csv|All Files|*.*";
                            dlgImport.DefaultExt = "*.csv*";
                            CSVConfig cSVConfig = new CSVConfig();
                            if (dlgImport.ShowDialog() == DialogResult.OK)
                            {
                                if (cSVConfig.ShowDialog() == DialogResult.OK)
                                {
                                    AustauschCSV austauschCSV = new AustauschCSV(cSVConfig.Typen.TrennerDezimal, cSVConfig.Typen.TrennerDaten);
                                    var tatListe = austauschCSV.TaetigkeitLesen(dlgImport.FileName);
                                    ImportBestaetigenView import = new ImportBestaetigenView(tatListe);
                                    if (import.ShowDialog() == DialogResult.OK)
                                    {
                                        foreach (Taetigkeit tat in tatListe)
                                        {
                                            _handler.TaetigkeitAnlegen(tat);
                                        }
                                        TreeViewNeu();
                                    }
                                }
                            }
                        }
                        else if (importV.DateiFormat == ExportView.Format.XML)
                        {
                            dlgImport.Filter = "XML|*.xml|All Files|*.*";
                            dlgImport.DefaultExt = "*.xml*";
                            if (dlgImport.ShowDialog() == DialogResult.OK)
                            {
                                AustauschXML austauschXML = new AustauschXML();
                                var tatListe = austauschXML.TaetigkeitLesen(dlgImport.FileName);
                                ImportBestaetigenView import = new ImportBestaetigenView(tatListe);
                                if(import.ShowDialog() == DialogResult.OK)
                                {
                                    foreach (Taetigkeit tat in tatListe)
                                    {
                                        _handler.TaetigkeitAnlegen(tat);
                                    }
                                    TreeViewNeu();
                                }
                            }
                        }
                        else if (importV.DateiFormat == ExportView.Format.JSON)
                        {
                            dlgImport.Filter = "JSON|*.json|All Files|*.*";
                            dlgImport.DefaultExt = "*.json*";
                            if (dlgImport.ShowDialog() == DialogResult.OK)
                            {
                                AustauschJSON austauschJSON = new AustauschJSON();
                                var tatListe = austauschJSON.TaetigkeitLesen(dlgImport.FileName);
                                ImportBestaetigenView import = new ImportBestaetigenView(tatListe);
                                if (import.ShowDialog() == DialogResult.OK)
                                {
                                    foreach (Taetigkeit tat in tatListe)
                                    {
                                        _handler.TaetigkeitAnlegen(tat);
                                    }
                                    TreeViewNeu();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorHandler.ErrorHandle(ex);
                }
            }
        }
    }
}
