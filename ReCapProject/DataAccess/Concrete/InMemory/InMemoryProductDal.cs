using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryProductDal()
        {
            _cars = new List<Car> {
            new Car {Id = 1, BrandId = 3, ColorId = 4, DailyPrice = 500, ModelYear = 2018, Description = "Kırmızı renk, Hyundai"},
            new Car {Id = 2, BrandId = 1, ColorId = 2, DailyPrice = 700, ModelYear = 2019, Description = "Siyah renk Renault"},
            new Car {Id = 3, BrandId = 4, ColorId = 3, DailyPrice = 900, ModelYear = 2020, Description = "Gri renk BMW"},
            new Car {Id = 4, BrandId = 5, ColorId = 1, DailyPrice = 1000, ModelYear = 2021, Description = "Beyaz renk Mercedez"},
            new Car {Id = 5, BrandId = 2, ColorId = 5, DailyPrice = 800, ModelYear = 2022, Description = "Lacivert renk Fiat"},
            new Car {Id = 6, BrandId = 3, ColorId = 4, DailyPrice = 800, ModelYear = 2022, Description = "Kırmızı renk Hyundai"},
            new Car {Id = 7, BrandId = 5, ColorId = 5, DailyPrice = 800, ModelYear = 2019, Description = "Lacivert renk Mercedez"},
            new Car {Id = 8, BrandId = 2, ColorId = 1, DailyPrice = 700, ModelYear = 2021, Description = "Beyaz renk Fiat"},
            new Car {Id = 9, BrandId = 1, ColorId = 3, DailyPrice = 800, ModelYear = 2020, Description = "Gri renk Renault"},
            new Car {Id = 10, BrandId = 4, ColorId = 2, DailyPrice = 700, ModelYear = 2018, Description = "Siyah renk BMW"}
            };
            
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(p=> p.Id == carId).ToList();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetCarsByColorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p=> p.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
            carToUpdate.DailyPrice = car.DailyPrice;
        }
    }
}
