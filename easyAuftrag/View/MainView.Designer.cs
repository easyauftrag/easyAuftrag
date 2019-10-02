
namespace easyAuftrag
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
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Kunden");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Mitarbeiter");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Aufträge");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ansichtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extrasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.überToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tvMain = new System.Windows.Forms.TreeView();
            this.dgvMain = new System.Windows.Forms.DataGridView();
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
            this.suchControlMain = new easyAuftrag.View.SuchControl();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.cxtMain.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.ctxTree.SuspendLayout();
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
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // ansichtToolStripMenuItem
            // 
            this.ansichtToolStripMenuItem.Name = "ansichtToolStripMenuItem";
            this.ansichtToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.ansichtToolStripMenuItem.Text = "Ansicht";
            // 
            // bearbeitenToolStripMenuItem
            // 
            this.bearbeitenToolStripMenuItem.Name = "bearbeitenToolStripMenuItem";
            this.bearbeitenToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.bearbeitenToolStripMenuItem.Text = "Bearbeiten";
            // 
            // extrasToolStripMenuItem
            // 
            this.extrasToolStripMenuItem.Name = "extrasToolStripMenuItem";
            this.extrasToolStripMenuItem.Size = new System.Drawing.Size(50, 24);
            this.extrasToolStripMenuItem.Text = "Extras";
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.überToolStripMenuItem});
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.hilfeToolStripMenuItem.Text = "Hilfe";
            // 
            // überToolStripMenuItem
            // 
            this.überToolStripMenuItem.Name = "überToolStripMenuItem";
            this.überToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.überToolStripMenuItem.Text = "Über";
            this.überToolStripMenuItem.Click += new System.EventHandler(this.überToolStripMenuItem_Click);
            // 
            // tvMain
            // 
            this.tvMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvMain.Location = new System.Drawing.Point(13, 58);
            this.tvMain.Name = "tvMain";
            treeNode4.Name = "Kunden";
            treeNode4.Tag = "Kunden";
            treeNode4.Text = "Kunden";
            treeNode5.Name = "Mitarbeiter";
            treeNode5.Tag = "Mitarbeiter";
            treeNode5.Text = "Mitarbeiter";
            treeNode6.Name = "Auftraege";
            treeNode6.Tag = "Auftraege";
            treeNode6.Text = "Aufträge";
            this.tvMain.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode6});
            this.tvMain.Size = new System.Drawing.Size(189, 441);
            this.tvMain.TabIndex = 6;
            this.tvMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TvMain_MouseUp);
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.AllowUserToOrderColumns = true;
            this.dgvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Location = new System.Drawing.Point(207, 188);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.Size = new System.Drawing.Size(565, 311);
            this.dgvMain.TabIndex = 9;
            this.dgvMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DgvMain_MouseUp);
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
            this.butExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.butExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butExport.Name = "butExport";
            this.butExport.Size = new System.Drawing.Size(75, 22);
            this.butExport.Text = "Datei Export";
            this.butExport.Click += new System.EventHandler(this.ButExport_Click);
            // 
            // butImport
            // 
            this.butImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.butImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butImport.Name = "butImport";
            this.butImport.Size = new System.Drawing.Size(77, 22);
            this.butImport.Text = "Datei Import";
            this.butImport.Click += new System.EventHandler(this.butImport_Click);
            // 
            // butAuftragZettel
            // 
            this.butAuftragZettel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.butAuftragZettel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butAuftragZettel.Name = "butAuftragZettel";
            this.butAuftragZettel.Size = new System.Drawing.Size(97, 22);
            this.butAuftragZettel.Text = "Auftrag drucken";
            this.butAuftragZettel.Click += new System.EventHandler(this.ButAuftragZettel_Click);
            // 
            // butStundenZettel
            // 
            this.butStundenZettel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.butStundenZettel.Image = ((System.Drawing.Image)(resources.GetObject("butStundenZettel.Image")));
            this.butStundenZettel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butStundenZettel.Name = "butStundenZettel";
            this.butStundenZettel.Size = new System.Drawing.Size(150, 22);
            this.butStundenZettel.Text = "Stundennachweis drucken";
            this.butStundenZettel.Click += new System.EventHandler(this.ButStundenZettel_Click);
            // 
            // butAuftrag
            // 
            this.butAuftrag.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.butAuftrag.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butAuftrag.Name = "butAuftrag";
            this.butAuftrag.Size = new System.Drawing.Size(86, 22);
            this.butAuftrag.Text = "Neuer Auftrag";
            this.butAuftrag.Click += new System.EventHandler(this.ButAuftrag_Click);
            // 
            // butKunde
            // 
            this.butKunde.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.butKunde.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butKunde.Name = "butKunde";
            this.butKunde.Size = new System.Drawing.Size(80, 22);
            this.butKunde.Text = "Neuer Kunde";
            this.butKunde.Click += new System.EventHandler(this.ButKunde_Click);
            // 
            // butMitarbeiter
            // 
            this.butMitarbeiter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.butMitarbeiter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butMitarbeiter.Name = "butMitarbeiter";
            this.butMitarbeiter.Size = new System.Drawing.Size(104, 22);
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
            // suchControlMain
            // 
            this.suchControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.suchControlMain.Location = new System.Drawing.Point(208, 52);
            this.suchControlMain.Name = "suchControlMain";
            this.suchControlMain.Size = new System.Drawing.Size(564, 130);
            this.suchControlMain.Spalten = ((System.Collections.Generic.List<string>)(resources.GetObject("suchControlMain.Spalten")));
            this.suchControlMain.TabIndex = 12;
            this.suchControlMain.SuchEvent += new System.Action(this.SuchControlMain_SuchEvent);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 524);
            this.Controls.Add(this.suchControlMain);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.tvMain);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 563);
            this.Name = "MainView";
            this.Text = "easyAuftrag";
            this.Load += new System.EventHandler(this.MainView_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.cxtMain.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ctxTree.ResumeLayout(false);
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
        private System.Windows.Forms.TreeView tvMain;
        private System.Windows.Forms.DataGridView dgvMain;
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
        private View.SuchControl suchControlMain;
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
    }
}

