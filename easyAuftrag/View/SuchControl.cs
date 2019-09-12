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
        public SuchControl()
        {
            InitializeComponent();
            _sucheInfo.CbAbgerechnet = cbAbgerechnet;
            _sucheInfo.CbErledigt = cbErledigt;
            _sucheInfo.TbSuche = tbSuche;
            _sucheInfo.DtpAnfangEingang = dtpAnfangEingang;
            _sucheInfo.DtpEndeEingang = dtpEndeEingang;
            _sucheInfo.DtpAnfangErteilt = dtpAnfangErteilt;
            _sucheInfo.DtpEndeErteilt = dtpEndeErteilt;
        }

        private void ButSuche_Click(object sender, EventArgs e)
        { 
            SuchEvent?.Invoke();
        }

        private void CbErledigt_CheckedChanged(object sender, EventArgs e)
        {
            SuchEvent?.Invoke();
        }

        private void CbAbgerechnet_CheckedChanged(object sender, EventArgs e)
        {
            SuchEvent?.Invoke();
        }
    }
}
