using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Model;

namespace Austausch
{//
    public class AustauschCSV : IAustausch
    {
        public List<Auftrag> AuftragLesen(string importPfad)
        {
            List<Auftrag> lstAuftrag = new List<Auftrag>();
            try
            {
                TextReader reader = new StreamReader(importPfad);
                string line = "";

                while (!string.IsNullOrEmpty(line = reader.ReadLine()))
                {
                    string[] auftragItems = line.Split(';');
                    Auftrag auftrag = new Auftrag();
                    auftrag.AuftragID = Convert.ToInt32(auftragItems[0]);
                    auftrag.AuftragNummer = auftragItems[1].Trim();
                    auftrag.KundeID = Convert.ToInt32(auftragItems[2]);
                    auftrag.Eingang = DateTime.Parse(auftragItems[3]);
                    auftrag.Erteilt = DateTime.Parse(auftragItems[4]);
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

        public void AuftragSchreiben(string exportPfad, List<Kunde> lstAuftrag)
        {
            throw new NotImplementedException();
        }

        public List<Kunde> KundeLesen(string importPfad)
        {
            List<Kunde> lstKunde = new List<Kunde>();
            try
            {
                TextReader reader = new StreamReader(importPfad);
                string line = "";

                while (!string.IsNullOrEmpty(line = reader.ReadLine()))
                {
                    string[] kundeItems = line.Split(';');
                    Kunde kunde = new Kunde();
                    kunde.KundeID = Convert.ToInt32(kundeItems[0]);
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
            throw new NotImplementedException();
        }

        public List<Mitarbeiter> MitarbeiterLesen(string importPfad)
        {
            List<Mitarbeiter> lstMitarbeiter = new List<Mitarbeiter>();
            try
            {
                TextReader reader = new StreamReader(importPfad);
                string line = "";

                while (!string.IsNullOrEmpty(line = reader.ReadLine()))
                {
                    string[] mitarbeiterItems = line.Split(';');
                    Mitarbeiter mitarbeiter = new Mitarbeiter();
                    mitarbeiter.MitarbeiterID = Convert.ToInt32(mitarbeiterItems[0]);
                    mitarbeiter.Name = mitarbeiterItems[1].Trim();
                    mitarbeiter.TelefonNr = mitarbeiterItems[2].Trim();
                    mitarbeiter.Strasse = mitarbeiterItems[3].Trim();
                    mitarbeiter.Hausnr = mitarbeiterItems[4].Trim();
                    mitarbeiter.PLZ = mitarbeiterItems[5].Trim();
                    mitarbeiter.Wohnort = mitarbeiterItems[6].Trim();
                    mitarbeiter.AuslastungStelle = Convert.ToInt32(mitarbeiterItems[7]);

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
            throw new NotImplementedException();
        }

        public List<Taetigkeit> TaetigkeitLesen(string importPfad)
        {
            List<Taetigkeit> lstTaetigkeit = new List<Taetigkeit>();
            try
            {
                TextReader reader = new StreamReader(importPfad);
                string line = "";

                while (!string.IsNullOrEmpty(line = reader.ReadLine()))
                {
                    string[] taetigkeitItems = line.Split(';');
                    Taetigkeit taetigkeit = new Taetigkeit();
                    taetigkeit.TaetigkeitID = Convert.ToInt32(taetigkeitItems[0]);
                    taetigkeit.AuftragID = Convert.ToInt32(taetigkeitItems[1]);
                    taetigkeit.MitarbeiterID = Convert.ToInt32(taetigkeitItems[2]);
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
            throw new NotImplementedException();
        }
    }
}
