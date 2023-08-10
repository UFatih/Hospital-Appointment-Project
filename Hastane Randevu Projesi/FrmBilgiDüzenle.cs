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
    public partial class FrmBilgiDüzenle : Form
    {
        public FrmBilgiDüzenle()
        {
            InitializeComponent();
        }
        public string tcno;

        sqlbaglantisi btn = new sqlbaglantisi();
        private void FrmBilgiDüzenle_Load(object sender, EventArgs e)
        {
            mskdtcno.Text = tcno;
            SqlCommand kmt = new SqlCommand("Select * From Tbl_Hastalar where HastaTC=@k1", btn.baglanti());
            kmt.Parameters.AddWithValue("@k1", mskdtcno.Text);
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                txtad.Text = dr[1].ToString();
                txtsoyad.Text = dr[2].ToString();
                mskdtel.Text = dr[4].ToString();
                txtsifre.Text = dr[5].ToString();
                cmbcinsiyet.Text = dr[6].ToString();
            }
            btn.baglanti().Close();


        }

        private void btndüzenle_Click(object sender, EventArgs e)
        {
            SqlCommand kmt2 = new SqlCommand("Update Tbl_Hastalar set HastaAd=@a1, HastaSoyad=@a2, HastaTelefon=@a3, HastaSifre=@a4, HastaCinsiyet=@a5 where HastaTC=@a6", btn.baglanti());
            kmt2.Parameters.AddWithValue("@a1", txtad.Text);
            kmt2.Parameters.AddWithValue("@a2", txtsoyad.Text);
            kmt2.Parameters.AddWithValue("@a3", mskdtel.Text);
            kmt2.Parameters.AddWithValue("@a4", txtsifre.Text);
            kmt2.Parameters.AddWithValue("@a5", cmbcinsiyet.Text);
            kmt2.Parameters.AddWithValue("@a6", mskdtcno.Text);
            kmt2.ExecuteNonQuery();
            btn.baglanti().Close();
            MessageBox.Show("Bilgileriniz düzenlenmiştir.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            
        }

        
    }
}
