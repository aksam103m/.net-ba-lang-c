//using KuzeyYeli.ORM.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuzeyYeli.ORM.Entity
{
    public class Urun
    {
        //sadece property tanımlamada kullandık
        public int UrunId { get; set; }

        public string UrunAdi { get; set; }
        
        public decimal Fiyat { get; set;}//db money

        public short Stok { get; set; }//db smallint

        public int KategoriID { get; set; }

        public int TedarikciID { get; set; }

        public string BirimdekiMiktar { get; set; }

        public short YeniSatis { get; set; }
        
        public short EnAzYenidenStisMiktari { get; set; }

        public bool Sonlandi { get; set; }
    }
}
