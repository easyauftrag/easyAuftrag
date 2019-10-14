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
