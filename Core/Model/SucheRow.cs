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
using System.Windows.Forms;

namespace Core.Model
{
    /// <summary>
    /// Model-Klasse zum Erzeugen von Zeilen Objekten für die UserControl SuchControl
    /// </summary>
    public class SucheRow
    {
        /// <summary>
        /// Logische Verknüpfung der Zeilen (null, und, oder)
        /// </summary>
        public ComboBox LinkControl { get; set; }
        /// <summary>
        /// Auswahl der Tabellenspalte
        /// </summary>
        public ComboBox SpalteControl { get; set; }
        /// <summary>
        /// Suchwert falls Textwert
        /// </summary>
        public TextBox ValueControl { get; set; }
        /// <summary>
        /// Anfangssuchwert falls Datum
        /// </summary>
        public DateTimePicker AnfangControl { get; set; }
        /// <summary>
        /// Endsuchwertwert falls Datum
        /// </summary>
        public DateTimePicker EndeControl { get; set; }
        /// <summary>
        /// Suchwert (true/false) falls Abgerechnet oder Erledigt
        /// </summary>
        public CheckBox CheckControl { get; set; }

    }
}
