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
    /// Model-Klasse zum Erstellen von Tätigkeitsobjekten
    /// </summary>
    public class Taetigkeit
    {
        /// <summary>
        /// Tätigkeits ID als Primärschlüssel zur eindeutigen Identifizierung der Tätigkeit in der Datenbank
        /// </summary>
        [Key]
        [Browsable(false)]
        public int TaetigkeitID { get; set; }
        /// <summary>
        /// Auftrags ID als Fremdschlüssel zur Verknüpfung der Tätigkeit mit einem Auftrag
        /// </summary>
        /// <seealso cref="Auftrag"/>
        public int AuftragID { get; set; }
        /// <summary>
        /// Mitarbeiter ID als Fremdschlüssel zur Verknüpfung der Tätigkeit mit einem Mitarbeiter
        /// </summary>
        /// <seealso cref="Mitarbeiter"/>
        public int MitarbeiterID { get; set; }
        /// <summary>
        /// Datum der Tätigkeit
        /// </summary>
        public DateTime Datum { get; set; }
        /// <summary>
        /// Name bzw. Beschreibung der Tätigkeit
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Uhrzeit des Beginns der Tätigkeit
        /// </summary>
        public TimeSpan StartZeit { get; set; }
        /// <summary>
        /// Uhrzeit des Endes der Tätigkeit
        /// </summary>
        public TimeSpan EndZeit { get; set; } // TODO: Check if größer StartZeit
        /// <summary>
        /// Enthält die für die Tätigkeit verbuchte Zeit
        /// </summary>
        /// <value>
        /// Der Wert wird durch <see cref="ZeitBerechnen"/> berechnet
        /// </value>
        public double Minuten { get { return ZeitBerechnen(); } }

        /// <summary>
        /// Klassenkonstruktor für die Klasse Taetigkeit
        /// </summary>
        public Taetigkeit()
        {

        }

        /// <summary>
        /// Berechnet die für die Tätigkeit verbuchte Zeit aus <see cref="StartZeit"/> und <see cref="EndZeit"/>
        /// </summary>
        /// <returns>Für Tätigkeit benötigte Zeit in Minuten</returns>
        private double ZeitBerechnen()
        {
            double minuten = (this.EndZeit - this.StartZeit).TotalMinutes;
            return minuten;
        }
    }
}
