//type safety - tip güvenliği
//alias = değer tututucu - kategoriEtiketi

string kategoriEtiketi = "Kategori";
int ogrenciSayisi = 32000;
double faizOrani = 1.45;
bool sistemeGirisYapmisMi = false;
double dolarDun = 7.35;
double dolarBugun = 7.45;

if (dolarDun>dolarBugun)
{
    Console.WriteLine("Azalış oku");
}
else if (dolarDun<dolarBugun)
{
    Console.WriteLine("Artış oku");
}
else
{
    Console.WriteLine("Değişmedi Butonu");
}

if (sistemeGirisYapmisMi == true) 
{
    Console.WriteLine("Ayarlar butonu");
}
else
{
    Console.WriteLine("Giriş yap butonu");
}
Console.WriteLine(kategoriEtiketi);

