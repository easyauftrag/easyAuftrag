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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ansichtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extrasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tvMain = new System.Windows.Forms.TreeView();
            this.cbErledigt = new System.Windows.Forms.CheckBox();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.cxtMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.neuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.bearbeitenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.löschenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.butExport = new System.Windows.Forms.ToolStripButton();
            this.butNachweis = new System.Windows.Forms.ToolStripButton();
            this.butAuftrag = new System.Windows.Forms.ToolStripButton();
            this.butKunde = new System.Windows.Forms.ToolStripButton();
            this.butMitarbeiter = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.cxtMain.SuspendLayout();
            this.toolStrip1.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(626, 24);
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
            this.extrasToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.extrasToolStripMenuItem.Text = "Extras";
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.hilfeToolStripMenuItem.Text = "Hilfe";
            // 
            // tvMain
            // 
            this.tvMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvMain.Location = new System.Drawing.Point(13, 58);
            this.tvMain.Name = "tvMain";
            this.tvMain.Size = new System.Drawing.Size(189, 436);
            this.tvMain.TabIndex = 6;
            // 
            // cbErledigt
            // 
            this.cbErledigt.AutoSize = true;
            this.cbErledigt.Location = new System.Drawing.Point(207, 58);
            this.cbErledigt.Name = "cbErledigt";
            this.cbErledigt.Size = new System.Drawing.Size(110, 17);
            this.cbErledigt.TabIndex = 7;
            this.cbErledigt.Text = "Erledigte Aufträge";
            this.cbErledigt.UseVisualStyleBackColor = true;
            this.cbErledigt.CheckedChanged += new System.EventHandler(this.CbErledigt_CheckedChanged);
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearch.Location = new System.Drawing.Point(324, 58);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(272, 20);
            this.tbSearch.TabIndex = 8;
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
            this.dgvMain.Location = new System.Drawing.Point(207, 82);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.Size = new System.Drawing.Size(407, 412);
            this.dgvMain.TabIndex = 9;
            this.dgvMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DgvMain_MouseUp);
            // 
            // cxtMain
            // 
            this.cxtMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neuToolStripMenuItem,
            this.toolStripMenuItem1,
            this.bearbeitenToolStripMenuItem1,
            this.löschenToolStripMenuItem});
            this.cxtMain.Name = "cxtMain";
            this.cxtMain.Size = new System.Drawing.Size(131, 76);
            // 
            // neuToolStripMenuItem
            // 
            this.neuToolStripMenuItem.Name = "neuToolStripMenuItem";
            this.neuToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.neuToolStripMenuItem.Text = "Neu";
            this.neuToolStripMenuItem.Click += new System.EventHandler(this.NeuToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(127, 6);
            // 
            // bearbeitenToolStripMenuItem1
            // 
            this.bearbeitenToolStripMenuItem1.Name = "bearbeitenToolStripMenuItem1";
            this.bearbeitenToolStripMenuItem1.Size = new System.Drawing.Size(130, 22);
            this.bearbeitenToolStripMenuItem1.Text = "Bearbeiten";
            this.bearbeitenToolStripMenuItem1.Click += new System.EventHandler(this.BearbeitenToolStripMenuItem1_Click);
            // 
            // löschenToolStripMenuItem
            // 
            this.löschenToolStripMenuItem.Name = "löschenToolStripMenuItem";
            this.löschenToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.löschenToolStripMenuItem.Text = "Löschen";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.butExport,
            this.butNachweis,
            this.butAuftrag,
            this.butKunde,
            this.butMitarbeiter});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(626, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // butExport
            // 
            this.butExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.butExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butExport.Name = "butExport";
            this.butExport.Size = new System.Drawing.Size(74, 22);
            this.butExport.Text = "Datei Export";
            this.butExport.Click += new System.EventHandler(this.ButExport_Click);
            // 
            // butNachweis
            // 
            this.butNachweis.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.butNachweis.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butNachweis.Name = "butNachweis";
            this.butNachweis.Size = new System.Drawing.Size(151, 22);
            this.butNachweis.Text = "Stundennachweis Drucken";
            this.butNachweis.Click += new System.EventHandler(this.ButNachweis_Click);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 484);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(626, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 506);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.cbErledigt);
            this.Controls.Add(this.tvMain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainView";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.MainView_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.cxtMain.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
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
        private System.Windows.Forms.CheckBox cbErledigt;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.ContextMenuStrip cxtMain;
        private System.Windows.Forms.ToolStripMenuItem neuToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bearbeitenToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem löschenToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton butExport;
        private System.Windows.Forms.ToolStripButton butNachweis;
        private System.Windows.Forms.ToolStripButton butAuftrag;
        private System.Windows.Forms.ToolStripButton butKunde;
        private System.Windows.Forms.ToolStripButton butMitarbeiter;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}

