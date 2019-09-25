using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Model;

namespace easyAuftrag.View
{
    public partial class ImportBestaetigenView : Form
    {
        public ImportBestaetigenView(object sender)
        {
            InitializeComponent();
            dgvImport.DataSource = sender;
        }

        private void butSpeichern_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void butAbbrechen_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }
    }
}
