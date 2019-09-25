using Newtonsoft.Json;
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
    public class AustauschJSON : IAustausch
    {
        public List<Auftrag> AuftragLesen(string importPfad)
        {
            List<Auftrag> lstAuftrag = new List<Auftrag>();
            try
            {
                TextReader reader = new StreamReader(importPfad);
                string json = reader.ReadToEnd();
                reader.Close();

                JArray jauftraege = JArray.Parse(json);

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
            return lstAuftrag;
        }
    

        public void AuftragSchreiben(string exportPfad, List<Auftrag> lstAuftrag)
        {
            try
            {
                var json = JsonConvert.SerializeObject(lstAuftrag.ToArray());

                File.WriteAllText(exportPfad, json);
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
                string json = reader.ReadToEnd();
                reader.Close();

                JArray jkunden = JArray.Parse(json);

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
            return lstKunde;
        }

        public void KundeSchreiben(string exportPfad, List<Kunde> lstKunde)
        {
            try
            {
                var json = JsonConvert.SerializeObject(lstKunde.ToArray());

                File.WriteAllText(exportPfad, json);
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
                string json = reader.ReadToEnd();
                reader.Close();

                JArray jmitarbeiters = JArray.Parse(json);

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
            return lstMitarbeiter;
        }

        public void MitarbeiterSchreiben(string exportPfad, List<Mitarbeiter> lstMitarbeiter)
        {
            try
            {
                var json = JsonConvert.SerializeObject(lstMitarbeiter.ToArray());

                File.WriteAllText(exportPfad, json);
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
                string json = reader.ReadToEnd();
                reader.Close();

                JArray jtaetigkeiten = JArray.Parse(json);

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
            return lstTaetigkeit;
        }

        public void TaetigkeitSchreiben(string exportPfad, List<Taetigkeit> lstTaetigkeit)
        {
            try
            {
                var json = JsonConvert.SerializeObject(lstTaetigkeit.ToArray());

                File.WriteAllText(exportPfad, json);
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }
    }
}
