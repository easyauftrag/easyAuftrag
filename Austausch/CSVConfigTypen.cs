using System;
using System.Collections.Generic;
using System.Text;

namespace Austausch
{
    /// <summary>
    /// Klasse zur definieren des Daten- und Dezimaltrenners einer CSV Datei
    /// </summary>
    public class CSVConfigTypen
    {
        /// <summary>
        /// Typen des Dezimaltrenners
        /// </summary>
        public enum DezimalTrenner { Punkt, Komma };
        /// <summary>
        /// Typen des Datentrenners
        /// </summary>
        public enum DatenTrenner { Komma, Semikolon, Tab };

        /// <summary>
        /// Dezimaltrenner einer CSV Datei
        /// </summary>
        public DezimalTrenner TrennerDezimal { get; set; }
        /// <summary>
        /// Datentrenner einer CSV Datei
        /// </summary>
        public DatenTrenner TrennerDaten { get; set; }

        /// <summary>
        /// Konstruktor zum Erstellen des Objekts
        /// </summary>
        public CSVConfigTypen()
        {

        }

        /// <summary>
        /// Konstruktor zum Erstellen des Objekts mit den Eigenschaften als Parameter
        /// </summary>
        /// <param name="dezimalTrenner">Dezimaltrenner einer CSV Datei</param>
        /// <param name="datenTrenner">Datentrenner einer CSV Datei</param>
        public CSVConfigTypen(DezimalTrenner dezimalTrenner, DatenTrenner datenTrenner)
        {
            TrennerDezimal = dezimalTrenner;
            TrennerDaten = datenTrenner;
        }
    }
}
