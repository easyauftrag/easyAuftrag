using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class DruckDoc
    {
        public string AuftragNr { get; set; }
        public string KundeName { get; set; }
        public string KundeAnschrift { get; set; }
        public string KundeTelefon { get; set; }
        public List<Taetigkeit> TatListe { get; set; }
        public List<Mitarbeiter> MitList { get; set; }

        public DruckDoc()
        {

        }
    }
}
