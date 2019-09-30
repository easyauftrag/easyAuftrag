using System;
using System.Collections.Generic;
using System.Text;
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
                // Geht durch die Liste der Knoten
                foreach (XmlNode item in xmlAuftrag)
                {
                    // Liest alle Eigenschaften in ein Auftragsobjekt
                    Auftrag auftrag = new Auftrag();
                    auftrag.AuftragID = Convert.ToInt32(item.Attributes["AuftragID"].Value);
                    auftrag.AuftragNummer = item.Attributes["AuftragNummer"].Value.Trim();
                    auftrag.KundeID = Convert.ToInt32(item.Attributes["KundeID"].Value);
                    auftrag.Eingang = DateTime.Parse(item.Attributes["Eingang"].Value);
                    auftrag.Erteilt = DateTime.Parse(item.Attributes["Erteilt"].Value);
                    auftrag.Erledigt = Convert.ToBoolean(item.Attributes["Erledigt"].Value);
                    auftrag.Abgerechnet = Convert.ToBoolean(item.Attributes["Abgerechnet"].Value);

                    // Fügt den Auftrag der Liste hinzu
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
                // Geht durch die Liste der Knoten
                foreach (XmlNode item in xmlKunde)
                {
                    // Speichert alle Eigenschaften in ein Kundenobjekt
                    Kunde kunde = new Kunde();
                    kunde.KundeID = Convert.ToInt32(item.Attributes["KundeID"].Value);
                    kunde.Name = item.Attributes["Name"].Value.Trim();
                    kunde.Strasse = item.Attributes["Strasse"].Value.Trim();
                    kunde.Hausnr = item.Attributes["Hausnr"].Value.Trim();
                    kunde.PLZ = item.Attributes["PLZ"].Value.Trim();
                    kunde.Wohnort = item.Attributes["Wohnort"].Value.Trim();
                    kunde.TelefonNr = item.Attributes["TelefonNr"].Value.Trim();

                    // Fügt den Kunden der Liste hinzu
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
                // Geht durch die Liste der Knoten
                foreach (XmlNode item in xmlMitarbeiter)
                {
                    // Speichert alle Eigenschaften in ein Mitarbeiterobjekt
                    Mitarbeiter mitarbeiter = new Mitarbeiter();
                    mitarbeiter.MitarbeiterID = Convert.ToInt32(item.Attributes["MitarbeiterID"].Value);
                    mitarbeiter.Name = item.Attributes["Name"].Value.Trim();
                    mitarbeiter.TelefonNr = item.Attributes["TelefonNr"].Value.Trim();
                    mitarbeiter.Strasse = item.Attributes["Strasse"].Value.Trim();
                    mitarbeiter.Hausnr = item.Attributes["Hausnr"].Value.Trim();
                    mitarbeiter.PLZ = item.Attributes["PLZ"].Value.Trim();
                    mitarbeiter.Wohnort = item.Attributes["Wohnort"].Value.Trim();
                    mitarbeiter.AuslastungStelle = Convert.ToInt32(item.Attributes["AuslastungStelle"].Value);

                    // Fügt den Mitarbeiter der Liste hinzu
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
                // Geht durch die Liste der Knoten
                foreach (XmlNode item in xmlTaetigkeit)
                {
                    // Speichert alle Eigenschaften in einem Taetigkeisobjekt
                    Taetigkeit taetigkeit = new Taetigkeit();
                    taetigkeit.TaetigkeitID = Convert.ToInt32(item.Attributes["TaetigkeitID"].Value);
                    taetigkeit.AuftragID = Convert.ToInt32(item.Attributes["AuftragID"].Value);
                    taetigkeit.MitarbeiterID = Convert.ToInt32(item.Attributes["MitarbeiterID"].Value);
                    taetigkeit.Datum = DateTime.Parse(item.Attributes["Datum"].Value);
                    taetigkeit.Name = item.Attributes["Name"].Value.Trim();
                    taetigkeit.StartZeit = TimeSpan.Parse(item.Attributes["StartZeit"].Value);
                    taetigkeit.EndZeit = TimeSpan.Parse(item.Attributes["EndZeit"].Value);

                    // Fügt die Tatigkeit der Liste hinzu
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
    }
}
