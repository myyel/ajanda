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
    public partial class Ekle : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-RCGP0F0\\SQLEXPRESS;Initial Catalog=db_plan;Integrated Security=True");

        public Ekle()
        {
            InitializeComponent();
        }
        private void Ekle_Load(object sender, EventArgs e)
        {
            
        }

        public void mesaj()
        {
            string baslik = "HATA";
            string uyari = "Lütfen tüm alanları doldurunuz";
            MessageBox.Show(uyari, baslik);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            richTextBox1.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            dateTimePicker1.Focus();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.MinDate = dateTimePicker1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text==""||textBox1.Text==""||textBox2.Text==""||textBox3.Text=="")
            {
                mesaj();
            }
            else
            {
                string[] baslangic_tarihi = dateTimePicker1.Value.ToString().Split();
                string[] bitis_tarihi = dateTimePicker2.Value.ToString().Split();
                string hedef = richTextBox1.Text;
                string calisma_sekli = textBox1.Text;
                string calisma_sayisi = textBox2.Text;
                string calisma_gun_sayisi = textBox3.Text;
                string hedef_yaz = "insert into hedefler(baslangic_tarihi, bitis_tarihi, hedef, calisma_sekli, calisma_sayisi, gun_sayisi) " +
                "values('" + baslangic_tarihi[0] + "', '" + bitis_tarihi[0] + "', '" + hedef + "', '" + calisma_sekli + "', '"
                + calisma_sayisi + "','" + calisma_gun_sayisi + "')";

                try
                {
                    int cs = Convert.ToInt32(textBox2.Text);
                    int cgs = Convert.ToInt32(textBox3.Text);
                    SqlCommand hedef_ekle = new SqlCommand(hedef_yaz, baglanti);
                    baglanti.Open();
                    hedef_ekle.ExecuteNonQuery();
                    baglanti.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lütfen 'Çalışma sayısı' ve 'Çalışma gün sayısı' kısmına bir sayı giriniz");

                }
                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker2.Value = DateTime.Now;
                richTextBox1.Clear();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                dateTimePicker1.Focus();
                MessageBox.Show("Hedef planlandı");
            }
        }
    }
}
