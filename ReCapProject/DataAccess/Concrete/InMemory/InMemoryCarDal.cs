using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        List<Brand> _brands;
        List<Color> _colors;

        public InMemoryCarDal()
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

            _brands = new List<Brand>
            {
                new Brand {Id = 1, Name = "Renault" },
                new Brand {Id = 2, Name = "Fiat" },
                new Brand {Id = 3, Name = "Hyundai" },
                new Brand {Id = 4, Name = "BMW" },
                new Brand {Id = 5, Name = "Mercedez" },
            };

            _colors = new List<Color>
            {
                new Color {Id = 1, Name = "Beyaz" },
                new Color {Id = 2, Name = "Siyah" },
                new Color {Id = 3, Name = "Gri" },
                new Color {Id = 4, Name = "Kırmızı" },
                new Color {Id = 5, Name = "Lacivert" },
            };
        }

        public void Add(Car entity)
        {
            _cars.Add(entity);
        }


        public void Delete(Car entity)
        {
            var carToDelete = _cars.SingleOrDefault(p=> p.Id == entity.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            return _cars.FirstOrDefault(filter.Compile());
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(p=> p.Id == id);
        }

        public List<CarDetailDTO> GetCarDetails()
        {
            var result = from c in _cars
                         join cl in _colors
                         on c.ColorId equals cl.Id
                         join b in _brands
                         on c.BrandId equals b.Id
                         select new CarDetailDTO
                         {
                             CarName = c.Description,
                             BrandName = b.Name,
                             ColorName = cl.Name,
                             DailyPrice = c.DailyPrice
                         };
            return result.ToList();
        }

        public void Update(Car entity)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.Id == entity.Id);
            carToUpdate.BrandId = entity.BrandId;
            carToUpdate.ColorId = entity.ColorId;
            carToUpdate.ModelYear = entity.ModelYear;
            carToUpdate.Description = entity.Description;
            carToUpdate.DailyPrice = entity.DailyPrice;
        }
    }
}
