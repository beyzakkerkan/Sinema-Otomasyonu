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
    public partial class LoginEkranı : Form
    {
        public LoginEkranı()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Sinema_Bileti;Integrated Security=True");

        private void LoginEkranı_Load(object sender, EventArgs e)
        {
           
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string kadi = textBox1.Text;
            string parola = textBox2.Text;
            baglanti.Open();
            string sql = "select * from yöneticibilgi where kullanıcıadı = @kullaniciadi and şifre = @sifre";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.Add(new SqlParameter("@kullaniciadi", kadi));
            komut.Parameters.Add(new SqlParameter("@sifre", parola));

            SqlDataReader reader = komut.ExecuteReader();

            if (reader.Read())
            {
                Hide();
                FormAnaSayfa anasyf = new FormAnaSayfa();
                anasyf.Show();
            }
            else
            {
                MessageBox.Show("Hatalı giriş yaptınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
                textBox2.Clear();
            }

            baglanti.Close();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                guna2Button1.PerformClick();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
