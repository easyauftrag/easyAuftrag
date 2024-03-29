﻿/*
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
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Core;
using Core.Model;

namespace Austausch
{
    /// <summary>
    /// Klasse mit Methoden zum Schreiben und Lesen von XML Dateien
    /// </summary>
    /// <seealso cref="IAustausch"/>
    public class AustauschXML : IAustausch
    {
        /// <summary>
        /// Liest Aufträge aus eine XML Datei
        /// </summary>
        /// <param name="importPfad">Pfad der XML Datei</param>
        /// <returns>Liste mit Auftragsobjekten</returns>
        /// <seealso cref="Auftrag"/>
        public List<Auftrag> AuftragLesen(string importPfad)
        {
            List<Auftrag> lstAuftrag = new List<Auftrag>();
            try
            {
                // Erzeugt ein neues XMLDocument und lädt die Datei
                XmlDocument xml = new XmlDocument();
                xml.Load(importPfad);

                // Speichert alle Knoten mit dem Tag "Auftrag" in einer Liste
                XmlNodeList xmlAuftrag = xml.GetElementsByTagName("Auftrag");
                if (xmlAuftrag.Count > 0)
                {
                    // Geht durch die Liste der Knoten
                    foreach (XmlNode item in xmlAuftrag)
                    {
                        // Liest alle Eigenschaften in ein Auftragsobjekt
                        Auftrag auftrag = new Auftrag();

                        auftrag.AuftragNummer = item.Attributes["AuftragNummer"].Value.Trim();
                        if (int.TryParse(item.Attributes["AuftragID"].Value, out int auftragID))
                        {
                            auftrag.AuftragID = auftragID;
                        }
                        else
                        {
                            MessageBox.Show("Konnte AuftragID nicht einlesen.");
                        }
                        if (int.TryParse(item.Attributes["KundeID"].Value, out int kundeID))
                        {
                            auftrag.KundeID = kundeID;
                        }
                        else
                        {
                            MessageBox.Show("Konnte KundeID nicht einlesen.");
                        }
                        if(DateTime.TryParse(item.Attributes["Eingang"].Value, out DateTime eingang))
                        {
                            auftrag.Eingang = eingang;
                        }
                        else
                        {
                            MessageBox.Show("Konnte Eingangsdatum nicht einlesen.");
                        }
                        if (DateTime.TryParse(item.Attributes["Erteilt"].Value, out DateTime erteilt))
                        {
                            auftrag.Eingang = erteilt;
                        }
                        else
                        {
                            MessageBox.Show("Konnte Erteiltdatum nicht einlesen.");
                        }
                        if(bool.TryParse(item.Attributes["Erledigt"].Value, out bool erledigt))
                        {
                            auftrag.Erledigt = erledigt;
                        }
                        else
                        {
                            MessageBox.Show("Konnte Erledigt Status nicht einlesen.");
                        }
                        if (bool.TryParse(item.Attributes["Abgerechnet"].Value, out bool abgerechnet))
                        {
                            auftrag.Erledigt = abgerechnet;
                        }
                        else
                        {
                            MessageBox.Show("Konnte Abgerechnet Status nicht einlesen.");
                        }
                        // Fügt den Auftrag der Liste hinzu
                        lstAuftrag.Add(auftrag);
                    }
                }
                else
                {
                    MessageBox.Show("Ungültiges Format.");
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
        /// Schreibt Aufträge in eine XML Datei
        /// </summary>
        /// <param name="exportPfad">Pfad der XML Datei</param>
        /// <param name="lstAuftrag">Liste mit Auftragsobjekten</param>
        /// <seealso cref="Auftrag"/>
        public void AuftragSchreiben(string exportPfad, List<Auftrag> lstAuftrag)
        {
            try
            {
                // Erzeugt ein neues XMLDocument
                XmlDocument doc = new XmlDocument();

                // Fügt den Wurzelknoten "Auftraege" zum XMLDocument hinzu
                XmlNode rootNode = doc.CreateElement("Auftraege");
                doc.AppendChild(rootNode);

                // Geht durch die Liste der Aufträge
                foreach (Auftrag item in lstAuftrag)
                {
                    // Erzeugt einen Knoten mit dem Tag "Auftrag"
                    XmlNode childNode = doc.CreateElement("Auftrag");

                    // Fügt die Eigenschaften des Auftrags dem Knoten hinzu
                    XmlAttribute attAuftragID = doc.CreateAttribute("AuftragID");
                    attAuftragID.Value = item.AuftragID.ToString();
                    childNode.Attributes.Append(attAuftragID);

                    XmlAttribute attAuftragNummer = doc.CreateAttribute("AuftragNummer");
                    attAuftragNummer.Value = item.AuftragNummer;
                    childNode.Attributes.Append(attAuftragNummer);

                    XmlAttribute attKundeID = doc.CreateAttribute("KundeID");
                    attKundeID.Value = item.KundeID.ToString();
                    childNode.Attributes.Append(attKundeID);

                    XmlAttribute attEingang = doc.CreateAttribute("Eingang");
                    attEingang.Value = item.Eingang.ToString();
                    childNode.Attributes.Append(attEingang);

                    XmlAttribute attErteilt = doc.CreateAttribute("Erteilt");
                    attErteilt.Value = item.Erteilt.ToString();
                    childNode.Attributes.Append(attErteilt);

                    XmlAttribute attErledigt = doc.CreateAttribute("Erledigt");
                    attErledigt.Value = item.Erledigt.ToString();
                    childNode.Attributes.Append(attErledigt);

                    XmlAttribute attAbgerechnet = doc.CreateAttribute("Abgerechnet");
                    attAbgerechnet.Value = item.Abgerechnet.ToString();
                    childNode.Attributes.Append(attAbgerechnet);

                    // Fügt den Knoten dem XMLDocument hinzu
                    rootNode.AppendChild(childNode);
                }

                // Schreibt das XmlDocument in die Datei am angegebenen Pfad
                doc.Save(exportPfad);
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        /// <summary>
        /// Liest Kunden aus einer XML Datei
        /// </summary>
        /// <param name="importPfad">Pfad der XML Datei</param>
        /// <returns>Liste mit Kundenobjekten</returns>
        /// <seealso cref="Kunde"/>
        public List<Kunde> KundeLesen(string importPfad)
        {
            List<Kunde> lstKunde = new List<Kunde>();
            try
            {
                // Erzeugt ein neues XMLDocument und lädt die Datei
                XmlDocument xml = new XmlDocument();
                xml.Load(importPfad);

                // Speichert alle Knoten mit dem Tag "Kunde" in einer Liste
                XmlNodeList xmlKunde = xml.GetElementsByTagName("Kunde");
                if (xmlKunde.Count > 0)
                {
                    // Geht durch die Liste der Knoten
                    foreach (XmlNode item in xmlKunde)
                    {
                        // Speichert alle Eigenschaften in ein Kundenobjekt
                        Kunde kunde = new Kunde();
                        
                        kunde.Name = item.Attributes["Name"].Value.Trim();
                        kunde.Strasse = item.Attributes["Strasse"].Value.Trim();
                        kunde.Hausnr = item.Attributes["Hausnr"].Value.Trim();
                        kunde.PLZ = item.Attributes["PLZ"].Value.Trim();
                        kunde.Wohnort = item.Attributes["Wohnort"].Value.Trim();
                        kunde.TelefonNr = item.Attributes["TelefonNr"].Value.Trim();
                        if (int.TryParse(item.Attributes["KundeID"].Value, out int kundeID))
                        {
                            kunde.KundeID = kundeID;
                        }
                        else
                        {
                            MessageBox.Show("Konnte KundeID nicht einlesen.");
                        }
                        // Fügt den Kunden der Liste hinzu
                        lstKunde.Add(kunde);
                    }
                }
                else
                {
                    MessageBox.Show("Ungültiges Format.");
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
        /// Schreibt Kunden in eine XML Datei
        /// </summary>
        /// <param name="exportPfad">Pfad der XML Datei</param>
        /// <param name="lstKunde">Liste mit Kundenobjekten</param>
        /// <seealso cref="Kunde"/>
        public void KundeSchreiben(string exportPfad, List<Kunde> lstKunde)
        {
            try
            {
                // Erzeugt ein neues XmlDocument
                XmlDocument doc = new XmlDocument();

                // Fügt den Wurzelknoten "Kunden" zum XmlDocument hinzu
                XmlNode rootNode = doc.CreateElement("Kunden");
                doc.AppendChild(rootNode);

                // Geht durch die Liste der Kunden
                foreach (Kunde item in lstKunde)
                {
                    // Erzeugt einen Knoten mit dem Tag "Kunde"
                    XmlNode childNode = doc.CreateElement("Kunde");

                    // Fügt die Eigenschaften des Kunden dem Knoten hinzu
                    XmlAttribute attKundeID = doc.CreateAttribute("KundeID");
                    attKundeID.Value = item.KundeID.ToString();
                    childNode.Attributes.Append(attKundeID);

                    XmlAttribute attName = doc.CreateAttribute("Name");
                    attName.Value = item.Name;
                    childNode.Attributes.Append(attName);

                    XmlAttribute attStrasse = doc.CreateAttribute("Strasse");
                    attStrasse.Value = item.Strasse;
                    childNode.Attributes.Append(attStrasse);

                    XmlAttribute attHausnr = doc.CreateAttribute("Hausnr");
                    attHausnr.Value = item.Hausnr;
                    childNode.Attributes.Append(attHausnr);

                    XmlAttribute attPLZ = doc.CreateAttribute("PLZ");
                    attPLZ.Value = item.PLZ;
                    childNode.Attributes.Append(attPLZ);

                    XmlAttribute attWohnort = doc.CreateAttribute("Wohnort");
                    attWohnort.Value = item.Wohnort;
                    childNode.Attributes.Append(attWohnort);

                    XmlAttribute attTelefonNr = doc.CreateAttribute("TelefonNr");
                    attTelefonNr.Value = item.TelefonNr;
                    childNode.Attributes.Append(attTelefonNr);

                    // Fügt den Knoten dem XmlDocument hinzu
                    rootNode.AppendChild(childNode);
                }

                // Schrebt das XmlDocument in die Datei am angegebenen Pfad
                doc.Save(exportPfad);
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        /// <summary>
        /// Liest Mitarbeiter aus einer XML Datei
        /// </summary>
        /// <param name="importPfad">Pfad der XML Datei</param>
        /// <returns>Liste mit Mitarbeiterobjekten</returns>
        /// <seealso cref="Mitarbeiter"/>
        public List<Mitarbeiter> MitarbeiterLesen(string importPfad)
        {
            List<Mitarbeiter> lstMitarbeiter = new List<Mitarbeiter>();
            try
            {
                // Erzeugt ein neues XmlDocument und lädt die Datei
                XmlDocument xml = new XmlDocument();
                xml.Load(importPfad);

                // Speichert alle Knoten mit dem Tag "Mitarbeiter" in einer Liste
                XmlNodeList xmlMitarbeiter = xml.GetElementsByTagName("Mitarbeiter");
                if (xmlMitarbeiter.Count > 0)
                {
                    // Geht durch die Liste der Knoten
                    foreach (XmlNode item in xmlMitarbeiter)
                    {
                        // Speichert alle Eigenschaften in ein Mitarbeiterobjekt
                        Mitarbeiter mitarbeiter = new Mitarbeiter();
                        
                        mitarbeiter.Name = item.Attributes["Name"].Value.Trim();
                        mitarbeiter.TelefonNr = item.Attributes["TelefonNr"].Value.Trim();
                        mitarbeiter.Strasse = item.Attributes["Strasse"].Value.Trim();
                        mitarbeiter.Hausnr = item.Attributes["Hausnr"].Value.Trim();
                        mitarbeiter.PLZ = item.Attributes["PLZ"].Value.Trim();
                        mitarbeiter.Wohnort = item.Attributes["Wohnort"].Value.Trim();
                        if (int.TryParse(item.Attributes["MitarbeiterID"].Value, out int mitarbeiterID))
                        {
                            mitarbeiter.MitarbeiterID = mitarbeiterID;
                        }
                        else
                        {
                            MessageBox.Show("Konnte MitarbeiterID nicht einlesen.");
                        }
                        if (int.TryParse(item.Attributes["AuslastungStelle"].Value, out int auslastung))
                        {
                            mitarbeiter.AuslastungStelle = auslastung;
                        }
                        else
                        {
                            MessageBox.Show("Konnte Auslastung Stelle nicht einlesen.");
                        }
                        // Fügt den Mitarbeiter der Liste hinzu
                        lstMitarbeiter.Add(mitarbeiter);
                    }
                }
                else
                {
                    MessageBox.Show("Ungültiges Format.");
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
        /// Schreibt Mitarbeiter in ein XML Datei
        /// </summary>
        /// <param name="exportPfad">Pfad der XML Datei</param>
        /// <param name="lstMitarbeiter">Liste mit Mitarbeiterobjekten</param>
        /// <seealso cref="Mitarbeiter"/>
        public void MitarbeiterSchreiben(string exportPfad, List<Mitarbeiter> lstMitarbeiter)
        {
            try
            {
                // Erzeugt ein neues XmlDocument
                XmlDocument doc = new XmlDocument();

                // Fügt den Wurzelknoten "Mitarbeiters" dem XmlDocument hinzu
                XmlNode rootNode = doc.CreateElement("Mitarbeiters");
                doc.AppendChild(rootNode);

                // Geht durch die Liste der Mitarbeiter
                foreach (Mitarbeiter item in lstMitarbeiter)
                {
                    // Erzeugt einen Knoten mit dem Tag "Mitarbeiter"
                    XmlNode childNode = doc.CreateElement("Mitarbeiter");

                    // Fügt die Eigenschaften des Mitarbeiters dem Knoten hinzu
                    XmlAttribute attMitarbeiterID = doc.CreateAttribute("MitarbeiterID");
                    attMitarbeiterID.Value = item.MitarbeiterID.ToString();
                    childNode.Attributes.Append(attMitarbeiterID);

                    XmlAttribute attName = doc.CreateAttribute("Name");
                    attName.Value = item.Name;
                    childNode.Attributes.Append(attName);

                    XmlAttribute attTelefonNr = doc.CreateAttribute("TelefonNr");
                    attTelefonNr.Value = item.TelefonNr;
                    childNode.Attributes.Append(attTelefonNr);

                    XmlAttribute attStrasse = doc.CreateAttribute("Strasse");
                    attStrasse.Value = item.Strasse;
                    childNode.Attributes.Append(attStrasse);

                    XmlAttribute attHausnr = doc.CreateAttribute("Hausnr");
                    attHausnr.Value = item.Hausnr;
                    childNode.Attributes.Append(attHausnr);

                    XmlAttribute attPLZ = doc.CreateAttribute("PLZ");
                    attPLZ.Value = item.PLZ;
                    childNode.Attributes.Append(attPLZ);

                    XmlAttribute attWohnort = doc.CreateAttribute("Wohnort");
                    attWohnort.Value = item.Wohnort;
                    childNode.Attributes.Append(attWohnort);

                    XmlAttribute attAuslastungStelle = doc.CreateAttribute("AuslastungStelle");
                    attAuslastungStelle.Value = item.AuslastungStelle.ToString();
                    childNode.Attributes.Append(attAuslastungStelle);

                    // Fügt den Knoten dem XmlDocument hinzu
                    rootNode.AppendChild(childNode);
                }

                // Schreibt das XmlDocument in die Datei
                doc.Save(exportPfad);
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        /// <summary>
        /// Liest Taetigkeiten aus einer XML Datei
        /// </summary>
        /// <param name="importPfad">Pfad der XML Datei</param>
        /// <returns>Liste mit Taetigkeitsobjekten</returns>
        /// <seealso cref="Taetigkeit"/>
        public List<Taetigkeit> TaetigkeitLesen(string importPfad)
        {
            List<Taetigkeit> lstTaetigkeit = new List<Taetigkeit>();
            try
            {
                // Erzeugt ein XmlDocument und lädt die Datei
                XmlDocument xml = new XmlDocument();
                xml.Load(importPfad);

                // Speichert alle Knoten mit dem Tag "Taetigkeit" in einer Liste
                XmlNodeList xmlTaetigkeit = xml.GetElementsByTagName("Taetigkeit");
                if (xmlTaetigkeit.Count > 0)
                {
                    // Geht durch die Liste der Knoten
                    foreach (XmlNode item in xmlTaetigkeit)
                    {
                        // Speichert alle Eigenschaften in einem Taetigkeisobjekt
                        Taetigkeit taetigkeit = new Taetigkeit();
                        taetigkeit.Name = item.Attributes["Name"].Value.Trim();
                        if (int.TryParse(item.Attributes["TaetigkeitID"].Value, out int taetigkeitID))
                        {
                            taetigkeit.TaetigkeitID = taetigkeitID;
                        }
                        else
                        {
                            MessageBox.Show("Konnte TaetigkeitID nicht einlesen.");
                        }
                        if (int.TryParse(item.Attributes["AuftragID"].Value, out int auftragID))
                        {
                            taetigkeit.AuftragID = auftragID;
                        }
                        else
                        {
                            MessageBox.Show("Konnte AuftragID nicht einlesen.");
                        }
                        if (int.TryParse(item.Attributes["MitarbeiterID"].Value, out int mitarbeiterID))
                        {
                            taetigkeit.MitarbeiterID = mitarbeiterID;
                        }
                        else
                        {
                            MessageBox.Show("Konnte MitarbeiterID nicht einlesen.");
                        }
                        if (DateTime.TryParse(item.Attributes["Datum"].Value, out DateTime datum))
                        {
                            taetigkeit.Datum = datum;
                        }
                        else
                        {
                            MessageBox.Show("Konnte Datum nicht einlesen.");
                        }
                        if(TimeSpan.TryParse(item.Attributes["StartZeit"].Value, out TimeSpan start))
                        {
                            taetigkeit.StartZeit = start;
                        }
                        else
                        {
                            MessageBox.Show("Konnte Startzeit nicht einlesen.");
                        }
                        if (TimeSpan.TryParse(item.Attributes["EndZeit"].Value, out TimeSpan ende))
                        {
                            taetigkeit.EndZeit = ende;
                        }
                        else
                        {
                            MessageBox.Show("Konnte Endzeit nicht einlesen.");
                        }
                        // Fügt die Tatigkeit der Liste hinzu
                        lstTaetigkeit.Add(taetigkeit);
                    }
                }
                else
                {
                    MessageBox.Show("Ungültiges Format.");
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
        /// Schreibt Taetigkeiten in eine XML Datei
        /// </summary>
        /// <param name="exportPfad">Pfad der XML Datei</param>
        /// <param name="lstTaetigkeit">Liste mit Taetigkeitsobjekten</param>
        /// <seealso cref="Taetigkeit"/>
        public void TaetigkeitSchreiben(string exportPfad, List<Taetigkeit> lstTaetigkeit)
        {
            try
            {
                // Erzeugt ein neues XmlDocument
                XmlDocument doc = new XmlDocument();

                // Fügt den Wurzelknoten "Taetigkeiten" dem XmlDocument hinzu
                XmlNode rootNode = doc.CreateElement("Taetigkeiten");
                doc.AppendChild(rootNode);

                // Geht durch die Liste der Taetigkeiten
                foreach (Taetigkeit item in lstTaetigkeit)
                {
                    // Erzeugt einen Knoten mit dem Tag "Taetigkeit"
                    XmlNode childNode = doc.CreateElement("Taetigkeit");

                    // Fügt dem Knoten alle Eigenschaften der Taetigkeit hinzu
                    XmlAttribute attTaetigkeitID = doc.CreateAttribute("TaetigkeitID");
                    attTaetigkeitID.Value = item.TaetigkeitID.ToString();
                    childNode.Attributes.Append(attTaetigkeitID);

                    XmlAttribute attAuftragID = doc.CreateAttribute("AuftragID");
                    attAuftragID.Value = item.AuftragID.ToString();
                    childNode.Attributes.Append(attAuftragID);

                    XmlAttribute attMitarbeiterID = doc.CreateAttribute("MitarbeiterID");
                    attMitarbeiterID.Value = item.MitarbeiterID.ToString();
                    childNode.Attributes.Append(attMitarbeiterID);

                    XmlAttribute attDatum = doc.CreateAttribute("Datum");
                    attDatum.Value = item.Datum.ToString();
                    childNode.Attributes.Append(attDatum);

                    XmlAttribute attName = doc.CreateAttribute("Name");
                    attName.Value = item.Name;
                    childNode.Attributes.Append(attName);

                    XmlAttribute attStartZeit = doc.CreateAttribute("StartZeit");
                    attStartZeit.Value = item.StartZeit.ToString();
                    childNode.Attributes.Append(attStartZeit);

                    XmlAttribute attEndZeit = doc.CreateAttribute("EndZeit");
                    attEndZeit.Value = item.EndZeit.ToString();
                    childNode.Attributes.Append(attEndZeit);

                    // Fügt den Knoten dem XmlDocument hinzu
                    rootNode.AppendChild(childNode);
                }

                // Schreibt das XmlDocument in die Datei
                doc.Save(exportPfad);
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }
        /// <summary>
        /// Liest Adresse aus einer XML Datei
        /// </summary>
        /// <param name="importPfad">Pfad der XML Datei</param>
        /// <returns>Liste mit Adressenobjekten</returns>
        /// <seealso cref="Adresse"/>
        public List<Adresse> AdresseLesen(string importPfad)
        {
            List<Adresse> lstAdresse = new List<Adresse>();
            try
            {
                // Erzeugt ein XmlDocument und lädt die Datei
                XmlDocument xml = new XmlDocument();
                xml.Load(importPfad);

                // Speichert alle Knoten mit dem Tag "Adresse" in einer Liste
                XmlNodeList xmlAdresse = xml.GetElementsByTagName("Adresse");
                if (xmlAdresse.Count > 0)
                {
                    // Geht durch die Liste der Knoten
                    foreach (XmlNode item in xmlAdresse)
                    {
                        // Speichert alle Eigenschaften in einem Adressenobjekt
                        Adresse adresse = new Adresse();

                        if (int.TryParse(item.Attributes["AdresseID"].Value, out int adresseID))
                        {
                            adresse.AdresseID = adresseID;
                        }
                        else
                        {
                            MessageBox.Show("Konnte AdresseID nicht einlesen.");
                        }
                        if (int.TryParse(item.Attributes["KundeID"].Value, out int kundeID))
                        {
                            adresse.KundeID = kundeID;
                        }
                        else
                        {
                            MessageBox.Show("Konnte KundeID nicht einlesen.");
                        }
                        adresse.Strasse = item.Attributes["Strasse"].Value.Trim();
                        adresse.Hausnr = item.Attributes["Hausnr"].Value.Trim();
                        adresse.PLZ = item.Attributes["PLZ"].Value.Trim();
                        adresse.Wohnort = item.Attributes["Wohnort"].Value.Trim();

                        // Fügt die Adresse der Liste hinzu
                        lstAdresse.Add(adresse);
                    }
                }
                else
                {
                    MessageBox.Show("Ungültiges Format.");
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
            // Die Liste wird zurückgegeben
            return lstAdresse;
        }

        /// <summary>
        /// Schreibt Adresse in eine XML Datei
        /// </summary>
        /// <param name="exportPfad">Pfad der XML Datei</param>
        /// <param name="lstAdresse">Liste mit Adressenobjekten</param>
        /// <seealso cref="Adresse"/>
        public void AdresseSchreiben(string exportPfad, List<Adresse> lstAdresse)
        {
            try
            {
                // Erzeugt ein neues XmlDocument
                XmlDocument doc = new XmlDocument();

                // Fügt den Wurzelknoten "Adressen" dem XmlDocument hinzu
                XmlNode rootNode = doc.CreateElement("Adressen");
                doc.AppendChild(rootNode);

                // Geht durch die Liste der Adressen
                foreach (Adresse item in lstAdresse)
                {
                    // Erzeugt einen Knoten mit dem Tag "Adresse"
                    XmlNode childNode = doc.CreateElement("Adresse");

                    // Fügt dem Knoten alle Eigenschaften der Adresse hinzu
                    XmlAttribute attAdresseID = doc.CreateAttribute("AdresseID");
                    attAdresseID.Value = item.AdresseID.ToString();
                    childNode.Attributes.Append(attAdresseID);

                    XmlAttribute attKundeID = doc.CreateAttribute("KundeID");
                    attKundeID.Value = item.KundeID.ToString();
                    childNode.Attributes.Append(attKundeID);

                    XmlAttribute attStrasse = doc.CreateAttribute("Strasse");
                    attStrasse.Value = item.Strasse;
                    childNode.Attributes.Append(attStrasse);

                    XmlAttribute attHausnr = doc.CreateAttribute("Hausnr");
                    attHausnr.Value = item.Hausnr;
                    childNode.Attributes.Append(attHausnr);

                    XmlAttribute attPLZ = doc.CreateAttribute("PLZ");
                    attPLZ.Value = item.PLZ;
                    childNode.Attributes.Append(attPLZ);

                    XmlAttribute attWohnort = doc.CreateAttribute("Wohnort");
                    attWohnort.Value = item.Wohnort;
                    childNode.Attributes.Append(attWohnort);

                    // Fügt den Knoten dem XmlDocument hinzu
                    rootNode.AppendChild(childNode);
                }

                // Schreibt das XmlDocument in die Datei
                doc.Save(exportPfad);
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }
    }
}
