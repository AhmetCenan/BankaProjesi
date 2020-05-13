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
    public partial class Altin : Form
    {
        public Altin()
        {
            InitializeComponent();
        }
        //sql bağlantımızı açıyoruz.
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-N8GETE5G;Initial Catalog=BankaProje;Integrated Security=True");


        private void btnGramal_Click(object sender, EventArgs e)
        {
            //eğer kullanıcı boş değer girerse hata veriyor.
            if (string.IsNullOrEmpty(txtgram.Text))
            {
                MessageBox.Show("Yetersiz Bilgi");
            }
            else
            {
                //altın transferinden sonra hesabdaki güncellemeleri yapıyoruz.
                int bakiye = (Convert.ToInt32(txtgram.Text)) * 382;
                baglanti.Open();
                SqlCommand komut = baglanti.CreateCommand();
                komut.CommandText = "update anasayfa set bakiye=bakiye-'" + bakiye + "'  where tc='" + txtTC.Text + "' ";
                komut.ExecuteNonQuery();
                komut.CommandText = "update anasayfa set altin=altin+'" + Convert.ToInt32(txtgram.Text) + "' where tc='" + txtTC.Text + "' ";
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Transfer Gerçekleşti");
            }
        }

        private void btnÇeyrekal_Click(object sender, EventArgs e)
        {
            //eğer kullanıcı boş değer girerse hata veriyor.
            if (string.IsNullOrEmpty(txtCeyrek.Text) || string.IsNullOrEmpty(txtTC.Text))
            {
                MessageBox.Show("Yetersiz Bilgi");
            }
            else
            {
                //altın transferinden sonra hesabdaki güncellemeleri yapıyoruz.
                int bakiye = (Convert.ToInt32(txtCeyrek.Text)) * 612;
                baglanti.Open();
                SqlCommand komut = baglanti.CreateCommand();
                komut.CommandText = "update anasayfa set bakiye=bakiye-'" + bakiye + "'  where tc='" + txtTC.Text + "' ";
                komut.ExecuteNonQuery();
                komut.CommandText = "update anasayfa set altin=altin+'" + (Convert.ToInt32(txtCeyrek.Text))*2 + "' where tc='" + txtTC.Text + "' ";
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Transfer Gerçekleşti");
            }
        }

        private void Altin_Load(object sender, EventArgs e)
        {
            //form1den tc bilgisini alıyoruz.
            string tckn = Form1.SetValueForText1;
            txtTC.Text = tckn;
        }

        private void txtgram_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Sadece sayı girişi için.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
