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
    public partial class SekreterGirişEkranı : Form
    {
        public SekreterGirişEkranı()
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
            SqlCommand sk = new SqlCommand("Select * From Tbl_Sekreter where SekreterTC=@p1 and SekreterSifre=@p2", btn.baglanti());
            sk.Parameters.AddWithValue("@p1", mskdtcno.Text);
            sk.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader dr = sk.ExecuteReader();
            if (dr.Read())
            {
                SekreterDetayEkranı frm = new SekreterDetayEkranı();
                frm.tcno = mskdtcno.Text;
                frm.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Hatalı TC veya Şifre", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            btn.baglanti().Close();
        }

        private void SekreterGirişEkranı_Load(object sender, EventArgs e)
        {

        }
    }
}
