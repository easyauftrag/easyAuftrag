using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class XmlPrintMapperAuftrag
    {
        //Test
        public List<PrintMapperItem> MappingList { get; set; }
        public int Start { get; set; }
        public int Inc { get; set; }
        public List<PrintMapperTaetigkeit> TatList { get; set; }
    }
}
