namespace Metotlar
{
    class Program
    {
        static void Main(string[] args)
        {
            Urun urun1 = new Urun();
            urun1.Adi = "Elma";
            urun1.Fiyati = 15;
            urun1.Aciklama = "Amasya Elması";

            Urun urun2 = new Urun();
            urun2.Adi = "Karpuz";
            urun2.Fiyati = 80;
            urun2.Aciklama = "Diyarbakır karpuzu";

            Urun[] urunler = new Urun[] {urun1, urun2 };

            foreach (Urun urun in urunler)
            {
                Console.WriteLine(urun.Adi);
                Console.WriteLine(urun.Fiyati);
                Console.WriteLine(urun.Aciklama);
                Console.WriteLine("----------------");
            }

            Console.WriteLine("----------Metotlar----------");

            SepetManager sepetManager = new SepetManager();
            sepetManager.Ekle(urun1);
            sepetManager.Ekle(urun2);

            // Ekle2 metotu yanlış bir kullanımdır. Metotta değişiklik yapıldığında
            // Örneğin bundan sonra stok adedi de girilsin denirse, tüm sayfalar patlar
            // Ama ekle1 gibi class olarak oluşturduğumuzda
            // Stok adedi diye yeni bir prop oluşturmamız yeterli olacaktır.
            sepetManager.Ekle2("Armut", "Yeşil armut", 12, 10);
            sepetManager.Ekle2("Elma", "Yeşil elma", 12, 9);
            sepetManager.Ekle2("Karpuz", "Diyarbakır karpuzu", 12, 8);

            //bu işlemden sonra sepetManager.Ekle(urunadi); kodu ile bu metodu
            //istediğimiz her sayfaya ekleyebiliriz.
            //encapsulation = Urun classına StokAdedi yeni prop olarak eklediğimizde
            //Ekle1 metotu patlamadı.
        }
    }
}