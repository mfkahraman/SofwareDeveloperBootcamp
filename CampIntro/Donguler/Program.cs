for (int i = 1; i <= 10; i=i+2)
{
    Console.WriteLine(i);
}
//i++ = i'yi bir bir arttır. i=i+1 veya i+=1 olarak da ifade edilebilir
//i=i+2 - i' yi ikişer arttır. i+=2 olarak da yazılabilir
//i <10 olursa 10 hariç demektir. <=10  olursa dahil olur. 

string kurs1 = "Yazılım Geliştirici Yetiştirme Kampı";
string kurs2 = "Programlamaya başlangıç için tenel kurs";
string kurs3 = "Java";

//array = dizi. Yukarıdaki kursları tek tek yazmak yerine dizi olarak yazalım;

string[] kurslar = new string[] {"Yazılım Geliştirici Yetiştirme Kampı", 
    "Programlamaya başlangıç için tenel kurs", "Java", "Python", "C#"};

for (int j = 0; j < kurslar.Length; j++)
{
    Console.WriteLine(kurslar[j]);
}
//kurslar.lenght = kursların eleman sayısı. Böylece diziye ne kadar eleman
//eklenirse eklensin, dinamik bir yapı sağlanmış olur.

Console.WriteLine( "For bitiyor, foreach başlıyor" );

foreach (string kurs in kurslar)
{
    Console.WriteLine(kurs);
}

//foreach dizi temelli yapıları tek tek dönmeye yarıyor.