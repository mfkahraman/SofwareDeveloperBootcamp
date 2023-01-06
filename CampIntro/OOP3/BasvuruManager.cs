using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP3
{
    internal class BasvuruManager
    {
        public void BasvuruYap(IKrediManager krediManager, 
            List<ILoggerService> loggerServices) //Aynı anda birden fazla log
            //yollayabilmek için List olarak yazdık.
        { 
 //BasvuruYap metodu çalışacağında bu başvuruyu hangi krediye göre yapmamsı
 //gerektiğini söylemek için base interface'i giriyoruz çünkü base interface
 //bütün kredimanagerlerin referans numarasını tutuyor.
 //Artık BasvuruYap metoduna parametre olarak hangi kredi türünü girersek
 //ona göre işlem yapacaktır.

 //Method injection - Kullanıcı kredi türünü ve loglayıcıyı enjekte ediyoruz.
            krediManager.Hesapla();
            foreach (var loggerService in loggerServices)
            {
                loggerService.Log();
            }

        }

        public void KrediOnBilgilendirmesiYap(List<IKrediManager> krediler)
        {
            foreach (var kredi in krediler)
            {
                kredi.Hesapla();
            }
        }
    }
}
