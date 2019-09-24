using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Austausch
{//
    interface IAustausch
    {
        void AuftragSchreiben(string exportPfad, List<Kunde> lstAuftrag);
        void TaetigkeitSchreiben(string exportPfad, List<Taetigkeit> lstTaetigkeit);
        void KundeSchreiben(string exportPfad, List<Kunde> lstKunde);
        void MitarbeiterSchreiben(string exportPfad, List<Mitarbeiter> lstMitarbeiter);

        List<Kunde> AuftragLesen(string importPfad);
        List<Taetigkeit> TaetigkeitLesen(string importPfad);
        List<Kunde> KundeLesen(string importPfad);
        List<Mitarbeiter> MitarbeiterLesen(string importPfad);
    }
}