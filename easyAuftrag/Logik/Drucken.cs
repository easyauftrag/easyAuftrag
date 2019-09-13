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
        DruckDoc _druckDoc = new DruckDoc();
        StundenDoc _stundenDoc = new StundenDoc();

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
            //Test
            XmlPrintMapperAuftrag mapper = LoadPrintMappings();

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

            foreach (var item in mapper.TatList)
            {
                string mitarbeiter = (from i in _druckDoc.MitList where t.MitarbeiterID == i.MitarbeiterID select i.Name).First();

                switch (item.Name)
                {
                    // TODO fertig einbauen
                    case
                        break;
                }
                e.Graphics.DrawString(t.Datum.ToShortDateString(), font, Brushes.Black, 20, y, StringFormat.GenericTypographic);
                e.Graphics.DrawString(mitarbeiter, font, Brushes.Black, 45, y, StringFormat.GenericTypographic);
                e.Graphics.DrawString(t.Name, font, Brushes.Black, 75, y, StringFormat.GenericTypographic);
                e.Graphics.DrawString(t.StartZeit.ToString(), font, Brushes.Black, 155, y, StringFormat.GenericTypographic);
                e.Graphics.DrawString(t.EndZeit.ToString(), font, Brushes.Black, 170, y, StringFormat.GenericTypographic);
                e.Graphics.DrawString( Math.Round(t.Minuten / 60, 1).ToString(), font, Brushes.Black, 185, y, StringFormat.GenericTypographic);

                y += mapper.Inc;
            }
        }

        private XmlPrintMapperAuftrag LoadPrintMappings()
        {
            string path = Path.Combine(Application.StartupPath, "Print");
            path = Path.Combine(path, "PrintAuftrag.xml");

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
            Config conf = new Config();
            conf.StundenSoll = 40;
            string stringToPrint = "Example";
            int charactersOnPage = 0;
            int linesPerPage = 0;
            Font font = new Font(FontFamily.GenericSansSerif, 10.0F, FontStyle.Regular);
            
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;

            e.Graphics.MeasureString(stringToPrint, font, e.MarginBounds.Size, StringFormat.GenericTypographic, out charactersOnPage, out linesPerPage);

            e.Graphics.DrawString(_stundenDoc.Mitarbeiter.Name, font, Brushes.Black, 60, 30, StringFormat.GenericTypographic);
            e.Graphics.DrawString(_stundenDoc.Anfang.ToString(), font, Brushes.Black, 60, 45, StringFormat.GenericTypographic);
            e.Graphics.DrawString(_stundenDoc.Ende.ToString(), font, Brushes.Black, 60, 60, StringFormat.GenericTypographic);
            e.Graphics.DrawString((_stundenDoc.Mitarbeiter.AuslastungStelle / 100 * conf.StundenSoll).ToString(), font, Brushes.Black, 60, 75, StringFormat.GenericTypographic);
            e.Graphics.DrawString(Berechnung.ArbeitsZeit(_stundenDoc).ToString(), font, Brushes.Black, 60, 90, StringFormat.GenericTypographic);

            int y = 115;
            foreach (Taetigkeit t in _stundenDoc.Tatlist)
            {
                e.Graphics.DrawString(t.Datum.ToShortDateString(), font, Brushes.Black, 20, y, StringFormat.GenericTypographic);
                e.Graphics.DrawString(_stundenDoc.Mitarbeiter.Name, font, Brushes.Black, 45, y, StringFormat.GenericTypographic);
                e.Graphics.DrawString(t.Name, font, Brushes.Black, 75, y, StringFormat.GenericTypographic);
                e.Graphics.DrawString(t.StartZeit.ToString(), font, Brushes.Black, 155, y, StringFormat.GenericTypographic);
                e.Graphics.DrawString(t.EndZeit.ToString(), font, Brushes.Black, 170, y, StringFormat.GenericTypographic);
                e.Graphics.DrawString(Math.Round(t.Minuten / 60, 1).ToString(), font, Brushes.Black, 185, y, StringFormat.GenericTypographic);

                y += 6;
            }

            stringToPrint = stringToPrint.Substring(charactersOnPage);

            e.HasMorePages = (stringToPrint.Length > 0);
        }
    }
}
