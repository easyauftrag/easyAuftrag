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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyAuftrag.Logik
{
    /// <summary>
    /// Klasse zum Drucken von Aufträgen
    /// </summary>
    public class Drucken
    {
        DruckDoc _druckDoc = new DruckDoc();
        StundenDoc _stundenDoc = new StundenDoc();
        public Drucken()
        {

        }

        public void Druck(DruckDoc druckDoc)
        {
            _druckDoc = druckDoc;
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += printDocument_PrintPage;

            //PrintPreviewDialog printPreview = new PrintPreviewDialog();
            //printPreview.Document = printDocument;
            //printPreview.ShowDialog();

            PrintDialog dlgPrinter = new PrintDialog();
            dlgPrinter.Document = doc;

            if (dlgPrinter.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }
        }

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
        
        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;

            int charactersOnPage = 0;
            int linesPerPage = 0;
            Font font = new Font(FontFamily.GenericSansSerif,10.0F, FontStyle.Regular);
            string stringToPrint = "Example";

            e.Graphics.MeasureString(stringToPrint, font, e.MarginBounds.Size, StringFormat.GenericTypographic, out charactersOnPage, out linesPerPage);

            e.Graphics.DrawString(_druckDoc.AuftragNr, font, Brushes.Black, 124, 60, StringFormat.GenericTypographic);
            e.Graphics.DrawString(_druckDoc.KundeName, font, Brushes.Black, 50, 75, StringFormat.GenericTypographic);
            e.Graphics.DrawString(_druckDoc.KundeAnschrift, font, Brushes.Black, 45, 82, StringFormat.GenericTypographic);
            e.Graphics.DrawString(_druckDoc.KundeTelefon, font, Brushes.Black, 160, 82, StringFormat.GenericTypographic);
            int y = 115;
            foreach (Taetigkeit t in _druckDoc.TatListe)
            {
                

                string mitarbeiter = (from i in _druckDoc.MitList where t.MitarbeiterID == i.MitarbeiterID select i.Name).First();

                e.Graphics.DrawString(t.Datum.ToShortDateString(), font, Brushes.Black, 20, y, StringFormat.GenericTypographic);
                e.Graphics.DrawString(mitarbeiter, font, Brushes.Black, 45, y, StringFormat.GenericTypographic);
                e.Graphics.DrawString(t.Name, font, Brushes.Black, 75, y, StringFormat.GenericTypographic);
                e.Graphics.DrawString(t.StartZeit.ToString(), font, Brushes.Black, 155, y, StringFormat.GenericTypographic);
                e.Graphics.DrawString(t.EndZeit.ToString(), font, Brushes.Black, 170, y, StringFormat.GenericTypographic);
                e.Graphics.DrawString( Math.Round(t.Minuten / 60, 1).ToString(), font, Brushes.Black, 185, y, StringFormat.GenericTypographic);

                y += 6;
            }
            
            stringToPrint = stringToPrint.Substring(charactersOnPage);

            e.HasMorePages = (stringToPrint.Length > 0);
        }
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
