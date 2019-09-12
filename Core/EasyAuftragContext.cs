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

using Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    /// <summary>
    /// Context-Klasse für das EntityFramework
    /// </summary>
    /// <remarks>
    /// Verweist das EntityFramework auf das <see cref="Model"/>, welches daraus die Tabellen für die Datenbank erstellt.
    /// Außerdem dient diese Klasse zur Interaktion (Anlegen/Bearbeiten/Löschen) von Einträgen in der Datenbank.
    /// </remarks>
    /// <seealso cref="DbContext"/>
    public class EasyAuftragContext:DbContext
    {
        /// <summary>
        /// Liste von Kunden, welche durch die von <see cref="DbContext"/> geerbten Methoden in die Datenbank geschrieben werden kann
        /// </summary>
        /// <seealso cref="Model.Kunde"/>
        public virtual DbSet<Kunde> Kunden { get; set; }

        /// <summary>
        /// Liste von Adressen, welche durch die von <see cref="DbContext"/> geerbten Methoden in die Datenbank geschrieben werden kann
        /// </summary>
        /// <seealso cref="Model.Adresse"/>
        public virtual DbSet<Adresse> Adressen { get; set; }

        /// <summary>
        /// Liste von Aufträgen, welche durch die von <see cref="DbContext"/> geerbten Methoden in die Datenbank geschrieben werden kann
        /// </summary>
        /// <seealso cref="Model.Auftrag"/>
        public virtual DbSet<Auftrag> Auftraege { get; set; }

        /// <summary>
        /// Liste von Mitarbeitern, welche durch die von <see cref="DbContext"/> geerbten Methoden in die Datenbank geschrieben werden kann
        /// </summary>
        /// <seealso cref="Model.Mitarbeiter"/>
        public virtual DbSet<Mitarbeiter> Mitarbeiters { get; set; }

        /// <summary>
        /// Liste von Tätigkeiten, welche durch die von <see cref="DbContext"/> geerbten Methoden in die Datenbank geschrieben werden kann
        /// </summary>
        /// <seealso cref="Model.Taetigkeit"/>
        public virtual DbSet<Taetigkeit> Taetigkeiten { get; set; }

        /// <summary>
        /// Konstruktor der Kontextklasse, verweist auf die zu verwendende Datenbank
        /// </summary>
        public EasyAuftragContext() : base("name=easyAuftrag.Properties.Settings.easyAuftragConnectionString")
        {

        }
    }
}
