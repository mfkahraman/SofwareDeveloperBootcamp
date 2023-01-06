using Bussiness.Abstract;
using Bussiness.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

class Program
{
    static void Main(string[] args)
    {
        /*
        ICarDal inMemoryDal = new InMemoryProductDal();
        ICarService productService = new CarManager(inMemoryDal);

        Console.WriteLine("productService.GetAll()----------------------");
        var allcars = productService.GetAll();
        foreach (var car in allcars)
        {
            Console.WriteLine(car.Description + "\n");
        }
        Console.WriteLine("---------------------------------------------\n");

        inMemoryDal.Add(new Car { Id = 11, BrandId = 6, ColorId = 6, ModelYear = 2022, DailyPrice = 2022, Description = "Mat Siyah Audi" });

        
        Console.WriteLine("Added Cars----------------------------------");
        var imallcars = inMemoryDal.GetAll();
        foreach (var car in imallcars)
        {
            if (car.Id>10)
            {
                Console.WriteLine(car.Description + "\n");
            }
            
        }
        Console.WriteLine("---------------------------------------------\n");
        */

        ICarService carManager = new CarManager(new EfCarDal());

        Car car1= new Car() {Id = 1, BrandId = 1, ColorId= 1, ModelYear = 2020, DailyPrice = 850, Description = "Siyah Toyota"};
        Car car2= new Car() { Id = 2, BrandId = 2, ColorId = 2, ModelYear = 2022, DailyPrice = 950, Description = "Beyaz Hyundai"};
        Car car3 = new Car() { Id = 3, BrandId = 3, ColorId = 3, ModelYear = 2021, DailyPrice = 900, Description = "Gri Renault" };

        carManager.Add(car1);
        carManager.Add(car2);
        carManager.Add(car3);


        Console.WriteLine("\n---------------carManager.GetAll()------------");
        foreach (var item in carManager.GetAll())
        {
            Console.WriteLine(item.Description);
        }


    }
}