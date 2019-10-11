namespace easyAuftrag.View
{
    partial class CSVConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CSVConfig));
            this.butOK = new System.Windows.Forms.Button();
            this.butAbbrechen = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbKommaDezi = new System.Windows.Forms.RadioButton();
            this.rbPunkt = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbTab = new System.Windows.Forms.RadioButton();
            this.rbSemikolon = new System.Windows.Forms.RadioButton();
            this.rbKomma = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // butOK
            // 
            this.butOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butOK.Location = new System.Drawing.Point(616, 223);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(75, 23);
            this.butOK.TabIndex = 0;
            this.butOK.Text = "OK";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // butAbbrechen
            // 
            this.butAbbrechen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butAbbrechen.Location = new System.Drawing.Point(697, 223);
            this.butAbbrechen.Name = "butAbbrechen";
            this.butAbbrechen.Size = new System.Drawing.Size(75, 23);
            this.butAbbrechen.TabIndex = 1;
            this.butAbbrechen.Text = "Abbrechen";
            this.butAbbrechen.UseVisualStyleBackColor = true;
            this.butAbbrechen.Click += new System.EventHandler(this.butAbbrechen_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbKommaDezi);
            this.groupBox1.Controls.Add(this.rbPunkt);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(759, 86);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dezimaltrenner";
            // 
            // rbKommaDezi
            // 
            this.rbKommaDezi.AutoSize = true;
            this.rbKommaDezi.Checked = true;
            this.rbKommaDezi.Location = new System.Drawing.Point(6, 42);
            this.rbKommaDezi.Name = "rbKommaDezi";
            this.rbKommaDezi.Size = new System.Drawing.Size(99, 17);
            this.rbKommaDezi.TabIndex = 4;
            this.rbKommaDezi.TabStop = true;
            this.rbKommaDezi.Text = "Komma (de-DE)";
            this.rbKommaDezi.UseVisualStyleBackColor = true;
            this.rbKommaDezi.CheckedChanged += new System.EventHandler(this.rbKommaDezi_CheckedChanged);
            // 
            // rbPunkt
            // 
            this.rbPunkt.AutoSize = true;
            this.rbPunkt.Location = new System.Drawing.Point(6, 19);
            this.rbPunkt.Name = "rbPunkt";
            this.rbPunkt.Size = new System.Drawing.Size(92, 17);
            this.rbPunkt.TabIndex = 3;
            this.rbPunkt.Text = "Punkt (en-US)";
            this.rbPunkt.UseVisualStyleBackColor = true;
            this.rbPunkt.CheckedChanged += new System.EventHandler(this.rbPunkt_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbTab);
            this.groupBox2.Controls.Add(this.rbSemikolon);
            this.groupBox2.Controls.Add(this.rbKomma);
            this.groupBox2.Location = new System.Drawing.Point(12, 105);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(760, 110);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datentrenner";
            // 
            // rbTab
            // 
            this.rbTab.AutoSize = true;
            this.rbTab.Location = new System.Drawing.Point(6, 65);
            this.rbTab.Name = "rbTab";
            this.rbTab.Size = new System.Drawing.Size(44, 17);
            this.rbTab.TabIndex = 2;
            this.rbTab.Text = "Tab";
            this.rbTab.UseVisualStyleBackColor = true;
            this.rbTab.CheckedChanged += new System.EventHandler(this.rbTab_CheckedChanged);
            // 
            // rbSemikolon
            // 
            this.rbSemikolon.AutoSize = true;
            this.rbSemikolon.Checked = true;
            this.rbSemikolon.Location = new System.Drawing.Point(6, 42);
            this.rbSemikolon.Name = "rbSemikolon";
            this.rbSemikolon.Size = new System.Drawing.Size(74, 17);
            this.rbSemikolon.TabIndex = 1;
            this.rbSemikolon.TabStop = true;
            this.rbSemikolon.Text = "Semikolon";
            this.rbSemikolon.UseVisualStyleBackColor = true;
            this.rbSemikolon.CheckedChanged += new System.EventHandler(this.rbSemikolon_CheckedChanged);
            // 
            // rbKomma
            // 
            this.rbKomma.AutoSize = true;
            this.rbKomma.Location = new System.Drawing.Point(6, 19);
            this.rbKomma.Name = "rbKomma";
            this.rbKomma.Size = new System.Drawing.Size(60, 17);
            this.rbKomma.TabIndex = 0;
            this.rbKomma.Text = "Komma";
            this.rbKomma.UseVisualStyleBackColor = true;
            this.rbKomma.CheckedChanged += new System.EventHandler(this.rbKomma_CheckedChanged);
            // 
            // CSVConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 258);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.butAbbrechen);
            this.Controls.Add(this.butOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(197, 297);
            this.Name = "CSVConfig";
            this.Text = "CSVConfig";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.Button butAbbrechen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbKommaDezi;
        private System.Windows.Forms.RadioButton rbPunkt;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbTab;
        private System.Windows.Forms.RadioButton rbSemikolon;
        private System.Windows.Forms.RadioButton rbKomma;
    }
}