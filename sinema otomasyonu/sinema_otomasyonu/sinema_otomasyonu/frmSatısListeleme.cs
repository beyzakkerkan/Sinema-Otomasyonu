using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sinema_otomasyonu
{
    public partial class frmSatısListeleme : Form
    {
        public frmSatısListeleme()
        {
            InitializeComponent();
        }
        Sinema_BiletiDataSetTableAdapters.Satis_BilgileriTableAdapter satislistesi = new Sinema_BiletiDataSetTableAdapters.Satis_BilgileriTableAdapter();
        SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Sinema_Bileti;Integrated Security=True");

        private void frmSatısListeleme_Load_1(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = satislistesi.TariheGoreListele2(dateTimePicker1.Text);
            ToplamUcretHesapla();
        }

        private void ToplamUcretHesapla()
        {
            int ucrettoplami = 0;
            for (int i = 0; i < guna2DataGridView1.Rows.Count; i++)
            {
                ucrettoplami += Convert.ToInt32(guna2DataGridView1.Rows[i].Cells["ucret"].Value);
            }
            label1.Text = "Toplam Satış=" + ucrettoplami + "TL";
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = satislistesi.SatisListele2();

            ToplamUcretHesapla();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = satislistesi.TariheGoreListele2(dateTimePicker1.Text);
            ToplamUcretHesapla();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bu Seansı silmek istiyor musunuz ?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Satis_Bilgileri where SatisId=@SatisId", baglanti);
                komut.Parameters.AddWithValue("@SatisId", guna2DataGridView1.CurrentRow.Cells["SatisId"].Value.ToString());
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Silme İşlemi Gerçekleşti", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            beyza.Class1.excelekaydet();
        }
    }
}
