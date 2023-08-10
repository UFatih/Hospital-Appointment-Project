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
    public partial class FrmBranş : Form
    {
        public FrmBranş()
        {
            InitializeComponent();
        }

        sqlbaglantisi btn = new sqlbaglantisi();
        private void FrmBranş_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Branslar", btn.baglanti());
            da.Fill(dt);
            dataGridView12.DataSource = dt;
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            SqlCommand kmt = new SqlCommand("insert into Tbl_Branslar (BransAd) values (@b1)",btn.baglanti());
            kmt.Parameters.AddWithValue("@b1", txtad.Text);
            kmt.ExecuteNonQuery();
            btn.baglanti().Close();
            MessageBox.Show("Bilgileriniz Eklenmiştir", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand kmt2 = new SqlCommand("Delete From Tbl_Branslar where Bransid=@r1", btn.baglanti());
            kmt2.Parameters.AddWithValue("@r1", txtid.Text);
            kmt2.ExecuteNonQuery();
            btn.baglanti().Close();
            MessageBox.Show("Bilgileriniz Silinmiştir", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btngncle_Click(object sender, EventArgs e)
        {
            SqlCommand kmt3 = new SqlCommand("Update Tbl_Branslar set BransAd=@u1 where Bransid=@u2", btn.baglanti());
            kmt3.Parameters.AddWithValue("@u1", txtad.Text);
            kmt3.Parameters.AddWithValue("@u2", txtid.Text);
            kmt3.ExecuteNonQuery();
            btn.baglanti().Close();
            MessageBox.Show("Bilgileriniz Güncellenmiştir", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView12_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView12.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView12.Rows[secilen].Cells[0].Value.ToString();
            txtad.Text = dataGridView12.Rows[secilen].Cells[1].Value.ToString();

        }
    }
}
