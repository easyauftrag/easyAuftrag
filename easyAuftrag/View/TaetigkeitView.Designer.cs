namespace easyAuftrag.View
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
            this.tbEnde = new System.Windows.Forms.TextBox();
            this.dtpDatum = new System.Windows.Forms.DateTimePicker();
            this.cbMitarbeiter = new System.Windows.Forms.ComboBox();
            this.tbStart = new System.Windows.Forms.TextBox();
            this.butAbbr = new System.Windows.Forms.Button();
            this.butSpeichern = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.labBeschreibung = new System.Windows.Forms.Label();
            this.errorInfo = new System.Windows.Forms.ErrorProvider(this.components);
            this.easyAuftragDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyAuftragDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // labEnde
            // 
            this.labEnde.AutoSize = true;
            this.labEnde.Location = new System.Drawing.Point(12, 127);
            this.labEnde.Name = "labEnde";
            this.labEnde.Size = new System.Drawing.Size(42, 13);
            this.labEnde.TabIndex = 11;
            this.labEnde.Text = "Endzeit";
            // 
            // labStart
            // 
            this.labStart.AutoSize = true;
            this.labStart.Location = new System.Drawing.Point(12, 99);
            this.labStart.Name = "labStart";
            this.labStart.Size = new System.Drawing.Size(45, 13);
            this.labStart.TabIndex = 10;
            this.labStart.Text = "Startzeit";
            // 
            // labDatum
            // 
            this.labDatum.AutoSize = true;
            this.labDatum.Location = new System.Drawing.Point(12, 47);
            this.labDatum.Name = "labDatum";
            this.labDatum.Size = new System.Drawing.Size(38, 13);
            this.labDatum.TabIndex = 8;
            this.labDatum.Text = "Datum";
            // 
            // labMitarbeiter
            // 
            this.labMitarbeiter.AutoSize = true;
            this.labMitarbeiter.Location = new System.Drawing.Point(12, 21);
            this.labMitarbeiter.Name = "labMitarbeiter";
            this.labMitarbeiter.Size = new System.Drawing.Size(56, 13);
            this.labMitarbeiter.TabIndex = 7;
            this.labMitarbeiter.Text = "Mitarbeiter";
            // 
            // tbEnde
            // 
            this.tbEnde.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEnde.Location = new System.Drawing.Point(90, 120);
            this.tbEnde.Name = "tbEnde";
            this.tbEnde.Size = new System.Drawing.Size(682, 20);
            this.tbEnde.TabIndex = 4;
            this.tbEnde.Text = "HH:MM";
            this.tbEnde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtpDatum
            // 
            this.dtpDatum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDatum.Location = new System.Drawing.Point(90, 40);
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.Size = new System.Drawing.Size(682, 20);
            this.dtpDatum.TabIndex = 1;
            // 
            // cbMitarbeiter
            // 
            this.cbMitarbeiter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMitarbeiter.FormattingEnabled = true;
            this.cbMitarbeiter.Location = new System.Drawing.Point(90, 13);
            this.cbMitarbeiter.Name = "cbMitarbeiter";
            this.cbMitarbeiter.Size = new System.Drawing.Size(682, 21);
            this.cbMitarbeiter.TabIndex = 0;
            // 
            // tbStart
            // 
            this.tbStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStart.Location = new System.Drawing.Point(90, 92);
            this.tbStart.Name = "tbStart";
            this.tbStart.Size = new System.Drawing.Size(682, 20);
            this.tbStart.TabIndex = 3;
            this.tbStart.Text = "HH:MM";
            this.tbStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // butAbbr
            // 
            this.butAbbr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butAbbr.Location = new System.Drawing.Point(697, 148);
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
            this.butSpeichern.Location = new System.Drawing.Point(616, 148);
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
            this.tbName.Size = new System.Drawing.Size(682, 20);
            this.tbName.TabIndex = 2;
            // 
            // labBeschreibung
            // 
            this.labBeschreibung.AutoSize = true;
            this.labBeschreibung.Location = new System.Drawing.Point(12, 73);
            this.labBeschreibung.Name = "labBeschreibung";
            this.labBeschreibung.Size = new System.Drawing.Size(72, 13);
            this.labBeschreibung.TabIndex = 9;
            this.labBeschreibung.Text = "Beschreibung";
            // 
            // errorInfo
            // 
            this.errorInfo.ContainerControl = this;
            // 
            // TaetigkeitView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 183);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.labBeschreibung);
            this.Controls.Add(this.butAbbr);
            this.Controls.Add(this.butSpeichern);
            this.Controls.Add(this.tbStart);
            this.Controls.Add(this.labEnde);
            this.Controls.Add(this.labStart);
            this.Controls.Add(this.labDatum);
            this.Controls.Add(this.labMitarbeiter);
            this.Controls.Add(this.tbEnde);
            this.Controls.Add(this.dtpDatum);
            this.Controls.Add(this.cbMitarbeiter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(319, 222);
            this.Name = "TaetigkeitView";
            this.Text = "Taetigkeit";
            ((System.ComponentModel.ISupportInitialize)(this.errorInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyAuftragDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labEnde;
        private System.Windows.Forms.Label labStart;
        private System.Windows.Forms.Label labDatum;
        private System.Windows.Forms.Label labMitarbeiter;
        private System.Windows.Forms.TextBox tbEnde;
        private System.Windows.Forms.DateTimePicker dtpDatum;
        private System.Windows.Forms.ComboBox cbMitarbeiter;
        private System.Windows.Forms.TextBox tbStart;
        private System.Windows.Forms.Button butAbbr;
        private System.Windows.Forms.Button butSpeichern;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label labBeschreibung;
        private System.Windows.Forms.ErrorProvider errorInfo;
        private System.Windows.Forms.BindingSource easyAuftragDataSetBindingSource;
    }
}