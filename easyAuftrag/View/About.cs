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
