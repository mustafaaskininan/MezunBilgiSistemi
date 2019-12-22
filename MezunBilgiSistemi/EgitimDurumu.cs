using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemi
{
    public class EgitimDurumu
    {
        public string OkulAd { get; set; }
        public string Bolum { get; set; }
        public DateTime Baslangic { get; set; }
        public DateTime Bitis { get; set; }
        public decimal NotOrt { get; set; }
    }
}
