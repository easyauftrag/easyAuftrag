namespace easyAuftrag.View
{
    partial class BerechnungView
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
            this.labMitarbeiter = new System.Windows.Forms.Label();
            this.labStart = new System.Windows.Forms.Label();
            this.labEnde = new System.Windows.Forms.Label();
            this.labGesamt = new System.Windows.Forms.Label();
            this.labSoll = new System.Windows.Forms.Label();
            this.cbMitarbeiter = new System.Windows.Forms.ComboBox();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnde = new System.Windows.Forms.DateTimePicker();
            this.tbGesamt = new System.Windows.Forms.TextBox();
            this.tbSoll = new System.Windows.Forms.TextBox();
            this.butAbbr = new System.Windows.Forms.Button();
            this.butBerechnen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labMitarbeiter
            // 
            this.labMitarbeiter.AutoSize = true;
            this.labMitarbeiter.Location = new System.Drawing.Point(12, 20);
            this.labMitarbeiter.Name = "labMitarbeiter";
            this.labMitarbeiter.Size = new System.Drawing.Size(56, 13);
            this.labMitarbeiter.TabIndex = 7;
            this.labMitarbeiter.Text = "Mitarbeiter";
            // 
            // labStart
            // 
            this.labStart.AutoSize = true;
            this.labStart.Location = new System.Drawing.Point(12, 46);
            this.labStart.Name = "labStart";
            this.labStart.Size = new System.Drawing.Size(26, 13);
            this.labStart.TabIndex = 8;
            this.labStart.Text = "Von";
            // 
            // labEnde
            // 
            this.labEnde.AutoSize = true;
            this.labEnde.Location = new System.Drawing.Point(12, 72);
            this.labEnde.Name = "labEnde";
            this.labEnde.Size = new System.Drawing.Size(21, 13);
            this.labEnde.TabIndex = 9;
            this.labEnde.Text = "Bis";
            // 
            // labGesamt
            // 
            this.labGesamt.AutoSize = true;
            this.labGesamt.Location = new System.Drawing.Point(12, 98);
            this.labGesamt.Name = "labGesamt";
            this.labGesamt.Size = new System.Drawing.Size(97, 13);
            this.labGesamt.TabIndex = 10;
            this.labGesamt.Text = "Geleistete Stunden";
            // 
            // labSoll
            // 
            this.labSoll.AutoSize = true;
            this.labSoll.Location = new System.Drawing.Point(12, 124);
            this.labSoll.Name = "labSoll";
            this.labSoll.Size = new System.Drawing.Size(62, 13);
            this.labSoll.TabIndex = 11;
            this.labSoll.Text = "Sollstunden";
            // 
            // cbMitarbeiter
            // 
            this.cbMitarbeiter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMitarbeiter.FormattingEnabled = true;
            this.cbMitarbeiter.Location = new System.Drawing.Point(120, 12);
            this.cbMitarbeiter.Name = "cbMitarbeiter";
            this.cbMitarbeiter.Size = new System.Drawing.Size(218, 21);
            this.cbMitarbeiter.TabIndex = 0;
            // 
            // dtpStart
            // 
            this.dtpStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpStart.Location = new System.Drawing.Point(120, 39);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(218, 20);
            this.dtpStart.TabIndex = 1;
            // 
            // dtpEnde
            // 
            this.dtpEnde.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpEnde.Location = new System.Drawing.Point(120, 65);
            this.dtpEnde.Name = "dtpEnde";
            this.dtpEnde.Size = new System.Drawing.Size(218, 20);
            this.dtpEnde.TabIndex = 2;
            // 
            // tbGesamt
            // 
            this.tbGesamt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGesamt.Location = new System.Drawing.Point(120, 91);
            this.tbGesamt.Name = "tbGesamt";
            this.tbGesamt.Size = new System.Drawing.Size(218, 20);
            this.tbGesamt.TabIndex = 3;
            // 
            // tbSoll
            // 
            this.tbSoll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSoll.Location = new System.Drawing.Point(120, 117);
            this.tbSoll.Name = "tbSoll";
            this.tbSoll.Size = new System.Drawing.Size(218, 20);
            this.tbSoll.TabIndex = 4;
            // 
            // butAbbr
            // 
            this.butAbbr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butAbbr.Location = new System.Drawing.Point(263, 151);
            this.butAbbr.Name = "butAbbr";
            this.butAbbr.Size = new System.Drawing.Size(75, 23);
            this.butAbbr.TabIndex = 6;
            this.butAbbr.Text = "Abbrechen";
            this.butAbbr.UseVisualStyleBackColor = true;
            // 
            // butBerechnen
            // 
            this.butBerechnen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butBerechnen.Location = new System.Drawing.Point(182, 151);
            this.butBerechnen.Name = "butBerechnen";
            this.butBerechnen.Size = new System.Drawing.Size(75, 23);
            this.butBerechnen.TabIndex = 5;
            this.butBerechnen.Text = "Berechnen";
            this.butBerechnen.UseVisualStyleBackColor = true;
            // 
            // BerechnungView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 186);
            this.Controls.Add(this.butBerechnen);
            this.Controls.Add(this.butAbbr);
            this.Controls.Add(this.tbSoll);
            this.Controls.Add(this.tbGesamt);
            this.Controls.Add(this.dtpEnde);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.cbMitarbeiter);
            this.Controls.Add(this.labSoll);
            this.Controls.Add(this.labGesamt);
            this.Controls.Add(this.labEnde);
            this.Controls.Add(this.labStart);
            this.Controls.Add(this.labMitarbeiter);
            this.Name = "BerechnungView";
            this.Text = "Berechnen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labMitarbeiter;
        private System.Windows.Forms.Label labStart;
        private System.Windows.Forms.Label labEnde;
        private System.Windows.Forms.Label labGesamt;
        private System.Windows.Forms.Label labSoll;
        private System.Windows.Forms.ComboBox cbMitarbeiter;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnde;
        private System.Windows.Forms.TextBox tbGesamt;
        private System.Windows.Forms.TextBox tbSoll;
        private System.Windows.Forms.Button butAbbr;
        private System.Windows.Forms.Button butBerechnen;
    }
}