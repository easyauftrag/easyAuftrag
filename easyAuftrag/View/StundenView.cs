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
using Core;
using Core.Model;
using easyAuftrag.Logik;
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
    /// Windows Form für Stundenberechnungen der Mitarbeiter
    /// </summary>
    /// <remarks>
    /// Wird aufgerufen, um Arbeitsstunden eines Mitarbeiters im angegebenen Zeitraum mit dem Soll-Wert zu vergleichen
    /// </remarks>
    public partial class StundenView : Form
    {
        /// <summary>
        /// Hier werden die eingegebenen Daten zwischengespeichert, 
        /// um sie dann an den <see cref="Core.Handler"/> zu übergeben, oder in der <see cref="TaetigkeitView"/> anzuzeigen.
        /// </summary>
        /// <value>
        /// Wird durch <see cref="FillTaetigkeit"/> oder <see cref="MainView"/> gefüllt
        /// und gibt seine Daten an <see cref="FillControls"/>, um sie in der View anzuzeigen.
        /// </value>
        public StundenDoc stundenDoc = new StundenDoc();

        /// <summary>
        /// Konstruktor für die <see cref="StundenView"/>
        /// </summary>
        public StundenView()
        {
            InitializeComponent();
            using (var db = new EasyAuftragContext())
            {
                var mitarbeiter = (from k in db.Mitarbeiters select new { ID = k.MitarbeiterID, mName = k.Name }).ToList();
                cbMitarbeiter.DataSource = mitarbeiter;
                cbMitarbeiter.DisplayMember = "mName";
                cbMitarbeiter.ValueMember = "ID";
            }
        }

        public void FillStunden()
        {
            try
            {
                stundenDoc.Anfang = dtpAnfang.Value;
                stundenDoc.Ende = dtpEnde.Value;
                int mID = Convert.ToInt32(cbMitarbeiter.SelectedValue);
                using (var db = new EasyAuftragContext())
                {
                    stundenDoc.Mitarbeiter = (from m in db.Mitarbeiters where m.MitarbeiterID == mID select m).First();
                    stundenDoc.Tatlist = (from t in db.Taetigkeiten where t.MitarbeiterID == stundenDoc.Mitarbeiter.MitarbeiterID select t).ToList();

                    stundenDoc.Tatlist = stundenDoc.Tatlist.Where(t => t.Datum >= stundenDoc.Anfang).ToList();
                    stundenDoc.Tatlist = stundenDoc.Tatlist.Where(t => t.Datum <= stundenDoc.Ende).ToList();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        public void FillControls()
        {
            try
            {
                Config conf = new Config();
                conf.StundenSoll = 40;
                tbSoll.Text = (stundenDoc.Mitarbeiter.AuslastungStelle/100 * conf.StundenSoll).ToString();
                tbGeleistet.Text = Berechnung.ArbeitsZeit(stundenDoc).ToString();
                dgvStunden.DataSource = stundenDoc.Tatlist;
                dgvStunden.Columns["TaetigkeitID"].Visible = false;
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        private void ButBerechnen_Click(object sender, EventArgs e)
        {
            FillStunden();
            FillControls();
        }

        private void ButDruck_Click(object sender, EventArgs e)
        {
            FillStunden();
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void ButAbbr_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

    }
}
