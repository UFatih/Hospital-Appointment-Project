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
    public partial class DoktorGirişEkranı : Form
    {
        public DoktorGirişEkranı()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmÜyeKayıtEkranı frmuye = new FrmÜyeKayıtEkranı();
            frmuye.Show();

        }


        sqlbaglantisi btn = new sqlbaglantisi();

        private void btnlogin_Click(object sender, EventArgs e)
        {
            SqlCommand kmt = new SqlCommand("Select * From Tbl_Doktorlar where DoktorTC=@p1 and DoktorSifre= @p2", btn.baglanti());
            kmt.Parameters.AddWithValue("@p1", mskdtcno.Text);
            kmt.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader dr = kmt.ExecuteReader();

            if (dr.Read())
            {
                DoktorDetayEkranı frmd = new DoktorDetayEkranı();
                frmd.tc = mskdtcno.Text;
                frmd.Show();
                this.Hide();
                
            }

            else
            {
                MessageBox.Show("Hatalı TC veya Şifre", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            btn.baglanti().Close();
        }

        private void DoktorGirişEkranı_Load(object sender, EventArgs e)
        {

        }
    }
}
