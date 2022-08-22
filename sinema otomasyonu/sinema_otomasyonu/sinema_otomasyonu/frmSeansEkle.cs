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
    public partial class frmSeansEkle : Form
    {
        public frmSeansEkle()
        {
            InitializeComponent();
        }
        Sinema_BiletiDataSetTableAdapters.Seans_BilgileriTableAdapter filmseans = new Sinema_BiletiDataSetTableAdapters.Seans_BilgileriTableAdapter();

        SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Sinema_Bileti;Integrated Security=True");

        private void frmSeansEkle_Load(object sender, EventArgs e)
        {
            FilmveSalonGoster(comboFilm,"select *from film_bilgileri","filmadi");
            FilmveSalonGoster(comboSalon, "select *from salon_bilgileri", "salonadi");

        }
        private void FilmveSalonGoster(ComboBox combo, string sql,string sql2)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sql, baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read()==true)
            {
                combo.Items.Add(read[sql2].ToString());
            }
            baglanti.Close();
        }
        string seans = "";
        private void Guna2RadioButtonSeçiliyse()
        {
            if (guna2RadioButton1.Checked == true) seans = guna2RadioButton1.Text;
            else if (guna2RadioButton2.Checked == true) seans = guna2RadioButton2.Text;
            else if (guna2RadioButton3.Checked == true) seans = guna2RadioButton3.Text;
            else if (guna2RadioButton4.Checked == true) seans = guna2RadioButton4.Text;
            else if (guna2RadioButton5.Checked == true) seans = guna2RadioButton5.Text;
            else if (guna2RadioButton6.Checked == true) seans = guna2RadioButton6.Text;
            else if (guna2RadioButton7.Checked == true) seans = guna2RadioButton7.Text;
            else if (guna2RadioButton8.Checked == true) seans = guna2RadioButton8.Text;
            else if (guna2RadioButton9.Checked == true) seans = guna2RadioButton9.Text;
            else if (guna2RadioButton10.Checked == true) seans = guna2RadioButton10.Text;
            else if (guna2RadioButton11.Checked == true) seans = guna2RadioButton11.Text;
            else if (guna2RadioButton12.Checked == true) seans = guna2RadioButton12.Text;
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Guna2RadioButtonSeçiliyse();
            if (seans!="")
            {
                filmseans.SeansEkleme(comboFilm.Text,comboSalon.Text,dateTimePicker1.Text,seans);
                MessageBox.Show("Seans ekleme işlemi yapıldı","Kayıt");
            }
            else if (seans=="")
            {
                MessageBox.Show("Seans seçimi yapmadınız","Uyarı");
               
            }
            comboFilm.SelectedIndex = -1;
            comboSalon.SelectedIndex = -1;
            dateTimePicker1.Text = DateTime.Now.ToShortDateString();//temizlemiyor 

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            foreach (Control item3 in groupBox1.Controls)
            {
                item3.Enabled = true;
               
            }
            DateTime bugün = DateTime.Parse(DateTime.Now.ToShortDateString());
            DateTime yeni = DateTime.Parse(dateTimePicker1.Text);

            if (yeni==bugün)
            {
                foreach (Control item in groupBox1.Controls)
                {
                    if (DateTime.Parse(DateTime.Now.ToShortTimeString()) > DateTime.Parse(item.Text))
                    {
                        item.Enabled = false;
                    }
                }
                Tarihi_Karşılaştır();
            }
            else if (yeni>bugün)
            {
                Tarihi_Karşılaştır();
            }
            else if (yeni<bugün)
            {
                MessageBox.Show("Geriye dönük işlem yapılamaz","Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateTimePicker1.Text = DateTime.Now.ToShortDateString();
            }
        }

        private void Tarihi_Karşılaştır()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from seans_bilgileri where salonadi='" + comboSalon.Text + "' and tarih='" + dateTimePicker1.Text + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read()==true)
            {
                foreach (Control item2 in groupBox1.Controls)
                {
                    if (read["seans"].ToString()==item2.Text)
                    {
                        item2.Enabled = false;
                    }
                }
            }
            baglanti.Close();
        }

        private void comboSalon_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Text = DateTime.Now.ToShortDateString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
