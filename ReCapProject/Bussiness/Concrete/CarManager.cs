using Bussiness.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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
                _carDal.Add(car);
            else
                Console.WriteLine("Lenght of Car description must be at least 2 and dailprice must be greater than 0");
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }
    }
}
