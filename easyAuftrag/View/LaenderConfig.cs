using Core;
using Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyAuftrag.View
{
    public partial class LaenderConfig : Form
    {
        private Handler _handler = new Handler();
        private string _connection;
        public LaenderConfig(string connection)
        {
            _connection = connection;
            InitializeComponent();
            DataGridNeu();
        }

        private void DataGridNeu()
        {
            try
            {
                using (var db = new EasyAuftragContext(_connection))
                {
                    dgvLaender.DataSource = (from lnd in db.Laender select lnd).ToList();
                    dgvLaender.Columns["LandID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandle(ex);
            }
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            errProv.Clear();
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void butAbbrechen_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        private void butLand_Click(object sender, EventArgs e)
        {
            landNeu();
        }

        private void neuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            landNeu();
        }

        private void landNeu()
        {
            LaenderView laenderView = new LaenderView("Land anlegen", _connection);
            if (laenderView.ShowDialog() == DialogResult.OK)
            {
                _handler.LandAnlegen(laenderView.LandInfo, _connection);
            }
            this.BringToFront();
            this.Activate();
            DataGridNeu();
        }

        private void bearbeitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvLaender.SelectedRows.Count > 0)
            {
                int landID = Convert.ToInt32(dgvLaender.SelectedRows[0].Cells["LandID"].Value);
                landBearbeiten(landID);
            }
            else if (dgvLaender.SelectedCells.Count > 0)
            {
                int landID = Convert.ToInt32(dgvLaender.SelectedCells[0].OwningRow.Cells["LandID"].Value);
                landBearbeiten(landID);
            }
        }

        private void landBearbeiten(int landID)
        {
            if (landID < 12)
            {
                errProv.SetError(dgvLaender, "Dieses Land kann nicht bearbeitet werden.");
            }
            else
            {
                LaenderView laenderV = new LaenderView("Land Bearbeiten", _handler.LandLaden(landID, out bool success, _connection), _connection);
                if (success == false)
                {
                    MessageBox.Show("Land nicht in der Datenbank gefunden");
                }
                else if (laenderV.ShowDialog() == DialogResult.OK)
                {
                    if (!_handler.LandBearbeiten(laenderV.LandInfo, landID, _connection))
                    {
                        MessageBox.Show("Land nicht in der Datenbank gefunden");
                    }
                }
                this.BringToFront();
                this.Activate();
                DataGridNeu();
            }
        }

        private void loeschenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvLaender.SelectedRows.Count > 0)
            {
                int landID = Convert.ToInt32(dgvLaender.SelectedRows[0].Cells["LandID"].Value);
                landLoeschen(landID);
            }
            else if (dgvLaender.SelectedCells.Count > 0)
            {
                int landID = Convert.ToInt32(dgvLaender.SelectedCells[0].OwningRow.Cells["LandID"].Value);
                landLoeschen(landID);
            }
        }

        private void landLoeschen(int landID)
        {
            if (landID < 12)
            {
                errProv.SetError(dgvLaender, "Dieses Land kann nicht gelöscht werden.");
            }
            else
            {
                LaenderView laenderV = new LaenderView("Land Löschen", _handler.LandLaden(landID, out bool success, _connection), _connection);
                if (success == false)
                {
                    MessageBox.Show("Land nicht in der Datenbank gefunden");
                }
                else if (laenderV.ShowDialog() == DialogResult.OK)
                {
                    if (!_handler.LandLoeschen(landID, _connection))
                    {
                        MessageBox.Show("Land nicht in der Datenbank gefunden");
                    }
                }
                this.BringToFront();
                this.Activate();
                DataGridNeu();
            }
        }

        private void dgvLaender_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cxtLaender.Show(dgvLaender, e.X, e.Y);
            }
        }

        private void dgvLaender_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLaender.SelectedCells.Count > 0)
            {
                int landID = Convert.ToInt32(dgvLaender.SelectedCells[0].OwningRow.Cells["LandID"].Value);
                landBearbeiten(landID);
            }
        }

        private void dgvLaender_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int landID = Convert.ToInt32(dgvLaender.SelectedRows[0].Cells["LandID"].Value);
            landBearbeiten(landID);
        }
    }
}
