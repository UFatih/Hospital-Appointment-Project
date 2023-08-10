using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hastane_Randevu_Projesi
{
    public partial class GirişEkranı : Form
    {
        public GirişEkranı()
        {
            InitializeComponent();
        }

        private void visionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("In the light of excellence-oriented, managerial, scientific and technological developments in health service delivery; To be the exemplary hospital of our region, which provides reliable service at national and international standards, with its determination to increase patient and employee safety and satisfaction, which supports continuous change and development with continuous education.", "Vision", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void missionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("With the belief and understanding that a healthy life is the fundamental right of all people, it is to provide quality, equal, friendly service that prioritizes satisfaction with its experienced and trained personnel, in accordance with ethical, scientific norms and offering the latest technologies.", "Mission", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Red;
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Green;
        }

        private void brownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Brown;
        }

        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkCyan;
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Blue;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnhastagiris_Click(object sender, EventArgs e)
        {
            HastaGirişEkranı hst = new HastaGirişEkranı();
            hst.Show();
            this.Hide();

        }

        private void btndoktorgiris_Click(object sender, EventArgs e)
        {
            DoktorGirişEkranı dktr = new DoktorGirişEkranı();
            dktr.Show();
            this.Hide();
        }

        private void btnsekretergiris_Click(object sender, EventArgs e)
        {
            SekreterGirişEkranı skrt = new SekreterGirişEkranı();
            skrt.Show();
            this.Hide();
        }

        private void GirişEkranı_Load(object sender, EventArgs e)
        {

        }
    }
}
