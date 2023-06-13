using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

class Program
{
    //ConsoleUI katmanı yani arayüz bütün katmanları kullanır, bütün proje referanslarını ekledik
    static void Main(string[] args)
    {
        //InMemoryProductManagerTest();

        //EntityFrameworkProductManagerTest();

        //CategoryManagerTest();

        ProductTest();

    }

    private static void CategoryManagerTest()
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        foreach (var item in categoryManager.GetAll())
        {
            Console.WriteLine(item.CategoryName);
        }

        Console.WriteLine("\ncategoryManager.GetById(5).CategoryName: {0}", categoryManager.GetById(5).CategoryName);
    }

    private static void InMemoryProductManagerTest()
    {
        ProductManager inMemoryPM = new ProductManager(new InMemoryProductDal());

        var result = inMemoryPM.GetAll();

        foreach (var product in result.Data)
        {
            Console.WriteLine(product.ProductName);
        }
    }

    private static void EntityFrameworkProductManagerTest()
    {
        ProductManager efPM = new ProductManager(new EfProductDal());


        Console.WriteLine("--------------efPM.GetAll()-----------------------");
        foreach (var item in efPM.GetAll().Data)
        {
            Console.WriteLine(item.ProductName);
        }
        Console.WriteLine("\n--------------------efPM.GetAllByCategoryId(2)---------------------");
        foreach (var item in efPM.GetAllByCategoryId(2).Data)
        {
            Console.WriteLine(item.ProductName);
        }
        Console.WriteLine("\n------------------efPM.GetByUnitPrice(40,1000)--------------------");
        foreach (var item in efPM.GetByUnitPrice(40, 1000).Data)
        {
            Console.WriteLine(item.ProductName);
        }
        Console.WriteLine("------------------------efPM.GetProductsDetails()-----------------------");
        foreach (var item in efPM.GetProductsDetails().Data)
        {
            Console.WriteLine("\nProductName: {0} / CategoryName: {1}", item.ProductName, item.CategoryName);
        }
    }

    private static void ProductTest()
    {
        ProductManager productManager = new ProductManager(new EfProductDal());

        var result = productManager.GetProductsDetails();

        if (result.Success) // if (result.Success) == true demek, daha kısa yazılışı.
        {
            foreach (var product in result.Data)
            {
                Console.WriteLine(product.ProductName + "/" + product.CategoryName);
            }
        }
        else
            Console.WriteLine(result.Message);
    }
}