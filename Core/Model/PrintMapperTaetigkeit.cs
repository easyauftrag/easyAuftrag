using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    /// <summary>
    /// Model-Klasse zum Erzeugen von PrintMapperTaetigkeit Objekten
    /// </summary>
    /// <remarks>
    /// In PrintMapperTaetigkeiten werden der Name des Items und seine X-Koordinaten auf dem Dokument gespeichert.
    /// Y-Koordinaten werden hier nicht benötigt.
    /// </remarks>
    public class PrintMapperTaetigkeit
    {
        /// <summary>
        /// Name der PrintMapperTaetigkeit
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// X-Koordinate der PrintMapperTaetigkeit
        /// </summary>
        public int X { get; set; }
    }
}
