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
    /// <summary>
    /// Windows Form mit DataGridView zum Anzeigen der Länder
    /// </summary>
    public partial class LaenderConfig : Form
    {
        /// <summary>
        /// Handler-Instanz zum anlegen, bearbeiten und löschen von Ländern
        /// </summary>
        private Handler _handler = new Handler();
        /// <summary>
        /// Connection String für die Verbindung mit der Datenbank
        /// </summary>
        private string _connection;

        /// <summary>
        /// Erzeugt eine neue Instanz der LaenderConfig Form
        /// </summary>
        /// <param name="connection">Connection String zur Verbindung mit der Datenbank</param>
        public LaenderConfig(string connection)
        {
            _connection = connection;
            InitializeComponent();
            DataGridNeu();
        }

        /// <summary>
        /// Methode zum Aktualisieren des DataGridViews
        /// </summary>
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

        /// <summary>
        /// Aktion beim Klick auf den OK Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButOK_Click(object sender, EventArgs e)
        {
            errProv.Clear();
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        /// <summary>
        /// Aktion beim Klick auf den "Land hinzufügen" Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButLand_Click(object sender, EventArgs e)
        {
            LandNeu();
        }

        /// <summary>
        /// Aktion beim Klick auf das Contextmenü Eintrag "Neu"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NeuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LandNeu();
        }

        /// <summary>
        /// Methode zum Aufruf des "Land anlegen" Dialogs
        /// </summary>
        private void LandNeu()
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

        /// <summary>
        /// Aktion beim Klick auf das Contextmenü Eintrag "Bearbeiten"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BearbeitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvLaender.SelectedRows.Count > 0)
            {
                int landID = Convert.ToInt32(dgvLaender.SelectedRows[0].Cells["LandID"].Value);
                LandBearbeiten(landID);
            }
            else if (dgvLaender.SelectedCells.Count > 0)
            {
                int landID = Convert.ToInt32(dgvLaender.SelectedCells[0].OwningRow.Cells["LandID"].Value);
                LandBearbeiten(landID);
            }
        }

        /// <summary>
        /// Methode zum Aufruf des "Land bearbeiten" Dialogs
        /// </summary>
        private void LandBearbeiten(int landID)
        {
            if (landID < 12)
            {
                errProv.SetError(dgvLaender, "Dieses Land kann nicht bearbeitet werden.");
            }
            else
            {
                LaenderView laenderV = new LaenderView("Land bearbeiten", _handler.LandLaden(landID, out bool success, _connection), _connection);
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

        /// <summary>
        /// Aktion beim Klick auf das Contextmenü Eintrag "Löschen"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoeschenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvLaender.SelectedRows.Count > 0)
            {
                int landID = Convert.ToInt32(dgvLaender.SelectedRows[0].Cells["LandID"].Value);
                LandLoeschen(landID);
            }
            else if (dgvLaender.SelectedCells.Count > 0)
            {
                int landID = Convert.ToInt32(dgvLaender.SelectedCells[0].OwningRow.Cells["LandID"].Value);
                LandLoeschen(landID);
            }
        }

        /// <summary>
        /// Methode zum Aufruf des "Land löschen" Dialogs
        /// </summary>
        /// <param name="landID"></param>
        private void LandLoeschen(int landID)
        {
            if (landID < 12)
            {
                errProv.SetError(dgvLaender, "Dieses Land kann nicht gelöscht werden.");
            }
            else
            {
                LaenderView laenderV = new LaenderView("Land löschen", _handler.LandLaden(landID, out bool success, _connection), _connection);
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

        /// <summary>
        /// Aktion beim Klick auf das DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvLaender_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cxtLaender.Show(dgvLaender, e.X, e.Y);
            }
        }

        /// <summary>
        /// Aktion beim Doppelklick in eine Zelle des DataGridViews
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvLaender_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLaender.SelectedCells.Count > 0)
            {
                int landID = Convert.ToInt32(dgvLaender.SelectedCells[0].OwningRow.Cells["LandID"].Value);
                LandBearbeiten(landID);
            }
        }

        /// <summary>
        /// Aktion beim Doppelklick auf einen RowHeader des DataGridViews
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvLaender_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int landID = Convert.ToInt32(dgvLaender.SelectedRows[0].Cells["LandID"].Value);
            LandBearbeiten(landID);
        }
    }
}
