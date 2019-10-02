namespace easyAuftrag.View
{
    partial class StundenView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StundenView));
            this.labAnfang = new System.Windows.Forms.Label();
            this.labEnde = new System.Windows.Forms.Label();
            this.labMitarbeiter = new System.Windows.Forms.Label();
            this.dtpAnfang = new System.Windows.Forms.DateTimePicker();
            this.dtpEnde = new System.Windows.Forms.DateTimePicker();
            this.cbMitarbeiter = new System.Windows.Forms.ComboBox();
            this.butAbbr = new System.Windows.Forms.Button();
            this.butDruck = new System.Windows.Forms.Button();
            this.dgvStunden = new System.Windows.Forms.DataGridView();
            this.labSoll = new System.Windows.Forms.Label();
            this.labGeleistet = new System.Windows.Forms.Label();
            this.tbSoll = new System.Windows.Forms.TextBox();
            this.tbGeleistet = new System.Windows.Forms.TextBox();
            this.butBerechnen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStunden)).BeginInit();
            this.SuspendLayout();
            // 
            // labAnfang
            // 
            this.labAnfang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labAnfang.AutoSize = true;
            this.labAnfang.Location = new System.Drawing.Point(12, 19);
            this.labAnfang.Name = "labAnfang";
            this.labAnfang.Size = new System.Drawing.Size(41, 13);
            this.labAnfang.TabIndex = 0;
            this.labAnfang.Text = "Anfang";
            // 
            // labEnde
            // 
            this.labEnde.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labEnde.AutoSize = true;
            this.labEnde.Location = new System.Drawing.Point(12, 45);
            this.labEnde.Name = "labEnde";
            this.labEnde.Size = new System.Drawing.Size(32, 13);
            this.labEnde.TabIndex = 1;
            this.labEnde.Text = "Ende";
            // 
            // labMitarbeiter
            // 
            this.labMitarbeiter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labMitarbeiter.AutoSize = true;
            this.labMitarbeiter.Location = new System.Drawing.Point(12, 68);
            this.labMitarbeiter.Name = "labMitarbeiter";
            this.labMitarbeiter.Size = new System.Drawing.Size(56, 13);
            this.labMitarbeiter.TabIndex = 2;
            this.labMitarbeiter.Text = "Mitarbeiter";
            // 
            // dtpAnfang
            // 
            this.dtpAnfang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpAnfang.Location = new System.Drawing.Point(118, 13);
            this.dtpAnfang.Name = "dtpAnfang";
            this.dtpAnfang.Size = new System.Drawing.Size(454, 20);
            this.dtpAnfang.TabIndex = 3;
            // 
            // dtpEnde
            // 
            this.dtpEnde.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpEnde.Location = new System.Drawing.Point(118, 39);
            this.dtpEnde.Name = "dtpEnde";
            this.dtpEnde.Size = new System.Drawing.Size(454, 20);
            this.dtpEnde.TabIndex = 4;
            // 
            // cbMitarbeiter
            // 
            this.cbMitarbeiter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMitarbeiter.FormattingEnabled = true;
            this.cbMitarbeiter.Location = new System.Drawing.Point(118, 65);
            this.cbMitarbeiter.Name = "cbMitarbeiter";
            this.cbMitarbeiter.Size = new System.Drawing.Size(454, 21);
            this.cbMitarbeiter.TabIndex = 5;
            // 
            // butAbbr
            // 
            this.butAbbr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butAbbr.Location = new System.Drawing.Point(497, 326);
            this.butAbbr.Name = "butAbbr";
            this.butAbbr.Size = new System.Drawing.Size(75, 23);
            this.butAbbr.TabIndex = 6;
            this.butAbbr.Text = "Abbrechen";
            this.butAbbr.UseVisualStyleBackColor = true;
            this.butAbbr.Click += new System.EventHandler(this.ButAbbr_Click);
            // 
            // butDruck
            // 
            this.butDruck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butDruck.Location = new System.Drawing.Point(416, 326);
            this.butDruck.Name = "butDruck";
            this.butDruck.Size = new System.Drawing.Size(75, 23);
            this.butDruck.TabIndex = 7;
            this.butDruck.Text = "Drucken";
            this.butDruck.UseVisualStyleBackColor = true;
            this.butDruck.Click += new System.EventHandler(this.ButDruck_Click);
            // 
            // dgvStunden
            // 
            this.dgvStunden.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStunden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStunden.Location = new System.Drawing.Point(12, 145);
            this.dgvStunden.Name = "dgvStunden";
            this.dgvStunden.Size = new System.Drawing.Size(560, 175);
            this.dgvStunden.TabIndex = 8;
            // 
            // labSoll
            // 
            this.labSoll.AutoSize = true;
            this.labSoll.Location = new System.Drawing.Point(12, 99);
            this.labSoll.Name = "labSoll";
            this.labSoll.Size = new System.Drawing.Size(62, 13);
            this.labSoll.TabIndex = 9;
            this.labSoll.Text = "Stundensoll";
            // 
            // labGeleistet
            // 
            this.labGeleistet.AutoSize = true;
            this.labGeleistet.Location = new System.Drawing.Point(12, 124);
            this.labGeleistet.Name = "labGeleistet";
            this.labGeleistet.Size = new System.Drawing.Size(97, 13);
            this.labGeleistet.TabIndex = 10;
            this.labGeleistet.Text = "Geleistete Stunden";
            // 
            // tbSoll
            // 
            this.tbSoll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSoll.Location = new System.Drawing.Point(118, 93);
            this.tbSoll.Name = "tbSoll";
            this.tbSoll.Size = new System.Drawing.Size(454, 20);
            this.tbSoll.TabIndex = 11;
            // 
            // tbGeleistet
            // 
            this.tbGeleistet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGeleistet.Location = new System.Drawing.Point(118, 119);
            this.tbGeleistet.Name = "tbGeleistet";
            this.tbGeleistet.Size = new System.Drawing.Size(454, 20);
            this.tbGeleistet.TabIndex = 12;
            // 
            // butBerechnen
            // 
            this.butBerechnen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butBerechnen.Location = new System.Drawing.Point(335, 326);
            this.butBerechnen.Name = "butBerechnen";
            this.butBerechnen.Size = new System.Drawing.Size(75, 23);
            this.butBerechnen.TabIndex = 13;
            this.butBerechnen.Text = "Berechnen";
            this.butBerechnen.UseVisualStyleBackColor = true;
            this.butBerechnen.Click += new System.EventHandler(this.ButBerechnen_Click);
            // 
            // StundenView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.butBerechnen);
            this.Controls.Add(this.tbGeleistet);
            this.Controls.Add(this.tbSoll);
            this.Controls.Add(this.labGeleistet);
            this.Controls.Add(this.labSoll);
            this.Controls.Add(this.dgvStunden);
            this.Controls.Add(this.butDruck);
            this.Controls.Add(this.butAbbr);
            this.Controls.Add(this.cbMitarbeiter);
            this.Controls.Add(this.dtpEnde);
            this.Controls.Add(this.dtpAnfang);
            this.Controls.Add(this.labMitarbeiter);
            this.Controls.Add(this.labEnde);
            this.Controls.Add(this.labAnfang);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "StundenView";
            this.Text = "Stundennachweis";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStunden)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labAnfang;
        private System.Windows.Forms.Label labEnde;
        private System.Windows.Forms.Label labMitarbeiter;
        private System.Windows.Forms.DateTimePicker dtpAnfang;
        private System.Windows.Forms.DateTimePicker dtpEnde;
        private System.Windows.Forms.ComboBox cbMitarbeiter;
        private System.Windows.Forms.Button butAbbr;
        private System.Windows.Forms.Button butDruck;
        private System.Windows.Forms.DataGridView dgvStunden;
        private System.Windows.Forms.Label labSoll;
        private System.Windows.Forms.Label labGeleistet;
        private System.Windows.Forms.TextBox tbSoll;
        private System.Windows.Forms.TextBox tbGeleistet;
        private System.Windows.Forms.Button butBerechnen;
    }
}