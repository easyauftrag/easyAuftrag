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
using Core;
using Core.Model;
using System.Linq;

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

        Handler _handler = new Handler();

        /// <summary>
        /// überprüft, ob ein Kunde zur DB hinzugefügt wurde
        /// </summary>
        /// <seealso cref="Handler.KundeAnlegen(Kunde)"/>
        [TestMethod]
        public void IrgendeinKundeAnlegenTest()
        {
            using (var db = new EasyAuftragContext())
            {
                // Anzahl Kunden messen
                int anzahlKunden = (from k in db.Kunden select k).ToList().Count();

                // neuen Kunden anlegen
                Kunde kundeTest = new Kunde
                {
                    Hausnr = "test",
                    Name = "test",
                    PLZ = "test",
                    Strasse = "test",
                    TelefonNr = "test",
                    Wohnort = "test"
                };
                _handler.KundeAnlegen(kundeTest);

                // überprüfen, ob neuer Kunde angelegt wurde
                if (anzahlKunden + 1 != (from k in db.Kunden select k).ToList().Count())
                {
                    Assert.Fail();
                }
            }
        }

        /// <summary>
        /// überprüft, ob die KundenID eines neu erstellten Kunden richtig ist
        /// </summary>
        /// <seealso cref="Handler.KundeAnlegen(Kunde)"/>
        [TestMethod]
        public void KundenIDExistiertTest()
        {
            using (var db = new EasyAuftragContext())
            {
                // Kunde mit max ID, da vorheriger Kunde gelöscht sein könnte
                Kunde kundeMaxIDTest = new Kunde
                {
                    Hausnr = "test",
                    Name = "test",
                    PLZ = "test",
                    Strasse = "test",
                    TelefonNr = "test",
                    Wohnort = "test"
                };
                _handler.KundeAnlegen(kundeMaxIDTest);

                // max ID herausfinden
                int kundeMaxID = (from k in db.Kunden orderby k.KundeID ascending select k.KundeID).ToList().Last();

                // neuer Kunde zum Vergleich der max ID
                Kunde kundeTestMaxIDTestNeu = new Kunde
                {
                    Hausnr = "test1234",
                    Name = "test2345",
                    PLZ = "test3456",
                    Strasse = "test4567",
                    TelefonNr = "test5678",
                    Wohnort = "test6789"
                };
                _handler.KundeAnlegen(kundeTestMaxIDTestNeu);

                // überprüfen, ob neue ID existiert
                if (kundeMaxID + 1 != (from k in db.Kunden orderby k.KundeID ascending select k.KundeID).ToList().Last())
                {
                    Assert.Fail();
                }
            }
        }

        /// <summary>
        /// überprüft, ob die Daten eines neu angelegten Kunden richtig sind
        /// </summary>
        /// <seealso cref="Handler.KundeAnlegen(Kunde)"/>
        [TestMethod]
        public void KundeAnlegenDatenTest()
        {
            using (var db = new EasyAuftragContext())
            {
                // Kunde mit max ID zum Vergleich der Daten
                Kunde kundeMaxIDTest = new Kunde
                {
                    Hausnr = "test1234",
                    Name = "test2345",
                    PLZ = "test3456",
                    Strasse = "test4567",
                    TelefonNr = "test5678",
                    Wohnort = "test6789"
                };
                _handler.KundeAnlegen(kundeMaxIDTest);

                // Kunde mit max ID aus DB ziehen
                Kunde kundeVergleich = (from k in db.Kunden orderby k.KundeID ascending select k).ToList().Last();
                
                if (kundeMaxIDTest.Hausnr != kundeVergleich.Hausnr)
                {
                    Assert.Fail();
                }
                if (kundeMaxIDTest.Name != kundeVergleich.Name)
                {
                    Assert.Fail();
                }
                if (kundeMaxIDTest.PLZ != kundeVergleich.PLZ)
                {
                    Assert.Fail();
                }
                if (kundeMaxIDTest.Strasse != kundeVergleich.Strasse)
                {
                    Assert.Fail();
                }
                if (kundeMaxIDTest.TelefonNr != kundeVergleich.TelefonNr)
                {
                    Assert.Fail();
                }
                if (kundeMaxIDTest.Wohnort != kundeVergleich.Wohnort)
                {
                    Assert.Fail();
                }
            }
        }

        /// <summary>
        /// überprüft, ob ein Kunde korrekt bearbeitet wurde
        /// </summary>
        /// <seealso cref="Handler.KundeBearbeiten(Kunde, int)"/>
        [TestMethod]
        public void KundeBearbeitenTest()
        {
            using (var db = new EasyAuftragContext())
            {
                // Kunde mit max ID zum Vergleich der Daten
                Kunde kundeMaxIDTest = new Kunde
                {
                    Hausnr = "test1234",
                    Name = "test2345",
                    PLZ = "test3456",
                    Strasse = "test4567",
                    TelefonNr = "test5678",
                    Wohnort = "test6789"
                };
                _handler.KundeAnlegen(kundeMaxIDTest);

                // bearbeiteter Kunde in DB speichern
                Kunde kundeBearbTest = new Kunde
                {
                    Hausnr = "test9876",
                    Name = "test8765",
                    PLZ = "test7654",
                    Strasse = "test6543",
                    TelefonNr = "test5432",
                    Wohnort = "test4321"
                };
                int maxID = (from k in db.Kunden orderby k.KundeID ascending select k.KundeID).ToList().Last();
                _handler.KundeBearbeiten(kundeBearbTest, maxID);

                // Kunde mit max ID aus DB ziehen
                Kunde kundeVergleich = (from k in db.Kunden orderby k.KundeID ascending where k.KundeID == maxID select k).ToList().Last();

                // Test ob alle Daten geändert wurden
                if (kundeBearbTest.Hausnr != kundeVergleich.Hausnr)
                {
                    Assert.Fail();
                }
                if (kundeBearbTest.Name != kundeVergleich.Name)
                {
                    Assert.Fail();
                }
                if (kundeBearbTest.PLZ != kundeVergleich.PLZ)
                {
                    Assert.Fail();
                }
                if (kundeBearbTest.Strasse != kundeVergleich.Strasse)
                {
                    Assert.Fail();
                }
                if (kundeBearbTest.TelefonNr != kundeVergleich.TelefonNr)
                {
                    Assert.Fail();
                }
                if (kundeBearbTest.Wohnort != kundeVergleich.Wohnort)
                {
                    Assert.Fail();
                }
            }
        }

        /// <summary>
        /// überprüft, ob irgendein Kunde gelöscht wird
        /// </summary>
        /// <seealso cref="Handler.KundeLoeschen(int)"/>
        [TestMethod]
        public void IrgendeinKundeLoeschenTest()
        {
            using (var db = new EasyAuftragContext())
            {
                // Kunde hinzufügen
                Kunde kundeTest = new Kunde
                {
                    Hausnr = "test1234",
                    Name = "test2345",
                    PLZ = "test3456",
                    Strasse = "test4567",
                    TelefonNr = "test5678",
                    Wohnort = "test6789"
                };
                _handler.KundeAnlegen(kundeTest);

                // ID des angelegten Kunden herausfinden
                int maxID = (from k in db.Kunden orderby k.KundeID ascending select k.KundeID).ToList().Last();

                // anzahl der Kunden herausfinden
                int anzahlKunden = (from k in db.Kunden select k).ToList().Count();

                // angelegten Kunden löschen
                _handler.KundeLoeschen(maxID);

                // überprüfen, ob jetzt ein Kunde weniger in der DB ist
                if (anzahlKunden - 1 != (from k in db.Kunden select k).ToList().Count())
                {
                    Assert.Fail();
                }
            }
        }

        /// <summary>
        /// überprüft, ob der angegebene Kunde gelöscht wird
        /// </summary>
        /// <seealso cref="Handler.KundeLoeschen(int)"/>
        [TestMethod]
        public void KundeLoeschenTest()
        {
            using (var db = new EasyAuftragContext())
            {
                // Kunde hinzufügen
                Kunde kundeTest = new Kunde
                {
                    Hausnr = "test1234",
                    Name = "test2345",
                    PLZ = "test3456",
                    Strasse = "test4567",
                    TelefonNr = "test5678",
                    Wohnort = "test6789"
                };
                _handler.KundeAnlegen(kundeTest);

                // ID des angelegten Kunden herausfinden
                int maxID = (from k in db.Kunden orderby k.KundeID ascending select k.KundeID).ToList().Last();

                // angelegten Kunden löschen
                _handler.KundeLoeschen(maxID);

                // Versuch, gelöschten Kunden aufzurufen
                kundeTest = (from k in db.Kunden where k.KundeID == maxID select k).ToList().First();

                // Falls der Kunde doch noch existiert, also ungleich null ist, schlägt der Test fehl
                if (kundeTest != null)
                {
                    Assert.Fail();
                }
            }
        }

        /// <summary>
        /// überprüft, ob irgendein Auftrag angelegt wird
        /// </summary>
        /// <seealso cref="Handler.AuftragAnlegen(Auftrag)"/>
        [TestMethod]
        public void IrgendeinAuftragAnlegenTest()
        {
            using (var db = new EasyAuftragContext())
            {
                // Anzahl Auftraege messen
                int anzahlAuftraege = (from a in db.Auftraege select a).ToList().Count();

                // neuer Auftrag anlegen
                Auftrag auftragTest = new Auftrag
                {
                    Abgerechnet = false,
                    AuftragNummer = "Irgendein Auftrag",
                    Eingang = new DateTime(2019, 8, 14),
                    Erledigt = true,
                    Erteilt = new DateTime(2019, 8, 14),
                    KundeID = 1
                };
                _handler.AuftragAnlegen(auftragTest);

                // überprüfen, ob neuer Auftrag angelegt wurde
                if (anzahlAuftraege + 1 != (from a in db.Auftraege select a).ToList().Count())
                {
                    Assert.Fail();
                }
            }
        }

        /// <summary>
        /// überprüft, ob die ID eines angelegten Auftrags richtig ist
        /// </summary>
        /// <seealso cref="Handler.AuftragAnlegen(Auftrag)"/>
        [TestMethod]
        public void AuftragIDExistiertTest()
        {
            using (var db = new EasyAuftragContext())
            {
                // Auftrag mit max ID, da vorheriger Auftrag gelöscht sein könnte
                Auftrag auftragMaxIDTest = new Auftrag
                {
                    Abgerechnet = false,
                    AuftragNummer = "test",
                    Eingang = new DateTime(2019, 8, 14),
                    Erledigt = true,
                    Erteilt = new DateTime(2019, 8, 14),
                    KundeID = 1
                };
                _handler.AuftragAnlegen(auftragMaxIDTest);

                // max ID herausfinden
                int auftragMaxID = (from a in db.Auftraege orderby a.AuftragID ascending select a.AuftragID).ToList().Last();

                // neuer Auftrag zum Vergleich der max ID
                Auftrag auftragMaxIDTestNeu = new Auftrag
                {
                    Abgerechnet = false,
                    AuftragNummer = "test1234567",
                    Eingang = new DateTime(2019, 8, 14),
                    Erledigt = true,
                    Erteilt = new DateTime(2019, 8, 14),
                    KundeID = 1
                };
                _handler.AuftragAnlegen(auftragMaxIDTestNeu);

                // überprüfen, ob neue ID existiert
                if (auftragMaxID + 1 != (from a in db.Auftraege orderby a.AuftragID ascending select a.AuftragID).ToList().Last())
                {
                    Assert.Fail();
                }
            }
        }

        /// <summary>
        /// überprüft, ob die Daten eines angelegten Auftrags richtig gespeichert werden
        /// </summary>
        /// <seealso cref="Handler.AuftragAnlegen(Auftrag)"/>
        [TestMethod]
        public void AuftragAnlegenDatenTest()
        {
            using (var db = new EasyAuftragContext())
            {
                // Auftrag mit max ID zum Vergleich der Daten
                Auftrag auftragMaxIDTest = new Auftrag
                {
                    Abgerechnet = false,
                    AuftragNummer = "IX57344",
                    Eingang = new DateTime(2019, 8, 14),
                    Erledigt = true,
                    Erteilt = new DateTime(2019, 8, 14),
                    KundeID = 1
                };
                _handler.AuftragAnlegen(auftragMaxIDTest);

                // Auftrag mit max ID aus DB ziehen
                Auftrag auftragVergleich = (from a in db.Auftraege orderby a.AuftragID ascending select a).ToList().Last();

                // Test, ob alle Daten stimmen
                if (auftragMaxIDTest.Abgerechnet != auftragVergleich.Abgerechnet)
                {
                    Assert.Fail();
                }
                if (auftragMaxIDTest.AuftragNummer != auftragVergleich.AuftragNummer)
                {
                    Assert.Fail();
                }
                if (auftragMaxIDTest.Eingang != auftragVergleich.Eingang)
                {
                    Assert.Fail();
                }
                if (auftragMaxIDTest.Erledigt != auftragVergleich.Erledigt)
                {
                    Assert.Fail();
                }
                if (auftragMaxIDTest.Erteilt != auftragVergleich.Erteilt)
                {
                    Assert.Fail();
                }
                if (auftragMaxIDTest.KundeID != auftragVergleich.KundeID)
                {
                    Assert.Fail();
                }
            }
        }

        /// <summary>
        /// überprüft, ob ein Auftrag richtig bearbeitet wird
        /// </summary>
        /// <seealso cref="Handler.AuftragBearbeiten(Auftrag, int)"/>
        [TestMethod]
        public void AuftragBearbeitenTest()
        {
            using (var db = new EasyAuftragContext())
            {
                // Auftrag mit max ID zum Vergleich der Daten
                Auftrag aufragMaxIDTest = new Auftrag
                {
                    Abgerechnet = false,
                    AuftragNummer = "test10234",
                    Eingang = new DateTime(2019, 8, 14),
                    Erledigt = false,
                    Erteilt = new DateTime(2019, 8, 14),
                    KundeID = 2
                };
                _handler.AuftragAnlegen(aufragMaxIDTest);

                // bearbeiteter Auftrag in DB speichern
                Auftrag auftragBearbTest = new Auftrag
                {
                    Abgerechnet = true,
                    AuftragNummer = "testBearbeitet",
                    Eingang = new DateTime(2018, 7, 15),
                    Erledigt = true,
                    Erteilt = new DateTime(2018, 7, 15),
                    KundeID = 2
                };
                int maxID = (from a in db.Auftraege orderby a.AuftragID ascending select a.AuftragID).ToList().Last();
                _handler.AuftragBearbeiten(auftragBearbTest, maxID);

                // Auftrag mit max ID aus DB ziehen
                Auftrag auftragVergleich = (from a in db.Auftraege orderby a.AuftragID ascending where a.AuftragID == maxID select a).ToList().Last();

                // Test ob alle Daten geändert wurden
                if (auftragBearbTest.Abgerechnet != auftragVergleich.Abgerechnet)
                {
                    Assert.Fail();
                }
                if (auftragBearbTest.AuftragNummer != auftragVergleich.AuftragNummer)
                {
                    Assert.Fail();
                }
                if (auftragBearbTest.Eingang != auftragVergleich.Eingang)
                {
                    Assert.Fail();
                }
                if (auftragBearbTest.Erledigt != auftragVergleich.Erledigt)
                {
                    Assert.Fail();
                }
                if (auftragBearbTest.Erteilt != auftragVergleich.Erteilt)
                {
                    Assert.Fail();
                }
                if (auftragBearbTest.KundeID != auftragVergleich.KundeID)
                {
                    Assert.Fail();
                }
            }
        }

        /// <summary>
        /// überprüft, ob irgendein Auftrag gelöscht wird
        /// </summary>
        /// <seealso cref="Handler.AuftragLoeschen(int)"/>
        [TestMethod]
        public void IrgendeinAuftragLoeschenTest()
        {
            using (var db = new EasyAuftragContext())
            {
                // Auftrag hinzufügen
                Auftrag auftragTest = new Auftrag
                {
                    Abgerechnet = true,
                    AuftragNummer = "IrgendeinAuftragLöschenTest",
                    Eingang = new DateTime(2018, 7, 15),
                    Erledigt = true,
                    Erteilt = new DateTime(2018, 7, 15),
                    KundeID = 2
                };
                _handler.AuftragAnlegen(auftragTest);

                // ID des angelegten Auftrags herausfinden
                int maxID = (from a in db.Auftraege orderby a.AuftragID ascending select a.AuftragID).ToList().Last();

                // Anzahl der Aufträge herausfinden
                int anzahlAuftraege = (from a in db.Auftraege select a).ToList().Count();

                // angelegten Auftrag löschen
                _handler.AuftragLoeschen(maxID);

                // überprüfen, ob jetzt ein Auftrag weniger in der DB ist
                if (anzahlAuftraege - 1 != (from a in db.Auftraege select a).ToList().Count())
                {
                    Assert.Fail();
                }
            }
        }

        /// <summary>
        /// überprüft, ob der angegebene Auftrag gelöscht wird
        /// </summary>
        /// <seealso cref="Handler.AuftragLoeschen(int)"/>
        [TestMethod]
        public void AuftragLoeschenTest()
        {
            using (var db = new EasyAuftragContext())
            {
                // Auftrag hinzufügen
                Auftrag auftragTest = new Auftrag
                {
                    Abgerechnet = true,
                    AuftragNummer = "AuftragLöschenTest",
                    Eingang = new DateTime(2018, 7, 15),
                    Erledigt = true,
                    Erteilt = new DateTime(2018, 7, 15),
                    KundeID = 2
                };
                _handler.AuftragAnlegen(auftragTest);

                // ID des angelegten Auftrags herausfinden
                int maxID = (from a in db.Auftraege orderby a.AuftragID ascending select a.AuftragID).ToList().Last();

                // Versuch, gelöschten Auftrag aufzurufen
                auftragTest = (from a in db.Auftraege where a.AuftragID == maxID select a).ToList().First();

                // angelegten Auftrag löschen
                _handler.KundeLoeschen(maxID);

                // Versuch, gelöschten Auftrag aufzurufen
                auftragTest = (from a in db.Auftraege where a.AuftragID == maxID select a).ToList().First();

                // Falls der Auftrag doch noch existiert, also ungleich null ist, schlägt der Test fehl
                if (auftragTest != null)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void MitarbeiterAnlegenTest()
        {
            //
            // TODO: Testlogik hier hinzufügen
            //
        }

        [TestMethod]
        public void MitarbeiterBearbeitenTest()
        {
            //
            // TODO: Testlogik hier hinzufügen
            //
        }

        [TestMethod]
        public void MitarbeiterLoeschenTest()
        {
            //
            // TODO: Testlogik hier hinzufügen
            //
        }

        [TestMethod]
        public void TaetigkeitAnlegenTest()
        {
            //
            // TODO: Testlogik hier hinzufügen
            //
        }

        [TestMethod]
        public void TaetigkeitBearbeitenTest()
        {
            //
            // TODO: Testlogik hier hinzufügen
            //
        }

        [TestMethod]
        public void TaetigkeitLoeschenTest()
        {
            //
            // TODO: Testlogik hier hinzufügen
            //
        }

        [TestMethod]
        public void KundeLadenTest()
        {
            //
            // TODO: Testlogik hier hinzufügen
            //
        }

        [TestMethod]
        public void AuftragLadenTest()
        {
            //
            // TODO: Testlogik hier hinzufügen
            //
        }

        [TestMethod]
        public void MitarbeiterLadenTest()
        {
            //
            // TODO: Testlogik hier hinzufügen
            //
        }

        [TestMethod]
        public void TaetigkeitLadenTest()
        {
            //
            // TODO: Testlogik hier hinzufügen
            //
        }
    }
}
