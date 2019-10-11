namespace easyAuftrag.View
{
    partial class AdresseView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdresseView));
            this.butAbbr = new System.Windows.Forms.Button();
            this.butSpeichern = new System.Windows.Forms.Button();
            this.tbStadt = new System.Windows.Forms.TextBox();
            this.tbHaus = new System.Windows.Forms.TextBox();
            this.labStadt = new System.Windows.Forms.Label();
            this.labHaus = new System.Windows.Forms.Label();
            this.labPLZ = new System.Windows.Forms.Label();
            this.labStraße = new System.Windows.Forms.Label();
            this.tbPLZ = new System.Windows.Forms.TextBox();
            this.tbStraße = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // butAbbr
            // 
            this.butAbbr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butAbbr.Location = new System.Drawing.Point(697, 127);
            this.butAbbr.Name = "butAbbr";
            this.butAbbr.Size = new System.Drawing.Size(75, 23);
            this.butAbbr.TabIndex = 0;
            this.butAbbr.Text = "Abbrechen";
            this.butAbbr.UseVisualStyleBackColor = true;
            this.butAbbr.Click += new System.EventHandler(this.ButAbbr_Click);
            // 
            // butSpeichern
            // 
            this.butSpeichern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butSpeichern.Location = new System.Drawing.Point(616, 127);
            this.butSpeichern.Name = "butSpeichern";
            this.butSpeichern.Size = new System.Drawing.Size(75, 23);
            this.butSpeichern.TabIndex = 1;
            this.butSpeichern.Text = "Speichern";
            this.butSpeichern.UseVisualStyleBackColor = true;
            this.butSpeichern.Click += new System.EventHandler(this.ButSpeichern_Click);
            // 
            // tbStadt
            // 
            this.tbStadt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStadt.Location = new System.Drawing.Point(111, 65);
            this.tbStadt.Name = "tbStadt";
            this.tbStadt.Size = new System.Drawing.Size(661, 20);
            this.tbStadt.TabIndex = 18;
            // 
            // tbHaus
            // 
            this.tbHaus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbHaus.Location = new System.Drawing.Point(111, 38);
            this.tbHaus.Name = "tbHaus";
            this.tbHaus.Size = new System.Drawing.Size(661, 20);
            this.tbHaus.TabIndex = 17;
            // 
            // labStadt
            // 
            this.labStadt.AutoSize = true;
            this.labStadt.Location = new System.Drawing.Point(18, 68);
            this.labStadt.Name = "labStadt";
            this.labStadt.Size = new System.Drawing.Size(32, 13);
            this.labStadt.TabIndex = 22;
            this.labStadt.Text = "Stadt";
            // 
            // labHaus
            // 
            this.labHaus.AutoSize = true;
            this.labHaus.Location = new System.Drawing.Point(18, 41);
            this.labHaus.Name = "labHaus";
            this.labHaus.Size = new System.Drawing.Size(44, 13);
            this.labHaus.TabIndex = 21;
            this.labHaus.Text = "Hausnr.";
            // 
            // labPLZ
            // 
            this.labPLZ.AutoSize = true;
            this.labPLZ.Location = new System.Drawing.Point(18, 94);
            this.labPLZ.Name = "labPLZ";
            this.labPLZ.Size = new System.Drawing.Size(27, 13);
            this.labPLZ.TabIndex = 23;
            this.labPLZ.Text = "PLZ";
            // 
            // labStraße
            // 
            this.labStraße.AutoSize = true;
            this.labStraße.Location = new System.Drawing.Point(18, 15);
            this.labStraße.Name = "labStraße";
            this.labStraße.Size = new System.Drawing.Size(38, 13);
            this.labStraße.TabIndex = 20;
            this.labStraße.Text = "Straße";
            // 
            // tbPLZ
            // 
            this.tbPLZ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPLZ.Location = new System.Drawing.Point(111, 91);
            this.tbPLZ.Name = "tbPLZ";
            this.tbPLZ.Size = new System.Drawing.Size(661, 20);
            this.tbPLZ.TabIndex = 19;
            // 
            // tbStraße
            // 
            this.tbStraße.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStraße.Location = new System.Drawing.Point(111, 12);
            this.tbStraße.Name = "tbStraße";
            this.tbStraße.Size = new System.Drawing.Size(661, 20);
            this.tbStraße.TabIndex = 16;
            // 
            // AdresseView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 162);
            this.Controls.Add(this.tbStadt);
            this.Controls.Add(this.tbHaus);
            this.Controls.Add(this.labStadt);
            this.Controls.Add(this.labHaus);
            this.Controls.Add(this.labPLZ);
            this.Controls.Add(this.labStraße);
            this.Controls.Add(this.tbPLZ);
            this.Controls.Add(this.tbStraße);
            this.Controls.Add(this.butSpeichern);
            this.Controls.Add(this.butAbbr);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(473, 201);
            this.Name = "AdresseView";
            this.Text = "Adresse";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butAbbr;
        private System.Windows.Forms.Button butSpeichern;
        private System.Windows.Forms.TextBox tbStadt;
        private System.Windows.Forms.TextBox tbHaus;
        private System.Windows.Forms.Label labStadt;
        private System.Windows.Forms.Label labHaus;
        private System.Windows.Forms.Label labPLZ;
        private System.Windows.Forms.Label labStraße;
        private System.Windows.Forms.TextBox tbPLZ;
        private System.Windows.Forms.TextBox tbStraße;
    }
}