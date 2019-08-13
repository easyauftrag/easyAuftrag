﻿namespace easyAuftrag.View
{
    partial class AuftragView
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
            this.butAbbr = new System.Windows.Forms.Button();
            this.butSpeichern = new System.Windows.Forms.Button();
            this.tbAuftragNr = new System.Windows.Forms.TextBox();
            this.cbKunde = new System.Windows.Forms.ComboBox();
            this.dtpEingang = new System.Windows.Forms.DateTimePicker();
            this.dtpErteilt = new System.Windows.Forms.DateTimePicker();
            this.tbGesamt = new System.Windows.Forms.TextBox();
            this.cbErledigt = new System.Windows.Forms.CheckBox();
            this.labAuftrag = new System.Windows.Forms.Label();
            this.labKunde = new System.Windows.Forms.Label();
            this.labEingang = new System.Windows.Forms.Label();
            this.labErteilt = new System.Windows.Forms.Label();
            this.labGesamt = new System.Windows.Forms.Label();
            this.dgvAuftrag = new System.Windows.Forms.DataGridView();
            this.butNeueTaetigkeit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuftrag)).BeginInit();
            this.SuspendLayout();
            // 
            // butAbbr
            // 
            this.butAbbr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butAbbr.Location = new System.Drawing.Point(312, 382);
            this.butAbbr.Name = "butAbbr";
            this.butAbbr.Size = new System.Drawing.Size(75, 23);
            this.butAbbr.TabIndex = 7;
            this.butAbbr.Text = "Abbrechen";
            this.butAbbr.UseVisualStyleBackColor = true;
            this.butAbbr.Click += new System.EventHandler(this.ButAbbr_Click);
            // 
            // butSpeichern
            // 
            this.butSpeichern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butSpeichern.Location = new System.Drawing.Point(231, 382);
            this.butSpeichern.Name = "butSpeichern";
            this.butSpeichern.Size = new System.Drawing.Size(75, 23);
            this.butSpeichern.TabIndex = 6;
            this.butSpeichern.Text = "Speichern";
            this.butSpeichern.UseVisualStyleBackColor = true;
            this.butSpeichern.Click += new System.EventHandler(this.ButSpeichern_Click);
            // 
            // tbAuftragNr
            // 
            this.tbAuftragNr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAuftragNr.Location = new System.Drawing.Point(103, 13);
            this.tbAuftragNr.Name = "tbAuftragNr";
            this.tbAuftragNr.Size = new System.Drawing.Size(284, 20);
            this.tbAuftragNr.TabIndex = 0;
            // 
            // cbKunde
            // 
            this.cbKunde.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbKunde.FormattingEnabled = true;
            this.cbKunde.Location = new System.Drawing.Point(103, 40);
            this.cbKunde.Name = "cbKunde";
            this.cbKunde.Size = new System.Drawing.Size(284, 21);
            this.cbKunde.TabIndex = 1;
            // 
            // dtpEingang
            // 
            this.dtpEingang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpEingang.Location = new System.Drawing.Point(103, 67);
            this.dtpEingang.Name = "dtpEingang";
            this.dtpEingang.Size = new System.Drawing.Size(284, 20);
            this.dtpEingang.TabIndex = 2;
            // 
            // dtpErteilt
            // 
            this.dtpErteilt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpErteilt.Location = new System.Drawing.Point(103, 94);
            this.dtpErteilt.Name = "dtpErteilt";
            this.dtpErteilt.Size = new System.Drawing.Size(284, 20);
            this.dtpErteilt.TabIndex = 3;
            // 
            // tbGesamt
            // 
            this.tbGesamt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGesamt.Location = new System.Drawing.Point(103, 121);
            this.tbGesamt.Name = "tbGesamt";
            this.tbGesamt.ReadOnly = true;
            this.tbGesamt.Size = new System.Drawing.Size(284, 20);
            this.tbGesamt.TabIndex = 13;
            // 
            // cbErledigt
            // 
            this.cbErledigt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbErledigt.AutoSize = true;
            this.cbErledigt.Location = new System.Drawing.Point(16, 155);
            this.cbErledigt.Name = "cbErledigt";
            this.cbErledigt.Size = new System.Drawing.Size(61, 17);
            this.cbErledigt.TabIndex = 4;
            this.cbErledigt.Text = "Erledigt";
            this.cbErledigt.UseVisualStyleBackColor = true;
            // 
            // labAuftrag
            // 
            this.labAuftrag.AutoSize = true;
            this.labAuftrag.Location = new System.Drawing.Point(13, 19);
            this.labAuftrag.Name = "labAuftrag";
            this.labAuftrag.Size = new System.Drawing.Size(58, 13);
            this.labAuftrag.TabIndex = 8;
            this.labAuftrag.Text = "Auftragsnr.";
            // 
            // labKunde
            // 
            this.labKunde.AutoSize = true;
            this.labKunde.Location = new System.Drawing.Point(13, 48);
            this.labKunde.Name = "labKunde";
            this.labKunde.Size = new System.Drawing.Size(38, 13);
            this.labKunde.TabIndex = 9;
            this.labKunde.Text = "Kunde";
            // 
            // labEingang
            // 
            this.labEingang.AutoSize = true;
            this.labEingang.Location = new System.Drawing.Point(13, 74);
            this.labEingang.Name = "labEingang";
            this.labEingang.Size = new System.Drawing.Size(80, 13);
            this.labEingang.TabIndex = 10;
            this.labEingang.Text = "Eingangsdatum";
            // 
            // labErteilt
            // 
            this.labErteilt.AutoSize = true;
            this.labErteilt.Location = new System.Drawing.Point(13, 101);
            this.labErteilt.Name = "labErteilt";
            this.labErteilt.Size = new System.Drawing.Size(82, 13);
            this.labErteilt.TabIndex = 11;
            this.labErteilt.Text = "Erteilungsdatum";
            // 
            // labGesamt
            // 
            this.labGesamt.AutoSize = true;
            this.labGesamt.Location = new System.Drawing.Point(16, 127);
            this.labGesamt.Name = "labGesamt";
            this.labGesamt.Size = new System.Drawing.Size(81, 13);
            this.labGesamt.TabIndex = 12;
            this.labGesamt.Text = "Gesamtstunden";
            // 
            // dgvAuftrag
            // 
            this.dgvAuftrag.AllowUserToAddRows = false;
            this.dgvAuftrag.AllowUserToDeleteRows = false;
            this.dgvAuftrag.AllowUserToOrderColumns = true;
            this.dgvAuftrag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAuftrag.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAuftrag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAuftrag.Location = new System.Drawing.Point(13, 178);
            this.dgvAuftrag.Name = "dgvAuftrag";
            this.dgvAuftrag.Size = new System.Drawing.Size(374, 198);
            this.dgvAuftrag.TabIndex = 14;
            // 
            // butNeueTaetigkeit
            // 
            this.butNeueTaetigkeit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butNeueTaetigkeit.Location = new System.Drawing.Point(13, 382);
            this.butNeueTaetigkeit.Name = "butNeueTaetigkeit";
            this.butNeueTaetigkeit.Size = new System.Drawing.Size(99, 23);
            this.butNeueTaetigkeit.TabIndex = 5;
            this.butNeueTaetigkeit.Text = "neue Tätigkeit";
            this.butNeueTaetigkeit.UseVisualStyleBackColor = true;
            this.butNeueTaetigkeit.Click += new System.EventHandler(this.ButNeueTaetigkeit_Click);
            // 
            // AuftragView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 417);
            this.Controls.Add(this.butNeueTaetigkeit);
            this.Controls.Add(this.dgvAuftrag);
            this.Controls.Add(this.labGesamt);
            this.Controls.Add(this.labErteilt);
            this.Controls.Add(this.labEingang);
            this.Controls.Add(this.labKunde);
            this.Controls.Add(this.labAuftrag);
            this.Controls.Add(this.cbErledigt);
            this.Controls.Add(this.tbGesamt);
            this.Controls.Add(this.dtpErteilt);
            this.Controls.Add(this.dtpEingang);
            this.Controls.Add(this.cbKunde);
            this.Controls.Add(this.tbAuftragNr);
            this.Controls.Add(this.butAbbr);
            this.Controls.Add(this.butSpeichern);
            this.Name = "AuftragView";
            this.Text = "Auftrag";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuftrag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butAbbr;
        private System.Windows.Forms.Button butSpeichern;
        private System.Windows.Forms.TextBox tbAuftragNr;
        private System.Windows.Forms.ComboBox cbKunde;
        private System.Windows.Forms.DateTimePicker dtpEingang;
        private System.Windows.Forms.DateTimePicker dtpErteilt;
        private System.Windows.Forms.TextBox tbGesamt;
        private System.Windows.Forms.CheckBox cbErledigt;
        private System.Windows.Forms.Label labAuftrag;
        private System.Windows.Forms.Label labKunde;
        private System.Windows.Forms.Label labEingang;
        private System.Windows.Forms.Label labErteilt;
        private System.Windows.Forms.Label labGesamt;
        private System.Windows.Forms.DataGridView dgvAuftrag;
        private System.Windows.Forms.Button butNeueTaetigkeit;
    }
}