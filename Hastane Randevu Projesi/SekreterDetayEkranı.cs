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
    public partial class SekreterDetayEkranı : Form
    {
        public SekreterDetayEkranı()
        {
            InitializeComponent();
        }

        sqlbaglantisi btn = new sqlbaglantisi();

        public string tcno;
        private void SekreterDetayEkranı_Load(object sender, EventArgs e)
        {
            lbltcno.Text = tcno;

            // Ad Soyad

            SqlCommand kmt = new SqlCommand("Select SekreterAdSoyad From Tbl_Sekreter where SekreterTC=@s1 ", btn.baglanti());
            kmt.Parameters.AddWithValue("@s1", lbltcno.Text);
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                lbladsoyad.Text = dr[0].ToString();
            }

            btn.baglanti().Close();

            //Branşları Datagride Aktarma
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Branslar", btn.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource = dt;

            //Doktorları Listeye Aktarma
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select (DoktorAd + ' ' + DoktorSoyad) as 'Doktorlar', DoktorBrans From Tbl_Doktorlar", btn.baglanti());
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;

            //Branşı Comboboxa Aktarma
            SqlCommand kmtt = new SqlCommand("Select BransAd From Tbl_Branslar",btn.baglanti());
            SqlDataReader rdr = kmtt.ExecuteReader();
            while (rdr.Read())
            {
                cmbbrans.Items.Add(rdr[0]);
            }
      

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand kmt = new SqlCommand("insert into Tbl_Randevuu (RandevuTarih, RandevuSaat, RandevuBrans, RandevuDoktor) values (@r1, @r2, @r3, @r4)", btn.baglanti());
            kmt.Parameters.AddWithValue("@r1", mskdtarih.Text);
            kmt.Parameters.AddWithValue("@r2", mskdsaat.Text);
            kmt.Parameters.AddWithValue("@r3", cmbbrans.Text);
            kmt.Parameters.AddWithValue("@r4", cmbdoktor.Text);            
            kmt.ExecuteNonQuery();
            btn.baglanti().Close();
            MessageBox.Show("Randevunuz Oluşturulmuştur");
        }

        private void cmbbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbdoktor.Items.Clear();

            SqlCommand kmtt2 = new SqlCommand("Select DoktorAd, DoktorSoyad From Tbl_Doktorlar where DoktorBrans=@p1", btn.baglanti());
            kmtt2.Parameters.AddWithValue("@p1", cmbbrans.Text);
            SqlDataReader rdr2 = kmtt2.ExecuteReader();
            while (rdr2.Read())
            {
                cmbdoktor.Items.Add(rdr2[0] + " " + rdr2[1]);
            }

            btn.baglanti().Close();
        }

        private void btnoluştur_Click(object sender, EventArgs e)
        {
            SqlCommand dyr = new SqlCommand("Insert into Tbl_Duyuruu (Duyuru)  values (@d1) ", btn.baglanti());
            dyr.Parameters.AddWithValue("@d1", rchduyuru.Text);
            dyr.ExecuteNonQuery();
            btn.baglanti().Close();
            MessageBox.Show("Duyuru Oluşturulmuştur", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btndokpnl_Click(object sender, EventArgs e)
        {
            DoktorEkleSilPaneli dktr = new DoktorEkleSilPaneli();
            dktr.Show();
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand kmt = new SqlCommand("Update Tbl_Randevuu set RandevuTarih=@r1, RandevuSaat=@r2, RandevuBrans=@r3, RandevuDoktor=@r4 where RndHastaTC=@r5", btn.baglanti());
            kmt.Parameters.AddWithValue("@r1", mskdtarih.Text);
            kmt.Parameters.AddWithValue("@r2", mskdsaat.Text);
            kmt.Parameters.AddWithValue("@r3", cmbbrans.Text);
            kmt.Parameters.AddWithValue("@r4", cmbdoktor.Text);
            kmt.Parameters.AddWithValue("@r5", mskdtc.Text);
            kmt.ExecuteNonQuery();
            btn.baglanti().Close();
            MessageBox.Show("Randevunuz Güncellenmiştir");
        }

        private void btnbrapnl_Click(object sender, EventArgs e)
        {
            FrmBranş frm = new FrmBranş();
            frm.Show();
        }

        private void btnçıkış_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       

        private void btbnduyuru_Click(object sender, EventArgs e)
        {
            FrmDuyurular frm = new FrmDuyurular();
            frm.Show();
        }

        private void btnrandevu_Click(object sender, EventArgs e)
        {
            FrmRandevu frm = new FrmRandevu();
            frm.Show();

        }
    }
}
