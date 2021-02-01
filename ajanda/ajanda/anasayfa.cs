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
    public partial class Anasayfa : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-RCGP0F0\\SQLEXPRESS;Initial Catalog=db_plan;Integrated Security=True");
        public Anasayfa()
        {
            InitializeComponent();
        }

        //Anasayfa
        public void Anasayfa_Load(object sender, EventArgs e)
        {
            string yil = DateTime.Now.Year.ToString();
            int yil2 = Convert.ToInt32(DateTime.Now.Year);
            if (yil2 == 2021)
            {
                label8.Enabled = false;
                label3.ForeColor = Color.White;
            }
            string yil_sorgu = "select yil from yillar where yil='" + yil + "'";
            label_yil.Text = yil;
            SqlCommand yil_sor = new SqlCommand(yil_sorgu, baglanti);
            baglanti.Open();

            if (yil_sor.ExecuteScalar() == null)
            {
                string yil_yaz = "insert into yillar(yil) values('" + yil + "')";
                SqlCommand yil_ekle = new SqlCommand(yil_yaz, baglanti);
                yil_ekle.ExecuteNonQuery();
                baglanti.Close();
            }
            baglanti.Close();
            int ay = Convert.ToInt32(DateTime.Now.Month);
            ay_bulma(ay);
        }

        //bugünün ya da istenilen ayı bulma fonksiyonu
        public void ay_bulma(int ay)
        {            
            switch (ay)
            {
                case 1:
                    ay = 1;
                    label_ay.Text = "Ocak";
                    label_ay.Size = new Size(116, 54);
                    label_ay.Font = new Font("Minion Pro", 34, FontStyle.Bold);                   
                    break;

                case 2:
                    ay = 2;
                    label_ay.Text = "Şubat";
                    label_ay.Location = new Point(49, 22);
                    label_ay.Font = new Font("Minion Pro", 30, FontStyle.Bold);
                    break;

                case 3:
                    ay = 3;
                    label_ay.Text = "Mart";
                    label_ay.Size = new Size(113, 54);
                    label_ay.Font = new Font("Minion Pro", 34, FontStyle.Bold);
                    break;

                case 4:
                    ay = 4;
                    label_ay.Text = "Nisan";
                    label_ay.Size = new Size(115, 48);
                    label_ay.Font = new Font("Minion Pro", 30, FontStyle.Bold);
                    break;

                case 5:
                    ay = 5;
                    label_ay.Text = "Mayıs";
                    label_ay.Size = new Size(117, 48);
                    label_ay.Font = new Font("Minion Pro", 30, FontStyle.Bold);
                    break;

                case 6:
                    ay = 6;
                    label_ay.Text = "Haziran";
                    label_ay.Location = new Point(49, 26);
                    label_ay.Font = new Font("Minion Pro", 23, FontStyle.Bold);
                    break;

                case 7:
                    ay = 7;
                    label_ay.Text = "Temmuz";
                    label_ay.Location = new Point(49, 29);
                    label_ay.Font = new Font("Minion Pro", 21, FontStyle.Bold);
                    
                    break;

                case 8:
                    ay = 8;
                    label_ay.Text = "Ağustos";
                    label_ay.Location = new Point(49, 25);
                    label_ay.Font = new Font("Minion Pro", 23, FontStyle.Bold);
                    break;

                case 9:
                    ay = 9;
                    label_ay.Text = "Eylül";
                    label_ay.Location = new Point(51, 20);
                    label_ay.Font = new Font("Minion Pro", 33, FontStyle.Bold);
                    break;

                case 10:
                    ay = 10;
                    label_ay.Text = "Ekim";
                    label_ay.Location = new Point(51, 20);
                    label_ay.Font = new Font("Minion Pro", 33, FontStyle.Bold);
                    break;

                case 11:
                    ay = 11;
                    label_ay.Text = "Kasım";
                    label_ay.Location = new Point(44, 22);
                    label_ay.Font = new Font("Minion Pro", 30, FontStyle.Bold);
                    break;

                case 12:
                    ay = 12;
                    label_ay.Text = "Aralık";
                    label_ay.Location = new Point(44, 22);
                    label_ay.Font = new Font("Minion Pro", 30, FontStyle.Bold);
                    break;

                case 0:
                    ay = 12;
                    int yil_dus = Convert.ToInt32(label_yil.Text);
                    yil_dus -= 1;
                    label_yil.Text = yil_dus.ToString();
                    label_ay.Text = "Aralık";
                    label_ay.Location = new Point(44, 22);
                    label_ay.Font = new Font("Minion Pro", 30, FontStyle.Bold);
                    break;
                case 13:
                    ay = 1;
                    int yil_dus1 = Convert.ToInt32(label_yil.Text);
                    yil_dus1 += 1;
                    label_yil.Text = yil_dus1.ToString();
                    label_ay.Text = "Ocak";
                    label_ay.Size = new Size(116, 54);
                    label_ay.Font = new Font("Minion Pro", 34, FontStyle.Bold);
                    break;
            }
            string yil_son = label_yil.Text;
            if (ay==1 && yil_son=="2021")
            {
                label3.Enabled = false;
                label3.ForeColor = Color.White;
            }
            else
            {
                label3.Enabled = true;
                label3.ForeColor = Color.DimGray;
            }
            int yil = Convert.ToInt32(label_yil.Text);
            if (yil == 2021)
            {
                label8.Enabled = false;
                label8.ForeColor = Color.White;
            }
            if (yil != 2021 && ay - 1 != 1)
            {
                label8.Enabled = true;
                label8.ForeColor = Color.DimGray;
            }
        }

        // ay çekme fonksiyonu
        public int ay_cekme()
        {
            string month = label_ay.Text;
            int ay=0;
            switch(month)
            {
                case "Ocak":
                    ay = 1;
                    break;
                case "Şubat":
                    ay = 2;
                    break;
                case "Mart":
                    ay = 3;
                    break;
                case "Nisan":
                    ay = 4;
                    break;
                case "Mayıs":
                    ay = 5;
                    break;
                case "Haziran":
                    ay = 6;
                    break;
                case "Temmuz":
                    ay = 7;
                    break;
                case "Ağustos":
                    ay = 8;
                    break;
                case "Eylül":
                    ay = 9;
                    break;
                case "Ekim":
                    ay = 10;
                    break;
                case "Kasım":
                    ay = 11;
                    break;
                case "Aralık":
                    ay = 12;
                    break;
            }
            return ay;
        }                

        // yıl yazma
        public void yil_yaz(string yil)
        {
            label_yil.Text = yil;
            if (yil == "2021")
            {
                label8.Enabled = false;
                label8.ForeColor = Color.White;
                if (label_ay.Text=="Ocak")
                {
                    label3.Enabled = false;
                    label3.ForeColor = Color.White;
                }
            }
            else
            {
                label8.Enabled = true;
                label8.ForeColor = Color.DimGray;
            }
        }
        
        //Ay ve yıl okları
        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.DimGray;
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            label3.ForeColor = Color.WhiteSmoke;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            int month=ay_cekme();
            int ay = month - 1;
            ay_bulma(ay);            
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            label4.ForeColor = Color.WhiteSmoke;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.DimGray;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            int month = ay_cekme();
            int ay = month + 1;
            ay_bulma(ay);            
        }

        private void label8_MouseHover(object sender, EventArgs e)
        {
            label8.ForeColor = Color.WhiteSmoke;
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            label8.ForeColor = Color.DimGray;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            int yil = Convert.ToInt32(label_yil.Text);
            int ay = ay_cekme();
            if (yil == 2021)
            {
                label8.Enabled = false;
                label8.ForeColor = Color.White;
            }
            yil -= 1;
            if (yil == 2021)
            {
                if (ay == 1)
                {
                    label3.Enabled = false;
                    label3.ForeColor = Color.White;
                }
                label8.Enabled = false;
                label8.ForeColor = Color.White;
            }
            label_yil.Text = yil.ToString();
        }

        private void label9_MouseHover(object sender, EventArgs e)
        {
            label9.ForeColor = Color.WhiteSmoke;
        }

        private void label9_MouseLeave(object sender, EventArgs e)
        {
            label9.ForeColor = Color.DimGray;
        }
        
        private void label9_Click(object sender, EventArgs e)
        {
            int yil = Convert.ToInt32(label_yil.Text);
            yil += 1;
            if (yil!=2021)
            {
                label3.Enabled = true;
                label3.ForeColor = Color.DimGray;
                label8.Enabled = true;
                label8.ForeColor = Color.DimGray;
            }
            label_yil.Text = yil.ToString();
        }

        // ay ve yıl formları
        private void label_ay_MouseHover(object sender, EventArgs e)
        {
            label_ay.ForeColor = Color.WhiteSmoke;
        }

        private void label_ay_MouseLeave(object sender, EventArgs e)
        {
            label_ay.ForeColor = Color.Silver;
        }

        private void label_ay_Click(object sender, EventArgs e)
        {
            Aylar ay_form = new Aylar();
            ay_form.ay_gon = new Aylar.ay_gonder(ay_bulma);
            ay_form.Show();
        }

        private void label_yil_MouseHover(object sender, EventArgs e)
        {
            label_yil.ForeColor = Color.WhiteSmoke;
        }

        private void label_yil_MouseLeave(object sender, EventArgs e)
        {
            label_yil.ForeColor = Color.Silver;
        }

        private void label_yil_Click(object sender, EventArgs e)
        {
            Yillar yil_form = new Yillar();
            yil_form.yil_gon = new Yillar.yil_gonder(yil_yaz);
            yil_form.Show();
        }
    }
}
