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

namespace Austausch
{
    /// <summary>
    /// Schnittstelle zum Schreiben und Lesen in und von Datenobjekten aus easyAauftrag
    /// </summary>
    /// <remarks>
    /// Kann Auftrags-, Tätigkeits-, Kunden- und Mitarbeiterobjekte Schreiben und Lesen
    /// </remarks>
    interface IAustausch
    {
        /// <summary>
        /// Schreibt eine Liste von Auftragsobjekten in eine Datei
        /// </summary>
        /// <param name="exportPfad">Pfad zur Ausgabedatei</param>
        /// <param name="lstAuftrag">Liste von Auftragsobjekten</param>
        void AuftragSchreiben(string exportPfad, List<Auftrag> lstAuftrag);
        /// <summary>
        /// Schreibt eine Liste von Tätigkeitsobjekten in eine Datei
        /// </summary>
        /// <param name="exportPfad">Pfad zur Ausgabedatei</param>
        /// <param name="lstTaetigkeit">Liste von Tätigkeitsobjekten</param>
        void TaetigkeitSchreiben(string exportPfad, List<Taetigkeit> lstTaetigkeit);
        /// <summary>
        /// Schreibt eine Liste von Kundenobjekten in eine Datei
        /// </summary>
        /// <param name="exportPfad">Pfad zur Ausgabedatei</param>
        /// <param name="lstKunde">Liste von Kundenobjekten</param>
        void KundeSchreiben(string exportPfad, List<Kunde> lstKunde);
        /// <summary>
        /// Schreibt eine Liste von Mitarbeiterobjekten in eine Datei
        /// </summary>
        /// <param name="exportPfad">Pfad zur Ausgabedatei</param>
        /// <param name="lstMitarbeiter">Liste von Mitarbeiterobjekten</param>
        void MitarbeiterSchreiben(string exportPfad, List<Mitarbeiter> lstMitarbeiter);

        /// <summary>
        /// Liest eine Liste von Auftragsobjekten aus einer Datei
        /// </summary>
        /// <param name="importPfad">Pfad zur Datei</param>
        /// <returns>Liste von Auftragsobjekten</returns>
        List<Auftrag> AuftragLesen(string importPfad);
        /// <summary>
        /// Liest eine Liste von Tätigkeitsobjekten aus einer Datei
        /// </summary>
        /// <param name="importPfad">Pfad zur Datei</param>
        /// <returns>Liste von Tätigkeitsobjekten</returns>
        List<Taetigkeit> TaetigkeitLesen(string importPfad);
        /// <summary>
        /// Liest eine Liste von Kundenobjekten aus einer Datei
        /// </summary>
        /// <param name="importPfad">Pfad zur Datei</param>
        /// <returns>Liste von Kundenobjekten</returns>
        List<Kunde> KundeLesen(string importPfad);
        /// <summary>
        /// Liest eine Liste von Mitarbeiterobjekten aus einer Datei
        /// </summary>
        /// <param name="importPfad">Pfad zur Datei</param>
        /// <returns>Liste von Mitarbeiterobjekten</returns>
        List<Mitarbeiter> MitarbeiterLesen(string importPfad);
    }
}