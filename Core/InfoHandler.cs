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
using System.Windows.Forms;

namespace Core
{
    /// <summary>
    /// Klasse für den ErrorHandler
    /// </summary>
    /// <remarks>
    /// Sammelt Informationen über einen Fehler und schreibt diese in eine Logdatei.
    /// </remarks>
    public class InfoHandler
    {
        /// <summary>
        /// Methode für den InfoHandler
        /// </summary>
        /// <remarks>
        /// Bekommt Informationen und
        /// fügt sie mit einem <see cref="StringBuilder"/> mit dem aktuellen Datum zusammen 
        /// und schreibt sie mit einem <see cref="TextWriter"/> in eine Logdatei.
        /// Falls die Logdatei noch nicht existiert, wird sie neu erstellt.
        /// </remarks>
        /// <seealso cref="System.IO"/>
        public static void InfoHandle(string info)
        {
            try
            {
                // Mit StringBuilder Infos über Fehler zusammenstellen
                StringBuilder buildInfo = new StringBuilder();
                buildInfo.Append("Event");
                buildInfo.Append(" ");
                buildInfo.Append(System.DateTime.Now.ToShortDateString());
                buildInfo.Append(" ");
                buildInfo.Append(info);

                // Ausgabe im Logfile
                string pfad = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "easyAuftrag");

                if (!Directory.Exists(pfad))
                {
                    Directory.CreateDirectory(pfad);
                }
                pfad = Path.Combine(pfad, "event.log");
                TextWriter writer = new StreamWriter(pfad, true);
                writer.WriteLine(buildInfo);
                writer.WriteLine();
                writer.Flush();
                writer.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
