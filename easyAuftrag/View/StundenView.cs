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
    public partial class StundenView : Form
    {
        public StundenDoc stundenDoc = new StundenDoc();
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
