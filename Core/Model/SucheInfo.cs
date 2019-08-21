using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Core.Model
{
    public class SucheInfo
    {
        public CheckBox CbErledigt { get; set; }
        public CheckBox CbAbgerechnet { get; set; }
        public TextBox TbSuche { get; set; }
        public DateTimePicker DtpAnfangEingang { get; set; }
        public DateTimePicker DtpEndeEingang { get; set; }
        public DateTimePicker DtpAnfangErteilt { get; set; }
        public DateTimePicker DtpEndeErteilt { get; set; }
        
    }
}
