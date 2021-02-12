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
        public SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-RCGP0F0\\SQLEXPRESS;Initial Catalog=db_plan;Integrated Security=True");
        public SqlConnection baglanti2 = new SqlConnection("Data Source=DESKTOP-RCGP0F0\\SQLEXPRESS;Initial Catalog=db_plan;Integrated Security=True");
        public SqlConnection baglanti3 = new SqlConnection("Data Source=DESKTOP-RCGP0F0\\SQLEXPRESS;Initial Catalog=db_plan;Integrated Security=True");
        public SqlConnection baglanti4 = new SqlConnection("Data Source=DESKTOP-RCGP0F0\\SQLEXPRESS;Initial Catalog=db_plan;Integrated Security=True");
        public DataTable sanal_tablo = new DataTable();

        public Anasayfa()
        {
            InitializeComponent();
        }

        // Anasayfa load
        public void Anasayfa_Load(object sender, EventArgs e)
        {
            this.Size = new Size(788, 818);
            int gun = DateTime.Now.Day;
            butons_tabs_ana(gun);
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
            int ay = Convert.ToInt32(DateTime.Now.Month);
            baglanti.Close();
            ay_bulma(ay);
            label_goster(gun);
            
        }

        // anasayfa büyümesi, gösterilecek gün label ve yapılacaklar listesi
        public void anasayfa_list()
        {
                ekle.Location = new Point(1142, 680);
                this.Size = new Size(1250, 818);

        }

        //buton click olayında
        public void butons_clicked(object sender, EventArgs e)
        {
            string ad = (sender as Button).Name;
            char ad1 = ad[6];
            char ad2 = ad[7];
            int gun = Convert.ToInt32((sender as Button).Text);
            string day = (sender as Button).Text;
            label_goster3(gun, ad1, ad2);
            plan_listele(day);
            butons_tabs(gun);
            anasayfa_list();
        }


        // plan listesini anasayfaya aktarma
        public void plan_listele(string day)
        {
            int s = 0;
            while (s<10)
            {
                checks_sil();
                s++;
            }
            string ay = label_ay.Text;
            string month = "";
            switch (ay)
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
            string year = label_yil.Text;
            string gun = label_gun.Text;
            label_time.Text = day + " " + ay + " " + year + "   " + gun;
            string tarih = day + "." + month + "." + year;
            try
            {
                int i = 0;
                string sorgu = "select hedef_id from planlar where gun= '" + tarih + "'";
                SqlCommand hedef_id_sorgu = new SqlCommand(sorgu, baglanti);
                baglanti.Open();
                IDataReader his = hedef_id_sorgu.ExecuteReader();
                while (his.Read())
                {
                    string hedef_ids = his[0].ToString();
                    string sorgu2 = "select hedef from hedefler where hedef_id='" + hedef_ids + "'";
                    SqlCommand hedef_sorgu = new SqlCommand(sorgu2,baglanti2);
                    baglanti2.Open();
                    string hedefs = hedef_sorgu.ExecuteScalar().ToString();
                    baglanti2.Close();
                    if (hedef_ids!=null)
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
                        string name = hedefs + " (" + sayis + " " + calisma_seklis + ")";
                        CheckBox checks = new CheckBox();
                        checks.Text = name;
                        checks.BackColor = Color.Transparent;
                        checks.ForeColor = Color.Black;
                        checks.Font = new Font("Arial Rounded MT Bold", 14);
                        checks.Location = new Point(836, 121 + i);
                        checks.TabStop = false;
                        checks.Size = new Size(359, 24);
                        checks.TextAlign = ContentAlignment.MiddleLeft;
                        this.Controls.Add(checks);
                        i += 30;
                        checks.CheckedChanged += new EventHandler(checks_checked);
                        checks.Click += new EventHandler(plan_sil);
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

        public void checks_checked(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked==true)
            {
                (sender as CheckBox).ForeColor = Color.DarkBlue;
            }
            else
            {
                (sender as CheckBox).ForeColor = Color.Black;
            }
        }

        public void checks_sil()
        {
            foreach (Control item in this.Controls)
            {
                if(item is CheckBox)
                {
                    this.Controls.Remove(item);
                }
            }
        }

        public void plan_sil(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Planı Silmek İstiyor musunuz?", "Bilgilendirme Penceresi", 
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

            if (secenek == DialogResult.Yes)
            {
                string[] hedef = (sender as CheckBox).Text.Split();
                string sorgu="select hedef_id from hedefler where hedef='"+hedef[0]+"'";
                SqlCommand hedef_sorgu = new SqlCommand(sorgu, baglanti2);
                baglanti2.Open();
                string hedef_id = hedef_sorgu.ExecuteScalar().ToString();
                baglanti2.Close();
                string sorgu2 = "delete from hedefler where hedef_id='" + hedef_id + "'";
                SqlCommand hedef_id_sorgu = new SqlCommand(sorgu2, baglanti3);
                baglanti3.Open();
                hedef_id_sorgu.ExecuteNonQuery();
                baglanti3.Close();
                string sorgu3 = "delete from planlar where hedef_id='" + hedef_id + "'";
                SqlCommand hedef_id_sorgu2 = new SqlCommand(sorgu3, baglanti3);
                baglanti3.Open();
                hedef_id_sorgu2.ExecuteNonQuery();
                baglanti3.Close();
                string[] day = label_time.Text.Split();
                plan_listele(day[0]);
                
            }
            else if (secenek == DialogResult.No)
            {
                //Hayır seçeneğine tıklandığında çalıştırılacak kodlar
            }
            else if (secenek == DialogResult.Cancel)
            {

            }
        }

        //buton hover olayında
        public void butons_hover(object sender, EventArgs e)
        {
            (sender as Button).FlatAppearance.BorderColor = Color.Silver;
            (sender as Button).FlatAppearance.BorderSize = 2;
        }

        // buton leave olayında
        public void butons_leave(object sender, EventArgs e)
        {
            (sender as Button).FlatAppearance.BorderSize = 0;
        }

        //buton tab number
        public void butons_tabs_ana(int gun)
        {
            Button[] butons =
                { button01, button02, button03, button04, button05, button06, button07, button08, button09, button10,
                button11, button12, button13, button14, button15, button16, button17, button18, button19, button20,
                button21, button22, button23, button24, button25, button26, button27, button28, button29, button30,
                button31, button32, button33, button34, button35, button36, button37
            };

            int j = 0;

            for (int i = 0; i < 37; i++)
            {
                if (Convert.ToInt32(butons[i].Text) == gun)
                {
                    break;
                }

                j = i+1;                
            }

            int a = 0;
            for (int i = j; i < 37; i++)
            {
                butons[i].TabIndex = a;
                a++;
            }
            for (int i = 0; i < j; i++)
            {
                butons[i].TabIndex = a;
                a++;
            }
            butons[j].Focus();
        }

        public void butons_tabs(int gun)
        {
            Button[] butons =
                { button01, button02, button03, button04, button05, button06, button07, button08, button09, button10,
                button11, button12, button13, button14, button15, button16, button17, button18, button19, button20,
                button21, button22, button23, button24, button25, button26, button27, button28, button29, button30,
                button31, button32, button33, button34, button35, button36, button37
            };
            int a = 0;
            for (int i = gun; i < 37; i++)
            {
                butons[i].TabIndex = a;
                a++;
            }
            for (int i = 0; i<gun; i++)
            {
                butons[i].TabIndex = a;
                a++;
            }
            butons[gun-1].Focus();
        }

        //seçilen günü gösterme
        public void label_goster(int gun)
        {
            Label[] labels = 
            {   lab1, lab2, lab3, lab4, lab5, lab6, lab7, lab8, lab9, lab10, lab11, lab12, lab13, lab14, lab15, 
                lab16, lab17, lab18, lab19, lab20, lab21, lab22, lab22, lab23, lab24, lab25, lab26, lab27, lab28, 
                lab29, lab30, lab31, lab32, lab33, lab34, lab35, lab36, lab37 
            };
            
            foreach (var item in labels)
            {
                item.Hide();
            }
            Convert.ToInt32(gun);
            labels[gun-1].Show();
            string yil = label_yil.Text;
            string ay = label_ay.Text;
            DateTime tarih2 = DateTime.Parse(yil + "-" + ay + "-" + gun);
            string gun2 = tarih2.DayOfWeek.ToString();
            switch (gun2)
            {
                case "Monday":
                    label_gun.Text = "Pazartesi";
                    break;
                case "Tuesday":
                    label_gun.Text = "Salı";
                    break;
                case "Wednesday":
                    label_gun.Text = "Çarşamba";
                    break;
                case "Thursday":
                    label_gun.Text = "Perşembe";
                    break;
                case "Friday":
                    label_gun.Text = "Cuma";
                    break;
                case "Saturday":
                    label_gun.Text = "Cumartesi";
                    break;
                case "Sunday":
                    label_gun.Text = "Pazar";
                    break;
            }
        }

        public void label_goster2(int gun, char ad1, char ad2)
        {
            string s = ad1.ToString() + ad2.ToString();
            int ad = Convert.ToInt32(s);
            Label[] labels =
            {   lab1, lab2, lab3, lab4, lab5, lab6, lab7, lab8, lab9, lab10, lab11, lab12, lab13, lab14, lab15,
                lab16, lab17, lab18, lab19, lab20, lab21, lab22, lab22, lab23, lab24, lab25, lab26, lab27, lab28,
                lab29, lab30, lab31, lab32, lab33, lab34, lab35, lab36, lab37
            };
            foreach (var item in labels)
            {
                item.Hide();
            }
            labels[ad - 1].Show();
        }

        public void label_goster3(int gun, char ad1, char ad2)
        {
            string s = ad1.ToString() + ad2.ToString();
            int ad = Convert.ToInt32(s);
            Label[] labels =
            {   lab1, lab2, lab3, lab4, lab5, lab6, lab7, lab8, lab9, lab10, lab11, lab12, lab13, lab14, lab15,
                lab16, lab17, lab18, lab19, lab20, lab21, lab22, lab23, lab24, lab25, lab26, lab27, lab28,
                lab29, lab30, lab31, lab32, lab33, lab34, lab35, lab36, lab37
            };
            foreach (var item in labels)
            {
                item.Hide();
            }
            labels[ad - 1].Show();
            string yil = label_yil.Text;
            string month = label_ay.Text;
            int ay = 0;
            switch (month)
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
            DateTime tarih2 = DateTime.Parse(yil + "-" + ay + "-" + gun);
            string gun2 = tarih2.DayOfWeek.ToString();
            switch (gun2)
            {
                case "Monday":
                    label_gun.Text = "Pazartesi";
                    break;
                case "Tuesday":
                    label_gun.Text = "Salı";
                    break;
                case "Wednesday":
                    label_gun.Text = "Çarşamba";
                    break;
                case "Thursday":
                    label_gun.Text = "Perşembe";
                    break;
                case "Friday":
                    label_gun.Text = "Cuma";
                    break;
                case "Saturday":
                    label_gun.Text = "Cumartesi";
                    break;
                case "Sunday":
                    label_gun.Text = "Pazar";
                    break;
            }
        }

        // bugünün ya da istenilen ayı bulma fonksiyonu
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
            int gun = 1;
            tarihin_gununu_bul(gun);
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
            int gun = 1;
            tarihin_gununu_bul(gun);
        }

        /* tarihlerin gününü bulma (bulduğu gün yazısını,
        ayın gün sayısınu bulma fonksiyonuna gönderir*/
        public void tarihin_gununu_bul(int gun)
        {
            string yil = label_yil.Text;
            string ay = label_ay.Text;
            string tarih = yil + "-" + ay + "-"+gun;
            string gun2 = DateTime.Parse(tarih).DayOfWeek.ToString();
            ayin_gun_sayisini_bulma(gun2);
        }

        /* ayın gün sayısını bulma (bulduğu ayın gün sayısını
         gün yazısı ile gun_yaz fonksiyonuna gönderir*/
        public void ayin_gun_sayisini_bulma(string gun_yazi)
        {
            int gun = 0;
            string ay = label_ay.Text;

            switch (ay)
            {
                case "Ocak":
                    gun = 31;
                    break;

                case "Şubat":
                    int yil = Convert.ToInt32(label_yil.Text);
                    if (yil % 4 == 0)
                    {
                        gun = 29;
                    }
                    else
                    {
                        gun = 28;
                    }
                    break;

                case "Mart":
                    gun = 31;
                    break;

                case "Nisan":
                    gun = 30;
                    break;

                case "Mayıs":
                    gun = 31;
                    break;

                case "Haziran":
                    gun = 30;
                    break;

                case "Temmuz":
                    gun = 31;
                    break;

                case "Ağustos":
                    gun = 31;
                    break;


                case "Eylül":
                    gun = 30;
                    break;

                case "Ekim":
                    gun = 31;
                    break;

                case "Kasım":
                    gun = 30;
                    break;

                case "Aralık":
                    gun = 31;
                    break;
            }

            gun_yaz(gun_yazi,gun);
        }
        

        /* günleri yazdırma (ayın gün sayısı ile oluşan gün durumunu
         buton_diz fonksiyonuna gönderir*/
        public void gun_yaz(string gun, int gun_sayisi)
        {
            int durum = 0;
            switch (gun_sayisi)
            {
                case 28:
                    durum = 1;
                    buton_diz(durum, gun);
                    break;
                case 29:
                    durum = 2;
                    buton_diz(durum, gun);
                    break;
                case 30:
                    durum = 3;
                    buton_diz(durum, gun);
                    break;
                case 31:
                    durum = 4;
                    buton_diz(durum, gun);
                    break;
            }
        }

        // günleri butona dizme
        public void buton_diz(int durum, string gun)
        {
            Button[] butons = { button01, button02, button03, button04,button05,button06,button07,button08,button09,button10,button11,button12, button13, button14, button15,button16,button17,button18,button19,button20,button21,button22,button23,button24,button25,button26,button27,button28,button29,button30,button31,button32,button33,button34, button35,button36,button37 };
            if (durum==1)
            {
                switch (gun)
                {
                    case "Monday":
                        label_gun.Text = "Pazartesi";
                        for (int i = 0; i < 0; i++)
                        {
                            butons[i].Hide();
                        }
                        for (int i=1; i < 29; i++)
                        {
                            butons[i-1].Show();
                            butons[i-1].Text = i.ToString();
                        }
                        for (int i = 28; i < 37; i++)
                        {
                            butons[i].Hide();
                        }
                        char[] ad = button01.Name.ToCharArray();
                        char ad1 = ad[6];
                        char ad2 = ad[7];
                        int gun2 = Convert.ToInt32(butons[0].Text);
                        label_goster2(gun2, ad1, ad2);
                        break;

                    case "Tuesday":
                        label_gun.Text = "Salı"; 
                        for (int i = 0; i < 1; i++)
                        {
                            butons[i].Hide();
                        }
                        for (int i = 1; i < 29; i++)
                        {
                            butons[i].Show();
                            butons[i].Text = i.ToString();
                        }
                        for (int i = 29; i < 37; i++)
                        {
                            butons[i].Hide();
                        }
                        char[] ad3 = button02.Name.ToCharArray();
                        char ad4 = ad3[6];
                        char ad5 = ad3[7];
                        int gun3 = Convert.ToInt32(butons[1].Text);
                        label_goster2(gun3, ad4, ad5);
                        break;

                    case "Wednesday":
                        label_gun.Text = "Çarşamba";
                        for (int i = 0; i < 2; i++)
                        {
                            butons[i].Hide();
                        }
                        for (int i = 1; i < 29; i++)
                        {
                            butons[i+1].Show();
                            butons[i+1].Text = i.ToString();
                        }
                        for (int i = 30; i < 37; i++)
                        {
                            butons[i].Hide();
                        }
                        char[] ad6 = butons[2].Name.ToCharArray();
                        char ad7 = ad6[6];
                        char ad8 = ad6[7];
                        int gun4 = Convert.ToInt32(butons[2].Text);
                        label_goster2(gun4, ad7, ad8);                        
                        break;

                    case "Thursday":
                        label_gun.Text = "Perşembe";
                        for (int i = 0; i < 3; i++)
                        {
                            butons[i].Hide();
                        }
                        for (int i = 1; i < 29; i++)
                        {
                            butons[i + 2].Show();
                            butons[i + 2].Text = i.ToString();
                        }
                        for (int i = 31; i < 37; i++)
                        {
                            butons[i].Hide();
                        }
                        char[] ad9 = butons[3].Name.ToCharArray();
                        char ad10 = ad9[6];
                        char ad11 = ad9[7];
                        int gun5 = Convert.ToInt32(butons[3].Text);
                        label_goster2(gun5, ad10, ad11);                        
                        break;

                    case "Friday":
                        label_gun.Text = "Cuma";
                        for (int i = 0; i < 4; i++)
                        {
                            butons[i].Hide();
                        }
                        for (int i = 1; i < 29; i++)
                        {
                            butons[i + 3].Show();
                            butons[i + 3].Text = i.ToString();
                        }
                        for (int i = 32; i < 37; i++)
                        {
                            butons[i].Hide();
                        }
                        char[] ad12 = butons[4].Name.ToCharArray();
                        char ad13 = ad12[6];
                        char ad14 = ad12[7];
                        int gun6 = Convert.ToInt32(butons[4].Text);
                        label_goster2(gun6, ad13, ad14);
                        break;

                    case "Saturday":
                        label_gun.Text = "Cumartesi";
                        for (int i = 0; i < 5; i++)
                        {
                            butons[i].Hide();
                        }
                        for (int i = 1; i < 29; i++)
                        {
                            butons[i + 4].Show();
                            butons[i + 4].Text = i.ToString();
                        }
                        for (int i = 33; i < 37; i++)
                        {
                            butons[i].Hide();
                        }
                        char[] ad15 = butons[5].Name.ToCharArray();
                        char ad16 = ad15[6];
                        char ad17 = ad15[7];
                        int gun7 = Convert.ToInt32(butons[5].Text);
                        label_goster2(gun7, ad16, ad17);
                        break;

                    case "Sunday":
                        label_gun.Text = "Pazar";
                        for (int i = 0; i < 6; i++)
                        {
                            butons[i].Hide();
                        }
                        for (int i = 1; i < 29; i++)
                        {
                            butons[i + 5].Show();
                            butons[i + 5].Text = i.ToString();
                        }
                        for (int i = 34; i < 37; i++)
                        {
                            butons[i].Hide();
                        }
                        char[] ad18 = butons[6].Name.ToCharArray();
                        char ad19 = ad18[6];
                        char ad20 = ad18[7];
                        int gun8 = Convert.ToInt32(butons[6].Text);
                        label_goster2(gun8, ad19, ad20);
                        break;
                }
            }
            if (durum==2)
            {
                switch (gun)
                {
                    case "Monday":
                        label_gun.Text = "Pazartesi";
                        for (int i = 0; i < 0; i++)
                        {
                            butons[i].Hide();
                        }
                        for (int i = 1; i < 30; i++)
                        {
                            butons[i - 1].Show();
                            butons[i - 1].Text = i.ToString();
                        }
                        for (int i = 29; i < 37; i++)
                        {
                            butons[i].Hide();
                        }
                        char[] ad = button01.Name.ToCharArray();
                        char ad1 = ad[6];
                        char ad2 = ad[7];
                        int gun2 = Convert.ToInt32(butons[0].Text);
                        label_goster2(gun2, ad1, ad2);
                        break;

                    case "Tuesday":
                        label_gun.Text = "Salı";
                        for (int i = 0; i < 1; i++)
                        {
                            butons[i].Hide();
                        }
                        for (int i = 1; i < 30; i++)
                        {
                            butons[i].Show();
                            butons[i].Text = i.ToString();
                        }
                        for (int i = 30; i < 37; i++)
                        {
                            butons[i].Hide();
                        }
                        char[] ad3 = button02.Name.ToCharArray();
                        char ad4 = ad3[6];
                        char ad5 = ad3[7];
                        int gun3 = Convert.ToInt32(butons[1].Text);
                        label_goster2(gun3, ad4, ad5);
                        break;

                    case "Wednesday":
                        label_gun.Text = "Çarşamba";
                        for (int i = 0; i < 2; i++)
                        {
                            butons[i].Hide();
                        }
                        for (int i = 1; i < 30; i++)
                        {
                            butons[i + 1].Show();
                            butons[i + 1].Text = i.ToString();
                        }
                        for (int i = 31; i < 37; i++)
                        {
                            butons[i].Hide();
                        }
                        char[] ad6 = butons[2].Name.ToCharArray();
                        char ad7 = ad6[6];
                        char ad8 = ad6[7];
                        int gun4 = Convert.ToInt32(butons[2].Text);
                        label_goster2(gun4, ad7, ad8);
                        break;

                    case "Thursday":
                        label_gun.Text = "Perşembe";
                        for (int i = 0; i < 3; i++)
                        {
                            butons[i].Hide();
                        }
                        for (int i = 1; i < 30; i++)
                        {
                            butons[i + 2].Show();
                            butons[i + 2].Text = i.ToString();
                        }
                        for (int i = 32; i < 37; i++)
                        {
                            butons[i].Hide();
                        }
                        char[] ad9 = butons[3].Name.ToCharArray();
                        char ad10 = ad9[6];
                        char ad11 = ad9[7];
                        int gun5 = Convert.ToInt32(butons[3].Text);
                        label_goster2(gun5, ad10, ad11);
                        break;

                    case "Friday":
                        label_gun.Text = "Cuma";
                        for (int i = 0; i < 4; i++)
                        {
                            butons[i].Hide();
                        }
                        for (int i = 1; i < 30; i++)
                        {
                            butons[i + 3].Show();
                            butons[i + 3].Text = i.ToString();
                        }
                        for (int i = 33; i < 37; i++)
                        {
                            butons[i].Hide();
                        }
                        char[] ad12 = butons[4].Name.ToCharArray();
                        char ad13 = ad12[6];
                        char ad14 = ad12[7];
                        int gun6 = Convert.ToInt32(butons[4].Text);
                        label_goster2(gun6, ad13, ad14);
                        break;

                    case "Saturday":
                        label_gun.Text = "Cumartesi";
                        for (int i = 0; i < 5; i++)
                        {
                            butons[i].Hide();
                        }
                        for (int i = 1; i < 30; i++)
                        {
                            butons[i + 4].Show();
                            butons[i + 4].Text = i.ToString();
                        }
                        for (int i = 34; i < 37; i++)
                        {
                            butons[i].Hide();
                        }
                        char[] ad15 = butons[5].Name.ToCharArray();
                        char ad16 = ad15[6];
                        char ad17 = ad15[7];
                        int gun7 = Convert.ToInt32(butons[5].Text);
                        label_goster2(gun7, ad16, ad17);
                        break;

                    case "Sunday":
                        label_gun.Text = "Pazar";
                        for (int i = 0; i < 6; i++)
                        {
                            butons[i].Hide();
                        }
                        for (int i = 1; i < 30; i++)
                        {
                            butons[i + 5].Show();
                            butons[i + 5].Text = i.ToString();
                        }
                        for (int i = 35; i < 37; i++)
                        {
                            butons[i].Hide();
                        }
                        char[] ad18 = butons[6].Name.ToCharArray();
                        char ad19 = ad18[6];
                        char ad20 = ad18[7];
                        int gun8 = Convert.ToInt32(butons[6].Text);
                        label_goster2(gun8, ad19, ad20);
                        break;
                }
            }
            if (durum == 3)
            {
                switch (gun)
                {
                    case "Monday":
                        label_gun.Text = "Pazartesi";
                        for (int i = 0; i < 0; i++)
                        {
                            butons[i].Hide();
                        }
                        for (int i = 1; i < 31; i++)
                        {
                            butons[i - 1].Show();
                            butons[i - 1].Text = i.ToString();
                        }
                        for (int i = 30; i < 37; i++)
                        {
                            butons[i].Hide();
                        }
                        char[] ad = button01.Name.ToCharArray();
                        char ad1 = ad[6];
                        char ad2 = ad[7];
                        int gun2 = Convert.ToInt32(butons[0].Text);
                        label_goster2(gun2, ad1, ad2);
                        break;

                    case "Tuesday":
                        label_gun.Text = "Salı";
                        for (int i = 0; i < 2; i++)
                        {
                            butons[i].Hide();
                        }
                        for (int i = 1; i < 31; i++)
                        {
                            butons[i].Show();
                            butons[i].Text = i.ToString();
                        }
                        for (int i = 31; i < 37; i++)
                        {
                            butons[i].Hide();
                        }
                        char[] ad3 = button02.Name.ToCharArray();
                        char ad4 = ad3[6];
                        char ad5 = ad3[7];
                        int gun3 = Convert.ToInt32(butons[1].Text);
                        label_goster2(gun3, ad4, ad5);
                        break;

                    case "Wednesday":
                        label_gun.Text = "Çarşamba";
                        for (int i = 0; i < 3; i++)
                        {
                            butons[i].Hide();
                        }
                        for (int i = 1; i < 31; i++)
                        {
                            butons[i + 1].Show();
                            butons[i + 1].Text = i.ToString();
                        }
                        for (int i = 32; i < 37; i++)
                        {
                            butons[i].Hide();
                        }
                        char[] ad6 = butons[2].Name.ToCharArray();
                        char ad7 = ad6[6];
                        char ad8 = ad6[7];
                        int gun4 = Convert.ToInt32(butons[2].Text);
                        label_goster2(gun4, ad7, ad8);
                        break;

                    case "Thursday":
                        label_gun.Text = "Perşembe";
                        for (int i = 0; i < 4; i++)
                        {
                            butons[i].Hide();
                        }
                        for (int i = 1; i < 31; i++)
                        {
                            butons[i + 2].Show();
                            butons[i + 2].Text = i.ToString();
                        }
                        for (int i = 33; i < 37; i++)
                        {
                            butons[i].Hide();
                        }
                        char[] ad9 = butons[3].Name.ToCharArray();
                        char ad10 = ad9[6];
                        char ad11 = ad9[7];
                        int gun5 = Convert.ToInt32(butons[3].Text);
                        label_goster2(gun5, ad10, ad11);
                        break;

                    case "Friday":
                        label_gun.Text = "Cuma";
                        for (int i = 0; i < 5; i++)
                        {
                            butons[i].Hide();
                        }
                        for (int i = 1; i < 31; i++)
                        {
                            butons[i + 3].Show();
                            butons[i + 3].Text = i.ToString();
                        }
                        for (int i = 34; i < 37; i++)
                        {
                            butons[i].Hide();
                        }
                        char[] ad12 = butons[4].Name.ToCharArray();
                        char ad13 = ad12[6];
                        char ad14 = ad12[7];
                        int gun6 = Convert.ToInt32(butons[4].Text);
                        label_goster2(gun6, ad13, ad14);
                        break;

                    case "Saturday":
                        label_gun.Text = "Cumartesi";
                        for (int i = 0; i < 6; i++)
                        {
                            butons[i].Hide();
                        }
                        for (int i = 1; i < 31; i++)
                        {
                            butons[i + 4].Show();
                            butons[i + 4].Text = i.ToString();
                        }
                        for (int i = 35; i < 37; i++)
                        {
                            butons[i].Hide();
                        }
                        char[] ad15 = butons[5].Name.ToCharArray();
                        char ad16 = ad15[6];
                        char ad17 = ad15[7];
                        int gun7 = Convert.ToInt32(butons[5].Text);
                        label_goster2(gun7, ad16, ad17);
                        break;

                    case "Sunday":
                        label_gun.Text = "Pazar";
                        for (int i = 0; i < 7; i++)
                        {
                            butons[i].Hide();
                        }
                        for (int i = 1; i < 31; i++)
                        {
                            butons[i + 5].Show();
                            butons[i + 5].Text = i.ToString();
                        }
                        for (int i = 36; i < 37; i++)
                        {
                            butons[i].Hide();
                        }
                        char[] ad18 = butons[6].Name.ToCharArray();
                        char ad19 = ad18[6];
                        char ad20 = ad18[7];
                        int gun8 = Convert.ToInt32(butons[6].Text);
                        label_goster2(gun8, ad19, ad20);
                        break;
                }
            }
            if (durum == 4)
            {
                switch (gun)
                {
                    case "Monday":
                        label_gun.Text = "Pazartesi";
                        for (int i = 0; i < 0; i++)
                        {
                            butons[i].Hide();
                        }
                        for (int i = 1; i < 32; i++)
                        {
                            butons[i - 1].Show();
                            butons[i - 1].Text = i.ToString();
                        }
                        for (int i = 31; i < 37; i++)
                        {
                            butons[i].Hide();
                        }
                        char[] ad = button01.Name.ToCharArray();
                        char ad1 = ad[6];
                        char ad2 = ad[7];
                        int gun2 = Convert.ToInt32(butons[0].Text);
                        label_goster2(gun2, ad1, ad2);
                        break;

                    case "Tuesday":
                        label_gun.Text = "Salı";
                        for (int i = 0; i < 2; i++)
                        {
                            butons[i].Hide();
                        }
                        for (int i = 1; i < 32; i++)
                        {
                            butons[i].Show();
                            butons[i].Text = i.ToString();
                        }
                        for (int i = 32; i < 37; i++)
                        {
                            butons[i].Hide();
                        }
                        char[] ad3 = button02.Name.ToCharArray();
                        char ad4 = ad3[6];
                        char ad5 = ad3[7];
                        int gun3 = Convert.ToInt32(butons[1].Text);
                        label_goster2(gun3, ad4, ad5);
                        break;

                    case "Wednesday":
                        label_gun.Text = "Çarşamba";
                        for (int i = 0; i < 3; i++)
                        {
                            butons[i].Hide();
                        }
                        for (int i = 1; i < 32; i++)
                        {
                            butons[i + 1].Show();
                            butons[i + 1].Text = i.ToString();
                        }
                        for (int i = 33; i < 37; i++)
                        {
                            butons[i].Hide();
                        }
                        char[] ad6 = butons[2].Name.ToCharArray();
                        char ad7 = ad6[6];
                        char ad8 = ad6[7];
                        int gun4 = Convert.ToInt32(butons[2].Text);
                        label_goster2(gun4, ad7, ad8);
                        break;

                    case "Thursday":
                        label_gun.Text = "Perşembe";
                        for (int i = 0; i < 4; i++)
                        {
                            butons[i].Hide();
                        }
                        for (int i = 1; i < 32; i++)
                        {
                            butons[i + 2].Show();
                            butons[i + 2].Text = i.ToString();
                        }
                        for (int i = 34; i < 37; i++)
                        {
                            butons[i].Hide();
                        }
                        char[] ad9 = butons[3].Name.ToCharArray();
                        char ad10 = ad9[6];
                        char ad11 = ad9[7];
                        int gun5 = Convert.ToInt32(butons[3].Text);
                        label_goster2(gun5, ad10, ad11);
                        break;

                    case "Friday":
                        label_gun.Text = "Cuma";
                        for (int i = 0; i < 5; i++)
                        {
                            butons[i].Hide();
                        }
                        for (int i = 1; i < 32; i++)
                        {
                            butons[i + 3].Show();
                            butons[i + 3].Text = i.ToString();
                        }
                        for (int i = 35; i < 37; i++)
                        {
                            butons[i].Hide();
                        }
                        char[] ad12 = butons[4].Name.ToCharArray();
                        char ad13 = ad12[6];
                        char ad14 = ad12[7];
                        int gun6 = Convert.ToInt32(butons[4].Text);
                        label_goster2(gun6, ad13, ad14);
                        break;

                    case "Saturday":
                        label_gun.Text = "Cumartesi";
                        for (int i = 0; i < 6; i++)
                        {
                            butons[i].Hide();
                        }
                        for (int i = 1; i < 32; i++)
                        {
                            butons[i + 4].Show();
                            butons[i + 4].Text = i.ToString();
                        }
                        for (int i = 36; i < 37; i++)
                        {
                            butons[i].Hide();
                        }
                        char[] ad15 = butons[5].Name.ToCharArray();
                        char ad16 = ad15[6];
                        char ad17 = ad15[7];
                        int gun7 = Convert.ToInt32(butons[5].Text);
                        label_goster2(gun7, ad16, ad17);
                        break;

                    case "Sunday":
                        label_gun.Text = "Pazar";
                        for (int i = 0; i < 7; i++)
                        {
                            butons[i].Hide();
                        }
                        for (int i = 1; i < 32; i++)
                        {
                            butons[i + 5].Show();
                            butons[i + 5].Text = i.ToString();
                        }
                        for (int i = 37; i < 37; i++)
                        {
                            butons[i].Hide();
                        }
                        char[] ad18 = butons[6].Name.ToCharArray();
                        char ad19 = ad18[6];
                        char ad20 = ad18[7];
                        int gun8 = Convert.ToInt32(butons[6].Text);
                        label_goster2(gun8, ad19, ad20);
                        break;
                }
            }
        }

        // label hover
        public void labels_hover(object sender,EventArgs e)
        {
            (sender as Label).ForeColor = Color.WhiteSmoke;
        }

        // label leave
        public void labels_leave(object sender, EventArgs e)
        {
            (sender as Label).ForeColor = Color.Silver;
        }

        // ekle formu
        private void ekle_Click(object sender, EventArgs e)
        {
            Ekle ekle_form = new Ekle();
            if (Application.OpenForms["Ekle"] == null)
            {
                ekle_form.Show();

            }
        }

        // Ay ve yıl okları

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
            int gun = 1;
            tarihin_gununu_bul(gun);
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
            int gun = 1;
            tarihin_gununu_bul(gun);
        }

        // ay ve yıl formları

        private void label_ay_Click(object sender, EventArgs e)
        {
            Aylar ay_form = new Aylar();
            ay_form.ay_gon = new Aylar.ay_gonder(ay_bulma);
            if (Application.OpenForms["Aylar"]==null)
            {
                ay_form.Show();

            }
        }

        private void label_yil_Click(object sender, EventArgs e)
        {
            Yillar yil_form = new Yillar();
            yil_form.yil_gon = new Yillar.yil_gonder(yil_yaz);
            if (Application.OpenForms["Yillar"] == null)
            {
                yil_form.Show();

            }
        }
    }
}
