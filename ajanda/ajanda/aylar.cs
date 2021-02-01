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
    }
}
