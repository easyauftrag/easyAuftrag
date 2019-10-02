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
using System.Text;
using System.Threading.Tasks;

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

        }
    }
}
