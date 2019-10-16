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
        public void KundeAnlegen(Kunde kunde, string connection)
        {
            try
            {
                using (var db = new EasyAuftragContext(connection))
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
        /// <seealso cref="EasyAuftragContext"/>
        public bool KundeBearbeiten(Kunde kunde, int kundeID, string connection)
        {
            try
            {
                using (var db = new EasyAuftragContext(connection))
                {
                    if (db.Kunden.Find(kundeID) != null)
                    {
                        db.Kunden.Find(kundeID).Name = kunde.Name;
                        db.Kunden.Find(kundeID).Strasse = kunde.Strasse;
                        db.Kunden.Find(kundeID).Hausnr = kunde.Hausnr;
                        db.Kunden.Find(kundeID).PLZ = kunde.PLZ;
                        db.Kunden.Find(kundeID).Wohnort = kunde.Wohnort;
                        db.Kunden.Find(kundeID).TelefonNr = kunde.TelefonNr;
                        db.Kunden.Find(kundeID).WeitereAdressen = kunde.WeitereAdressen;
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
                return false;
            }
        }

        /// <summary>
        /// Löscht den Kunden, dessen ID übergeben wird.
        /// </summary>
        /// <param name="kundeID">Primärschlüssel des Kunden in der Datenbank</param>
        /// <seealso cref="EasyAuftragContext"/>
        public bool KundeLoeschen(int kundeID, string connection)
        {
            try
            {
                using (var db = new EasyAuftragContext(connection))
                {
                    if (db.Kunden.Find(kundeID) != null)
                    {
                        db.Kunden.Remove(db.Kunden.Find(kundeID));
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
                    return false;
            }
        }

        /// <summary>
        /// Legt einen neuen Auftrag mit den übergebenen Daten in der Datenbank an.
        /// </summary>
        /// <param name="auftrag">Daten des neuen Auftrags</param>
        /// <seealso cref="EasyAuftragContext"/>
        public void AuftragAnlegen(Auftrag auftrag, string connection)
        {
            try
            {
                using (var db = new EasyAuftragContext(connection))
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
        public bool AuftragBearbeiten(Auftrag auftrag, int auftragID, string connection)
        {
            try
            {
                using (var db = new EasyAuftragContext(connection))
                {
                    if (db.Auftraege.Find(auftragID) != null)
                    {
                        db.Auftraege.Find(auftragID).AuftragNummer = auftrag.AuftragNummer;
                        db.Auftraege.Find(auftragID).Eingang = auftrag.Eingang;
                        db.Auftraege.Find(auftragID).Erteilt = auftrag.Erteilt;
                        db.Auftraege.Find(auftragID).Taetigkeiten = auftrag.Taetigkeiten;
                        db.Auftraege.Find(auftragID).Erledigt = auftrag.Erledigt;
                        db.Auftraege.Find(auftragID).Abgerechnet = auftrag.Abgerechnet;
                        db.Auftraege.Find(auftragID).KundeID = auftrag.KundeID;
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
                return false;
            }
        }

        /// <summary>
        /// Löscht den Auftrag, dessen ID übergeben wird.
        /// </summary>
        /// <param name="auftragID">Primärschlüssel des Auftrags in der Datenbank</param>
        /// <seealso cref="EasyAuftragContext"/>
        public bool AuftragLoeschen(int auftragID, string connection)
        {
            try
            {
                using (var db = new EasyAuftragContext(connection))
                {
                    if (db.Auftraege.Find(auftragID) != null)
                    {
                        db.Auftraege.Remove(db.Auftraege.Find(auftragID));
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
                return false;
            }
        }

        /// <summary>
        /// Legt einen neuen Mitarbeiter mit den übergebenen Daten in der Datenbank an.
        /// </summary>
        /// <param name="mitarbeiter">Daten des neuen Mitarbeiters</param>
        /// <seealso cref="EasyAuftragContext"/>
        public void MitarbeiterAnlegen(Mitarbeiter mitarbeiter, string connection)
        {
            try
            {
                using (var db = new EasyAuftragContext(connection))
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
        public bool MitarbeiterBearbeiten(Mitarbeiter mitarbeiter, int mitarbeiterID, string connection)
        {
            try
            {
                using (var db = new EasyAuftragContext(connection))
                {
                    if (db.Mitarbeiters.Find(mitarbeiterID) != null)
                    {
                        db.Mitarbeiters.Find(mitarbeiterID).Name = mitarbeiter.Name;
                        db.Mitarbeiters.Find(mitarbeiterID).Strasse = mitarbeiter.Strasse;
                        db.Mitarbeiters.Find(mitarbeiterID).Hausnr = mitarbeiter.Hausnr;
                        db.Mitarbeiters.Find(mitarbeiterID).PLZ = mitarbeiter.PLZ;
                        db.Mitarbeiters.Find(mitarbeiterID).Wohnort = mitarbeiter.Wohnort;
                        db.Mitarbeiters.Find(mitarbeiterID).TelefonNr = mitarbeiter.TelefonNr;
                        db.Mitarbeiters.Find(mitarbeiterID).AuslastungStelle = mitarbeiter.AuslastungStelle;
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
                return false;
            }
        }

        /// <summary>
        /// Löscht den Mitarbeiter, dessen ID übergeben wird.
        /// </summary>
        /// <param name="mitarbeiterID">Primärschlüssel des Mitarbeiters in der Datenbank</param>
        /// <seealso cref="EasyAuftragContext"/>
        public bool MitarbeiterLoeschen(int mitarbeiterID, string connection)
        {
            try
            {
                using (var db = new EasyAuftragContext(connection))
                {
                    if (db.Mitarbeiters.Find(mitarbeiterID) != null)
                    {
                        db.Mitarbeiters.Remove(db.Mitarbeiters.Find(mitarbeiterID));
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
                return false;
            }
        }

        /// <summary>
        /// Legt eine neue Tätigkeit mit den übergebenen Daten in der Datenbank an.
        /// </summary>
        /// <param name="taetigkeit">Daten der neuen Tätigkeit</param>
        /// <seealso cref="EasyAuftragContext"/>
        public void TaetigkeitAnlegen(Taetigkeit taetigkeit, string connection)
        {
            try
            {
                using (var db = new EasyAuftragContext(connection))
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
        public bool TaetigkeitBearbeiten(Taetigkeit taetigkeit, int taetigkeitID, string connection)
        {
            try
            {
                using (var db = new EasyAuftragContext(connection))
                {
                    if (db.Taetigkeiten.Find(taetigkeitID) != null)
                    {
                        db.Taetigkeiten.Find(taetigkeitID).AuftragID = taetigkeit.AuftragID;
                        db.Taetigkeiten.Find(taetigkeitID).MitarbeiterID = taetigkeit.MitarbeiterID;
                        db.Taetigkeiten.Find(taetigkeitID).Name = taetigkeit.Name;
                        db.Taetigkeiten.Find(taetigkeitID).Datum = taetigkeit.Datum;
                        db.Taetigkeiten.Find(taetigkeitID).StartZeit = taetigkeit.StartZeit;
                        db.Taetigkeiten.Find(taetigkeitID).EndZeit = taetigkeit.EndZeit;
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
                return false;
            }
        }

        /// <summary>
        /// Löscht die Tätigkeit, deren ID übergeben wird.
        /// </summary>
        /// <param name="taetigkeitID">Primärschlüssel der Tätigkeit in der Datenbank</param>
        /// <seealso cref="EasyAuftragContext"/>
        public bool TaetigkeitLoeschen(int taetigkeitID, string connection)
        {
            try
            {
                using (var db = new EasyAuftragContext(connection))
                {
                    if (db.Taetigkeiten.Find(taetigkeitID) != null)
                    {
                        db.Taetigkeiten.Remove(db.Taetigkeiten.Find(taetigkeitID));
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
                return false;
            }
        }
        /// <summary>
        /// Legt eine neue Adresse mit den übergebenen Daten in der Datenbank an.
        /// </summary>
        /// <param name="adresse">Daten des neuen Kunden</param>
        /// <seealso cref="EasyAuftragContext"/>
        public void AdresseAnlegen(Adresse adresse, string connection)
        {
            try
            {
                using (var db = new EasyAuftragContext(connection))
                {
                    db.Adressen.Add(adresse);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        /// <summary>
        /// Bearbeitet eine existierende Adresse mit den übergebenen Daten in der Datenbank.
        /// </summary>
        /// <param name="adresse">aktualisierte Daten des Kunden</param>
        /// <param name="adresseID">Primärschlüssel des Kunden in der Datenbank</param>
        /// <seealso cref="EasyAuftragContext"/>
        public bool AdresseBearbeiten(Adresse adresse, int adresseID, string connection)
        {
            try
            {
                using (var db = new EasyAuftragContext(connection))
                {
                    if (db.Adressen.Find(adresseID) != null)
                    {
                        db.Adressen.Find(adresseID).KundeID = adresse.KundeID;
                        db.Adressen.Find(adresseID).Strasse = adresse.Strasse;
                        db.Adressen.Find(adresseID).Hausnr = adresse.Hausnr;
                        db.Adressen.Find(adresseID).PLZ = adresse.PLZ;
                        db.Adressen.Find(adresseID).Wohnort = adresse.Wohnort;
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
                return false;
            }
        }

        /// <summary>
        /// Löscht die Adresse, deren ID übergeben wird.
        /// </summary>
        /// <param name="adresseID">Primärschlüssel des Kunden in der Datenbank</param>
        /// <seealso cref="EasyAuftragContext"/>
        public bool AdresseLoeschen(int adresseID, string connection)
        {
            try
            {
                using (var db = new EasyAuftragContext(connection))
                {
                    if (db.Adressen.Find(adresseID) != null)
                    {
                        db.Adressen.Remove(db.Adressen.Find(adresseID));
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
                return false;
            }
        }

        /// <summary>
        /// Legt ein neues Land mit den übergebenen Daten in der Datenbank an.
        /// </summary>
        /// <param name="land">Daten des neuen Landes</param>
        /// <seealso cref="EasyAuftragContext"/>
        public void LandAnlegen(Land land, string connection)
        {
            try
            {
                using (var db = new EasyAuftragContext(connection))
                {
                    db.Laender.Add(land);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        /// <summary>
        /// Bearbeitet ein existierendes Land mit den übergebenen Daten in der Datenbank.
        /// </summary>
        /// <param name="land">aktualisierte Daten des Landes</param>
        /// <param name="land_ID">Primärschlüssel des Landes in der Datenbank</param>
        /// <seealso cref="EasyAuftragContext"/>
        public bool LandBearbeiten(Land land, int land_ID, string connection)
        {
            try
            {
                using (var db = new EasyAuftragContext(connection))
                {
                    if (db.Laender.Find(land_ID) != null)
                    {
                        db.Laender.Find(land_ID).LandID = land.LandID;
                        db.Laender.Find(land_ID).Name = land.Name;
                        db.Laender.Find(land_ID).Vorwahl = land.Vorwahl;
                        db.Laender.Find(land_ID).Kuerzel = land.Kuerzel;
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
                return false;
            }
        }

        /// <summary>
        /// Löscht das Land, dessen ID übergeben wird.
        /// </summary>
        /// <param name="landID">Primärschlüssel des Landes in der Datenbank</param>
        /// <seealso cref="EasyAuftragContext"/>
        public bool LandLoeschen(int landID, string connection)
        {
            try
            {
                using (var db = new EasyAuftragContext(connection))
                {
                    if (db.Laender.Find(landID) != null)
                    {
                        db.Laender.Remove(db.Laender.Find(landID));
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
                return false;
            }
        }

        /// <summary>
        /// Gibt einen Kunden aus der Datenbank anhand der Kunden ID zurück
        /// </summary>
        /// <param name="kundeID"></param>
        /// <returns>Kunde aus Datenbank</returns>
        /// <seealso cref="EasyAuftragContext"/>
        public Kunde KundeLaden(int kundeID, out bool success, string connection)
        {
            Kunde kund = new Kunde();
            try
            {
                using (var db = new EasyAuftragContext(connection))
                {
                    if (db.Kunden.Find(kundeID) != null)
                    {
                        kund = (from k in db.Kunden select k).First(k => k.KundeID == kundeID);
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
                success = false;
            }
            return kund;
        }

        /// <summary>
        /// Gibt einen Auftrag aus der Datenbank anhand der Auftrag ID zurück
        /// </summary>
        /// <param name="auftragID"></param>
        /// <returns>Auftrag aus Datenbank</returns>
        /// <seealso cref="EasyAuftragContext"/>
        public Auftrag AuftragLaden(int auftragID, out bool success, string connection)
        {
            Auftrag auft = new Auftrag();
            try
            {
                using (var db = new EasyAuftragContext(connection))
                {
                    if (db.Auftraege.Find(auftragID) != null)
                    {
                        auft = (from k in db.Auftraege select k).First(k => k.AuftragID == auftragID);
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
                success = false;
            }
            return auft;
        }

        /// <summary>
        /// Gibt einen Mitarbeiter aus der Datenbank anhand der Mitarbeiter ID zurück
        /// </summary>
        /// <param name="mitarbeiterID"></param>
        /// <returns>Mitarbeiter aus Datenbank</returns>
        /// <seealso cref="EasyAuftragContext"/>
        public Mitarbeiter MitarbeiterLaden(int mitarbeiterID, out bool success, string connection)
        {
            Mitarbeiter mitarb = new Mitarbeiter();
            try
            {
                using (var db = new EasyAuftragContext(connection))
                {
                    if (db.Mitarbeiters.Find(mitarbeiterID) != null)
                    {
                        mitarb = (from k in db.Mitarbeiters select k).First(k => k.MitarbeiterID == mitarbeiterID);
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
                success = false;
            }
            return mitarb;
        }

        /// <summary>
        /// Gibt eine Taetigkeit aus der Datenbank anhand der Taetigkeit ID zurück
        /// </summary>
        /// <param name="taetigkeitID"></param>
        /// <returns>Taetigkeit aus Datenbank</returns>
        /// <seealso cref="EasyAuftragContext"/>
        public Taetigkeit TaetigkeitLaden(int taetigkeitID, out bool success, string connection)
        {
            Taetigkeit tat = new Taetigkeit();
            try
            {
                using (var db = new EasyAuftragContext(connection))
                {
                    if (db.Taetigkeiten.Find(taetigkeitID) != null)
                    {
                        tat = (from k in db.Taetigkeiten select k).First(k => k.TaetigkeitID == taetigkeitID);
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
                success = false;
            }
            return tat;
        }
        /// <summary>
        /// Gibt eine Adresse aus der Datenbank anhand der Adressen ID zurück
        /// </summary>
        /// <param name="adresseID"></param>
        /// <returns>Kunde aus Datenbank</returns>
        /// <seealso cref="EasyAuftragContext"/>
        public Adresse AdresseLaden(int adresseID, out bool success, string connection)
        {
            Adresse adr = new Adresse();
            try
            {
                using (var db = new EasyAuftragContext(connection))
                {
                    if (db.Adressen.Find(adresseID) != null)
                    {
                        adr = (from ad in db.Adressen select ad).First(ad => ad.AdresseID == adresseID);
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
                success = false;
            }
            return adr;
        }

        /// <summary>
        /// Gibt ein Land aus der Datenbank anhand der LandID zurück
        /// </summary>
        /// <param name="landID"></param>
        /// <returns>Land aus Datenbank</returns>
        /// <seealso cref="EasyAuftragContext"/>
        public Land LandLaden(int landID, out bool success, string connection)
        {
            Land land = new Land();
            try
            {
                using (var db = new EasyAuftragContext(connection))
                {
                    if (db.Laender.Find(landID) != null)
                    {
                        land = (from lnd in db.Laender select lnd).First(lnd => lnd.LandID == landID);
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
                success = false;
            }
            return land;
        }
    }
}
