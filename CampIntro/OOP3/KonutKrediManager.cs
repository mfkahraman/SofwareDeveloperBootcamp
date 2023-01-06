using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP3
{
//Base class olarak IKrediManager interface'ini girdiğimizde hata verir
//çünkü interface'deki bütün metotları içermek zorundadır.
//Ampüle basıp impelement interface yaparız.
    internal class KonutKrediManager : IKrediManager
    {
        public void BiseyYap()
        {
            throw new NotImplementedException();
        }

        public void Hesapla()
        {
            Console.WriteLine("Konut kredisi ödeme planı hesaplandı");
        }
    }
}
