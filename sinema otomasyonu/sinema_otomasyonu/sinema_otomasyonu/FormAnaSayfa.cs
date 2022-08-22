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
    public partial class FormAnaSayfa : Form
    {
        public FormAnaSayfa()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Sinema_Bileti;Integrated Security=True"); 

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            panel12.SendToBack();
            panel3.BringToFront();
            guna2Button1.Checked = true;
            guna2Button2.Checked = false;
            guna2Button3.Checked = false;
            guna2Button4.Checked = false;
            guna2Button5.Checked = false;
            guna2Button9.Checked = false;

            guna2Button6.Checked = false;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            //frmSalonEkle slnekle = new frmSalonEkle();
            //slnekle.ShowDialog();

            frmSalonEkle a = new frmSalonEkle();
            a.Dock = DockStyle.Fill;
            a.TopLevel = false;
            a.FormBorderStyle = FormBorderStyle.None;
            panel12.Controls.Add(a);
            panel3.SendToBack();
            a.Show();
            a.BringToFront();

            guna2Button1.Checked = false;
            guna2Button2.Checked = true;
            guna2Button3.Checked = false;
            guna2Button4.Checked = false;
            guna2Button5.Checked = false;
            guna2Button9.Checked = false;

            guna2Button6.Checked = false;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            //frmFilmEkle filmekle = new frmFilmEkle();
            //filmekle.ShowDialog();

            frmFilmEkle a = new frmFilmEkle();
            a.Dock = DockStyle.Fill;
            a.TopLevel = false;
            a.FormBorderStyle = FormBorderStyle.None;
            panel12.Controls.Add(a);
            panel3.SendToBack();
            a.Show();
            a.BringToFront();

            guna2Button1.Checked = false;
            guna2Button2.Checked = false;
            guna2Button3.Checked = true;
            guna2Button4.Checked = false;
            guna2Button9.Checked = false;

            guna2Button5.Checked = false;
            guna2Button6.Checked = false;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
           // frmSeansEkle seansekle = new frmSeansEkle();
           // seansekle.ShowDialog();

            frmSeansEkle a = new frmSeansEkle();
            a.Dock = DockStyle.Fill;
            a.TopLevel = false;
            a.FormBorderStyle = FormBorderStyle.None;
            panel12.Controls.Add(a);
            panel3.SendToBack();
            a.Show();
            a.BringToFront();

            guna2Button1.Checked = false;
            guna2Button2.Checked = false;
            guna2Button3.Checked = false;
            guna2Button4.Checked = true;
            guna2Button5.Checked = false;
            guna2Button6.Checked = false;
            guna2Button9.Checked = false;

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            SeansListelemeSayfası a = new SeansListelemeSayfası();
            a.Dock = DockStyle.Fill;
            a.TopLevel = false;
            a.FormBorderStyle = FormBorderStyle.None;
            panel12.Controls.Add(a);
            panel3.SendToBack();
            a.Show();
            a.BringToFront();

            guna2Button1.Checked = false;
            guna2Button2.Checked = false;
            guna2Button3.Checked = false;
            guna2Button4.Checked = false;
            guna2Button5.Checked = true;
            guna2Button9.Checked = false;

            guna2Button6.Checked = false;
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            //frmBiletİşlemleri bltişlmleri = new frmBiletİşlemleri();
            //bltişlmleri.ShowDialog();

            frmBiletİşlemleri a = new frmBiletİşlemleri();
            a.Dock = DockStyle.Fill;
            a.TopLevel = false;
            a.FormBorderStyle = FormBorderStyle.None;
            panel12.Controls.Add(a);
            panel3.SendToBack();
            a.Show();
            a.BringToFront();


            guna2Button1.Checked = false;
            guna2Button2.Checked = false;
            guna2Button3.Checked = false;
            guna2Button4.Checked = false;
            guna2Button5.Checked = false;
            guna2Button6.Checked = true;
            guna2Button9.Checked = false;

        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Programdan Çıkmak İstediğinize Emin Misiniz ?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void FormAnaSayfa_Load(object sender, EventArgs e)
        {
            label2.Text = "8.4 IMDB";
            guna2Button10.Checked = true;
            Lblminute.Text = "161 dakika";
            LblFılmName.Text = "DANGAL";
            LblVisionDate.Text = "23 Aralık 2016";
            guna2RatingStar1.Value = 4;

            pictureBox2.Image = Image.FromFile(@"resim\dangal.jpg");
            pictureBox3.Image = Image.FromFile(@"resim\dangal2.jpg");
            pictureBox4.Image = Image.FromFile(@"resim\dangal3.jpg");

            LblExp.Text = "Aamir Khan filmde Mahavir Singh isimli güreşçi olarak karşımıza çıkıyor." +
                        "Filmin yapımcılığını Disney ile Aamir Khan üstleniyor." +
                        "Khan hayranlarını yine büyülüyor." +
                        "Bir rol için 28 kilo alınır mı demeyin söz konusu Aamir Khan ise bu sorgulanmaz bile." +
                        "Filmde bir adamın 19, 29, 55 yaşlarındaki halini ayrı ayrı canlandıran Aamir Khan’ın çalışmaları" +
                        " gerçekleştirirken bir antrenör eşliğinde vücut geliştirdiği biliniyor." +
                        "98 kilo ile çekimleri bitince tekrar kilo veriyor." +
                        "98 kilo ile çekimleri bitince tekrar kilo veriyor." +
                        "Dangal güreş yarışması anlamına gelir, zaten Dangal film konusu da güreşmeyi bırakan bir babanın " +
                        "kızlarını güreşçi olarak yetiştirmesini anlatıyor." +
                        "Biyografik spor dram filmidir.";
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {

            frmSatısListeleme a = new frmSatısListeleme();
            a.Dock = DockStyle.Fill;
            a.TopLevel = false;
            a.FormBorderStyle = FormBorderStyle.None;
            panel12.Controls.Add(a);
            panel3.SendToBack();
            a.Show();
            a.BringToFront();

            guna2Button1.Checked = false;
            guna2Button2.Checked = false;
            guna2Button3.Checked = false;
            guna2Button4.Checked = false;
            guna2Button5.Checked = false;
            guna2Button6.Checked = false;
            guna2Button9.Checked = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void LblExp_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            guna2Button10.Checked = true;
            guna2Button11.Checked = false;
            guna2Button12.Checked = false;
            guna2Button13.Checked = false;
            guna2Button14.Checked = false;

            pictureBox2.Image= Image.FromFile(@"resim\dangal.jpg");
            pictureBox3.Image= Image.FromFile(@"resim\dangal2.jpg");
            pictureBox4.Image= Image.FromFile(@"resim\dangal3.jpg");

            LblFılmName.Text = "DANGAL";
            Lblminute.Text = "161 dakika";
            label2.Text = "8.4 IMDB";
            LblVisionDate.Text = "23 Aralık 2016";
            guna2RatingStar1.Value = 4;
            pictureBox1.Image = guna2Button10.BackgroundImage;

            LblExp.Text = "Aamir Khan filmde Mahavir Singh isimli güreşçi olarak karşımıza çıkıyor." +
                       "Filmin yapımcılığını Disney ile Aamir Khan üstleniyor." +
                       "Khan hayranlarını yine büyülüyor." +
                       "Bir rol için 28 kilo alınır mı demeyin söz konusu Aamir Khan ise bu sorgulanmaz bile." +
                       "Filmde bir adamın 19, 29, 55 yaşlarındaki halini ayrı ayrı canlandıran Aamir Khan’ın çalışmaları" +
                       " gerçekleştirirken bir antrenör eşliğinde vücut geliştirdiği biliniyor." +
                       "98 kilo ile çekimleri bitince tekrar kilo veriyor." +
                       "98 kilo ile çekimleri bitince tekrar kilo veriyor." +
                       "Dangal güreş yarışması anlamına gelir, zaten Dangal film konusu da güreşmeyi bırakan bir babanın " +
                       "kızlarını güreşçi olarak yetiştirmesini anlatıyor." +
                       "Biyografik spor dram filmidir.";
        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            guna2Button10.Checked = false;
            guna2Button11.Checked = false;
            guna2Button12.Checked = false;
            guna2Button13.Checked = false;
            guna2Button14.Checked = true;

            pictureBox2.Image = Image.FromFile(@"resim\dunc1.jpg");
            pictureBox3.Image = Image.FromFile(@"resim\dunc2.jpg");
            pictureBox4.Image = Image.FromFile(@"resim\dunc3.jpg");

            LblFılmName.Text = "DUNE";
            Lblminute.Text = "155 dakika";
            label2.Text = "8.6 IMDB";
            LblVisionDate.Text = "22 Ekim 2021";
            guna2RatingStar1.Value = 3;
            pictureBox1.Image = guna2Button14.BackgroundImage;

            LblExp.Text = "Uzak bir gelecekte geçen Dune, ailesi çöl gezegeni Arrakis’in kontrolüne sahip olan Paul Atreides’in hikayesini anlatıyor. " +
                "Galaksinin farklı noktalarındaki gezegenler, rakip feodal aileler tarafından yönetilmektedir. " +
                "Çok değerli bir kaynağın tek üreticisi olan çöl gezegeni Arrakis'in kontrolü asil aileler arasında son derece talep görmektedir. " +
                "Baharat adı verilen bu kaynak, yüksek bilinç ve uzun bir yaşam süresi sunarken, beraberinde çok ciddi yan etkileri de getirmektedir. " +
                "Ayrıca yıldızlararası yollarda gezinmeye yardımcı olan kaynak da bu baharattır. " +
                "Bu kaynağı elde etmek isteyen feodal rakiplerden Harkonen ailesi tarafından Paul ve ailesine tuzak kurulur. " +
                "Bu tuzağın sonucunda Paul'un ailesi darmadağın olarak firari hale gelir. " +
                "Paul, ailesinin Arrakis kontrolünü yeniden kazanması için bir isyan başlatırken, tüm evrenin seyrini değiştirebilme ihtimalini yakalayacaktır.";
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            guna2Button10.Checked = false;
            guna2Button11.Checked = false;
            guna2Button12.Checked = true;
            guna2Button13.Checked = false;
            guna2Button14.Checked = false;

            pictureBox2.Image = Image.FromFile(@"resim\dumbo1.jpg");
            pictureBox3.Image = Image.FromFile(@"resim\dumbo2.jpg");
            pictureBox4.Image = Image.FromFile(@"resim\dumbo3.jpg");

            LblFılmName.Text = "DUMBO";
            Lblminute.Text = "64 dakika";
            label2.Text = "6.3 IMDB";
            LblVisionDate.Text = "11 Mart 2019";
            guna2RatingStar1.Value = 2;
            pictureBox1.Image = guna2Button12.BackgroundImage;

            LblExp.Text = "Sirk sahibi Max Medici, eski yıldızı Holt Farrier ve onun çocukları Milly ve Joe'ya sıradışı bir görev verir. "
                        + "Ailenin görevi, sirkin yeni üyesinin bakımını üstlenmektir. "
                        + "Bu yeni üye, koca kulakları sebebiyle seyircileri güldüren, yavru bir bebek fildir. "
                        + "Ancak Dumbo'nun uçabileceğini keşfettiklerinde, tek ayağı çukurda olan sirk inanılmaz bir geri dönüş yapar ve ikna edici girişimci V.A. Vandevere'in dikkatini çeker. "
                        + "Vandevere, sevimli fili, yeni ve büyük eğlence parkı Dreamland için kiralar. Ancak Dreamland, yüzeyde göründüğü kadar parlak ve görkemli değildir. "
                        + "Dumbo, çekici ve muhteşem bir akrobat olan Colette Marchant ile birlikte yeni zirvelere doğru yükselir. "
                        + "Bu süreçte Holt da, Dreamland'in karanlık sırlarını keşfedecektir... "
                        + "Yönetmenliğini Tim Burton'ın üstlendiği yapım, küçük bir sirk filinin fareyle olan dostluğunu beyazperdeye taşıyacak. "
                        + "Yapımcılığını Disney'in üstlendiği projede senaryo ise Ehren Kruger'e ait.";
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            guna2Button10.Checked = false;
            guna2Button11.Checked = false;
            guna2Button12.Checked = false;
            guna2Button13.Checked = true;
            guna2Button14.Checked = false;

            pictureBox2.Image = Image.FromFile(@"resim\venom1.jpg");
            pictureBox3.Image = Image.FromFile(@"resim\venom2.jpg");
            pictureBox4.Image = Image.FromFile(@"resim\venom3.jpg");

            LblFılmName.Text = "VENOM";
            Lblminute.Text = "93 dakika";
            label2.Text = "7.7 IMDB";
            LblVisionDate.Text = "15 Ekim 2021";
            guna2RatingStar1.Value = 4;
            pictureBox1.Image = guna2Button13.BackgroundImage;

            LblExp.Text = "Tom Hardy'nin, Venom ile simbiyotik bir ilişki sürdürmeye çalışan gazeteci Eddie Brock rolüne geri döndüğü filmde, " +
                "Woody Harrelson'ın canlandırdığı Cletus Kasady, nam-ı diğer Carnage ile Naomie Harris'in hayat verdiği Shriek'i Venom ile mücadele ederken göreceğiz. " +
                "İlk filmde yer alan ünlü oyuncu Michelle Williams, devam filminde de karakterini yeniden canlandıracak.";
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            guna2Button10.Checked = false;
            guna2Button11.Checked = true;
            guna2Button12.Checked = false;
            guna2Button13.Checked = false;
            guna2Button14.Checked = false;

            pictureBox2.Image = Image.FromFile(@"resim\adams1.jpg");
            pictureBox3.Image = Image.FromFile(@"resim\adams2.jpg");
            pictureBox4.Image = Image.FromFile(@"resim\adams3.jpg");

            LblFılmName.Text = "ADAMS AİLESİ 2";
            Lblminute.Text = "93 dakika";
            label2.Text = "7.2 IMDB";
            LblVisionDate.Text = "12 Kasım 2021";
            guna2RatingStar1.Value = 5;
            pictureBox1.Image = guna2Button11.BackgroundImage;

            LblExp.Text = "Animasyon komedinin devam filmi Addams Ailesi 2’de herkesin favorisi olan ürkütücü aile geri dönüyor. " +
                "Bu yeni filmde Morticia ile Gomez’i, çocukları büyüdüğü, aile yemeklerini ektikleri ve “çığlık süresi”ni tümüyle kullandıkları için çılgına dönmüş bir halde buluruz. " +
                "Aralarındaki bağı yeniden kurmak için Wednesday, Pugsley, Fester amca ve ekibi perili karavanlarına doldurup son bir sefil aile tatili için yola düşerler. " +
                "Amerika’nın diğer ucuna doğru çıktıkları macera, onları kendi ortamlarından çıkarır ve ikonik kuzenleri ’Şey’ ve acayip yeni karakterlerle komik çatışmalara sokar. " +
                "Yanlış giden ne olabilir ki?";
        }
    }
}
