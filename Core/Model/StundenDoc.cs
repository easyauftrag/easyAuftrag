using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class StundenDoc
    {
        public DateTime Anfang { get; set; }
        public DateTime Ende { get; set; }
        public Mitarbeiter Mitarbeiter { get; set; }
        public List<Taetigkeit> Tatlist { get; set; }

        public StundenDoc()
        {

        }
        
    }
}
