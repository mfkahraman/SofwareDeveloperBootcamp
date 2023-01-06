using System.Collections.Generic;

namespace OOP3
{
    class Program
    {
        static void Main(string[] args)
        {
            IKrediManager ihtiyacKrediManager = new IhtiyacKrediManager();
            ihtiyacKrediManager.Hesapla();

            IKrediManager tasitKrediManager =new TasitKrediManager();
            tasitKrediManager.Hesapla();

            IKrediManager konutKrediManager = new KonutKrediManager();
            konutKrediManager.Hesapla();
            //Base class gibi base interface de o interface'i implemente eden
            //classın referans numarasını tutabiliyor.

            Console.WriteLine("----------------------------------");

            BasvuruManager basvuruManager = new BasvuruManager();

            ILoggerService databaseLoggerService = new DatabaseLoggerService();
            ILoggerService fileLoggerService = new FileLoggerService();
            ILoggerService smsLoggerService = new SmsLoggerService();
            
            
            basvuruManager.BasvuruYap(ihtiyacKrediManager, new List<ILoggerService>
            {databaseLoggerService, fileLoggerService, smsLoggerService});
            
            basvuruManager.BasvuruYap(konutKrediManager, new List<ILoggerService>
            {smsLoggerService,databaseLoggerService});

            Console.WriteLine("------------------------------------");

            List<IKrediManager> krediler = new List<IKrediManager>() 
            {ihtiyacKrediManager, tasitKrediManager };

            basvuruManager.KrediOnBilgilendirmesiYap(krediler);

            Console.WriteLine("------------------------------------");

            basvuruManager.BasvuruYap(new EsnafKredisiManager(),
                new List<ILoggerService>
                {smsLoggerService, fileLoggerService});
            //Bu şekilde de newleyebiliriz yani instance oluşturabiliriz.
        }
    }
} 