/***********************************************************************************************
**                                      SAKARYA ÜNİVERSİTESİ
**                                      BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**                                      BİLİŞİM SİSTEMLERİ MÜHENDİSLİĞİ BÖLÜMÜ
**                                      NESNEYE DAYALI PROGRAMLAMA DERSİ
**                                      2019-2020 BAHAR DÖNEMİ
**
**                                      ÖDEV NUMARASI ........:
**                                      ÖĞRENCİ ADI Ahmet Cenan Akdoğan:
**                                      ÖĞRENCİ NUMARASI B191200040:
**                                      DERSİN ALINDIĞI GRUP...:
***********************************************************************************************/
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

namespace Ndp_Proje
{
    public partial class Form1 : Form
    {


        public static string SetValueForText1 = "test verisi";

        public Form1()
        {
            InitializeComponent();
        }
        //sql baglantisini acıyoruz
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-N8GETE5G;Initial Catalog=BankaProje;Integrated Security=True");
        SqlDataReader reader;

        static Random random;
        public static string RastSeriNo()//kullanıcıya random seri numarası vermek için metod oluşturuyoruz ve bu metodta 1 tane rastgele char ve yanına 100 ile 1000 arasında bir sayı geliyor.
        {
            random = new Random();
            int num = random.Next(0, 7);
            char ch = (char)('a' + num);
            int sayi = random.Next(100, 999);
            string serino = ch + sayi.ToString();
            return serino;
        }
        public string tckn;
        public string TCno, Serino;
        private void btnGiris_Click(object sender, EventArgs e)
        {
            TCno = txtKimlikno.Text;
            Serino = txtSerino.Text;

            SetValueForText1 = txtKimlikno.Text;//diğer formlarda kullanabilmek için public değişkene tcnin değerini atıyoruz.

            //sql bağlatısı açıyoruz ve giriş bilgilerini veritabanından kontrol edip doğruysa anasayfaya gönderiyoruz.
            SqlCommand komut = baglanti.CreateCommand();
            komut.CommandText = "Select * From kayit where tckimlik='" + TCno + "' and serino='" + Serino + "'";
            baglanti.Open();
            reader = komut.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show("Giris Başarılı Anasayfaya Yönlendiriliyorsunuz.", "Başarılı");
                tckn = txtKimlikno.Text;
                Form2 frm2 = new Form2();
                this.Hide();
                frm2.Show();
            }
            else
            {

                MessageBox.Show("Lütfen Seri Numarası Alıp Tekrar Deneyiniz", "Hata!");
            }
            baglanti.Close();
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            //kayıt butonuna tıklayınca  eğer tc kimliği boş değil ise oluşturduğumuz metod ile kullanıcıya random serino veriyoruz ve kullanıcının tc si ile birlikte veri tabanında kayıt ediyouz.
            if (string.IsNullOrEmpty(txtKimlikno.Text) || string.IsNullOrEmpty(txtSerino.Text))
            {
                if (string.IsNullOrEmpty(txtKimlikno.Text))
                {
                    MessageBox.Show("Lütfen Alanları Boş Bırakmayın");
                }
                else if (string.IsNullOrEmpty(txtSerino.Text))
                {
                    KayitEkle();
                }
            }
            else
            {
                KayitEkle();
            }

        }

        private void KayitEkle()
        {
            //aynı kodları 2 kere yazmamak için metod haline getiriyoruz.
            txtSerino.Text = RastSeriNo();
            baglanti.Open();
            SqlCommand komut = baglanti.CreateCommand();
            komut.CommandText = "insert kayit(tckimlik, serino) values('" + txtKimlikno.Text + "', '" + txtSerino.Text + "')";
            komut.ExecuteNonQuery();
            komut.CommandText = "insert anasayfa(tc,bakiye,altin) values('" + txtKimlikno.Text + "',0,'0')";
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        private void txtKimlikno_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Sadece sayı girişi için ayarlıyoruz.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

    }
}
