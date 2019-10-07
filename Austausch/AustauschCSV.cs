using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Model;

namespace Austausch
{
    /// <summary>
    /// Klasse mit Methoden zum Schreiben und Lesen von CSV Dateien
    /// </summary>
    /// <seealso cref="IAustausch"/>
    public class AustauschCSV : IAustausch
    {
        /// <summary>
        /// Datentrenner in der CSV Datei, standardmäßig ein Semikolon
        /// </summary>
        private string _datenTrenner = ";";
        /// <summary>
        /// <see cref="CultureInfo"/> zum Definieren des Dezimaltrenners in der CSV Datei
        /// </summary>
        private CultureInfo _culture = new CultureInfo("de-DE");

        /// <summary>
        /// Konstruktor zum Erstellen eines AustauschCSV Objekts.
        /// Legt den Dezimal- und Datentrenner für den In-/Export im CSV Format fest.
        /// </summary>
        /// <param name="trennerDezimal">Dezimaltrenner für In-/Export im CSV Format</param>
        /// <param name="trennerDaten">Datentrenner für In-/Export im CSV Format</param>
        /// <seealso cref="CSVConfigTypen"/>
        public AustauschCSV(CSVConfigTypen.DezimalTrenner trennerDezimal, CSVConfigTypen.DatenTrenner trennerDaten)
        {
            // Falls der Dezimaltrenner auf Komma gesetzt wurde, wird _culture auf de-DE gesetzt
            if (trennerDezimal == CSVConfigTypen.DezimalTrenner.Komma)
            {
                _culture = new CultureInfo("de-DE");
            }
            // Falls der Dezimaltrenner auf Punkt gesetzt wurde, wird _culture auf en-US gesetzt
            else if (trennerDezimal == CSVConfigTypen.DezimalTrenner.Punkt)
            {
                _culture = new CultureInfo("en-US");
            }
            // Falls der Datentrenner auf Semikolon gesetzt wurde, wird _datenTrenner auf ";" gesetzt
            if (trennerDaten == CSVConfigTypen.DatenTrenner.Semikolon)
            {
                _datenTrenner = ";";
            }
            // Falls der Datentrenner auf Komma gesetzt wurde, wird _datenTrenner auf "," gesetzt
            else if (trennerDaten == CSVConfigTypen.DatenTrenner.Komma)
            {
                _datenTrenner = ",";
            }
            // Falls der Datentrenner auf Tabulator gesetzt wurde, wird _datenTrenner auf "\t" gesetzt
            else if (trennerDaten == CSVConfigTypen.DatenTrenner.Tab)
            {
                _datenTrenner = "\t";
            }
        }

        /// <summary>
        /// Liest Aufträge aus einer CSV Datei
        /// </summary>
        /// <param name="importPfad">Pfad der CSV Datei</param>
        /// <returns>Liste von Auftragsobjekten</returns>
        /// <seealso cref="Auftrag"/>
        public List<Auftrag> AuftragLesen(string importPfad)
        {
            List<Auftrag> lstAuftrag = new List<Auftrag>();
            try
            {
                // Erzeugt einen StreamReader für die Datei
                TextReader reader = new StreamReader(importPfad);
                // Deklariert und initialisiert die Variable line mit der ersten Zeile der CSV Datei, also dem Header, welchen wir nicht auslesen wollen
                string line = reader.ReadLine();

                // Solange die Zeile noch Daten enthält wird sie weiter ausgelesen und in eine Liste von Aufträgen geschrieben
                while (!string.IsNullOrEmpty(line = reader.ReadLine()))
                {
                    // Die Zeile wird am Datentrenner in ein Array aus Strings aufgespalten
                    string[] auftragItems = line.Split(_datenTrenner.ToCharArray());

                    // Die Daten in den Zellen des Arrays werden in die einzelnen Eigenschaften eines Auftragobjekts geschrieben
                    Auftrag auftrag = new Auftrag();
                    auftrag.AuftragID = Convert.ToInt32(string.Format(auftragItems[0]), _culture);
                    auftrag.AuftragNummer = auftragItems[1].Trim();
                    auftrag.KundeID = Convert.ToInt32(string.Format(auftragItems[2]), _culture);
                    auftrag.Eingang = DateTime.Parse(auftragItems[3], _culture);
                    auftrag.Erteilt = DateTime.Parse(auftragItems[4], _culture);
                    auftrag.Erledigt = Convert.ToBoolean(auftragItems[5]);
                    auftrag.Abgerechnet = Convert.ToBoolean(auftragItems[6]);

                    // Das Auftragsobjekt wird einer Liste von Aufträgen angefügt
                    lstAuftrag.Add(auftrag);
                }

            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
            // Die Liste wird zurückgegeben
            return lstAuftrag;
        }

        /// <summary>
        /// Schreibt Aufträge in eine CSV Datei
        /// </summary>
        /// <param name="exportPfad">Pfad der CSV Datei</param>
        /// <param name="lstAuftrag">Liste von Auftragsobjekten</param>
        /// <seealso cref="Auftrag"/>
        public void AuftragSchreiben(string exportPfad, List<Auftrag> lstAuftrag)
        {
            try
            {
                // Erzeugt einen StreamWriter für die Datei
                TextWriter writer = new StreamWriter(exportPfad);
                // Schreibt den Header der Datei
                writer.WriteLine("AuftragID; AuftragNummer; KundeID; Eingang; Erteilt; Erledigt; Abgerechnet");

                // Geht durch die Aufträge in der Liste und schreibt diese Zeile für Zeile in die CSV Datei
                foreach (var item in lstAuftrag)
                {
                    writer.WriteLine(item.AuftragID.ToString(_culture) + _datenTrenner
                        + item.AuftragNummer + _datenTrenner
                        + item.KundeID.ToString(_culture) + _datenTrenner
                        + item.Eingang + _datenTrenner
                        + item.Erteilt + _datenTrenner
                        + item.Erledigt + _datenTrenner
                        + item.Abgerechnet);
                }

                writer.Flush();
                writer.Close();
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        /// <summary>
        /// Liest Kunden aus einer CSV Datei
        /// </summary>
        /// <param name="importPfad">Pfad der CSV Datei</param>
        /// <returns>Liste von Kundenobjekten</returns>
        /// <seealso cref="Kunde"/>
        public List<Kunde> KundeLesen(string importPfad)
        {
            List<Kunde> lstKunde = new List<Kunde>();
            try
            {
                // Erzeugt einen StreamReader für die Datei
                TextReader reader = new StreamReader(importPfad);
                // Deklariert und initialisiert die Variable line mit der ersten Zeile der CSV Datei, also dem Header, welchen wir nicht auslesen wollen
                string line = reader.ReadLine();

                // Solange die Zeile noch Daten enthält wird sie weiter ausgelesen und in eine Liste von Kunden geschrieben
                while (!string.IsNullOrEmpty(line = reader.ReadLine()))
                {
                    // Die Zeile wird am Datentrenner in ein Array aus Strings aufgespalten
                    string[] kundeItems = line.Split(_datenTrenner.ToCharArray());

                    // Die Daten in den Zellen des Arrays werden in die einzelnen Eigenschaften eines Kundenobjekts geschrieben
                    Kunde kunde = new Kunde();
                    kunde.KundeID = Convert.ToInt32(string.Format(kundeItems[0]), _culture);
                    kunde.Name = kundeItems[1].Trim();
                    kunde.Strasse = kundeItems[2].Trim();
                    kunde.Hausnr = kundeItems[3].Trim();
                    kunde.PLZ = kundeItems[4].Trim();
                    kunde.Wohnort = kundeItems[5].Trim();
                    kunde.TelefonNr = kundeItems[6].Trim();

                    // Das Kundenobjekt wird einer Liste von Kunden angefügt
                    lstKunde.Add(kunde);
                }

            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
            // Die Liste wird zurückgegeben
            return lstKunde;
        }

        /// <summary>
        /// Schreibt Kunden in eine CSV Datei
        /// </summary>
        /// <param name="exportPfad">Pfad der CSV Datei</param>
        /// <param name="lstKunde">Liste von Kundenobjekten</param>
        /// <seealso cref="Kunde"/>
        public void KundeSchreiben(string exportPfad, List<Kunde> lstKunde)
        {
            try
            {
                // Erzeugt einen StreamWriter für die Datei
                TextWriter writer = new StreamWriter(exportPfad);
                // Schreibt den Header der Datei
                writer.WriteLine("KundeID; Name; Strasse; Hausnr; PLZ; Wohnort; TelefonNr");

                // Geht durch die Kunden in der Liste und schreibt diese Zeile für Zeile in die CSV Datei
                foreach (var item in lstKunde)
                {
                    writer.WriteLine(item.KundeID.ToString(_culture) + _datenTrenner
                        + item.Name + _datenTrenner
                        + item.Strasse + _datenTrenner
                        + item.Hausnr + _datenTrenner
                        + item.PLZ + _datenTrenner
                        + item.Wohnort + _datenTrenner
                        + item.TelefonNr);
                }

                writer.Flush();
                writer.Close();
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        /// <summary>
        /// Liest Mitarbeiter aus einer CSV Datei
        /// </summary>
        /// <param name="importPfad">Pfad der CSV Datei</param>
        /// <returns>Liste von Mitarbeiterobjekten</returns>
        /// <seealso cref="Mitarbeiter"/>
        public List<Mitarbeiter> MitarbeiterLesen(string importPfad)
        {
            List<Mitarbeiter> lstMitarbeiter = new List<Mitarbeiter>();
            try
            {
                // Erzeugt einen StreamReader für die Datei
                TextReader reader = new StreamReader(importPfad);
                // Deklariert und initialisiert die Variable line mit der ersten Zeile der CSV Datei, also dem Header, welchen wir nicht auslesen wollen
                string line = reader.ReadLine();

                // Solange die Zeile noch Daten enthält wird sie weiter ausgelesen und in eine Liste von Mitarbeitern geschrieben
                while (!string.IsNullOrEmpty(line = reader.ReadLine()))
                {
                    // Die Zeile wird am Datentrenner in ein Array aus Strings aufgespalten
                    string[] mitarbeiterItems = line.Split(_datenTrenner.ToCharArray());

                    // Die Daten in den Zellen des Arrays werden in die einzelnen Eigenschaften eines Mitarbeiterobjekts geschrieben
                    Mitarbeiter mitarbeiter = new Mitarbeiter();
                    mitarbeiter.MitarbeiterID = Convert.ToInt32(string.Format(mitarbeiterItems[0]), _culture);
                    mitarbeiter.Name = mitarbeiterItems[1].Trim();
                    mitarbeiter.TelefonNr = mitarbeiterItems[2].Trim();
                    mitarbeiter.Strasse = mitarbeiterItems[3].Trim();
                    mitarbeiter.Hausnr = mitarbeiterItems[4].Trim();
                    mitarbeiter.PLZ = mitarbeiterItems[5].Trim();
                    mitarbeiter.Wohnort = mitarbeiterItems[6].Trim();
                    mitarbeiter.AuslastungStelle = Convert.ToInt32(string.Format(mitarbeiterItems[7]), _culture);

                    // Das Mitarbeiterobjekt wird zu einer Liste von Mitarbeitern hinzugefügt
                    lstMitarbeiter.Add(mitarbeiter);
                }

            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
            // Die Liste wird zurückgegeben
            return lstMitarbeiter;
        }

        /// <summary>
        /// Schreibt Mitarbeiter in eine CSV Datei
        /// </summary>
        /// <param name="exportPfad">Pfad der CSV Datei</param>
        /// <param name="lstMitarbeiter">Liste von Mitarbeiterobjekten</param>
        /// <seealso cref="Mitarbeiter"/>
        public void MitarbeiterSchreiben(string exportPfad, List<Mitarbeiter> lstMitarbeiter)
        {
            try
            {
                // Erzeugt einen StreamWriter für die Datei
                TextWriter writer = new StreamWriter(exportPfad);
                // Schreibt den Header der Datei
                writer.WriteLine("MitarbeiterID; Name; TelefonNr; Strasse; Hausnr; PLZ; Wohnort; AuslastungStelle");

                // Geht durch die Liste und schreibt die Objekte Zeile für Zeile in die Datei
                foreach (var item in lstMitarbeiter)
                {
                    writer.WriteLine(item.MitarbeiterID.ToString(_culture) + _datenTrenner
                        + item.Name + _datenTrenner
                        + item.TelefonNr + _datenTrenner
                        + item.Strasse + _datenTrenner
                        + item.Hausnr + _datenTrenner
                        + item.PLZ + _datenTrenner
                        + item.Wohnort + _datenTrenner
                        + item.AuslastungStelle.ToString(_culture));
                }

                writer.Flush();
                writer.Close();
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        /// <summary>
        /// Liest Tätigkeiten aus Einer CSV Datei
        /// </summary>
        /// <param name="importPfad">Pfad zur CSV Datei</param>
        /// <returns>Liste von Taetigkeitsobjekten</returns>
        /// <seealso cref="Taetigkeit"/>
        public List<Taetigkeit> TaetigkeitLesen(string importPfad)
        {
            List<Taetigkeit> lstTaetigkeit = new List<Taetigkeit>();
            try
            {
                // Erzeugt einen StreamReader für die Datei
                TextReader reader = new StreamReader(importPfad);

                // Deklariert und initialisiert die Variable line mit der ersten Zeile der CSV Datei, also dem Header, welchen wir nicht auslesen wollen
                string line = reader.ReadLine();

                // Solange die Zeile noch Daten enthält wird sie weiter ausgelesen und in eine Liste von Tätigkeiten geschrieben
                while (!string.IsNullOrEmpty(line = reader.ReadLine()))
                {
                    // Die Zeile wird am Datentrenner in ein Array aus Strings aufgespalten
                    string[] taetigkeitItems = line.Split(_datenTrenner.ToCharArray());

                    // Die Daten in den Zellen des Arrays werden in die einzelnen Eigenschaften eines Taetigkeitsobjekts geschrieben
                    Taetigkeit taetigkeit = new Taetigkeit();
                    taetigkeit.TaetigkeitID = Convert.ToInt32(string.Format(taetigkeitItems[0]), _culture);
                    taetigkeit.AuftragID = Convert.ToInt32(string.Format(taetigkeitItems[1]), _culture);
                    taetigkeit.MitarbeiterID = Convert.ToInt32(string.Format(taetigkeitItems[2]), _culture);
                    taetigkeit.Datum = DateTime.Parse(taetigkeitItems[3]);
                    taetigkeit.Name = taetigkeitItems[4].Trim();
                    taetigkeit.StartZeit = TimeSpan.Parse(taetigkeitItems[5]);
                    taetigkeit.EndZeit = TimeSpan.Parse(taetigkeitItems[6]);

                    // Die Tätigkeit wird der Tätigkeitsliste hinzugefügt
                    lstTaetigkeit.Add(taetigkeit);
                }

            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
            // Die Liste wird zurückgegeben
            return lstTaetigkeit;
        }

        /// <summary>
        /// Schreibt Tätigkeiten in eine CSV Datei
        /// </summary>
        /// <param name="exportPfad">Pfad zur CSV Datei</param>
        /// <param name="lstTaetigkeit">Liste von Taetigkeitsobjekten</param>
        /// <seealso cref="Taetigkeit"/>
        public void TaetigkeitSchreiben(string exportPfad, List<Taetigkeit> lstTaetigkeit)
        {
            try
            {
                // Erzeugt einen StreamWriter für die Datei
                TextWriter writer = new StreamWriter(exportPfad);
                // Schreibt den Header in die Datei
                writer.WriteLine("TaetigkeitID; AuftragID; MitarbeiterID; Datum; Name; StartZeit; EndZeit");

                // Schreibt jedes Element der Liste Zeile für Zeile in die Datei
                foreach (var item in lstTaetigkeit)
                {
                    writer.WriteLine(item.TaetigkeitID.ToString(_culture) + _datenTrenner
                        + item.AuftragID.ToString(_culture) + _datenTrenner
                        + item.MitarbeiterID.ToString(_culture) + _datenTrenner
                        + item.Datum + _datenTrenner
                        + item.Name + _datenTrenner
                        + item.StartZeit + _datenTrenner
                        + item.EndZeit);
                }

                writer.Flush();
                writer.Close();
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }
        /// <summary>
        /// Schreibt Adressen in eine CSV Datei
        /// </summary>
        /// <param name="exportPfad">Pfad zur CSV Datei</param>
        /// <param name="lstAdressen">Liste von Adressobjekten</param>
        /// <seealso cref="Adresse"/>
        public void AdresseSchreiben(string exportPfad, List<Adresse> lstAdresse)
        {
            try
            {
                // Erzeugt einen StreamWriter für die Datei
                TextWriter writer = new StreamWriter(exportPfad);
                // Schreibt den Header in die Datei
                writer.WriteLine("AdresseID; KundeID; Strasse; Hausnr; PLZ; Wohnort");

                // Schreibt jedes Element der Liste Zeile für Zeile in die Datei
                foreach (var item in lstAdresse)
                {
                    writer.WriteLine(item.AdresseID.ToString(_culture) + _datenTrenner
                        + item.KundeID.ToString(_culture) + _datenTrenner
                        + item.Strasse + _datenTrenner
                        + item.Hausnr + _datenTrenner
                        + item.PLZ + _datenTrenner
                        + item.Wohnort);
                }

                writer.Flush();
                writer.Close();
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }
    }
}
