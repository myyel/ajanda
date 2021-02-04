using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ajanda
{
    public partial class Aylar : Form
    {
        public Aylar()
        {
            InitializeComponent();
        }

        public delegate void ay_gonder(int ay);
        public ay_gonder ay_gon;

        private void ocak_Click(object sender, EventArgs e)
        {
            ay_gon(1);
            this.Close();
        }

        private void subat_Click(object sender, EventArgs e)
        {
            ay_gon(2);
            this.Close();
        }

        private void mart_Click(object sender, EventArgs e)
        {
            ay_gon(3);
            this.Close();
        }

        private void nisan_Click(object sender, EventArgs e)
        {
            ay_gon(4);
            this.Close();
        }

        private void mayis_Click(object sender, EventArgs e)
        {
            ay_gon(5);
            this.Close();
        }

        private void haziran_Click(object sender, EventArgs e)
        {
            ay_gon(6);
            this.Close();
        }

        private void temmuz_Click(object sender, EventArgs e)
        {
            ay_gon(7);
            this.Close();
        }

        private void agustos_Click(object sender, EventArgs e)
        {
            ay_gon(8);
            this.Close();
        }

        private void eylul_Click(object sender, EventArgs e)
        {
            ay_gon(9);
            this.Close();
        }

        private void ekim_Click(object sender, EventArgs e)
        {
            ay_gon(10);
            this.Close();
        }

        private void kasim_Click(object sender, EventArgs e)
        {
            ay_gon(11);
            this.Close();
        }

        private void aralik_Click(object sender, EventArgs e)
        { 
            ay_gon(12);
            this.Close();
        }

        private void ocak_MouseHover(object sender, EventArgs e)
        {
            ocak.FlatAppearance.BorderColor = Color.Silver;
            ocak.FlatAppearance.BorderSize = 1;
        }

        private void ocak_MouseLeave(object sender, EventArgs e)
        {
            ocak.FlatAppearance.BorderSize = 0;
        }

        private void subat_MouseHover(object sender, EventArgs e)
        {
            subat.FlatAppearance.BorderColor = Color.Silver;
            subat.FlatAppearance.BorderSize = 1;
        }

        private void subat_MouseLeave(object sender, EventArgs e)
        {
            subat.FlatAppearance.BorderSize = 0;
        }

        private void mart_MouseHover(object sender, EventArgs e)
        {
            mart.FlatAppearance.BorderColor = Color.Silver;
            mart.FlatAppearance.BorderSize = 1;
        }

        private void mart_MouseLeave(object sender, EventArgs e)
        {
            mart.FlatAppearance.BorderSize = 0;
        }

        private void nisan_MouseHover(object sender, EventArgs e)
        {
            nisan.FlatAppearance.BorderColor = Color.Silver;
            nisan.FlatAppearance.BorderSize = 1;
        }

        private void nisan_MouseLeave(object sender, EventArgs e)
        {
            nisan.FlatAppearance.BorderSize = 0;
        }

        private void mayis_MouseHover(object sender, EventArgs e)
        {
            mayis.FlatAppearance.BorderColor = Color.Silver;
            mayis.FlatAppearance.BorderSize = 1;
        }

        private void mayis_MouseLeave(object sender, EventArgs e)
        {
            mayis.FlatAppearance.BorderSize = 0;
        }

        private void haziran_MouseHover(object sender, EventArgs e)
        {
            haziran.FlatAppearance.BorderColor = Color.Silver;
            haziran.FlatAppearance.BorderSize = 1;
        }

        private void haziran_MouseLeave(object sender, EventArgs e)
        {
            haziran.FlatAppearance.BorderSize = 0;
        }

        private void temmuz_MouseHover(object sender, EventArgs e)
        {
            temmuz.FlatAppearance.BorderColor = Color.Silver;
            temmuz.FlatAppearance.BorderSize = 1;
        }

        private void temmuz_MouseLeave(object sender, EventArgs e)
        {
            temmuz.FlatAppearance.BorderSize = 0;
        }

        private void agustos_MouseHover(object sender, EventArgs e)
        {
            agustos.FlatAppearance.BorderColor = Color.Silver;
            agustos.FlatAppearance.BorderSize = 1;
        }

        private void agustos_MouseLeave(object sender, EventArgs e)
        {
            agustos.FlatAppearance.BorderSize = 0;
        }

        private void eylul_MouseHover(object sender, EventArgs e)
        {
            eylul.FlatAppearance.BorderColor = Color.Silver;
            eylul.FlatAppearance.BorderSize = 1;
        }

        private void eylul_MouseLeave(object sender, EventArgs e)
        {
            eylul.FlatAppearance.BorderSize = 0;
        }

        private void ekim_MouseHover(object sender, EventArgs e)
        {
            ekim.FlatAppearance.BorderColor = Color.Silver;
            ekim.FlatAppearance.BorderSize = 1;
        }

        private void ekim_MouseLeave(object sender, EventArgs e)
        {
            ekim.FlatAppearance.BorderSize = 0;
        }

        private void kasim_MouseHover(object sender, EventArgs e)
        {
            kasim.FlatAppearance.BorderColor = Color.Silver;
            kasim.FlatAppearance.BorderSize = 1;
        }

        private void kasim_MouseLeave(object sender, EventArgs e)
        {
            kasim.FlatAppearance.BorderSize = 0;
        }

        private void aralik_MouseHover(object sender, EventArgs e)
        {
            aralik.FlatAppearance.BorderColor = Color.Silver;
            aralik.FlatAppearance.BorderSize = 1;
        }

        private void aralik_MouseLeave(object sender, EventArgs e)
        {
            aralik.FlatAppearance.BorderSize = 0;
        }
    }
}
