using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        public bool IsCarAvailable(int carId);
        public List<Car> GetAvailableCars();
        public string Rent(int carId, int customerId);
        public string Return(int rentalId);
    }
}
