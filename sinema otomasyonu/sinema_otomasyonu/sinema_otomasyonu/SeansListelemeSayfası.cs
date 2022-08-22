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
    public partial class SeansListelemeSayfası : Form
    {
        public SeansListelemeSayfası()
        {
            InitializeComponent();
        }
        //Sinema_BiletiDataSetTableAdapters.Seans_BilgileriTableAdapter filmseans = new Sinema_BiletiDataSetTableAdapters.Seans_BilgileriTableAdapter();

        SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Sinema_Bileti;Integrated Security=True");
        DataTable tablo = new DataTable();

        private void SeansListesi(string sql)
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter(sql,baglanti);
            adtr.Fill(tablo);
            guna2DataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void SeansListelemeSayfası_Load(object sender, EventArgs e)
        {
            tablo.Clear();
           SeansListesi("select *from seans_bilgileri where tarih like '" + dateTimePicker1.Text + "' ");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            tablo.Clear();
            SeansListesi("select *from seans_bilgileri where tarih like '" + dateTimePicker1.Text + "' ");
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            tablo.Clear();
            SeansListesi("select *from seans_bilgileri");

        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bu Seansı silmek istiyor musunuz ?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Seans_Bilgileri where SeansId=@SeansId", baglanti);
                komut.Parameters.AddWithValue("@SeansId", guna2DataGridView1.CurrentRow.Cells["SeansId"].Value.ToString());
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Silme İşlemi Gerçekleşti", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
        }
    }
}
