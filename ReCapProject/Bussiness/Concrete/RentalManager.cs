using Bussiness.Abstract;
using Bussiness.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Delete(Rental rental)
        {
           _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        public IDataResult<List<Car>> GetAvailableCars()
        {
            return new SuccessDataResult<List<Car>>(_rentalDal.GetAvailableCars(), Messages.AvailableCarsListed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p=> p.Id == id), Messages.RentalsListed);
        }

        public IResult IsCarAvailable(int carId)
        {
            if (_rentalDal.IsCarAvailable(carId))
                return new SuccessResult("The car is available");
            else return new ErrorResult("The car is not available");
        }

        public IResult Rent(int carId, int customerId)
        {
            if (_rentalDal.IsCarAvailable(carId))
            {
                var result = _rentalDal.Rent(carId, customerId);
                return new SuccessResult(("The car successfully rented by " + result));
            }
            else return new ErrorResult("This car is not available");
        }

        public IResult Return(int rentalId)
        {
            var result = _rentalDal.Return(rentalId);
            return new SuccessResult(result);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
