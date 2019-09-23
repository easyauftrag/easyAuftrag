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
                new DateTime(2018, 4, 8),   // 2
                new DateTime(2016, 6, 27),  // 3
            };

            DateTime[] endeTest = new DateTime[]
            {
                new DateTime(2019, 9, 15),  // 1
                new DateTime(2019, 1, 30),  // 2
                new DateTime(2018, 7, 27),  // 3
            };

            DateTime[] testDatesM1 = new DateTime[]
            {
                new DateTime(2019, 9, 9),   // 1
                new DateTime(2019, 1, 30),  // 1,2
                new DateTime(2018, 6, 29),  // 2,3
                new DateTime(2018, 6, 27),  // 2,3
                new DateTime(2017, 12, 4)   // 3
            };

            DateTime[] testDatesM2 = new DateTime[]
            {
                new DateTime(2019, 2, 5),   // 1
                new DateTime(2018, 7, 28),  // 2
                new DateTime(2018, 6, 27),  // 2,3
                new DateTime(2018, 4, 7),   // 3
                new DateTime(2017, 10, 16)  // 3
            };

            TimeSpan[] startTestZeit = new TimeSpan[]
            {
                new TimeSpan(0, 13, 0),
                new TimeSpan(4, 21, 0),
                new TimeSpan(12, 6, 0),
                new TimeSpan(13, 46, 0),
                new TimeSpan(19, 32, 0)
            };

            /*
             * 1421 min
             * 1026 min
             * 186 min
             * 0 min
             * 449 min
             */

            TimeSpan[] endTestZeit = new TimeSpan[]
            {
                new TimeSpan(23, 54, 0),
                new TimeSpan(21, 27, 0),
                new TimeSpan(15, 12, 0),
                new TimeSpan(13, 46, 0),
                new TimeSpan(23, 55, 0)
            };

            List<Taetigkeit> testTaetigkeit = new List<Taetigkeit>();

            for (int i = 0; i < testDatesM1.Length; i++)
            {
                testTaetigkeit.Add(new Taetigkeit()
                {
                    AuftragID = i,
                    MitarbeiterID = 1,
                    TaetigkeitID = i,
                    Datum = testDatesM1[i],
                    Name = "Installation " + i,
                    StartZeit = startTestZeit[i],
                    EndZeit = endTestZeit[i]
                }
                );
            }

            for (int i = testDatesM2.Length - 1; i >= 0; i--)
            {
                testTaetigkeit.Add(new Taetigkeit()
                {
                    AuftragID = i,
                    MitarbeiterID = 2,
                    TaetigkeitID = i,
                    Datum = testDatesM2[i],
                    Name = "Installation " + (i + 5),
                    StartZeit = startTestZeit[i],
                    EndZeit = endTestZeit[i]
                }
                );
            }

            double[] ergMitarbeiter1 =
            {
                40.78,
                20.2,
                7.48
            };

            /*
             * 2447,
             * 1212,
             * 263
             */

            double[] ergMitarbeiter2 =
            {
                23.68,
                20.2,
                7.48
            };

            /*
             * 1421,
             * 1212,
             * 263
             */

            for (int i = 0; i < anfangTest.Length; i++)
            {
                StundenDoc stundenDoc1 = new StundenDoc
                {
                    Mitarbeiter = new Mitarbeiter()
                };
                stundenDoc1.Mitarbeiter.MitarbeiterID = 1;
                stundenDoc1.Tatlist = (from t in testTaetigkeit where t.MitarbeiterID == stundenDoc1.Mitarbeiter.MitarbeiterID select t).ToList();

                stundenDoc1.Tatlist = stundenDoc1.Tatlist.Where(t => t.Datum >= anfangTest[i]).ToList();
                stundenDoc1.Tatlist = stundenDoc1.Tatlist.Where(t => t.Datum <= endeTest[i]).ToList();

                StundenDoc stundenDoc2 = new StundenDoc
                {
                    Mitarbeiter = new Mitarbeiter()
                };
                stundenDoc2.Mitarbeiter.MitarbeiterID = 2;
                stundenDoc2.Tatlist = (from t in testTaetigkeit where t.MitarbeiterID == stundenDoc2.Mitarbeiter.MitarbeiterID select t).ToList();

                stundenDoc2.Tatlist = stundenDoc2.Tatlist.Where(t => t.Datum >= anfangTest[i]).ToList();
                stundenDoc2.Tatlist = stundenDoc2.Tatlist.Where(t => t.Datum <= endeTest[i]).ToList();

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

            double auftragZeitTest = 2633;

            if (auftragZeitTest != Berechnung.AuftragZeitGesamt(testTaetigkeit))
            {
                Assert.Fail();
            }
        }
    }
}
