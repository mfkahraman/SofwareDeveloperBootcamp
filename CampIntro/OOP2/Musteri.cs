using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    internal class Musteri
    {
    //Id ve Musteri no GercekMusteri ve TuzelMusteri classlarında ortak olduğu
    //için bu özellikleri ikisini de kapsayan Musteri classına yazdık.
    //Musteri classına base class - temel sınıf diyoruz.
        public int Id { get; set; }
        public string MusteriNo { get; set; }

    }
}
