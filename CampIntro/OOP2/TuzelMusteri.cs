using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    //Coorporate = Tüzel
    internal class TuzelMusteri:Musteri
    //MusteriManager'e oluşturacağımız metotlara class olarak Musteri demek ama
    //Dilediğimizde TuzelMusteri dilediğimizde GercekMusteri girebilmek için
    //bu şekilde :Musteri yaptık. TuzelMusteri bir Musteri'dir anlamına geliyor.
    //Buna miras - inheritance deniyor.
    //Ortak prop'ları Musteri classına yazdık. Gercek ve Tuzel classlarına
    //sadece o class'a ait özellikleri yazdık.
    {
        public string SirketAdi { get; set; }
        public string VergiNo { get; set; }
    }
}
