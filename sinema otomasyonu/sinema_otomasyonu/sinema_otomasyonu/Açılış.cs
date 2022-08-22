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
    public partial class Açılış : Form
    {
        public Açılış()
        {
            InitializeComponent();
        }

        private void Açılış_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Width += 2;
            if (panel1.Width>=500)
            {
                gunaLabel1.Visible = true;
               
                
            }
            


        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (panel1.Width >= 1030)
            {
                this.Hide();
                LoginEkranı lgn = new LoginEkranı();
                lgn.Show();
                timer1.Stop();
                timer2.Stop();
            }
        }
    }
}
