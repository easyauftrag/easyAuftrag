﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace easyAuftragTest.Austausch
{
    /// <summary>
    /// Zusammenfassungsbeschreibung für AustauschXMLTest
    /// </summary>
    [TestClass]
    public class AustauschXMLTest
    {
        public AustauschXMLTest()
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
        public void AuftragLesenTest()
        {

        }

        [TestMethod]
        public void AuftragSchreibenTest()
        {

        }

        [TestMethod]
        public void AuftragLesenSchreibenTest()
        {

        }

        [TestMethod]
        public void KundeLesenTest()
        {

        }

        [TestMethod]
        public void KundeSchreibenTest()
        {

        }

        [TestMethod]
        public void KundeLesenSchreibenTest()
        {

        }

        [TestMethod]
        public void MitarbeiterLesenTest()
        {

        }

        [TestMethod]
        public void MitarbeiterSchreibenTest()
        {

        }

        [TestMethod]
        public void MitarbeiterLesenSchreibenTest()
        {

        }

        [TestMethod]
        public void TaetigkeitLesenTest()
        {

        }

        [TestMethod]
        public void TaetigkeitSchreibenTest()
        {

        }

        [TestMethod]
        public void TaetigkeitLesenSchreibenTest()
        {

        }
    }
}
