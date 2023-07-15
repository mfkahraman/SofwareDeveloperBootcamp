using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RCPContext>, IRentalDal
    {
        public List<Car> GetAvailableCars()
        {
            using (RCPContext context = new RCPContext())
            {
                var unAvailableCars = context.Rentals.Where(p=> p.ReturnDate == null).Select(p=> p.CarId).ToList();
                var availableCars = context.Cars.Where(p=> !unAvailableCars.Contains(p.Id)).ToList();
                return availableCars;
            }
        }

        public bool IsCarAvailable(int carId)
        {
            using (RCPContext context = new RCPContext()) 
            {
                var isAvailable = !context.Rentals.Any(p => p.CarId == carId && p.ReturnDate == null);
                return isAvailable;
            }
        }

        public string Rent(int carId, int customerId)
        {
            using (RCPContext context = new RCPContext())
            {
                var rental = new Rental
                {
                    CarId = carId,
                    CustomerId = customerId,
                    RentDate = DateTime.Now,
                    ReturnDate = null
                };

                context.Rentals.Add(rental);
                context.SaveChanges();
                var user = context.Users.FirstOrDefault(p=> p.Id == customerId);
                return (user.FirstName + " " + user.LastName);
            }
        }

        public string Return(int rentalId)
        {
            using (RCPContext context = new RCPContext())
            {
                var rental = context.Rentals.FirstOrDefault(p => p.Id == rentalId);

                if(rental != null)
                {
                    rental.ReturnDate= DateTime.Now;
                    context.SaveChanges();
                    return ("The car is successfully returned");
                }
                return ("Something went wrong");
            }
        }
    }
}
