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
    /// <summary>
    /// Windows Form für Adressen
    /// </summary>
    /// <remarks>
    /// Wird aufgerufen, um Adressen auszuwählen
    /// </remarks>
    /// <seealso cref="Adresse"/>
    public partial class AuswahlAdresse : Form
    {
        /// <summary>
        /// Hier werden die eingegebenen Daten zwischengespeichert, 
        /// um sie dann an <see cref="easyAuftrag.Logik.Drucken"/> zu übergeben, oder in der <see cref="AuswahlAdresse"/> anzuzeigen.
        /// </summary>
        /// <value>
        /// Wird durch <see cref="ButAuswahl_Click"/> gefüllt
        /// und gibt seine Daten an <see cref="FillControls"/>, um sie in der View anzuzeigen.
        /// </value>
        public Adresse AdresseInfo { get; set; }
        private List<Adresse> _adressen = new List<Adresse>();

        /// <summary>
        /// Konstruktor für <see cref="AuswahlAdresse"/>
        /// </summary>
        /// <param name="kunde"></param>
        /// <param name="connection"></param>
        /// <seealso cref="EasyAuftragContext"/>
        public AuswahlAdresse(Kunde kunde, string connection)
        {
            AdresseInfo = new Adresse();
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
                    var adr = (from ad 
                               in db.Adressen 
                               where ad.KundeID == kunde.KundeID 
                               select new { ad, adName = "Adresse " + ad.AdresseID + ", " + kunde.Name}).ToList();
                    //Hinzufügen der Rechnungsadresse zur Liste
                    adr.Add(new { ad = rechnungsadresse, adName = "Rechnungsadresse"});
                    foreach (var item in adr)
                    {
                        _adressen.Add(item.ad);
                    }
                    cbAdresse.DataSource = adr;
                    // "Adresse X, Kundename" wird in der ComboBox angezeigt
                    cbAdresse.DisplayMember = "adName";
                    cbAdresse.ValueMember = "ad";
                    // Starten mit "Rechnungsadresse" 
                    cbAdresse.SelectedIndex = adr.Count()-1;
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }
        /// <summary>
        /// Methode zum Anzeigen der übergebenen <see cref="Adresse"/> in den Controls
        /// </summary>
        /// <param name="adresse"></param>
        private void FillControls(Adresse adresse)
        {
            tbStraße.Text = adresse.Strasse;
            tbHaus.Text = adresse.Hausnr;
            tbPLZ.Text = adresse.PLZ;
            tbStadt.Text = adresse.Wohnort;
        }
        /// <summary>
        /// Aktion beim Ändern der Auswahl in der <see cref="ComboBox"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbAdresse_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Zwischenpeichern der ausgewälten Adresse zur Weiterverarbeitung
            AdresseInfo = _adressen.ElementAt(cbAdresse.SelectedIndex);
            // Übergeben der Adresse zum Anzeigen in den Controls
            FillControls(AdresseInfo);
        }
        /// <summary>
        /// Aktion beim Klick auf den "Auswahl" Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButAuswahl_Click(object sender, EventArgs e)
        {
            // Zwischenpeichern der ausgewälten Adresse zur Übergabe an "Auftragzettel" im MainView
            AdresseInfo = _adressen.ElementAt(cbAdresse.SelectedIndex);
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }
        /// <summary>
        /// Aktion beim Klick auf den "Abbrechen" Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButAbbr_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }
    }
}
