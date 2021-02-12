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
            dateTimePicker1.Value = DateTime.Now.Date;
            dateTimePicker2.Value = DateTime.Now.AddDays(1);            
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
            dateTimePicker2.Value = DateTime.Now.AddDays(1);
            richTextBox1.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            dateTimePicker1.Focus();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.MinDate = dateTimePicker1.Value.AddDays(1);
            DateTime x = dateTimePicker1.Value;
            DateTime y = dateTimePicker2.Value;
            TimeSpan sonuc = y - x;
            decimal z = Convert.ToDecimal(sonuc.TotalDays);
            textBox3.Text = Math.Floor(z).ToString();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime x = dateTimePicker1.Value;
            DateTime y = dateTimePicker2.Value;
            TimeSpan sonuc = y - x;
            decimal z= Convert.ToDecimal(sonuc.TotalDays);
            textBox3.Text=Math.Floor(z).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text==""||textBox1.Text==""||textBox2.Text=="")
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
                    DateTime bt = dateTimePicker1.Value;
                    planla(bt, hedef, cs, cgs);
                }
                catch (Exception)
                {
                    MessageBox.Show("Lütfen 'Çalışma sayısı' ve 'Çalışma gün sayısı' kısmına bir sayı giriniz");

                }
                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker2.Value = DateTime.Now.AddDays(1);
                richTextBox1.Clear();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                dateTimePicker1.Focus();
                MessageBox.Show("Hedef planlandı");
                dateTimePicker1.Value = DateTime.Now.Date;
                dateTimePicker2.Value = DateTime.Now.AddDays(1);
            }
        }

        // planlar tablosuna hedefleri ekle
        public void planla(DateTime baslangic_tarihi, string hedef, int cs, int cgs)
        {
            string sorgu = " select hedef_id from hedefler where hedef='" + hedef + "'";
            SqlCommand hedef_id_al = new SqlCommand(sorgu, baglanti);
            baglanti.Open();
            string hedef_id2 = hedef_id_al.ExecuteScalar().ToString();
            int hedef_id = Convert.ToInt32(hedef_id2);
            int mod = cs % cgs;
            int calisma_sayisi = cs - mod;
            int z = calisma_sayisi / cgs;

            DateTime gun = dateTimePicker1.Value;
            for (int y = cgs; y > 0; y--)
            {
                string[] day = gun.ToString().Split();
                string ekle_sorgu = "insert into planlar(gun,hedef_id,sayi) values('" + day[0] + "','" + hedef_id + "','"+z+"')";
                SqlCommand plan_ekle = new SqlCommand(ekle_sorgu, baglanti);
                plan_ekle.ExecuteNonQuery();
                gun = gun.AddDays(1);
            }
            if (calisma_sayisi < 1)
            {
                for (int i = 0; i < mod; i++)
                {
                    z++;
                    string[] day = gun.ToString().Split();
                    string ekle_sorgu2 = "insert into planlar(gun,hedef_id,sayi) values('" + day[0] + "','" + hedef_id + "','" + z + "')";
                    SqlCommand plan_ekle2 = new SqlCommand(ekle_sorgu2, baglanti);
                    plan_ekle2.ExecuteNonQuery();
                    gun = gun.AddDays(1);
                    z--;
                }
            }
            else if (calisma_sayisi>0 && mod != 0)
            {
                for (int i = 0; i < mod; i++)
                {
                    string[] day = gun.ToString().Split();
                    string ekle_sorgu2 = "insert into planlar(gun,hedef_id,sayi) values('" + day[0] + "','" + hedef_id + "','" + mod + "')";
                    SqlCommand plan_ekle2 = new SqlCommand(ekle_sorgu2, baglanti);
                    plan_ekle2.ExecuteNonQuery();
                    gun = gun.AddDays(1);
                }
            }
            baglanti.Close();
        }
    }
}
