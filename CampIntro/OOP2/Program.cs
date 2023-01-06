namespace OOP2
{
    class Program
    {
        static void Main(string[] args)
        {
        //classlar 2'ye ayrılır. Prop - Özellik belirten entity-varlık classı ve
        //Metodları içeren operasyon classı.
        //Bu iki classı aynı class içine yazmaya çalışma
        //her zaman ayrı classlar oluştur!
            //Musteri musteri1 = new Musteri();
            //musteri1.Adi = "Engin";
            //musteri1.Soyadi = "Demiroğ";
            //musteri1.Id = 1;
            //musteri1.Soyadi = "2222222222";
            //musteri1.MusteriNo = "12345";
        //önce gercek ve tüzel müşteri ayrımı yapmadan sadece müşteri classı
        //oluşturduk ve yukarıdaki müşteri1'i tanımladık. Ancak tüzel ve gerçek
        //müşterinin karışmaması için örneğin tcnoya sahip bir tüzel müşteri
        //veya şirketno'ya sahip bir gerçek müşteri olmaması için tüzel ve gerçek
        //müşteri classlarını 2 farklı class olarak oluşturduk. Doğru kullanım budur!.
            
            GercekMusteri musteri1 = new GercekMusteri();
            musteri1.Id = 1;
            musteri1.MusteriNo = "12345";
            musteri1.Adi = "Engin";
            musteri1.Soyadi = "Demiroğ";
            musteri1.TcNo = "12345678910";

            TuzelMusteri musteri2 = new TuzelMusteri();
            musteri2.Id = 2;
            musteri2.MusteriNo = "54321";
            musteri2.SirketAdi = "Kodlama.io";
            musteri2.VergiNo = "1234567890";

            Musteri musteri3 = new GercekMusteri();
            Musteri musteri4 = new TuzelMusteri();
            //Soldaki Musteri classtır.
            //Sağdaki GercekMusteri ve TuzelMusteri ise referans numaralarıdır.
            //Musteri classı hem GercekMusteri hem TuzelMusteri referansını tutabiliyor.

            MusteriManager musteriManager = new MusteriManager();
            musteriManager.Ekle(musteri1);
            musteriManager.Ekle(musteri2);

        }
    }
}