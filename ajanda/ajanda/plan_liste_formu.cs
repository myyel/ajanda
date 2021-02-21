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
    public partial class Plan_liste_formu : Form
    {
        public SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-RCGP0F0\\SQLEXPRESS;Initial Catalog=db_plan;Integrated Security=True");
        public SqlConnection baglanti2 = new SqlConnection("Data Source=DESKTOP-RCGP0F0\\SQLEXPRESS;Initial Catalog=db_plan;Integrated Security=True");
        public SqlConnection baglanti3 = new SqlConnection("Data Source=DESKTOP-RCGP0F0\\SQLEXPRESS;Initial Catalog=db_plan;Integrated Security=True");
        public SqlConnection baglanti4 = new SqlConnection("Data Source=DESKTOP-RCGP0F0\\SQLEXPRESS;Initial Catalog=db_plan;Integrated Security=True");
        public DataTable sanal_tablo = new DataTable();

        public Plan_liste_formu()
        {
            InitializeComponent();
        }

        public void plan_liste_formu_Load(object sender, EventArgs e)
        {
            this.DesktopLocation = new Point(1107, 111);
        }

        public void plan_liste(string tarih)
        {
            label_time.Show();
            label_deger.Show();
            progressBar1.Show();
            try
            {
                string sorgu7 = "select gun_degerlendirme from degerlendirmeler where tarih='" + tarih + "'";
                SqlCommand degerlen_al = new SqlCommand(sorgu7, baglanti4);
                baglanti4.Open();
                string degerlen = degerlen_al.ExecuteScalar().ToString();
                baglanti4.Close();
                label_deger.Text = degerlen;
                prog_goster(degerlen);
            }
            catch (Exception)
            {

            }
            try
            {
                int i = 0;
                int i2 = 0;
                int i3 = 0;
                int j = 1;

                string sorgu = "select hedef_id from planlar where gun= '" + tarih + "'";
                SqlCommand hedef_id_sorgu = new SqlCommand(sorgu, baglanti);
                baglanti.Open();
                IDataReader his = hedef_id_sorgu.ExecuteReader();
                while (his.Read())
                {
                    string hedef_ids = his[0].ToString();
                    string sorgu2 = "select hedef from hedefler where hedef_id='" + hedef_ids + "'";
                    SqlCommand hedef_sorgu = new SqlCommand(sorgu2, baglanti2);
                    baglanti2.Open();
                    string hedefs = hedef_sorgu.ExecuteScalar().ToString();
                    baglanti2.Close();
                    if (hedef_ids != null)
                    {

                        string sorgu3 = "select calisma_sekli from hedefler where hedef_id='" + hedef_ids + "'";
                        SqlCommand calisma_sekli_sorgu = new SqlCommand(sorgu3, baglanti3);
                        baglanti3.Open();
                        string calisma_seklis = calisma_sekli_sorgu.ExecuteScalar().ToString();
                        baglanti3.Close();
                        string sorgu4 = "select sayi from planlar where gun='" + tarih + "' and hedef_id='" + hedef_ids + "'";
                        SqlCommand sayi_sorgu = new SqlCommand(sorgu4, baglanti4);
                        baglanti4.Open();
                        string sayis = sayi_sorgu.ExecuteScalar().ToString();
                        baglanti4.Close();
                        string sorgu5 = "select deger from planlar where gun='" + tarih + "' and hedef_id='" + hedef_ids + "'";
                        SqlCommand deger_sorgu = new SqlCommand(sorgu5, baglanti4);
                        baglanti4.Open();
                        string deger = deger_sorgu.ExecuteScalar().ToString();
                        baglanti4.Close();
                        string name = hedefs + " (" + sayis + " " + calisma_seklis + ")";
                        string hedef_tarih = hedef_ids + " " + tarih;

                        CheckBox checks = new CheckBox();
                        checks.Name = name;
                        checks.Text = hedef_tarih;
                        checks.AutoSize = false;
                        checks.Appearance = Appearance.Button;
                        checks.AutoCheck = false;
                        checks.AutoEllipsis = true;
                        checks.Checked = false;
                        checks.BackColor = Color.WhiteSmoke;
                        checks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        checks.FlatAppearance.BorderSize = 1;
                        checks.FlatAppearance.BorderColor = Color.Black;
                        checks.FlatAppearance.CheckedBackColor = System.Drawing.ColorTranslator.FromHtml("#c99e7e");
                        checks.Location = new Point(59, 75+i);
                        checks.Size = new Size(15, 15);
                        checks.TabStop = false;
                        if (deger == "1")
                        {
                            checks.Checked = true;
                        }
                        this.Controls.Add(checks);
                        checks.Click += new EventHandler(cheks_click);

                        Label labels = new Label();
                        labels.Text = name;
                        labels.BackColor = Color.Transparent;
                        labels.AutoSize = false;
                        labels.ForeColor = Color.WhiteSmoke;                        
                        labels.Font = new Font("Swis721 BlkCn BT", 14 );
                        labels.Location = new Point(77, 65 + i);
                        labels.TabStop = false;
                        labels.Size = new Size(237, 32);
                        labels.TextAlign = ContentAlignment.MiddleLeft;
                        if (deger == "1")
                        {
                            labels.ForeColor = System.Drawing.ColorTranslator.FromHtml("#c99e7e");
                        }
                        this.Controls.Add(labels);
                        i += 38;

                        Label label_no = new Label();
                        label_no.Name = name;
                        label_no.Text = j.ToString();
                        label_no.BackColor = Color.Transparent;
                        label_no.AutoSize = false;
                        label_no.ForeColor = Color.WhiteSmoke;
                        label_no.Font = new Font("Arial Rounded MT Bold", 20);
                        label_no.Location = new Point(1, 63 + i2);
                        label_no.TabStop = false;
                        label_no.Size = new Size(50, 32);
                        label_no.TextAlign = ContentAlignment.MiddleCenter;
                        if (deger == "1")
                        {
                            label_no.ForeColor = System.Drawing.ColorTranslator.FromHtml("#c99e7e");
                        }
                        this.Controls.Add(label_no);
                        i2 += 38;
                        j += 1;

                        Button butons1 = new Button();
                        butons1.Name = hedef_ids;
                        butons1.Text = "Düzenle";
                        butons1.BackColor = Color.Transparent;
                        butons1.ForeColor = Color.Silver;
                        butons1.Font = new Font("Microsoft Sans Serif Bold", 6);
                        butons1.Location = new Point(330, 59 + i3);
                        butons1.TabStop = true;
                        butons1.TabIndex = j;
                        butons1.Size = new Size(52, 38);
                        butons1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        butons1.FlatAppearance.BorderSize = 1;
                        butons1.FlatAppearance.MouseOverBackColor = Color.Snow;
                        this.Controls.Add(butons1);
                        butons1.Click += new EventHandler(duzenle);

                        Button butons2 = new Button();
                        butons2.Name = labels.Text;
                        butons2.Text = "Sil";
                        butons2.BackColor = Color.Transparent;
                        butons2.ForeColor = Color.Silver;
                        butons2.Font = new Font("Microsoft Sans Serif Bold", 6);
                        butons2.Location = new Point(382, 59 + i3);
                        butons2.TabStop = true;
                        butons2.TabIndex = j;
                        butons2.Size = new Size(52, 38);
                        butons2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        butons2.FlatAppearance.BorderSize = 1;
                        butons2.FlatAppearance.MouseOverBackColor = Color.Snow;
                        this.Controls.Add(butons2);
                        i3 += 39;
                        butons2.Click += new EventHandler(veri_sil);
                    }
                }
                baglanti.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                baglanti.Close();
            }
        }

        public void duzenle(object sender, EventArgs e)
        {
            this.Close();
            string hedef_id = (sender as Button).Name;
            Duzenle duzenle_form = new Duzenle();
            duzenle_form.plan_duzenle(hedef_id);
            duzenle_form.Show();
        }

        public void veri_sil(object sender, EventArgs e)
        {
            string time = label_time.Text;
            DialogResult secenek = MessageBox.Show("Planı Silmek İstiyor musunuz?", "Bilgilendirme Penceresi",
            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            string[] hedef = (sender as Button).Name.Split();
            string sorgu_id = "select hedef_id from hedefler where hedef='" + hedef[0] + "'";
            SqlCommand id_al = new SqlCommand(sorgu_id, baglanti);
            baglanti.Open();
            int hedef_id = Convert.ToInt32(id_al.ExecuteScalar());
            baglanti.Close();
            string sorgu1 = "select baslangic_tarihi from hedefler where hedef_id='" + hedef_id.ToString() + "'";
            SqlCommand bas_tarih_al = new SqlCommand(sorgu1, baglanti3);
            baglanti3.Open();
            string[] bas_tarih = bas_tarih_al.ExecuteScalar().ToString().Split('.');
            baglanti3.Close();

            string sorgu2 = "select bitis_tarihi from hedefler where hedef_id='" + hedef_id.ToString() + "'";
            SqlCommand bit_tarih_al = new SqlCommand(sorgu2, baglanti3);
            baglanti3.Open();
            string[] bit_tarih = bit_tarih_al.ExecuteScalar().ToString().Split('.');
            baglanti3.Close();

            if (secenek == DialogResult.Yes)
            {
                string sorgu = "delete from hedefler where hedef='" + hedef[0] + "'";
                SqlCommand hedef_sorgu = new SqlCommand(sorgu, baglanti2);
                baglanti2.Open();
                hedef_sorgu.ExecuteNonQuery();
                baglanti2.Close();
                Duzenle duzen_form = new Duzenle();
                duzen_form.duzen_gun_degerlendirme(bas_tarih, bit_tarih);
                string[] day = label_time.Text.Split();
                string month = "";
                switch (day[1])
                {
                    case "Ocak":
                        month = "01";
                        break;
                    case "Şubat":
                        month = "02";
                        break;
                    case "Mart":
                        month = "03";
                        break;
                    case "Nisan":
                        month = "04";
                        break;
                    case "Mayıs":
                        month = "05";
                        break;
                    case "Haziran":
                        month = "06";
                        break;
                    case "Temmuz":
                        month = "07";
                        break;
                    case "Ağustos":
                        month = "08";
                        break;
                    case "Eylül":
                        month = "09";
                        break;
                    case "Ekim":
                        month = "10";
                        break;
                    case "Kasım":
                        month = "11";
                        break;
                    case "Aralık":
                        month = "12";
                        break;
                }
                string tarih = day[0] + "." + month + "." + day[2];
                this.Controls.Clear();
                this.Controls.Add(label_deger);
                this.Controls.Add(progressBar1);
                this.Controls.Add(label_time);
                label_time.Text = time;
                label_time.Show();

                plan_liste(tarih);
                MessageBox.Show("Plan silinmiştir");
            }

        }

        public void hovers(string name)
        {
            foreach (Control item in this.Controls)
            {
                if (item is Label)
                {
                    if (item.Text==name)
                    {
                        if (item.ForeColor == Color.WhiteSmoke)
                        {
                            item.ForeColor = System.Drawing.ColorTranslator.FromHtml("#c99e7e");
                        }
                        else
                        {
                            item.ForeColor = Color.WhiteSmoke;
                        }
                    }
                    else if (item.Name==name)
                    {
                        if (item.ForeColor == Color.WhiteSmoke)
                        {
                            item.ForeColor = System.Drawing.ColorTranslator.FromHtml("#c99e7e");
                        }
                        else
                        {
                            item.ForeColor = Color.WhiteSmoke;
                        }
                    }
                }

            }
        }

        private void cheks_click(object sender, EventArgs e)
        {
            string[] hedef = (sender as CheckBox).Text.Split();
            string sorgu = "select deger from planlar where hedef_id='" + hedef[0] + "' and gun='" + hedef[1] + "'";
            SqlCommand deger_al = new SqlCommand(sorgu, baglanti2);
            baglanti2.Open();
            int deger = Convert.ToInt32(deger_al.ExecuteScalar());
            baglanti2.Close();
            if (deger == 0)
            {
                deger = 1;
                string sorgu2 = "update planlar set deger='" + deger + "' where hedef_id='" + hedef[0] + "' and gun='" + hedef[1] + "'";
                SqlCommand deger_update = new SqlCommand(sorgu2, baglanti3);
                baglanti3.Open();
                deger_update.ExecuteNonQuery();
                baglanti3.Close();

                string sorgu1 = "select baslangic_tarihi from hedefler where hedef_id='" + hedef[0] + "'";
                SqlCommand bas_tarih_al = new SqlCommand(sorgu1, baglanti2);
                baglanti2.Open();
                string[] bas_tarih = bas_tarih_al.ExecuteScalar().ToString().Split('.');
                baglanti2.Close();

                string sorgu3 = "select bitis_tarihi from hedefler where hedef_id='" + hedef[0] + "'";
                SqlCommand bit_tarih_al = new SqlCommand(sorgu3, baglanti3);
                baglanti3.Open();
                string[] bit_tarih = bit_tarih_al.ExecuteScalar().ToString().Split('.');
                baglanti3.Close();
                Ekle ekle_form = new Ekle();
                ekle_form.gun_degerlendirme(bas_tarih, bit_tarih);

                string sorgu4 = "select gun_degerlendirme from degerlendirmeler where tarih='" + hedef[1] + "'";
                SqlCommand degerlen_al = new SqlCommand(sorgu4, baglanti4);
                baglanti4.Open();
                string degerlen = degerlen_al.ExecuteScalar().ToString();
                baglanti4.Close();
                label_deger.Text = degerlen;

                prog_goster(degerlen);
            }
            else if (deger == 1)
            {
                deger = 0;
                string sorgu2 = "update planlar set deger='" + deger + "' where hedef_id='" + hedef[0] + "' and gun='" + hedef[1] + "'";
                SqlCommand deger_update = new SqlCommand(sorgu2, baglanti3);
                baglanti3.Open();
                deger_update.ExecuteNonQuery();
                baglanti3.Close();

                string sorgu1 = "select baslangic_tarihi from hedefler where hedef_id='" + hedef[0] + "'";
                SqlCommand bas_tarih_al = new SqlCommand(sorgu1, baglanti2);
                baglanti2.Open();
                string[] bas_tarih = bas_tarih_al.ExecuteScalar().ToString().Split('.');
                baglanti2.Close();

                string sorgu3 = "select bitis_tarihi from hedefler where hedef_id='" + hedef[0] + "'";
                SqlCommand bit_tarih_al = new SqlCommand(sorgu3, baglanti3);
                baglanti3.Open();
                string[] bit_tarih = bit_tarih_al.ExecuteScalar().ToString().Split('.');
                baglanti3.Close();
                Ekle ekle_form = new Ekle();
                ekle_form.gun_degerlendirme(bas_tarih, bit_tarih);

                string sorgu4 = "select gun_degerlendirme from degerlendirmeler where tarih='" + hedef[1] + "'";
                SqlCommand degerlen_al = new SqlCommand(sorgu4, baglanti4);
                baglanti4.Open();
                string degerlen = degerlen_al.ExecuteScalar().ToString();
                baglanti4.Close();
                label_deger.Text = degerlen;

                prog_goster(degerlen);
            }
            else
            {
                MessageBox.Show("Beklenmeyen bir hata oluştu. Hatalı olan bu hedef silinmiştir. Lütfen hedefi tekrar baştan planlayınız...", "HATA");
                string sorgu2 = "delete from hedefler where hedef_id='" + hedef[0] + "'";
                SqlCommand deger_update = new SqlCommand(sorgu2, baglanti3);
                baglanti3.Open();
                deger_update.ExecuteNonQuery();
                baglanti3.Close();
            }

            if ((sender as CheckBox).Checked==true)
            {
                (sender as CheckBox).Checked = false;
                string name = (sender as CheckBox).Name;
                hovers(name);
            }
            else
            {
                (sender as CheckBox).Checked = true;
                string name = (sender as CheckBox).Name;
                hovers(name);
            }
        }

        public void prog_goster(string deger)
        {
            string[] degers = deger.Split(',');
            int sayi = Convert.ToInt32(degers[0]);
            progressBar1.ForeColor= System.Drawing.ColorTranslator.FromHtml("#c99e7e");
            progressBar1.Value = sayi;
        }
    }
}
