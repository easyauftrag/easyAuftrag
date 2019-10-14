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
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;

namespace easyAuftrag.View
{
    public partial class ConfigView : Form
    {
        public Config Conf { get; set; }

        public ConfigView()
        {
            Conf = new Config();
            InitializeComponent();
            if (rdbWin.Checked)
            {
                tbUser.Enabled = false;
                tbPW.Enabled = false;
            }
        }

        private void ButExport_Click(object sender, EventArgs e)
        {
            if (fbdExport.ShowDialog() == DialogResult.OK)
            {
                tbExport.Text = fbdExport.SelectedPath;
            }
        }

        private void ButServer_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataSourceEnumerator enumerator = SqlDataSourceEnumerator.Instance;
                DataTable serverTable = enumerator.GetDataSources();

                // Verfügbare Instanzen sammeln
                foreach (DataRow row in serverTable.Rows)
                {
                    string serverName = row["ServerName"].ToString();

                    if (row["InstanceName"] != DBNull.Value)
                    {
                        serverName += "\\" + row["InstanceName"];
                    }

                    cmbServer.Items.Add(serverName);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        private void ButDB_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cmbServer.Text))
                {
                    string con = "Data Source=" + cmbServer.Text + ";Initial Catalog=MASTER;Integrated Security=True;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                    string sql = "SELECT name FROM sys.databases";

                    DataSet data = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                    adapter.Fill(data);

                    foreach (DataRow row in data.Tables[0].Rows)
                    {
                        cmbDB.Items.Add(row[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        private void RdbSQL_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSQL.Checked)
            {
                tbUser.Enabled = true;
                tbPW.Enabled = true;
            }
        }

        private void RdbWin_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbWin.Checked)
            {
                tbUser.Enabled = false;
                tbPW.Enabled = false;
            }
        }

        private void ButOK_Click(object sender, EventArgs e)
        {
            errorInfo.Clear();
            FillConfig();
            if (errorInfo.GetError(tbSoll) == "")
            {
                Conf.SchreibeXML();
                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
            else
            {
                this.BringToFront();
                this.Activate();
            }
            
        }

        private void FillConfig()
        {
            if (double.TryParse(tbSoll.Text, out double soll))
            {
                Conf.StundenSoll = soll;
            }
            else
            {
                errorInfo.SetError(tbSoll, "Bitte korrekten Stundensoll eingeben!");
            }
            Conf.StandardZielPfad = tbExport.Text;
            Conf.Server = cmbServer.Text;
            Conf.WinAuth = rdbWin.Checked;
            Conf.BenutzerName = tbUser.Text;
            Conf.Passwort = tbPW.Text;
            Conf.Datenbank = cmbDB.Text;
        }

        private void ButAbbr_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }
    }
}
