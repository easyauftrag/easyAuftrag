using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    /// <summary>
    /// Model-Klasse zum Erzeugen von XmlPrintMapperAuftrag Objekten
    /// </summary>
    /// <remarks>
    /// Ein XmlPrintMapperAuftrag Objekt speichert für den Druck die Positionen aller Informationen zu einem Auftrag.
    /// Diese werden aus einer XML Datei ausgelesen.
    /// </remarks>
    public class XmlPrintMapperAuftrag
    {
        /// <summary>
        /// Liste mit den Koordinaten der gewöhnlichen Items
        /// </summary>
        public List<PrintMapperItem> MappingList { get; set; }
        /// <summary>
        /// Y-Koordinate der Tätigkeiten
        /// </summary>
        public int Start { get; set; }
        /// <summary>
        /// Abstand zwischen den Tätigkeiten
        /// </summary>
        public int Inc { get; set; }
        /// <summary>
        /// Liste mit den Koordinaten der Tätigkeiten
        /// </summary>
        public List<PrintMapperTaetigkeit> TatList { get; set; }

        /// <summary>
        /// Klassenkostruktur für die Klasse PrintMapperAuftrag
        /// </summary>
        public XmlPrintMapperAuftrag()
        {
            MappingList = new List<PrintMapperItem>();
            TatList = new List<PrintMapperTaetigkeit>();
        }
    }
}
