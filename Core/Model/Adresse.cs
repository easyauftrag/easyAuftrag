using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    /// <summary>
    /// Model-Klasse zum Erstellen von Adressobjekten
    /// </summary>
    public class Adresse
    {
        /// <summary>
        /// Adress ID als Primärschlüssel zur eindeutigen Identífizierung der Adresse in der Datenbank
        /// </summary>
        [Key]
        [Browsable(false)]
        public int AdresseID { get; set; }
        /// <summary>
        /// Straße der Adresse
        /// </summary>
        public string Strasse { get; set; }
        /// <summary>
        /// Hausnummer der Adresse
        /// </summary>
        public string Hausnr { get; set; }
        /// <summary>
        /// Postleitzahl der Adresse
        /// </summary>
        public string PLZ { get; set; }
        /// <summary>
        /// Wohnort der Adresse
        /// </summary>
        public string Wohnort { get; set; }

        /// <summary>
        /// Klassenkonstruktor für die Klasse Adresse
        /// </summary>
        public Adresse()
        {

        }
    }
}
