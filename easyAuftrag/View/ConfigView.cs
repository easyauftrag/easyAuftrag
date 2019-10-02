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
        private Config _config = new Config();

        public ConfigView()
        {
            InitializeComponent();
            if (rdbWin.Checked)
            {
                tbUser.Enabled = false;
                tbPW.Enabled = false;
            }
        }

        private void butExport_Click(object sender, EventArgs e)
        {
            if (fbdExport.ShowDialog() == DialogResult.OK)
            {
                tbExport.Text = fbdExport.SelectedPath;
            }
        }

        private void butServer_Click(object sender, EventArgs e)
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

        private void butDB_Click(object sender, EventArgs e)
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

        private void rdbSQL_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSQL.Checked)
            {
                tbUser.Enabled = true;
                tbPW.Enabled = true;
            }
        }

        private void rdbWin_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbWin.Checked)
            {
                tbUser.Enabled = false;
                tbPW.Enabled = false;
            }
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            FillConfig();
            _config.SchreibeXML();

            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void FillConfig()
        {
            _config.StundenSoll = Convert.ToDouble(tbSoll.Text);
            _config.StandardZielPfad = tbExport.Text;
            _config.Server = cmbServer.Text;
            _config.WinAuth = rdbWin.Checked;
            _config.BenutzerName = tbUser.Text;
            _config.Passwort = tbPW.Text;
            _config.Datenbank = cmbDB.Text;
        }

        private void butAbbr_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }
    }
}
