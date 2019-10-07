/*
    Dieses Programm mit dem Namen "easyAuftrag" ist eine Verwaltungssoftware 
    zur Digitalisierung von Auftragszetteln für kleine und mittelständische Handwerksunternehmen.

    
    Copyright (C) 2019  Torben Hettrich (torben.hettrich@kzvbw.de)
    Copyright (C) 2019  Jeremias Weber (jeremias.weber@kzvbw.de)

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License version 3 as published by
    the Free Software Foundation.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.

    Contact us:
    Torben Hettrich & Jeremias Weber
    KZV BW Zahnärztehaus Freiburg
    Merzhauser Str. 114-116
    79100 Freiburg im Breisgau
    DE - Germany
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyAuftrag.View
{
    /// <summary>
    /// Windows Form zum Exportieren von Dateien
    /// </summary>
    /// <seealso cref="Logik.Export"/>
    public partial class ExportView : Form
    {
        public enum Format { CSV, XML, JSON }
        public enum Art { Auftrag, Kunde, Mitarbeiter, Taetigkeit, Adresse }
        public Format DateiFormat { get; set; }
        public Art ExportArt { get; set; }

        /// <summary>
        /// Konstruktor für die <see cref="ExportView"/>
        /// </summary>
        public ExportView(string titel)
        {
            InitializeComponent();
            Text = titel;
            if(titel == "Import")
            {
                butSpeichern.Text = "Laden";
            }
        }

        /// <summary>
        /// Action beim Click auf den "Abbrechen" Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButAbbr_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        private void RdbCSV_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCSV.Checked)
            {
                DateiFormat = Format.CSV;
            }
        }

        private void RdbXML_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbXML.Checked)
            {
                DateiFormat = Format.XML;
            }
        }

        private void RdbJSON_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbJSON.Checked)
            {
                DateiFormat = Format.JSON;
            }
        }

        private void ButSpeichern_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void RdbAuftrag_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAuftrag.Checked)
            {
                ExportArt = Art.Auftrag;
            }
        }

        private void RdbKunde_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbKunde.Checked)
            {
                ExportArt = Art.Kunde;
            }
        }

        private void RdbMitarbeiter_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbMitarbeiter.Checked)
            {
                ExportArt = Art.Mitarbeiter;
            }
        }

        private void RdbTaetigkeit_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTaetigkeit.Checked)
            {
                ExportArt = Art.Taetigkeit;
            }
        }

        private void RdbAdresse_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAdresse.Checked)
            {
                ExportArt = Art.Adresse;
            }
        }
    }
}
