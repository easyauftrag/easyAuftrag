using Core;
using Core.Model;
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
    public partial class AuswahlAdresse : Form
    {
        public Adresse AdresseInfo { get; set; }
        private List<Adresse> _adressen = new List<Adresse>();
        public AuswahlAdresse(Kunde kunde, string connection)
        {
            InitializeComponent();
            try
            {
                Adresse rechnungsadresse = new Adresse
                {
                    KundeID = kunde.KundeID,
                    Strasse = kunde.Strasse,
                    Hausnr = kunde.Hausnr,
                    PLZ = kunde.PLZ,
                    Wohnort = kunde.Wohnort
                };
                using (var db = new EasyAuftragContext(connection))
                {
                    // Laden aller Adressen, die zum aktiven Kunden gehören
                    var adr = (from ad in db.Adressen where ad.KundeID == kunde.KundeID select new { ad, adName = ad.Strasse + " " + ad.Hausnr + ", " + ad.PLZ + " " + ad.Wohnort }).ToList();
                    adr.Add(new { ad = rechnungsadresse, adName = "Rechnungsadresse "});
                    foreach (var item in adr)
                    {
                        _adressen.Add(item.ad);
                    }
                    cbAdresse.DataSource = adr;
                    cbAdresse.DisplayMember = "adName";
                    cbAdresse.ValueMember = "ad";
                    cbAdresse.SelectedIndex = adr.Count()-1;
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }
        /// <summary>
        /// Zeigt die übergebene <see cref="Adresse"/> in den Controls an.
        /// </summary>
        /// <param name="adresse"></param>
        private void FillControls(Adresse adresse)
        {
            tbStraße.Text = adresse.Strasse;
            tbHaus.Text = adresse.Hausnr;
            tbPLZ.Text = adresse.PLZ;
            tbStadt.Text = adresse.Wohnort;
        }
        private void CbAdresse_SelectedIndexChanged(object sender, EventArgs e)
        {
            AdresseInfo = _adressen.ElementAt(cbAdresse.SelectedIndex);
            FillControls(AdresseInfo);
        }

        private void ButAuswahl_Click(object sender, EventArgs e)
        {
            AdresseInfo = _adressen.ElementAt(cbAdresse.SelectedIndex);
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
