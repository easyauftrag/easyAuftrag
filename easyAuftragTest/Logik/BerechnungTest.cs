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
        [TestMethod]
        public void ArbeitsZeitTest()
        {
            DateTime[] anfangTest = new DateTime[]
            {
                new DateTime(2019, 1, 29),  // 1
                new DateTime(2019, 1, 30),  // 2
                new DateTime(2018, 6, 27),  // 3
                new DateTime(2017, 10, 14), // 4
                new DateTime(2016, 1, 1)    // 5
            };

            DateTime[] endeTest = new DateTime[]
            {
                new DateTime(2019, 2, 7),   // 1
                new DateTime(2019, 2, 9),   // 2
                new DateTime(2018, 7, 27),  // 3
                new DateTime(2017, 12, 24), // 4
                new DateTime(2016, 1, 1)    // 5
            };

            DateTime[] testDates = new DateTime[]
            {
                new DateTime(2019, 1, 30),  // 1,2  :1
                new DateTime(2019, 2, 5),   // 1,2  :1
                new DateTime(2019, 2, 9),   // 2    :1
                new DateTime(2018, 6, 27),  // 3    :1,2

                new DateTime(2018, 6, 29),  // 3    :1,2
                new DateTime(2018, 7, 5),   // 3    :1,2
                new DateTime(2017, 10, 16), // 4    :2
                new DateTime(2017, 12, 4)   // 4    :2
            };

            TimeSpan[] startTestZeit = new TimeSpan[]
            {
                new TimeSpan(0, 13, 0),     // 1,2
                new TimeSpan(4, 21, 0),     // 1,2
                new TimeSpan(12, 6, 0),     // 2
                new TimeSpan(13, 46, 0),    // 3

                new TimeSpan(0, 13, 0),     // 3
                new TimeSpan(4, 21, 0),     // 3
                new TimeSpan(12, 6, 0),     // 4
                new TimeSpan(13, 46, 0)     // 4
            };

            TimeSpan[] endTestZeit = new TimeSpan[]
            {
                new TimeSpan(23, 54, 0),    // 1,2
                new TimeSpan(21, 27, 0),    // 1,2
                new TimeSpan(15, 12, 0),    // 2
                new TimeSpan(13, 46, 0),    // 3

                new TimeSpan(23, 54, 0),    // 3
                new TimeSpan(21, 27, 0),    // 3
                new TimeSpan(15, 12, 0),    // 4
                new TimeSpan(17, 46, 0)     // 4
            };

            List<Taetigkeit> testTaetigkeit = new List<Taetigkeit>();

            for (int i = 0; i < testDates.Length / 2 + 2; i++)
            {
                testTaetigkeit.Add(new Taetigkeit()
                {
                    AuftragID = i,
                    MitarbeiterID = 1,
                    TaetigkeitID = i,
                    Datum = testDates[i],
                    Name = "Installation " + i,
                    StartZeit = startTestZeit[i],
                    EndZeit = endTestZeit[i]
                }
                );
            }

            for (int i = testDates.Length; i >= testDates.Length / 2; i--)
            {
                testTaetigkeit.Add(new Taetigkeit()
                {
                    AuftragID = i,
                    MitarbeiterID = 2,
                    TaetigkeitID = i,
                    Datum = testDates[i],
                    Name = "Installation " + i,
                    StartZeit = startTestZeit[i],
                    EndZeit = endTestZeit[i]
                }
                );
            }

            double[] ergMitarbeiter1 =
            {
                34.82,
                37.58,
                34.82,
                0,
                0
            };

            /*
             * 2089,
             * 2255,
             * 2089,
             * 0,
             * 0
             */

            double[] ergMitarbeiter2 =
            {
                0,
                0,
                34.82,
                8.1,
                0
            };

            /*
             * 0,
             * 0,
             * 2089,
             * 486,
             * 0
             */

            StundenDoc stundenDoc1 = new StundenDoc();
            stundenDoc1.Mitarbeiter = new Mitarbeiter();
            stundenDoc1.Mitarbeiter.MitarbeiterID = 1;
            stundenDoc1.Tatlist = (from t in testTaetigkeit where t.MitarbeiterID == stundenDoc1.Mitarbeiter.MitarbeiterID select t).ToList();

            StundenDoc stundenDoc2 = new StundenDoc();
            stundenDoc2.Mitarbeiter = new Mitarbeiter();
            stundenDoc2.Mitarbeiter.MitarbeiterID = 2;
            stundenDoc2.Tatlist = (from t in testTaetigkeit where t.MitarbeiterID == stundenDoc2.Mitarbeiter.MitarbeiterID select t).ToList();

            for (int i = 0; i < testDates.Length; i++)
            {
                stundenDoc1.Tatlist = stundenDoc1.Tatlist.Where(t => t.Datum >= anfangTest[i]).ToList();
                stundenDoc1.Tatlist = stundenDoc1.Tatlist.Where(t => t.Datum <= endeTest[i]).ToList();

                if (ergMitarbeiter1[i] != Berechnung.ArbeitsZeit(stundenDoc1))
                {
                    Assert.Fail();
                }
                if (ergMitarbeiter2[i] != Berechnung.ArbeitsZeit(stundenDoc2))
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void AuftragZeitGesamtTest()
        {
            TimeSpan[] startTestZeit = new TimeSpan[]
            {
                new TimeSpan(0, 13, 0),
                new TimeSpan(4, 21, 0),
                new TimeSpan(12, 6, 0),
                new TimeSpan(13, 46, 0)
            };

            TimeSpan[] endTestZeit = new TimeSpan[]
            {
                new TimeSpan(23, 54, 0),
                new TimeSpan(21, 27, 0),
                new TimeSpan(15, 12, 0),
                new TimeSpan(13, 46, 0)
            };

            DateTime[] testDates = new DateTime[]
            {
                new DateTime(2019, 7, 18),
                new DateTime(2019, 7, 18),
                new DateTime(2019, 4, 27),
                new DateTime(2017, 10, 30)
            };

            List<Taetigkeit> testTaetigkeit = new List<Taetigkeit>();

            for (int i = 0; i < testDates.Length; i++)
            {
                testTaetigkeit.Add(new Taetigkeit()
                {
                    AuftragID = 345,
                    MitarbeiterID = i,
                    TaetigkeitID = i,
                    Datum = testDates[i],
                    Name = "Installation " + i,
                    StartZeit = startTestZeit[i],
                    EndZeit = endTestZeit[i]
                }
                );
            }

            double auftragZeitTest = 2255;

            if (auftragZeitTest != Berechnung.AuftragZeitGesamt(testTaetigkeit))
            {
                Assert.Fail();
            }
        }
    }
}
