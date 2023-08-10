
namespace Hastane_Randevu_Projesi
{
    partial class FrmRandevu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRandevu));
            this.dataGridView111 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView111)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView111
            // 
            this.dataGridView111.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView111.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView111.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView111.Location = new System.Drawing.Point(0, 0);
            this.dataGridView111.Name = "dataGridView111";
            this.dataGridView111.RowHeadersWidth = 51;
            this.dataGridView111.RowTemplate.Height = 24;
            this.dataGridView111.Size = new System.Drawing.Size(1022, 450);
            this.dataGridView111.TabIndex = 0;
            // 
            // FrmRandevu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1022, 450);
            this.Controls.Add(this.dataGridView111);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmRandevu";
            this.Text = "FrmRandevuListesi";
            this.Load += new System.EventHandler(this.FrmRandevu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView111)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView111;
    }
}