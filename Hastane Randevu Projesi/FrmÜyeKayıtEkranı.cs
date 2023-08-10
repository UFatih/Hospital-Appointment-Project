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
    public partial class FrmÜyeKayıtEkranı : Form
    {
        public FrmÜyeKayıtEkranı()
        {
            InitializeComponent();
        }

        sqlbaglantisi btn = new sqlbaglantisi();

        private void btnolustur_Click(object sender, EventArgs e)
        {
            SqlCommand btnolustur = new SqlCommand("insert into Tbl_Hastalar (HastaAd, HastaSoyad, HastaTC, HastaTelefon, HastaSifre, HastaCinsiyet) values (@h1, @h2, @h3, @h4, @h5, @h6)", btn.baglanti());
            btnolustur.Parameters.AddWithValue("@h1", txtad.Text);
            btnolustur.Parameters.AddWithValue("@h2", txtsoyad.Text);
            btnolustur.Parameters.AddWithValue("@h3", mskdtcno.Text);
            btnolustur.Parameters.AddWithValue("@h4", mskdtelno.Text);
            btnolustur.Parameters.AddWithValue("@h5", txtsifre.Text);
            btnolustur.Parameters.AddWithValue("@h6", cmbcinsiyet.Text);
            btnolustur.ExecuteNonQuery();
            btn.baglanti().Close();
            MessageBox.Show("Kaydınız başarılı bir şekilde oluşturulmuştur", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmÜyeKayıtEkranı_Load(object sender, EventArgs e)
        {

        }
    }
}
