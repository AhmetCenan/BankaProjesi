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
    public partial class ParaTransfer : Form
    { 
        //sql bağlantımızı açıyoruz.
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-N8GETE5G;Initial Catalog=BankaProje;Integrated Security=True");

        public ParaTransfer()
        {
            InitializeComponent();
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            //eğer kullanıcı textboxları doldurmazsa hata verdiriyoruz.
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(txtMiktar.Text) || string.IsNullOrEmpty(txtTC.Text))
            {
                MessageBox.Show("Yetersiz Bilgi");
            }
            else
            {
                //sql bağlantısı açık para transferini yapıyoruz.
                int miktar = Convert.ToInt32(txtMiktar.Text);
                baglanti.Open();
                SqlCommand komut = baglanti.CreateCommand();
                komut.CommandText = "update anasayfa set bakiye=bakiye-'" + miktar + "'  where tc='" + textBox1.Text + "' ";
                komut.ExecuteNonQuery();
                komut.CommandText = "update anasayfa set bakiye=bakiye+'" + miktar + "' where tc='" + txtTC.Text + "' ";
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Transfer Gerçekleşti");
            }

        }

        private void ParaTransfer_Load(object sender, EventArgs e)
        {
            //form1den aldığımız kullanıcının tc bilgisini kullanmak üzere textboxa atıyoruz.
            string tckn = Form1.SetValueForText1;
            textBox1.Text = tckn;
        }

        private void txtTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Sadece sayı girişi için.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
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
