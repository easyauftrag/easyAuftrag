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
        /// <param name="anfang">Anfang des Zeitraums der Berechnung</param>
        /// <param name="ende">Ende des Zeitraums der Berechnung</param>
        /// <param name="taetigkeitsListe">Liste aller Tätigkeiten</param>
        /// <param name="mitarbeiterID">Primärschlüssel des Mitarbeiters in der Datenbank</param>
        /// <returns></returns>
        public static double ArbeitsZeit(DateTime anfang, DateTime ende, List<Taetigkeit> taetigkeitsListe, int mitarbeiterID)
        {
            List<Taetigkeit> gefilterteTatListe = taetigkeitsListe.Where(t => t.MitarbeiterID == mitarbeiterID).ToList();
            gefilterteTatListe = gefilterteTatListe.Where(t => t.Datum >= anfang).ToList();
            gefilterteTatListe = gefilterteTatListe.Where(t => t.Datum <= ende).ToList();

            double arbeitszeit = 0;

            foreach (Taetigkeit tat in gefilterteTatListe)
            {
                arbeitszeit += tat.Minuten;
            }

            return arbeitszeit;
        }
    }
}
