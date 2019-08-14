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
    /// Wird aufgerufen, um Adressen anzulegen, zu bearbeiten und zu löschen
    /// </remarks>
    public partial class AdresseView : Form
    {
        /// <summary>
        /// Hier werden die eingegebenen Daten zwischengespeichert, 
        /// um sie dann an den <see cref="Core.Handler"/> zu übergeben, oder in der <see cref="AdresseView"/> anzuzeigen.
        /// </summary>
        /// <value>
        /// Wird durch <see cref="FillAdresse"/> oder <see cref="MainView"/> gefüllt
        /// und gibt seine Daten an <see cref="FillControls"/>, um sie in der View anzuzeigen.
        /// </value>
        public Adresse AdresseInfo { get; set; }

        /// <summary>
        /// Konstruktor für die <see cref="AdresseView"/>
        /// </summary>
        /// <param name="titel"></param>
        public AdresseView(string titel)
        {
            AdresseInfo = new Adresse();
            InitializeComponent();
            Text = titel;
        }
        /// <summary>
        /// Konstruktor für die <see cref="AdresseView"/>
        /// </summary>
        /// <param name="titel"></param>
        /// <param name="adresse"></param>
        public AdresseView(string titel, Adresse adresse)
        {
            InitializeComponent();
            Text = titel;
            AdresseInfo = adresse;
            FillControls(AdresseInfo);
        }

        /// <summary>
        /// Packt die Eingaben in den Controls in eine <see cref="Adresse"/>.
        /// </summary>
        /// <returns>Taetigkeit aus den Eingaben in den Controls</returns>
        private void FillAdresse()
        {
            try
            {
                AdresseInfo.Strasse = tbStraße.Text;
                AdresseInfo.Hausnr = tbHaus.Text;
                AdresseInfo.PLZ = tbPLZ.Text;
                AdresseInfo.Wohnort = tbStadt.Text;
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

        /// <summary>
        /// Action beim Klick auf den "Speichen" Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButSpeichern_Click(object sender, EventArgs e)
        {
            FillAdresse();
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        /// <summary>
        /// Action beim Klick auf den "Abbrechen" Button
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
