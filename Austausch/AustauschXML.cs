using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Core;
using Core.Model;

namespace Austausch
{
    public class AustauschXML : IAustausch
    {
        public List<Auftrag> AuftragLesen(string importPfad)
        {
            List<Auftrag> lstAuftrag = new List<Auftrag>();
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(importPfad);

                XmlNodeList xmlAuftrag = xml.GetElementsByTagName("Auftrag");
                foreach (XmlNode item in xmlAuftrag)
                {
                    Auftrag auftrag = new Auftrag();
                    auftrag.AuftragID = Convert.ToInt32(item.Attributes["AuftragID"].Value);
                    auftrag.AuftragNummer = item.Attributes["AuftragNummer"].Value.Trim();
                    auftrag.KundeID = Convert.ToInt32(item.Attributes["KundeID"].Value);
                    auftrag.Eingang = DateTime.Parse(item.Attributes["Eingang"].Value);
                    auftrag.Erteilt = DateTime.Parse(item.Attributes["Erteilt"].Value);
                    auftrag.Erledigt = Convert.ToBoolean(item.Attributes["Erledigt"].Value);
                    auftrag.Abgerechnet = Convert.ToBoolean(item.Attributes["Abgerechnet"].Value);

                    lstAuftrag.Add(auftrag);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
            return lstAuftrag;
        }

        public void AuftragSchreiben(string exportPfad, List<Auftrag> lstAuftrag)
        {
            try
            {
                XmlDocument doc = new XmlDocument();

                XmlNode rootNode = doc.CreateElement("Auftraege");
                doc.AppendChild(rootNode);

                foreach (Auftrag item in lstAuftrag)
                {
                    XmlNode childNode = doc.CreateElement("Auftrag");

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


                    rootNode.AppendChild(childNode);
                }

                doc.Save(exportPfad);
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        public List<Kunde> KundeLesen(string importPfad)
        {
            List<Kunde> lstKunde = new List<Kunde>();
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(importPfad);

                XmlNodeList xmlKunde = xml.GetElementsByTagName("Kunde");
                foreach (XmlNode item in xmlKunde)
                {
                    Kunde kunde = new Kunde();
                    kunde.KundeID = Convert.ToInt32(item.Attributes["KundeID"].Value);
                    kunde.Name = item.Attributes["Name"].Value.Trim();
                    kunde.Strasse = item.Attributes["Strasse"].Value.Trim();
                    kunde.Hausnr = item.Attributes["Hausnr"].Value.Trim();
                    kunde.PLZ = item.Attributes["PLZ"].Value.Trim();
                    kunde.Wohnort = item.Attributes["Wohnort"].Value.Trim();
                    kunde.TelefonNr = item.Attributes["TelefonNr"].Value.Trim();

                    lstKunde.Add(kunde);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
            return lstKunde;
        }

        public void KundeSchreiben(string exportPfad, List<Kunde> lstKunde)
        {
            try
            {
                XmlDocument doc = new XmlDocument();

                XmlNode rootNode = doc.CreateElement("Kunden");
                doc.AppendChild(rootNode);

                foreach (Kunde item in lstKunde)
                {
                    XmlNode childNode = doc.CreateElement("Kunde");

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


                    rootNode.AppendChild(childNode);
                }

                doc.Save(exportPfad);
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        public List<Mitarbeiter> MitarbeiterLesen(string importPfad)
        {
            List<Mitarbeiter> lstMitarbeiter = new List<Mitarbeiter>();
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(importPfad);

                XmlNodeList xmlMitarbeiter = xml.GetElementsByTagName("Mitarbeiter");
                foreach (XmlNode item in xmlMitarbeiter)
                {
                    Mitarbeiter mitarbeiter = new Mitarbeiter();
                    mitarbeiter.MitarbeiterID = Convert.ToInt32(item.Attributes["MitarbeiterID"].Value);
                    mitarbeiter.Name = item.Attributes["Name"].Value.Trim();
                    mitarbeiter.TelefonNr = item.Attributes["TelefonNr"].Value.Trim();
                    mitarbeiter.Strasse = item.Attributes["Strasse"].Value.Trim();
                    mitarbeiter.Hausnr = item.Attributes["Hausnr"].Value.Trim();
                    mitarbeiter.PLZ = item.Attributes["PLZ"].Value.Trim();
                    mitarbeiter.Wohnort = item.Attributes["Wohnort"].Value.Trim();
                    mitarbeiter.AuslastungStelle = Convert.ToInt32(item.Attributes["AuslastungStelle"].Value);

                    lstMitarbeiter.Add(mitarbeiter);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
            return lstMitarbeiter;
        }

        public void MitarbeiterSchreiben(string exportPfad, List<Mitarbeiter> lstMitarbeiter)
        {
            try
            {
                XmlDocument doc = new XmlDocument();

                XmlNode rootNode = doc.CreateElement("Mitarbeiters");
                doc.AppendChild(rootNode);

                foreach (Mitarbeiter item in lstMitarbeiter)
                {
                    XmlNode childNode = doc.CreateElement("Mitarbeiter");

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


                    rootNode.AppendChild(childNode);
                }

                doc.Save(exportPfad);
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        public List<Taetigkeit> TaetigkeitLesen(string importPfad)
        {
            List<Taetigkeit> lstTaetigkeit = new List<Taetigkeit>();
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(importPfad);

                XmlNodeList xmlTaetigkeit = xml.GetElementsByTagName("Taetigkeit");
                foreach (XmlNode item in xmlTaetigkeit)
                {
                    Taetigkeit taetigkeit = new Taetigkeit();
                    taetigkeit.TaetigkeitID = Convert.ToInt32(item.Attributes["TaetigkeitID"].Value);
                    taetigkeit.AuftragID = Convert.ToInt32(item.Attributes["AuftragID"].Value);
                    taetigkeit.MitarbeiterID = Convert.ToInt32(item.Attributes["MitarbeiterID"].Value);
                    taetigkeit.Datum = DateTime.Parse(item.Attributes["Strasse"].Value);
                    taetigkeit.Name = item.Attributes["Name"].Value.Trim();
                    taetigkeit.StartZeit = TimeSpan.Parse(item.Attributes["StartZeit"].Value);
                    taetigkeit.EndZeit = TimeSpan.Parse(item.Attributes["EndZeit"].Value);

                    lstTaetigkeit.Add(taetigkeit);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
            return lstTaetigkeit;
        }

        public void TaetigkeitSchreiben(string exportPfad, List<Taetigkeit> lstTaetigkeit)
        {
            try
            {
                XmlDocument doc = new XmlDocument();

                XmlNode rootNode = doc.CreateElement("Taetigkeiten");
                doc.AppendChild(rootNode);

                foreach (Taetigkeit item in lstTaetigkeit)
                {
                    XmlNode childNode = doc.CreateElement("Taetigkeit");

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


                    rootNode.AppendChild(childNode);
                }

                doc.Save(exportPfad);
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }
    }
}
