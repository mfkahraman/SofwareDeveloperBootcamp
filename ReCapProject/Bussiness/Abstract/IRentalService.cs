using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstract
{
    public interface IRentalService
    {
        public IDataResult<List<Rental>> GetAll();
        public IDataResult<Rental> GetById(int id);
        public IResult Update(Rental rental);
        public IResult Delete(Rental rental);
        public IResult Rent(int carId, int customerId);
        public IResult Return(int rentalId);
        public IDataResult<List<Car>> GetAvailableCars();
        public IResult IsCarAvailable(int carId);




    }
}
