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