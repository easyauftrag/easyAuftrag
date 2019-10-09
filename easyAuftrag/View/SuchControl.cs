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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Model;
using Core;

namespace easyAuftrag.View
{
    public partial class SuchControl : UserControl
    {
        private List<SucheRow> _lstRow = new List<SucheRow>();
        private List<string> _spalten = new List<string>();
        public event Action SuchEvent;
        public List<SucheRow> Suche { get; set; }

        /// <summary>
        /// Auslesen oder Befüllen der Spalten im <see cref="SuchControl"/>
        /// </summary>
        public List<string> Spalten
        {
            get { return _spalten; }
            set
            {
                _spalten = value;
                FillSpalten();
            }
        }

        /// <summary>
        /// Konstruktor für das <see cref="SuchControl"/>
        /// </summary>
        public SuchControl()
        {
            InitializeComponent();
            Suche = new List<SucheRow>();
            SucheRow row = new SucheRow
            {
                LinkControl = comboLink,
                SpalteControl = comboSpalte,
                ValueControl = tbSuche,
                AnfangControl = dtpAnfang,
                EndeControl = dtpEnde,
                CheckControl = cbSuche,

            };
            row.LinkControl.Visible = false;
            row.AnfangControl.Visible = false;
            row.EndeControl.Visible = false;
            row.CheckControl.Visible = false;
            _lstRow.Add(row);
        }

        /// <summary>
        /// Methode zum befüllen der <see cref="ComboBox"/> Spalten im <see cref="SuchControl"/>
        /// </summary>
        private void FillSpalten()
        {
            foreach (var spalte in Spalten)
            {
                comboSpalte.Items.Add(spalte);
            }
        }

        /// <summary>
        /// Methode zum Hinzufügen einer zusätzlichen Suchzeile im <see cref="SuchControl"/>
        /// </summary>
        private void AddControls()
        {
            SucheRow row = new SucheRow();
            ComboBox comboLinkVorlage = new ComboBox();
            ComboBox comboSpalteVorlage = new ComboBox();
            TextBox tbSucheVorlage = new TextBox();
            DateTimePicker dtpAnfangVorlage = new DateTimePicker();
            DateTimePicker dtpEndeVorlage = new DateTimePicker();
            CheckBox cbSucheVorlage = new CheckBox();
            CheckBox cbErledigtVorlage = new CheckBox();

            comboLinkVorlage.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            comboLinkVorlage.FormattingEnabled = true;
            comboLinkVorlage.Location = new Point(4, tbSuche.Location.Y + _lstRow.Count * 30);
            comboLinkVorlage.Name = "comboLinkVorlage_" + _lstRow.Count.ToString();
            comboLinkVorlage.Size = new Size(56, 21);
            comboLinkVorlage.TabIndex = 2;
            comboLinkVorlage.Items.AddRange(new object[]
            {
                "und",
                "oder"
            });
            comboLinkVorlage.SelectedIndex = 0;

            comboSpalteVorlage.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            comboSpalteVorlage.FormattingEnabled = true;
            comboSpalteVorlage.Location = new Point(66, comboSpalte.Location.Y + _lstRow.Count * 30);
            comboSpalteVorlage.Name = "comboSpalteVorlage_" + _lstRow.Count.ToString();
            comboSpalteVorlage.Size = new Size(133, 21);
            comboSpalteVorlage.TabIndex = 3;
            comboSpalteVorlage.SelectedIndexChanged += ComboSpalteVorlage_SelectedIndexChanged;
            foreach (var spalte in Spalten)
            {
                comboSpalteVorlage.Items.Add(spalte);
            }

            tbSucheVorlage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbSucheVorlage.Location = new Point(205, tbSuche.Location.Y + _lstRow.Count * 30);
            tbSucheVorlage.Name = "tbSucheVorlage_" + _lstRow.Count.ToString();
            tbSucheVorlage.Size = new Size(274, 20);
            tbSucheVorlage.TabIndex = 4;

            dtpAnfangVorlage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpAnfangVorlage.Location = new Point(205, dtpAnfang.Location.Y + _lstRow.Count * 30);
            dtpAnfangVorlage.Name = "dtpAnfangVorlage_" + _lstRow.Count.ToString();
            dtpAnfangVorlage.Size = new Size(134, 20);
            dtpAnfangVorlage.TabIndex = 5;
            dtpAnfangVorlage.Visible = false;

            dtpEndeVorlage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpEndeVorlage.Location = new Point(345, dtpEnde.Location.Y + _lstRow.Count * 30);
            dtpEndeVorlage.Name = "dtpEndeVorlage_" + _lstRow.Count.ToString();
            dtpEndeVorlage.Size = new Size(134, 20);
            dtpEndeVorlage.TabIndex = 6;
            dtpEndeVorlage.Visible = false;

            cbSucheVorlage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbSucheVorlage.Location = new Point(205, cbSuche.Location.Y + _lstRow.Count * 30);
            cbSucheVorlage.Name = "cbSucheVorlage_" + _lstRow.Count.ToString();
            cbSucheVorlage.Size = new Size(274, 20);
            cbSucheVorlage.TabIndex = 7;
            cbSucheVorlage.Visible = false;

            Controls.Add(comboLinkVorlage);
            Controls.Add(tbSucheVorlage);
            Controls.Add(comboSpalteVorlage);
            Controls.Add(dtpAnfangVorlage);
            Controls.Add(dtpEndeVorlage);
            Controls.Add(cbSucheVorlage);

            row.LinkControl = comboLinkVorlage;
            row.SpalteControl = comboSpalteVorlage;
            row.ValueControl = tbSucheVorlage;
            row.AnfangControl = dtpAnfangVorlage;
            row.EndeControl = dtpEndeVorlage;
            row.CheckControl = cbSucheVorlage;

            _lstRow.Add(row);
        }

        /// <summary>
        /// Methode zum Ausblenden der nicht verwendeten Controls in der ersten Zeile des <see cref="SuchControl"/>
        /// </summary>
        private void ComboSpalte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboSpalte.SelectedItem.Equals("Eingang") || comboSpalte.SelectedItem.Equals("Erteilt"))
            {
                dtpAnfang.Visible = true;
                dtpEnde.Visible = true;
                tbSuche.Visible = false;
                cbSuche.Visible = false;
            }
            else if (comboSpalte.SelectedItem.Equals("Abgerechnet"))
            {
                cbSuche.Text = "Nicht abgerechnete Aufträge";
                cbSuche.Visible = true;
                dtpAnfang.Visible = false;
                dtpEnde.Visible = false;
                tbSuche.Visible = false;
            }
            else if (comboSpalte.SelectedItem.Equals("Erledigt"))
            {
                cbSuche.Text = "Erledigte Aufträge";
                cbSuche.Visible = true;
                dtpAnfang.Visible = false;
                dtpEnde.Visible = false;
                tbSuche.Visible = false;
            }
            else
            {
                tbSuche.Visible = true;
                dtpAnfang.Visible = false;
                dtpEnde.Visible = false;
                cbSuche.Visible = false;
            }
            if (_lstRow.Count < 3)
            {
                AddControls();
            }
        }

        /// <summary>
        /// Methode zum Ausblenden der nicht verwendeten Controls in den weiteren Zeilen des <see cref="SuchControl"/>
        /// </summary>
        private void ComboSpalteVorlage_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbNew = (ComboBox)sender;
            int currentIndex = Convert.ToInt32(cbNew.Name.Split('_')[1]);
            if (cbNew.SelectedItem.Equals("Eingang") || cbNew.SelectedItem.Equals("Erteilt"))
            {
                _lstRow[currentIndex].AnfangControl.Visible = true;
                _lstRow[currentIndex].EndeControl.Visible = true;
                _lstRow[currentIndex].ValueControl.Visible = false;
                _lstRow[currentIndex].CheckControl.Visible = false;
            }
            else if (cbNew.SelectedItem.Equals("Abgerechnet"))
            {
                _lstRow[currentIndex].CheckControl.Text = "Nicht abgerechnete Aufträge";
                _lstRow[currentIndex].CheckControl.Visible = true;
                _lstRow[currentIndex].AnfangControl.Visible = false;
                _lstRow[currentIndex].EndeControl.Visible = false;
                _lstRow[currentIndex].ValueControl.Visible = false;
            }
            else if (cbNew.SelectedItem.Equals("Erledigt"))
            {
                _lstRow[currentIndex].CheckControl.Text = "Erledigte Aufträge";
                _lstRow[currentIndex].CheckControl.Visible = true;
                _lstRow[currentIndex].AnfangControl.Visible = false;
                _lstRow[currentIndex].EndeControl.Visible = false;
                _lstRow[currentIndex].ValueControl.Visible = false;
            }
            else
            {
                _lstRow[currentIndex].ValueControl.Visible = true;
                _lstRow[currentIndex].AnfangControl.Visible = false;
                _lstRow[currentIndex].EndeControl.Visible = false;
                _lstRow[currentIndex].CheckControl.Visible = false;
            }
            if (_lstRow.Count < 3)
            {
                AddControls();
            }
        }

        /// <summary>
        /// Action beim Klick auf den "Suche" Button im <see cref="SuchControl"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButSuche_Click(object sender, EventArgs e)
        {
            Suche = _lstRow;
            SuchEvent?.Invoke();
        }
    }
}
