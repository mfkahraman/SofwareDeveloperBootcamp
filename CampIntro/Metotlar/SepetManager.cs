using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metotlar
{
    internal class SepetManager
    {
        //naming convention - isimlendirme kuralı
        public void Ekle(Urun urun)  //parantez yani () metot demektir. //Urun = class, urun = parametre.
        //Metota parametre ekleyerek Ekle metotunda ne ekleyeceğini belirtmiş olduk.
        {
            Console.WriteLine("Sepete eklendi :" + urun.Adi);
        }

        //Ekle2 yanlış bir metot örneği olarak veriliyor.
        public void Ekle2(string urunAdi, string aciklama, double fiyat, int stokAdedi)
        {
            Console.WriteLine("Sepete eklendi :" + urunAdi);
        }
    }
}
