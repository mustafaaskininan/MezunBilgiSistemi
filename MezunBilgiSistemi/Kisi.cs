using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemi
{
    public class Kisi
    {
        public string Ad { get; set; }
        public string Adres { get; set; }
        public string Tel { get; set; }
        public string Uyruk { get; set; }
        public string DYeri { get; set; }
        public DateTime DTarihi { get; set; }
        public string MDurum { get; set; }
        public string YabanciDil { get; set; }
        public string IlgiAlanlari { get; set; }
        public string Referans { get; set; }

        public IsDeneyimleri isdeneyim = new IsDeneyimleri();
        public EgitimDurumu egitim = new EgitimDurumu();
        LinkedList blist = new LinkedList();
        
        public void KisiEkle(string ad,string adres,string tel,string uyruk,string dyeri,DateTime dtarihi,string mdurum,string ydil,string ialanlari,string referans,string isdad,string isdadres,string isdpoz,string eokulad,string ebolum,DateTime ebas,DateTime ebit,decimal eort)
        {
            this.Ad = ad;
            this.Adres = adres;
            this.Tel = tel;
            this.Uyruk = uyruk;
            this.DYeri = dyeri;
            this.DTarihi = dtarihi;
            this.MDurum = mdurum;
            this.YabanciDil = ydil;
            this.IlgiAlanlari = ialanlari;
            this.Referans = referans;
            isdeneyim.Ad = isdad;
            isdeneyim.Adres = isdadres;
            isdeneyim.Pozisyon = isdpoz;
            egitim.OkulAd = eokulad;
            egitim.Bolum = ebolum;
            egitim.Baslangic = ebas;
            egitim.Bitis = ebit;
            egitim.NotOrt = eort;
            blist.Insert(this.egitim, this.isdeneyim);
        }
        EgitimDurumu e = new EgitimDurumu();
        public string not()
        {
            object[] tveri = new object[2];
            tveri = blist.Veri();
            e = (EgitimDurumu)tveri[0];
            return e.NotOrt.ToString();
        }
    }
}
