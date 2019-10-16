using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    /// <summary>
    /// Model Klasse, um Länder zu erzeugen.
    /// </summary>
    public class Land
    {
        /// <summary>
        /// LandID als Primärschlüssel zur eindeutigen Identifizierung in der Datenbank
        /// </summary>
        [Key]
        public int LandID { get; set; }
        /// <summary>
        /// Name des Landes
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Länderkürzel
        /// </summary>
        public string Kuerzel { get; set; }
        /// <summary>
        /// Vorwahl des Landes
        /// </summary>
        public string Vorwahl { get; set; }

        public Land()
        {

        }

        public Land(string name, string kuerzel, string vorwahl)
        {
            Name = name;
            Kuerzel = kuerzel;
            Vorwahl = vorwahl;
        }
    }
}
