namespace easyAuftrag.View
{
    partial class ExportView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportView));
            this.butAbbr = new System.Windows.Forms.Button();
            this.butSpeichern = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbJSON = new System.Windows.Forms.RadioButton();
            this.rdbXML = new System.Windows.Forms.RadioButton();
            this.rdbCSV = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbTaetigkeit = new System.Windows.Forms.RadioButton();
            this.rdbMitarbeiter = new System.Windows.Forms.RadioButton();
            this.rdbKunde = new System.Windows.Forms.RadioButton();
            this.rdbAuftrag = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // butAbbr
            // 
            this.butAbbr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butAbbr.Location = new System.Drawing.Point(93, 277);
            this.butAbbr.Name = "butAbbr";
            this.butAbbr.Size = new System.Drawing.Size(75, 23);
            this.butAbbr.TabIndex = 2;
            this.butAbbr.Text = "Abbrechen";
            this.butAbbr.UseVisualStyleBackColor = true;
            this.butAbbr.Click += new System.EventHandler(this.ButAbbr_Click);
            // 
            // butSpeichern
            // 
            this.butSpeichern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butSpeichern.Location = new System.Drawing.Point(12, 277);
            this.butSpeichern.Name = "butSpeichern";
            this.butSpeichern.Size = new System.Drawing.Size(75, 23);
            this.butSpeichern.TabIndex = 1;
            this.butSpeichern.Text = "Speichern";
            this.butSpeichern.UseVisualStyleBackColor = true;
            this.butSpeichern.Click += new System.EventHandler(this.butSpeichern_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbJSON);
            this.groupBox1.Controls.Add(this.rdbXML);
            this.groupBox1.Controls.Add(this.rdbCSV);
            this.groupBox1.Location = new System.Drawing.Point(12, 158);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 113);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Speichern als";
            // 
            // rdbJSON
            // 
            this.rdbJSON.AutoSize = true;
            this.rdbJSON.Location = new System.Drawing.Point(6, 65);
            this.rdbJSON.Name = "rdbJSON";
            this.rdbJSON.Size = new System.Drawing.Size(88, 17);
            this.rdbJSON.TabIndex = 2;
            this.rdbJSON.TabStop = true;
            this.rdbJSON.Text = "JSON (*.json)";
            this.rdbJSON.UseVisualStyleBackColor = true;
            this.rdbJSON.CheckedChanged += new System.EventHandler(this.rdbJSON_CheckedChanged);
            // 
            // rdbXML
            // 
            this.rdbXML.AutoSize = true;
            this.rdbXML.Location = new System.Drawing.Point(6, 42);
            this.rdbXML.Name = "rdbXML";
            this.rdbXML.Size = new System.Drawing.Size(78, 17);
            this.rdbXML.TabIndex = 1;
            this.rdbXML.TabStop = true;
            this.rdbXML.Text = "XML (*.xml)";
            this.rdbXML.UseVisualStyleBackColor = true;
            this.rdbXML.CheckedChanged += new System.EventHandler(this.rdbXML_CheckedChanged);
            // 
            // rdbCSV
            // 
            this.rdbCSV.AutoSize = true;
            this.rdbCSV.Checked = true;
            this.rdbCSV.Location = new System.Drawing.Point(6, 19);
            this.rdbCSV.Name = "rdbCSV";
            this.rdbCSV.Size = new System.Drawing.Size(79, 17);
            this.rdbCSV.TabIndex = 0;
            this.rdbCSV.TabStop = true;
            this.rdbCSV.Text = "CSV (*.csv)";
            this.rdbCSV.UseVisualStyleBackColor = true;
            this.rdbCSV.CheckedChanged += new System.EventHandler(this.rdbCSV_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbTaetigkeit);
            this.groupBox2.Controls.Add(this.rdbMitarbeiter);
            this.groupBox2.Controls.Add(this.rdbKunde);
            this.groupBox2.Controls.Add(this.rdbAuftrag);
            this.groupBox2.Location = new System.Drawing.Point(12, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(156, 139);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Art auswählen";
            // 
            // rdbTaetigkeit
            // 
            this.rdbTaetigkeit.AutoSize = true;
            this.rdbTaetigkeit.Location = new System.Drawing.Point(6, 88);
            this.rdbTaetigkeit.Name = "rdbTaetigkeit";
            this.rdbTaetigkeit.Size = new System.Drawing.Size(78, 17);
            this.rdbTaetigkeit.TabIndex = 6;
            this.rdbTaetigkeit.TabStop = true;
            this.rdbTaetigkeit.Text = "Tätigkeiten";
            this.rdbTaetigkeit.UseVisualStyleBackColor = true;
            this.rdbTaetigkeit.CheckedChanged += new System.EventHandler(this.rdbTaetigkeit_CheckedChanged);
            // 
            // rdbMitarbeiter
            // 
            this.rdbMitarbeiter.AutoSize = true;
            this.rdbMitarbeiter.Location = new System.Drawing.Point(6, 65);
            this.rdbMitarbeiter.Name = "rdbMitarbeiter";
            this.rdbMitarbeiter.Size = new System.Drawing.Size(74, 17);
            this.rdbMitarbeiter.TabIndex = 5;
            this.rdbMitarbeiter.TabStop = true;
            this.rdbMitarbeiter.Text = "Mitarbeiter";
            this.rdbMitarbeiter.UseVisualStyleBackColor = true;
            this.rdbMitarbeiter.CheckedChanged += new System.EventHandler(this.rdbMitarbeiter_CheckedChanged);
            // 
            // rdbKunde
            // 
            this.rdbKunde.AutoSize = true;
            this.rdbKunde.Location = new System.Drawing.Point(6, 42);
            this.rdbKunde.Name = "rdbKunde";
            this.rdbKunde.Size = new System.Drawing.Size(62, 17);
            this.rdbKunde.TabIndex = 4;
            this.rdbKunde.TabStop = true;
            this.rdbKunde.Text = "Kunden";
            this.rdbKunde.UseVisualStyleBackColor = true;
            this.rdbKunde.CheckedChanged += new System.EventHandler(this.rdbKunde_CheckedChanged);
            // 
            // rdbAuftrag
            // 
            this.rdbAuftrag.AutoSize = true;
            this.rdbAuftrag.Checked = true;
            this.rdbAuftrag.Location = new System.Drawing.Point(6, 19);
            this.rdbAuftrag.Name = "rdbAuftrag";
            this.rdbAuftrag.Size = new System.Drawing.Size(65, 17);
            this.rdbAuftrag.TabIndex = 3;
            this.rdbAuftrag.TabStop = true;
            this.rdbAuftrag.Text = "Aufträge";
            this.rdbAuftrag.UseVisualStyleBackColor = true;
            this.rdbAuftrag.CheckedChanged += new System.EventHandler(this.rdbAuftrag_CheckedChanged);
            // 
            // ExportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(180, 312);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.butAbbr);
            this.Controls.Add(this.butSpeichern);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(196, 351);
            this.Name = "ExportView";
            this.Text = "Export";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butAbbr;
        private System.Windows.Forms.Button butSpeichern;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbJSON;
        private System.Windows.Forms.RadioButton rdbXML;
        private System.Windows.Forms.RadioButton rdbCSV;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbTaetigkeit;
        private System.Windows.Forms.RadioButton rdbMitarbeiter;
        private System.Windows.Forms.RadioButton rdbKunde;
        private System.Windows.Forms.RadioButton rdbAuftrag;
    }
}