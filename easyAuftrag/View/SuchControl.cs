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
