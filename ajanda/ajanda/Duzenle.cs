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
    public partial class Duzenle : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-RCGP0F0\\SQLEXPRESS;Initial Catalog=db_plan;Integrated Security=True");
        SqlConnection baglanti2 = new SqlConnection("Data Source=DESKTOP-RCGP0F0\\SQLEXPRESS;Initial Catalog=db_plan;Integrated Security=True");
        
        public Duzenle()
        {
            InitializeComponent();
        }

        private void Duzenle_Load(object sender, EventArgs e)
        {

        }

        public void mesaj()
        {
            string baslik = "HATA";
            string uyari = "Lütfen tüm alanları doldurunuz";
            MessageBox.Show(uyari, baslik);
        }

        public void mesaj2()
        {
            MessageBox.Show("Lütfen 'Çalışma sayısı' ve 'Çalışma gün sayısı' kısmına bir sayı giriniz");
        }

        public void plan_duzenle(string hedef_id)
        {
            button1.Name = hedef_id;
            string sorgu = "select baslangic_tarihi from hedefler where hedef_id='" + hedef_id + "'";
            SqlCommand duzenle = new SqlCommand(sorgu, baglanti);
            baglanti.Open();
            string[] baslangic_tarihi = duzenle.ExecuteScalar().ToString().Split('.');
            baglanti.Close();
            DateTime baslangic = new DateTime(
                Convert.ToInt32(baslangic_tarihi[2]),
                Convert.ToInt32(baslangic_tarihi[1]),
                Convert.ToInt32(baslangic_tarihi[0])
                );
            dateTimePicker1.Value = baslangic.AddDays(0);

            string sorgu2 = "select bitis_tarihi from hedefler where hedef_id='" + hedef_id + "'";
            SqlCommand bitis_sorgu = new SqlCommand(sorgu2, baglanti);
            baglanti.Open();
            string[] bitis_tarihi = bitis_sorgu.ExecuteScalar().ToString().Split('.');
            baglanti.Close();

            DateTime bitis = new DateTime(
                Convert.ToInt32(bitis_tarihi[2]),
                Convert.ToInt32(bitis_tarihi[1]),
                Convert.ToInt32(bitis_tarihi[0])
                );
            dateTimePicker2.Value = bitis.AddDays(0);

            string sorgu3 = "select hedef from hedefler where hedef_id='" + hedef_id + "'";
            SqlCommand hedef_sorgu = new SqlCommand(sorgu3, baglanti);
            baglanti.Open();
            string hedef = hedef_sorgu.ExecuteScalar().ToString();
            richTextBox1.Text = hedef;
            baglanti.Close();

            string sorgu4 = "select calisma_sekli from hedefler where hedef_id='" + hedef_id + "'";
            SqlCommand calisma_sekli_sorgu = new SqlCommand(sorgu4, baglanti);
            baglanti.Open();
            string calisma_sekli = calisma_sekli_sorgu.ExecuteScalar().ToString();
            textBox1.Text = calisma_sekli;
            baglanti.Close();

            string sorgu5 = "select calisma_sayisi from hedefler where hedef_id='" + hedef_id + "'";
            SqlCommand calisma_sayisi_sorgu = new SqlCommand(sorgu5, baglanti);
            baglanti.Open();
            string calisma_sayisi = calisma_sayisi_sorgu.ExecuteScalar().ToString();
            textBox2.Text = calisma_sayisi;
            baglanti.Close();

            string sorgu6 = "select gun_sayisi from hedefler where hedef_id='" + hedef_id + "'";
            SqlCommand gun_sayisi_sorgu = new SqlCommand(sorgu6, baglanti);
            baglanti.Open();
            string gun_sayisi = gun_sayisi_sorgu.ExecuteScalar().ToString();
            textBox3.Text = gun_sayisi;
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "" || textBox1.Text == "" || textBox2.Text == "")
            {
                mesaj();
            }
            else
            {
                string hedef_id = (sender as Button).Name;
                string[] baslangic_tarihi = dateTimePicker1.Value.ToString().Split();
                string[] bitis_tarihi = dateTimePicker2.Value.ToString().Split();
                string hedef = richTextBox1.Text;
                string calisma_sekli = textBox1.Text;
                string calisma_sayisi = textBox2.Text;
                string calisma_gun_sayisi = textBox3.Text;
                string sorgu = "update hedefler set baslangic_tarihi='" + baslangic_tarihi[0] + "', bitis_tarihi='" +
                    bitis_tarihi[0] + "', hedef='" + hedef + "', calisma_sekli='" + calisma_sekli + "', calisma_sayisi='" +
                    calisma_sayisi + "', gun_sayisi='" + calisma_gun_sayisi + "' where hedef_id='" + hedef_id + "'";
                try
                {
                    int cs = Convert.ToInt32(textBox2.Text);
                    int cgs = Convert.ToInt32(textBox3.Text);
                    SqlCommand guncelle = new SqlCommand(sorgu, baglanti);
                    baglanti.Open();
                    guncelle.ExecuteNonQuery();
                    baglanti.Close();
                    string sorgu2 = "delete from planlar where hedef_id='" + hedef_id + "'";
                    SqlCommand sil = new SqlCommand(sorgu2, baglanti2);
                    baglanti2.Open();
                    sil.ExecuteNonQuery();
                    baglanti2.Close();
                    DateTime bt = dateTimePicker1.Value;
                    Ekle ekle_form = new Ekle();
                    ekle_form.planla(bt,hedef, cs, cgs);
                }
                catch (Exception w)
                {
                    MessageBox.Show(w.ToString());

                }
                MessageBox.Show("Hedef güncellendi");
                this.Close();
            }           
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
            decimal z = Convert.ToDecimal(sonuc.TotalDays);
            textBox3.Text = Math.Floor(z).ToString();
        }
    }
}
