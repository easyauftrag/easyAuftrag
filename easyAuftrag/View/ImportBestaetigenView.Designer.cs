namespace easyAuftrag.View
{
    partial class ImportBestaetigenView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportBestaetigenView));
            this.dgvImport = new System.Windows.Forms.DataGridView();
            this.butAbbrechen = new System.Windows.Forms.Button();
            this.butSpeichern = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImport)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvImport
            // 
            this.dgvImport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvImport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImport.Location = new System.Drawing.Point(13, 13);
            this.dgvImport.Name = "dgvImport";
            this.dgvImport.Size = new System.Drawing.Size(747, 357);
            this.dgvImport.TabIndex = 0;
            // 
            // butAbbrechen
            // 
            this.butAbbrechen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butAbbrechen.Location = new System.Drawing.Point(685, 376);
            this.butAbbrechen.Name = "butAbbrechen";
            this.butAbbrechen.Size = new System.Drawing.Size(75, 23);
            this.butAbbrechen.TabIndex = 1;
            this.butAbbrechen.Text = "Abbrechen";
            this.butAbbrechen.UseVisualStyleBackColor = true;
            this.butAbbrechen.Click += new System.EventHandler(this.butAbbrechen_Click);
            // 
            // butSpeichern
            // 
            this.butSpeichern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butSpeichern.Location = new System.Drawing.Point(604, 376);
            this.butSpeichern.Name = "butSpeichern";
            this.butSpeichern.Size = new System.Drawing.Size(75, 23);
            this.butSpeichern.TabIndex = 2;
            this.butSpeichern.Text = "Speichern";
            this.butSpeichern.UseVisualStyleBackColor = true;
            this.butSpeichern.Click += new System.EventHandler(this.butSpeichern_Click);
            // 
            // ImportBestaetigenView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.butSpeichern);
            this.Controls.Add(this.butAbbrechen);
            this.Controls.Add(this.dgvImport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 450);
            this.Name = "ImportBestaetigenView";
            this.Text = "In Datenbank schreiben?";
            ((System.ComponentModel.ISupportInitialize)(this.dgvImport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvImport;
        private System.Windows.Forms.Button butAbbrechen;
        private System.Windows.Forms.Button butSpeichern;
    }
}