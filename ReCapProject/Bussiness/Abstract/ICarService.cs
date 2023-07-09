using Core.Utilities.Results;
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
        public IDataResult<List<Car>> GetAll();
        public IDataResult<Car> GetById(int id);
        public IResult Add(Car car);
        public IResult Update(Car car);
        public IResult Delete(Car car);
        public IDataResult<List<CarDetailDTO>> GetCarDetails();

    }
}
