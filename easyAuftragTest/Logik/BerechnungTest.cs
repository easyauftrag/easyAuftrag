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

using System;
using System.Collections.Generic;
using System.Linq;
using Core.Model;
using easyAuftrag.Logik;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace easyAuftragTest.Logik
{
    [TestClass]
    public class BerechnungTest
    {
        /// <summary>
        /// Methode zum Testen von <see cref="Berechnung.ArbeitsZeit(StundenDoc)"/>
        /// </summary>
        [TestMethod]
        public void ArbeitsZeitTest()
        {
            // Tätigkeitsliste erstellen und jeweils zwei Einträge für Mitarbeiter 1 und Mitarbeiter 2 erstellen
            List<Taetigkeit> testTaetigkeiten = new List<Taetigkeit>();

            testTaetigkeiten.Add(new Taetigkeit()
            {
                AuftragID = 1,
                MitarbeiterID = 1,
                TaetigkeitID = 1,
                Datum = new DateTime(2017, 12, 4),
                Name = "Installation 1 M1",
                StartZeit = new TimeSpan(21, 13, 0),
                EndZeit = new TimeSpan(23, 54, 0)
            }
            );

            testTaetigkeiten.Add(new Taetigkeit()
            {
                AuftragID = 2,
                MitarbeiterID = 1,
                TaetigkeitID = 2,
                Datum = new DateTime(2019, 9, 9),
                Name = "Installation 2 M1",
                StartZeit = new TimeSpan(13, 46, 0),
                EndZeit = new TimeSpan(19, 32, 0)
            }
            );

            testTaetigkeiten.Add(new Taetigkeit()
            {
                AuftragID = 3,
                MitarbeiterID = 2,
                TaetigkeitID = 3,
                Datum = new DateTime(2018, 5, 17),
                Name = "Installation 1 M2",
                StartZeit = new TimeSpan(5, 29, 0),
                EndZeit = new TimeSpan(11, 28,0)
            }
            );

            testTaetigkeiten.Add(new Taetigkeit()
            {
                AuftragID = 2,
                MitarbeiterID = 2,
                TaetigkeitID = 4,
                Datum = new DateTime(2019, 1, 4),
                Name = "Installation 2 M2",
                StartZeit = new TimeSpan(17, 7, 0),
                EndZeit = new TimeSpan(22, 56, 0)
            }
            );

            // Neues StundenDoc für Mitarbeiter 1 erstellen
            StundenDoc stundenDocM1 = new StundenDoc
            {
                Mitarbeiter = new Mitarbeiter
                {
                    MitarbeiterID = 1
                }
            };
            // Tätigkeistliste nach Mitarbeiter 1, Anfangs- und Enddatum filtern
            stundenDocM1.Tatlist = (from t in testTaetigkeiten where t.MitarbeiterID == stundenDocM1.Mitarbeiter.MitarbeiterID && t.Datum >= new DateTime(2017, 12, 4) && t.Datum <= new DateTime(2018, 10, 20) select t).ToList();

            // Neues StundenDoc für Mitarbeiter 2 erstellen
            StundenDoc stundenDocM2 = new StundenDoc
            {
                Mitarbeiter = new Mitarbeiter
                {
                    MitarbeiterID = 2
                }
            };
            // Tätigkeistliste nach Mitarbeiter 2, Anfangs- und Enddatum filtern
            stundenDocM2.Tatlist = (from t in testTaetigkeiten where t.MitarbeiterID == stundenDocM2.Mitarbeiter.MitarbeiterID && t.Datum >= new DateTime(2018, 5, 17) && t.Datum <= new DateTime(2019, 1, 4) select t).ToList();

            // Berechnung der Arbeitszeit überprüfen
            if (Berechnung.ArbeitsZeit(stundenDocM1) != 2.68)
            {
                Assert.Fail();
            }
            if (Berechnung.ArbeitsZeit(stundenDocM2) != 11.8)
            {
                Assert.Fail();
            }
        }

        /// <summary>
        /// Methode zum Testen von <see cref="Berechnung.AuftragZeitGesamt(List{Taetigkeit})"/>
        /// </summary>
        [TestMethod]
        public void AuftragZeitGesamtTest()
        {
            // Taetigkeitsliste mit drei Einträgen für Auftrag 345 erstellen
            List<Taetigkeit> testTaetigkeiten = new List<Taetigkeit>();

            testTaetigkeiten.Add(new Taetigkeit()
            {
                AuftragID = 345,
                MitarbeiterID = 1,
                TaetigkeitID = 1,
                Datum = new DateTime(2019, 7, 18),
                Name = "Installation 1",
                StartZeit = new TimeSpan(4, 21, 0),
                EndZeit = new TimeSpan(13, 46, 0)
            }
            );

            testTaetigkeiten.Add(new Taetigkeit()
            {
                AuftragID = 345,
                MitarbeiterID = 2,
                TaetigkeitID = 2,
                Datum = new DateTime(2018, 4, 27),
                Name = "Installation 2",
                StartZeit = new TimeSpan(12, 6, 0),
                EndZeit = new TimeSpan(15, 12, 0)
            }
            );

            testTaetigkeiten.Add(new Taetigkeit()
            {
                AuftragID = 345,
                MitarbeiterID = 1,
                TaetigkeitID = 3,
                Datum = new DateTime(2017, 10, 30),
                Name = "Installation 3",
                StartZeit = new TimeSpan(16, 14, 0),
                EndZeit = new TimeSpan(22, 38, 0)
            }
            );

            // Berechnung der Gesamtzeit für den Auftrag prüfen
            if (Berechnung.AuftragZeitGesamt(testTaetigkeiten) != 1135)
            {
                Assert.Fail();
            }
        }
    }
}
