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
    public partial class frmSalonEkle : Form
    {
        public frmSalonEkle()
        {
            InitializeComponent();
        }
        Sinema_BiletiDataSetTableAdapters.Salon_BilgileriTableAdapter salon = new Sinema_BiletiDataSetTableAdapters.Salon_BilgileriTableAdapter();

        private void frmSalonEkle_Load(object sender, EventArgs e)
        {

        }
        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSalonAdi.Text == "" || txtSalonKapasitesi.Text == "" || txtSalonKati.Text == "" || txtSalonGorevlisi.Text == "")
                {
                    MessageBox.Show("Bilgileri Eksiksiz Şekilde Doldurunuz!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    salon.SalonEkleme(txtSalonAdi.Text, txtSalonKapasitesi.Text, txtSalonKati.Text, txtSalonGorevlisi.Text);
                    MessageBox.Show("Salon Bilgileri Eklendi", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSalonAdi.Clear();
                    txtSalonKapasitesi.Clear();
                    txtSalonKati.Clear();
                    txtSalonGorevlisi.Clear();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bu salonu Daha Önce Eklediniz!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
