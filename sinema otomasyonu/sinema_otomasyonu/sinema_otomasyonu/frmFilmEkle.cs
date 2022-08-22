using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sinema_otomasyonu
{
    public partial class frmFilmEkle : Form
    {
        public frmFilmEkle()
        {
            InitializeComponent();
        }
        Sinema_BiletiDataSetTableAdapters.Film_BilgileriTableAdapter film = new Sinema_BiletiDataSetTableAdapters.Film_BilgileriTableAdapter();

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFilmAdi.Text == "" || txtYonetmen.Text == "" || txtYapimYili.Text == "" || txtSure.Text == "" || comboFilmTuru.SelectedIndex == -1 || pictureBox1 == null)
                {
                    MessageBox.Show("Bilgileri Eksiksiz Şekilde Doldurunuz!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    film.FilmEkleme(txtFilmAdi.Text, txtYonetmen.Text, comboFilmTuru.Text, txtSure.Text, dateTimePicker1.Text, txtYapimYili.Text, pictureBox1.ImageLocation);
                    MessageBox.Show("Film Bilgileri Eklendi", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFilmAdi.Clear();
                    txtYonetmen.Clear();
                    txtSure.Clear();
                    txtYapimYili.Clear();
                    comboFilmTuru.SelectedIndex = -1;
                    pictureBox1.Image = null;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Bu Filmi Daha Önce Eklediniz!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFilmAdi.Clear();
                txtYonetmen.Clear();
                txtSure.Clear();
                txtYapimYili.Clear();
                comboFilmTuru.SelectedIndex = -1;
                pictureBox1.Image = null;
            }
            
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
        }

        private void frmFilmEkle_Load(object sender, EventArgs e)
        {

        }
    }
}
