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

namespace easyAuftrag.View
{
    public partial class SuchControl : UserControl
    {
        public event Action SuchEvent;
        public SucheInfo _sucheInfo = new SucheInfo();
        private List<SucheRow> _lstRow = new List<SucheRow>();
        private List<string> _spalten = new List<string>();
        public string Suche { get; set; }

        public List<string> Spalten
        {
            get { return _spalten; }
            set
            {
                _spalten = value;
                FuelleSpalten();
            }
        }

        public SuchControl()
        {
            InitializeComponent();
            SucheRow row = new SucheRow
            {
                LinkControl = new ComboBox(),
                SpalteControl = comboSpalte,
                ValueControl = tbSuche,
                AnfangControl = dtpAnfang,
                EndeControl = dtpEnde,

            };
            _lstRow.Add(row);
            _sucheInfo.CbAbgerechnet = cbAbgerechnet;
            _sucheInfo.CbErledigt = cbErledigt;
            _sucheInfo.ComboSpalte = comboSpalte;
            _sucheInfo.TbSuche = tbSuche;
            _sucheInfo.DtpAnfang = dtpAnfang;
            _sucheInfo.DtpEnde = dtpEnde;
            _sucheInfo.DtpAnfang.Visible = false;
            _sucheInfo.DtpEnde.Visible = false;
        }

        private void FuelleSpalten()
        {
            foreach (var spalte in Spalten)
            {
                comboSpalte.Items.Add(spalte);
            }
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
            comboLinkVorlage.Location = new Point(3, tbSuche.Location.Y + _lstRow.Count * 30);
            comboLinkVorlage.Name = "cmbLinkVorlage";
            comboLinkVorlage.Size = new Size(62, 21);
            comboLinkVorlage.TabIndex = 7;

            comboSpalteVorlage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboSpalteVorlage.FormattingEnabled = true;
            comboSpalteVorlage.Location = new Point(71, comboSpalte.Location.Y + _lstRow.Count * 30);
            comboSpalteVorlage.Name = "comboSpalteVorlage";
            comboSpalteVorlage.Size = new Size(115, 21);
            comboSpalteVorlage.TabIndex = 4;
            comboSpalteVorlage.SelectedIndexChanged += comboSpalteVorlage_SelectedIndexChanged;
            foreach (var spalte in Spalten)
            {
                comboSpalteVorlage.Items.Add(spalte);
            }

            tbSucheVorlage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tbSucheVorlage.Location = new Point(327, tbSuche.Location.Y + _lstRow.Count * 30);
            tbSucheVorlage.Name = "txtValueVorlage";
            tbSucheVorlage.Size = new Size(168, 20);
            tbSucheVorlage.TabIndex = 6;

            dtpAnfangVorlage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpAnfangVorlage.Location = new Point(327, dtpAnfang.Location.Y + _lstRow.Count * 30);
            dtpAnfangVorlage.Name = "txtValueVorlage";
            dtpAnfangVorlage.Size = new Size(168, 20);
            dtpAnfangVorlage.TabIndex = 6;

            dtpEndeVorlage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpEndeVorlage.Location = new Point(375, dtpEnde.Location.Y + _lstRow.Count * 30);
            dtpEndeVorlage.Name = "txtValueVorlage";
            dtpEndeVorlage.Size = new Size(168, 20);
            dtpEndeVorlage.TabIndex = 7;

        }

        private void ButSuche_Click(object sender, EventArgs e)
        { 
            SuchEvent?.Invoke();
        }

        private void CbErledigt_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in _lstRow)
            {
                Suche += item.Text + "\n";
            }
            SuchEvent?.Invoke();
        }

        private void CbAbgerechnet_CheckedChanged(object sender, EventArgs e)
        {
            SuchEvent?.Invoke();
        }
        private void comboSpalte_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddControls();
        }

        private void comboSpalteVorlage_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddControls();
        }
    }
}
