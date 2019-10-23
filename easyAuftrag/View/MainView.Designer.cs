
namespace easyAuftrag.View
{
    partial class MainView
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Kunden");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Mitarbeiter");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Aufträge");
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateiExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateiImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.druckenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.auftragToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stundennachweisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ansichtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neuerKundeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.neuerMitarbeiterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.neuerAuftragToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extrasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laenderKonfigurierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.überToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfethemenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cxtMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMIneu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.TSMIbearbeiten = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.TSMIloeschen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.butExport = new System.Windows.Forms.ToolStripButton();
            this.butImport = new System.Windows.Forms.ToolStripButton();
            this.butAuftragZettel = new System.Windows.Forms.ToolStripButton();
            this.butStundenZettel = new System.Windows.Forms.ToolStripButton();
            this.butAuftrag = new System.Windows.Forms.ToolStripButton();
            this.butKunde = new System.Windows.Forms.ToolStripButton();
            this.butMitarbeiter = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssLabText = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssLabNummer = new System.Windows.Forms.ToolStripStatusLabel();
            this.ctxTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripNeu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBearbeiten = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLoeschen = new System.Windows.Forms.ToolStripMenuItem();
            this.splitConTree = new System.Windows.Forms.SplitContainer();
            this.tvMain = new System.Windows.Forms.TreeView();
            this.splitConSuche = new System.Windows.Forms.SplitContainer();
            this.suchControlMain = new easyAuftrag.View.SuchControl();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.cxtMain.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.ctxTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitConTree)).BeginInit();
            this.splitConTree.Panel1.SuspendLayout();
            this.splitConTree.Panel2.SuspendLayout();
            this.splitConTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitConSuche)).BeginInit();
            this.splitConSuche.Panel1.SuspendLayout();
            this.splitConSuche.Panel2.SuspendLayout();
            this.splitConSuche.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.ansichtToolStripMenuItem,
            this.bearbeitenToolStripMenuItem,
            this.extrasToolStripMenuItem,
            this.hilfeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiExportToolStripMenuItem,
            this.dateiImportToolStripMenuItem,
            this.toolStripMenuItem4,
            this.druckenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // dateiExportToolStripMenuItem
            // 
            this.dateiExportToolStripMenuItem.Name = "dateiExportToolStripMenuItem";
            this.dateiExportToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.dateiExportToolStripMenuItem.Text = "Datei Export";
            this.dateiExportToolStripMenuItem.Click += new System.EventHandler(this.DateiExportToolStripMenuItem_Click);
            // 
            // dateiImportToolStripMenuItem
            // 
            this.dateiImportToolStripMenuItem.Name = "dateiImportToolStripMenuItem";
            this.dateiImportToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.dateiImportToolStripMenuItem.Text = "Datei Import";
            this.dateiImportToolStripMenuItem.Click += new System.EventHandler(this.DateiImportToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(137, 6);
            // 
            // druckenToolStripMenuItem
            // 
            this.druckenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.auftragToolStripMenuItem,
            this.stundennachweisToolStripMenuItem});
            this.druckenToolStripMenuItem.Name = "druckenToolStripMenuItem";
            this.druckenToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.druckenToolStripMenuItem.Text = "Drucken";
            // 
            // auftragToolStripMenuItem
            // 
            this.auftragToolStripMenuItem.Name = "auftragToolStripMenuItem";
            this.auftragToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.auftragToolStripMenuItem.Text = "Auftrag";
            this.auftragToolStripMenuItem.Click += new System.EventHandler(this.AuftragToolStripMenuItem_Click);
            // 
            // stundennachweisToolStripMenuItem
            // 
            this.stundennachweisToolStripMenuItem.Name = "stundennachweisToolStripMenuItem";
            this.stundennachweisToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.stundennachweisToolStripMenuItem.Text = "Stundennachweis";
            this.stundennachweisToolStripMenuItem.Click += new System.EventHandler(this.StundennachweisToolStripMenuItem_Click);
            // 
            // ansichtToolStripMenuItem
            // 
            this.ansichtToolStripMenuItem.Name = "ansichtToolStripMenuItem";
            this.ansichtToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.ansichtToolStripMenuItem.Text = "Ansicht";
            // 
            // bearbeitenToolStripMenuItem
            // 
            this.bearbeitenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neuerKundeToolStripMenuItem,
            this.toolStripMenuItem2,
            this.neuerMitarbeiterToolStripMenuItem,
            this.toolStripMenuItem3,
            this.neuerAuftragToolStripMenuItem});
            this.bearbeitenToolStripMenuItem.Name = "bearbeitenToolStripMenuItem";
            this.bearbeitenToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.bearbeitenToolStripMenuItem.Text = "Bearbeiten";
            // 
            // neuerKundeToolStripMenuItem
            // 
            this.neuerKundeToolStripMenuItem.Name = "neuerKundeToolStripMenuItem";
            this.neuerKundeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.neuerKundeToolStripMenuItem.Text = "Neuer Kunde";
            this.neuerKundeToolStripMenuItem.Click += new System.EventHandler(this.NeuerKundeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // neuerMitarbeiterToolStripMenuItem
            // 
            this.neuerMitarbeiterToolStripMenuItem.Name = "neuerMitarbeiterToolStripMenuItem";
            this.neuerMitarbeiterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.neuerMitarbeiterToolStripMenuItem.Text = "Neuer Mitarbeiter";
            this.neuerMitarbeiterToolStripMenuItem.Click += new System.EventHandler(this.NeuerMitarbeiterToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(177, 6);
            // 
            // neuerAuftragToolStripMenuItem
            // 
            this.neuerAuftragToolStripMenuItem.Name = "neuerAuftragToolStripMenuItem";
            this.neuerAuftragToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.neuerAuftragToolStripMenuItem.Text = "Neuer Auftrag";
            this.neuerAuftragToolStripMenuItem.Click += new System.EventHandler(this.NeuerAuftragToolStripMenuItem_Click);
            // 
            // extrasToolStripMenuItem
            // 
            this.extrasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.einstellungenToolStripMenuItem,
            this.laenderKonfigurierenToolStripMenuItem});
            this.extrasToolStripMenuItem.Name = "extrasToolStripMenuItem";
            this.extrasToolStripMenuItem.Size = new System.Drawing.Size(50, 24);
            this.extrasToolStripMenuItem.Text = "Extras";
            // 
            // einstellungenToolStripMenuItem
            // 
            this.einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
            this.einstellungenToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.einstellungenToolStripMenuItem.Text = "Einstellungen";
            this.einstellungenToolStripMenuItem.Click += new System.EventHandler(this.EinstellungenToolStripMenuItem_Click);
            // 
            // laenderKonfigurierenToolStripMenuItem
            // 
            this.laenderKonfigurierenToolStripMenuItem.Name = "laenderKonfigurierenToolStripMenuItem";
            this.laenderKonfigurierenToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.laenderKonfigurierenToolStripMenuItem.Text = "Länder konfigurieren";
            this.laenderKonfigurierenToolStripMenuItem.Click += new System.EventHandler(this.LaenderKonfigurierenToolStripMenuItem_Click);
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.überToolStripMenuItem,
            this.hilfethemenToolStripMenuItem});
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.hilfeToolStripMenuItem.Text = "Hilfe";
            // 
            // überToolStripMenuItem
            // 
            this.überToolStripMenuItem.Name = "überToolStripMenuItem";
            this.überToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.überToolStripMenuItem.Text = "Info zu easyAuftrag";
            this.überToolStripMenuItem.Click += new System.EventHandler(this.InfoToolStripMenuItem_Click);
            // 
            // hilfethemenToolStripMenuItem
            // 
            this.hilfethemenToolStripMenuItem.Name = "hilfethemenToolStripMenuItem";
            this.hilfethemenToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.hilfethemenToolStripMenuItem.Text = "Hilfe anzeigen";
            this.hilfethemenToolStripMenuItem.Click += new System.EventHandler(this.HilfeanzeigenToolStripMenuItem_Click);
            // 
            // cxtMain
            // 
            this.cxtMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIneu,
            this.toolStripMenuItem1,
            this.TSMIbearbeiten,
            this.toolStripSeparator3,
            this.TSMIloeschen});
            this.cxtMain.Name = "cxtMain";
            this.cxtMain.Size = new System.Drawing.Size(131, 82);
            // 
            // TSMIneu
            // 
            this.TSMIneu.Name = "TSMIneu";
            this.TSMIneu.Size = new System.Drawing.Size(130, 22);
            this.TSMIneu.Text = "Neu";
            this.TSMIneu.Click += new System.EventHandler(this.TSMIneu_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(127, 6);
            // 
            // TSMIbearbeiten
            // 
            this.TSMIbearbeiten.Name = "TSMIbearbeiten";
            this.TSMIbearbeiten.Size = new System.Drawing.Size(130, 22);
            this.TSMIbearbeiten.Text = "Bearbeiten";
            this.TSMIbearbeiten.Click += new System.EventHandler(this.TSMIbearbeiten_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(127, 6);
            // 
            // TSMIloeschen
            // 
            this.TSMIloeschen.Name = "TSMIloeschen";
            this.TSMIloeschen.Size = new System.Drawing.Size(130, 22);
            this.TSMIloeschen.Text = "Löschen";
            this.TSMIloeschen.Click += new System.EventHandler(this.TSMIloeschen_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.butExport,
            this.butImport,
            this.butAuftragZettel,
            this.butStundenZettel,
            this.butAuftrag,
            this.butKunde,
            this.butMitarbeiter});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(784, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // butExport
            // 
            this.butExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butExport.Image = ((System.Drawing.Image)(resources.GetObject("butExport.Image")));
            this.butExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butExport.Name = "butExport";
            this.butExport.Size = new System.Drawing.Size(23, 22);
            this.butExport.Text = "Datei Export";
            this.butExport.Click += new System.EventHandler(this.ButExport_Click);
            // 
            // butImport
            // 
            this.butImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butImport.Image = ((System.Drawing.Image)(resources.GetObject("butImport.Image")));
            this.butImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butImport.Name = "butImport";
            this.butImport.Size = new System.Drawing.Size(23, 22);
            this.butImport.Text = "Datei Import";
            this.butImport.Click += new System.EventHandler(this.ButImport_Click);
            // 
            // butAuftragZettel
            // 
            this.butAuftragZettel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butAuftragZettel.Image = ((System.Drawing.Image)(resources.GetObject("butAuftragZettel.Image")));
            this.butAuftragZettel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butAuftragZettel.Name = "butAuftragZettel";
            this.butAuftragZettel.Size = new System.Drawing.Size(23, 22);
            this.butAuftragZettel.Text = "Auftrag drucken";
            this.butAuftragZettel.Click += new System.EventHandler(this.ButAuftragZettel_Click);
            // 
            // butStundenZettel
            // 
            this.butStundenZettel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butStundenZettel.Image = ((System.Drawing.Image)(resources.GetObject("butStundenZettel.Image")));
            this.butStundenZettel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butStundenZettel.Name = "butStundenZettel";
            this.butStundenZettel.Size = new System.Drawing.Size(23, 22);
            this.butStundenZettel.Text = "Stundennachweis drucken";
            this.butStundenZettel.Click += new System.EventHandler(this.ButStundenZettel_Click);
            // 
            // butAuftrag
            // 
            this.butAuftrag.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butAuftrag.Image = ((System.Drawing.Image)(resources.GetObject("butAuftrag.Image")));
            this.butAuftrag.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butAuftrag.Name = "butAuftrag";
            this.butAuftrag.Size = new System.Drawing.Size(23, 22);
            this.butAuftrag.Text = "Neuer Auftrag";
            this.butAuftrag.Click += new System.EventHandler(this.ButAuftrag_Click);
            // 
            // butKunde
            // 
            this.butKunde.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butKunde.Image = ((System.Drawing.Image)(resources.GetObject("butKunde.Image")));
            this.butKunde.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butKunde.Name = "butKunde";
            this.butKunde.Size = new System.Drawing.Size(23, 22);
            this.butKunde.Text = "Neuer Kunde";
            this.butKunde.Click += new System.EventHandler(this.ButKunde_Click);
            // 
            // butMitarbeiter
            // 
            this.butMitarbeiter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butMitarbeiter.Image = ((System.Drawing.Image)(resources.GetObject("butMitarbeiter.Image")));
            this.butMitarbeiter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butMitarbeiter.Name = "butMitarbeiter";
            this.butMitarbeiter.Size = new System.Drawing.Size(23, 22);
            this.butMitarbeiter.Text = "Neuer Mitarbeiter";
            this.butMitarbeiter.Click += new System.EventHandler(this.ButMitarbeiter_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssLabText,
            this.tssLabNummer});
            this.statusStrip1.Location = new System.Drawing.Point(0, 502);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssLabText
            // 
            this.tssLabText.Name = "tssLabText";
            this.tssLabText.Size = new System.Drawing.Size(212, 17);
            this.tssLabText.Text = "Anzahl erledigt und nicht abgerechnet:";
            // 
            // tssLabNummer
            // 
            this.tssLabNummer.Name = "tssLabNummer";
            this.tssLabNummer.Size = new System.Drawing.Size(0, 17);
            // 
            // ctxTree
            // 
            this.ctxTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripNeu,
            this.toolStripSeparator1,
            this.toolStripBearbeiten,
            this.toolStripSeparator2,
            this.toolStripLoeschen});
            this.ctxTree.Name = "ctxTree";
            this.ctxTree.Size = new System.Drawing.Size(131, 82);
            // 
            // toolStripNeu
            // 
            this.toolStripNeu.Name = "toolStripNeu";
            this.toolStripNeu.Size = new System.Drawing.Size(130, 22);
            this.toolStripNeu.Text = "Neu";
            this.toolStripNeu.Click += new System.EventHandler(this.ToolStripNeu_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(127, 6);
            // 
            // toolStripBearbeiten
            // 
            this.toolStripBearbeiten.Name = "toolStripBearbeiten";
            this.toolStripBearbeiten.Size = new System.Drawing.Size(130, 22);
            this.toolStripBearbeiten.Text = "Bearbeiten";
            this.toolStripBearbeiten.Click += new System.EventHandler(this.ToolStripBearbeiten_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(127, 6);
            // 
            // toolStripLoeschen
            // 
            this.toolStripLoeschen.Name = "toolStripLoeschen";
            this.toolStripLoeschen.Size = new System.Drawing.Size(130, 22);
            this.toolStripLoeschen.Text = "Löschen";
            this.toolStripLoeschen.Click += new System.EventHandler(this.ToolStripLoeschen_Click);
            // 
            // splitConTree
            // 
            this.splitConTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitConTree.Location = new System.Drawing.Point(0, 49);
            this.splitConTree.Name = "splitConTree";
            // 
            // splitConTree.Panel1
            // 
            this.splitConTree.Panel1.Controls.Add(this.tvMain);
            // 
            // splitConTree.Panel2
            // 
            this.splitConTree.Panel2.Controls.Add(this.splitConSuche);
            this.splitConTree.Size = new System.Drawing.Size(784, 453);
            this.splitConTree.SplitterDistance = 150;
            this.splitConTree.TabIndex = 12;
            // 
            // tvMain
            // 
            this.tvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvMain.Location = new System.Drawing.Point(0, 0);
            this.tvMain.Name = "tvMain";
            treeNode4.Name = "Kunden";
            treeNode4.Tag = "Kunden";
            treeNode4.Text = "Kunden";
            treeNode4.ToolTipText = "Doppelklick auf einen Kunden zum Bearbeiten";
            treeNode5.Name = "Mitarbeiter";
            treeNode5.Tag = "Mitarbeiter";
            treeNode5.Text = "Mitarbeiter";
            treeNode5.ToolTipText = "Doppelklick auf einen Mitarbeiter zum Bearbeiten";
            treeNode6.Name = "Auftraege";
            treeNode6.Tag = "Auftraege";
            treeNode6.Text = "Aufträge";
            treeNode6.ToolTipText = "Doppelklick auf einen Auftrag zum Bearbeiten";
            this.tvMain.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode6});
            this.tvMain.Size = new System.Drawing.Size(150, 453);
            this.tvMain.TabIndex = 11;
            this.tvMain.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TvMain_NodeMouseDoubleClick);
            this.tvMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TvMain_MouseUp);
            // 
            // splitConSuche
            // 
            this.splitConSuche.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitConSuche.Location = new System.Drawing.Point(0, 0);
            this.splitConSuche.Name = "splitConSuche";
            this.splitConSuche.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitConSuche.Panel1
            // 
            this.splitConSuche.Panel1.Controls.Add(this.suchControlMain);
            // 
            // splitConSuche.Panel2
            // 
            this.splitConSuche.Panel2.Controls.Add(this.dgvMain);
            this.splitConSuche.Size = new System.Drawing.Size(630, 453);
            this.splitConSuche.SplitterDistance = 150;
            this.splitConSuche.TabIndex = 0;
            // 
            // suchControlMain
            // 
            this.suchControlMain.AutoScroll = true;
            this.suchControlMain.AutoSize = true;
            this.suchControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.suchControlMain.Location = new System.Drawing.Point(0, 0);
            this.suchControlMain.Name = "suchControlMain";
            this.suchControlMain.Size = new System.Drawing.Size(630, 150);
            this.suchControlMain.Spalten = ((System.Collections.Generic.List<string>)(resources.GetObject("suchControlMain.Spalten")));
            this.suchControlMain.TabIndex = 0;
            this.suchControlMain.SuchEvent += new System.Action(this.SuchControlMain_SuchEvent);
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Location = new System.Drawing.Point(0, 0);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(627, 299);
            this.dgvMain.TabIndex = 12;
            this.dgvMain.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvMain_CellDoubleClick);
            this.dgvMain.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvMain_RowHeaderMouseDoubleClick);
            this.dgvMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DgvMain_MouseUp);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 524);
            this.Controls.Add(this.splitConTree);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 563);
            this.Name = "MainView";
            this.Text = "easyAuftrag";
            this.Load += new System.EventHandler(this.MainView_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.cxtMain.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ctxTree.ResumeLayout(false);
            this.splitConTree.Panel1.ResumeLayout(false);
            this.splitConTree.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitConTree)).EndInit();
            this.splitConTree.ResumeLayout(false);
            this.splitConSuche.Panel1.ResumeLayout(false);
            this.splitConSuche.Panel1.PerformLayout();
            this.splitConSuche.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitConSuche)).EndInit();
            this.splitConSuche.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ansichtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bearbeitenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extrasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cxtMain;
        private System.Windows.Forms.ToolStripMenuItem TSMIneu;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem TSMIbearbeiten;
        private System.Windows.Forms.ToolStripMenuItem TSMIloeschen;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton butExport;
        private System.Windows.Forms.ToolStripButton butAuftragZettel;
        private System.Windows.Forms.ToolStripButton butAuftrag;
        private System.Windows.Forms.ToolStripButton butKunde;
        private System.Windows.Forms.ToolStripButton butMitarbeiter;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssLabText;
        private System.Windows.Forms.ToolStripStatusLabel tssLabNummer;
        private System.Windows.Forms.ContextMenuStrip ctxTree;
        private System.Windows.Forms.ToolStripMenuItem toolStripNeu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripBearbeiten;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripLoeschen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton butStundenZettel;
        private System.Windows.Forms.ToolStripButton butImport;
        private System.Windows.Forms.ToolStripMenuItem überToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dateiExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dateiImportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem einstellungenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem druckenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem auftragToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stundennachweisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hilfethemenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem laenderKonfigurierenToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitConTree;
        private System.Windows.Forms.SplitContainer splitConSuche;
        private System.Windows.Forms.TreeView tvMain;
        private System.Windows.Forms.DataGridView dgvMain;
        private SuchControl suchControlMain;
        private System.Windows.Forms.ToolStripMenuItem neuerKundeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem neuerMitarbeiterToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem neuerAuftragToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
    }
}

