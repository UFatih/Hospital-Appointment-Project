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
    public partial class HastaGirişEkranı : Form
    {
        public HastaGirişEkranı()
        {
            InitializeComponent();
        }

        sqlbaglantisi btn = new sqlbaglantisi();
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmÜyeKayıtEkranı frm = new FrmÜyeKayıtEkranı();
            frm.Show();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            SqlCommand btngiris = new SqlCommand("Select * From Tbl_Hastalar Where HastaTC=@p1 and HastaSifre=@p2", btn.baglanti());
            btngiris.Parameters.AddWithValue("@p1", mskdtcno.Text);
            btngiris.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader rdr = btngiris.ExecuteReader();
            if (rdr.Read())
            {
                HastaDetayEkranı hst = new HastaDetayEkranı();
                hst.tc = mskdtcno.Text;
                hst.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Hatalı TC veya Şifre");
            }
            btn.baglanti().Close();
        }

        private void HastaGirişEkranı_Load(object sender, EventArgs e)
        {

        }
    }
}
