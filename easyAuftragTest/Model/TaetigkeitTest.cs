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
using easyAuftrag.Logik;

namespace easyAuftragTest.Model
{
    /// <summary>
    /// Zusammenfassungsbeschreibung für TaetigkeitTest
    /// </summary>
    [TestClass]
    public class TaetigkeitTest
    {
        public TaetigkeitTest()
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
        public void ZeitBerechnenTest()
        {
            Taetigkeit tatTest = new Taetigkeit();

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

            double[] testResults =
            {
                1421,
                1026,
                186,
                0
            };

            for (int i = 0; i < startTestZeit.Length; i++)
            {
                tatTest.StartZeit = startTestZeit[i];
                tatTest.EndZeit = endTestZeit[i];
                if (!testResults[i].Equals(tatTest.Minuten))
                {
                    Assert.Fail();
                }
            }
        }
    }
}
