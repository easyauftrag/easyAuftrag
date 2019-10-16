namespace easyAuftrag.View
{
    partial class LaenderView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaenderView));
            this.butSpeichern = new System.Windows.Forms.Button();
            this.butAbbr = new System.Windows.Forms.Button();
            this.tbVorwahl = new System.Windows.Forms.TextBox();
            this.labVorwahl = new System.Windows.Forms.Label();
            this.labKuerzel = new System.Windows.Forms.Label();
            this.tbKuerzel = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.labName = new System.Windows.Forms.Label();
            this.errorInfo = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // butSpeichern
            // 
            this.butSpeichern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butSpeichern.Location = new System.Drawing.Point(599, 96);
            this.butSpeichern.Name = "butSpeichern";
            this.butSpeichern.Size = new System.Drawing.Size(75, 23);
            this.butSpeichern.TabIndex = 7;
            this.butSpeichern.Text = "Speichern";
            this.butSpeichern.UseVisualStyleBackColor = true;
            this.butSpeichern.Click += new System.EventHandler(this.ButSpeichern_Click);
            // 
            // butAbbr
            // 
            this.butAbbr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butAbbr.Location = new System.Drawing.Point(680, 96);
            this.butAbbr.Name = "butAbbr";
            this.butAbbr.Size = new System.Drawing.Size(75, 23);
            this.butAbbr.TabIndex = 8;
            this.butAbbr.Text = "Abbrechen";
            this.butAbbr.UseVisualStyleBackColor = true;
            this.butAbbr.Click += new System.EventHandler(this.ButAbbr_Click);
            // 
            // tbVorwahl
            // 
            this.tbVorwahl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbVorwahl.Location = new System.Drawing.Point(105, 65);
            this.tbVorwahl.Name = "tbVorwahl";
            this.tbVorwahl.Size = new System.Drawing.Size(650, 20);
            this.tbVorwahl.TabIndex = 2;
            // 
            // labVorwahl
            // 
            this.labVorwahl.AutoSize = true;
            this.labVorwahl.Location = new System.Drawing.Point(12, 68);
            this.labVorwahl.Name = "labVorwahl";
            this.labVorwahl.Size = new System.Drawing.Size(45, 13);
            this.labVorwahl.TabIndex = 11;
            this.labVorwahl.Text = "Vorwahl";
            // 
            // labKuerzel
            // 
            this.labKuerzel.AutoSize = true;
            this.labKuerzel.Location = new System.Drawing.Point(12, 42);
            this.labKuerzel.Name = "labKuerzel";
            this.labKuerzel.Size = new System.Drawing.Size(36, 13);
            this.labKuerzel.TabIndex = 10;
            this.labKuerzel.Text = "Kürzel";
            // 
            // tbKuerzel
            // 
            this.tbKuerzel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbKuerzel.Location = new System.Drawing.Point(105, 39);
            this.tbKuerzel.Name = "tbKuerzel";
            this.tbKuerzel.Size = new System.Drawing.Size(650, 20);
            this.tbKuerzel.TabIndex = 1;
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.Location = new System.Drawing.Point(105, 12);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(650, 20);
            this.tbName.TabIndex = 0;
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Location = new System.Drawing.Point(12, 15);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(35, 13);
            this.labName.TabIndex = 9;
            this.labName.Text = "Name";
            // 
            // errorInfo
            // 
            this.errorInfo.ContainerControl = this;
            // 
            // LaenderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 131);
            this.Controls.Add(this.tbVorwahl);
            this.Controls.Add(this.labVorwahl);
            this.Controls.Add(this.labKuerzel);
            this.Controls.Add(this.tbKuerzel);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.labName);
            this.Controls.Add(this.butAbbr);
            this.Controls.Add(this.butSpeichern);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 170);
            this.Name = "LaenderView";
            this.Text = "Land";
            ((System.ComponentModel.ISupportInitialize)(this.errorInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butSpeichern;
        private System.Windows.Forms.Button butAbbr;
        private System.Windows.Forms.TextBox tbVorwahl;
        private System.Windows.Forms.Label labVorwahl;
        private System.Windows.Forms.Label labKuerzel;
        private System.Windows.Forms.TextBox tbKuerzel;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.ErrorProvider errorInfo;
    }
}