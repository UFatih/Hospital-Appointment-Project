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
    public partial class DoktorDetayEkranı : Form
    {
        public DoktorDetayEkranı()
        {
            InitializeComponent();
        }

        sqlbaglantisi btn = new sqlbaglantisi();

        public string tc;
        private void btnçıkış_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DoktorDetayEkranı_Load(object sender, EventArgs e)
        {
            //AdSoyad Alma
            lbltcno.Text = tc;
            SqlCommand drdty = new SqlCommand("Select DoktorAd, DoktorSoyad From Tbl_Doktorlar where DoktorTC=@p1", btn.baglanti());
            drdty.Parameters.AddWithValue("@p1", tc);
            SqlDataReader rdr = drdty.ExecuteReader();
            while (rdr.Read())
            {
                lbladsoyad.Text = rdr[0] + " " + rdr[1];
            }
            btn.baglanti().Close();

            //Randevular 
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevuu where RandevuDoktor='" + lbladsoyad.Text + "'", btn.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnguncll_Click(object sender, EventArgs e)
        {
            DoktorBilgiGnclle dktr = new DoktorBilgiGnclle();
            dktr.tcno = lbltcno.Text;
            dktr.Show();
        }

        private void btnduyru_Click(object sender, EventArgs e)
        {
            FrmDuyurular frm = new FrmDuyurular();
            frm.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int sec = dataGridView1.SelectedCells[0].RowIndex;
            rchsikayet.Text = dataGridView1.Rows[sec].Cells[0].Value.ToString();
        }
    }
}
