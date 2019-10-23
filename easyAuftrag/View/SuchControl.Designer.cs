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
            this.cbSuche = new System.Windows.Forms.CheckBox();
            this.tbSuche = new System.Windows.Forms.TextBox();
            this.dtpAnfang = new System.Windows.Forms.DateTimePicker();
            this.dtpEnde = new System.Windows.Forms.DateTimePicker();
            this.butSuche = new System.Windows.Forms.Button();
            this.comboSpalte = new System.Windows.Forms.ComboBox();
            this.labSpalte = new System.Windows.Forms.Label();
            this.labWert = new System.Windows.Forms.Label();
            this.comboLink = new System.Windows.Forms.ComboBox();
            this.labLink = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbSuche
            // 
            this.cbSuche.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSuche.Location = new System.Drawing.Point(208, 17);
            this.cbSuche.Name = "cbSuche";
            this.cbSuche.Size = new System.Drawing.Size(339, 17);
            this.cbSuche.TabIndex = 1;
            this.cbSuche.Text = "Nicht abgerechnete Aufträge";
            this.cbSuche.UseVisualStyleBackColor = true;
            // 
            // tbSuche
            // 
            this.tbSuche.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSuche.Location = new System.Drawing.Point(208, 17);
            this.tbSuche.Name = "tbSuche";
            this.tbSuche.Size = new System.Drawing.Size(339, 20);
            this.tbSuche.TabIndex = 2;
            // 
            // dtpAnfang
            // 
            this.dtpAnfang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpAnfang.Location = new System.Drawing.Point(208, 17);
            this.dtpAnfang.Name = "dtpAnfang";
            this.dtpAnfang.Size = new System.Drawing.Size(166, 20);
            this.dtpAnfang.TabIndex = 3;
            // 
            // dtpEnde
            // 
            this.dtpEnde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpEnde.Location = new System.Drawing.Point(380, 17);
            this.dtpEnde.Name = "dtpEnde";
            this.dtpEnde.Size = new System.Drawing.Size(166, 20);
            this.dtpEnde.TabIndex = 4;
            // 
            // butSuche
            // 
            this.butSuche.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butSuche.Location = new System.Drawing.Point(553, 15);
            this.butSuche.Name = "butSuche";
            this.butSuche.Size = new System.Drawing.Size(75, 23);
            this.butSuche.TabIndex = 5;
            this.butSuche.Text = "Suchen";
            this.butSuche.UseVisualStyleBackColor = true;
            this.butSuche.Click += new System.EventHandler(this.ButSuche_Click);
            // 
            // comboSpalte
            // 
            this.comboSpalte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSpalte.FormattingEnabled = true;
            this.comboSpalte.Location = new System.Drawing.Point(69, 17);
            this.comboSpalte.Name = "comboSpalte";
            this.comboSpalte.Size = new System.Drawing.Size(133, 21);
            this.comboSpalte.TabIndex = 11;
            this.comboSpalte.SelectedIndexChanged += new System.EventHandler(this.ComboSpalte_SelectedIndexChanged);
            // 
            // labSpalte
            // 
            this.labSpalte.AutoSize = true;
            this.labSpalte.Location = new System.Drawing.Point(66, 0);
            this.labSpalte.Name = "labSpalte";
            this.labSpalte.Size = new System.Drawing.Size(37, 13);
            this.labSpalte.TabIndex = 12;
            this.labSpalte.Text = "Spalte";
            // 
            // labWert
            // 
            this.labWert.AutoSize = true;
            this.labWert.Location = new System.Drawing.Point(205, 0);
            this.labWert.Name = "labWert";
            this.labWert.Size = new System.Drawing.Size(30, 13);
            this.labWert.TabIndex = 13;
            this.labWert.Text = "Wert";
            // 
            // comboLink
            // 
            this.comboLink.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLink.FormattingEnabled = true;
            this.comboLink.Location = new System.Drawing.Point(7, 17);
            this.comboLink.Name = "comboLink";
            this.comboLink.Size = new System.Drawing.Size(56, 21);
            this.comboLink.TabIndex = 14;
            // 
            // labLink
            // 
            this.labLink.AutoSize = true;
            this.labLink.Location = new System.Drawing.Point(3, 0);
            this.labLink.Name = "labLink";
            this.labLink.Size = new System.Drawing.Size(62, 13);
            this.labLink.TabIndex = 15;
            this.labLink.Text = "Verküpfung";
            // 
            // SuchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.labLink);
            this.Controls.Add(this.comboLink);
            this.Controls.Add(this.labWert);
            this.Controls.Add(this.labSpalte);
            this.Controls.Add(this.comboSpalte);
            this.Controls.Add(this.butSuche);
            this.Controls.Add(this.dtpEnde);
            this.Controls.Add(this.dtpAnfang);
            this.Controls.Add(this.tbSuche);
            this.Controls.Add(this.cbSuche);
            this.Name = "SuchControl";
            this.Size = new System.Drawing.Size(631, 130);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox cbSuche;
        private System.Windows.Forms.TextBox tbSuche;
        private System.Windows.Forms.DateTimePicker dtpAnfang;
        private System.Windows.Forms.DateTimePicker dtpEnde;
        private System.Windows.Forms.Button butSuche;
        private System.Windows.Forms.ComboBox comboSpalte;
        private System.Windows.Forms.Label labSpalte;
        private System.Windows.Forms.Label labWert;
        private System.Windows.Forms.ComboBox comboLink;
        private System.Windows.Forms.Label labLink;
    }
}
