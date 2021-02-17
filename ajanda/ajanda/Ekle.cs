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
        SqlConnection baglanti2 = new SqlConnection("Data Source=DESKTOP-RCGP0F0\\SQLEXPRESS;Initial Catalog=db_plan;Integrated Security=True");



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

        public void mesaj2()
        {
            MessageBox.Show("Lütfen 'Çalışma sayısı' ve 'Çalışma gün sayısı' kısmına bir sayı giriniz","HATA");
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
                    mesaj2();

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
            try
            {
                string sorgu = " select hedef_id from hedefler where hedef='" + hedef + "'";
                SqlCommand hedef_id_al = new SqlCommand(sorgu, baglanti);
                baglanti.Open();
                string hedef_id2 = hedef_id_al.ExecuteScalar().ToString();
                baglanti.Close();
                int hedef_id = Convert.ToInt32(hedef_id2);
                int mod = cs % cgs;
                int bolunebilir_calisma_sayisi = cs - mod;
                int gunluk_calisma_sayisi = bolunebilir_calisma_sayisi / cgs;
                if (gunluk_calisma_sayisi < 1)
                {
                    gunluk_calisma_sayisi += 1;
                    for (int i = mod; i > 0; i--)
                    {
                        string[] day = baslangic_tarihi.ToString().Split();
                        string ekle_sorgu = "insert into planlar(gun,hedef_id,sayi) values('" + day[0] + "','" + hedef_id + "','" + gunluk_calisma_sayisi + "')";
                        SqlCommand ekle_plan = new SqlCommand(ekle_sorgu, baglanti2);
                        baglanti2.Open();
                        ekle_plan.ExecuteNonQuery();
                        baglanti2.Close();
                        baslangic_tarihi = baslangic_tarihi.AddDays(1);
                    }
                }
                else
                {
                    if (mod==0)
                    {
                        for (int i = cgs; i > 0; i--)
                        {
                            string[] day = baslangic_tarihi.ToString().Split();
                            string ekle_sorgu = "insert into planlar(gun,hedef_id,sayi) values('" + day[0] + "','" + hedef_id + "','" + gunluk_calisma_sayisi + "')";
                            SqlCommand ekle_plan = new SqlCommand(ekle_sorgu, baglanti2);
                            baglanti2.Open();
                            ekle_plan.ExecuteNonQuery();
                            baglanti2.Close();
                            baslangic_tarihi = baslangic_tarihi.AddDays(1);
                        }
                    }
                    else
                    {
                        for (int i = cgs; i > 0; i--)
                        {
                            if (mod!=0)
                            {
                                gunluk_calisma_sayisi += 1;
                            }
                            string[] day = baslangic_tarihi.ToString().Split();
                            string ekle_sorgu = "insert into planlar(gun,hedef_id,sayi) values('" + day[0] + "','" + hedef_id + "','" + gunluk_calisma_sayisi + "')";
                            SqlCommand ekle_plan = new SqlCommand(ekle_sorgu, baglanti2);
                            baglanti2.Open();
                            ekle_plan.ExecuteNonQuery();
                            baglanti2.Close();
                            gunluk_calisma_sayisi -=1;
                            mod--;
                            baslangic_tarihi = baslangic_tarihi.AddDays(1);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }            
        }                
    }
}
