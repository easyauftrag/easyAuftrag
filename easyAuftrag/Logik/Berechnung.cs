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

using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyAuftrag.Logik
{
    /// <summary>
    /// Klasse für Berechnungsmethoden
    /// </summary>
    public static class Berechnung
    {
        /// <summary>
        /// Methode zur Berechnung der Arbeitszeit eines Mitarbeiters in einem vorgegebenen Zeitraum
        /// </summary>
        /// <param name="stundenDoc">Enthält: Anfang des Zeitraums der Berechnung,
        /// Ende des Zeitraums der Berechnung,
        /// den Mitarbeiter, für den Die Arbeitsstunden berechnet werden,
        /// Liste aller Tätigkeiten des Mitarbeiters</param>
        /// <returns>Geleistete Arbeitszeit in Stunden (--> <see cref="Taetigkeit.Minuten"/>)</returns>
        public static double ArbeitsZeit(StundenDoc stundenDoc)
        {
            double arbeitszeit = 0;

            foreach (Taetigkeit tat in stundenDoc.Tatlist)
            {
                arbeitszeit += tat.Minuten;
            }

            return Math.Round(arbeitszeit/60, 2);
        }

        /// <summary>
        /// Berechnet die gesamte bisher für den Auftrag benötigte Zeit aus der Summe der Zeiten 
        /// (--> <see cref="Taetigkeit.Minuten"/>) aller Tätigkeiten 
        /// </summary>
        /// <returns>Gesamtarbeitszeit für einen Auftrag in Minuten als double</returns>
        public static double AuftragZeitGesamt(List<Taetigkeit> Taetigkeiten)
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
