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
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ndp_Proje
{
    public partial class Bagis : Form
    {
        public Bagis()
        {
            InitializeComponent();
        }
        //sql bağlantısını açıyoruz.
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-N8GETE5G;Initial Catalog=BankaProje;Integrated Security=True");


        private void btnGonder_Click(object sender, EventArgs e)
        {
            //eğer kullanıcı boş değer girerse hata veriyor.
            if (string.IsNullOrEmpty(txtTc.Text) || string.IsNullOrEmpty(txtMiktar.Text))
            {
                MessageBox.Show("Yetersiz Bilgi");
            }
            else
            {
                //kullanıcının bağış miktarını hesabından çıkartıyoruz.
                int miktar = Convert.ToInt32(txtMiktar.Text);
                baglanti.Open();
                SqlCommand komut = baglanti.CreateCommand();
                komut.CommandText = "update anasayfa set bakiye=bakiye-'" + miktar + "'  where tc='" + txtTc.Text + "' ";
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Bagiş Yapıldı,Teşekkür Ederiz.");
            }
        }

        private void Bagis_Load(object sender, EventArgs e)
        {
            //form1den tc bilgsini alıyoruz.
            string tckn = Form1.SetValueForText1;
            txtTc.Text = tckn;
        }

        private void txtMiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Sadece sayı girişi için.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
