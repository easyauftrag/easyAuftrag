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

using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyAuftrag.Logik
{
    /// <summary>
    /// Klasse zum Export von Daten in Dateien
    /// </summary>
    class Export
    {
        /// <summary>
        /// Methode zum Export einer Taetigkeitsliste in eine Datei
        /// </summary>
        /// <param name="taetigkeitsListe">Liste mit Tätigkeitsobjekten</param>
        /// <param name="zielPfad">Zielpfad für den Export der Datei</param>
        public void DateiSchreiben(List<Taetigkeit> taetigkeitsListe, string zielPfad)
        {

        }
    }
}