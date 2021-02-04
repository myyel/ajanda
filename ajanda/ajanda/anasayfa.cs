﻿using System;
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
       
        public Anasayfa()
        {
            InitializeComponent();
        }

        // Anasayfa load
        public void Anasayfa_Load(object sender, EventArgs e)
        {
            this.Size = new Size(788, 818);
            string gun = DateTime.Now.Day.ToString();
            string mont = DateTime.Now.Month.ToString();
            string yil = DateTime.Now.Year.ToString();
            if (Convert.ToInt32(DateTime.Now.Day)<10 || Convert.ToInt32(DateTime.Now.Month)<10)
            {
                if (Convert.ToInt32(DateTime.Now.Day) < 10)
                {
                    string new_mont = null;
                    if (Convert.ToInt32(DateTime.Now.Month) < 10)
                    {
                        new_mont = "0" + mont;

                    }
                    else
                    {
                        new_mont = mont;
                    }
                    string tarih = "0" + gun + "." + new_mont + "." + yil;
                    label_gun.Text = tarih;

                }
                else
                {
                    string tarih =  gun + "." +"0"+ mont + "." + yil;
                    label_gun.Text = tarih;
                }
            }
            else
            {
                
            }
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
        }

        // anasayfa büyümesi ve yapılacaklar listesi
        public void anasayfa_list(int gun)
        {
            this.Size = new Size(1250, 818);
            this.BackgroundImage = Properties.Resources.home_background2_acik;
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
            tarihin_gununu_bul();
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

            tarihin_gununu_bul();
        }

        /* tarihlerin gününü bulma (bulduğu gün yazısını,
        ayın gün sayısınu bulma fonksiyonuna gönderir*/
        public void tarihin_gununu_bul()
        {
            string yil = label_yil.Text;
            string ay = label_ay.Text;
            string tarih = yil + "-" + ay + "01";
            string gun = DateTime.Parse(tarih).DayOfWeek.ToString();
            ayin_gun_sayisini_bulma(gun);
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
            if (durum==1)
            {
                switch (gun)
                {
                    case "Monday":
                        button1.Show();
                        button2.Show();
                        button3.Show();
                        button4.Show();
                        button5.Show();
                        button6.Show();
                        button7.Show();
                        button8.Show();
                        button9.Show();
                        button10.Show();
                        button11.Show();
                        button12.Show();
                        button13.Show();
                        button14.Show();
                        button15.Show();
                        button16.Show();
                        button17.Show();
                        button18.Show();
                        button19.Show();
                        button20.Show();
                        button21.Show();
                        button22.Show();
                        button23.Show();
                        button24.Show();
                        button25.Show();
                        button26.Show();
                        button27.Show();
                        button28.Show();

                        button1.Text = 1.ToString();
                        button2.Text = 2.ToString();
                        button3.Text = 3.ToString();
                        button4.Text = 4.ToString();
                        button5.Text = 5.ToString();
                        button6.Text = 6.ToString();
                        button7.Text = 7.ToString();
                        button8.Text = 8.ToString();
                        button9.Text = 9.ToString();
                        button10.Text = 10.ToString();
                        button11.Text = 11.ToString();
                        button12.Text = 12.ToString();
                        button13.Text = 13.ToString();
                        button14.Text = 14.ToString();
                        button15.Text = 15.ToString();
                        button16.Text = 16.ToString();
                        button17.Text = 17.ToString();
                        button18.Text = 18.ToString();
                        button19.Text = 19.ToString();
                        button20.Text = 20.ToString();
                        button21.Text = 21.ToString();
                        button22.Text = 22.ToString();
                        button23.Text = 23.ToString();
                        button24.Text = 24.ToString();
                        button25.Text = 25.ToString();
                        button26.Text = 26.ToString();
                        button27.Text = 27.ToString();
                        button28.Text = 28.ToString();
                        button29.Hide();
                        button30.Hide();
                        button31.Hide();
                        button32.Hide();
                        button33.Hide();
                        button34.Hide();
                        button35.Hide();
                        button36.Hide();
                        button37.Hide();
                        break;

                    case "Tuesday":
                        button2.Show();
                        button3.Show();
                        button4.Show();
                        button5.Show();
                        button6.Show();
                        button7.Show();
                        button8.Show();
                        button9.Show();
                        button10.Show();
                        button11.Show();
                        button12.Show();
                        button13.Show();
                        button14.Show();
                        button15.Show();
                        button16.Show();
                        button17.Show();
                        button18.Show();
                        button19.Show();
                        button20.Show();
                        button21.Show();
                        button22.Show();
                        button23.Show();
                        button24.Show();
                        button25.Show();
                        button26.Show();
                        button27.Show();
                        button28.Show();
                        button29.Show();

                        button1.Hide();
                        button2.Text = 1.ToString();
                        button3.Text = 2.ToString();
                        button4.Text = 3.ToString();
                        button5.Text = 4.ToString();
                        button6.Text = 5.ToString();
                        button7.Text = 6.ToString();
                        button8.Text = 7.ToString();
                        button9.Text = 8.ToString();
                        button10.Text = 9.ToString();
                        button11.Text = 10.ToString();
                        button12.Text = 11.ToString();
                        button13.Text = 12.ToString();
                        button14.Text = 13.ToString();
                        button15.Text = 14.ToString();
                        button16.Text = 15.ToString();
                        button17.Text = 16.ToString();
                        button18.Text = 17.ToString();
                        button19.Text = 18.ToString();
                        button20.Text = 19.ToString();
                        button21.Text = 20.ToString();
                        button22.Text = 21.ToString();
                        button23.Text = 22.ToString();
                        button24.Text = 23.ToString();
                        button25.Text = 24.ToString();
                        button26.Text = 25.ToString();
                        button27.Text = 26.ToString();
                        button28.Text = 27.ToString();
                        button29.Text = 28.ToString();
                        button30.Hide();
                        button31.Hide();
                        button32.Hide();
                        button33.Hide();
                        button34.Hide();
                        button35.Hide();
                        button36.Hide();
                        button37.Hide();
                        break;

                    case "Wednesday":
                        button3.Show();
                        button4.Show();
                        button5.Show();
                        button6.Show();
                        button7.Show();
                        button8.Show();
                        button9.Show();
                        button10.Show();
                        button11.Show();
                        button12.Show();
                        button13.Show();
                        button14.Show();
                        button15.Show();
                        button16.Show();
                        button17.Show();
                        button18.Show();
                        button19.Show();
                        button20.Show();
                        button21.Show();
                        button22.Show();
                        button23.Show();
                        button24.Show();
                        button25.Show();
                        button26.Show();
                        button27.Show();
                        button28.Show();
                        button29.Show();
                        button30.Show();
                       
                        button1.Hide();
                        button2.Hide();
                        button3.Text = 1.ToString();
                        button4.Text = 2.ToString();
                        button5.Text = 3.ToString();
                        button6.Text = 4.ToString();
                        button7.Text = 5.ToString();
                        button8.Text = 6.ToString();
                        button9.Text = 7.ToString();
                        button10.Text = 8.ToString();
                        button11.Text = 9.ToString();
                        button12.Text = 10.ToString();
                        button13.Text = 11.ToString();
                        button14.Text = 12.ToString();
                        button15.Text = 13.ToString();
                        button16.Text = 14.ToString();
                        button17.Text = 15.ToString();
                        button18.Text = 16.ToString();
                        button19.Text = 17.ToString();
                        button20.Text = 18.ToString();
                        button21.Text = 19.ToString();
                        button22.Text = 20.ToString();
                        button23.Text = 21.ToString();
                        button24.Text = 22.ToString();
                        button25.Text = 23.ToString();
                        button26.Text = 24.ToString();
                        button27.Text = 25.ToString();
                        button28.Text = 26.ToString();
                        button29.Text = 27.ToString();
                        button30.Text = 28.ToString();
                        button31.Hide();
                        button32.Hide();
                        button33.Hide();
                        button34.Hide();
                        button35.Hide();
                        button36.Hide();
                        button37.Hide();
                        break;

                    case "Thursday":
                        button4.Show();
                        button5.Show();
                        button6.Show();
                        button7.Show();
                        button8.Show();
                        button9.Show();
                        button10.Show();
                        button11.Show();
                        button12.Show();
                        button13.Show();
                        button14.Show();
                        button15.Show();
                        button16.Show();
                        button17.Show();
                        button18.Show();
                        button19.Show();
                        button20.Show();
                        button21.Show();
                        button22.Show();
                        button23.Show();
                        button24.Show();
                        button25.Show();
                        button26.Show();
                        button27.Show();
                        button28.Show();
                        button29.Show();
                        button30.Show();
                        button31.Show();
                        
                        button1.Hide();
                        button2.Hide();
                        button3.Hide();
                        button4.Text = 1.ToString();
                        button5.Text = 2.ToString();
                        button6.Text = 3.ToString();
                        button7.Text = 4.ToString();
                        button8.Text = 5.ToString();
                        button9.Text = 6.ToString();
                        button10.Text = 7.ToString();
                        button11.Text = 8.ToString();
                        button12.Text = 9.ToString();
                        button13.Text = 10.ToString();
                        button14.Text = 11.ToString();
                        button15.Text = 12.ToString();
                        button16.Text = 13.ToString();
                        button17.Text = 14.ToString();
                        button18.Text = 15.ToString();
                        button19.Text = 16.ToString();
                        button20.Text = 17.ToString();
                        button21.Text = 18.ToString();
                        button22.Text = 19.ToString();
                        button23.Text = 20.ToString();
                        button24.Text = 21.ToString();
                        button25.Text = 22.ToString();
                        button26.Text = 23.ToString();
                        button27.Text = 24.ToString();
                        button28.Text = 25.ToString();
                        button29.Text = 26.ToString();
                        button30.Text = 27.ToString();
                        button31.Text = 28.ToString();
                        button32.Hide();
                        button33.Hide();
                        button34.Hide();
                        button35.Hide();
                        button36.Hide();
                        button37.Hide();
                        break;

                    case "Friday":
                        button5.Show();
                        button6.Show();
                        button7.Show();
                        button8.Show();
                        button9.Show();
                        button10.Show();
                        button11.Show();
                        button12.Show();
                        button13.Show();
                        button14.Show();
                        button15.Show();
                        button16.Show();
                        button17.Show();
                        button18.Show();
                        button19.Show();
                        button20.Show();
                        button21.Show();
                        button22.Show();
                        button23.Show();
                        button24.Show();
                        button25.Show();
                        button26.Show();
                        button27.Show();
                        button28.Show();
                        button29.Show();
                        button30.Show();
                        button31.Show();
                        button32.Show();
                        

                        button1.Hide();
                        button2.Hide();
                        button3.Hide();
                        button4.Hide();
                        button5.Text = 1.ToString();
                        button6.Text = 2.ToString();
                        button7.Text = 3.ToString();
                        button8.Text = 4.ToString();
                        button9.Text = 5.ToString();
                        button10.Text = 6.ToString();
                        button11.Text = 7.ToString();
                        button12.Text = 8.ToString();
                        button13.Text = 9.ToString();
                        button14.Text = 10.ToString();
                        button15.Text = 11.ToString();
                        button16.Text = 12.ToString();
                        button17.Text = 13.ToString();
                        button18.Text = 14.ToString();
                        button19.Text = 15.ToString();
                        button20.Text = 16.ToString();
                        button21.Text = 17.ToString();
                        button22.Text = 18.ToString();
                        button23.Text = 19.ToString();
                        button24.Text = 20.ToString();
                        button25.Text = 21.ToString();
                        button26.Text = 22.ToString();
                        button27.Text = 23.ToString();
                        button28.Text = 24.ToString();
                        button29.Text = 25.ToString();
                        button30.Text = 26.ToString();
                        button31.Text = 27.ToString();
                        button32.Text = 28.ToString();
                        button33.Hide();
                        button34.Hide();
                        button35.Hide();
                        button36.Hide();
                        button37.Hide();
                        break;

                    case "Saturday":
                        
                        button6.Show();
                        button7.Show();
                        button8.Show();
                        button9.Show();
                        button10.Show();
                        button11.Show();
                        button12.Show();
                        button13.Show();
                        button14.Show();
                        button15.Show();
                        button16.Show();
                        button17.Show();
                        button18.Show();
                        button19.Show();
                        button20.Show();
                        button21.Show();
                        button22.Show();
                        button23.Show();
                        button24.Show();
                        button25.Show();
                        button26.Show();
                        button27.Show();
                        button28.Show();
                        button29.Show();
                        button30.Show();
                        button31.Show();
                        button32.Show();
                        button33.Show();
                        
                        button1.Hide();
                        button2.Hide();
                        button3.Hide();
                        button4.Hide();
                        button5.Hide();
                        button6.Text = 1.ToString();
                        button7.Text = 2.ToString();
                        button8.Text = 3.ToString();
                        button9.Text = 4.ToString();
                        button10.Text = 5.ToString();
                        button11.Text = 6.ToString();
                        button12.Text = 7.ToString();
                        button13.Text = 8.ToString();
                        button14.Text = 9.ToString();
                        button15.Text = 10.ToString();
                        button16.Text = 11.ToString();
                        button17.Text = 12.ToString();
                        button18.Text = 13.ToString();
                        button19.Text = 14.ToString();
                        button20.Text = 15.ToString();
                        button21.Text = 16.ToString();
                        button22.Text = 17.ToString();
                        button23.Text = 18.ToString();
                        button24.Text = 19.ToString();
                        button25.Text = 20.ToString();
                        button26.Text = 21.ToString();
                        button27.Text = 22.ToString();
                        button28.Text = 23.ToString();
                        button29.Text = 24.ToString();
                        button30.Text = 25.ToString();
                        button31.Text = 26.ToString();
                        button32.Text = 27.ToString();
                        button33.Text = 28.ToString();
                        button34.Hide();
                        button35.Hide();
                        button36.Hide();
                        button37.Hide();
                        break;

                    case "Sunday":
                        button7.Show();
                        button8.Show();
                        button9.Show();
                        button10.Show();
                        button11.Show();
                        button12.Show();
                        button13.Show();
                        button14.Show();
                        button15.Show();
                        button16.Show();
                        button17.Show();
                        button18.Show();
                        button19.Show();
                        button20.Show();
                        button21.Show();
                        button22.Show();
                        button23.Show();
                        button24.Show();
                        button25.Show();
                        button26.Show();
                        button27.Show();
                        button28.Show();
                        button29.Show();
                        button30.Show();
                        button31.Show();
                        button32.Show();
                        button33.Show();
                        button34.Show();
                        
                        button1.Hide();
                        button2.Hide();
                        button3.Hide();
                        button4.Hide();
                        button5.Hide();
                        button6.Hide();
                        button7.Text = 1.ToString();
                        button8.Text = 2.ToString();
                        button9.Text = 3.ToString();
                        button10.Text = 4.ToString();
                        button11.Text = 5.ToString();
                        button12.Text = 6.ToString();
                        button13.Text = 7.ToString();
                        button14.Text = 8.ToString();
                        button15.Text = 9.ToString();
                        button16.Text = 10.ToString();
                        button17.Text = 11.ToString();
                        button18.Text = 12.ToString();
                        button19.Text = 13.ToString();
                        button20.Text = 14.ToString();
                        button21.Text = 15.ToString();
                        button22.Text = 16.ToString();
                        button23.Text = 17.ToString();
                        button24.Text = 18.ToString();
                        button25.Text = 19.ToString();
                        button26.Text = 20.ToString();
                        button27.Text = 21.ToString();
                        button28.Text = 22.ToString();
                        button29.Text = 23.ToString();
                        button30.Text = 24.ToString();
                        button31.Text = 25.ToString();
                        button32.Text = 26.ToString();
                        button33.Text = 27.ToString();
                        button34.Text = 28.ToString();
                        button35.Hide();
                        button36.Hide();
                        button37.Hide();
                        break;
                }
            }
            if (durum==2)
            {
                switch (gun)
                {
                    case "Monday":
                        button1.Show();
                        button2.Show();
                        button3.Show();
                        button4.Show();
                        button5.Show();
                        button6.Show();
                        button7.Show();
                        button8.Show();
                        button9.Show();
                        button10.Show();
                        button11.Show();
                        button12.Show();
                        button13.Show();
                        button14.Show();
                        button15.Show();
                        button16.Show();
                        button17.Show();
                        button18.Show();
                        button19.Show();
                        button20.Show();
                        button21.Show();
                        button22.Show();
                        button23.Show();
                        button24.Show();
                        button25.Show();
                        button26.Show();
                        button27.Show();
                        button28.Show();
                        button29.Show();

                        button1.Text = 1.ToString();
                        button2.Text = 2.ToString();
                        button3.Text = 3.ToString();
                        button4.Text = 4.ToString();
                        button5.Text = 5.ToString();
                        button6.Text = 6.ToString();
                        button7.Text = 7.ToString();
                        button8.Text = 8.ToString();
                        button9.Text = 9.ToString();
                        button10.Text = 10.ToString();
                        button11.Text = 11.ToString();
                        button12.Text = 12.ToString();
                        button13.Text = 13.ToString();
                        button14.Text = 14.ToString();
                        button15.Text = 15.ToString();
                        button16.Text = 16.ToString();
                        button17.Text = 17.ToString();
                        button18.Text = 18.ToString();
                        button19.Text = 19.ToString();
                        button20.Text = 20.ToString();
                        button21.Text = 21.ToString();
                        button22.Text = 22.ToString();
                        button23.Text = 23.ToString();
                        button24.Text = 24.ToString();
                        button25.Text = 25.ToString();
                        button26.Text = 26.ToString();
                        button27.Text = 27.ToString();
                        button28.Text = 28.ToString();
                        button29.Text = 29.ToString();
                        button30.Hide();
                        button31.Hide();
                        button32.Hide();
                        button33.Hide();
                        button34.Hide();
                        button35.Hide();
                        button36.Hide();
                        button37.Hide();
                        break;

                    case "Tuesday":
                        button2.Show();
                        button3.Show();
                        button4.Show();
                        button5.Show();
                        button6.Show();
                        button7.Show();
                        button8.Show();
                        button9.Show();
                        button10.Show();
                        button11.Show();
                        button12.Show();
                        button13.Show();
                        button14.Show();
                        button15.Show();
                        button16.Show();
                        button17.Show();
                        button18.Show();
                        button19.Show();
                        button20.Show();
                        button21.Show();
                        button22.Show();
                        button23.Show();
                        button24.Show();
                        button25.Show();
                        button26.Show();
                        button27.Show();
                        button28.Show();
                        button29.Show();
                        button30.Show();

                        button1.Hide();
                        button2.Text = 1.ToString();
                        button3.Text = 2.ToString();
                        button4.Text = 3.ToString();
                        button5.Text = 4.ToString();
                        button6.Text = 5.ToString();
                        button7.Text = 6.ToString();
                        button8.Text = 7.ToString();
                        button9.Text = 8.ToString();
                        button10.Text = 9.ToString();
                        button11.Text = 10.ToString();
                        button12.Text = 11.ToString();
                        button13.Text = 12.ToString();
                        button14.Text = 13.ToString();
                        button15.Text = 14.ToString();
                        button16.Text = 15.ToString();
                        button17.Text = 16.ToString();
                        button18.Text = 17.ToString();
                        button19.Text = 18.ToString();
                        button20.Text = 19.ToString();
                        button21.Text = 20.ToString();
                        button22.Text = 21.ToString();
                        button23.Text = 22.ToString();
                        button24.Text = 23.ToString();
                        button25.Text = 24.ToString();
                        button26.Text = 25.ToString();
                        button27.Text = 26.ToString();
                        button28.Text = 27.ToString();
                        button29.Text = 28.ToString();
                        button30.Text = 29.ToString();
                        button31.Hide();
                        button32.Hide();
                        button33.Hide();
                        button34.Hide();
                        button35.Hide();
                        button36.Hide();
                        button37.Hide();
                        break;

                    case "Wednesday":
                        button3.Show();
                        button4.Show();
                        button5.Show();
                        button6.Show();
                        button7.Show();
                        button8.Show();
                        button9.Show();
                        button10.Show();
                        button11.Show();
                        button12.Show();
                        button13.Show();
                        button14.Show();
                        button15.Show();
                        button16.Show();
                        button17.Show();
                        button18.Show();
                        button19.Show();
                        button20.Show();
                        button21.Show();
                        button22.Show();
                        button23.Show();
                        button24.Show();
                        button25.Show();
                        button26.Show();
                        button27.Show();
                        button28.Show();
                        button29.Show();
                        button30.Show();
                        button31.Show();

                        button1.Hide();
                        button2.Hide();
                        button3.Text = 1.ToString();
                        button4.Text = 2.ToString();
                        button5.Text = 3.ToString();
                        button6.Text = 4.ToString();
                        button7.Text = 5.ToString();
                        button8.Text = 6.ToString();
                        button9.Text = 7.ToString();
                        button10.Text = 8.ToString();
                        button11.Text = 9.ToString();
                        button12.Text = 10.ToString();
                        button13.Text = 11.ToString();
                        button14.Text = 12.ToString();
                        button15.Text = 13.ToString();
                        button16.Text = 14.ToString();
                        button17.Text = 15.ToString();
                        button18.Text = 16.ToString();
                        button19.Text = 17.ToString();
                        button20.Text = 18.ToString();
                        button21.Text = 19.ToString();
                        button22.Text = 20.ToString();
                        button23.Text = 21.ToString();
                        button24.Text = 22.ToString();
                        button25.Text = 23.ToString();
                        button26.Text = 24.ToString();
                        button27.Text = 25.ToString();
                        button28.Text = 26.ToString();
                        button29.Text = 27.ToString();
                        button30.Text = 28.ToString();
                        button31.Text = 29.ToString();
                        button32.Hide();
                        button33.Hide();
                        button34.Hide();
                        button35.Hide();
                        button36.Hide();
                        button37.Hide();
                        break;

                    case "Thursday":
                        button4.Show();
                        button5.Show();
                        button6.Show();
                        button7.Show();
                        button8.Show();
                        button9.Show();
                        button10.Show();
                        button11.Show();
                        button12.Show();
                        button13.Show();
                        button14.Show();
                        button15.Show();
                        button16.Show();
                        button17.Show();
                        button18.Show();
                        button19.Show();
                        button20.Show();
                        button21.Show();
                        button22.Show();
                        button23.Show();
                        button24.Show();
                        button25.Show();
                        button26.Show();
                        button27.Show();
                        button28.Show();
                        button29.Show();
                        button30.Show();
                        button31.Show();
                        button32.Show();

                        button1.Hide();
                        button2.Hide();
                        button3.Hide();
                        button4.Text = 1.ToString();
                        button5.Text = 2.ToString();
                        button6.Text = 3.ToString();
                        button7.Text = 4.ToString();
                        button8.Text = 5.ToString();
                        button9.Text = 6.ToString();
                        button10.Text = 7.ToString();
                        button11.Text = 8.ToString();
                        button12.Text = 9.ToString();
                        button13.Text = 10.ToString();
                        button14.Text = 11.ToString();
                        button15.Text = 12.ToString();
                        button16.Text = 13.ToString();
                        button17.Text = 14.ToString();
                        button18.Text = 15.ToString();
                        button19.Text = 16.ToString();
                        button20.Text = 17.ToString();
                        button21.Text = 18.ToString();
                        button22.Text = 19.ToString();
                        button23.Text = 20.ToString();
                        button24.Text = 21.ToString();
                        button25.Text = 22.ToString();
                        button26.Text = 23.ToString();
                        button27.Text = 24.ToString();
                        button28.Text = 25.ToString();
                        button29.Text = 26.ToString();
                        button30.Text = 27.ToString();
                        button31.Text = 28.ToString();
                        button32.Text = 29.ToString();
                        button33.Hide();
                        button34.Hide();
                        button35.Hide();
                        button36.Hide();
                        button37.Hide();
                        break;

                    case "Friday":
                        button5.Show();
                        button6.Show();
                        button7.Show();
                        button8.Show();
                        button9.Show();
                        button10.Show();
                        button11.Show();
                        button12.Show();
                        button13.Show();
                        button14.Show();
                        button15.Show();
                        button16.Show();
                        button17.Show();
                        button18.Show();
                        button19.Show();
                        button20.Show();
                        button21.Show();
                        button22.Show();
                        button23.Show();
                        button24.Show();
                        button25.Show();
                        button26.Show();
                        button27.Show();
                        button28.Show();
                        button29.Show();
                        button30.Show();
                        button31.Show();
                        button32.Show();
                        button33.Show();


                        button1.Hide();
                        button2.Hide();
                        button3.Hide();
                        button4.Hide();
                        button5.Text = 1.ToString();
                        button6.Text = 2.ToString();
                        button7.Text = 3.ToString();
                        button8.Text = 4.ToString();
                        button9.Text = 5.ToString();
                        button10.Text = 6.ToString();
                        button11.Text = 7.ToString();
                        button12.Text = 8.ToString();
                        button13.Text = 9.ToString();
                        button14.Text = 10.ToString();
                        button15.Text = 11.ToString();
                        button16.Text = 12.ToString();
                        button17.Text = 13.ToString();
                        button18.Text = 14.ToString();
                        button19.Text = 15.ToString();
                        button20.Text = 16.ToString();
                        button21.Text = 17.ToString();
                        button22.Text = 18.ToString();
                        button23.Text = 19.ToString();
                        button24.Text = 20.ToString();
                        button25.Text = 21.ToString();
                        button26.Text = 22.ToString();
                        button27.Text = 23.ToString();
                        button28.Text = 24.ToString();
                        button29.Text = 25.ToString();
                        button30.Text = 26.ToString();
                        button31.Text = 27.ToString();
                        button32.Text = 28.ToString();
                        button33.Text = 29.ToString();
                        button34.Hide();
                        button35.Hide();
                        button36.Hide();
                        button37.Hide();
                        break;

                    case "Saturday":

                        button6.Show();
                        button7.Show();
                        button8.Show();
                        button9.Show();
                        button10.Show();
                        button11.Show();
                        button12.Show();
                        button13.Show();
                        button14.Show();
                        button15.Show();
                        button16.Show();
                        button17.Show();
                        button18.Show();
                        button19.Show();
                        button20.Show();
                        button21.Show();
                        button22.Show();
                        button23.Show();
                        button24.Show();
                        button25.Show();
                        button26.Show();
                        button27.Show();
                        button28.Show();
                        button29.Show();
                        button30.Show();
                        button31.Show();
                        button32.Show();
                        button33.Show();
                        button34.Show();

                        button1.Hide();
                        button2.Hide();
                        button3.Hide();
                        button4.Hide();
                        button5.Hide();
                        button6.Text = 1.ToString();
                        button7.Text = 2.ToString();
                        button8.Text = 3.ToString();
                        button9.Text = 4.ToString();
                        button10.Text = 5.ToString();
                        button11.Text = 6.ToString();
                        button12.Text = 7.ToString();
                        button13.Text = 8.ToString();
                        button14.Text = 9.ToString();
                        button15.Text = 10.ToString();
                        button16.Text = 11.ToString();
                        button17.Text = 12.ToString();
                        button18.Text = 13.ToString();
                        button19.Text = 14.ToString();
                        button20.Text = 15.ToString();
                        button21.Text = 16.ToString();
                        button22.Text = 17.ToString();
                        button23.Text = 18.ToString();
                        button24.Text = 19.ToString();
                        button25.Text = 20.ToString();
                        button26.Text = 21.ToString();
                        button27.Text = 22.ToString();
                        button28.Text = 23.ToString();
                        button29.Text = 24.ToString();
                        button30.Text = 25.ToString();
                        button31.Text = 26.ToString();
                        button32.Text = 27.ToString();
                        button33.Text = 28.ToString();
                        button34.Text = 29.ToString();
                        button35.Hide();
                        button36.Hide();
                        button37.Hide();
                        break;

                    case "Sunday":
                        button7.Show();
                        button8.Show();
                        button9.Show();
                        button10.Show();
                        button11.Show();
                        button12.Show();
                        button13.Show();
                        button14.Show();
                        button15.Show();
                        button16.Show();
                        button17.Show();
                        button18.Show();
                        button19.Show();
                        button20.Show();
                        button21.Show();
                        button22.Show();
                        button23.Show();
                        button24.Show();
                        button25.Show();
                        button26.Show();
                        button27.Show();
                        button28.Show();
                        button29.Show();
                        button30.Show();
                        button31.Show();
                        button32.Show();
                        button33.Show();
                        button34.Show();
                        button35.Show();

                        button1.Hide();
                        button2.Hide();
                        button3.Hide();
                        button4.Hide();
                        button5.Hide();
                        button6.Hide();
                        button7.Text = 1.ToString();
                        button8.Text = 2.ToString();
                        button9.Text = 3.ToString();
                        button10.Text = 4.ToString();
                        button11.Text = 5.ToString();
                        button12.Text = 6.ToString();
                        button13.Text = 7.ToString();
                        button14.Text = 8.ToString();
                        button15.Text = 9.ToString();
                        button16.Text = 10.ToString();
                        button17.Text = 11.ToString();
                        button18.Text = 12.ToString();
                        button19.Text = 13.ToString();
                        button20.Text = 14.ToString();
                        button21.Text = 15.ToString();
                        button22.Text = 16.ToString();
                        button23.Text = 17.ToString();
                        button24.Text = 18.ToString();
                        button25.Text = 19.ToString();
                        button26.Text = 20.ToString();
                        button27.Text = 21.ToString();
                        button28.Text = 22.ToString();
                        button29.Text = 23.ToString();
                        button30.Text = 24.ToString();
                        button31.Text = 25.ToString();
                        button32.Text = 26.ToString();
                        button33.Text = 27.ToString();
                        button34.Text = 28.ToString();
                        button35.Text = 29.ToString();
                        button36.Hide();
                        button37.Hide();
                        break;
                }
            }
            if (durum == 3)
            {
                switch (gun)
                {
                    case "Monday":
                        button1.Show();
                        button2.Show();
                        button3.Show();
                        button4.Show();
                        button5.Show();
                        button6.Show();
                        button7.Show();
                        button8.Show();
                        button9.Show();
                        button10.Show();
                        button11.Show();
                        button12.Show();
                        button13.Show();
                        button14.Show();
                        button15.Show();
                        button16.Show();
                        button17.Show();
                        button18.Show();
                        button19.Show();
                        button20.Show();
                        button21.Show();
                        button22.Show();
                        button23.Show();
                        button24.Show();
                        button25.Show();
                        button26.Show();
                        button27.Show();
                        button28.Show();
                        button29.Show();
                        button30.Show();

                        button1.Text = 1.ToString();
                        button2.Text = 2.ToString();
                        button3.Text = 3.ToString();
                        button4.Text = 4.ToString();
                        button5.Text = 5.ToString();
                        button6.Text = 6.ToString();
                        button7.Text = 7.ToString();
                        button8.Text = 8.ToString();
                        button9.Text = 9.ToString();
                        button10.Text = 10.ToString();
                        button11.Text = 11.ToString();
                        button12.Text = 12.ToString();
                        button13.Text = 13.ToString();
                        button14.Text = 14.ToString();
                        button15.Text = 15.ToString();
                        button16.Text = 16.ToString();
                        button17.Text = 17.ToString();
                        button18.Text = 18.ToString();
                        button19.Text = 19.ToString();
                        button20.Text = 20.ToString();
                        button21.Text = 21.ToString();
                        button22.Text = 22.ToString();
                        button23.Text = 23.ToString();
                        button24.Text = 24.ToString();
                        button25.Text = 25.ToString();
                        button26.Text = 26.ToString();
                        button27.Text = 27.ToString();
                        button28.Text = 28.ToString();
                        button29.Text = 29.ToString();
                        button30.Text = 30.ToString();
                        button31.Hide();
                        button32.Hide();
                        button33.Hide();
                        button34.Hide();
                        button35.Hide();
                        button36.Hide();
                        button37.Hide();
                        break;

                    case "Tuesday":
                        button2.Show();
                        button3.Show();
                        button4.Show();
                        button5.Show();
                        button6.Show();
                        button7.Show();
                        button8.Show();
                        button9.Show();
                        button10.Show();
                        button11.Show();
                        button12.Show();
                        button13.Show();
                        button14.Show();
                        button15.Show();
                        button16.Show();
                        button17.Show();
                        button18.Show();
                        button19.Show();
                        button20.Show();
                        button21.Show();
                        button22.Show();
                        button23.Show();
                        button24.Show();
                        button25.Show();
                        button26.Show();
                        button27.Show();
                        button28.Show();
                        button29.Show();
                        button30.Show();
                        button31.Show();

                        button1.Hide();
                        button2.Text = 1.ToString();
                        button3.Text = 2.ToString();
                        button4.Text = 3.ToString();
                        button5.Text = 4.ToString();
                        button6.Text = 5.ToString();
                        button7.Text = 6.ToString();
                        button8.Text = 7.ToString();
                        button9.Text = 8.ToString();
                        button10.Text = 9.ToString();
                        button11.Text = 10.ToString();
                        button12.Text = 11.ToString();
                        button13.Text = 12.ToString();
                        button14.Text = 13.ToString();
                        button15.Text = 14.ToString();
                        button16.Text = 15.ToString();
                        button17.Text = 16.ToString();
                        button18.Text = 17.ToString();
                        button19.Text = 18.ToString();
                        button20.Text = 19.ToString();
                        button21.Text = 20.ToString();
                        button22.Text = 21.ToString();
                        button23.Text = 22.ToString();
                        button24.Text = 23.ToString();
                        button25.Text = 24.ToString();
                        button26.Text = 25.ToString();
                        button27.Text = 26.ToString();
                        button28.Text = 27.ToString();
                        button29.Text = 28.ToString();
                        button30.Text = 29.ToString();
                        button31.Text = 30.ToString();
                        button32.Hide();
                        button33.Hide();
                        button34.Hide();
                        button35.Hide();
                        button36.Hide();
                        button37.Hide();
                        break;

                    case "Wednesday":
                        button3.Show();
                        button4.Show();
                        button5.Show();
                        button6.Show();
                        button7.Show();
                        button8.Show();
                        button9.Show();
                        button10.Show();
                        button11.Show();
                        button12.Show();
                        button13.Show();
                        button14.Show();
                        button15.Show();
                        button16.Show();
                        button17.Show();
                        button18.Show();
                        button19.Show();
                        button20.Show();
                        button21.Show();
                        button22.Show();
                        button23.Show();
                        button24.Show();
                        button25.Show();
                        button26.Show();
                        button27.Show();
                        button28.Show();
                        button29.Show();
                        button30.Show();
                        button31.Show();
                        button32.Show();

                        button1.Hide();
                        button2.Hide();
                        button3.Text = 1.ToString();
                        button4.Text = 2.ToString();
                        button5.Text = 3.ToString();
                        button6.Text = 4.ToString();
                        button7.Text = 5.ToString();
                        button8.Text = 6.ToString();
                        button9.Text = 7.ToString();
                        button10.Text = 8.ToString();
                        button11.Text = 9.ToString();
                        button12.Text = 10.ToString();
                        button13.Text = 11.ToString();
                        button14.Text = 12.ToString();
                        button15.Text = 13.ToString();
                        button16.Text = 14.ToString();
                        button17.Text = 15.ToString();
                        button18.Text = 16.ToString();
                        button19.Text = 17.ToString();
                        button20.Text = 18.ToString();
                        button21.Text = 19.ToString();
                        button22.Text = 20.ToString();
                        button23.Text = 21.ToString();
                        button24.Text = 22.ToString();
                        button25.Text = 23.ToString();
                        button26.Text = 24.ToString();
                        button27.Text = 25.ToString();
                        button28.Text = 26.ToString();
                        button29.Text = 27.ToString();
                        button30.Text = 28.ToString();
                        button31.Text = 29.ToString();
                        button32.Text = 30.ToString();
                        button33.Hide();
                        button34.Hide();
                        button35.Hide();
                        button36.Hide();
                        button37.Hide();
                        break;

                    case "Thursday":
                        button4.Show();
                        button5.Show();
                        button6.Show();
                        button7.Show();
                        button8.Show();
                        button9.Show();
                        button10.Show();
                        button11.Show();
                        button12.Show();
                        button13.Show();
                        button14.Show();
                        button15.Show();
                        button16.Show();
                        button17.Show();
                        button18.Show();
                        button19.Show();
                        button20.Show();
                        button21.Show();
                        button22.Show();
                        button23.Show();
                        button24.Show();
                        button25.Show();
                        button26.Show();
                        button27.Show();
                        button28.Show();
                        button29.Show();
                        button30.Show();
                        button31.Show();
                        button32.Show();
                        button33.Show();

                        button1.Hide();
                        button2.Hide();
                        button3.Hide();
                        button4.Text = 1.ToString();
                        button5.Text = 2.ToString();
                        button6.Text = 3.ToString();
                        button7.Text = 4.ToString();
                        button8.Text = 5.ToString();
                        button9.Text = 6.ToString();
                        button10.Text = 7.ToString();
                        button11.Text = 8.ToString();
                        button12.Text = 9.ToString();
                        button13.Text = 10.ToString();
                        button14.Text = 11.ToString();
                        button15.Text = 12.ToString();
                        button16.Text = 13.ToString();
                        button17.Text = 14.ToString();
                        button18.Text = 15.ToString();
                        button19.Text = 16.ToString();
                        button20.Text = 17.ToString();
                        button21.Text = 18.ToString();
                        button22.Text = 19.ToString();
                        button23.Text = 20.ToString();
                        button24.Text = 21.ToString();
                        button25.Text = 22.ToString();
                        button26.Text = 23.ToString();
                        button27.Text = 24.ToString();
                        button28.Text = 25.ToString();
                        button29.Text = 26.ToString();
                        button30.Text = 27.ToString();
                        button31.Text = 28.ToString();
                        button32.Text = 29.ToString();
                        button33.Text = 30.ToString();
                        button34.Hide();
                        button35.Hide();
                        button36.Hide();
                        button37.Hide();
                        break;

                    case "Friday":
                        button5.Show();
                        button6.Show();
                        button7.Show();
                        button8.Show();
                        button9.Show();
                        button10.Show();
                        button11.Show();
                        button12.Show();
                        button13.Show();
                        button14.Show();
                        button15.Show();
                        button16.Show();
                        button17.Show();
                        button18.Show();
                        button19.Show();
                        button20.Show();
                        button21.Show();
                        button22.Show();
                        button23.Show();
                        button24.Show();
                        button25.Show();
                        button26.Show();
                        button27.Show();
                        button28.Show();
                        button29.Show();
                        button30.Show();
                        button31.Show();
                        button32.Show();
                        button33.Show();
                        button34.Show();


                        button1.Hide();
                        button2.Hide();
                        button3.Hide();
                        button4.Hide();
                        button5.Text = 1.ToString();
                        button6.Text = 2.ToString();
                        button7.Text = 3.ToString();
                        button8.Text = 4.ToString();
                        button9.Text = 5.ToString();
                        button10.Text = 6.ToString();
                        button11.Text = 7.ToString();
                        button12.Text = 8.ToString();
                        button13.Text = 9.ToString();
                        button14.Text = 10.ToString();
                        button15.Text = 11.ToString();
                        button16.Text = 12.ToString();
                        button17.Text = 13.ToString();
                        button18.Text = 14.ToString();
                        button19.Text = 15.ToString();
                        button20.Text = 16.ToString();
                        button21.Text = 17.ToString();
                        button22.Text = 18.ToString();
                        button23.Text = 19.ToString();
                        button24.Text = 20.ToString();
                        button25.Text = 21.ToString();
                        button26.Text = 22.ToString();
                        button27.Text = 23.ToString();
                        button28.Text = 24.ToString();
                        button29.Text = 25.ToString();
                        button30.Text = 26.ToString();
                        button31.Text = 27.ToString();
                        button32.Text = 28.ToString();
                        button33.Text = 29.ToString();
                        button34.Text = 30.ToString();
                        button35.Hide();
                        button36.Hide();
                        button37.Hide();
                        break;

                    case "Saturday":

                        button6.Show();
                        button7.Show();
                        button8.Show();
                        button9.Show();
                        button10.Show();
                        button11.Show();
                        button12.Show();
                        button13.Show();
                        button14.Show();
                        button15.Show();
                        button16.Show();
                        button17.Show();
                        button18.Show();
                        button19.Show();
                        button20.Show();
                        button21.Show();
                        button22.Show();
                        button23.Show();
                        button24.Show();
                        button25.Show();
                        button26.Show();
                        button27.Show();
                        button28.Show();
                        button29.Show();
                        button30.Show();
                        button31.Show();
                        button32.Show();
                        button33.Show();
                        button34.Show();
                        button35.Show();

                        button1.Hide();
                        button2.Hide();
                        button3.Hide();
                        button4.Hide();
                        button5.Hide();
                        button6.Text = 1.ToString();
                        button7.Text = 2.ToString();
                        button8.Text = 3.ToString();
                        button9.Text = 4.ToString();
                        button10.Text = 5.ToString();
                        button11.Text = 6.ToString();
                        button12.Text = 7.ToString();
                        button13.Text = 8.ToString();
                        button14.Text = 9.ToString();
                        button15.Text = 10.ToString();
                        button16.Text = 11.ToString();
                        button17.Text = 12.ToString();
                        button18.Text = 13.ToString();
                        button19.Text = 14.ToString();
                        button20.Text = 15.ToString();
                        button21.Text = 16.ToString();
                        button22.Text = 17.ToString();
                        button23.Text = 18.ToString();
                        button24.Text = 19.ToString();
                        button25.Text = 20.ToString();
                        button26.Text = 21.ToString();
                        button27.Text = 22.ToString();
                        button28.Text = 23.ToString();
                        button29.Text = 24.ToString();
                        button30.Text = 25.ToString();
                        button31.Text = 26.ToString();
                        button32.Text = 27.ToString();
                        button33.Text = 28.ToString();
                        button34.Text = 29.ToString();
                        button35.Text = 30.ToString();
                        button36.Hide();
                        button37.Hide();
                        break;

                    case "Sunday":
                        button7.Show();
                        button8.Show();
                        button9.Show();
                        button10.Show();
                        button11.Show();
                        button12.Show();
                        button13.Show();
                        button14.Show();
                        button15.Show();
                        button16.Show();
                        button17.Show();
                        button18.Show();
                        button19.Show();
                        button20.Show();
                        button21.Show();
                        button22.Show();
                        button23.Show();
                        button24.Show();
                        button25.Show();
                        button26.Show();
                        button27.Show();
                        button28.Show();
                        button29.Show();
                        button30.Show();
                        button31.Show();
                        button32.Show();
                        button33.Show();
                        button34.Show();
                        button35.Show();
                        button36.Show();

                        button1.Hide();
                        button2.Hide();
                        button3.Hide();
                        button4.Hide();
                        button5.Hide();
                        button6.Hide();
                        button7.Text = 1.ToString();
                        button8.Text = 2.ToString();
                        button9.Text = 3.ToString();
                        button10.Text = 4.ToString();
                        button11.Text = 5.ToString();
                        button12.Text = 6.ToString();
                        button13.Text = 7.ToString();
                        button14.Text = 8.ToString();
                        button15.Text = 9.ToString();
                        button16.Text = 10.ToString();
                        button17.Text = 11.ToString();
                        button18.Text = 12.ToString();
                        button19.Text = 13.ToString();
                        button20.Text = 14.ToString();
                        button21.Text = 15.ToString();
                        button22.Text = 16.ToString();
                        button23.Text = 17.ToString();
                        button24.Text = 18.ToString();
                        button25.Text = 19.ToString();
                        button26.Text = 20.ToString();
                        button27.Text = 21.ToString();
                        button28.Text = 22.ToString();
                        button29.Text = 23.ToString();
                        button30.Text = 24.ToString();
                        button31.Text = 25.ToString();
                        button32.Text = 26.ToString();
                        button33.Text = 27.ToString();
                        button34.Text = 28.ToString();
                        button35.Text = 29.ToString();
                        button36.Text = 30.ToString();
                        button37.Hide();
                        break;
                }
            }
            if (durum == 4)
            {
                switch (gun)
                {
                    case "Monday":
                        button1.Show();
                        button2.Show();
                        button3.Show();
                        button4.Show();
                        button5.Show();
                        button6.Show();
                        button7.Show();
                        button8.Show();
                        button9.Show();
                        button10.Show();
                        button11.Show();
                        button12.Show();
                        button13.Show();
                        button14.Show();
                        button15.Show();
                        button16.Show();
                        button17.Show();
                        button18.Show();
                        button19.Show();
                        button20.Show();
                        button21.Show();
                        button22.Show();
                        button23.Show();
                        button24.Show();
                        button25.Show();
                        button26.Show();
                        button27.Show();
                        button28.Show();
                        button29.Show();
                        button30.Show();
                        button31.Show();

                        button1.Text = 1.ToString();
                        button2.Text = 2.ToString();
                        button3.Text = 3.ToString();
                        button4.Text = 4.ToString();
                        button5.Text = 5.ToString();
                        button6.Text = 6.ToString();
                        button7.Text = 7.ToString();
                        button8.Text = 8.ToString();
                        button9.Text = 9.ToString();
                        button10.Text = 10.ToString();
                        button11.Text = 11.ToString();
                        button12.Text = 12.ToString();
                        button13.Text = 13.ToString();
                        button14.Text = 14.ToString();
                        button15.Text = 15.ToString();
                        button16.Text = 16.ToString();
                        button17.Text = 17.ToString();
                        button18.Text = 18.ToString();
                        button19.Text = 19.ToString();
                        button20.Text = 20.ToString();
                        button21.Text = 21.ToString();
                        button22.Text = 22.ToString();
                        button23.Text = 23.ToString();
                        button24.Text = 24.ToString();
                        button25.Text = 25.ToString();
                        button26.Text = 26.ToString();
                        button27.Text = 27.ToString();
                        button28.Text = 28.ToString();
                        button29.Text = 29.ToString();
                        button30.Text = 30.ToString();
                        button31.Text = 31.ToString();
                        button32.Hide();
                        button33.Hide();
                        button34.Hide();
                        button35.Hide();
                        button36.Hide();
                        button37.Hide();
                        break;

                    case "Tuesday":
                        button2.Show();
                        button3.Show();
                        button4.Show();
                        button5.Show();
                        button6.Show();
                        button7.Show();
                        button8.Show();
                        button9.Show();
                        button10.Show();
                        button11.Show();
                        button12.Show();
                        button13.Show();
                        button14.Show();
                        button15.Show();
                        button16.Show();
                        button17.Show();
                        button18.Show();
                        button19.Show();
                        button20.Show();
                        button21.Show();
                        button22.Show();
                        button23.Show();
                        button24.Show();
                        button25.Show();
                        button26.Show();
                        button27.Show();
                        button28.Show();
                        button29.Show();
                        button30.Show();
                        button31.Show();
                        button32.Show();

                        button1.Hide();
                        button2.Text = 1.ToString();
                        button3.Text = 2.ToString();
                        button4.Text = 3.ToString();
                        button5.Text = 4.ToString();
                        button6.Text = 5.ToString();
                        button7.Text = 6.ToString();
                        button8.Text = 7.ToString();
                        button9.Text = 8.ToString();
                        button10.Text = 9.ToString();
                        button11.Text = 10.ToString();
                        button12.Text = 11.ToString();
                        button13.Text = 12.ToString();
                        button14.Text = 13.ToString();
                        button15.Text = 14.ToString();
                        button16.Text = 15.ToString();
                        button17.Text = 16.ToString();
                        button18.Text = 17.ToString();
                        button19.Text = 18.ToString();
                        button20.Text = 19.ToString();
                        button21.Text = 20.ToString();
                        button22.Text = 21.ToString();
                        button23.Text = 22.ToString();
                        button24.Text = 23.ToString();
                        button25.Text = 24.ToString();
                        button26.Text = 25.ToString();
                        button27.Text = 26.ToString();
                        button28.Text = 27.ToString();
                        button29.Text = 28.ToString();
                        button30.Text = 29.ToString();
                        button31.Text = 30.ToString(); 
                        button32.Text = 31.ToString();
                        button33.Hide();
                        button34.Hide();
                        button35.Hide();
                        button36.Hide();
                        button37.Hide();
                        break;

                    case "Wednesday":
                        button3.Show();
                        button4.Show();
                        button5.Show();
                        button6.Show();
                        button7.Show();
                        button8.Show();
                        button9.Show();
                        button10.Show();
                        button11.Show();
                        button12.Show();
                        button13.Show();
                        button14.Show();
                        button15.Show();
                        button16.Show();
                        button17.Show();
                        button18.Show();
                        button19.Show();
                        button20.Show();
                        button21.Show();
                        button22.Show();
                        button23.Show();
                        button24.Show();
                        button25.Show();
                        button26.Show();
                        button27.Show();
                        button28.Show();
                        button29.Show();
                        button30.Show();
                        button31.Show();
                        button32.Show();
                        button33.Show();

                        button1.Hide();
                        button2.Hide();
                        button3.Text = 1.ToString();
                        button4.Text = 2.ToString();
                        button5.Text = 3.ToString();
                        button6.Text = 4.ToString();
                        button7.Text = 5.ToString();
                        button8.Text = 6.ToString();
                        button9.Text = 7.ToString();
                        button10.Text = 8.ToString();
                        button11.Text = 9.ToString();
                        button12.Text = 10.ToString();
                        button13.Text = 11.ToString();
                        button14.Text = 12.ToString();
                        button15.Text = 13.ToString();
                        button16.Text = 14.ToString();
                        button17.Text = 15.ToString();
                        button18.Text = 16.ToString();
                        button19.Text = 17.ToString();
                        button20.Text = 18.ToString();
                        button21.Text = 19.ToString();
                        button22.Text = 20.ToString();
                        button23.Text = 21.ToString();
                        button24.Text = 22.ToString();
                        button25.Text = 23.ToString();
                        button26.Text = 24.ToString();
                        button27.Text = 25.ToString();
                        button28.Text = 26.ToString();
                        button29.Text = 27.ToString();
                        button30.Text = 28.ToString();
                        button31.Text = 29.ToString();
                        button32.Text = 30.ToString();
                        button33.Text = 31.ToString();
                        button34.Hide();
                        button35.Hide();
                        button36.Hide();
                        button37.Hide();
                        break;

                    case "Thursday":
                        button4.Show();
                        button5.Show();
                        button6.Show();
                        button7.Show();
                        button8.Show();
                        button9.Show();
                        button10.Show();
                        button11.Show();
                        button12.Show();
                        button13.Show();
                        button14.Show();
                        button15.Show();
                        button16.Show();
                        button17.Show();
                        button18.Show();
                        button19.Show();
                        button20.Show();
                        button21.Show();
                        button22.Show();
                        button23.Show();
                        button24.Show();
                        button25.Show();
                        button26.Show();
                        button27.Show();
                        button28.Show();
                        button29.Show();
                        button30.Show();
                        button31.Show();
                        button32.Show();
                        button33.Show();
                        button34.Show();

                        button1.Hide();
                        button2.Hide();
                        button3.Hide();
                        button4.Text = 1.ToString();
                        button5.Text = 2.ToString();
                        button6.Text = 3.ToString();
                        button7.Text = 4.ToString();
                        button8.Text = 5.ToString();
                        button9.Text = 6.ToString();
                        button10.Text = 7.ToString();
                        button11.Text = 8.ToString();
                        button12.Text = 9.ToString();
                        button13.Text = 10.ToString();
                        button14.Text = 11.ToString();
                        button15.Text = 12.ToString();
                        button16.Text = 13.ToString();
                        button17.Text = 14.ToString();
                        button18.Text = 15.ToString();
                        button19.Text = 16.ToString();
                        button20.Text = 17.ToString();
                        button21.Text = 18.ToString();
                        button22.Text = 19.ToString();
                        button23.Text = 20.ToString();
                        button24.Text = 21.ToString();
                        button25.Text = 22.ToString();
                        button26.Text = 23.ToString();
                        button27.Text = 24.ToString();
                        button28.Text = 25.ToString();
                        button29.Text = 26.ToString();
                        button30.Text = 27.ToString();
                        button31.Text = 28.ToString();
                        button32.Text = 29.ToString();
                        button33.Text = 30.ToString();
                        button34.Text = 31.ToString();
                        button35.Hide();
                        button36.Hide();
                        button37.Hide();
                        break;

                    case "Friday":
                        button5.Show();
                        button6.Show();
                        button7.Show();
                        button8.Show();
                        button9.Show();
                        button10.Show();
                        button11.Show();
                        button12.Show();
                        button13.Show();
                        button14.Show();
                        button15.Show();
                        button16.Show();
                        button17.Show();
                        button18.Show();
                        button19.Show();
                        button20.Show();
                        button21.Show();
                        button22.Show();
                        button23.Show();
                        button24.Show();
                        button25.Show();
                        button26.Show();
                        button27.Show();
                        button28.Show();
                        button29.Show();
                        button30.Show();
                        button31.Show();
                        button32.Show();
                        button33.Show();
                        button34.Show();
                        button35.Show();


                        button1.Hide();
                        button2.Hide();
                        button3.Hide();
                        button4.Hide();
                        button5.Text = 1.ToString();
                        button6.Text = 2.ToString();
                        button7.Text = 3.ToString();
                        button8.Text = 4.ToString();
                        button9.Text = 5.ToString();
                        button10.Text = 6.ToString();
                        button11.Text = 7.ToString();
                        button12.Text = 8.ToString();
                        button13.Text = 9.ToString();
                        button14.Text = 10.ToString();
                        button15.Text = 11.ToString();
                        button16.Text = 12.ToString();
                        button17.Text = 13.ToString();
                        button18.Text = 14.ToString();
                        button19.Text = 15.ToString();
                        button20.Text = 16.ToString();
                        button21.Text = 17.ToString();
                        button22.Text = 18.ToString();
                        button23.Text = 19.ToString();
                        button24.Text = 20.ToString();
                        button25.Text = 21.ToString();
                        button26.Text = 22.ToString();
                        button27.Text = 23.ToString();
                        button28.Text = 24.ToString();
                        button29.Text = 25.ToString();
                        button30.Text = 26.ToString();
                        button31.Text = 27.ToString();
                        button32.Text = 28.ToString();
                        button33.Text = 29.ToString();
                        button34.Text = 30.ToString();
                        button35.Text = 31.ToString();
                        button36.Hide();
                        button37.Hide();
                        break;

                    case "Saturday":

                        button6.Show();
                        button7.Show();
                        button8.Show();
                        button9.Show();
                        button10.Show();
                        button11.Show();
                        button12.Show();
                        button13.Show();
                        button14.Show();
                        button15.Show();
                        button16.Show();
                        button17.Show();
                        button18.Show();
                        button19.Show();
                        button20.Show();
                        button21.Show();
                        button22.Show();
                        button23.Show();
                        button24.Show();
                        button25.Show();
                        button26.Show();
                        button27.Show();
                        button28.Show();
                        button29.Show();
                        button30.Show();
                        button31.Show();
                        button32.Show();
                        button33.Show();
                        button34.Show();
                        button35.Show();
                        button36.Show();

                        button1.Hide();
                        button2.Hide();
                        button3.Hide();
                        button4.Hide();
                        button5.Hide();
                        button6.Text = 1.ToString();
                        button7.Text = 2.ToString();
                        button8.Text = 3.ToString();
                        button9.Text = 4.ToString();
                        button10.Text = 5.ToString();
                        button11.Text = 6.ToString();
                        button12.Text = 7.ToString();
                        button13.Text = 8.ToString();
                        button14.Text = 9.ToString();
                        button15.Text = 10.ToString();
                        button16.Text = 11.ToString();
                        button17.Text = 12.ToString();
                        button18.Text = 13.ToString();
                        button19.Text = 14.ToString();
                        button20.Text = 15.ToString();
                        button21.Text = 16.ToString();
                        button22.Text = 17.ToString();
                        button23.Text = 18.ToString();
                        button24.Text = 19.ToString();
                        button25.Text = 20.ToString();
                        button26.Text = 21.ToString();
                        button27.Text = 22.ToString();
                        button28.Text = 23.ToString();
                        button29.Text = 24.ToString();
                        button30.Text = 25.ToString();
                        button31.Text = 26.ToString();
                        button32.Text = 27.ToString();
                        button33.Text = 28.ToString();
                        button34.Text = 29.ToString();
                        button35.Text = 30.ToString();
                        button36.Text = 31.ToString();
                        button37.Hide();
                        break;

                    case "Sunday":
                        button7.Show();
                        button8.Show();
                        button9.Show();
                        button10.Show();
                        button11.Show();
                        button12.Show();
                        button13.Show();
                        button14.Show();
                        button15.Show();
                        button16.Show();
                        button17.Show();
                        button18.Show();
                        button19.Show();
                        button20.Show();
                        button21.Show();
                        button22.Show();
                        button23.Show();
                        button24.Show();
                        button25.Show();
                        button26.Show();
                        button27.Show();
                        button28.Show();
                        button29.Show();
                        button30.Show();
                        button31.Show();
                        button32.Show();
                        button33.Show();
                        button34.Show();
                        button35.Show();
                        button36.Show();
                        button37.Show();

                        button1.Hide();
                        button2.Hide();
                        button3.Hide();
                        button4.Hide();
                        button5.Hide();
                        button6.Hide();
                        button7.Text = 1.ToString();
                        button8.Text = 2.ToString();
                        button9.Text = 3.ToString();
                        button10.Text = 4.ToString();
                        button11.Text = 5.ToString();
                        button12.Text = 6.ToString();
                        button13.Text = 7.ToString();
                        button14.Text = 8.ToString();
                        button15.Text = 9.ToString();
                        button16.Text = 10.ToString();
                        button17.Text = 11.ToString();
                        button18.Text = 12.ToString();
                        button19.Text = 13.ToString();
                        button20.Text = 14.ToString();
                        button21.Text = 15.ToString();
                        button22.Text = 16.ToString();
                        button23.Text = 17.ToString();
                        button24.Text = 18.ToString();
                        button25.Text = 19.ToString();
                        button26.Text = 20.ToString();
                        button27.Text = 21.ToString();
                        button28.Text = 22.ToString();
                        button29.Text = 23.ToString();
                        button30.Text = 24.ToString();
                        button31.Text = 25.ToString();
                        button32.Text = 26.ToString();
                        button33.Text = 27.ToString();
                        button34.Text = 28.ToString();
                        button35.Text = 29.ToString();
                        button36.Text = 30.ToString();
                        button37.Text = 31.ToString();
                        break;
                }
            }
        }

        // ekle formu
        private void ekle_MouseHover(object sender, EventArgs e)
        {
            ekle.ForeColor = Color.WhiteSmoke;
        }

        private void ekle_MouseLeave(object sender, EventArgs e)
        {
            ekle.ForeColor = Color.Silver;
        }

        private void ekle_Click(object sender, EventArgs e)
        {
            Ekle ekle_form = new Ekle();
            if (Application.OpenForms["Ekle"] == null)
            {
                ekle_form.Show();

            }
        }

        // Ay ve yıl okları
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

            tarihin_gununu_bul();
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

            tarihin_gununu_bul();
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
            if (Application.OpenForms["Aylar"]==null)
            {
                ay_form.Show();

            }
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
            if (Application.OpenForms["Yillar"] == null)
            {
                yil_form.Show();

            }
        }

        // butonların flat ayarları
        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.FlatAppearance.BorderColor = Color.Silver;
            button1.FlatAppearance.BorderSize = 1;
        }
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.FlatAppearance.BorderSize = 0;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.FlatAppearance.BorderColor = Color.Silver;
            button2.FlatAppearance.BorderSize = 1;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.FlatAppearance.BorderSize = 0;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.FlatAppearance.BorderColor = Color.Silver;
            button3.FlatAppearance.BorderSize = 1;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.FlatAppearance.BorderSize = 0;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.FlatAppearance.BorderColor = Color.Silver;
            button4.FlatAppearance.BorderSize = 1;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.FlatAppearance.BorderSize = 0;
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            button5.FlatAppearance.BorderColor = Color.Silver;
            button5.FlatAppearance.BorderSize = 1;

        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.FlatAppearance.BorderSize = 0;
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            button6.FlatAppearance.BorderColor = Color.Silver;
            button6.FlatAppearance.BorderSize = 1;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.FlatAppearance.BorderSize = 0;
        }

        private void button7_MouseHover(object sender, EventArgs e)
        {
            button7.FlatAppearance.BorderColor = Color.Silver;
            button7.FlatAppearance.BorderSize = 1;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.FlatAppearance.BorderSize = 0;
        }

        private void button8_MouseHover(object sender, EventArgs e)
        {
            button8.FlatAppearance.BorderColor = Color.Silver;
            button8.FlatAppearance.BorderSize = 1;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            button8.FlatAppearance.BorderSize = 0;
        }

        private void button9_MouseHover(object sender, EventArgs e)
        {
            button9.FlatAppearance.BorderColor = Color.Silver;
            button9.FlatAppearance.BorderSize = 1;
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            button9.FlatAppearance.BorderSize = 0;
        }

        private void button10_MouseHover(object sender, EventArgs e)
        {
            button10.FlatAppearance.BorderColor = Color.Silver;
            button10.FlatAppearance.BorderSize = 1;
        }

        private void button10_MouseLeave(object sender, EventArgs e)
        {
            button10.FlatAppearance.BorderSize = 0;
        }

        private void button11_MouseHover(object sender, EventArgs e)
        {
            button11.FlatAppearance.BorderColor = Color.Silver;
            button11.FlatAppearance.BorderSize = 1;
        }

        private void button11_MouseLeave(object sender, EventArgs e)
        {
            button11.FlatAppearance.BorderSize = 0;
        }

        private void button12_MouseHover(object sender, EventArgs e)
        {
            button12.FlatAppearance.BorderColor = Color.Silver;
            button12.FlatAppearance.BorderSize = 1;
        }

        private void button12_MouseLeave(object sender, EventArgs e)
        {
            button12.FlatAppearance.BorderSize = 0;
        }

        private void button13_MouseHover(object sender, EventArgs e)
        {
            button13.FlatAppearance.BorderColor = Color.Silver;
            button13.FlatAppearance.BorderSize = 1;
        }

        private void button13_MouseLeave(object sender, EventArgs e)
        {
            button13.FlatAppearance.BorderSize = 0;
        }

        private void button14_MouseHover(object sender, EventArgs e)
        {
            button14.FlatAppearance.BorderColor = Color.Silver;
            button14.FlatAppearance.BorderSize = 1;
        }
        private void button14_MouseLeave_1(object sender, EventArgs e)
        {
            button14.FlatAppearance.BorderSize = 0;
        }

        private void button15_MouseHover(object sender, EventArgs e)
        {
            button15.FlatAppearance.BorderColor = Color.Silver;
            button15.FlatAppearance.BorderSize = 1;
        }

        private void button15_MouseLeave(object sender, EventArgs e)
        {
            button15.FlatAppearance.BorderSize = 0;
        }

        private void button16_MouseHover(object sender, EventArgs e)
        {
            button16.FlatAppearance.BorderColor = Color.Silver;
            button16.FlatAppearance.BorderSize = 1;
        }

        private void button16_MouseLeave(object sender, EventArgs e)
        {
            button16.FlatAppearance.BorderSize = 0;
        }

        private void button17_MouseHover(object sender, EventArgs e)
        {
            button17.FlatAppearance.BorderColor = Color.Silver;
            button17.FlatAppearance.BorderSize = 1;
        }

        private void button17_MouseLeave(object sender, EventArgs e)
        {
            button17.FlatAppearance.BorderSize = 0;
        }

        private void button18_MouseHover(object sender, EventArgs e)
        {
            button18.FlatAppearance.BorderColor = Color.Silver;
            button18.FlatAppearance.BorderSize = 1;
        }

        private void button18_MouseLeave(object sender, EventArgs e)
        {
            button18.FlatAppearance.BorderSize = 0;
        }

        private void button19_MouseHover(object sender, EventArgs e)
        {
            button19.FlatAppearance.BorderColor = Color.Silver;
            button19.FlatAppearance.BorderSize = 1;
        }

        private void button19_MouseLeave(object sender, EventArgs e)
        {
            button19.FlatAppearance.BorderSize = 0;
        }

        private void button20_MouseHover(object sender, EventArgs e)
        {
            button20.FlatAppearance.BorderColor = Color.Silver;
            button20.FlatAppearance.BorderSize = 1;
        }

        private void button20_MouseLeave(object sender, EventArgs e)
        {
            button20.FlatAppearance.BorderSize = 0;
        }

        private void button21_MouseHover(object sender, EventArgs e)
        {
            button21.FlatAppearance.BorderColor = Color.Silver;
            button21.FlatAppearance.BorderSize = 1;
        }

        private void button21_MouseLeave(object sender, EventArgs e)
        {
            button21.FlatAppearance.BorderSize = 0;
        }

        private void button22_MouseHover(object sender, EventArgs e)
        {
            button22.FlatAppearance.BorderColor = Color.Silver;
            button22.FlatAppearance.BorderSize = 1;
        }

        private void button22_MouseLeave(object sender, EventArgs e)
        {
            button22.FlatAppearance.BorderSize = 0;
        }

        private void button23_MouseHover(object sender, EventArgs e)
        {
            button23.FlatAppearance.BorderColor = Color.Silver;
            button23.FlatAppearance.BorderSize = 1;
        }

        private void button23_MouseLeave(object sender, EventArgs e)
        {
            button23.FlatAppearance.BorderSize = 0;
        }

        private void button24_MouseHover(object sender, EventArgs e)
        {
            button24.FlatAppearance.BorderColor = Color.Silver;
            button24.FlatAppearance.BorderSize = 1;
        }

        private void button24_MouseLeave(object sender, EventArgs e)
        {
            button24.FlatAppearance.BorderSize = 0;
        }

        private void button25_MouseHover(object sender, EventArgs e)
        {
            button25.FlatAppearance.BorderColor = Color.Silver;
            button25.FlatAppearance.BorderSize = 1;
        }

        private void button25_MouseLeave(object sender, EventArgs e)
        {
            button25.FlatAppearance.BorderSize = 0;
        }

        private void button26_MouseHover(object sender, EventArgs e)
        {
            button26.FlatAppearance.BorderColor = Color.Silver;
            button26.FlatAppearance.BorderSize = 1;
        }

        private void button26_MouseLeave(object sender, EventArgs e)
        {
            button26.FlatAppearance.BorderSize = 0;
        }

        private void button27_MouseHover(object sender, EventArgs e)
        {
            button27.FlatAppearance.BorderColor = Color.Silver;
            button27.FlatAppearance.BorderSize = 1;
        }

        private void button27_MouseLeave(object sender, EventArgs e)
        {
            button27.FlatAppearance.BorderSize = 0;
        }

        private void button28_MouseHover(object sender, EventArgs e)
        {
            button28.FlatAppearance.BorderColor = Color.Silver;
            button28.FlatAppearance.BorderSize = 1;
        }

        private void button28_MouseLeave(object sender, EventArgs e)
        {
            button28.FlatAppearance.BorderSize = 0;
        }

        private void button29_MouseHover(object sender, EventArgs e)
        {
            button29.FlatAppearance.BorderColor = Color.Silver;
            button29.FlatAppearance.BorderSize = 1;
        }

        private void button29_MouseLeave(object sender, EventArgs e)
        {
            button29.FlatAppearance.BorderSize = 0;
        }

        private void button30_MouseHover(object sender, EventArgs e)
        {
            button30.FlatAppearance.BorderColor = Color.Silver;
            button30.FlatAppearance.BorderSize = 1;
        }

        private void button30_MouseLeave(object sender, EventArgs e)
        {
            button30.FlatAppearance.BorderSize = 0;
        }

        private void button31_MouseHover(object sender, EventArgs e)
        {
            button31.FlatAppearance.BorderColor = Color.Silver;
            button31.FlatAppearance.BorderSize = 1;
        }

        private void button31_MouseLeave(object sender, EventArgs e)
        {
            button31.FlatAppearance.BorderSize = 0;
        }

        private void button32_MouseHover(object sender, EventArgs e)
        {
            button32.FlatAppearance.BorderColor = Color.Silver;
            button32.FlatAppearance.BorderSize = 1;
        }

        private void button32_MouseLeave(object sender, EventArgs e)
        {
            button32.FlatAppearance.BorderSize = 0;
        }

        private void button33_MouseHover(object sender, EventArgs e)
        {
            button33.FlatAppearance.BorderColor = Color.Silver;
            button33.FlatAppearance.BorderSize = 1;
        }

        private void button33_MouseLeave(object sender, EventArgs e)
        {
            button33.FlatAppearance.BorderSize = 0;
        }

        private void button34_MouseHover(object sender, EventArgs e)
        {
            button34.FlatAppearance.BorderColor = Color.Silver;
            button34.FlatAppearance.BorderSize = 1;
        }

        private void button34_MouseLeave(object sender, EventArgs e)
        {
            button34.FlatAppearance.BorderSize = 0;
        }

        private void button35_MouseHover(object sender, EventArgs e)
        {
            button35.FlatAppearance.BorderColor = Color.Silver;
            button35.FlatAppearance.BorderSize = 1;
        }

        private void button35_MouseLeave(object sender, EventArgs e)
        {
            button35.FlatAppearance.BorderSize = 0;
        }

        private void button36_MouseHover(object sender, EventArgs e)
        {
            button36.FlatAppearance.BorderColor = Color.Silver;
            button36.FlatAppearance.BorderSize = 1;
        }

        private void button36_MouseLeave(object sender, EventArgs e)
        {
            button36.FlatAppearance.BorderSize = 0;
        }

        private void button37_MouseHover(object sender, EventArgs e)
        {
            button37.FlatAppearance.BorderColor = Color.Silver;
            button37.FlatAppearance.BorderSize = 1;
        }

        private void button37_MouseLeave(object sender, EventArgs e)
        {
            button37.FlatAppearance.BorderSize = 0;
        }

        // gün butonları liste açma
        private void button1_Click(object sender, EventArgs e)
        {
            int gun = Convert.ToInt32(button1.Text);
            anasayfa_list(gun);
        }
    }
}
