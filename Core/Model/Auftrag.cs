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
    /// Model-Klasse zum Erstellen von Auftragsobjekten
    /// </summary>
    public class Auftrag
    {
        /// <summary>
        /// Auftrags ID als Primärschlüssel zur eindeutigen Identifizierung des Auftrags in der Datenbank
        /// </summary>
        [Key]
        public int AuftragID { get; set; }
        /// <summary>
        /// Aufragsnummer zur Kennzeichnung des Auftrags für den Betrieb
        /// </summary>
        public string AuftragNummer { get; set; }
        /// <summary>
        /// Kunden ID als Fremdschlüssel zur Verknüpfung des Auftrags mit einem Kunden
        /// </summary>
        /// <seealso cref="Kunde"/>
        public int KundeID { get; set; }
        /// <summary>
        /// Datum, wann der Auftrag eingegangen ist
        /// </summary>
        public DateTime Eingang { get; set; }
        /// <summary>
        /// Datum, wann der Auftrag an einen Mitarbeiter erteilt wurde
        /// </summary>
        public DateTime Erteilt { get; set; }
        /// <summary>
        /// Liste aller zum Auftrag zugehörigen Tätigkeiten
        /// </summary>
        /// <seealso cref="List{T}"/>
        public List<Taetigkeit> Taetigkeiten { get; set; }
        /// <summary>
        /// Zeigt an, ob der Auftrag schon erledigt wurde
        /// </summary>
        public bool Erledigt { get; set; }
        /// <summary>
        /// Enthält die gesamte bisher für den Auftrag benötigte Zeit
        /// </summary>
        /// <value>
        /// Der Wert von ZeitGesamt wird durch die Methode <see cref="AuftragZeitGesamt"/> berechnet
        /// </value>
        public double ZeitGesamt
        {
            get { return AuftragZeitGesamt(); }
        }

        /// <summary>
        /// Klassenkonstruktor für die Klasse Auftrag
        /// </summary>
        public Auftrag()
        {
            Taetigkeiten = new List<Taetigkeit>();
        }

        /// <summary>
        /// Berechnet die gesamte bisher für den Auftrag benötigte Zeit aus der Summe der Zeiten (--> <see cref="Taetigkeit.Minuten"/>) aller Tätigkeiten 
        /// </summary>
        /// <returns>Gesamtarbeitszeit für einen Auftrag in Minuten als double</returns>
        private double AuftragZeitGesamt()
        {
            double auftragZeitGesamt = 0;
            if (Taetigkeiten != null)
            {
                foreach (Taetigkeit tat in Taetigkeiten)
                {
                    auftragZeitGesamt += tat.Minuten;
                }
                return auftragZeitGesamt;
            }
            else
            {
                return 0;
            }
        }
    }
}
