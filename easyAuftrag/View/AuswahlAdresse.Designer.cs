namespace easyAuftrag.View
{
    partial class AuswahlAdresse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuswahlAdresse));
            this.tbStadt = new System.Windows.Forms.TextBox();
            this.tbHaus = new System.Windows.Forms.TextBox();
            this.labStadt = new System.Windows.Forms.Label();
            this.labHaus = new System.Windows.Forms.Label();
            this.labPLZ = new System.Windows.Forms.Label();
            this.labStraße = new System.Windows.Forms.Label();
            this.tbPLZ = new System.Windows.Forms.TextBox();
            this.tbStraße = new System.Windows.Forms.TextBox();
            this.butAuswahl = new System.Windows.Forms.Button();
            this.butAbbr = new System.Windows.Forms.Button();
            this.cbAdresse = new System.Windows.Forms.ComboBox();
            this.labAdresse = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbStadt
            // 
            this.tbStadt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStadt.Location = new System.Drawing.Point(105, 94);
            this.tbStadt.Name = "tbStadt";
            this.tbStadt.ReadOnly = true;
            this.tbStadt.Size = new System.Drawing.Size(658, 20);
            this.tbStadt.TabIndex = 28;
            // 
            // tbHaus
            // 
            this.tbHaus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbHaus.Location = new System.Drawing.Point(105, 67);
            this.tbHaus.Name = "tbHaus";
            this.tbHaus.ReadOnly = true;
            this.tbHaus.Size = new System.Drawing.Size(658, 20);
            this.tbHaus.TabIndex = 27;
            // 
            // labStadt
            // 
            this.labStadt.AutoSize = true;
            this.labStadt.Location = new System.Drawing.Point(12, 97);
            this.labStadt.Name = "labStadt";
            this.labStadt.Size = new System.Drawing.Size(32, 13);
            this.labStadt.TabIndex = 32;
            this.labStadt.Text = "Stadt";
            // 
            // labHaus
            // 
            this.labHaus.AutoSize = true;
            this.labHaus.Location = new System.Drawing.Point(12, 70);
            this.labHaus.Name = "labHaus";
            this.labHaus.Size = new System.Drawing.Size(44, 13);
            this.labHaus.TabIndex = 31;
            this.labHaus.Text = "Hausnr.";
            // 
            // labPLZ
            // 
            this.labPLZ.AutoSize = true;
            this.labPLZ.Location = new System.Drawing.Point(12, 123);
            this.labPLZ.Name = "labPLZ";
            this.labPLZ.Size = new System.Drawing.Size(27, 13);
            this.labPLZ.TabIndex = 33;
            this.labPLZ.Text = "PLZ";
            // 
            // labStraße
            // 
            this.labStraße.AutoSize = true;
            this.labStraße.Location = new System.Drawing.Point(12, 44);
            this.labStraße.Name = "labStraße";
            this.labStraße.Size = new System.Drawing.Size(38, 13);
            this.labStraße.TabIndex = 30;
            this.labStraße.Text = "Straße";
            // 
            // tbPLZ
            // 
            this.tbPLZ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPLZ.Location = new System.Drawing.Point(105, 120);
            this.tbPLZ.Name = "tbPLZ";
            this.tbPLZ.ReadOnly = true;
            this.tbPLZ.Size = new System.Drawing.Size(658, 20);
            this.tbPLZ.TabIndex = 29;
            // 
            // tbStraße
            // 
            this.tbStraße.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStraße.Location = new System.Drawing.Point(105, 41);
            this.tbStraße.Name = "tbStraße";
            this.tbStraße.ReadOnly = true;
            this.tbStraße.Size = new System.Drawing.Size(658, 20);
            this.tbStraße.TabIndex = 26;
            // 
            // butAuswahl
            // 
            this.butAuswahl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butAuswahl.Location = new System.Drawing.Point(607, 149);
            this.butAuswahl.Name = "butAuswahl";
            this.butAuswahl.Size = new System.Drawing.Size(75, 23);
            this.butAuswahl.TabIndex = 25;
            this.butAuswahl.Text = "Auswählen";
            this.butAuswahl.UseVisualStyleBackColor = true;
            this.butAuswahl.Click += new System.EventHandler(this.ButAuswahl_Click);
            // 
            // butAbbr
            // 
            this.butAbbr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butAbbr.Location = new System.Drawing.Point(688, 149);
            this.butAbbr.Name = "butAbbr";
            this.butAbbr.Size = new System.Drawing.Size(75, 23);
            this.butAbbr.TabIndex = 24;
            this.butAbbr.Text = "Abbrechen";
            this.butAbbr.UseVisualStyleBackColor = true;
            this.butAbbr.Click += new System.EventHandler(this.ButAbbr_Click);
            // 
            // cbAdresse
            // 
            this.cbAdresse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAdresse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAdresse.FormattingEnabled = true;
            this.cbAdresse.Location = new System.Drawing.Point(105, 13);
            this.cbAdresse.Name = "cbAdresse";
            this.cbAdresse.Size = new System.Drawing.Size(658, 21);
            this.cbAdresse.TabIndex = 34;
            this.cbAdresse.SelectedIndexChanged += new System.EventHandler(this.CbAdresse_SelectedIndexChanged);
            // 
            // labAdresse
            // 
            this.labAdresse.AutoSize = true;
            this.labAdresse.Location = new System.Drawing.Point(12, 16);
            this.labAdresse.Name = "labAdresse";
            this.labAdresse.Size = new System.Drawing.Size(45, 13);
            this.labAdresse.TabIndex = 35;
            this.labAdresse.Text = "Adresse";
            // 
            // AuswahlAdresse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 184);
            this.Controls.Add(this.labAdresse);
            this.Controls.Add(this.cbAdresse);
            this.Controls.Add(this.tbStadt);
            this.Controls.Add(this.tbHaus);
            this.Controls.Add(this.labStadt);
            this.Controls.Add(this.labHaus);
            this.Controls.Add(this.labPLZ);
            this.Controls.Add(this.labStraße);
            this.Controls.Add(this.tbPLZ);
            this.Controls.Add(this.tbStraße);
            this.Controls.Add(this.butAuswahl);
            this.Controls.Add(this.butAbbr);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(434, 223);
            this.Name = "AuswahlAdresse";
            this.Text = "Auswahl Adresse";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbStadt;
        private System.Windows.Forms.TextBox tbHaus;
        private System.Windows.Forms.Label labStadt;
        private System.Windows.Forms.Label labHaus;
        private System.Windows.Forms.Label labPLZ;
        private System.Windows.Forms.Label labStraße;
        private System.Windows.Forms.TextBox tbPLZ;
        private System.Windows.Forms.TextBox tbStraße;
        private System.Windows.Forms.Button butAuswahl;
        private System.Windows.Forms.Button butAbbr;
        private System.Windows.Forms.ComboBox cbAdresse;
        private System.Windows.Forms.Label labAdresse;
    }
}