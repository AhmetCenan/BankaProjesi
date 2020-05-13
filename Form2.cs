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
    public partial class Form2 : Form
    {
        public string tck; 

        public Form2()
        {
            InitializeComponent();            
        }
        //sql bağlatımızı açıyoruz.
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-N8GETE5G;Initial Catalog=BankaProje;Integrated Security=True");
        private void Form2_Load(object sender, EventArgs e)
        {
            //forum yüklendiği anda form1 den tc bilgimizi alıyoruz ve bu formdan kullanılmak üzere txtTC.Text e atıyoruz.
            string tckn =  Form1.SetValueForText1;
            txtTC.Text = tckn;
            BilgileriYaz();
            timer1.Enabled = true;//tarihi göstermek için timer ekliyoruz.
        }
        
        private void BilgileriYaz()
        {
            //form1 den aldığımız tc verisi ile sqle bağlanıyoruz ve kullanıcının bakiyesini cüzdana yazdırıyoruz.
            baglanti.Open();
            SqlCommand komut = baglanti.CreateCommand();
            SqlDataReader dtr;
            komut.CommandText = "select *from kayit where tckimlik='"+txtTC.Text+"'";
            dtr = komut.ExecuteReader();
            while (dtr.Read())
            {
                txtTC.Text = dtr["tckimlik"].ToString();
                txtSeri.Text = dtr["serino"].ToString();
            }
            baglanti.Close();
            baglanti.Open();
            komut.CommandText = "select *from anasayfa where tc='" + txtTC.Text + "' ";
            dtr = komut.ExecuteReader();
            while (dtr.Read())
            {
                txtTl.Text = dtr["bakiye"].ToString();
                txtAltin.Text = dtr["altin"].ToString();
            }
            baglanti.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = DateTime.Now.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //form değiştirme metodu
            ParaTransfer transfer = new ParaTransfer();
            transfer.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //form değiştirme metodu
            Altin altn = new Altin();
            altn.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //form değiştirme metodu
            Fatura ftr = new Fatura();
            ftr.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //form değiştirme metodu
            Bagis bgs = new Bagis();
            bgs.ShowDialog();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            //herhangi bir işlem yaptıktan sonra cüzdandaki bilgileri güncellemek için metod oluşturuyoruz.
            BilgileriYaz();
        }
    }
}
