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
        SqlConnection baglanti= new SqlConnection("Data Source=DESKTOP-RCGP0F0\\SQLEXPRESS;Initial Catalog=db_plan;Integrated Security=True");
        public Anasayfa()
        {
            InitializeComponent();
        }
        
        //bugünün ya da istenilen ayı bulma fonksiyonu
        public void ay_bulma(int ay)
        {            
            switch (ay)
            {
                case 1:
                    ay = 1;
                    label2.Size = new Size(116, 54);
                    label2.Font = new Font("Minion Pro", 34, FontStyle.Bold);
                    label2.Text = "Ocak";                    
                    break;

                case 2:
                    ay = 2;
                    label2.Size = new Size(127, 54);
                    label2.Font = new Font("Minion Pro", 34, FontStyle.Bold);
                    label2.Text = "Şubat";
                    break;

                case 3:
                    ay = 3;
                    label2.Size = new Size(113, 54);
                    label2.Font = new Font("Minion Pro", 34, FontStyle.Bold);
                    label2.Text = "Mart";
                    break;

                case 4:
                    ay = 4;
                    label2.Size = new Size(115, 48);
                    label2.Font = new Font("Minion Pro", 30, FontStyle.Bold);
                    label2.Text = "Nisan";
                    break;

                case 5:
                    ay = 5;
                    label2.Size = new Size(117, 48);
                    label2.Font = new Font("Minion Pro", 30, FontStyle.Bold);
                    label2.Text = "Mayıs";
                    break;

                case 6:
                    ay = 6;
                    label2.Location = new Point(49, 26);
                    label2.Font = new Font("Minion Pro", 23, FontStyle.Bold);
                    label2.Text = "Haziran";
                    break;

                case 7:
                    ay = 7;
                    label2.Location = new Point(49, 29);
                    label2.Font = new Font("Minion Pro", 21, FontStyle.Bold);
                    label2.Text = "Temmuz";
                    break;

                case 8:
                    ay = 8;
                    label2.Location = new Point(49, 25);
                    label2.Font = new Font("Minion Pro", 23, FontStyle.Bold);
                    label2.Text = "Ağustos";
                    break;

                case 9:
                    ay = 9;
                    label2.Location = new Point(51, 20);
                    label2.Font = new Font("Minion Pro", 33, FontStyle.Bold);
                    label2.Text = "Eylül";
                    break;

                case 10:
                    ay = 10;
                    label2.Location = new Point(51, 20);
                    label2.Font = new Font("Minion Pro", 33, FontStyle.Bold);
                    label2.Text = "Ekim";
                    break;

                case 11:
                    ay = 11;
                    label2.Location = new Point(44, 22);
                    label2.Font = new Font("Minion Pro", 30, FontStyle.Bold);
                    label2.Text = "Kasım";
                    break;

                case 12:
                    ay = 12;
                    label2.Location = new Point(44, 22);
                    label2.Font = new Font("Minion Pro", 30, FontStyle.Bold);
                    label2.Text = "Aralık";
                    break;

                case 0:
                    ay = 12;
                    int yil_dus = Convert.ToInt32(label1.Text);
                    yil_dus -= 1;
                    label1.Text = yil_dus.ToString();
                    label2.Location = new Point(44, 22);
                    label2.Font = new Font("Minion Pro", 30, FontStyle.Bold);
                    label2.Text = "Aralık";
                    break;
                case 13:
                    ay = 1;
                    int yil_dus1 = Convert.ToInt32(label1.Text);
                    yil_dus1 += 1;
                    label1.Text = yil_dus1.ToString();
                    label2.Size = new Size(116, 54);
                    label2.Font = new Font("Minion Pro", 34, FontStyle.Bold);
                    label2.Text = "Ocak";
                    break;
            }
            string yil_son = label1.Text;
            if (ay==1 && yil_son=="2021")
            {
                label3.Enabled = false;
                label3.ForeColor = Color.LightGray;
            }
            else
            {
                label3.Enabled = true;
                label3.ForeColor = Color.SteelBlue;
            }
        }

        // ay çekme fonksiyonu
        public int ay_cekme()
        {
            string month = label2.Text;
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
        
        private void Anasayfa_Load(object sender, EventArgs e)
        {
            string yil = DateTime.Now.Year.ToString();
            string yil_sorgu="select yil from yillar where yil='"+yil+"'";
            label1.Text = yil;
            SqlCommand yil_sor = new SqlCommand(yil_sorgu,baglanti);
            baglanti.Open();
            
            if (yil_sor.ExecuteScalar()==null)
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

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.SteelBlue;
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            label3.ForeColor = Color.LightGray;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            int month=ay_cekme();
            int ay = month - 1;
            ay_bulma(ay);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            int month = ay_cekme();
            int ay = month + 1;
            ay_bulma(ay);
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            label4.ForeColor = Color.LightGray;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.SteelBlue;
        }
    }
}
