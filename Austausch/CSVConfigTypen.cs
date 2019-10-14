/*
    Dieses Programm mit dem Namen "easyAuftrag" ist eine Verwaltungssoftware 
    zur Digitalisierung von Auftragszetteln für kleine und mittelständische Handwerksunternehmen.

    
    Copyright (C) 2019  Torben Hettrich (torben.hettrich@kzvbw.de)
    Copyright (C) 2019  Jeremias Weber (jeremias.weber@kzvbw.de)

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License version 3 as published by
    the Free Software Foundation.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.

    Contact us:
    Torben Hettrich & Jeremias Weber
    KZV BW Zahnärztehaus Freiburg
    Merzhauser Str. 114-116
    79100 Freiburg im Breisgau
    DE - Germany
*/
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
