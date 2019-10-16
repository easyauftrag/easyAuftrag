namespace easyAuftrag.View
{
    partial class KundeView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KundeView));
            this.butAbbr = new System.Windows.Forms.Button();
            this.butSpeichern = new System.Windows.Forms.Button();
            this.labName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbStraße = new System.Windows.Forms.TextBox();
            this.tbPLZ = new System.Windows.Forms.TextBox();
            this.tbTelefon = new System.Windows.Forms.TextBox();
            this.labStraße = new System.Windows.Forms.Label();
            this.labPLZ = new System.Windows.Forms.Label();
            this.labTelefon = new System.Windows.Forms.Label();
            this.labHaus = new System.Windows.Forms.Label();
            this.labStadt = new System.Windows.Forms.Label();
            this.tbHaus = new System.Windows.Forms.TextBox();
            this.tbStadt = new System.Windows.Forms.TextBox();
            this.labRech = new System.Windows.Forms.Label();
            this.butAdresse = new System.Windows.Forms.Button();
            this.dgvKunde = new System.Windows.Forms.DataGridView();
            this.cxtKunde = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.neuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loeschenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errProv = new System.Windows.Forms.ErrorProvider(this.components);
            this.labLand = new System.Windows.Forms.Label();
            this.cmbLand = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKunde)).BeginInit();
            this.cxtKunde.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProv)).BeginInit();
            this.SuspendLayout();
            // 
            // butAbbr
            // 
            this.butAbbr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butAbbr.Location = new System.Drawing.Point(680, 407);
            this.butAbbr.Name = "butAbbr";
            this.butAbbr.Size = new System.Drawing.Size(75, 23);
            this.butAbbr.TabIndex = 8;
            this.butAbbr.Text = "Abbrechen";
            this.butAbbr.UseVisualStyleBackColor = true;
            this.butAbbr.Click += new System.EventHandler(this.ButAbbr_Click);
            // 
            // butSpeichern
            // 
            this.butSpeichern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butSpeichern.Location = new System.Drawing.Point(599, 407);
            this.butSpeichern.Name = "butSpeichern";
            this.butSpeichern.Size = new System.Drawing.Size(75, 23);
            this.butSpeichern.TabIndex = 7;
            this.butSpeichern.Text = "Speichern";
            this.butSpeichern.UseVisualStyleBackColor = true;
            this.butSpeichern.Click += new System.EventHandler(this.ButSpeichern_Click);
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Location = new System.Drawing.Point(12, 16);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(35, 13);
            this.labName.TabIndex = 9;
            this.labName.Text = "Name";
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.Location = new System.Drawing.Point(105, 13);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(650, 20);
            this.tbName.TabIndex = 0;
            // 
            // tbStraße
            // 
            this.tbStraße.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStraße.Location = new System.Drawing.Point(105, 92);
            this.tbStraße.Name = "tbStraße";
            this.tbStraße.Size = new System.Drawing.Size(650, 20);
            this.tbStraße.TabIndex = 2;
            // 
            // tbPLZ
            // 
            this.tbPLZ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPLZ.Location = new System.Drawing.Point(105, 171);
            this.tbPLZ.Name = "tbPLZ";
            this.tbPLZ.Size = new System.Drawing.Size(650, 20);
            this.tbPLZ.TabIndex = 5;
            // 
            // tbTelefon
            // 
            this.tbTelefon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTelefon.Location = new System.Drawing.Point(105, 39);
            this.tbTelefon.Name = "tbTelefon";
            this.tbTelefon.Size = new System.Drawing.Size(650, 20);
            this.tbTelefon.TabIndex = 1;
            // 
            // labStraße
            // 
            this.labStraße.AutoSize = true;
            this.labStraße.Location = new System.Drawing.Point(12, 95);
            this.labStraße.Name = "labStraße";
            this.labStraße.Size = new System.Drawing.Size(38, 13);
            this.labStraße.TabIndex = 12;
            this.labStraße.Text = "Straße";
            // 
            // labPLZ
            // 
            this.labPLZ.AutoSize = true;
            this.labPLZ.Location = new System.Drawing.Point(12, 174);
            this.labPLZ.Name = "labPLZ";
            this.labPLZ.Size = new System.Drawing.Size(27, 13);
            this.labPLZ.TabIndex = 15;
            this.labPLZ.Text = "PLZ";
            // 
            // labTelefon
            // 
            this.labTelefon.AutoSize = true;
            this.labTelefon.Location = new System.Drawing.Point(12, 42);
            this.labTelefon.Name = "labTelefon";
            this.labTelefon.Size = new System.Drawing.Size(55, 13);
            this.labTelefon.TabIndex = 10;
            this.labTelefon.Text = "Telefonnr.";
            // 
            // labHaus
            // 
            this.labHaus.AutoSize = true;
            this.labHaus.Location = new System.Drawing.Point(12, 121);
            this.labHaus.Name = "labHaus";
            this.labHaus.Size = new System.Drawing.Size(44, 13);
            this.labHaus.TabIndex = 13;
            this.labHaus.Text = "Hausnr.";
            // 
            // labStadt
            // 
            this.labStadt.AutoSize = true;
            this.labStadt.Location = new System.Drawing.Point(12, 148);
            this.labStadt.Name = "labStadt";
            this.labStadt.Size = new System.Drawing.Size(32, 13);
            this.labStadt.TabIndex = 14;
            this.labStadt.Text = "Stadt";
            // 
            // tbHaus
            // 
            this.tbHaus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbHaus.Location = new System.Drawing.Point(105, 118);
            this.tbHaus.Name = "tbHaus";
            this.tbHaus.Size = new System.Drawing.Size(650, 20);
            this.tbHaus.TabIndex = 3;
            // 
            // tbStadt
            // 
            this.tbStadt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStadt.Location = new System.Drawing.Point(105, 145);
            this.tbStadt.Name = "tbStadt";
            this.tbStadt.Size = new System.Drawing.Size(650, 20);
            this.tbStadt.TabIndex = 4;
            // 
            // labRech
            // 
            this.labRech.AutoSize = true;
            this.labRech.Location = new System.Drawing.Point(12, 68);
            this.labRech.Name = "labRech";
            this.labRech.Size = new System.Drawing.Size(108, 13);
            this.labRech.TabIndex = 11;
            this.labRech.Text = "Rechnungsaddresse:";
            // 
            // butAdresse
            // 
            this.butAdresse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butAdresse.AutoSize = true;
            this.butAdresse.Location = new System.Drawing.Point(12, 407);
            this.butAdresse.Name = "butAdresse";
            this.butAdresse.Size = new System.Drawing.Size(101, 23);
            this.butAdresse.TabIndex = 6;
            this.butAdresse.Text = "Weitere Adresse";
            this.butAdresse.UseVisualStyleBackColor = true;
            this.butAdresse.Click += new System.EventHandler(this.ButAdresse_Click);
            // 
            // dgvKunde
            // 
            this.dgvKunde.AllowUserToAddRows = false;
            this.dgvKunde.AllowUserToDeleteRows = false;
            this.dgvKunde.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKunde.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvKunde.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKunde.Location = new System.Drawing.Point(15, 224);
            this.dgvKunde.Name = "dgvKunde";
            this.dgvKunde.Size = new System.Drawing.Size(740, 176);
            this.dgvKunde.TabIndex = 16;
            this.dgvKunde.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKunde_CellContentDoubleClick);
            this.dgvKunde.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvKunde_RowHeaderMouseDoubleClick);
            this.dgvKunde.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DgvKunde_MouseUp);
            // 
            // cxtKunde
            // 
            this.cxtKunde.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neuToolStripMenuItem,
            this.bearbeitenToolStripMenuItem,
            this.loeschenToolStripMenuItem});
            this.cxtKunde.Name = "cmsKunde";
            this.cxtKunde.Size = new System.Drawing.Size(131, 70);
            // 
            // neuToolStripMenuItem
            // 
            this.neuToolStripMenuItem.Name = "neuToolStripMenuItem";
            this.neuToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.neuToolStripMenuItem.Text = "Neu";
            this.neuToolStripMenuItem.Click += new System.EventHandler(this.NeuToolStripMenuItem_Click);
            // 
            // bearbeitenToolStripMenuItem
            // 
            this.bearbeitenToolStripMenuItem.Name = "bearbeitenToolStripMenuItem";
            this.bearbeitenToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.bearbeitenToolStripMenuItem.Text = "Bearbeiten";
            this.bearbeitenToolStripMenuItem.Click += new System.EventHandler(this.BearbeitenToolStripMenuItem_Click);
            // 
            // loeschenToolStripMenuItem
            // 
            this.loeschenToolStripMenuItem.Name = "loeschenToolStripMenuItem";
            this.loeschenToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.loeschenToolStripMenuItem.Text = "Löschen";
            this.loeschenToolStripMenuItem.Click += new System.EventHandler(this.LoeschenToolStripMenuItem_Click);
            // 
            // errProv
            // 
            this.errProv.ContainerControl = this;
            // 
            // labLand
            // 
            this.labLand.AutoSize = true;
            this.labLand.Location = new System.Drawing.Point(12, 200);
            this.labLand.Name = "labLand";
            this.labLand.Size = new System.Drawing.Size(31, 13);
            this.labLand.TabIndex = 19;
            this.labLand.Text = "Land";
            // 
            // cmbLand
            // 
            this.cmbLand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLand.FormattingEnabled = true;
            this.cmbLand.Location = new System.Drawing.Point(105, 197);
            this.cmbLand.Name = "cmbLand";
            this.cmbLand.Size = new System.Drawing.Size(650, 21);
            this.cmbLand.TabIndex = 18;
            this.cmbLand.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.ComboBoxFormat);
            // 
            // KundeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 442);
            this.Controls.Add(this.labLand);
            this.Controls.Add(this.cmbLand);
            this.Controls.Add(this.dgvKunde);
            this.Controls.Add(this.butAdresse);
            this.Controls.Add(this.labRech);
            this.Controls.Add(this.tbStadt);
            this.Controls.Add(this.tbHaus);
            this.Controls.Add(this.labStadt);
            this.Controls.Add(this.labHaus);
            this.Controls.Add(this.labTelefon);
            this.Controls.Add(this.labPLZ);
            this.Controls.Add(this.labStraße);
            this.Controls.Add(this.tbTelefon);
            this.Controls.Add(this.tbPLZ);
            this.Controls.Add(this.tbStraße);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.labName);
            this.Controls.Add(this.butAbbr);
            this.Controls.Add(this.butSpeichern);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 450);
            this.Name = "KundeView";
            this.Text = "Kunde";
            ((System.ComponentModel.ISupportInitialize)(this.dgvKunde)).EndInit();
            this.cxtKunde.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errProv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butAbbr;
        private System.Windows.Forms.Button butSpeichern;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbStraße;
        private System.Windows.Forms.TextBox tbPLZ;
        private System.Windows.Forms.TextBox tbTelefon;
        private System.Windows.Forms.Label labStraße;
        private System.Windows.Forms.Label labPLZ;
        private System.Windows.Forms.Label labTelefon;
        private System.Windows.Forms.Label labHaus;
        private System.Windows.Forms.Label labStadt;
        private System.Windows.Forms.TextBox tbHaus;
        private System.Windows.Forms.TextBox tbStadt;
        private System.Windows.Forms.Label labRech;
        private System.Windows.Forms.Button butAdresse;
        private System.Windows.Forms.DataGridView dgvKunde;
        private System.Windows.Forms.ContextMenuStrip cxtKunde;
        private System.Windows.Forms.ToolStripMenuItem neuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bearbeitenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loeschenToolStripMenuItem;
        private System.Windows.Forms.ErrorProvider errProv;
        private System.Windows.Forms.Label labLand;
        private System.Windows.Forms.ComboBox cmbLand;
    }
}