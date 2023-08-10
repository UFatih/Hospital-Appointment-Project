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
    public partial class HastaDetayEkranı : Form
    {
        public HastaDetayEkranı()
        {
            InitializeComponent();
        }
        sqlbaglantisi btn = new sqlbaglantisi();
        public string tc;
        private void HastaDetayEkranı_Load(object sender, EventArgs e)
        {
            //AdSoyad Alma
            lbltcno.Text = tc;
            SqlCommand hstdty = new SqlCommand("Select HastaAd, HastaSoyad From Tbl_Hastalar where HastaTC=@p1", btn.baglanti());
            hstdty.Parameters.AddWithValue("@p1", tc);
            SqlDataReader rdr = hstdty.ExecuteReader();
            while (rdr.Read())
            {
                lbladsoyad.Text = rdr[0] + " " + rdr[1];
            }
            btn.baglanti().Close();

            //Branş Alma
            SqlCommand hstdty2 = new SqlCommand("Select BransAd From Tbl_Branslar", btn.baglanti());
            SqlDataReader rdr2 = hstdty2.ExecuteReader();
            while (rdr2.Read())
            {
                cmbbrans.Items.Add(rdr2[0]);
            }
            btn.baglanti().Close();

            //Randevu Geçmişi
            DataTable dtb = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter("Select * From Tbl_Randevuu where RndHastaTC=" + tc, btn.baglanti());
            adp.Fill(dtb);
            dataGridView1.DataSource =dtb;




        }

        private void cmbbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbdoktor.Items.Clear();

            SqlCommand sql = new SqlCommand("Select DoktorAd,DoktorSoyad From Tbl_Doktorlar where DoktorBrans=@d1", btn.baglanti());
            sql.Parameters.AddWithValue("@d1", cmbbrans.Text);
            SqlDataReader dr = sql.ExecuteReader();
            while (dr.Read())
            {
                cmbdoktor.Items.Add(dr[0] + " " + dr[1]);
            }
            btn.baglanti().Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBilgiDüzenle frm = new FrmBilgiDüzenle();
            frm.tcno = lbltcno.Text;
            frm.Show();
        }

        private void cmbdoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sql = new SqlDataAdapter("Select * From Tbl_Randevuu where RandevuBrans= '" + cmbbrans.Text + "'" + " and RandevuDoktor='" + cmbdoktor.Text + "' and RandevuDurum=0", btn.baglanti());
            sql.Fill(dt);
            dataGridView2.DataSource = dt;

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int sec = dataGridView2.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView2.Rows[sec].Cells[0].Value.ToString();
            
        }

        private void btnrandevu_Click(object sender, EventArgs e)
        {
            SqlCommand kmt = new SqlCommand("Update Tbl_Randevuu Set RandevuDurum=1, RndHastaTC=@p1, HastaSikayet=@p2 where Randevuid=@p3", btn.baglanti());
            kmt.Parameters.AddWithValue("@p1", lbltcno.Text);
            kmt.Parameters.AddWithValue("@p2", rchsikayet.Text);
            kmt.Parameters.AddWithValue("@p3", txtid.Text);
            kmt.ExecuteNonQuery();
            btn.baglanti().Close();
            MessageBox.Show("Randevu Alınmıştır", "Info", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }
    }
}
