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

namespace easyAuftragTest.Logik
{
    /// <summary>
    /// Zusammenfassungsbeschreibung für HandlerTest
    /// </summary>
    [TestClass]
    public class HandlerTest
    {
        public HandlerTest()
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
        public void KundeAnlegenTest()
        {
            //
            // TODO: Testlogik hier hinzufügen
            //
        }

        public void KundeBearbeitenTest()
        {
            //
            // TODO: Testlogik hier hinzufügen
            //
        }

        public void KundeLoeschenTest()
        {
            //
            // TODO: Testlogik hier hinzufügen
            //
        }

        public void AuftragAnlegenTest()
        {
            //
            // TODO: Testlogik hier hinzufügen
            //
        }

        public void AuftragBearbeitenTest()
        {
            //
            // TODO: Testlogik hier hinzufügen
            //
        }

        public void AuftragLoeschenTest()
        {
            //
            // TODO: Testlogik hier hinzufügen
            //
        }

        public void MitarbeiterAnlegenTest()
        {
            //
            // TODO: Testlogik hier hinzufügen
            //
        }

        public void MitarbeiterBearbeitenTest()
        {
            //
            // TODO: Testlogik hier hinzufügen
            //
        }

        public void MitarbeiterLoeschenTest()
        {
            //
            // TODO: Testlogik hier hinzufügen
            //
        }

        public void TaetigkeitAnlegenTest()
        {
            //
            // TODO: Testlogik hier hinzufügen
            //
        }

        public void TaetigkeitBearbeitenTest()
        {
            //
            // TODO: Testlogik hier hinzufügen
            //
        }

        public void TaetigkeitLoeschenTest()
        {
            //
            // TODO: Testlogik hier hinzufügen
            //
        }

        public void KundeLadenTest()
        {
            //
            // TODO: Testlogik hier hinzufügen
            //
        }

        public void AuftragLadenTest()
        {
            //
            // TODO: Testlogik hier hinzufügen
            //
        }

        public void MitarbeiterLadenTest()
        {
            //
            // TODO: Testlogik hier hinzufügen
            //
        }

        public void TaetigkeitLadenTest()
        {
            //
            // TODO: Testlogik hier hinzufügen
            //
        }
    }
}
