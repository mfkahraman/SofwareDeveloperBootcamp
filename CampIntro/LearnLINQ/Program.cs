class Program
{
    static void Main(string[] args)
    {
        List<Category> categories = new List<Category>
            {
                new Category{CategoryId = 1, CategoryName = "Bilgisayar" },
                new Category{CategoryId = 2, CategoryName = "Telefon"}
            };

        List<Product> products = new List<Product>
            {
                new Product {ProductId = 1, CategoryId = 1, ProductName = "Acer Laptop", QuantityPerUnit = "32 Gb Ram", UnitPrice = 10000, UnitInStock = 5},
                new Product {ProductId = 2, CategoryId = 1, ProductName = "Asus Laptop", QuantityPerUnit = "16 Gb Ram", UnitPrice = 8000, UnitInStock = 3},
                new Product {ProductId = 3, CategoryId = 1, ProductName = "HP Laptop", QuantityPerUnit = "8 Gb Ram", UnitPrice = 6000, UnitInStock = 2},
                new Product {ProductId = 4, CategoryId = 2, ProductName = "Samsung Telefon", QuantityPerUnit = "4 Gb Ram", UnitPrice = 5000, UnitInStock = 15},
                new Product {ProductId = 5, CategoryId = 2, ProductName = "Apple Telefon", QuantityPerUnit = "4 Gb Ram", UnitPrice = 8000, UnitInStock = 0},
            };
        //Yukarıdaki Ürünler, kategoriler vs normalde veritabanından gelir

        //Algoritmik ve LINQ ile ayrı ayrı filtreleme yaparak LINQ' ın kolaylığını görelim

        Console.WriteLine("Algoritmik----------------------------");
        foreach (var p in products)
        {
            if (p.UnitPrice > 5000 && p.UnitInStock > 3)
            {
                Console.WriteLine(p.ProductName);
            }
        }

        Console.WriteLine("\nLINQ------------------------------------");
        var result = products.Where(p => p.UnitPrice > 5000 && p.UnitInStock > 3);
        foreach (var p in result)
        {
            Console.WriteLine(p.ProductName);
        }

        Console.WriteLine("\n--------------GetProducts-------------");
        var result2 = GetProducts(products);
        foreach (var p in result2)
        {
            Console.WriteLine(p.ProductName);
        }
        Console.WriteLine("\n--------------GetProductsLINQ-------------");
        var result3 = GetProductsLINQ(products);
        foreach (var p in result3)
        {
            Console.WriteLine(p.ProductName);
        }
    }

    //Özellikle metot oluştururken LINQ çok kolaylık sağlıyor, karlışaltıralım;

    static List<Product> GetProducts(List<Product> products)
    {
        List<Product> filteredProducts = new List<Product>();
        foreach (var p in products)
        {
            if (p.UnitPrice > 5000 && p.UnitInStock > 3)
            {
                filteredProducts.Add(p);
            }
        }

        return filteredProducts;

    }

    static List<Product> GetProductsLINQ(List<Product> products)
    {
        return products.Where(p => p.UnitPrice > 5000 && p.UnitInStock > 3).ToList();
    }

}

//Entitilerimizi oluşturalım
class Product
{
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
    public string ProductName { get; set; }
    public string QuantityPerUnit { get; set; }
    public decimal UnitPrice { get; set; }
    public int UnitInStock { get; set; }
}

class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}