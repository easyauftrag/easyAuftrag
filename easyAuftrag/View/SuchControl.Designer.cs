namespace easyAuftrag.View
{
    partial class SuchControl
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbErledigt = new System.Windows.Forms.CheckBox();
            this.cbAbgerechnet = new System.Windows.Forms.CheckBox();
            this.tbSuche = new System.Windows.Forms.TextBox();
            this.dtpAnfangEingang = new System.Windows.Forms.DateTimePicker();
            this.dtpEndeEingang = new System.Windows.Forms.DateTimePicker();
            this.butSuche = new System.Windows.Forms.Button();
            this.dtpAnfangErteilt = new System.Windows.Forms.DateTimePicker();
            this.dtpEndeErteilt = new System.Windows.Forms.DateTimePicker();
            this.labEingang = new System.Windows.Forms.Label();
            this.labErteilt = new System.Windows.Forms.Label();
            this.labText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbErledigt
            // 
            this.cbErledigt.AutoSize = true;
            this.cbErledigt.Location = new System.Drawing.Point(3, 3);
            this.cbErledigt.Name = "cbErledigt";
            this.cbErledigt.Size = new System.Drawing.Size(110, 17);
            this.cbErledigt.TabIndex = 0;
            this.cbErledigt.Text = "Erledigte Aufträge";
            this.cbErledigt.UseVisualStyleBackColor = true;
            this.cbErledigt.CheckedChanged += new System.EventHandler(this.CbErledigt_CheckedChanged);
            // 
            // cbAbgerechnet
            // 
            this.cbAbgerechnet.AutoSize = true;
            this.cbAbgerechnet.Location = new System.Drawing.Point(3, 26);
            this.cbAbgerechnet.Name = "cbAbgerechnet";
            this.cbAbgerechnet.Size = new System.Drawing.Size(163, 17);
            this.cbAbgerechnet.TabIndex = 1;
            this.cbAbgerechnet.Text = "Nicht abgerechnete Aufträge";
            this.cbAbgerechnet.UseVisualStyleBackColor = true;
            this.cbAbgerechnet.CheckedChanged += new System.EventHandler(this.CbAbgerechnet_CheckedChanged);
            // 
            // tbSuche
            // 
            this.tbSuche.Location = new System.Drawing.Point(172, 23);
            this.tbSuche.Name = "tbSuche";
            this.tbSuche.Size = new System.Drawing.Size(200, 20);
            this.tbSuche.TabIndex = 2;
            // 
            // dtpAnfangEingang
            // 
            this.dtpAnfangEingang.Location = new System.Drawing.Point(2, 62);
            this.dtpAnfangEingang.Name = "dtpAnfangEingang";
            this.dtpAnfangEingang.Size = new System.Drawing.Size(200, 20);
            this.dtpAnfangEingang.TabIndex = 3;
            // 
            // dtpEndeEingang
            // 
            this.dtpEndeEingang.Location = new System.Drawing.Point(208, 62);
            this.dtpEndeEingang.Name = "dtpEndeEingang";
            this.dtpEndeEingang.Size = new System.Drawing.Size(200, 20);
            this.dtpEndeEingang.TabIndex = 4;
            // 
            // butSuche
            // 
            this.butSuche.Location = new System.Drawing.Point(378, 23);
            this.butSuche.Name = "butSuche";
            this.butSuche.Size = new System.Drawing.Size(75, 23);
            this.butSuche.TabIndex = 5;
            this.butSuche.Text = "Suchen";
            this.butSuche.UseVisualStyleBackColor = true;
            this.butSuche.Click += new System.EventHandler(this.ButSuche_Click);
            // 
            // dtpAnfangErteilt
            // 
            this.dtpAnfangErteilt.Location = new System.Drawing.Point(2, 101);
            this.dtpAnfangErteilt.Name = "dtpAnfangErteilt";
            this.dtpAnfangErteilt.Size = new System.Drawing.Size(200, 20);
            this.dtpAnfangErteilt.TabIndex = 6;
            // 
            // dtpEndeErteilt
            // 
            this.dtpEndeErteilt.Location = new System.Drawing.Point(208, 101);
            this.dtpEndeErteilt.Name = "dtpEndeErteilt";
            this.dtpEndeErteilt.Size = new System.Drawing.Size(200, 20);
            this.dtpEndeErteilt.TabIndex = 7;
            // 
            // labEingang
            // 
            this.labEingang.AutoSize = true;
            this.labEingang.Location = new System.Drawing.Point(0, 46);
            this.labEingang.Name = "labEingang";
            this.labEingang.Size = new System.Drawing.Size(83, 13);
            this.labEingang.TabIndex = 8;
            this.labEingang.Text = "Eingangsdatum:";
            // 
            // labErteilt
            // 
            this.labErteilt.AutoSize = true;
            this.labErteilt.Location = new System.Drawing.Point(0, 85);
            this.labErteilt.Name = "labErteilt";
            this.labErteilt.Size = new System.Drawing.Size(85, 13);
            this.labErteilt.TabIndex = 9;
            this.labErteilt.Text = "Erteilungsdatum:";
            // 
            // labText
            // 
            this.labText.AutoSize = true;
            this.labText.Location = new System.Drawing.Point(172, 4);
            this.labText.Name = "labText";
            this.labText.Size = new System.Drawing.Size(86, 13);
            this.labText.TabIndex = 10;
            this.labText.Text = "Auftrag / Kunde:";
            // 
            // SuchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labText);
            this.Controls.Add(this.labErteilt);
            this.Controls.Add(this.labEingang);
            this.Controls.Add(this.dtpEndeErteilt);
            this.Controls.Add(this.dtpAnfangErteilt);
            this.Controls.Add(this.butSuche);
            this.Controls.Add(this.dtpEndeEingang);
            this.Controls.Add(this.dtpAnfangEingang);
            this.Controls.Add(this.tbSuche);
            this.Controls.Add(this.cbAbgerechnet);
            this.Controls.Add(this.cbErledigt);
            this.Name = "SuchControl";
            this.Size = new System.Drawing.Size(455, 130);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbErledigt;
        private System.Windows.Forms.CheckBox cbAbgerechnet;
        private System.Windows.Forms.TextBox tbSuche;
        private System.Windows.Forms.DateTimePicker dtpAnfangEingang;
        private System.Windows.Forms.DateTimePicker dtpEndeEingang;
        private System.Windows.Forms.Button butSuche;
        private System.Windows.Forms.DateTimePicker dtpAnfangErteilt;
        private System.Windows.Forms.DateTimePicker dtpEndeErteilt;
        private System.Windows.Forms.Label labEingang;
        private System.Windows.Forms.Label labErteilt;
        private System.Windows.Forms.Label labText;
    }
}
