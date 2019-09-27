using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    /// <summary>
    /// Model-Klasse für PrintMapperItem Objekte
    /// </summary>
    /// <remarks>
    /// In PrintMapperItems werden der Name des Items und seine Koordinaten auf dem Dokument gespeichert. 
    /// </remarks>
    public class PrintMapperItem
    { 
        /// <summary>
        /// Name des PrintMapperItems
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// X-Koordinate des PrintMapperItems
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Y-Koordinate des PrintMapperItems
        /// </summary>
        public int Y { get; set; }
    }
}
