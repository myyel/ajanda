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
        SqlConnection baglanti3 = new SqlConnection("Data Source=DESKTOP-RCGP0F0\\SQLEXPRESS;Initial Catalog=db_plan;Integrated Security=True");
        SqlConnection baglanti4 = new SqlConnection("Data Source=DESKTOP-RCGP0F0\\SQLEXPRESS;Initial Catalog=db_plan;Integrated Security=True");


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
                    MessageBox.Show("Hedef planlandı");
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

                string sorgu1 = "select baslangic_tarihi from hedefler where hedef_id='" + hedef_id + "'";
                SqlCommand bas_tarih_al = new SqlCommand(sorgu1, baglanti2);
                baglanti2.Open();
                string[] bas_tarih = bas_tarih_al.ExecuteScalar().ToString().Split('.');
                baglanti2.Close();

                string sorgu2 = "select bitis_tarihi from hedefler where hedef_id='" + hedef_id + "'";
                SqlCommand bit_tarih_al = new SqlCommand(sorgu2, baglanti3);
                baglanti3.Open();
                string[] bit_tarih = bit_tarih_al.ExecuteScalar().ToString().Split('.');
                baglanti3.Close();
                gun_degerlendirme(bas_tarih, bit_tarih);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        // gün değerlendirme
        public void gun_degerlendirme(string[] bas_tarih, string[] bit_tarih)
        {
            int bas_yil = Convert.ToInt32(bas_tarih[2]);
            int bit_yil = Convert.ToInt32(bit_tarih[2]);
            int bas_ay = Convert.ToInt32(bas_tarih[1]);
            int bit_ay = Convert.ToInt32(bit_tarih[1]);
            int bas_gun = Convert.ToInt32(bas_tarih[0]);
            int bit_gun = Convert.ToInt32(bit_tarih[0]);

            DateTime baslangic_tarihi = new DateTime(bas_yil, bas_ay, bas_gun);
            DateTime bitis_tarihi = new DateTime(bit_yil,bit_ay, bit_gun);

            while (baslangic_tarihi<bitis_tarihi)
            {
                string[] gun = baslangic_tarihi.ToString().Split();
                string sorgu3 = "select sum(sayi) from planlar where gun='" + gun[0] + "'";
                SqlCommand sayi_al = new SqlCommand(sorgu3, baglanti4);
                baglanti4.Open();
                decimal sayi_toplam = Convert.ToDecimal(sayi_al.ExecuteScalar().ToString());
                baglanti4.Close();

                string sorgu4 = "select sum(sayi*deger) from planlar where gun='" + gun[0] + "'";
                SqlCommand deger_al = new SqlCommand(sorgu4, baglanti2);
                baglanti2.Open();
                decimal deger_toplam = Convert.ToDecimal(deger_al.ExecuteScalar().ToString());
                baglanti2.Close();

                decimal gun_degerlendirmes = ((deger_toplam / sayi_toplam) * 100);
                
                string sorgu5 = "update degerlendirmeler set gun_degerlendirme='" + gun_degerlendirmes.ToString().Replace(',', '.') + "' where tarih='"+gun[0]+"'";
                SqlCommand guncelle_deger = new SqlCommand(sorgu5, baglanti3);
                baglanti3.Open();
                guncelle_deger.ExecuteNonQuery();
                baglanti3.Close();

                baslangic_tarihi = baslangic_tarihi.AddDays(1);
            }
        }
    }
}
