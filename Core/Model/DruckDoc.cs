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

namespace Core.Model
{
    /// <summary>
    /// Model-Klasse zum Erstellen von DruckDoc Objekten
    /// </summary>
    public class DruckDoc
    {
        /// <summary>
        /// Auftragsnummer
        /// </summary>
        public string AuftragNr { get; set; }

        /// <summary>
        /// Kundenname
        /// </summary>
        public string KundeName { get; set; }

        /// <summary>
        /// Adresse des Kunden
        /// </summary>
        public string KundeAnschrift { get; set; }

        /// <summary>
        /// Telefonnummer des Kunden
        /// </summary>
        public string KundeTelefon { get; set; }

        /// <summary>
        /// Liste der Tätigkeiten in Zusammenhang mit dem Auftrag
        /// </summary>
        public List<Taetigkeit> TatListe { get; set; }

        /// <summary>
        /// Liste der Mitarbeiter, die am Auftrag mitgewirkt haben
        /// </summary>
        public List<Mitarbeiter> MitListe { get; set; }
        
        /// <summary>
        /// Liste der Adressen des Kunden
        /// </summary>
        public List<Adresse> AdrListe { get; set; }

        /// <summary>
        /// Konstruktor für die Klasse DruckDoc
        /// </summary>
        public DruckDoc()
        {

        }
    }
}
