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
        public event Action SuchEvent;
        public SucheInfo sucheInfo = new SucheInfo();
        private List<SucheRow> _lstRow = new List<SucheRow>();
        private List<string> _spalten = new List<string>();
        public List<SucheRow> Suche = new List<SucheRow>();

        public List<string> Spalten
        {
            get { return _spalten; }
            set
            {
                _spalten = value;
                FillSpalten();
            }
        }

        private void FillSpalten()
        {
            foreach (var spalte in Spalten)
            {
                comboSpalte.Items.Add(spalte);
            }
        }

        public SuchControl()
        {
            InitializeComponent();
            SucheRow row = new SucheRow
            {
                LinkControl = comboLink,
                SpalteControl = comboSpalte,
                ValueControl = tbSuche,
                AnfangControl = dtpAnfang,
                EndeControl = dtpEnde,

            };
            _lstRow.Add(row);
            sucheInfo.CbAbgerechnet = cbAbgerechnet;
            sucheInfo.CbErledigt = cbErledigt;
            sucheInfo.ComboSpalte = comboSpalte;
            sucheInfo.TbSuche = tbSuche;
            sucheInfo.DtpAnfang = dtpAnfang;
            sucheInfo.DtpEnde = dtpEnde;
            sucheInfo.DtpAnfang.Visible = false;
            sucheInfo.DtpEnde.Visible = false;
        }

        private void AddControls()
        {
            SucheRow row = new SucheRow();
            ComboBox comboLinkVorlage = new ComboBox();
            ComboBox comboSpalteVorlage = new ComboBox();
            TextBox tbSucheVorlage = new TextBox();
            DateTimePicker dtpAnfangVorlage = new DateTimePicker();
            DateTimePicker dtpEndeVorlage = new DateTimePicker();

            comboLinkVorlage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
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

            comboSpalteVorlage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboSpalteVorlage.FormattingEnabled = true;
            comboSpalteVorlage.Location = new Point(66, comboSpalte.Location.Y + _lstRow.Count * 30);
            comboSpalteVorlage.Name = "comboSpalteVorlage_" + _lstRow.Count.ToString();
            comboSpalteVorlage.Size = new Size(133, 21);
            comboSpalteVorlage.TabIndex = 3;
            comboSpalteVorlage.SelectedIndexChanged += comboSpalteVorlage_SelectedIndexChanged;
            foreach (var spalte in Spalten)
            {
                comboSpalteVorlage.Items.Add(spalte);
            }


            tbSucheVorlage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tbSucheVorlage.Location = new Point(205, tbSuche.Location.Y + _lstRow.Count * 30);
            tbSucheVorlage.Name = "tbSucheVorlage_" + _lstRow.Count.ToString();
            tbSucheVorlage.Size = new Size(274, 20);
            tbSucheVorlage.TabIndex = 4;

            dtpAnfangVorlage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpAnfangVorlage.Location = new Point(205, dtpAnfang.Location.Y + _lstRow.Count * 30);
            dtpAnfangVorlage.Name = "dtpAnfangVorlage_" + _lstRow.Count.ToString();
            dtpAnfangVorlage.Size = new Size(134, 20);
            dtpAnfangVorlage.TabIndex = 5;

            dtpEndeVorlage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpEndeVorlage.Location = new Point(345, dtpEnde.Location.Y + _lstRow.Count * 30);
            dtpEndeVorlage.Name = "dtpEndeVorlage_" + _lstRow.Count.ToString();
            dtpEndeVorlage.Size = new Size(134, 20);
            dtpEndeVorlage.TabIndex = 6;

            this.Controls.Add(comboLinkVorlage);
            this.Controls.Add(tbSucheVorlage);
            this.Controls.Add(comboSpalteVorlage);
            this.Controls.Add(dtpAnfangVorlage);
            this.Controls.Add(dtpEndeVorlage);

            row.LinkControl = comboLinkVorlage;
            row.SpalteControl = comboSpalteVorlage;
            row.ValueControl = tbSucheVorlage;
            row.AnfangControl = dtpAnfangVorlage;
            row.EndeControl = dtpEndeVorlage;
            _lstRow.Add(row);
        }

        private void comboSpalteVorlage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_lstRow.Count < 3)
                {
                    AddControls();
                }
                ComboBox cbNew = (ComboBox)sender;
                int currentIndex = Convert.ToInt32(cbNew.Name.Split('_')[1]);
                if (cbNew.SelectedItem.Equals("Eingang") || cbNew.SelectedItem.Equals("Erteilt"))
                {
                    _lstRow[currentIndex].AnfangControl.Visible = true;
                    _lstRow[currentIndex].EndeControl.Visible = true;
                    _lstRow[currentIndex].ValueControl.Visible = false;
                }
                else
                {
                    _lstRow[currentIndex].AnfangControl.Visible = false;
                    _lstRow[currentIndex].EndeControl.Visible = false;
                    _lstRow[currentIndex].ValueControl.Visible = true;
                }
            }
            catch (Exception ex)
            {

                ErrorHandler.ErrorHandle(ex);
            }
            
        }

        private void ButSuche_Click(object sender, EventArgs e)
        {
            if (Suche != null)
            { Suche.Clear(); };

            Suche = _lstRow;
            SuchEvent?.Invoke();
        }

        private void CbErledigt_CheckedChanged(object sender, EventArgs e)
        {
            if (Suche != null)
            { Suche.Clear(); };
            Suche = _lstRow;
            SuchEvent?.Invoke();
        }

        private void CbAbgerechnet_CheckedChanged(object sender, EventArgs e)
        {
            if (Suche != null)
            { Suche.Clear(); };
            foreach (var item in _lstRow)
            {
                Suche.Add(item);
            }
            SuchEvent?.Invoke();
        }

        private void ComboSpalte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboSpalte.SelectedItem.Equals("Eingang") || comboSpalte.SelectedItem.Equals("Erteilt"))
            {
                dtpAnfang.Visible = true;
                dtpEnde.Visible = true;
                tbSuche.Visible = false;
            }
            else
            {
                dtpAnfang.Visible = false;
                dtpEnde.Visible = false;
                tbSuche.Visible = true;
            }
            if (_lstRow.Count < 3)
            {
                AddControls();
            }
            
        }
    }
}
