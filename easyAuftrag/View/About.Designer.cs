namespace easyAuftrag.View
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.linkLicense = new System.Windows.Forms.LinkLabel();
            this.labBoxDLL = new System.Windows.Forms.ListBox();
            this.butOK = new System.Windows.Forms.Button();
            this.labVersion = new System.Windows.Forms.Label();
            this.panName = new System.Windows.Forms.Panel();
            this.labName = new System.Windows.Forms.Label();
            this.labKomp = new System.Windows.Forms.Label();
            this.panName.SuspendLayout();
            this.SuspendLayout();
            // 
            // linkLicense
            // 
            this.linkLicense.AutoSize = true;
            this.linkLicense.Location = new System.Drawing.Point(203, 4);
            this.linkLicense.Name = "linkLicense";
            this.linkLicense.Size = new System.Drawing.Size(37, 13);
            this.linkLicense.TabIndex = 2;
            this.linkLicense.TabStop = true;
            this.linkLicense.Text = "Lizenz";
            this.linkLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLicense_LinkClicked);
            // 
            // labBoxDLL
            // 
            this.labBoxDLL.FormattingEnabled = true;
            this.labBoxDLL.Location = new System.Drawing.Point(12, 154);
            this.labBoxDLL.Name = "labBoxDLL";
            this.labBoxDLL.Size = new System.Drawing.Size(243, 95);
            this.labBoxDLL.TabIndex = 3;
            // 
            // butOK
            // 
            this.butOK.Location = new System.Drawing.Point(180, 255);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(75, 23);
            this.butOK.TabIndex = 4;
            this.butOK.Text = "OK";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // labVersion
            // 
            this.labVersion.AutoSize = true;
            this.labVersion.Location = new System.Drawing.Point(12, 63);
            this.labVersion.Name = "labVersion";
            this.labVersion.Size = new System.Drawing.Size(63, 13);
            this.labVersion.TabIndex = 5;
            this.labVersion.Text = "easyAuftrag";
            // 
            // panName
            // 
            this.panName.Controls.Add(this.labName);
            this.panName.Controls.Add(this.linkLicense);
            this.panName.Location = new System.Drawing.Point(12, 12);
            this.panName.Name = "panName";
            this.panName.Size = new System.Drawing.Size(243, 48);
            this.panName.TabIndex = 6;
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labName.Location = new System.Drawing.Point(6, 4);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(171, 31);
            this.labName.TabIndex = 6;
            this.labName.Text = "easyAuftrag";
            // 
            // labKomp
            // 
            this.labKomp.AutoSize = true;
            this.labKomp.Location = new System.Drawing.Point(13, 135);
            this.labKomp.Name = "labKomp";
            this.labKomp.Size = new System.Drawing.Size(136, 13);
            this.labKomp.TabIndex = 7;
            this.labKomp.Text = "Verwendete Komponenten:";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 290);
            this.Controls.Add(this.labKomp);
            this.Controls.Add(this.panName);
            this.Controls.Add(this.labVersion);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.labBoxDLL);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "About";
            this.Text = "Info";
            this.Load += new System.EventHandler(this.About_Load);
            this.panName.ResumeLayout(false);
            this.panName.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLicense;
        private System.Windows.Forms.ListBox labBoxDLL;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.Label labVersion;
        private System.Windows.Forms.Panel panName;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.Label labKomp;
    }
}