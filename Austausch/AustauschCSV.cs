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
    public class AustauschCSV : IAustausch
    {
        private string _datenTrenner = ";";
        private CultureInfo _culture = new CultureInfo("de-DE");

        public AustauschCSV(CSVConfigTypen.DezimalTrenner trennerDezimal, CSVConfigTypen.DatenTrenner trennerDaten)
        {
            if (trennerDezimal == CSVConfigTypen.DezimalTrenner.Komma)
            {
                _culture = new CultureInfo("de-DE");
            }
            if (trennerDezimal == CSVConfigTypen.DezimalTrenner.Punkt)
            {
                _culture = new CultureInfo("en-US");
            }
            if (trennerDaten == CSVConfigTypen.DatenTrenner.Semikolon)
            {
                _datenTrenner = ";";
            }
            if (trennerDaten == CSVConfigTypen.DatenTrenner.Komma)
            {
                _datenTrenner = ",";
            }
            if (trennerDaten == CSVConfigTypen.DatenTrenner.Tab)
            {
                _datenTrenner = "\t";
            }
        }

        public List<Auftrag> AuftragLesen(string importPfad)
        {
            List<Auftrag> lstAuftrag = new List<Auftrag>();
            try
            {
                TextReader reader = new StreamReader(importPfad);
                string line = reader.ReadLine();

                while (!string.IsNullOrEmpty(line = reader.ReadLine()))
                {
                    string[] auftragItems = line.Split(_datenTrenner.ToCharArray());
                    Auftrag auftrag = new Auftrag();
                    auftrag.AuftragID = Convert.ToInt32(string.Format(auftragItems[0]), _culture);
                    auftrag.AuftragNummer = auftragItems[1].Trim();
                    auftrag.KundeID = Convert.ToInt32(string.Format(auftragItems[2]), _culture);
                    auftrag.Eingang = DateTime.Parse(auftragItems[3], _culture);
                    auftrag.Erteilt = DateTime.Parse(auftragItems[4], _culture);
                    auftrag.Erledigt = Convert.ToBoolean(auftragItems[5]);
                    auftrag.Abgerechnet = Convert.ToBoolean(auftragItems[6]);

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
                TextWriter writer = new StreamWriter(exportPfad);
                writer.WriteLine("AuftragID; AuftragNummer; KundeID; Eingang; Erteilt; Erledigt; Abgerechnet");
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

        public List<Kunde> KundeLesen(string importPfad)
        {
            List<Kunde> lstKunde = new List<Kunde>();
            try
            {
                TextReader reader = new StreamReader(importPfad);
                string line = reader.ReadLine();

                while (!string.IsNullOrEmpty(line = reader.ReadLine()))
                {
                    string[] kundeItems = line.Split(_datenTrenner.ToCharArray());
                    Kunde kunde = new Kunde();
                    kunde.KundeID = Convert.ToInt32(string.Format(kundeItems[0]), _culture);
                    kunde.Name = kundeItems[1].Trim();
                    kunde.Strasse = kundeItems[2].Trim();
                    kunde.Hausnr = kundeItems[3].Trim();
                    kunde.PLZ = kundeItems[4].Trim();
                    kunde.Wohnort = kundeItems[5].Trim();
                    kunde.TelefonNr = kundeItems[6].Trim();

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
                TextWriter writer = new StreamWriter(exportPfad);
                writer.WriteLine("KundeID; Name; Strasse; Hausnr; PLZ; Wohnort; TelefonNr");
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

        public List<Mitarbeiter> MitarbeiterLesen(string importPfad)
        {
            List<Mitarbeiter> lstMitarbeiter = new List<Mitarbeiter>();
            try
            {
                TextReader reader = new StreamReader(importPfad);
                string line = reader.ReadLine();

                while (!string.IsNullOrEmpty(line = reader.ReadLine()))
                {
                    string[] mitarbeiterItems = line.Split(_datenTrenner.ToCharArray());
                    Mitarbeiter mitarbeiter = new Mitarbeiter();
                    mitarbeiter.MitarbeiterID = Convert.ToInt32(string.Format(mitarbeiterItems[0]), _culture);
                    mitarbeiter.Name = mitarbeiterItems[1].Trim();
                    mitarbeiter.TelefonNr = mitarbeiterItems[2].Trim();
                    mitarbeiter.Strasse = mitarbeiterItems[3].Trim();
                    mitarbeiter.Hausnr = mitarbeiterItems[4].Trim();
                    mitarbeiter.PLZ = mitarbeiterItems[5].Trim();
                    mitarbeiter.Wohnort = mitarbeiterItems[6].Trim();
                    mitarbeiter.AuslastungStelle = Convert.ToInt32(string.Format(mitarbeiterItems[7]), _culture);

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
                TextWriter writer = new StreamWriter(exportPfad);
                writer.WriteLine("MitarbeiterID; Name; TelefonNr; Strasse; Hausnr; PLZ; Wohnort; AuslastungStelle");
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

        public List<Taetigkeit> TaetigkeitLesen(string importPfad)
        {
            List<Taetigkeit> lstTaetigkeit = new List<Taetigkeit>();
            try
            {
                TextReader reader = new StreamReader(importPfad);
                string line = reader.ReadLine();

                while (!string.IsNullOrEmpty(line = reader.ReadLine()))
                {
                    string[] taetigkeitItems = line.Split(_datenTrenner.ToCharArray());
                    Taetigkeit taetigkeit = new Taetigkeit();
                    taetigkeit.TaetigkeitID = Convert.ToInt32(string.Format(taetigkeitItems[0]), _culture);
                    taetigkeit.AuftragID = Convert.ToInt32(string.Format(taetigkeitItems[1]), _culture);
                    taetigkeit.MitarbeiterID = Convert.ToInt32(string.Format(taetigkeitItems[2]), _culture);
                    taetigkeit.Datum = DateTime.Parse(taetigkeitItems[3]);
                    taetigkeit.Name = taetigkeitItems[4].Trim();
                    taetigkeit.StartZeit = TimeSpan.Parse(taetigkeitItems[5]);
                    taetigkeit.EndZeit = TimeSpan.Parse(taetigkeitItems[6]);

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
                TextWriter writer = new StreamWriter(exportPfad);
                writer.WriteLine("TaetigkeitID; AuftragID; MitarbeiterID; Datum; Name; StartZeit; EndZeit");
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
    }
}
