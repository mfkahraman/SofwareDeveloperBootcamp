namespace OOP1
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product();
            product1.Id = 1;
            product1.CategoryId = 2;
            product1.ProductName = "Masa";
            product1.UnitPrice = 500;
            product1.UnitInStock = 3;

            //Yukarıdakinden farklı olarak bir ürünü şu şekilde de oluşturabiliriz;
            Product product2 = new Product
            {
                Id = 2,
                CategoryId = 5,
                UnitInStock = 5,
                ProductName = "Kalem",
                UnitPrice = 35
            };

            //PascalCase - Kelimenin ilk harfi büyük
            //camelCase - ilk harf küçük sonraki kelimelerin ilk harfi büyük
            //case sensitive - C# küçük ve büyük harf duyarlıdır.
            //Class oluştururken aşağı örnekteki gibi
            //sol taraftaki ProductManager stack'de oluştururken
            //sağdaki ProductManager heap'de oluşturma işlevi görür.
            //ProductManager türündeki productManager değişkeni, yeni bir
            //referans numarası almış ProductManager'dır anlamına geliyor.

            ProductManager productManager = new ProductManager();
            productManager.Add(product1);
            Console.WriteLine(product1.ProductName);

            


        }
    }
}