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
