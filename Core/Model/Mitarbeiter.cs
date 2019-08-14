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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    /// <summary>
    /// Model-Klasse zum Erstellen von Mitarbeiterobjekten
    /// </summary>
    public class Mitarbeiter
    {
        /// <summary>
        /// Mitarbeiter ID als Primärschlüssel zur eindeutigen Identifizierung des Mitarbeiters in der Datenbank
        /// </summary>
        [Key]
        [Browsable(false)]
        public int MitarbeiterID { get; set; }
        /// <summary>
        /// Name des Mitarbeiters
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Telefonnummer des Mitarbeiters
        /// </summary>
        public string TelefonNr { get; set; }
        /// <summary>
        /// Adresse des Mitarbeiters
        /// </summary>
        public Adresse Adresse { get; set; }
        /// <summary>
        /// Auslastung der Stelle des Mitarbeiters in Prozent, wird mit dem Sollwert der Wochenstunden verrechnet.
        /// </summary>
        /// <seealso cref="Config.StundenSoll"/>
        public int AuslastungStelle { get; set; }

        /// <summary>
        /// Klassenkonstruktor für die Klasse Mitarbeiter
        /// </summary>
        public Mitarbeiter()
        {

        }
    }
}
