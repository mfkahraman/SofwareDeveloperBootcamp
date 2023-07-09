using Bussiness.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.Description.Length > 1 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine("Car added -> {0}", car.Description);
            }
            else
                Console.WriteLine("Lenght of Car description must be at least 2 and dailprice must be greater than 0");
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("Car deleted -> {0}", car.Description);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }


        public List<CarDetailDTO> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine("Car updated -> {0}", car.Description);
        }

        Car ICarService.GetById(int id)
        {
            return _carDal.Get(p => p.Id == id);
        }
    }
}
