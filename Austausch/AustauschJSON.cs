﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Core.Model;
using System.Linq;
using Core;

namespace Austausch
{
    /// <summary>
    /// Klasse mit Methoden zum Schreiben und Lesen von JSON Dateien
    /// </summary>
    /// <seealso cref="IAustausch"/>
    public class AustauschJSON : IAustausch
    {
        /// <summary>
        /// Liest Aufträge aus eine JSON Datei
        /// </summary>
        /// <param name="importPfad">Pfad der JSON Datei</param>
        /// <returns>Liste mit Auftragsobjekten</returns>
        /// <seealso cref="Auftrag"/>
        public List<Auftrag> AuftragLesen(string importPfad)
        {
            List<Auftrag> lstAuftrag = new List<Auftrag>();
            try
            {
                // Erzeugt einen StreamReader für die Datei und liest diese in einen String
                TextReader reader = new StreamReader(importPfad);
                string json = reader.ReadToEnd();
                reader.Close();

                // Liest den String in ein JSON Array
                JArray jauftraege = JArray.Parse(json);

                // Konvertiert die das JSON Array in eine Liste mit Aufträgen
                lstAuftrag = jauftraege.Select(a => new Auftrag
                {
                    AuftragID = (int)a["AuftragID"],
                    AuftragNummer = (string)a["AuftragNummer"],
                    KundeID = (int)a["KundeID"],
                    Eingang = (DateTime)a["Eingang"],
                    Erteilt = (DateTime)a["Erteilt"],
                    Erledigt = (bool)a["Erledigt"],
                    Abgerechnet = (bool)a["Abgerechnet"]
                }).ToList();


            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
            // Gibt die Liste zurück
            return lstAuftrag;
        }

        /// <summary>
        /// Schreibt Aufträge in eine JSON Datei
        /// </summary>
        /// <param name="exportPfad">Pfad der JSON Datei</param>
        /// <param name="lstAuftrag">Liste mit Auftragsobjekten</param>
        /// <seealso cref="Auftrag"/>
        public void AuftragSchreiben(string exportPfad, List<Auftrag> lstAuftrag)
        {
            try
            {
                // Konvertiert die Liste in ein Array und dieses in einen String im JSON Format
                var json = JsonConvert.SerializeObject(lstAuftrag.ToArray());

                // Schreibt den String in die Datei
                File.WriteAllText(exportPfad, json);
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        /// <summary>
        /// Liest Kunden aus einer JSON Datei
        /// </summary>
        /// <param name="importPfad">Pfad der JSON Datei</param>
        /// <returns>Liste mit Kundenobjekten</returns>
        /// <seealso cref="Kunde"/>
        public List<Kunde> KundeLesen(string importPfad)
        {
            List<Kunde> lstKunde = new List<Kunde>();
            try
            {
                // Erzeugt einen StreamReader für die Datei und liest diese in einen String
                TextReader reader = new StreamReader(importPfad);
                string json = reader.ReadToEnd();
                reader.Close();

                // Liest den String in ein JSON Array
                JArray jkunden = JArray.Parse(json);

                // Konvertiert das JSON Array in eine Liste mit Kunden
                lstKunde = jkunden.Select(k => new Kunde
                {
                    KundeID = (int)k["KundeID"],
                    Name = (string)k["Name"],
                    Strasse = (string)k["Strasse"],
                    Hausnr = (string)k["Hausnr"],
                    PLZ = (string)k["PLZ"],
                    Wohnort = (string)k["Wohnort"],
                    TelefonNr = (string)k["TelefonNr"]
                }).ToList();


            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
            // Gibt die Liste zurück
            return lstKunde;
        }

        /// <summary>
        /// Schreibt Kunden in eine JSON Datei
        /// </summary>
        /// <param name="exportPfad">Pfad der JSON Datei</param>
        /// <param name="lstKunde">Liste mit Kundenobjekten</param>
        /// <seealso cref="Kunde"/>
        public void KundeSchreiben(string exportPfad, List<Kunde> lstKunde)
        {
            try
            {
                // Konvertiert die Liste in ein Array und dieses in einen String im JSON Format
                var json = JsonConvert.SerializeObject(lstKunde.ToArray());

                // Schreibt den String in die Datei
                File.WriteAllText(exportPfad, json);
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        /// <summary>
        /// Liest Mitarbeiter aus einer JSON Datei
        /// </summary>
        /// <param name="importPfad">Pfad der JSON Datei</param>
        /// <returns>Liste mit Mitarbeiterobjekten</returns>
        /// <seealso cref="Mitarbeiter"/>
        public List<Mitarbeiter> MitarbeiterLesen(string importPfad)
        {
            List<Mitarbeiter> lstMitarbeiter = new List<Mitarbeiter>();
            try
            {
                // Erzeugt einen StreamReader für die Datei und liest diese in einen String
                TextReader reader = new StreamReader(importPfad);
                string json = reader.ReadToEnd();
                reader.Close();

                // Liest den String in ein JSON Array
                JArray jmitarbeiters = JArray.Parse(json);

                // Konvertiert das JSON Array in eine Liste mit Mitarbeitern
                lstMitarbeiter = jmitarbeiters.Select(m => new Mitarbeiter
                {
                    MitarbeiterID = (int)m["MitarbeiterID"],
                    Name = (string)m["Name"],
                    TelefonNr = (string)m["TelefonNr"],
                    Strasse = (string)m["Strasse"],
                    Hausnr = (string)m["Hausnr"],
                    PLZ = (string)m["PLZ"],
                    Wohnort = (string)m["Wohnort"]
                }).ToList();


            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
            // Gibt die Liste zurück
            return lstMitarbeiter;
        }

        /// <summary>
        /// Schreibt Mitarbeiter in eine JSON Datei
        /// </summary>
        /// <param name="exportPfad">Pfad der JSON Datei</param>
        /// <param name="lstMitarbeiter">Liste mit Mitarbeiterobjekten</param>
        /// <seealso cref="Mitarbeiter"/>
        public void MitarbeiterSchreiben(string exportPfad, List<Mitarbeiter> lstMitarbeiter)
        {
            try
            {
                // Konvertiert die Liste in ein Array und dieses in einen String im JSON Format
                var json = JsonConvert.SerializeObject(lstMitarbeiter.ToArray());

                // Schreibt den String in die Datei
                File.WriteAllText(exportPfad, json);
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        /// <summary>
        /// Liest Tätigkeiten aus einer JSON Datei
        /// </summary>
        /// <param name="importPfad">Pfad der JSON Datei</param>
        /// <returns>Liste mit Taetigkeitsobjekten</returns>
        /// <seealso cref="Taetigkeit"/>
        public List<Taetigkeit> TaetigkeitLesen(string importPfad)
        {
            List<Taetigkeit> lstTaetigkeit = new List<Taetigkeit>();
            try
            {
                // Erzeugt einen StreamReader für die Datei und liest diese in einen String
                TextReader reader = new StreamReader(importPfad);
                string json = reader.ReadToEnd();
                reader.Close();

                // Liest den String in ein JSON Array
                JArray jtaetigkeiten = JArray.Parse(json);

                // Konvertiert das JSON Array in eine Liste mit Tätigkeiten
                lstTaetigkeit = jtaetigkeiten.Select(t => new Taetigkeit
                {
                    TaetigkeitID = (int)t["TaetigkeitID"],
                    AuftragID = (int)t["AuftragID"],
                    MitarbeiterID = (int)t["MitarbeiterID"],
                    Datum = (DateTime)t["Datum"],
                    Name = (string)t["Name"],
                    StartZeit = (TimeSpan)t["StartZeit"],
                    EndZeit = (TimeSpan)t["EndZeit"]
                }).ToList();


            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
            // Gibt die Liste zurück
            return lstTaetigkeit;
        }

        /// <summary>
        /// Schreibt Tätigkeiten in eine JSON Datei
        /// </summary>
        /// <param name="exportPfad">Pfad der JSON Datei</param>
        /// <param name="lstTaetigkeit">Liste mit Taetigkeitsobjekten</param>
        /// <seealso cref="Taetigkeit"/>
        public void TaetigkeitSchreiben(string exportPfad, List<Taetigkeit> lstTaetigkeit)
        {
            try
            {
                // Konvertiert die Liste in ein Array und dieses in einen String im JSON Format
                var json = JsonConvert.SerializeObject(lstTaetigkeit.ToArray());

                // Schreibt den String in die Datei
                File.WriteAllText(exportPfad, json);
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }
    }
}
