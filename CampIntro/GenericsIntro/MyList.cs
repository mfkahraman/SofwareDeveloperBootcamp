using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsIntro
{
    class MyList<T> //T = type = tip anlamında kullandık. Herhangi birsey kullanabiliriz.
    {
        T[] items; //constructor. ctor yazıp 2xtab ile alttaki blok açılır.
        //Bir class newlendiğinde çalışan metoda constructor deniyor.
        //Mylist türünde bir liste newlendiğinde aşağıdaki MyList metodu otomatik çalışacak ve
        //T türünde 0 elemanlı bir array oluşturacak.
        public MyList()
        {
            items = new T[0]; // 0 elemanlı bir items dizisi oluşturduk.
        }

        public void Add(T item) // buraya ne tip girersek girelim kabul etmesi
         // için T item dedik. Artık MyList clasında liste oluştururken istediğimiz
         // veri tipini kendimiz belirleyebiliriz.
        {
            T[] tempArray = items; //itemsi newleyip eleman sayısını bir arttırmadan
            //önce mevcut referans numarasını geçici bir diziye bağlıyoruz. alttaki
            //kod ile itemsı newlediğimizde yeni bir referans numarası alacak.
            //eski referans numarası bu geçici dizide kalacak.
            items = new T[items.Length+1]; // dizinin eleman sayısını 1 arttırdık.
            for (int i = 0; i < tempArray.Length; i++)
            {
                items[i] = tempArray[i];
                //Bu döngü ile tempArray dizisinde geçici tuttuğumuz elemanları
                //items dizisine geri almış olduk.

                items[items.Length - 1] = item;
                //items dizisinin son elemanını yani oluşturduğumuz boşluğu
                //seçtik ve bir item atadık
            }
        }
    }
}
