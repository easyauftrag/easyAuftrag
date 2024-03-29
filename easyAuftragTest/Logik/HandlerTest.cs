﻿/*
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
using easyAuftrag;
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
                    Hausnr = "25",
                    Name = "Musterfirma24",
                    PLZ = "79112",
                    Strasse = "Teststr.",
                    TelefonNr = "+49 761 1234",
                    Wohnort = "Musterstadt"
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
                    Hausnr = "118",
                    Name = "Max Mustermann",
                    PLZ = "79136",
                    Strasse = "Musterallee",
                    TelefonNr = "0 (049) 0987 654321",
                    Wohnort = "Mußburg"
                };
                _handler.KundeAnlegen(kundeMaxIDTest);

                // max ID herausfinden
                int kundeMaxID = (from k in db.Kunden orderby k.KundeID ascending select k.KundeID).ToList().Last();

                // neuer Kunde zum Vergleich der max ID
                Kunde kundeTestMaxIDTestNeu = new Kunde
                {
                    Hausnr = "59",
                    Name = "Maia Musterfrau",
                    PLZ = "73523",
                    Strasse = "Am Marktplatz",
                    TelefonNr = "01673/86923245",
                    Wohnort = "Merzig (Saar)"
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
                    Hausnr = "1838",
                    Name = "Timo Template",
                    PLZ = "10946",
                    Strasse = "Zampastraße",
                    TelefonNr = "0235 243214",
                    Wohnort = "Berlin"
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
                    Hausnr = "46b",
                    Name = "Sören Testerson",
                    PLZ = "52847",
                    Strasse = "Fichtenweg",
                    TelefonNr = "01686/461832",
                    Wohnort = "Örtlingen"
                };
                _handler.KundeAnlegen(kundeMaxIDTest);

                // bearbeiteter Kunde in DB speichern
                Kunde kundeBearbTest = new Kunde
                {
                    Hausnr = "67",
                    Name = "Testerson Company",
                    PLZ = "74564",
                    Strasse = "Bergstraße",
                    TelefonNr = "01268 / 212256",
                    Wohnort = "Rosenthal"
                };
                int maxID = (from k in db.Kunden orderby k.KundeID ascending select k.KundeID).ToList().Last();

                bool success = false;
                success = _handler.KundeBearbeiten(kundeBearbTest, maxID);

                // Falls success false ist, schlägt der Test fehl
                if (!success)
                {
                    Assert.Fail();
                }

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
                    Hausnr = "74",
                    Name = "Martina Musterfrau",
                    PLZ = "35682",
                    Strasse = "Malergasse",
                    TelefonNr = "0184466687",
                    Wohnort = "Nördlingen"
                };
                _handler.KundeAnlegen(kundeTest);

                // ID des angelegten Kunden herausfinden
                int maxID = (from k in db.Kunden orderby k.KundeID ascending select k.KundeID).ToList().Last();

                // anzahl der Kunden herausfinden
                int anzahlKunden = (from k in db.Kunden select k).ToList().Count();

                bool success = false;
                // angelegten Kunden löschen
                success = _handler.KundeLoeschen(maxID);

                // Falls success false ist, schlägt der Test fehl
                if (!success)
                {
                    Assert.Fail();
                }

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
                    Hausnr = "82",
                    Name = "Tobias Tester",
                    PLZ = "73173",
                    Strasse = "Hauptstr.",
                    TelefonNr = "0269252",
                    Wohnort = "Rosslau"
                };
                _handler.KundeAnlegen(kundeTest);

                // ID des angelegten Kunden herausfinden
                int maxID = (from k in db.Kunden orderby k.KundeID ascending select k.KundeID).ToList().Last();

                bool success = false;

                // angelegten Kunden löschen
                success = _handler.KundeLoeschen(maxID);

                // Falls success false ist, schlägt der Test fehl
                if (!success)
                {
                    Assert.Fail();
                }

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
        /// überprüft, ob ein Kunde zur DB hinzugefügt wurde
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
                    AuftragNummer = "Auftrag_74",
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
        /// überprüft, ob die AuftragsID eines neu erstellten Auftrags richtig ist
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
                    AuftragNummer = "AZ-HG4",
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
                    AuftragNummer = "012345",
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
                    AuftragNummer = "Auftrag#20",
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
                    AuftragNummer = "Auftrag#20_bearb",
                    Eingang = new DateTime(2018, 7, 15),
                    Erledigt = true,
                    Erteilt = new DateTime(2018, 7, 15),
                    KundeID = 2
                };
                int maxID = (from a in db.Auftraege orderby a.AuftragID ascending select a.AuftragID).ToList().Last();

                bool success = false;
                success = _handler.AuftragBearbeiten(auftragBearbTest, maxID);

                // Falls success false ist, schlägt der Test fehl
                if (!success)
                {
                    Assert.Fail();
                }

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
                    AuftragNummer = "auftrag.97924",
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

                bool success = false;

                // angelegten Auftrag löschen
                success = _handler.AuftragLoeschen(maxID);

                // Falls success false ist, schlägt der Test fehl
                if (!success)
                {
                    Assert.Fail();
                }

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
                    AuftragNummer = "Heizung einbauen",
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

                bool success = false;

                // angelegten Auftrag löschen
                success = _handler.AuftragLoeschen(maxID);

                // Falls success false ist, schlägt der Test fehl
                if (!success)
                {
                    Assert.Fail();
                }

                // Versuch, gelöschten Auftrag aufzurufen
                auftragTest = (from a in db.Auftraege where a.AuftragID == maxID select a).ToList().First();

                // Falls der Auftrag doch noch existiert, also ungleich null ist, schlägt der Test fehl
                if (auftragTest != null)
                {
                    Assert.Fail();
                }
            }
        }

        /// <summary>
        /// überprüft, ob ein Mitarbeiter zur DB hinzugefügt wurde
        /// </summary>
        /// <seealso cref="Handler.MitarbeiterAnlegen(Mitarbeiter)"/>
        [TestMethod]
        public void IrgendeinMitarbeiterAnlegenTest()
        {
            using (var db = new EasyAuftragContext())
            {
                // Anzahl Mitarbeiter messen
                int anzahlMitarbeiter = (from m in db.Mitarbeiters select m).ToList().Count();

                // neuen Mitarbeiter anlegen
                Mitarbeiter mitarbeiterTest = new Mitarbeiter
                {
                    Hausnr = "93",
                    Name = "Otto Template",
                    PLZ = "65185",
                    Strasse = "Rheinstrasse",
                    TelefonNr = "0611 586437",
                    Wohnort = "Wiesbaden"
                };
                _handler.MitarbeiterAnlegen(mitarbeiterTest);

                // überprüfen, ob neuer Mitarbeiter angelegt wurde
                if (anzahlMitarbeiter + 1 != (from m in db.Mitarbeiters select m).ToList().Count())
                {
                    Assert.Fail();
                }
            }
        }

        /// <summary>
        /// überprüft, ob die MitarbeiterID eines neu erstellten Mitarbeiters richtig ist
        /// </summary>
        /// <seealso cref="Handler.MitarbeiterAnlegen(Mitarbeiter)"/>
        [TestMethod]
        public void MitarbeiterIDExistiertTest()
        {
            using (var db = new EasyAuftragContext())
            {
                // Mitarbeiter mit max ID, da vorheriger Mitarbeiter gelöscht sein könnte
                Mitarbeiter mitarbeiterMaxIDTest = new Mitarbeiter
                {
                    Hausnr = "1",
                    Name = "Heinz Muster",
                    PLZ = "94646",
                    Strasse = "Im Wiesengrund",
                    TelefonNr = "08526667",
                    Wohnort = "Neukirchen"
                };
                _handler.MitarbeiterAnlegen(mitarbeiterMaxIDTest);

                // max ID herausfinden
                int mitarbeiterMaxID = (from m in db.Mitarbeiters orderby m.MitarbeiterID ascending select m.MitarbeiterID).ToList().Last();

                // neuer Mitarbeiter zum Vergleich der max ID
                Mitarbeiter mitarbeiterTestMaxIDTestNeu = new Mitarbeiter
                {
                    Hausnr = "946",
                    Name = "Jürgen",
                    PLZ = "26431",
                    Strasse = "Kirchgasse",
                    TelefonNr = "06468723",
                    Wohnort = "Fuchstal"
                };
                _handler.MitarbeiterAnlegen(mitarbeiterTestMaxIDTestNeu);

                // überprüfen, ob neue ID existiert
                if (mitarbeiterMaxID + 1 != (from m in db.Mitarbeiters orderby m.MitarbeiterID ascending select m.MitarbeiterID).ToList().Last())
                {
                    Assert.Fail();
                }
            }
        }

        /// <summary>
        /// überprüft, ob die Daten eines neu angelegten Mitarbeiters richtig sind
        /// </summary>
        /// <seealso cref="Handler.MitarbeiterAnlegen(Mitarbeiter)"/>
        [TestMethod]
        public void MitarbeiterAnlegenDatenTest()
        {
            using (var db = new EasyAuftragContext())
            {
                // Mitarbeiter mit max ID zum Vergleich der Daten
                Mitarbeiter mitarbeiterMaxIDTest = new Mitarbeiter
                {
                    Hausnr = "399",
                    Name = "Milla Musterfrau",
                    PLZ = "94638",
                    Strasse = "Obere Saitengasse",
                    TelefonNr = "08314654100",
                    Wohnort = "Ulm"
                };
                _handler.MitarbeiterAnlegen(mitarbeiterMaxIDTest);

                // Mitarbeiter mit max ID aus DB ziehen
                Mitarbeiter mitarbeiterVergleich = (from m in db.Mitarbeiters orderby m.MitarbeiterID ascending select m).ToList().Last();

                if (mitarbeiterMaxIDTest.Hausnr != mitarbeiterVergleich.Hausnr)
                {
                    Assert.Fail();
                }
                if (mitarbeiterMaxIDTest.Name != mitarbeiterVergleich.Name)
                {
                    Assert.Fail();
                }
                if (mitarbeiterMaxIDTest.PLZ != mitarbeiterVergleich.PLZ)
                {
                    Assert.Fail();
                }
                if (mitarbeiterMaxIDTest.Strasse != mitarbeiterVergleich.Strasse)
                {
                    Assert.Fail();
                }
                if (mitarbeiterMaxIDTest.TelefonNr != mitarbeiterVergleich.TelefonNr)
                {
                    Assert.Fail();
                }
                if (mitarbeiterMaxIDTest.Wohnort != mitarbeiterVergleich.Wohnort)
                {
                    Assert.Fail();
                }
            }
        }

        /// <summary>
        /// überprüft, ob ein Mitarbeiter korrekt bearbeitet wurde
        /// </summary>
        /// <seealso cref="Handler.MitarbeiterBearbeiten(Mitarbeiter, int)"/>
        [TestMethod]
        public void MitarbeiterBearbeitenTest()
        {
            using (var db = new EasyAuftragContext())
            {
                // Mitarbeiter mit max ID zum Vergleich der Daten
                Mitarbeiter mitarbeiterMaxIDTest = new Mitarbeiter
                {
                    Hausnr = "7",
                    Name = "Max Mustermann",
                    PLZ = "94646",
                    Strasse = "Um die Ecke",
                    TelefonNr = "0123456",
                    Wohnort = "Musterstadt"
                };
                _handler.MitarbeiterAnlegen(mitarbeiterMaxIDTest);

                // bearbeiteter Mitarbeiter in DB speichern
                Mitarbeiter mitarbeiterBearbTest = new Mitarbeiter
                {
                    Hausnr = "9",
                    Name = "Max Tester",
                    PLZ = "46648",
                    Strasse = "Teststr.",
                    TelefonNr = "35465",
                    Wohnort = "Eisenach"
                };
                int maxID = (from m in db.Mitarbeiters orderby m.MitarbeiterID ascending select m.MitarbeiterID).ToList().Last();

                bool success = false;

                success = _handler.MitarbeiterBearbeiten(mitarbeiterBearbTest, maxID);

                // Falls success false ist, schlägt der Test fehl
                if (!success)
                {
                    Assert.Fail();
                }

                // Mitarbeiter mit max ID aus DB ziehen
                Mitarbeiter mitarbeiterVergleich = (from m in db.Mitarbeiters orderby m.MitarbeiterID ascending where m.MitarbeiterID == maxID select m).ToList().Last();

                // Test ob alle Daten geändert wurden
                if (mitarbeiterBearbTest.Hausnr != mitarbeiterVergleich.Hausnr)
                {
                    Assert.Fail();
                }
                if (mitarbeiterBearbTest.Name != mitarbeiterVergleich.Name)
                {
                    Assert.Fail();
                }
                if (mitarbeiterBearbTest.PLZ != mitarbeiterVergleich.PLZ)
                {
                    Assert.Fail();
                }
                if (mitarbeiterBearbTest.Strasse != mitarbeiterVergleich.Strasse)
                {
                    Assert.Fail();
                }
                if (mitarbeiterBearbTest.TelefonNr != mitarbeiterVergleich.TelefonNr)
                {
                    Assert.Fail();
                }
                if (mitarbeiterBearbTest.Wohnort != mitarbeiterVergleich.Wohnort)
                {
                    Assert.Fail();
                }
            }
        }

        /// <summary>
        /// überprüft, ob irgendein Mitarbeiter gelöscht wird
        /// </summary>
        /// <seealso cref="Handler.MitarbeiterLoeschen(int)"/>
        [TestMethod]
        public void IrgendeinMitarbeiterLoeschenTest()
        {
            using (var db = new EasyAuftragContext())
            {
                // Mitarbeiter hinzufügen
                Mitarbeiter mitarbeiterTest = new Mitarbeiter
                {
                    Hausnr = "39",
                    Name = "Max Mustermann",
                    PLZ = "34856",
                    Strasse = "Holzweg",
                    TelefonNr = "02446958",
                    Wohnort = "Teststadt"
                };
                _handler.MitarbeiterAnlegen(mitarbeiterTest);

                // ID des angelegten Mitarbeiters herausfinden
                int maxID = (from m in db.Mitarbeiters orderby m.MitarbeiterID ascending select m.MitarbeiterID).ToList().Last();

                // anzahl der Mitarbeiter herausfinden
                int anzahlMitarbeiter = (from m in db.Mitarbeiters select m).ToList().Count();
                
                bool success = false;
                
                // angelegten Mitarbeiter löschen
                success = _handler.MitarbeiterLoeschen(maxID);

                // Falls success false ist, schlägt der Test fehl
                if (!success)
                {
                    Assert.Fail();
                }

                // überprüfen, ob jetzt ein Mitarbeiter weniger in der DB ist
                if (anzahlMitarbeiter - 1 != (from m in db.Mitarbeiters select m).ToList().Count())
                {
                    Assert.Fail();
                }
            }
        }

        /// <summary>
        /// überprüft, ob der angegebene Mitarbeiter gelöscht wird
        /// </summary>
        /// <seealso cref="Handler.MitarbeiterLoeschen(int)"/>
        [TestMethod]
        public void MitarbeiterLoeschenTest()
        {
            using (var db = new EasyAuftragContext())
            {
                // Mitarbeiter hinzufügen
                Mitarbeiter mitarbeiterTest = new Mitarbeiter
                {
                    Hausnr = "78",
                    Name = "Matthias Mustermann",
                    PLZ = "64979",
                    Strasse = "Musterstraße",
                    TelefonNr = "014987676",
                    Wohnort = "Testort"
                };
                _handler.MitarbeiterAnlegen(mitarbeiterTest);

                // ID des angelegten Mitarbeiters herausfinden
                int maxID = (from m in db.Mitarbeiters orderby m.MitarbeiterID ascending select m.MitarbeiterID).ToList().Last();

                bool success = false;

                // angelegten Mitarbeiter löschen
                success = _handler.MitarbeiterLoeschen(maxID);

                // Falls success false ist, schlägt der Test fehl
                if (!success)
                {
                    Assert.Fail();
                }

                // Versuch, gelöschten Mitarbeiter aufzurufen
                mitarbeiterTest = (from m in db.Mitarbeiters where m.MitarbeiterID == maxID select m).ToList().First();

                // Falls der Mitarbeiter doch noch existiert, also ungleich null ist, schlägt der Test fehl
                if (mitarbeiterTest != null)
                {
                    Assert.Fail();
                }
            }
        }

        /// <summary>
        /// überprüft, ob eine Taetigkeit zur DB hinzugefügt wurde
        /// </summary>
        /// <seealso cref="Handler.TaetigkeitAnlegen(Taetigkeit)"/>
        [TestMethod]
        public void IrgendeineTaetigkeitAnlegenTest()
        {
            using (var db = new EasyAuftragContext())
            {
                // Anzahl Taetigkeit messen
                int anzahlTaetigkeiten = (from t in db.Taetigkeiten select t).ToList().Count();

                // neuen Taetigkeit anlegen
                Taetigkeit taetigkeitTest = new Taetigkeit
                {
                    AuftragID = 1,
                    Datum = new DateTime(2019, 8, 14),
                    MitarbeiterID = 1,
                    Name = "Heizungskessel einbauen",
                    StartZeit = new TimeSpan(12, 44, 0),
                    EndZeit = new TimeSpan(15, 23, 14)
                };
                _handler.TaetigkeitAnlegen(taetigkeitTest);

                // überprüfen, ob neue Taetigkeit angelegt wurde
                if (anzahlTaetigkeiten + 1 != (from t in db.Taetigkeiten select t).ToList().Count())
                {
                    Assert.Fail();
                }
            }
        }

        /// <summary>
        /// überprüft, ob die TaetigkeitsID einer neu erstellten Taetigkeit richtig ist
        /// </summary>
        /// <seealso cref="Handler.KundeAnlegen(Kunde)"/>
        [TestMethod]
        public void TaetigkeitIDExistiertTest()
        {
            using (var db = new EasyAuftragContext())
            {
                // Taetigkeit mit max ID, da vorherige Taetigkeit gelöscht sein könnte
                Taetigkeit taetigkeitMaxIDTest = new Taetigkeit
                {
                    AuftragID = 2,
                    Datum = new DateTime(2019, 8, 14),
                    MitarbeiterID = 3,
                    Name = "Wand mauern",
                    StartZeit = new TimeSpan(12, 44, 0),
                    EndZeit = new TimeSpan(15, 23, 14)
                };
                _handler.TaetigkeitAnlegen(taetigkeitMaxIDTest);

                // max ID herausfinden
                int taetigkeitMaxID = (from t in db.Taetigkeiten orderby t.TaetigkeitID ascending select t.TaetigkeitID).ToList().Last();

                // neue Taetigkeit zum Vergleich der max ID
                Taetigkeit taetigkeitTestMaxIDTestNeu = new Taetigkeit
                {
                    AuftragID = 2,
                    Datum = new DateTime(2019, 8, 14),
                    MitarbeiterID = 3,
                    Name = "Wand einreißen",
                    StartZeit = new TimeSpan(12, 44, 0),
                    EndZeit = new TimeSpan(15, 23, 14)
                };
                _handler.TaetigkeitAnlegen(taetigkeitTestMaxIDTestNeu);

                // überprüfen, ob neue ID existiert
                if (taetigkeitMaxID + 1 != (from t in db.Taetigkeiten orderby t.TaetigkeitID ascending select t.TaetigkeitID).ToList().Last())
                {
                    Assert.Fail();
                }
            }
        }

        /// <summary>
        /// überprüft, ob die Daten einer neu angelegten Taetigkeit richtig sind
        /// </summary>
        /// <seealso cref="Handler.TaetigkeitAnlegen(Taetigkeit)"/>
        [TestMethod]
        public void TaetigkeitAnlegenDatenTest()
        {
            using (var db = new EasyAuftragContext())
            {
                // Taetigkeit mit max ID zum Vergleich der Daten
                Taetigkeit taetigkeitMaxIDTest = new Taetigkeit
                {
                    AuftragID = 2,
                    Datum = new DateTime(2019, 8, 14),
                    MitarbeiterID = 3,
                    Name = "Häusle baue",
                    StartZeit = new TimeSpan(12, 44, 0),
                    EndZeit = new TimeSpan(15, 23, 14)
                };
                _handler.TaetigkeitAnlegen(taetigkeitMaxIDTest);

                // Taetigkeit mit max ID aus DB ziehen
                Taetigkeit taetigkeitVergleich = (from t in db.Taetigkeiten orderby t.TaetigkeitID ascending select t).ToList().Last();

                if (taetigkeitMaxIDTest.AuftragID != taetigkeitVergleich.AuftragID)
                {
                    Assert.Fail();
                }
                if (taetigkeitMaxIDTest.Name != taetigkeitVergleich.Name)
                {
                    Assert.Fail();
                }
                if (taetigkeitMaxIDTest.Datum != taetigkeitVergleich.Datum)
                {
                    Assert.Fail();
                }
                if (taetigkeitMaxIDTest.MitarbeiterID != taetigkeitVergleich.MitarbeiterID)
                {
                    Assert.Fail();
                }
                if (taetigkeitMaxIDTest.StartZeit != taetigkeitVergleich.StartZeit)
                {
                    Assert.Fail();
                }
                if (taetigkeitMaxIDTest.EndZeit != taetigkeitVergleich.EndZeit)
                {
                    Assert.Fail();
                }
            }
        }

        /// <summary>
        /// überprüft, ob eine Taetigkeit korrekt bearbeitet wurde
        /// </summary>
        /// <seealso cref="Handler.TaetigkeitBearbeiten(Taetigkeit, int)"/>
        [TestMethod]
        public void TaetigkeitBearbeitenTest()
        {
            using (var db = new EasyAuftragContext())
            {
                // Taetigkeit mit max ID zum Vergleich der Daten
                Taetigkeit taetigkeitMaxIDTest = new Taetigkeit
                {
                    AuftragID = 2,
                    Datum = new DateTime(2019, 8, 14),
                    MitarbeiterID = 3,
                    Name = "Dach versiegeln",
                    StartZeit = new TimeSpan(12, 44, 0),
                    EndZeit = new TimeSpan(15, 23, 14)
                };
                _handler.TaetigkeitAnlegen(taetigkeitMaxIDTest);

                // bearbeitete Taetigkeit in DB speichern
                Taetigkeit taetigkeitBearbTest = new Taetigkeit
                {
                    AuftragID = 1,
                    Datum = new DateTime(2018, 5, 14),
                    MitarbeiterID = 1,
                    Name = "Dach decken",
                    StartZeit = new TimeSpan(17, 43, 0),
                    EndZeit = new TimeSpan(23, 23, 54)
                };
                int maxID = (from k in db.Taetigkeiten orderby k.TaetigkeitID ascending select k.TaetigkeitID).ToList().Last();

                bool success = false;

                success = _handler.TaetigkeitBearbeiten(taetigkeitBearbTest, maxID);

                // Falls success false ist, schlägt der Test fehl
                if (!success)
                {
                    Assert.Fail();
                }

                // Taetigkeit mit max ID aus DB ziehen
                Taetigkeit taetigkeitVergleich = (from t in db.Taetigkeiten orderby t.TaetigkeitID ascending where t.TaetigkeitID == maxID select t).ToList().Last();

                // Test ob alle Daten geändert wurden
                if (taetigkeitBearbTest.AuftragID != taetigkeitVergleich.AuftragID)
                {
                    Assert.Fail();
                }
                if (taetigkeitBearbTest.Name != taetigkeitVergleich.Name)
                {
                    Assert.Fail();
                }
                if (taetigkeitBearbTest.Datum != taetigkeitVergleich.Datum)
                {
                    Assert.Fail();
                }
                if (taetigkeitBearbTest.MitarbeiterID != taetigkeitVergleich.MitarbeiterID)
                {
                    Assert.Fail();
                }
                if (taetigkeitBearbTest.StartZeit != taetigkeitVergleich.StartZeit)
                {
                    Assert.Fail();
                }
                if (taetigkeitBearbTest.EndZeit != taetigkeitVergleich.EndZeit)
                {
                    Assert.Fail();
                }
            }
        }

        /// <summary>
        /// überprüft, ob irgendeine Taetigkeit gelöscht wird
        /// </summary>
        /// <seealso cref="Handler.TaetigkeitLoeschen(int)"/>
        [TestMethod]
        public void IrgendeineTaetigkeitLoeschenTest()
        {
            using (var db = new EasyAuftragContext())
            {
                // Taetigkeit hinzufügen
                Taetigkeit taetigkeitTest = new Taetigkeit
                {
                    AuftragID = 1,
                    Datum = new DateTime(2018, 5, 14),
                    MitarbeiterID = 1,
                    Name = "Neu verputzen",
                    StartZeit = new TimeSpan(17, 43, 0),
                    EndZeit = new TimeSpan(23, 23, 54)
                };
                _handler.TaetigkeitAnlegen(taetigkeitTest);

                // ID der angelegten Taetigkeit herausfinden
                int maxID = (from t in db.Taetigkeiten orderby t.TaetigkeitID ascending select t.TaetigkeitID).ToList().Last();

                // anzahl der Taetigkeiten herausfinden
                int anzahlTaetigkeiten = (from t in db.Taetigkeiten select t).ToList().Count();

                bool success = false;

                // angelegte Taetigkeit löschen
                success = _handler.TaetigkeitLoeschen(maxID);

                // Falls success false ist, schlägt der Test fehl
                if (!success)
                {
                    Assert.Fail();
                }

                // überprüfen, ob jetzt eine Taetigkeit weniger in der DB ist
                if (anzahlTaetigkeiten - 1 != (from t in db.Taetigkeiten select t).ToList().Count())
                {
                    Assert.Fail();
                }
            }
        }

        /// <summary>
        /// überprüft, ob die angegebene Taetigkeit gelöscht wird
        /// </summary>
        /// <seealso cref="Handler.TaetigkeitLoeschen(int)"/>
        [TestMethod]
        public void TaetigkeitLoeschenTest()
        {
            using (var db = new EasyAuftragContext())
            {
                // Taetigkeit hinzufügen
                Taetigkeit taetigkeitTest = new Taetigkeit
                {
                    AuftragID = 1,
                    Datum = new DateTime(2018, 5, 14),
                    MitarbeiterID = 1,
                    Name = "Fliesen legen",
                    StartZeit = new TimeSpan(17, 43, 0),
                    EndZeit = new TimeSpan(23, 23, 54)
                };
                _handler.TaetigkeitAnlegen(taetigkeitTest);

                // ID der angelegten Taetigkeit herausfinden
                int maxID = (from t in db.Taetigkeiten orderby t.TaetigkeitID ascending select t.TaetigkeitID).ToList().Last();

                bool success = false;
                
                // angelegte Taetigkeit löschen
                success = _handler.TaetigkeitLoeschen(maxID);

                // Falls success false ist, schlägt der Test fehl
                if (!success)
                {
                    Assert.Fail();
                }

                // Versuch, gelöschte Taetigkeit aufzurufen
                taetigkeitTest = (from t in db.Taetigkeiten where t.TaetigkeitID == maxID select t).ToList().First();

                // Falls die Taetigkeit doch noch existiert, also ungleich null ist, schlägt der Test fehl
                if (taetigkeitTest != null)
                {
                    Assert.Fail();
                }
            }
        }

        /// <summary>
        /// überprüft, ob ein Kunde richtig aus der DB geladen wird
        /// </summary>
        /// <seealso cref="Handler.KundeLaden(int)"/>
        [TestMethod]
        public void KundeLadenTest()
        {
            using (var db = new EasyAuftragContext())
            {
                // neuen Kunden anlegen
                Kunde kundeTest = new Kunde
                {
                    Hausnr = "8",
                    Name = "Monika Muster",
                    PLZ = "16497",
                    Strasse = "Eichenweg",
                    TelefonNr = "080949964",
                    Wohnort = "Storz"
                };
                _handler.KundeAnlegen(kundeTest);

                // max ID herausfinden
                int kundeMaxID = (from k in db.Kunden orderby k.KundeID ascending select k.KundeID).ToList().Last();

                // success initialisieren
                bool success = false;

                // Kunde laden
                Kunde kundeGeladen = _handler.KundeLaden(kundeMaxID, out success);

                // Falls success false ist, schlägt der Test fehl
                if (!success)
                {
                    Assert.Fail();
                }

                // Eigenschaften des Kunden vergleichen
                if (kundeTest.Hausnr != kundeGeladen.Hausnr)
                {
                    Assert.Fail();
                }
                if (kundeTest.Name != kundeGeladen.Name)
                {
                    Assert.Fail();
                }
                if (kundeTest.PLZ != kundeGeladen.PLZ)
                {
                    Assert.Fail();
                }
                if (kundeTest.Strasse != kundeGeladen.Strasse)
                {
                    Assert.Fail();
                }
                if (kundeTest.TelefonNr != kundeGeladen.TelefonNr)
                {
                    Assert.Fail();
                }
                if (kundeTest.Wohnort != kundeGeladen.Wohnort)
                {
                    Assert.Fail();
                }
            }
        }

        /// <summary>
        /// überprüft, ob ein Auftrag richtig aus der DB geladen wird
        /// </summary>
        /// <seealso cref="Handler.AuftragLaden(int)"/>
        [TestMethod]
        public void AuftragLadenTest()
        {
            using (var db = new EasyAuftragContext())
            {
                // neuen Auftrag anlegen
                Auftrag auftragTest = new Auftrag
                {
                    Abgerechnet = false,
                    AuftragNummer = "AU-66$15",
                    Eingang = new DateTime(2019, 8, 14),
                    Erledigt = false,
                    Erteilt = new DateTime(2019, 8, 14),
                    KundeID = 2
                };
                _handler.AuftragAnlegen(auftragTest);

                // max ID herausfinden
                int auftragMaxID = (from a in db.Auftraege orderby a.AuftragID ascending select a.AuftragID).ToList().Last();

                // success initialisieren
                bool success = false;

                // Auftrag laden
                Auftrag auftragGeladen = _handler.AuftragLaden(auftragMaxID, out success);
                
                // Falls success false ist, schlägt der Test fehl
                if (!success)
                {
                    Assert.Fail();
                }

                // Eigenschaften des Auftrags vergleichen
                if (auftragGeladen.Abgerechnet != auftragTest.Abgerechnet)
                {
                    Assert.Fail();
                }
                if (auftragGeladen.AuftragNummer != auftragTest.AuftragNummer)
                {
                    Assert.Fail();
                }
                if (auftragGeladen.Eingang != auftragTest.Eingang)
                {
                    Assert.Fail();
                }
                if (auftragGeladen.Erledigt != auftragTest.Erledigt)
                {
                    Assert.Fail();
                }
                if (auftragGeladen.Erteilt != auftragTest.Erteilt)
                {
                    Assert.Fail();
                }
                if (auftragGeladen.KundeID != auftragTest.KundeID)
                {
                    Assert.Fail();
                }
            }
        }

        /// <summary>
        /// überprüft, ob ein Mitarbeiter richtig aus der DB geladen wird
        /// </summary>
        /// <seealso cref="Handler.MitarbeiterLaden(int)"/>
        [TestMethod]
        public void MitarbeiterLadenTest()
        {
            using (var db = new EasyAuftragContext())
            {
                // neuen Mitarbeiter anlegen
                Mitarbeiter mitarbeiterTest = new Mitarbeiter
                {
                    Hausnr = "32",
                    Name = "Jan Test",
                    PLZ = "25449",
                    Strasse = "Dobel",
                    TelefonNr = "06987525",
                    Wohnort = "Holzach"
                };
                _handler.MitarbeiterAnlegen(mitarbeiterTest);

                // max ID herausfinden
                int mitarbeiterMaxID = (from m in db.Mitarbeiters orderby m.MitarbeiterID ascending select m.MitarbeiterID).ToList().Last();

                // success initialisieren
                bool success = false;

                // Mitarbeiter laden
                Mitarbeiter mitarbeiterGeladen = _handler.MitarbeiterLaden(mitarbeiterMaxID, out success);

                // Falls success false ist, schlägt der Test fehl
                if (!success)
                {
                    Assert.Fail();
                }

                // Eigenschaften des Kunden vergleichen
                if (mitarbeiterTest.Hausnr != mitarbeiterGeladen.Hausnr)
                {
                    Assert.Fail();
                }
                if (mitarbeiterTest.Name != mitarbeiterGeladen.Name)
                {
                    Assert.Fail();
                }
                if (mitarbeiterTest.PLZ != mitarbeiterGeladen.PLZ)
                {
                    Assert.Fail();
                }
                if (mitarbeiterTest.Strasse != mitarbeiterGeladen.Strasse)
                {
                    Assert.Fail();
                }
                if (mitarbeiterTest.TelefonNr != mitarbeiterGeladen.TelefonNr)
                {
                    Assert.Fail();
                }
                if (mitarbeiterTest.Wohnort != mitarbeiterGeladen.Wohnort)
                {
                    Assert.Fail();
                }
            }
        }

        /// <summary>
        /// überprüft, ob eine Tätigkeit richtig aus der DB geladen wird
        /// </summary>
        /// <seealso cref="Handler.TaetigkeitLaden(int)"/>
        [TestMethod]
        public void TaetigkeitLadenTest()
        {
            using (var db = new EasyAuftragContext())
            {
                // neue Taetigkeit anlegen
                Taetigkeit taetigkeitTest = new Taetigkeit
                {
                    AuftragID = 2,
                    Datum = new DateTime(2019, 8, 14),
                    MitarbeiterID = 3,
                    Name = "Wand streichen",
                    StartZeit = new TimeSpan(12, 44, 0),
                    EndZeit = new TimeSpan(15, 23, 14)
                };
                _handler.TaetigkeitAnlegen(taetigkeitTest);

                // max ID herausfinden
                int taetigkeitMaxID = (from t in db.Taetigkeiten orderby t.TaetigkeitID ascending select t.TaetigkeitID).ToList().Last();

                // success initialisieren
                bool success = false;

                // Taetigkeit laden
                Taetigkeit taetigkeitGeladen = _handler.TaetigkeitLaden(taetigkeitMaxID, out success);

                // Falls success false ist, schlägt der Test fehl
                if (!success)
                {
                    Assert.Fail();
                }

                // Eigenschaften des Kunden vergleichen
                if (taetigkeitGeladen.AuftragID != taetigkeitTest.AuftragID)
                {
                    Assert.Fail();
                }
                if (taetigkeitGeladen.Datum != taetigkeitTest.Datum)
                {
                    Assert.Fail();
                }
                if (taetigkeitGeladen.MitarbeiterID != taetigkeitTest.MitarbeiterID)
                {
                    Assert.Fail();
                }
                if (taetigkeitGeladen.Name != taetigkeitTest.Name)
                {
                    Assert.Fail();
                }
                if (taetigkeitGeladen.StartZeit != taetigkeitTest.StartZeit)
                {
                    Assert.Fail();
                }
                if (taetigkeitGeladen.EndZeit != taetigkeitTest.EndZeit)
                {
                    Assert.Fail();
                }
            }
        }
    }
}
