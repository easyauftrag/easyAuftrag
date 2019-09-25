using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Austausch;

namespace easyAuftrag.View
{
    public partial class CSVConfig : Form
    {

        public CSVConfigTypen Typen { get; set; }

        public CSVConfig()
        {
            InitializeComponent();
            Typen = new CSVConfigTypen();
            Typen.TrennerDezimal = CSVConfigTypen.DezimalTrenner.Komma;
            Typen.TrennerDaten = CSVConfigTypen.DatenTrenner.Semikolon;
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void butAbbrechen_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        #region Dezimaltrenner
        private void rbPunkt_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPunkt.Checked)
            {
                Typen.TrennerDezimal = CSVConfigTypen.DezimalTrenner.Punkt;
            }
        }

        private void rbKommaDezi_CheckedChanged(object sender, EventArgs e)
        {
            if (rbKommaDezi.Checked)
            {
                Typen.TrennerDezimal = CSVConfigTypen.DezimalTrenner.Komma;
            }

        }
        #endregion

        #region Datentrenner
        private void rbKomma_CheckedChanged(object sender, EventArgs e)
        {
            Typen.TrennerDaten = CSVConfigTypen.DatenTrenner.Komma;
        }

        private void rbSemikolon_CheckedChanged(object sender, EventArgs e)
        {
            Typen.TrennerDaten = CSVConfigTypen.DatenTrenner.Semikolon;
        }

        private void rbTab_CheckedChanged(object sender, EventArgs e)
        {
            Typen.TrennerDaten = CSVConfigTypen.DatenTrenner.Tab;
        }
        #endregion
    }
}
