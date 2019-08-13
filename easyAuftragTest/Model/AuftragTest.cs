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
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Model;

namespace easyAuftragTest.Model
{
    /// <summary>
    /// Zusammenfassungsbeschreibung für AuftragTest
    /// </summary>
    [TestClass]
    public class AuftragTest
    {
        public AuftragTest()
        {
            //
            // TODO: Konstruktorlogik hier hinzufügen
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Ruft den Textkontext mit Informationen über
        ///den aktuellen Testlauf sowie Funktionalität für diesen auf oder legt diese fest.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Zusätzliche Testattribute
        //
        // Sie können beim Schreiben der Tests folgende zusätzliche Attribute verwenden:
        //
        // Verwenden Sie ClassInitialize, um vor Ausführung des ersten Tests in der Klasse Code auszuführen.
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Verwenden Sie ClassCleanup, um nach Ausführung aller Tests in einer Klasse Code auszuführen.
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Mit TestInitialize können Sie vor jedem einzelnen Test Code ausführen. 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Mit TestCleanup können Sie nach jedem Test Code ausführen.
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

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

            Random random = new Random();

            List<Taetigkeit> testTaetigkeit = new List<Taetigkeit>();

            for (int i = 0; i < testDates.Length; i++)
            {
                testTaetigkeit.Add(new Taetigkeit()
                {
                    AuftragID = 345,
                    MitarbeiterID = random.Next(0, 50),
                    TaetigkeitID = i,
                    Datum = testDates[i],
                    Name = "Installation " + i,
                    StartZeit = startTestZeit[i],
                    EndZeit = endTestZeit[i]
                }
                );
            }
            

            Auftrag auftragTest = new Auftrag();
            auftragTest.Taetigkeiten = testTaetigkeit;

            double auftragZeitTest = 2255;
            
            if (auftragZeitTest != auftragTest.ZeitGesamt)
            {
                Assert.Fail();
            }
        }
    }
}
