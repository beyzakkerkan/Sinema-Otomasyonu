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
    public partial class frmBiletİşlemleri : Form
    {
        public frmBiletİşlemleri()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Sinema_Bileti;Integrated Security=True");

        int sayac = 0;

        private void FilmveSalonGetir(ComboBox combo, string sql1, string sql2)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sql1,baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                combo.Items.Add(read[sql2].ToString());
            }
            baglanti.Close();
        }
        private void FilmAfisiGoster()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from film_bilgileri where filmadi='"+ComboFilmAdi.SelectedItem+"'",baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                guna2PictureBox1.ImageLocation = read["resim"].ToString();
            }
            baglanti.Close();
        }
        private void Combo_Dolu_Koltuklar()
        {
            ComboKoltukİptal.Items.Clear();
            ComboKoltukİptal.Text="";

            foreach (Control item in panel3.Controls)
            {
                if (item is Button)
                {
                    if (item.BackColor==Color.Red)
                    {
                        ComboKoltukİptal.Items.Add(item.Text);
                    }
                }
            }
        }

        private void YenidenRenklendir()
        {
            foreach (Control item in panel3.Controls)
            {
                if (item is Button)
                {
                    item.BackColor = Color.White;
                }
            }
        }
        private void Veritabani_Dolu_Koltuklar()
        {
            baglanti.Open(); 
            SqlCommand komut = new SqlCommand("select *from Satis_Bilgileri where FilmAdi='"+ComboFilmAdi.SelectedItem+"' and SalonAdi='"+ComboSalonAdi.SelectedItem+"' and Tarih='"+ComboFilmTarihi.SelectedItem+"' and Saat='"+ComboFilmSeansı.SelectedItem+"'",baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                foreach (Control item in panel3.Controls)
                {
                    if (item is Button)
                    {
                        if (read["KoltukNo"].ToString()==item.Text)
                        {
                            item.BackColor = Color.Red;
                        }
                       
                    }
                }
            }
            baglanti.Close();
        }

        private void frmBiletİşlemleri_Load(object sender, EventArgs e)
        {
            Boş_Koltuklar();
            FilmveSalonGetir(ComboFilmAdi,"select *from film_bilgileri","filmadi");
            FilmveSalonGetir(ComboSalonAdi, "select *from salon_bilgileri", "salonadi");
        }

        private void Boş_Koltuklar()
        {
            sayac = 1;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(30, 30);
                    btn.BackColor = Color.White;
                    btn.Location = new Point(j * 30 + 30, i * 30 + 30);
                    btn.Name = sayac.ToString();
                    btn.Text = sayac.ToString();
                    if (j == 4)
                    {
                        continue;
                    }
                    sayac++;
                    this.panel3.Controls.Add(btn);
                    btn.Click += Btn_Click;
                }
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.BackColor==Color.White)
            {
                txtKoltukNo.Text = b.Text;
            }
        }

        private void ComboFilmAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboFilmSeansı.Items.Clear();
            ComboFilmTarihi.Items.Clear();
            ComboFilmSeansı.Text = "";
            ComboFilmTarihi.Text = "";
            ComboSalonAdi.Text = "";
            ComboUcret.Text = "";
            foreach (Control item in groupBox3.Controls) if (item is TextBox) item.Text = "";

            FilmAfisiGoster();
            YenidenRenklendir();
            Combo_Dolu_Koltuklar();
        }
        Sinema_BiletiDataSetTableAdapters.Satis_BilgileriTableAdapter satis = new Sinema_BiletiDataSetTableAdapters.Satis_BilgileriTableAdapter();

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            if (txtKoltukNo.Text!="")
            {
                try
                {
                    if (MessageBox.Show("Bilet satışı yapılsın mı?","", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                    {
                        satis.Satış_Yap(txtKoltukNo.Text, ComboSalonAdi.Text, ComboFilmAdi.Text, ComboFilmTarihi.Text, ComboFilmSeansı.Text, txtAd.Text, txtSoyad.Text, ComboUcret.Text, DateTime.Now.ToString());
                        foreach (Control item in groupBox3.Controls) if (item is TextBox) item.Text = "";
                        ComboFilmAdi.SelectedIndex = -1;
                        ComboSalonAdi.SelectedIndex = -1;
                        ComboFilmTarihi.SelectedIndex = -1;
                        ComboFilmSeansı.SelectedIndex = -1;
                        txtKoltukNo.Clear();
                        txtAd.Clear();
                        txtSoyad.Clear();
                        ComboUcret.SelectedIndex = -1;
                        YenidenRenklendir();
                        Veritabani_Dolu_Koltuklar();
                        Combo_Dolu_Koltuklar();
                        MessageBox.Show("Bilet satışı yapıldı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        
                    }
                    
                }
                catch (Exception hata)
                {

                    MessageBox.Show(" Hata oluştu!!!"+hata.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } 
            }
            else
            {
                MessageBox.Show("Koltuk seçimi yapmadınız !!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Film_Tarihi_Getir()
        {
            ComboFilmTarihi.Text ="";
            ComboFilmSeansı.Text="";
            ComboFilmTarihi.Items.Clear();
            ComboFilmSeansı.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from Seans_Bilgileri where FilmAdi='"+ComboFilmAdi.Text+"' and SalonAdi='"+ComboSalonAdi.Text+"'",baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (DateTime.Parse(read["Tarih"].ToString())>=DateTime.Parse(DateTime.Now.ToShortDateString()))
                {
                    if (!ComboFilmTarihi.Items.Contains(read["Tarih"].ToString()))
                    {
                        ComboFilmTarihi.Items.Add(read["Tarih"].ToString());
                    }

                }
            }
            baglanti.Close();
        }
        private void ComboSalonAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboFilmTarihi.Items.Clear();
            Film_Tarihi_Getir();
        }
        private void Film_Seansi_Getir()
        {
            ComboFilmSeansı.Text = "";
            ComboFilmSeansı.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from Seans_Bilgileri where FilmAdi='" + ComboFilmAdi.Text + "' and SalonAdi='" + ComboSalonAdi.Text + "' and Tarih='"+ComboFilmTarihi.Text+"'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (DateTime.Parse(read["Tarih"].ToString()) == DateTime.Parse(DateTime.Now.ToShortDateString()))
                {
                    if (DateTime.Parse(read["Seans"].ToString()) > DateTime.Parse(DateTime.Now.ToLongTimeString()))
                    {
                        ComboFilmSeansı.Items.Add(read["Seans"].ToString());
                    }
                      
                }
                else if (DateTime.Parse(read["Tarih"].ToString()) > DateTime.Parse(DateTime.Now.ToShortDateString()))
                {
                    ComboFilmSeansı.Items.Add(read["Seans"].ToString());
                }
            }
            baglanti.Close();
        }
        private void ComboFilmTarihi_SelectedIndexChanged(object sender, EventArgs e)
        {
            Film_Seansi_Getir();
        }

        private void ComboFilmSeansı_SelectedIndexChanged(object sender, EventArgs e)
        {
            YenidenRenklendir();
            Veritabani_Dolu_Koltuklar();
            Combo_Dolu_Koltuklar();
        }

        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
            if (ComboKoltukİptal.Text!="")
            {
                try
                {
                    if (MessageBox.Show("Bilet iptal edilsin mi?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        satis.Satış_İptal(ComboFilmAdi.Text, ComboSalonAdi.Text, ComboFilmTarihi.Text, ComboFilmSeansı.Text, ComboKoltukİptal.Text);
                        YenidenRenklendir();
                        Veritabani_Dolu_Koltuklar();
                        Combo_Dolu_Koltuklar();
                        MessageBox.Show("Bilet iptal edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ComboFilmAdi.SelectedIndex = -1;
                        ComboSalonAdi.SelectedIndex = -1;
                        ComboFilmTarihi.SelectedIndex = -1;
                        ComboFilmSeansı.SelectedIndex = -1;
                        txtKoltukNo.Clear();
                        txtAd.Clear();
                        txtSoyad.Clear();
                        ComboUcret.SelectedIndex = -1;
                    }
                    
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Hata oluştu !!!"+hata.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Koltuk seçimi yapmadınız !!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
