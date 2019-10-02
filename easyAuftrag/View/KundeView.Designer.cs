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
            ((System.ComponentModel.ISupportInitialize)(this.dgvKunde)).BeginInit();
            this.SuspendLayout();
            // 
            // butAbbr
            // 
            this.butAbbr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butAbbr.Location = new System.Drawing.Point(497, 376);
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
            this.butSpeichern.Location = new System.Drawing.Point(416, 376);
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
            this.tbName.Size = new System.Drawing.Size(467, 20);
            this.tbName.TabIndex = 0;
            // 
            // tbStraße
            // 
            this.tbStraße.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStraße.Location = new System.Drawing.Point(105, 92);
            this.tbStraße.Name = "tbStraße";
            this.tbStraße.Size = new System.Drawing.Size(467, 20);
            this.tbStraße.TabIndex = 2;
            // 
            // tbPLZ
            // 
            this.tbPLZ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPLZ.Location = new System.Drawing.Point(105, 171);
            this.tbPLZ.Name = "tbPLZ";
            this.tbPLZ.Size = new System.Drawing.Size(467, 20);
            this.tbPLZ.TabIndex = 5;
            // 
            // tbTelefon
            // 
            this.tbTelefon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTelefon.Location = new System.Drawing.Point(105, 39);
            this.tbTelefon.Name = "tbTelefon";
            this.tbTelefon.Size = new System.Drawing.Size(467, 20);
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
            this.tbHaus.Size = new System.Drawing.Size(467, 20);
            this.tbHaus.TabIndex = 3;
            // 
            // tbStadt
            // 
            this.tbStadt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStadt.Location = new System.Drawing.Point(105, 145);
            this.tbStadt.Name = "tbStadt";
            this.tbStadt.Size = new System.Drawing.Size(467, 20);
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
            this.butAdresse.Location = new System.Drawing.Point(12, 376);
            this.butAdresse.Name = "butAdresse";
            this.butAdresse.Size = new System.Drawing.Size(101, 23);
            this.butAdresse.TabIndex = 6;
            this.butAdresse.Text = "Weitere Adresse";
            this.butAdresse.UseVisualStyleBackColor = true;
            this.butAdresse.Click += new System.EventHandler(this.ButAdresse_Click);
            // 
            // dgvKunde
            // 
            this.dgvKunde.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKunde.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKunde.Location = new System.Drawing.Point(15, 197);
            this.dgvKunde.Name = "dgvKunde";
            this.dgvKunde.Size = new System.Drawing.Size(557, 172);
            this.dgvKunde.TabIndex = 16;
            // 
            // KundeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 411);
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
    }
}