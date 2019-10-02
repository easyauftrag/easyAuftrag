namespace easyAuftrag.View
{
    partial class MitarbeiterView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MitarbeiterView));
            this.butSpeichern = new System.Windows.Forms.Button();
            this.butAbbr = new System.Windows.Forms.Button();
            this.tbStadt = new System.Windows.Forms.TextBox();
            this.tbHaus = new System.Windows.Forms.TextBox();
            this.labStadt = new System.Windows.Forms.Label();
            this.labHaus = new System.Windows.Forms.Label();
            this.labTelefon = new System.Windows.Forms.Label();
            this.labPLZ = new System.Windows.Forms.Label();
            this.labStraße = new System.Windows.Forms.Label();
            this.tbTelefon = new System.Windows.Forms.TextBox();
            this.tbPLZ = new System.Windows.Forms.TextBox();
            this.tbStraße = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.labName = new System.Windows.Forms.Label();
            this.tbAuslastung = new System.Windows.Forms.TextBox();
            this.labAuslastung = new System.Windows.Forms.Label();
            this.errorInfo = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // butSpeichern
            // 
            this.butSpeichern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butSpeichern.Location = new System.Drawing.Point(105, 201);
            this.butSpeichern.Name = "butSpeichern";
            this.butSpeichern.Size = new System.Drawing.Size(75, 23);
            this.butSpeichern.TabIndex = 7;
            this.butSpeichern.Text = "Speichern";
            this.butSpeichern.UseVisualStyleBackColor = true;
            this.butSpeichern.Click += new System.EventHandler(this.ButSpeichern_Click);
            // 
            // butAbbr
            // 
            this.butAbbr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butAbbr.Location = new System.Drawing.Point(186, 201);
            this.butAbbr.Name = "butAbbr";
            this.butAbbr.Size = new System.Drawing.Size(75, 23);
            this.butAbbr.TabIndex = 8;
            this.butAbbr.Text = "Abbrechen";
            this.butAbbr.UseVisualStyleBackColor = true;
            this.butAbbr.Click += new System.EventHandler(this.ButAbbr_Click);
            // 
            // tbStadt
            // 
            this.tbStadt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStadt.Location = new System.Drawing.Point(105, 92);
            this.tbStadt.Name = "tbStadt";
            this.tbStadt.Size = new System.Drawing.Size(156, 20);
            this.tbStadt.TabIndex = 3;
            // 
            // tbHaus
            // 
            this.tbHaus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbHaus.Location = new System.Drawing.Point(105, 65);
            this.tbHaus.Name = "tbHaus";
            this.tbHaus.Size = new System.Drawing.Size(156, 20);
            this.tbHaus.TabIndex = 2;
            // 
            // labStadt
            // 
            this.labStadt.AutoSize = true;
            this.labStadt.Location = new System.Drawing.Point(12, 95);
            this.labStadt.Name = "labStadt";
            this.labStadt.Size = new System.Drawing.Size(32, 13);
            this.labStadt.TabIndex = 12;
            this.labStadt.Text = "Stadt";
            // 
            // labHaus
            // 
            this.labHaus.AutoSize = true;
            this.labHaus.Location = new System.Drawing.Point(12, 68);
            this.labHaus.Name = "labHaus";
            this.labHaus.Size = new System.Drawing.Size(44, 13);
            this.labHaus.TabIndex = 11;
            this.labHaus.Text = "Hausnr.";
            // 
            // labTelefon
            // 
            this.labTelefon.AutoSize = true;
            this.labTelefon.Location = new System.Drawing.Point(12, 148);
            this.labTelefon.Name = "labTelefon";
            this.labTelefon.Size = new System.Drawing.Size(55, 13);
            this.labTelefon.TabIndex = 14;
            this.labTelefon.Text = "Telefonnr.";
            // 
            // labPLZ
            // 
            this.labPLZ.AutoSize = true;
            this.labPLZ.Location = new System.Drawing.Point(12, 121);
            this.labPLZ.Name = "labPLZ";
            this.labPLZ.Size = new System.Drawing.Size(27, 13);
            this.labPLZ.TabIndex = 13;
            this.labPLZ.Text = "PLZ";
            // 
            // labStraße
            // 
            this.labStraße.AutoSize = true;
            this.labStraße.Location = new System.Drawing.Point(12, 42);
            this.labStraße.Name = "labStraße";
            this.labStraße.Size = new System.Drawing.Size(38, 13);
            this.labStraße.TabIndex = 10;
            this.labStraße.Text = "Straße";
            // 
            // tbTelefon
            // 
            this.tbTelefon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTelefon.Location = new System.Drawing.Point(105, 145);
            this.tbTelefon.Name = "tbTelefon";
            this.tbTelefon.Size = new System.Drawing.Size(156, 20);
            this.tbTelefon.TabIndex = 5;
            // 
            // tbPLZ
            // 
            this.tbPLZ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPLZ.Location = new System.Drawing.Point(105, 118);
            this.tbPLZ.Name = "tbPLZ";
            this.tbPLZ.Size = new System.Drawing.Size(156, 20);
            this.tbPLZ.TabIndex = 4;
            // 
            // tbStraße
            // 
            this.tbStraße.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStraße.Location = new System.Drawing.Point(105, 39);
            this.tbStraße.Name = "tbStraße";
            this.tbStraße.Size = new System.Drawing.Size(156, 20);
            this.tbStraße.TabIndex = 1;
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.Location = new System.Drawing.Point(105, 12);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(156, 20);
            this.tbName.TabIndex = 0;
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Location = new System.Drawing.Point(12, 15);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(35, 13);
            this.labName.TabIndex = 9;
            this.labName.Text = "Name";
            // 
            // tbAuslastung
            // 
            this.tbAuslastung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAuslastung.Location = new System.Drawing.Point(105, 172);
            this.tbAuslastung.Name = "tbAuslastung";
            this.tbAuslastung.Size = new System.Drawing.Size(156, 20);
            this.tbAuslastung.TabIndex = 6;
            // 
            // labAuslastung
            // 
            this.labAuslastung.AutoSize = true;
            this.labAuslastung.Location = new System.Drawing.Point(12, 175);
            this.labAuslastung.Name = "labAuslastung";
            this.labAuslastung.Size = new System.Drawing.Size(88, 13);
            this.labAuslastung.TabIndex = 15;
            this.labAuslastung.Text = "Auslastung Stelle";
            // 
            // errorInfo
            // 
            this.errorInfo.ContainerControl = this;
            // 
            // MitarbeiterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 236);
            this.Controls.Add(this.labAuslastung);
            this.Controls.Add(this.tbAuslastung);
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
            this.MinimumSize = new System.Drawing.Size(289, 275);
            this.Name = "MitarbeiterView";
            this.Text = "Mitarbeiter";
            ((System.ComponentModel.ISupportInitialize)(this.errorInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butSpeichern;
        private System.Windows.Forms.Button butAbbr;
        private System.Windows.Forms.TextBox tbStadt;
        private System.Windows.Forms.TextBox tbHaus;
        private System.Windows.Forms.Label labStadt;
        private System.Windows.Forms.Label labHaus;
        private System.Windows.Forms.Label labTelefon;
        private System.Windows.Forms.Label labPLZ;
        private System.Windows.Forms.Label labStraße;
        private System.Windows.Forms.TextBox tbTelefon;
        private System.Windows.Forms.TextBox tbPLZ;
        private System.Windows.Forms.TextBox tbStraße;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.TextBox tbAuslastung;
        private System.Windows.Forms.Label labAuslastung;
        private System.Windows.Forms.ErrorProvider errorInfo;
    }
}