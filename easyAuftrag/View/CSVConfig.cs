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
    /// <summary>
    /// Windows Form zur Auswahl von Daten- und Dezimaltrenner beim Im- und Export von Dateien
    /// </summary>
    public partial class CSVConfig : Form
    {
        /// <summary>
        /// Eigenschaft zum Speichern des Daten- und Dezimaltrenners
        /// </summary>
        public CSVConfigTypen Typen { get; set; }

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="CSVConfig"/> Form
        /// </summary>
        public CSVConfig()
        {
            InitializeComponent();
            // Initialisiert die Eigenschaft Typen mit den Default Werten
            Typen = new CSVConfigTypen(CSVConfigTypen.DezimalTrenner.Komma, CSVConfigTypen.DatenTrenner.Semikolon);
            rbKomma.Enabled = false;
        }

        /// <summary>
        /// Action beim Klick auf den Button "OK"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Action beim Klick auf den Button "Abbrechen"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butAbbrechen_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        #region Dezimaltrenner
        /// <summary>
        /// Action falls Punkt als Dezimaltrenner ausgewählt wird
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <seealso cref="CSVConfigTypen.DezimalTrenner.Punkt"/>
        private void rbPunkt_CheckedChanged(object sender, EventArgs e)
        {
            // Falls der Radiobutton ausgewählt wurde, wird der Dezimaltrenner auf "Punkt" gesetzt
            if (rbPunkt.Checked)
            {
                Typen.TrennerDezimal = CSVConfigTypen.DezimalTrenner.Punkt;
                rbKomma.Enabled = true;
            }
        }


        /// <summary>
        /// Action falls Komma als Dezimaltrenner ausgewählt wird
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <seealso cref="CSVConfigTypen.DezimalTrenner.Komma"/>
        private void rbKommaDezi_CheckedChanged(object sender, EventArgs e)
        {
            // Falls der Radiobutton ausgewählt wurde, wird der Dezimaltrenner auf "Komma" gesetzt
            if (rbKommaDezi.Checked)
            {
                Typen.TrennerDezimal = CSVConfigTypen.DezimalTrenner.Komma;
                rbKomma.Checked = false;
                rbKomma.Enabled = false;
                rbSemikolon.Checked = true;
            }

        }
        #endregion

        #region Datentrenner
        /// <summary>
        /// Action falls Komma als Datentrenner ausgewählt wird
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <seealso cref="CSVConfigTypen.DatenTrenner.Komma"/>
        private void rbKomma_CheckedChanged(object sender, EventArgs e)
        {
            // Falls der Radiobutton ausgewählt wurde, wird der Datentrenner auf "Komma" gesetzt
            if (rbKomma.Checked)
            {
                Typen.TrennerDaten = CSVConfigTypen.DatenTrenner.Komma;
            }
        }

        /// <summary>
        /// Action falls Semikolon als Datentrenner ausgewählt wird
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <seealso cref="CSVConfigTypen.DatenTrenner.Semikolon"/>
        private void rbSemikolon_CheckedChanged(object sender, EventArgs e)
        {
            // Falls der Radiobutton ausgewählt wurde, wird der Datentrenner auf "Semikolon" gesetzt
            if (rbSemikolon.Checked)
            {
                Typen.TrennerDaten = CSVConfigTypen.DatenTrenner.Semikolon;
            }
        }

        /// <summary>
        /// Action falls Tab als Datentrenner ausgewählt wird
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <seealso cref="CSVConfigTypen.DatenTrenner.Tab"/>
        private void rbTab_CheckedChanged(object sender, EventArgs e)
        {
            // Falls der Radiobutton ausgewählt wurde, wird der Datentrenner auf "Tab" gesetzt
            if (rbTab.Checked)
            {
                Typen.TrennerDaten = CSVConfigTypen.DatenTrenner.Tab;
            }
        }
        #endregion
    }
}
