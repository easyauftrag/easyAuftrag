namespace easyAuftrag.View
{
    partial class LaenderConfig
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
            this.dgvLaender = new System.Windows.Forms.DataGridView();
            this.butLand = new System.Windows.Forms.Button();
            this.butOK = new System.Windows.Forms.Button();
            this.cxtLaender = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.neuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loeschenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errProv = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaender)).BeginInit();
            this.cxtLaender.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLaender
            // 
            this.dgvLaender.AllowUserToAddRows = false;
            this.dgvLaender.AllowUserToDeleteRows = false;
            this.dgvLaender.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLaender.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLaender.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLaender.Location = new System.Drawing.Point(12, 12);
            this.dgvLaender.Name = "dgvLaender";
            this.dgvLaender.ReadOnly = true;
            this.dgvLaender.Size = new System.Drawing.Size(760, 368);
            this.dgvLaender.TabIndex = 0;
            this.dgvLaender.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLaender_CellDoubleClick);
            this.dgvLaender.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvLaender_RowHeaderMouseDoubleClick);
            this.dgvLaender.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvLaender_MouseUp);
            // 
            // butLand
            // 
            this.butLand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLand.Location = new System.Drawing.Point(13, 386);
            this.butLand.Name = "butLand";
            this.butLand.Size = new System.Drawing.Size(102, 23);
            this.butLand.TabIndex = 1;
            this.butLand.Text = "Land hinzufügen";
            this.butLand.UseVisualStyleBackColor = true;
            this.butLand.Click += new System.EventHandler(this.butLand_Click);
            // 
            // butOK
            // 
            this.butOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butOK.Location = new System.Drawing.Point(697, 386);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(75, 23);
            this.butOK.TabIndex = 2;
            this.butOK.Text = "OK";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // cxtLaender
            // 
            this.cxtLaender.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neuToolStripMenuItem,
            this.bearbeitenToolStripMenuItem,
            this.loeschenToolStripMenuItem});
            this.cxtLaender.Name = "cxtLaender";
            this.cxtLaender.Size = new System.Drawing.Size(131, 70);
            // 
            // neuToolStripMenuItem
            // 
            this.neuToolStripMenuItem.Name = "neuToolStripMenuItem";
            this.neuToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.neuToolStripMenuItem.Text = "Neu";
            this.neuToolStripMenuItem.Click += new System.EventHandler(this.neuToolStripMenuItem_Click);
            // 
            // bearbeitenToolStripMenuItem
            // 
            this.bearbeitenToolStripMenuItem.Name = "bearbeitenToolStripMenuItem";
            this.bearbeitenToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.bearbeitenToolStripMenuItem.Text = "Bearbeiten";
            this.bearbeitenToolStripMenuItem.Click += new System.EventHandler(this.bearbeitenToolStripMenuItem_Click);
            // 
            // loeschenToolStripMenuItem
            // 
            this.loeschenToolStripMenuItem.Name = "loeschenToolStripMenuItem";
            this.loeschenToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.loeschenToolStripMenuItem.Text = "Löschen";
            this.loeschenToolStripMenuItem.Click += new System.EventHandler(this.loeschenToolStripMenuItem_Click);
            // 
            // errProv
            // 
            this.errProv.ContainerControl = this;
            // 
            // LaenderConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 421);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.butLand);
            this.Controls.Add(this.dgvLaender);
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "LaenderConfig";
            this.Text = "Länder konfigurieren";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaender)).EndInit();
            this.cxtLaender.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errProv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLaender;
        private System.Windows.Forms.Button butLand;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.ContextMenuStrip cxtLaender;
        private System.Windows.Forms.ToolStripMenuItem neuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bearbeitenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loeschenToolStripMenuItem;
        private System.Windows.Forms.ErrorProvider errProv;
    }
}