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
        /// Aktion beim Laden der Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <seealso cref="EasyAuftragContext"/>
        private void MainView_Load(object sender, EventArgs e)
        {
            try
            {
                // Laden der Aufträge ins DataGridView
                TabelleNeu();
                // Laden aller Daten ins TreeView
                TreeViewNeu();
                // Liste der Spaltennamen
                List<string> lstSpalten = new List<string>();
                // Anzahl der Spalten im DataGridView
                int s = dgvMain.Columns.Count;
                for (int i = 1; i < s; i++)
                {
                    // Auslesen der Spaltennamen aus dem DataGridView
                    lstSpalten.Add(dgvMain.Columns[i].HeaderText);
                }
                // Bereitstellen der Spaltennamen in der ComboBox im SuchControl
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
                    // Laden aller aufträge
                    var auftr = (from a in db.Auftraege
                                 join k in db.Kunden on a.KundeID equals k.KundeID
                                 select new { a.AuftragID, a.AuftragNummer, k.Name, a.Eingang, a.Erteilt, a.Erledigt, a.Abgerechnet }).ToList();
                    // Herausfiltern der erledigten und nicht abgerechneten Aufträge
                    var auftraege = auftr.Where(a => a.Abgerechnet == false && a.Erledigt == true).ToList();
                    // Anzeige im Statusbalken, wieviele erledigte Aufträge noch abgerechnet werden müssen.
                    tssLabNummer.Text = auftraege.Count().ToString();
                    // Einfügen aller Aufträge ins DataGridView
                    dgvMain.DataSource = auftr;
                    // AuftragID wird später benötigt, soll aber für den User nicht sichtbar sein
                    dgvMain.Columns["auftragID"].Visible = false;
                    // Spaltenname "Name" zur besseren Erkenntlichkeit in "Kundenname" ändern
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
            // Setzen der Grundknoten
            tvMain.Nodes["Kunden"].Nodes.Clear();
            tvMain.Nodes["Mitarbeiter"].Nodes.Clear();
            tvMain.Nodes["Auftraege"].Nodes.Clear();
            try
            {
                using (var db = new EasyAuftragContext())
                {
                    // Laden aller Kunden
                    List<Kunde> kun = (from k in db.Kunden select k).ToList();
                    foreach (Kunde k in kun)
                    {
                        // Setzen des Tags
                        TreeNode nKunde = new TreeNode(k.Name)
                        {
                            Tag = "Kunde_" + k.KundeID.ToString()
                        };
                        // Hinzufügen zum TreeView
                        tvMain.Nodes["Kunden"].Nodes.Add(nKunde);
                    }
                    // Laden aller Mitarbeiter
                    List<Mitarbeiter> mit = (from m in db.Mitarbeiters select m).ToList();
                    foreach (Mitarbeiter m in mit)
                    {
                        // Setzen des Tags
                        TreeNode nMitarbeiter = new TreeNode(m.Name)
                        {
                            Tag = "Mitarbeiter_" + m.MitarbeiterID.ToString()
                        };
                        // Hinzufügen zum TreeView
                        tvMain.Nodes["Mitarbeiter"].Nodes.Add(nMitarbeiter);
                    }
                    // Laden aller Aufträge
                    List<Auftrag> auf = (from a in db.Auftraege select a).ToList();
                    foreach (Auftrag a in auf)
                    {
                        // Setzen des Tags
                        TreeNode nAuftrag = new TreeNode(a.AuftragNummer)
                        {
                            Tag = "Auftrag_" + a.AuftragID.ToString()
                        };
                        // Hinzufügen zum TreeView
                        tvMain.Nodes["Auftraege"].Nodes.Add(nAuftrag);
                        // Laden aller Tätigkeiten, die zum aktiven Auftrag gehören
                        List<Taetigkeit> tat = (from t in db.Taetigkeiten where t.AuftragID == a.AuftragID select t).ToList();
                        foreach (Taetigkeit t in tat)
                        {
                            // Setzen des Tags
                            TreeNode nTaetigkeit = new TreeNode(t.Name)
                            {
                                Tag = "Taetigkeit_" + t.TaetigkeitID.ToString()
                            };
                            // Hinzufügen zum TreeView
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
        /// Aktion beim Klick auf den "Neuer Kunde" Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButKunde_Click(object sender, EventArgs e)
        {
            try
            {
                NeuerKunde();
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }
        /// <summary>
        /// Aktion beim Klick auf den "Neuer Mitarbeiter" Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButMitarbeiter_Click(object sender, EventArgs e)
        {
            try
            {
                NeuerMitarbeiter();
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }
        /// <summary>
        /// Aktion beim Klick auf den "Neuer Auftrag" Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButAuftrag_Click(object sender, EventArgs e)
        {
            try
            {
                NeuerAuftrag();
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }
        /// <summary>
        /// Aktion beim Rechtsklick auf die <see cref="DataGridView"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Anzeigen des Kontextmenus für die DataGridView
                cxtMain.Show(dgvMain, e.X, e.Y);
            }
        }
        /// <summary>
        /// Aktion beim Klick auf "Neu" im Kontextmenu auf der <see cref="DataGridView"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TSMIneu_Click(object sender, EventArgs e)
        {
            try
            {
                NeuerAuftrag();
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }
        /// <summary>
        /// Aktion beim Klick auf "Bearbeiten" im Kontextmenu auf der <see cref="DataGridView"/>
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
                    BearbeitenAuftrag(auftragID);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }
        /// <summary>
        /// Aktion beim Klick auf "Löschen" im Kontextmenu auf der <see cref="DataGridView"/>
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
                    LoeschenAuftrag(auftragID);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }
        /// <summary>
        /// Aktion beim Klick auf den "Datei Export" Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <seealso cref="EasyAuftragContext"/>
        private void ButExport_Click(object sender, EventArgs e)
        {
            // Öffnen der "Export" Fensters
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
                        // Öffnen eines Windows Speichern Fensters
                        SaveFileDialog dlg = new SaveFileDialog();
                        if (exportV.DateiFormat == ExportView.Format.CSV)
                        {
                            dlg.Filter = "CSV|*.csv|All Files|*.*|Text File|*.txt";
                            dlg.DefaultExt = "*.csv*";

                            // Öffnen des Konfigurationsfensters für die .csv Datei
                            CSVConfig cSVConfig = new CSVConfig();
                            if (dlg.ShowDialog() == DialogResult.OK)
                            {
                                if (cSVConfig.ShowDialog() == DialogResult.OK)
                                {
                                    AustauschCSV austauschCSV = new AustauschCSV(cSVConfig.Typen.TrennerDezimal, cSVConfig.Typen.TrennerDaten);
                                    if (exportV.ExportArt == ExportView.Art.Auftrag)
                                    {
                                        // Laden aller Aufträge aus der Datenbank
                                        auftraege = (from a in db.Auftraege select a).ToList();
                                        // Schreiben der .csv Datei
                                        austauschCSV.AuftragSchreiben(dlg.FileName, auftraege);
                                    }
                                    else if (exportV.ExportArt == ExportView.Art.Kunde)
                                    {
                                        // Laden aller Kunden aus der Datenbank
                                        kunden = (from k in db.Kunden select k).ToList();
                                        // Schreiben der .csv Datei
                                        austauschCSV.KundeSchreiben(dlg.FileName, kunden);
                                    }
                                    else if (exportV.ExportArt == ExportView.Art.Mitarbeiter)
                                    {
                                        // Laden aller Mitarbeiter aus der Datenbank
                                        mitarbeiters = (from m in db.Mitarbeiters select m).ToList();
                                        // Schreiben der .csv Datei
                                        austauschCSV.MitarbeiterSchreiben(dlg.FileName, mitarbeiters);
                                    }
                                    else if (exportV.ExportArt == ExportView.Art.Taetigkeit)
                                    {
                                        // Laden aller Tätigkeiten aus der Datenbank
                                        taetigkeiten = (from t in db.Taetigkeiten select t).ToList();
                                        // Schreiben der .csv Datei
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
                                    // Laden aller Aufträge aus der Datenbank
                                    auftraege = (from a in db.Auftraege select a).ToList();
                                    // Schreiben der .xml Datei
                                    austauschXML.AuftragSchreiben(dlg.FileName, auftraege);
                                }
                                else if (exportV.ExportArt == ExportView.Art.Kunde)
                                {
                                    // Laden aller Kunden aus der Datenbank
                                    kunden = (from k in db.Kunden select k).ToList();
                                    // Schreiben der .xml Datei
                                    austauschXML.KundeSchreiben(dlg.FileName, kunden);
                                }
                                else if (exportV.ExportArt == ExportView.Art.Mitarbeiter)
                                {
                                    // Laden aller Mitarbeiter aus der Datenbank
                                    mitarbeiters = (from m in db.Mitarbeiters select m).ToList();
                                    // Schreiben der .xml Datei
                                    austauschXML.MitarbeiterSchreiben(dlg.FileName, mitarbeiters);
                                }
                                else if (exportV.ExportArt == ExportView.Art.Taetigkeit)
                                {
                                    // Laden aller Tätigkeiten aus der Datenbank
                                    taetigkeiten = (from t in db.Taetigkeiten select t).ToList();
                                    // Schreiben der .xml Datei
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
                                    // Laden aller Aufträge aus der Datenbank
                                    auftraege = (from a in db.Auftraege select a).ToList();
                                    // Schreiben der .json Datei
                                    austauschJSON.AuftragSchreiben(dlg.FileName, auftraege);
                                }
                                else if (exportV.ExportArt == ExportView.Art.Kunde)
                                {
                                    // Laden aller Kunden aus der Datenbank
                                    kunden = (from k in db.Kunden select k).ToList();
                                    // Schreiben der .json Datei
                                    austauschJSON.KundeSchreiben(dlg.FileName, kunden);
                                }
                                else if (exportV.ExportArt == ExportView.Art.Mitarbeiter)
                                {
                                    // Laden aller Mitarbeiter aus der Datenbank
                                    mitarbeiters = (from m in db.Mitarbeiters select m).ToList();
                                    // Schreiben der .json Datei
                                    austauschJSON.MitarbeiterSchreiben(dlg.FileName, mitarbeiters);
                                }
                                else if (exportV.ExportArt == ExportView.Art.Taetigkeit)
                                {
                                    // Laden aller Tätigkeiten aus der Datenbank
                                    taetigkeiten = (from t in db.Taetigkeiten select t).ToList();
                                    // Schreiben der .json Datei
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
        /// Aktion beim Klick auf den "Auftrag drucken" Button
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
                        // Laden des ausgewählten Auftrags aus der Datenbank
                        Auftrag auftrag = (from a in db.Auftraege where a.AuftragID == auftragID select a).First();
                        // Laden des zugehörigen Kunden
                        Kunde kunde = (from k in db.Kunden where k.KundeID == auftrag.KundeID select k).First();
                        // Laden der zugehörigen Liste von Tätigkeiten
                        List<Taetigkeit> Tatlist = (from t in db.Taetigkeiten where t.AuftragID == auftrag.AuftragID select t).ToList();
                        List<Mitarbeiter> MitList = new List<Mitarbeiter>();
                        // Laden der Mitarbeiter, die zu den einzelnen Tätigkeiten gehören
                        foreach (Taetigkeit t in Tatlist)
                        {
                            MitList.Add((from m in db.Mitarbeiters where m.MitarbeiterID == t.MitarbeiterID select m).First());
                        }
                        // Zuweisung zum DruckDoc
                        doc.AuftragNr = auftrag.AuftragNummer;
                        doc.KundeName = kunde.Name;
                        doc.KundeAnschrift = kunde.Strasse + " " + kunde.Hausnr + ", " + kunde.PLZ + " " + kunde.Wohnort;
                        doc.KundeTelefon = kunde.TelefonNr;
                        doc.TatListe = Tatlist;
                        doc.MitList = MitList;
                        // Drucken der Auswahl
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
        /// Aktion beim Klick auf den "Stundennachweis drucken" Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButStundenZettel_Click(object sender, EventArgs e)
        {
            try
            {
                // Öffnen des "StundenView" Fensters
                StundenView stundV = new StundenView();
                if (stundV.ShowDialog() == DialogResult.OK)
                {
                    // Drucken der Angaben aus dem "StundenView" Fenster
                    Drucken druck = new Drucken();
                    druck.StundenDruck(stundV.StuDoc);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }
        /// <summary>
        /// Aktion beim Rechtsklick auf die <see cref="TreeView"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TvMain_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    // Anzeigen des Kontextmenus für die TreeView
                    if (tvMain.SelectedNode != null)
                    {
                        if (tvMain.SelectedNode.Tag.ToString().Contains("_"))
                        {
                            // "Bearbeiten" und "Löschen" Funktion, wenn es ein Unterknoten ist
                            toolStripBearbeiten.Enabled = true;
                            toolStripLoeschen.Enabled = true;
                            ctxTree.Show(tvMain, e.X, e.Y);
                        }
                        else
                        {
                            // Nur "Neu" Funktion, wenn es ein Hauptknoten ist
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
        /// Aktion beim Klick auf "Neu" im Kontextmenu auf der <see cref="TreeView"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripNeu_Click(object sender, EventArgs e)
        {
            try
            {
                // Auswahl was neu angelegt werden soll
                string[] item = tvMain.SelectedNode.Tag.ToString().Split('_');
                if (item[0].ToLower().StartsWith("kun"))
                {
                    NeuerKunde();
                }
                if (item[0].ToLower().StartsWith("mit"))
                {
                    NeuerMitarbeiter();
                }
                if (item[0].ToLower().StartsWith("auf"))
                {
                    NeuerAuftrag();
                }
                if (item[0].ToLower().StartsWith("tae"))
                {
                    // Wenn eine neue Tätigkeit angelegt werden soll, öffnet sich das Fenster des zugehörigen Auftrags
                    string[] itemParent = tvMain.SelectedNode.Parent.Tag.ToString().Split('_');
                    int auftragID = Convert.ToInt32(itemParent[1]);
                    BearbeitenAuftrag(auftragID);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }
        /// <summary>
        /// Aktion beim Klick auf "Bearbeiten" im Kontextmenu auf der <see cref="TreeView"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripBearbeiten_Click(object sender, EventArgs e)
        {
            try
            {
                // Auswahl was bearbeitet werden soll
                string[] item = tvMain.SelectedNode.Tag.ToString().Split('_');
                if (item[0].ToLower().StartsWith("kun"))
                {
                    // Öffnen des "Kunde" Fensters und Laden der Daten des Kunden in die Felder
                    KundeView kundeV = new KundeView("Kunde Bearbeiten", kunde: _handler.KundeLaden(Convert.ToInt32(item[1]), out bool success));
                    if (success == false)
                    {
                        MessageBox.Show("Kunde nicht in der Datenbank gefunden");
                    }
                    else if (kundeV.ShowDialog() == DialogResult.OK)
                    {
                        // Aktualisieren der Datenbank mit den neuen Werten des Kunden
                        if (!_handler.KundeBearbeiten(kundeV.KundenInfo, Convert.ToInt32(item[1])))
                        {
                            MessageBox.Show("Kunde nicht in der Datenbank gefunden");
                        }
                    }
                    // Auf MainView zurückgehen
                    this.BringToFront();
                    this.Activate();
                    // Aktualisieren des TreeView, um den bearbeiteten Kunden mit einzubeziehen
                    TreeViewNeu();
                }
                if (item[0].ToLower().StartsWith("mit"))
                {
                    // Öffnen des "Mitarbeiter" Fensters und Laden der Daten des Mitarbeiters in die Felder
                    MitarbeiterView mitarbeiterV = new MitarbeiterView("Mitarbeiter Bearbeiten", mitarbeiter: _handler.MitarbeiterLaden(Convert.ToInt32(item[1]), out bool success));
                    if (success == false)
                    {
                        MessageBox.Show("Mitarbeiter nicht in der Datenbank gefunden");
                    }
                    else if (mitarbeiterV.ShowDialog() == DialogResult.OK)
                    {
                        // Aktualisieren der Datenbank mit den neuen Werten des Mitarbeiters
                        if (!_handler.MitarbeiterBearbeiten(mitarbeiterV.MitarbeiterInfo, Convert.ToInt32(item[1])))
                        {
                            MessageBox.Show("Mitarbeiter nicht in der Datenbank gefunden");
                        }
                    }
                    // Auf MainView zurückgehen
                    this.BringToFront();
                    this.Activate();
                    // Aktualisieren des TreeView, um den bearbeiteten Mitarbeiter mit einzubeziehen
                    TreeViewNeu();
                }
                if (item[0].ToLower().StartsWith("auf"))
                {
                    int auftragID = Convert.ToInt32(item[1]);
                    BearbeitenAuftrag(auftragID);
                }
                if (item[0].ToLower().StartsWith("tae"))
                {
                    // Öffnen des "Tätigkeit" Fensters und Laden der Daten der Tätigkeit in die Felder
                    TaetigkeitView taetigkeitV = new TaetigkeitView("Tätigkeit Bearbeiten", taetigkeit: _handler.TaetigkeitLaden(Convert.ToInt32(item[1]), out bool success));
                    if (success == false)
                    {
                        MessageBox.Show("Tätigkeit nicht in der Datenbank gefunden");
                    }
                    else if (taetigkeitV.ShowDialog() == DialogResult.OK)
                    {
                        // Aktualisieren der Datenbank mit den neuen Werten der Tätigkeit
                        if (!_handler.TaetigkeitBearbeiten(taetigkeitV.TaetigkeitInfo, Convert.ToInt32(item[1])))
                        {
                            MessageBox.Show("Tätigkeit nicht in der Datenbank gefunden");
                        }
                    }
                    // Auf MainView zurückgehen
                    this.BringToFront();
                    this.Activate();
                    // Aktualisieren des TreeView, um die bearbeitete Tätigkeit mit einzubeziehen
                    TreeViewNeu();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }
        /// <summary>
        /// Aktion beim Klick auf "Löschen" im Kontextmenu auf der <see cref="TreeView"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripLoeschen_Click(object sender, EventArgs e)
        {
            try
            {
                // Auswahl was gelöscht werden soll
                string[] item = tvMain.SelectedNode.Tag.ToString().Split('_');
                if (item[0].ToLower().StartsWith("kun"))
                {
                    // Öffnen des "Kunde" Fensters und Laden der Daten des Kunden in die Felder
                    KundeView kundeV = new KundeView("Kunde Löschen", kunde: _handler.KundeLaden(Convert.ToInt32(item[1]), out bool success));
                    if (success == false)
                    {
                        MessageBox.Show("Kunde nicht in der Datenbank gefunden");
                    }
                    else if (kundeV.ShowDialog() == DialogResult.OK)
                    {
                        // Aktualisieren der Datenbank
                        if (!_handler.KundeLoeschen(Convert.ToInt32(item[1])))
                        {
                            MessageBox.Show("Kunde nicht in der Datenbank gefunden");
                        }
                    }
                    // Auf MainView zurückgehen
                    this.BringToFront();
                    this.Activate();
                    // Aktualisieren des TreeView, um den gelöschten Kunden mit einzubeziehen
                    TreeViewNeu();
                }
                if (item[0].ToLower().StartsWith("mit"))
                {
                    // Öffnen des "Mitarbeiter" Fensters und Laden der Daten des Mitarbeiters in die Felder
                    MitarbeiterView mitarbeiterV = new MitarbeiterView("Mitarbeiter Löschen", mitarbeiter: _handler.MitarbeiterLaden(Convert.ToInt32(item[1]), out bool success));
                    if (success == false)
                    {
                        MessageBox.Show("Mitarbeiter nicht in der Datenbank gefunden");
                    }
                    else if (mitarbeiterV.ShowDialog() == DialogResult.OK)
                    {
                        // Aktualisieren der Datenbank
                        if (!_handler.MitarbeiterLoeschen(Convert.ToInt32(item[1])))
                        {
                            MessageBox.Show("Mitarbeiter nicht in der Datenbank gefunden");
                        }
                    }
                    // Auf MainView zurückgehen
                    this.BringToFront();
                    this.Activate();
                    // Aktualisieren des TreeView, um den gelöschten Mitarbeiter mit einzubeziehen
                    TreeViewNeu();
                }
                if (item[0].ToLower().StartsWith("auf"))
                {
                    int auftragID = Convert.ToInt32(item[1]);
                    LoeschenAuftrag(auftragID);
                }
                if (item[0].ToLower().StartsWith("tae"))
                {
                    // Öffnen des "Tätigkeit" Fensters und Laden der Daten der Tätigkeit in die Felder
                    TaetigkeitView taetigkeitV = new TaetigkeitView("Tätigkeit Löschen", taetigkeit: _handler.TaetigkeitLaden(Convert.ToInt32(item[1]), out bool success));
                    if (success == false)
                    {
                        MessageBox.Show("Tätigkeit nicht in der Datenbank gefunden");
                    }
                    else if (taetigkeitV.ShowDialog() == DialogResult.OK)
                    {
                        // Aktualisieren der Datenbank
                        if (!_handler.TaetigkeitLoeschen(Convert.ToInt32(item[1])))
                        {
                            MessageBox.Show("Tätigkeit nicht in der Datenbank gefunden");
                        }
                    }
                    // Auf MainView zurückgehen
                    this.BringToFront();
                    this.Activate();
                    // Aktualisieren des TreeView, um die gelöschte Tätigkeit mit einzubeziehen
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
                    // Laden aller Aufträge aus der Datenbank
                    var auft = (from a in db.Auftraege
                                join k in db.Kunden on a.KundeID equals k.KundeID
                                select new { a.AuftragID, a.AuftragNummer, k.Name, a.Eingang, a.Erteilt, a.Erledigt, a.Abgerechnet }).ToList();
                    List<string> suchBedingungen = new List<string>();
                    // Zusammensetzen der Suchkriterien aus den verschiedenen Controls in einer Zeile
                    foreach (var item in suchControlMain.Suche)
                    {
                        if (string.IsNullOrWhiteSpace(item.LinkControl.Text))
                        {
                            if (!string.IsNullOrEmpty(item.SpalteControl.Text))
                            {
                                suchBedingungen.Add(SuchStringBuild(item, " "));
                            }
                        }
                        // Verknüpfung mit UND
                        else if (item.LinkControl.Text == "und")
                        {
                            if (!string.IsNullOrEmpty(item.SpalteControl.Text))
                            {
                                suchBedingungen.Add(SuchStringBuild(item, " && "));
                            }
                        }
                        // Verknüpfung mit ODER
                        else if (!string.IsNullOrEmpty(item.SpalteControl.Text))
                        {
                            suchBedingungen.Add(SuchStringBuild(item, " || "));
                        }
                    }
                    string finalSuche = "";
                    // Umwandeln der Suchkriterien in einen einzelnen String
                    foreach (var inhalt in suchBedingungen)
                    {
                        finalSuche += inhalt;
                    }
                    // Filtern der Aufträge nach den Suchkriterien
                    auft = auft.Where(finalSuche).ToList();
                    // Anzeige der gefilterten Aufträge im DataGridView
                    dgvMain.DataSource = auft;
                    // AuftragID wird später benötigt, soll aber für den User nicht sichtbar sein
                    dgvMain.Columns["auftragID"].Visible = false;
                    // Spaltenname "Name" zur besseren Erkenntlichkeit in "Kundenname" ändern
                    dgvMain.Columns["Name"].HeaderText = "Kundenname";
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }
        /// <summary>
        /// Methode zum Schreiben eines String aus einer Zeile im <see cref="SuchControl"/>
        /// </summary>
        /// <param name="row">Eine Zeile des <see cref="SuchControl"/></param>
        /// <param name="verknuepfung">Verknüfung UND (&&) oder ODER (||)</param>
        private string SuchStringBuild (SucheRow row, string verknuepfung)
        {
            string suchBedingungen = "";
            // Auswahl welche Spalte als Suchkriterium gilt
            switch (row.SpalteControl.Text)
            {
                case "AuftragNummer":
                    if (!string.IsNullOrWhiteSpace(row.ValueControl.Text))
                    {
                        // Zusammensetzen des SuchString
                        suchBedingungen += verknuepfung + "AuftragNummer == \"" + row.ValueControl.Text + "\"";
                    }
                    break;
                case "Name":
                    if (!string.IsNullOrWhiteSpace(row.ValueControl.Text))
                    {
                        // Zusammensetzen des SuchString
                        suchBedingungen += verknuepfung + "Name == \"" + row.ValueControl.Text + "\"";
                    }
                    break;
                case "Eingang":
                    // Zusammensetzen des SuchString
                    suchBedingungen += verknuepfung + "Eingang >= DateTime("
                        + row.AnfangControl.Value.Year + ","
                        + row.AnfangControl.Value.Month + ","
                        + row.AnfangControl.Value.Day + ")"
                        + " && Eingang <= DateTime("
                        + row.EndeControl.Value.Year + ","
                        + row.EndeControl.Value.Month + ","
                        + row.EndeControl.Value.Day + ")";
                    break;
                case "Erteilt":
                    // Zusammensetzen des SuchString
                    suchBedingungen += verknuepfung + "Erteilt >= DateTime("
                        + row.AnfangControl.Value.Year + ","
                        + row.AnfangControl.Value.Month + ","
                        + row.AnfangControl.Value.Day + ")"
                        + " && Erteilt <= DateTime("
                        + row.EndeControl.Value.Year + ","
                        + row.EndeControl.Value.Month + ","
                        + row.EndeControl.Value.Day + ")";
                    break;
                case "Abgerechnet":
                    // Zusammensetzen des SuchString
                    suchBedingungen += verknuepfung + "Abgerechnet != " + row.AbgerechnetControl.Checked;
                    break;
                case "Erledigt":
                    // Zusammensetzen des SuchString
                    suchBedingungen += verknuepfung + "Erledigt == " + row.ErledigtControl.Checked;
                    break;
            }
            // Rückgabe des SuchString
            return suchBedingungen;
        }
        /// <summary>
        /// Aktion beim Klick auf den "Datei Import" Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butImport_Click(object sender, EventArgs e)
        {
            // Öffnen des "Import" Fensters
            ExportView importV = new ExportView("Import");
            if (importV.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (importV.ExportArt == ExportView.Art.Auftrag)
                    {
                        // Öffnen eines Windows Datei öffnen Fensters
                        OpenFileDialog dlgImport = new OpenFileDialog();
                        if (importV.DateiFormat == ExportView.Format.CSV)
                        {
                            dlgImport.Filter = "CSV|*.csv|All Files|*.*";
                            dlgImport.DefaultExt = "*.csv*";
                            // Öffnen des Konfigurationsfensters für die .csv Datei
                            CSVConfig cSVConfig = new CSVConfig();
                            if (dlgImport.ShowDialog() == DialogResult.OK)
                            {
                                if (cSVConfig.ShowDialog() == DialogResult.OK)
                                {
                                    AustauschCSV austauschCSV = new AustauschCSV(cSVConfig.Typen.TrennerDezimal, cSVConfig.Typen.TrennerDaten);
                                    // Lesen der Aufträge aus der Datei
                                    var aufListe = austauschCSV.AuftragLesen(dlgImport.FileName);
                                    // Hinzufügen der Aufträge zur Datenbank
                                    ImportAuftrag(aufListe);
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
                                // Lesen der Aufträge aus der Datei
                                var aufListe = austauschXML.AuftragLesen(dlgImport.FileName);
                                // Hinzufügen der Aufträge zur Datenbank
                                ImportAuftrag(aufListe);
                            }
                        }
                        else if (importV.DateiFormat == ExportView.Format.JSON)
                        {
                            dlgImport.Filter = "JSON|*.json|All Files|*.*";
                            dlgImport.DefaultExt = "*.json*";
                            if (dlgImport.ShowDialog() == DialogResult.OK)
                            {
                                AustauschJSON austauschJSON = new AustauschJSON();
                                // Lesen der Aufträge aus der Datei
                                var aufListe = austauschJSON.AuftragLesen(dlgImport.FileName);
                                // Hinzufügen der Aufträge zur Datenbank
                                ImportAuftrag(aufListe);
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
                                    // Lesen der Kunden aus der Datei
                                    var kunListe = austauschCSV.KundeLesen(dlgImport.FileName);
                                    // Hinzufügen der Kunden zur Datenbank
                                    ImportKunde(kunListe);
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
                                // Lesen der Kunden aus der Datei
                                var kunListe = austauschXML.KundeLesen(dlgImport.FileName);
                                // Hinzufügen der Kunden zur Datenbank
                                ImportKunde(kunListe);
                            }
                        }
                        else if (importV.DateiFormat == ExportView.Format.JSON)
                        {
                            dlgImport.Filter = "JSON|*.json|All Files|*.*";
                            dlgImport.DefaultExt = "*.json*";
                            if (dlgImport.ShowDialog() == DialogResult.OK)
                            {
                                AustauschJSON austauschJSON = new AustauschJSON();
                                // Lesen der Kunden aus der Datei
                                var kunListe = austauschJSON.KundeLesen(dlgImport.FileName);
                                // Hinzufügen der Kunden zur Datenbank
                                ImportKunde(kunListe);
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
                                    // Lesen der Mitarbeiter aus der Datei
                                    var mitListe = austauschCSV.MitarbeiterLesen(dlgImport.FileName);
                                    // Hinzufügen der Mitarbeiter zur Datenbank
                                    ImportMitarbeiter(mitListe);
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
                                // Lesen der Mitarbeiter aus der Datei
                                var mitListe = austauschXML.MitarbeiterLesen(dlgImport.FileName);
                                // Hinzufügen der Mitarbeiter zur Datenbank
                                ImportMitarbeiter(mitListe);
                            }
                        }
                        else if (importV.DateiFormat == ExportView.Format.JSON)
                        {
                            dlgImport.Filter = "JSON|*.json|All Files|*.*";
                            dlgImport.DefaultExt = "*.json*";
                            if (dlgImport.ShowDialog() == DialogResult.OK)
                            {
                                AustauschJSON austauschJSON = new AustauschJSON();
                                // Lesen der Mitarbeiter aus der Datei
                                var mitListe = austauschJSON.MitarbeiterLesen(dlgImport.FileName);
                                // Hinzufügen der Mitarbeiter zur Datenbank
                                ImportMitarbeiter(mitListe);
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
                                    // Lesen der Tätigkeiten aus der Datei
                                    var tatListe = austauschCSV.TaetigkeitLesen(dlgImport.FileName);
                                    // Hinzufügen der Tätigkeiten zur Datenbank
                                    ImportTaetigkeit(tatListe);
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
                                // Lesen der Tätigkeiten aus der Datei
                                var tatListe = austauschXML.TaetigkeitLesen(dlgImport.FileName);
                                // Hinzufügen der Tätigkeiten zur Datenbank
                                ImportTaetigkeit(tatListe);
                            }
                        }
                        else if (importV.DateiFormat == ExportView.Format.JSON)
                        {
                            dlgImport.Filter = "JSON|*.json|All Files|*.*";
                            dlgImport.DefaultExt = "*.json*";
                            if (dlgImport.ShowDialog() == DialogResult.OK)
                            {
                                AustauschJSON austauschJSON = new AustauschJSON();
                                // Lesen der Tätigkeiten aus der Datei
                                var tatListe = austauschJSON.TaetigkeitLesen(dlgImport.FileName);
                                // Hinzufügen der Tätigkeiten zur Datenbank
                                ImportTaetigkeit(tatListe);
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
        /// Methode zum Anlegen eines neuen Auftrags
        /// </summary>
        private void NeuerAuftrag()
        {
            // Öffnen des "Auftrag" Fensters
            AuftragView auftragV = new AuftragView("Neuer Auftrag");
            if (auftragV.ShowDialog() == DialogResult.OK)
            {
                // Hinzufügen des Auftrags zur Datenbank
                _handler.AuftragAnlegen(auftragV.AuftragInfo);
            }
            // Auf MainView zurückgehen
            this.BringToFront();
            this.Activate();
            // Aktualisieren der DataGridView und des TreeView, um den neuen Auftrag mit einzubeziehen
            TabelleNeu();
            TreeViewNeu();
        }
        /// <summary>
        /// Methode zum Bearbeiten eines Auftrags
        /// </summary>
        /// <param name="auftragID">ID des zu bearbeitenden Auftrags</param>
        private void BearbeitenAuftrag(int auftragID)
        {
            // Öffnen des "Auftrag" Fensters und Laden der Daten des Auftrags in die Felder
            AuftragView auftragV = new AuftragView("Auftrag Bearbeiten", auftrag: _handler.AuftragLaden(auftragID, out bool success));
            if (success == false)
            {
                MessageBox.Show("Auftrag nicht in der Datenbank gefunden");
            }
            else if (auftragV.ShowDialog() == DialogResult.OK)
            {
                // Aktualisieren der Datenbank mit den neuen Werten des Auftrags
                if (!_handler.AuftragBearbeiten(auftragV.AuftragInfo, auftragID))
                {
                    MessageBox.Show("Auftrag nicht in der Datenbank gefunden");
                }
            }
            // Auf MainView zurückgehen
            this.BringToFront();
            this.Activate();
            // Aktualisieren der DataGridView und des TreeView, um den bearbeiteten Auftrag mit einzubeziehen
            TabelleNeu();
            TreeViewNeu();
        }
        /// <summary>
        /// Methode zum Löschen eines Auftrags
        /// </summary>
        /// <param name="auftragID">ID des zu löschenden Auftrags</param>
        private void LoeschenAuftrag(int auftragID)
        {
            // Öffnen des "Auftrag" Fensters und Laden der Daten des Auftrags in die Felder
            AuftragView auftragV = new AuftragView("Auftrag Löschen", auftrag: _handler.AuftragLaden(auftragID, out bool success));
            if (success == false)
            {
                MessageBox.Show("Auftrag nicht in der Datenbank gefunden");
            }
            else
            {
                if (auftragV.ShowDialog() == DialogResult.OK)
                {
                    // Löschen des Auftrags
                    if (!_handler.AuftragLoeschen(auftragID))
                    {
                        MessageBox.Show("Auftrag nicht in der Datenbank gefunden");
                    }
                }
            }// Auf MainView zurückgehen
            this.BringToFront();
            this.Activate();
            // Aktualisieren der DataGridView und des TreeView, um den gelöschten Auftrag mit einzubeziehen
            TabelleNeu();
            TreeViewNeu();
        }
        /// <summary>
        /// Methode zum Anlegen eines neuen Kunden
        /// </summary>
        private void NeuerKunde()
        {
            // Öffnen des "Kunde" Fensters
            KundeView kundeV = new KundeView("Neuer Kunde");
            if (kundeV.ShowDialog() == DialogResult.OK)
            {
                // Hinzufügen des Kunden zur Datenbank
                _handler.KundeAnlegen(kundeV.KundenInfo);
            }
            // Auf MainView zurückgehen
            this.BringToFront();
            this.Activate();
            // Aktualisieren des TreeView, um den neuen Kunden mit einzubeziehen
            TreeViewNeu();
        }
        /// <summary>
        /// Methode zum Anlegen eines neuen Mitarbeiters
        /// </summary>
        private void NeuerMitarbeiter()
        {
            // Öffnen des "Mitarbeiter" Fensters
            MitarbeiterView mitarbeiterV = new MitarbeiterView("Neuer Mitarbeiter");
            if (mitarbeiterV.ShowDialog() == DialogResult.OK)
            {
                // Hinzufügen des Mitarbeiters zur Datenbank
                _handler.MitarbeiterAnlegen(mitarbeiterV.MitarbeiterInfo);
            }
            // Auf MainView zurückgehen
            this.BringToFront();
            this.Activate();
            // Aktualisieren des TreeView, um den neuen Mitarbeiter mit einzubeziehen
            TreeViewNeu();
        }
        /// <summary>
        /// Methode zum Importieren von Aufträgen
        /// </summary>
        /// <param name="aufListe">Liste der zu importierenden Aufträge</param>
        private void ImportAuftrag(List<Auftrag> aufListe)
        {
            // Öffnen des "Import bestätigen" Fensters mit den Daten der Aufträge
            ImportBestaetigenView import = new ImportBestaetigenView(aufListe);
            if (import.ShowDialog() == DialogResult.OK)
            {
                foreach (Auftrag auf in aufListe)
                {
                    // Hinzufügen des Auftrags zur Datenbank
                    _handler.AuftragAnlegen(auf);
                }
                // Auf MainView zurückgehen
                this.BringToFront();
                this.Activate();
                // Aktualisieren der DataGridView und des TreeView, um die neuen Aufträge mit einzubeziehen
                TabelleNeu();
                TreeViewNeu();
            }
        }
        /// <summary>
        /// Methode zum Importieren von Kunden
        /// </summary>
        /// <param name="kunListe">Liste der zu importierenden Kunden</param>
        private void ImportKunde(List<Kunde> kunListe)
        {
            // Öffnen des "Import bestätigen" Fensters mit den Daten der Kunden
            ImportBestaetigenView import = new ImportBestaetigenView(kunListe);
            if (import.ShowDialog() == DialogResult.OK)
            {
                foreach (Kunde kun in kunListe)
                {
                    // Hinzufügen des Kunden zur Datenbank
                    _handler.KundeAnlegen(kun);
                }
                // Auf MainView zurückgehen
                this.BringToFront();
                this.Activate();
                // Aktualisieren des TreeView, um die neuen Kunden mit einzubeziehen
                TreeViewNeu();
            }
        }
        /// <summary>
        /// Methode zum Importieren von Mitarbeitern
        /// </summary>
        /// <param name="mitListe">Liste der zu importierenden Mitarbeiter</param>
        private void ImportMitarbeiter(List<Mitarbeiter> mitListe)
        {
            // Öffnen des "Import bestätigen" Fensters mit den Daten der Mitarbeiter
            ImportBestaetigenView import = new ImportBestaetigenView(mitListe);
            if (import.ShowDialog() == DialogResult.OK)
            {
                foreach (Mitarbeiter mit in mitListe)
                {
                    // Hinzufügen des Mitarbeiters zur Datenbank
                    _handler.MitarbeiterAnlegen(mit);
                }
                // Auf MainView zurückgehen
                this.BringToFront();
                this.Activate();
                // Aktualisieren des TreeView, um die neuen Mitarbeiter mit einzubeziehen
                TreeViewNeu();
            }
        }/// <summary>
         /// Methode zum Importieren von Tätigkeiten
         /// </summary>
         /// <param name="tatListe">Liste der zu importierenden Tätigkeiten</param>
        private void ImportTaetigkeit(List<Taetigkeit> tatListe)
        {
            // Öffnen des "Import bestätigen" Fensters mit den Daten der Tätigkeiten
            ImportBestaetigenView import = new ImportBestaetigenView(tatListe);
            if (import.ShowDialog() == DialogResult.OK)
            {
                foreach (Taetigkeit tat in tatListe)
                {
                    // Hinzufügen der Tätigkeit zur Datenbank
                    _handler.TaetigkeitAnlegen(tat);
                }
                // Auf MainView zurückgehen
                this.BringToFront();
                this.Activate();
                // Aktualisieren des TreeView, um die neuen Tätigkeiten mit einzubeziehen
                TreeViewNeu();
            }
        }
    }
}
