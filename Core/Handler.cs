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
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    /// <summary>
    /// Handler-Klasse zum Anlegen, Bearbeiten und Löschen von Kunden, Aufträgen, Mitarbeitern und Tätigkeiten
    /// </summary>
    public class Handler
    {
        /// <summary>
        /// Legt einen neuen Kunden mit den übergebenen Daten in der Datenbank an.
        /// </summary>
        /// <param name="kunde">Daten des neuen Kunden</param>
        /// <seealso cref="EasyAuftragContext"/>
        public void KundeAnlegen(Kunde kunde)
        {
            try
            {
                using (var db = new EasyAuftragContext())
                {
                    db.Kunden.Add(kunde);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        /// <summary>
        /// Bearbeitet einen existierenden Kunden mit den übergebenen Daten in der Datenbank.
        /// </summary>
        /// <param name="kunde">aktualisierte Daten des Kunden</param>
        /// <param name="kundeID">Primärschlüssel des Kunden in der Datenbank</param>
        /// /// <seealso cref="EasyAuftragContext"/>
        public void KundeBearbeiten(Kunde kunde, int kundeID)
        {
            try
            {

            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        /// <summary>
        /// Löscht den Kunden, dessen ID übergeben wird.
        /// </summary>
        /// <param name="kundeID">Primärschlüssel des Kunden in der Datenbank</param>
        /// <seealso cref="EasyAuftragContext"/>
        public void KundeLoeschen(int kundeID)
        {

        }

        /// <summary>
        /// Legt einen neuen Auftrag mit den übergebenen Daten in der Datenbank an.
        /// </summary>
        /// <param name="auftrag">Daten des neuen Auftrags</param>
        /// <seealso cref="EasyAuftragContext"/>
        public void AuftragAnlegen(Auftrag auftrag)
        {
            try
            {
                using (var db = new EasyAuftragContext())
                {
                    db.Auftraege.Add(auftrag);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }

        }

        /// <summary>
        /// Bearbeitet einen existierenden Auftrag mit den übergebenen Daten in der Datenbank.
        /// </summary>
        /// <param name="auftrag">aktualisierte Daten des Auftrags</param>
        /// <param name="auftragID">Primärschlüssel des Auftrags in der Datenbank</param>
        /// <seealso cref="EasyAuftragContext"/>
        public void AuftragBearbeiten(Auftrag auftrag, int auftragID)
        {
            try
            {

                using (var db = new EasyAuftragContext())
                {
                    
                    if (db.Auftraege.Find(auftragID) != null)
                    {

                        db.Auftraege.Find(auftragID).AuftragNummer = auftrag.AuftragNummer;
                        db.Auftraege.Find(auftragID).Eingang = auftrag.Eingang;
                        db.Auftraege.Find(auftragID).Erteilt = auftrag.Erteilt;
                        db.Auftraege.Find(auftragID).Taetigkeiten = auftrag.Taetigkeiten;
                        db.Auftraege.Find(auftragID).Erledigt = auftrag.Erledigt;
                        db.Auftraege.Find(auftragID).KundeID = auftrag.KundeID;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        /// <summary>
        /// Löscht den Auftrag, dessen ID übergeben wird.
        /// </summary>
        /// <param name="auftragID">Primärschlüssel des Auftrags in der Datenbank</param>
        /// <seealso cref="EasyAuftragContext"/>
        public void AuftragLoeschen(int auftragID)
        {

        }

        /// <summary>
        /// Legt einen neuen Mitarbeiter mit den übergebenen Daten in der Datenbank an.
        /// </summary>
        /// <param name="mitarbeiter">Daten des neuen Mitarbeiters</param>
        /// <seealso cref="EasyAuftragContext"/>
        public void MitarbeiterAnlegen(Mitarbeiter mitarbeiter)
        {
            try
            {
                using (var db = new EasyAuftragContext())
                {
                    db.Mitarbeiters.Add(mitarbeiter);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        /// <summary>
        /// Bearbeitet einen existierenden Mitarbeiter mit den übergebenen Daten in der Datenbank.
        /// </summary>
        /// <param name="mitarbeiter">aktualisierte Daten des Mitarbeiters</param>
        /// <param name="mitarbeiterID">Primärschlüssel des Mitarbeiters in der Datenbank</param>
        /// <seealso cref="EasyAuftragContext"/>
        public void MitarbeiterBearbeiten(Mitarbeiter mitarbeiter, int mitarbeiterID)
        {

        }

        /// <summary>
        /// Löscht den Mitarbeiter, dessen ID übergeben wird.
        /// </summary>
        /// <param name="mitarbeiterID">Primärschlüssel des Mitarbeiters in der Datenbank</param>
        /// <seealso cref="EasyAuftragContext"/>
        public void MitarbeiterLoeschen(int mitarbeiterID)
        {

        }

        /// <summary>
        /// Legt eine neue Tätigkeit mit den übergebenen Daten in der Datenbank an.
        /// </summary>
        /// <param name="taetigkeit">Daten der neuen Tätigkeit</param>
        /// <seealso cref="EasyAuftragContext"/>
        public void TaetigkeitAnlegen(Taetigkeit taetigkeit)
        {
            try
            {
                using (var db = new EasyAuftragContext())
                {
                    db.Taetigkeiten.Add(taetigkeit);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }

        }

        /// <summary>
        /// Bearbeitet eine existierende Tätigkeit mit den übergebenen Daten in der Datenbank.
        /// </summary>
        /// <param name="taetigkeit">aktualisierte Daten der Tätigkeit</param>
        /// <param name="taetigkeitID">Primärschlüssel der Tätigkeit in der Datenbank</param>
        /// <seealso cref="EasyAuftragContext"/>
        public void TaetigkeitBearbeiten(Taetigkeit taetigkeit, int taetigkeitID)
        {

        }

        /// <summary>
        /// Löscht die Tätigkeit, deren ID übergeben wird.
        /// </summary>
        /// <param name="taetigkeitID">Primärschlüssel der Tätigkeit in der Datenbank</param>
        /// <seealso cref="EasyAuftragContext"/>
        public void TaetigkeitLoeschen(int taetigkeitID)
        {

        }

        /// <summary>
        /// Gibt einen Kunden aus der Datenbank anhand der Kunden ID zurück
        /// </summary>
        /// <param name="kundeID"></param>
        /// <returns>Kunde aus Datenbank</returns>
        public Kunde KundeLaden(int kundeID)
        {
            using (var db = new EasyAuftragContext())
            {
                List<Kunde> kunden = (from k in db.Kunden where k.KundeID == kundeID select k).ToList();
                return kunden.ElementAt(0);
            }
        }

        /// <summary>
        /// Gibt einen Auftrag aus der Datenbank anhand der Auftrag ID zurück
        /// </summary>
        /// <param name="auftragID"></param>
        /// <returns>Auftrag aus Datenbank</returns>
        public Auftrag AuftragLaden(int auftragID)
        {
            Auftrag auft = new Auftrag();
            try
            {
                using (var db = new EasyAuftragContext())
                {
                    auft = (from k in db.Auftraege select k).First(k => k.AuftragID == auftragID);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
            return auft;
        }

        /// <summary>
        /// Gibt einen Mitarbeiter aus der Datenbank anhand der Mitarbeiter ID zurück
        /// </summary>
        /// <param name="mitarbeiterID"></param>
        /// <returns>Mitarbeiter aus Datenbank</returns>
        public Mitarbeiter MitarbeiterLaden(int mitarbeiterID)
        {
            Mitarbeiter mitarb = new Mitarbeiter();
            try
            {
                using (var db = new EasyAuftragContext())
                {
                    mitarb = (from k in db.Mitarbeiters select k).First(k => k.MitarbeiterID == mitarbeiterID);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
            return mitarb;
        }

        /// <summary>
        /// Gibt eine Taetigkeit aus der Datenbank anhand der Taetigkeit ID zurück
        /// </summary>
        /// <param name="taetigkeitID"></param>
        /// <returns>Taetigkeit aus Datenbank</returns>
        public Taetigkeit TaetigkeitLaden(int taetigkeitID)
        {
            Taetigkeit tat = new Taetigkeit();
            try
            {
                using (var db = new EasyAuftragContext())
                {
                    tat = (from k in db.Taetigkeiten select k).First(k => k.TaetigkeitID == taetigkeitID);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
            return tat;
        }
    }
}
