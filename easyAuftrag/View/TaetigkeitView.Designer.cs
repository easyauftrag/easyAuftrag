﻿namespace easyAuftrag.View
{
    partial class TaetigkeitView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaetigkeitView));
            this.labEnde = new System.Windows.Forms.Label();
            this.labStart = new System.Windows.Forms.Label();
            this.labDatum = new System.Windows.Forms.Label();
            this.labMitarbeiter = new System.Windows.Forms.Label();
            this.dtpDatum = new System.Windows.Forms.DateTimePicker();
            this.cbMitarbeiter = new System.Windows.Forms.ComboBox();
            this.butAbbr = new System.Windows.Forms.Button();
            this.butSpeichern = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.labBeschreibung = new System.Windows.Forms.Label();
            this.errorInfo = new System.Windows.Forms.ErrorProvider(this.components);
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnde = new System.Windows.Forms.DateTimePicker();
            this.suchControl1 = new easyAuftrag.View.SuchControl();
            this.toolTipTaetigkeit = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // labEnde
            // 
            this.labEnde.AutoSize = true;
            this.labEnde.Location = new System.Drawing.Point(12, 125);
            this.labEnde.Name = "labEnde";
            this.labEnde.Size = new System.Drawing.Size(42, 13);
            this.labEnde.TabIndex = 11;
            this.labEnde.Text = "Endzeit";
            this.labEnde.MouseHover += new System.EventHandler(this.LabEnde_MouseHover);
            // 
            // labStart
            // 
            this.labStart.AutoSize = true;
            this.labStart.Location = new System.Drawing.Point(12, 99);
            this.labStart.Name = "labStart";
            this.labStart.Size = new System.Drawing.Size(45, 13);
            this.labStart.TabIndex = 10;
            this.labStart.Text = "Startzeit";
            this.labStart.MouseHover += new System.EventHandler(this.LabStart_MouseHover);
            // 
            // labDatum
            // 
            this.labDatum.AutoSize = true;
            this.labDatum.Location = new System.Drawing.Point(12, 46);
            this.labDatum.Name = "labDatum";
            this.labDatum.Size = new System.Drawing.Size(38, 13);
            this.labDatum.TabIndex = 8;
            this.labDatum.Text = "Datum";
            // 
            // labMitarbeiter
            // 
            this.labMitarbeiter.AutoSize = true;
            this.labMitarbeiter.Location = new System.Drawing.Point(12, 16);
            this.labMitarbeiter.Name = "labMitarbeiter";
            this.labMitarbeiter.Size = new System.Drawing.Size(56, 13);
            this.labMitarbeiter.TabIndex = 7;
            this.labMitarbeiter.Text = "Mitarbeiter";
            // 
            // dtpDatum
            // 
            this.dtpDatum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDatum.Location = new System.Drawing.Point(90, 40);
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.Size = new System.Drawing.Size(671, 20);
            this.dtpDatum.TabIndex = 1;
            this.dtpDatum.Value = new System.DateTime(2019, 10, 23, 15, 43, 34, 0);
            // 
            // cbMitarbeiter
            // 
            this.cbMitarbeiter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMitarbeiter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMitarbeiter.FormattingEnabled = true;
            this.cbMitarbeiter.Location = new System.Drawing.Point(90, 13);
            this.cbMitarbeiter.Name = "cbMitarbeiter";
            this.cbMitarbeiter.Size = new System.Drawing.Size(671, 21);
            this.cbMitarbeiter.TabIndex = 0;
            // 
            // butAbbr
            // 
            this.butAbbr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butAbbr.Location = new System.Drawing.Point(686, 148);
            this.butAbbr.Name = "butAbbr";
            this.butAbbr.Size = new System.Drawing.Size(75, 23);
            this.butAbbr.TabIndex = 6;
            this.butAbbr.Text = "Abbrechen";
            this.butAbbr.UseVisualStyleBackColor = true;
            this.butAbbr.Click += new System.EventHandler(this.ButAbbr_Click);
            // 
            // butSpeichern
            // 
            this.butSpeichern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butSpeichern.Location = new System.Drawing.Point(605, 148);
            this.butSpeichern.Name = "butSpeichern";
            this.butSpeichern.Size = new System.Drawing.Size(75, 23);
            this.butSpeichern.TabIndex = 5;
            this.butSpeichern.Text = "Speichern";
            this.butSpeichern.UseVisualStyleBackColor = true;
            this.butSpeichern.Click += new System.EventHandler(this.ButSpeichern_Click);
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.Location = new System.Drawing.Point(90, 66);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(671, 20);
            this.tbName.TabIndex = 2;
            // 
            // labBeschreibung
            // 
            this.labBeschreibung.AutoSize = true;
            this.labBeschreibung.Location = new System.Drawing.Point(12, 69);
            this.labBeschreibung.Name = "labBeschreibung";
            this.labBeschreibung.Size = new System.Drawing.Size(72, 13);
            this.labBeschreibung.TabIndex = 9;
            this.labBeschreibung.Text = "Beschreibung";
            // 
            // errorInfo
            // 
            this.errorInfo.ContainerControl = this;
            // 
            // dtpStart
            // 
            this.dtpStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(90, 93);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.ShowUpDown = true;
            this.dtpStart.Size = new System.Drawing.Size(671, 20);
            this.dtpStart.TabIndex = 12;
            this.dtpStart.Value = new System.DateTime(2019, 10, 23, 0, 0, 0, 0);
            this.dtpStart.MouseHover += new System.EventHandler(this.DtpStart_MouseHover);
            // 
            // dtpEnde
            // 
            this.dtpEnde.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpEnde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnde.Location = new System.Drawing.Point(90, 119);
            this.dtpEnde.Name = "dtpEnde";
            this.dtpEnde.ShowUpDown = true;
            this.dtpEnde.Size = new System.Drawing.Size(671, 20);
            this.dtpEnde.TabIndex = 13;
            this.dtpEnde.Value = new System.DateTime(2019, 10, 14, 0, 0, 0, 0);
            this.dtpEnde.MouseHover += new System.EventHandler(this.DtpEnde_MouseHover);
            // 
            // suchControl1
            // 
            this.suchControl1.AutoScroll = true;
            this.suchControl1.Location = new System.Drawing.Point(0, 0);
            this.suchControl1.Name = "suchControl1";
            this.suchControl1.Size = new System.Drawing.Size(563, 130);
            this.suchControl1.Spalten = ((System.Collections.Generic.List<string>)(resources.GetObject("suchControl1.Spalten")));
            this.suchControl1.TabIndex = 0;
            // 
            // TaetigkeitView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 183);
            this.Controls.Add(this.dtpEnde);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.labBeschreibung);
            this.Controls.Add(this.butAbbr);
            this.Controls.Add(this.butSpeichern);
            this.Controls.Add(this.labEnde);
            this.Controls.Add(this.labStart);
            this.Controls.Add(this.labDatum);
            this.Controls.Add(this.labMitarbeiter);
            this.Controls.Add(this.dtpDatum);
            this.Controls.Add(this.cbMitarbeiter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(319, 222);
            this.Name = "TaetigkeitView";
            this.Text = "Tätigkeit";
            ((System.ComponentModel.ISupportInitialize)(this.errorInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labEnde;
        private System.Windows.Forms.Label labStart;
        private System.Windows.Forms.Label labDatum;
        private System.Windows.Forms.Label labMitarbeiter;
        private System.Windows.Forms.DateTimePicker dtpDatum;
        private System.Windows.Forms.ComboBox cbMitarbeiter;
        private System.Windows.Forms.Button butAbbr;
        private System.Windows.Forms.Button butSpeichern;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label labBeschreibung;
        private System.Windows.Forms.ErrorProvider errorInfo;
        private System.Windows.Forms.DateTimePicker dtpEnde;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private SuchControl suchControl1;
        private System.Windows.Forms.ToolTip toolTipTaetigkeit;
    }
}