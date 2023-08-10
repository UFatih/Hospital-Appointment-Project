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
    public partial class DoktorBilgiGnclle : Form
    {
        public DoktorBilgiGnclle()
        {
            InitializeComponent();
        }

        sqlbaglantisi btn = new sqlbaglantisi();

        public string tcno;
        private void DoktorBilgiGnclle_Load(object sender, EventArgs e)
        {
            mskdtcno.Text = tcno;
            SqlCommand kmt = new SqlCommand("Select * From Tbl_Doktorlar where DoktorTC=@p1", btn.baglanti());
            kmt.Parameters.AddWithValue("@p1", mskdtcno.Text);
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                txtad.Text = dr[1].ToString();
                txtsoyad.Text = dr[2].ToString();
                cmbbrans.Text = dr[3].ToString();                
                txtsifre.Text = dr[5].ToString();
            }

            btn.baglanti().Close();
        }

        private void btngnclle_Click(object sender, EventArgs e)
        {
            SqlCommand kmtt = new SqlCommand("Update Tbl_Doktorlar set DoktorAd=@p1, DoktorSoyad=@p2, DoktorBrans=@p3, DoktorSifre=@p4 where DoktorTC=@p5", btn.baglanti());
            kmtt.Parameters.AddWithValue("@p1", txtad.Text);
            kmtt.Parameters.AddWithValue("@p2", txtsoyad.Text);
            kmtt.Parameters.AddWithValue("@p3", cmbbrans.Text);
            kmtt.Parameters.AddWithValue("@p4", txtsifre.Text);
            kmtt.Parameters.AddWithValue("@p5", mskdtcno.Text);
            kmtt.ExecuteNonQuery();
            btn.baglanti().Close();
            MessageBox.Show("Kayıt Güncellenmiştir", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
