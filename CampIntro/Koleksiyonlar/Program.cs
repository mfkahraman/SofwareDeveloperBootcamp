using System.Collections.Generic;

namespace Koleksiyonlar
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] isimler = new string[] { "Engin", "Murat", "Kerem", "Halil" };
            //Console.WriteLine(isimler[0]);
            //Console.WriteLine(isimler[1]);
            //Console.WriteLine(isimler[2]);
            //Console.WriteLine(isimler[3]);
            ////diziye 5. eleman tanımlamaya çalışalım.
            ////isimler[4] = "İlker";
            ////Console.WriteLine(isimler[4]);
            ////Yukarıdaki şekilde diziye yeni eleman ekleyemedik,
            ////Dizi 4 elemanlı oluşturulduğu için 5. elemanı yazdırmayı kabul etmedi
            //isimler = new string[5];
            //isimler[4] = "İlker";
            //Console.WriteLine(isimler[4]);
            //Console.WriteLine(isimler[0]);
            ////Yukarıdaki şekilde yaptığımızda da yeni dizi tanımlamış olduk ve
            ////eski dizideki 1.eleman olan Engin'i yazdıramadık.
            ////Sonuç olarak biz dizileri genişletemiyoruz, diziler genelde bir
            ////veri kaynağından geliyor, asıl dizi üzerinde oynama yapamıyoruz.
            ////sonradan da eleman eklediğimizde asıl dizideki elemanları kaybediyoruz.
            ////bu nedenle genelde array yerine koleksiyonlar kullanılıyor.

            // ctrl k, ctrl c ile toplu commend alınabilir.
            // ctrl k ctrl u ile geri çevrilebilir

            List<string> isimler2 = new List<string> {"Engin", "Murat", "Kerem", "Halil"};
            Console.WriteLine(isimler2[0]);
            Console.WriteLine(isimler2[1]);
            Console.WriteLine(isimler2[2]);
            Console.WriteLine(isimler2[3]);
            isimler2.Add("İlker");
            Console.WriteLine(isimler2[4]);
            Console.WriteLine(isimler2[0]);
        }
    }
}