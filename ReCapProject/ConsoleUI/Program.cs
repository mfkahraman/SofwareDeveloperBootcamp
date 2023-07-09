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
        EFCarManagerTest();    
    }

    private static void EFCarManagerTest()
    {
        ICarService carManager = new CarManager(new EfCarDal());

        Car car1 = new Car() { Id = 11, BrandId = 1, ColorId = 2, ModelYear = 2020, DailyPrice = 850, Description = "Siyah Mercedez" };
        Car car2 = new Car() { Id = 12, BrandId = 3, ColorId = 1, ModelYear = 2021, DailyPrice = 950, Description = "Beyaz Peugeot" };
        Car car3 = new Car() { Id = 12, BrandId = 4, ColorId = 3, ModelYear = 2020, DailyPrice = 850, Description = "Gri Renault" };

        Console.WriteLine("\n---------------carManager.GetAll() 1------------");
        foreach (var item in carManager.GetAll())
        {
            Console.WriteLine(item.Description);
        }

        Console.WriteLine("\n---------------carManager.Add()------------");
        carManager.Add(car1);
        carManager.Add(car2);


        Console.WriteLine("\n---------------carManager.GetAll() 2------------");
        foreach (var item in carManager.GetAll())
        {
            Console.WriteLine(item.Description);
        }

        Console.WriteLine("\n---------------Update CarID 12------------");
        carManager.Update(car3);

        Console.WriteLine("\n---------------GetById 12------------");
        Console.WriteLine(carManager.GetById(12).Description);


        Console.WriteLine("\n---------------Delete CarId 12------------");
        carManager.Delete(car3);

        Console.WriteLine("\n---------------GetCarDetails------------");
        foreach (var item in carManager.GetCarDetails())
        {
            Console.WriteLine("CarName = {0},BrandName = {1}, ColorName = {2}, DailyPrice = {3}\n"
                , item.CarName, item.BrandName, item.ColorName, item.DailyPrice);
        }
    }

    void InMemoryCarTest()
    {
        ICarDal inMemoryDal = new InMemoryCarDal();
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
            if (car.Id > 10)
            {
                Console.WriteLine(car.Description + "\n");
            }

        }
        Console.WriteLine("---------------------------------------------\n");
    }
}