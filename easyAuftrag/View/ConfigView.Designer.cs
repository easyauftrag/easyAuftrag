namespace easyAuftrag.View
{
    partial class ConfigView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigView));
            this.tcConfig = new System.Windows.Forms.TabControl();
            this.tpAllg = new System.Windows.Forms.TabPage();
            this.butExport = new System.Windows.Forms.Button();
            this.tbExport = new System.Windows.Forms.TextBox();
            this.labExport = new System.Windows.Forms.Label();
            this.tbSoll = new System.Windows.Forms.TextBox();
            this.labSoll = new System.Windows.Forms.Label();
            this.tbDB = new System.Windows.Forms.TabPage();
            this.gBoxDB = new System.Windows.Forms.GroupBox();
            this.butDB = new System.Windows.Forms.Button();
            this.butServer = new System.Windows.Forms.Button();
            this.cmbDB = new System.Windows.Forms.ComboBox();
            this.cmbServer = new System.Windows.Forms.ComboBox();
            this.tbPW = new System.Windows.Forms.TextBox();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.rdbSQL = new System.Windows.Forms.RadioButton();
            this.rdbWin = new System.Windows.Forms.RadioButton();
            this.labPW = new System.Windows.Forms.Label();
            this.labUser = new System.Windows.Forms.Label();
            this.labDB = new System.Windows.Forms.Label();
            this.labServer = new System.Windows.Forms.Label();
            this.butAbbr = new System.Windows.Forms.Button();
            this.butOK = new System.Windows.Forms.Button();
            this.fbdExport = new System.Windows.Forms.FolderBrowserDialog();
            this.errorInfo = new System.Windows.Forms.ErrorProvider(this.components);
            this.tcConfig.SuspendLayout();
            this.tpAllg.SuspendLayout();
            this.tbDB.SuspendLayout();
            this.gBoxDB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // tcConfig
            // 
            this.tcConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcConfig.Controls.Add(this.tpAllg);
            this.tcConfig.Controls.Add(this.tbDB);
            this.tcConfig.Location = new System.Drawing.Point(13, 13);
            this.tcConfig.Name = "tcConfig";
            this.tcConfig.SelectedIndex = 0;
            this.tcConfig.Size = new System.Drawing.Size(759, 211);
            this.tcConfig.TabIndex = 0;
            // 
            // tpAllg
            // 
            this.tpAllg.Controls.Add(this.butExport);
            this.tpAllg.Controls.Add(this.tbExport);
            this.tpAllg.Controls.Add(this.labExport);
            this.tpAllg.Controls.Add(this.tbSoll);
            this.tpAllg.Controls.Add(this.labSoll);
            this.tpAllg.Location = new System.Drawing.Point(4, 22);
            this.tpAllg.Name = "tpAllg";
            this.tpAllg.Padding = new System.Windows.Forms.Padding(3);
            this.tpAllg.Size = new System.Drawing.Size(751, 185);
            this.tpAllg.TabIndex = 1;
            this.tpAllg.Text = "Allgemein";
            this.tpAllg.UseVisualStyleBackColor = true;
            // 
            // butExport
            // 
            this.butExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butExport.Location = new System.Drawing.Point(718, 40);
            this.butExport.Name = "butExport";
            this.butExport.Size = new System.Drawing.Size(27, 23);
            this.butExport.TabIndex = 4;
            this.butExport.Text = "...";
            this.butExport.UseVisualStyleBackColor = true;
            this.butExport.Click += new System.EventHandler(this.ButExport_Click);
            // 
            // tbExport
            // 
            this.tbExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbExport.Location = new System.Drawing.Point(90, 42);
            this.tbExport.Name = "tbExport";
            this.tbExport.Size = new System.Drawing.Size(622, 20);
            this.tbExport.TabIndex = 3;
            // 
            // labExport
            // 
            this.labExport.AutoSize = true;
            this.labExport.Location = new System.Drawing.Point(6, 45);
            this.labExport.Name = "labExport";
            this.labExport.Size = new System.Drawing.Size(62, 13);
            this.labExport.TabIndex = 2;
            this.labExport.Text = "Export Pfad";
            // 
            // tbSoll
            // 
            this.tbSoll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSoll.Location = new System.Drawing.Point(90, 11);
            this.tbSoll.Name = "tbSoll";
            this.tbSoll.Size = new System.Drawing.Size(622, 20);
            this.tbSoll.TabIndex = 1;
            // 
            // labSoll
            // 
            this.labSoll.AutoSize = true;
            this.labSoll.Location = new System.Drawing.Point(6, 14);
            this.labSoll.Name = "labSoll";
            this.labSoll.Size = new System.Drawing.Size(62, 13);
            this.labSoll.TabIndex = 0;
            this.labSoll.Text = "Sollstunden";
            // 
            // tbDB
            // 
            this.tbDB.Controls.Add(this.gBoxDB);
            this.tbDB.Location = new System.Drawing.Point(4, 22);
            this.tbDB.Name = "tbDB";
            this.tbDB.Padding = new System.Windows.Forms.Padding(3);
            this.tbDB.Size = new System.Drawing.Size(751, 185);
            this.tbDB.TabIndex = 0;
            this.tbDB.Text = "Datenbank";
            this.tbDB.UseVisualStyleBackColor = true;
            // 
            // gBoxDB
            // 
            this.gBoxDB.Controls.Add(this.butDB);
            this.gBoxDB.Controls.Add(this.butServer);
            this.gBoxDB.Controls.Add(this.cmbDB);
            this.gBoxDB.Controls.Add(this.cmbServer);
            this.gBoxDB.Controls.Add(this.tbPW);
            this.gBoxDB.Controls.Add(this.tbUser);
            this.gBoxDB.Controls.Add(this.rdbSQL);
            this.gBoxDB.Controls.Add(this.rdbWin);
            this.gBoxDB.Controls.Add(this.labPW);
            this.gBoxDB.Controls.Add(this.labUser);
            this.gBoxDB.Controls.Add(this.labDB);
            this.gBoxDB.Controls.Add(this.labServer);
            this.gBoxDB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBoxDB.Location = new System.Drawing.Point(3, 3);
            this.gBoxDB.Name = "gBoxDB";
            this.gBoxDB.Size = new System.Drawing.Size(745, 179);
            this.gBoxDB.TabIndex = 2;
            this.gBoxDB.TabStop = false;
            // 
            // butDB
            // 
            this.butDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butDB.Location = new System.Drawing.Point(712, 144);
            this.butDB.Name = "butDB";
            this.butDB.Size = new System.Drawing.Size(27, 23);
            this.butDB.TabIndex = 11;
            this.butDB.Text = "...";
            this.butDB.UseVisualStyleBackColor = true;
            this.butDB.Click += new System.EventHandler(this.ButDB_Click);
            // 
            // butServer
            // 
            this.butServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butServer.Location = new System.Drawing.Point(712, 15);
            this.butServer.Name = "butServer";
            this.butServer.Size = new System.Drawing.Size(27, 23);
            this.butServer.TabIndex = 10;
            this.butServer.Text = "...";
            this.butServer.UseVisualStyleBackColor = true;
            this.butServer.Click += new System.EventHandler(this.ButServer_Click);
            // 
            // cmbDB
            // 
            this.cmbDB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDB.FormattingEnabled = true;
            this.cmbDB.Location = new System.Drawing.Point(90, 146);
            this.cmbDB.Name = "cmbDB";
            this.cmbDB.Size = new System.Drawing.Size(616, 21);
            this.cmbDB.TabIndex = 9;
            // 
            // cmbServer
            // 
            this.cmbServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbServer.FormattingEnabled = true;
            this.cmbServer.Location = new System.Drawing.Point(90, 17);
            this.cmbServer.Name = "cmbServer";
            this.cmbServer.Size = new System.Drawing.Size(616, 21);
            this.cmbServer.TabIndex = 8;
            // 
            // tbPW
            // 
            this.tbPW.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPW.Location = new System.Drawing.Point(90, 120);
            this.tbPW.Name = "tbPW";
            this.tbPW.PasswordChar = '*';
            this.tbPW.Size = new System.Drawing.Size(616, 20);
            this.tbPW.TabIndex = 7;
            // 
            // tbUser
            // 
            this.tbUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUser.Location = new System.Drawing.Point(90, 94);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(616, 20);
            this.tbUser.TabIndex = 6;
            // 
            // rdbSQL
            // 
            this.rdbSQL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbSQL.AutoSize = true;
            this.rdbSQL.Location = new System.Drawing.Point(90, 71);
            this.rdbSQL.Name = "rdbSQL";
            this.rdbSQL.Size = new System.Drawing.Size(146, 17);
            this.rdbSQL.TabIndex = 5;
            this.rdbSQL.Text = "SQL-Server-Authentifiziert";
            this.rdbSQL.UseVisualStyleBackColor = true;
            this.rdbSQL.CheckedChanged += new System.EventHandler(this.RdbSQL_CheckedChanged);
            // 
            // rdbWin
            // 
            this.rdbWin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbWin.AutoSize = true;
            this.rdbWin.Checked = true;
            this.rdbWin.Location = new System.Drawing.Point(90, 48);
            this.rdbWin.Name = "rdbWin";
            this.rdbWin.Size = new System.Drawing.Size(130, 17);
            this.rdbWin.TabIndex = 4;
            this.rdbWin.TabStop = true;
            this.rdbWin.Text = "Window-Authentifiziert";
            this.rdbWin.UseVisualStyleBackColor = true;
            this.rdbWin.CheckedChanged += new System.EventHandler(this.RdbWin_CheckedChanged);
            // 
            // labPW
            // 
            this.labPW.AutoSize = true;
            this.labPW.Location = new System.Drawing.Point(6, 123);
            this.labPW.Name = "labPW";
            this.labPW.Size = new System.Drawing.Size(50, 13);
            this.labPW.TabIndex = 3;
            this.labPW.Text = "Passwort";
            // 
            // labUser
            // 
            this.labUser.AutoSize = true;
            this.labUser.Location = new System.Drawing.Point(6, 97);
            this.labUser.Name = "labUser";
            this.labUser.Size = new System.Drawing.Size(75, 13);
            this.labUser.TabIndex = 2;
            this.labUser.Text = "Benutzername";
            // 
            // labDB
            // 
            this.labDB.AutoSize = true;
            this.labDB.Location = new System.Drawing.Point(6, 149);
            this.labDB.Name = "labDB";
            this.labDB.Size = new System.Drawing.Size(60, 13);
            this.labDB.TabIndex = 1;
            this.labDB.Text = "Datenbank";
            // 
            // labServer
            // 
            this.labServer.AutoSize = true;
            this.labServer.Location = new System.Drawing.Point(6, 20);
            this.labServer.Name = "labServer";
            this.labServer.Size = new System.Drawing.Size(38, 13);
            this.labServer.TabIndex = 0;
            this.labServer.Text = "Server";
            // 
            // butAbbr
            // 
            this.butAbbr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butAbbr.Location = new System.Drawing.Point(697, 236);
            this.butAbbr.Name = "butAbbr";
            this.butAbbr.Size = new System.Drawing.Size(75, 23);
            this.butAbbr.TabIndex = 1;
            this.butAbbr.Text = "Abbrechen";
            this.butAbbr.UseVisualStyleBackColor = true;
            this.butAbbr.Click += new System.EventHandler(this.ButAbbr_Click);
            // 
            // butOK
            // 
            this.butOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butOK.Location = new System.Drawing.Point(616, 236);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(75, 23);
            this.butOK.TabIndex = 2;
            this.butOK.Text = "OK";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.ButOK_Click);
            // 
            // errorInfo
            // 
            this.errorInfo.ContainerControl = this;
            // 
            // ConfigView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 271);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.butAbbr);
            this.Controls.Add(this.tcConfig);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "ConfigView";
            this.Text = "ConfigView";
            this.tcConfig.ResumeLayout(false);
            this.tpAllg.ResumeLayout(false);
            this.tpAllg.PerformLayout();
            this.tbDB.ResumeLayout(false);
            this.gBoxDB.ResumeLayout(false);
            this.gBoxDB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcConfig;
        private System.Windows.Forms.TabPage tbDB;
        private System.Windows.Forms.TabPage tpAllg;
        private System.Windows.Forms.Button butAbbr;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.Button butExport;
        private System.Windows.Forms.TextBox tbExport;
        private System.Windows.Forms.Label labExport;
        private System.Windows.Forms.TextBox tbSoll;
        private System.Windows.Forms.Label labSoll;
        private System.Windows.Forms.FolderBrowserDialog fbdExport;
        private System.Windows.Forms.GroupBox gBoxDB;
        private System.Windows.Forms.Button butDB;
        private System.Windows.Forms.Button butServer;
        private System.Windows.Forms.ComboBox cmbDB;
        private System.Windows.Forms.ComboBox cmbServer;
        private System.Windows.Forms.TextBox tbPW;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.RadioButton rdbSQL;
        private System.Windows.Forms.RadioButton rdbWin;
        private System.Windows.Forms.Label labPW;
        private System.Windows.Forms.Label labUser;
        private System.Windows.Forms.Label labDB;
        private System.Windows.Forms.Label labServer;
        private System.Windows.Forms.ErrorProvider errorInfo;
    }
}