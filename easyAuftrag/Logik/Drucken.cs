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

using Core;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace easyAuftrag.Logik
{
    /// <summary>
    /// Klasse zum Drucken von Aufträgen
    /// </summary>
    public class Drucken
    {
        private DruckDoc _druckDoc = new DruckDoc();
        private StundenDoc _stundenDoc = new StundenDoc();

        /// <summary>
        /// Konstruktor für die <see cref="Drucken"/> Klasse
        /// </summary>
        public Drucken()
        {

        }

        /// <summary>
        /// Methode zum Drucken eines Auftrags (--> <see cref="Core.Model.DruckDoc"/>)
        /// durch <see cref="printDocument_PrintPage"/>
        /// </summary>
        public void Druck(DruckDoc druckDoc)
        {
            _druckDoc = druckDoc;
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += printDocument_PrintPage;

            PrintDialog dlgPrinter = new PrintDialog();
            dlgPrinter.Document = doc;

            if (dlgPrinter.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }
        }

        /// <summary>
        /// Methode zum Drucken der Sollstunden und geleisteten Stunden eines Mitarbeiters (--> <see cref="Core.Model.StundenDoc"/>)
        /// durch <see cref="printDocument_PrintStunden"/>
        /// </summary>
        public void StundenDruck(StundenDoc stundenDoc)
        {
            _stundenDoc = stundenDoc;
            PrintDocument doc = new PrintDocument();

            doc.PrintPage += printDocument_PrintStunden;

            PrintDialog dlgPrinter = new PrintDialog();
            dlgPrinter.Document = doc;

            if (dlgPrinter.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }
        }

        /// <summary>
        /// Methode, die das Layout zum Drucken eines Auftrags (--> <see cref="Core.Model.DruckDoc"/>) festlegt
        /// </summary>
        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            XmlPrintMapperAuftrag mapper = LoadPrintMappings("Auftrag");

            e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            
            Font font = new Font(FontFamily.GenericSansSerif,10.0F, FontStyle.Regular);
            
            foreach (var item in mapper.MappingList)
            {
                switch (item.Name)
                {
                    case "AuftragNr":
                        e.Graphics.DrawString(_druckDoc.AuftragNr, font, Brushes.Black, item.X, item.Y, StringFormat.GenericTypographic);
                        break;
                    case "KundeName":
                        e.Graphics.DrawString(_druckDoc.KundeName, font, Brushes.Black, item.X, item.Y, StringFormat.GenericTypographic);
                        break;
                    case "KundeAnschrift":
                        e.Graphics.DrawString(_druckDoc.KundeAnschrift, font, Brushes.Black, item.X, item.Y, StringFormat.GenericTypographic);
                        break;
                    case "KundeTelefon":
                        e.Graphics.DrawString(_druckDoc.KundeTelefon, font, Brushes.Black, item.X, item.Y, StringFormat.GenericTypographic);
                        break;
                }
            }
            
            int y = mapper.Start;

            foreach (Taetigkeit t in _druckDoc.TatListe)
            {
                foreach (var item in mapper.TatList)
                {
                    string mitarbeiter = (from i in _druckDoc.MitList
                                          where i.MitarbeiterID == t.MitarbeiterID
                                          select i.Name).First();

                    switch (item.Name)
                    {
                        case "Datum":
                            e.Graphics.DrawString(t.Datum.ToShortDateString(), font, Brushes.Black, item.X, y, StringFormat.GenericTypographic);
                            break;
                        case "Mitarbeiter":
                            e.Graphics.DrawString(mitarbeiter, font, Brushes.Black, item.X, y, StringFormat.GenericTypographic);
                            break;
                        case "Beschreibung":
                            e.Graphics.DrawString(t.Name, font, Brushes.Black, item.X, y, StringFormat.GenericTypographic);
                            break;
                        case "StartZeit":
                            e.Graphics.DrawString(t.StartZeit.ToString(), font, Brushes.Black, item.X, y, StringFormat.GenericTypographic);
                            break;
                        case "EndZeit":
                            e.Graphics.DrawString(t.EndZeit.ToString(), font, Brushes.Black, item.X, y, StringFormat.GenericTypographic);
                            break;
                        case "Stunden":
                            e.Graphics.DrawString(Math.Round(t.Minuten / 60, 1).ToString(), font, Brushes.Black, item.X, y, StringFormat.GenericTypographic);
                            break;
                    }
                }
                y += mapper.Inc;
            }
        }

        private XmlPrintMapperAuftrag LoadPrintMappings(string art)
        {
            string path = Path.Combine(Application.StartupPath, "Print");
            path = Path.Combine(path, "Print" + art + ".xml");

            XmlDocument xml = new XmlDocument();
            xml.Load(path);

            XmlNodeList mappinglstXmlItems = xml.GetElementsByTagName("printitem");
            XmlNodeList tatlstXmlItems = xml.GetElementsByTagName("listitem");
            XmlPrintMapperAuftrag printMA = new XmlPrintMapperAuftrag();

            foreach (XmlNode node in mappinglstXmlItems)
            {
                PrintMapperItem printMI = new PrintMapperItem();
                printMI.Name = node.Attributes["name"].Value;
                printMI.X = Convert.ToInt32(node.Attributes["x"].Value);
                printMI.Y = Convert.ToInt32(node.Attributes["y"].Value);

                printMA.MappingList.Add(printMI);
            }
            foreach (XmlNode node in tatlstXmlItems)
            {
                PrintMapperTaetigkeit printMT = new PrintMapperTaetigkeit();
                printMT.Name = node.Attributes["name"].Value;
                printMT.X = Convert.ToInt32(node.Attributes["x"].Value);

                printMA.TatList.Add(printMT);
            }
            printMA.Start = Convert.ToInt32(xml.GetElementsByTagName("printlist").Item(0).Attributes["start"].Value);
            printMA.Inc = Convert.ToInt32(xml.GetElementsByTagName("printlist").Item(0).Attributes["inc"].Value);

            return printMA;
        }

        /// <summary>
        /// Methode, die das Layout zum Drucken der Sollstunden und geleisteten Stunden eines Mitarbeiters 
        /// (--> <see cref="Core.Model.StundenDoc"/>) festlegt
        /// </summary>
        private void printDocument_PrintStunden(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            XmlPrintMapperAuftrag mapper = LoadPrintMappings("Stunden");
            //TODO Config Datei erstellen, die Stundensoll enthält.
            Config conf = new Config();
            conf.StundenSoll = 40;
            Font font = new Font(FontFamily.GenericSansSerif, 10.0F, FontStyle.Regular);
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            foreach (var item in mapper.MappingList)
            {
                switch (item.Name)
                {
                    case "MitarbeiterName":
                        e.Graphics.DrawString(_stundenDoc.Mitarbeiter.Name, font, Brushes.Black, item.X, item.Y, StringFormat.GenericTypographic);
                        break;
                    case "Anfang":
                        e.Graphics.DrawString(_stundenDoc.Anfang.ToShortDateString(), font, Brushes.Black, item.X, item.Y, StringFormat.GenericTypographic);
                        break;
                    case "Ende":
                        e.Graphics.DrawString(_stundenDoc.Ende.ToShortDateString(), font, Brushes.Black, item.X, item.Y, StringFormat.GenericTypographic);
                        break;
                    case "Sollstunden":
                        e.Graphics.DrawString((_stundenDoc.Mitarbeiter.AuslastungStelle / 100 * conf.StundenSoll).ToString(), font, Brushes.Black, item.X, item.Y, StringFormat.GenericTypographic);
                        break;
                    case "Arbeitszeit":
                        e.Graphics.DrawString(Berechnung.ArbeitsZeit(_stundenDoc).ToString(), font, Brushes.Black, item.X, item.Y, StringFormat.GenericTypographic);
                        break;
                }
            }
            int y = mapper.Start;

            foreach (Taetigkeit t in _stundenDoc.Tatlist)
            {
                foreach (var item in mapper.TatList)
                {
                    switch (item.Name)
                    {
                        case "Datum":
                            e.Graphics.DrawString(t.Datum.ToShortDateString(), font, Brushes.Black, item.X, y, StringFormat.GenericTypographic);
                            break;
                        case "Mitarbeiter":
                            e.Graphics.DrawString(_stundenDoc.Mitarbeiter.Name, font, Brushes.Black, item.X, y, StringFormat.GenericTypographic);
                            break;
                        case "Beschreibung":
                            e.Graphics.DrawString(t.Name, font, Brushes.Black, item.X, y, StringFormat.GenericTypographic);
                            break;
                        case "StartZeit":
                            e.Graphics.DrawString(t.StartZeit.ToString(), font, Brushes.Black, item.X, y, StringFormat.GenericTypographic);
                            break;
                        case "EndZeit":
                            e.Graphics.DrawString(t.EndZeit.ToString(), font, Brushes.Black, item.X, y, StringFormat.GenericTypographic);
                            break;
                        case "Stunden":
                            e.Graphics.DrawString(Math.Round(t.Minuten / 60, 1).ToString(), font, Brushes.Black, item.X, y, StringFormat.GenericTypographic);
                            break;
                    }
                }
                y += mapper.Inc;
            }
        }
    }
}
