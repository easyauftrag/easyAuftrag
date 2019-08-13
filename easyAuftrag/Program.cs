using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyAuftrag
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Properties.Settings.Default.easyAuftragConnectionString = @"Data Source =" + SystemInformation.ComputerName.ToString() + @"\SQLEXPRESS; Initial Catalog = easyAuftrag; Integrated Security = True";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainView());
        }
    }
}
