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
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyAuftrag.View
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            string path = Path.Combine(Application.StartupPath, "LICENSE.txt");
            var link = new LinkLabel.Link();
            link.LinkData = path;
            linkLicense.Links.Add(link);
            
            labVersion.Text = "Version: " + Application.ProductVersion + "\n"
                + "Entwickelt von: " + Application.CompanyName + "\n";

            labBoxDLL.Items.Add(typeof(Core.Handler).Assembly.GetName().Name + " " + typeof(Core.Handler).Assembly.GetName().Version);
            labBoxDLL.Items.Add(typeof(Austausch.AustauschCSV).Assembly.GetName().Name + " " + typeof(Austausch.AustauschCSV).Assembly.GetName().Version);
        }

        private void linkLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = (string)linkLicense.Links[0].LinkData;
            process.Start();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
