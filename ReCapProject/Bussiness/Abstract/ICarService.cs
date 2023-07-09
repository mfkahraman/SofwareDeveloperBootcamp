using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstract
{
    public interface ICarService
    {
        public List<Car> GetAll();
        public Car GetById(int id);
        public void Add(Car car);
        public void Update(Car car);
        public void Delete(Car car);
        public List<CarDetailDTO> GetCarDetails();

    }
}
