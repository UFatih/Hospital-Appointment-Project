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
    public partial class DoktorEkleSilPaneli : Form
    {
        public DoktorEkleSilPaneli()
        {
            InitializeComponent();
        }
        sqlbaglantisi btn = new sqlbaglantisi();
        private void DoktorEkleSilPaneli_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Doktorlar", btn.baglanti());
            da.Fill(dt);
            dataGridView11.DataSource = dt;

        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            SqlCommand kmt = new SqlCommand("Insert into Tbl_Doktorlar (DoktorAd, DoktorSoyad, DoktorBrans, DoktorTC, DoktorSifre) values (@d1, @d2, @d3, @d4, @d5)", btn.baglanti());
            kmt.Parameters.AddWithValue("@d1", txtad.Text);
            kmt.Parameters.AddWithValue("@d2", txtsoyad.Text);
            kmt.Parameters.AddWithValue("@d3", cmbbrans.Text);
            kmt.Parameters.AddWithValue("@d4", mskdtc.Text);
            kmt.Parameters.AddWithValue("@d5", txtsifre.Text);
            kmt.ExecuteNonQuery();
            btn.baglanti().Close();
            MessageBox.Show("Doktor Eklenmiştir", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand kmt2 = new SqlCommand("Delete From Tbl_Doktorlar where DoktorTc=@p1", btn.baglanti());
            kmt2.Parameters.AddWithValue("@p1", mskdtc.Text);
            kmt2.ExecuteNonQuery();
            btn.baglanti().Close();
            MessageBox.Show("Kayıt silinmiştir", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btngncle_Click(object sender, EventArgs e)
        {
            SqlCommand kmt3 = new SqlCommand("Update Tbl_Doktorlar set DoktorAd=@d1, DoktorSoyad=@d2, DoktorBrans=@d3, DoktorTC=@d4, DoktorSifre=@d5", btn.baglanti());
            kmt3.Parameters.AddWithValue("@d1", txtad.Text);
            kmt3.Parameters.AddWithValue("@d2", txtsoyad.Text);
            kmt3.Parameters.AddWithValue("@d3", cmbbrans.Text);
            kmt3.Parameters.AddWithValue("@d4", mskdtc.Text);
            kmt3.Parameters.AddWithValue("@d5", txtsifre.Text);
            kmt3.ExecuteNonQuery();
            btn.baglanti().Close();
            MessageBox.Show("Doktor bilgisi güncellenmiştir", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView11_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int seç = dataGridView11.SelectedCells[0].RowIndex;
            txtad.Text = dataGridView11.Rows[seç].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView11.Rows[seç].Cells[2].Value.ToString();
            cmbbrans.Text = dataGridView11.Rows[seç].Cells[3].Value.ToString();
            mskdtc.Text = dataGridView11.Rows[seç].Cells[4].Value.ToString();
            txtsifre.Text = dataGridView11.Rows[seç].Cells[5].Value.ToString();
        }

        
    }
}
