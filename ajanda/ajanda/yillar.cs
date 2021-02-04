using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ajanda
{
    public partial class Yillar : Form
    {
        public Yillar()
        {
            InitializeComponent();
        }

        public delegate void yil_gonder(string yil);
        public yil_gonder yil_gon;

        // yılları butona yazma
        public void buton_yaz(int gercek_yil)
        {
            but1.Text = (gercek_yil + 1).ToString();
            but2.Text = (gercek_yil + 2).ToString();
            but3.Text = (gercek_yil + 3).ToString();
            but4.Text = (gercek_yil + 4).ToString();
            but5.Text = (gercek_yil + 5).ToString();
            but6.Text = (gercek_yil + 6).ToString();
            but7.Text = (gercek_yil + 7).ToString();
            but8.Text = (gercek_yil + 8).ToString();
            but9.Text = (gercek_yil + 9).ToString();
            but10.Text = (gercek_yil + 10).ToString();
        }

        // anasayfa
        private void Yillar_Load(object sender, EventArgs e)
        {
            
            Anasayfa ana_form = new Anasayfa();
            int gercek_yil = Convert.ToInt32(ana_form.label_yil.Text);
            int hedef_yil = 2020;
            while (gercek_yil>hedef_yil)
            {
                if (gercek_yil > hedef_yil)
                {
                    gercek_yil = hedef_yil;
                }
                hedef_yil = hedef_yil + 10;
            }
            if (gercek_yil==2020)
            {
                button10.Enabled = false;
            }
            buton_yaz(gercek_yil);
        }

        private void but1_Click(object sender, EventArgs e)
        {
            yil_gon(but1.Text);
            this.Close();
        }

        private void but2_Click(object sender, EventArgs e)
        {
            yil_gon(but2.Text);
            this.Close();
        }

        private void but3_Click(object sender, EventArgs e)
        {
            yil_gon(but3.Text);
            this.Close();
        }

        private void but4_Click(object sender, EventArgs e)
        {
            yil_gon(but4.Text);
            this.Close();
        }

        private void but5_Click(object sender, EventArgs e)
        {
            yil_gon(but5.Text);
            this.Close();
        }

        private void but6_Click(object sender, EventArgs e)
        {
            yil_gon(but6.Text);
            this.Close();
        }

        private void but7_Click(object sender, EventArgs e)
        {
            yil_gon(but7.Text);
            this.Close();
        }

        private void but8_Click(object sender, EventArgs e)
        {
            yil_gon(but8.Text);
            this.Close();
        }

        private void but9_Click(object sender, EventArgs e)
        {
            yil_gon(but9.Text);
            this.Close();
        }

        private void but10_Click(object sender, EventArgs e)
        {
            yil_gon(but10.Text);
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int gercek_yil = Convert.ToInt32(but1.Text) + 9;
            if (gercek_yil!=2021)
            {
                button10.Enabled = true;
            }
            buton_yaz(gercek_yil);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int gercek_yil = Convert.ToInt32(but1.Text) - 11;
            if (gercek_yil==2020)
            {
                button10.Enabled = false;
            }
            buton_yaz(gercek_yil);
        }

        private void but1_MouseHover(object sender, EventArgs e)
        {
            but1.FlatAppearance.BorderColor = Color.Silver;
            but1.FlatAppearance.BorderSize = 1;
        }

        private void but1_MouseLeave(object sender, EventArgs e)
        {
            but1.FlatAppearance.BorderSize = 0;
        }

        private void but2_MouseHover(object sender, EventArgs e)
        {
            but2.FlatAppearance.BorderColor = Color.Silver;
            but2.FlatAppearance.BorderSize = 1;
        }

        private void but2_MouseLeave(object sender, EventArgs e)
        {
            but2.FlatAppearance.BorderSize = 0;
        }

        private void but3_MouseHover(object sender, EventArgs e)
        {
            but3.FlatAppearance.BorderColor = Color.Silver;
            but3.FlatAppearance.BorderSize = 1;
        }

        private void but3_MouseLeave(object sender, EventArgs e)
        {
            but3.FlatAppearance.BorderSize = 0;
        }

        private void but4_MouseHover(object sender, EventArgs e)
        {
            but4.FlatAppearance.BorderColor = Color.Silver;
            but4.FlatAppearance.BorderSize = 1;
        }

        private void but4_MouseLeave(object sender, EventArgs e)
        {
            but4.FlatAppearance.BorderSize = 0;
        }

        private void but5_MouseHover(object sender, EventArgs e)
        {
            but5.FlatAppearance.BorderColor = Color.Silver;
            but5.FlatAppearance.BorderSize = 1;
        }

        private void but5_MouseLeave(object sender, EventArgs e)
        {
            but5.FlatAppearance.BorderSize = 0;
        }

        private void but6_MouseHover(object sender, EventArgs e)
        {
            but6.FlatAppearance.BorderColor = Color.Silver;
            but6.FlatAppearance.BorderSize = 1;
        }

        private void but6_MouseLeave(object sender, EventArgs e)
        {
            but6.FlatAppearance.BorderSize = 0;
        }

        private void but7_MouseHover(object sender, EventArgs e)
        {
            but7.FlatAppearance.BorderColor = Color.Silver;
            but7.FlatAppearance.BorderSize = 1;
        }

        private void but7_MouseLeave(object sender, EventArgs e)
        {
            but7.FlatAppearance.BorderSize = 0;
        }

        private void but8_MouseHover(object sender, EventArgs e)
        {
            but8.FlatAppearance.BorderColor = Color.Silver;
            but8.FlatAppearance.BorderSize = 1;
        }

        private void but8_MouseLeave(object sender, EventArgs e)
        {
            but8.FlatAppearance.BorderSize = 0;
        }

        private void but9_MouseHover(object sender, EventArgs e)
        {
            but9.FlatAppearance.BorderColor = Color.Silver;
            but9.FlatAppearance.BorderSize = 1;
        }

        private void but9_MouseLeave(object sender, EventArgs e)
        {
            but9.FlatAppearance.BorderSize = 0;
        }

        private void but10_MouseHover(object sender, EventArgs e)
        {
            but10.FlatAppearance.BorderColor = Color.Silver;
            but10.FlatAppearance.BorderSize = 1;
        }

        private void but10_MouseLeave(object sender, EventArgs e)
        {
            but10.FlatAppearance.BorderSize = 0;
        }

        private void button10_MouseHover(object sender, EventArgs e)
        {
            button10.FlatAppearance.BorderColor = Color.Silver;
            button10.FlatAppearance.BorderSize = 1;
        }

        private void button10_MouseLeave(object sender, EventArgs e)
        {
            button10.FlatAppearance.BorderSize = 0;
        }

        private void button11_MouseHover(object sender, EventArgs e)
        {
            button11.FlatAppearance.BorderColor = Color.Silver;
            button11.FlatAppearance.BorderSize = 1;
        }

        private void button11_MouseLeave(object sender, EventArgs e)
        {
            button11.FlatAppearance.BorderSize = 0;
        }
    }
}
