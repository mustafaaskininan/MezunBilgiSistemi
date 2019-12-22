using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MezunBilgiSistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Tree agac = new Tree();
        Kisi k = new Kisi();
        string isim;
        private void Form1_Load_1(object sender, EventArgs e)
        {
           /* k = (Kisi)agac.Ara("hede");
            MessageBox.Show(k.DYeri);*/
        }
        
        private void btnKaydetEleman_Click(object sender, EventArgs e)
        {
            if (txtOncekiIsyeriAdi.Text != "" && txtCalisanOncekiIsAdresi.Text != "" && txtGorevi.Text != "" && txtOkulAdi.Text != "" && txtBolumu.Text != "" && txtOrtalama.Text != "" && (rdioEvli.Checked == false || rdioBekar.Checked == false))//diğer inputların dolu olup olmama durumu kontrolu
            {
                Kisi ki = new Kisi();
                isim = txtAd.Text;
                string mdurum = "";
                if (rdioEvli.Checked == true)
                    mdurum = "Evli";
                else if (rdioBekar.Checked == true)
                    mdurum = "Bekar";
                ki.KisiEkle(txtAd.Text, txtCalisanAdres.Text, txtCalisanTelefon.Text, txtUyruk.Text, txtDogumYeri.Text, dateTimeDogum.Value, mdurum, txtYabancidil.Text, txtIlgiAlanlari.Text, txtReferansOlanlar.Text, txtOncekiIsyeriAdi.Text, txtCalisanOncekiIsAdresi.Text, txtGorevi.Text, txtOkulAdi.Text, txtBolumu.Text, dateTimeOkulBaslangic.Value, dateTimeOkulBitis.Value, Convert.ToDecimal(txtOrtalama.Text));
                agac.Ekle(ki);
                MessageBox.Show("Kayıt Tamamlandı");
                btnExit.Enabled = true;
            }
            else
                MessageBox.Show("Eksik alan");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (agac.delete(k))
                MessageBox.Show("Kişi kaydı silindi.");
            else
                MessageBox.Show("Çıkış Yapılamadı!");
        }

        private void btnAdaGorAra_Click_1(object sender, EventArgs e)
        {
         
            k = (Kisi)agac.Ara(txtAdaGorAra.Text);
            if (k == null)
                MessageBox.Show("bulunamadı");
            else
            {
                txtAd.Text = k.Ad;
                txtCalisanAdres.Text = k.Adres;
                txtCalisanTelefon.Text = k.Tel;
                txtUyruk.Text = k.Uyruk;
                txtDogumYeri.Text = k.DYeri;
                dateTimeDogum.Value = k.DTarihi;
                if (k.MDurum == "Bekar")
                    rdioBekar.Checked = true;
                else
                    rdioEvli.Checked = true;
                txtYabancidil.Text = k.YabanciDil;
                txtIlgiAlanlari.Text = k.IlgiAlanlari;
                txtReferansOlanlar.Text = k.Referans;
                txtOncekiIsyeriAdi.Text = k.isdeneyim.Ad;
                txtCalisanOncekiIsAdresi.Text = k.isdeneyim.Adres;
                txtGorevi.Text = k.isdeneyim.Pozisyon;
                txtOkulAdi.Text = k.egitim.OkulAd;
                txtBolumu.Text = k.egitim.Bolum;
                txtOrtalama.Text = k.egitim.NotOrt.ToString();
                dateTimeOkulBaslangic.Value = k.egitim.Baslangic;
                dateTimeOkulBitis.Value = k.egitim.Bitis;
                tabControl1.TabPages[0].Show();
                btnGuncelle.Enabled = true;
                btnKaydetEleman.Enabled = false;
            }
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtOncekiIsyeriAdi.Text != "" && txtCalisanOncekiIsAdresi.Text != "" && txtGorevi.Text != "" && txtOkulAdi.Text != "" && txtBolumu.Text != "" && txtOrtalama.Text != "" && (rdioEvli.Checked == false || rdioBekar.Checked == false))
            {
                string mdurum = "";
                if (rdioEvli.Checked == true)
                    mdurum = "Evli";
                else if (rdioBekar.Checked == true)
                    mdurum = "Bekar";
                k.KisiEkle(txtAd.Text, txtCalisanAdres.Text, txtCalisanTelefon.Text, txtUyruk.Text, txtDogumYeri.Text, dateTimeDogum.Value, mdurum, txtYabancidil.Text, txtIlgiAlanlari.Text, txtReferansOlanlar.Text, txtOncekiIsyeriAdi.Text, txtCalisanOncekiIsAdresi.Text, txtGorevi.Text, txtOkulAdi.Text, txtBolumu.Text, dateTimeOkulBaslangic.Value, dateTimeOkulBitis.Value, Convert.ToDecimal(txtOrtalama.Text));

            }
            else
                MessageBox.Show("Eksik alan");
        }

        private void btnOrtGoreAra_Click(object sender, EventArgs e)
        {
            agac.ortisim();
            if (agac.isimler == "")
                MessageBox.Show("Bulunamadı!");
            else
                MessageBox.Show(agac.isimler);
        }

        private void btningAra_Click(object sender, EventArgs e)
        {
            agac.ingisim();
            if (agac.isimler == "")
                MessageBox.Show("Bulunamadı!");
            else
                MessageBox.Show(agac.isimler);
        }

        private void btnAllList_Click(object sender, EventArgs e)
        {
            agac.allisim();
            if(agac.isimler == "")
                MessageBox.Show("Bulunamadı!");
            else
                MessageBox.Show(agac.isimler);
        }

        private void btneSay_Click(object sender, EventArgs e)
        {
            if (agac.eSay() == 0)
                MessageBox.Show("Ağaç Boş");
            else
                MessageBox.Show("Ağaç " + agac.eSay().ToString() + " Elemanlı");
        }

                


    }
}
