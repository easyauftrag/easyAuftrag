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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static System.Environment;

namespace Core
{
    /// <summary>
    /// Klasse zur Interaktion mit der Konfigurationsdatei
    /// </summary>
    public class Config
    {
        /// <summary>
        /// Soll-Wert der Wochenstunden, wird mit der Auslastung der Stelle verrechnet
        /// </summary>
        /// <seealso cref="Model.Mitarbeiter.AuslastungStelle"/>
        public double StundenSoll { get; set; }
        /// <summary>
        /// Standardmäßiger Zielpfad für den Export von Dateien
        /// </summary>
        public string StandardZielPfad { get; set; }
        public bool WinAuth { get; set; }
        public string Datenbank { get; set; }
        public string Server { get; set; }
        public string BenutzerName { get; set; }
        public string Passwort { get; set; }
        public string ConnectionString { get { return BuildConString(); } }

        public Config()
        {
            StundenSoll = new double();
        }

        private string BuildConString()
        {
            string conType;
            if (WinAuth)
            {
                conType = "Integrated Security=True";
            }
            else
            {
                conType = "User=" 
                    + BenutzerName
                    + "; Password=" 
                    + Passwort;
            }
            string con = "Data Source=" 
                + Server 
                + ";Initial Catalog="
                + Datenbank + ";" 
                + conType 
                + ";Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            return con;
        }

        public void SchreibeXML()
        {
            try
            {
                // Erzeugt ein neues XMLDocument
                XmlDocument doc = new XmlDocument();

                // Fügt den Wurzelknoten "Config" zum XMLDocument hinzu
                XmlNode rootNode = doc.CreateElement("Config");
                doc.AppendChild(rootNode);

                // Erzeugt einen Knoten mit dem Tag "Allgemein"
                XmlNode childNodeAllg = doc.CreateElement("Allgemein");
                // Fügt die Eigenschaft Stundensoll dem Knoten hinzu
                XmlAttribute stundenSoll = doc.CreateAttribute("Stundensoll");
                stundenSoll.Value = StundenSoll.ToString();
                childNodeAllg.Attributes.Append(stundenSoll);
                // Fügt die Eigenschaft StandardZielPfad dem Knoten hinzu
                XmlAttribute standardZielPfad = doc.CreateAttribute("StandardZielPfad");
                standardZielPfad.Value = StandardZielPfad.ToString();
                childNodeAllg.Attributes.Append(standardZielPfad);
                // Fügt den Knoten dem XMLDocument hinzu
                rootNode.AppendChild(childNodeAllg);

                // Erzeugt einen Knoten mit dem Tag "Datenbank"
                XmlNode childNodeDB = doc.CreateElement("Datenbank");
                // Fügt die Eigenschaft WinAuth dem Knoten hinzu
                XmlAttribute winAuth = doc.CreateAttribute("WinAuth");
                winAuth.Value = WinAuth.ToString();
                childNodeDB.Attributes.Append(winAuth);
                // Fügt die Eigenschaft Datenbank dem Knoten hinzu
                XmlAttribute datenbank = doc.CreateAttribute("Datenbank");
                datenbank.Value = Datenbank.ToString();
                childNodeDB.Attributes.Append(datenbank);
                // Fügt die Eigenschaft Server dem Knoten hinzu
                XmlAttribute server = doc.CreateAttribute("Server");
                server.Value = Server.ToString();
                childNodeDB.Attributes.Append(server);
                // Fügt die Eigenschaft BenutzerName dem Knoten hinzu
                XmlAttribute benutzerName = doc.CreateAttribute("BenutzerName");
                benutzerName.Value = BenutzerName.ToString();
                childNodeDB.Attributes.Append(benutzerName);
                // Fügt die Eigenschaft Passwort dem Knoten hinzu
                XmlAttribute passwort = doc.CreateAttribute("Passwort");
                passwort.Value = Passwort.ToString();
                childNodeDB.Attributes.Append(passwort);
                // Fügt den Knoten dem XMLDocument hinzu
                rootNode.AppendChild(childNodeDB);

                // Schreibt das XmlDocument in die Datei in %Appdata%
                string path = GetFolderPath(SpecialFolder.ApplicationData);
                path = Path.Combine(path, "easyAuftrag");
                path = Path.Combine(path, "Config");
                Directory.CreateDirectory(path);
                path = Path.Combine(path, "config.xml");
                doc.Save(path);
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        public bool LeseXML()
        {
            try
            {
                // Erzeugt ein neues XMLDocument und lädt die Datei
                XmlDocument xml = new XmlDocument();
                string path = GetFolderPath(SpecialFolder.ApplicationData);
                path = Path.Combine(path, "easyAuftrag");
                path = Path.Combine(path, "Config");
                Directory.CreateDirectory(path);
                path = Path.Combine(path, "config.xml");
                if (File.Exists(path))
                {
                    xml.Load(path);

                    // Weist alle Eigenschften des Knoten mit dem Tag "Allgemein" dem Objekt zu
                    XmlNode xmlAllg = xml.GetElementsByTagName("Allgemein").Item(0);
                    StundenSoll = Convert.ToDouble(xmlAllg.Attributes["Stundensoll"].Value);
                    StandardZielPfad = xmlAllg.Attributes["StandardZielPfad"].Value.Trim();

                    // Weist alle Eigenschften des Knoten mit dem Tag "Datenbank" dem Objekt zu
                    XmlNode xmlDB = xml.GetElementsByTagName("Datenbank").Item(0);
                    WinAuth = Convert.ToBoolean(xmlDB.Attributes["WinAuth"].Value);
                    Datenbank = xmlDB.Attributes["Datenbank"].Value.Trim();
                    Server = xmlDB.Attributes["Server"].Value.Trim();
                    BenutzerName = xmlDB.Attributes["BenutzerName"].Value.Trim();
                    Passwort = xmlDB.Attributes["Passwort"].Value.Trim();
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
                return false;
            }
        }
    }
}
