using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP3
{
//Metotoların void Hesapla(), void BiseyYap() kısımlarına imza diyoruz.
//İmzanın aynı olduğu ancak içeriğinin farklı olduğu classlarda kullanmak için
//base classı interface olarak kullanıyoruz. Metodları aşağıdaki gibi yazıyoruz.
//Her kredi interfacedeki metotları içermek zorundadır.
//Okunurluğu arttırmak için interfaceleri I harfi ile başlatıyoruz.
    interface IKrediManager
    {
        void Hesapla();
        void BiseyYap();
    }
}
