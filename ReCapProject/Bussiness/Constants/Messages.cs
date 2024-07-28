using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Constants
{
    public class Messages
    {
        public static string CarAdded = "The car is succesfully added";
        public static string CarUpdated = "The car is succesfully updated";
        public static string CarDeleted = "The car is succesfully deleted";
        public static string CarsListed = "Cars are listed";
        public static string InvalidCarDesc = "Lenght of a car description must be at least 2 and dailprice must be greater than 0";
        public static string BrandAdded = "The brand is succesfully added";
        public static string BrandUpdated = "The brand is succesfully updated";
        public static string BrandDeleted = "The brand is succesfully deleted";
        public static string BrandsListed = "Brands are listed";
        public static string ColorAdded = "The color is succesfully added";
        public static string ColorUpdated = "The color is succesfully updated";
        public static string ColorDeleted = "The color is succesfully deleted";
        public static string ColorsListed = "Colors are listed";
        public static string UserAdded = "The user is succesfully added";
        public static string UserUpdated = "The user is succesfully updated";
        public static string UserDeleted = "The user is succesfully deleted";
        public static string UsersListed = "Users are listed";
        public static string CustomerAdded = "The customer is succesfully added";
        public static string CustomerUpdated = "The customer is succesfully updated";
        public static string CustomerDeleted = "The customer is succesfully deleted";
        public static string CustomersListed = "Customers are listed";
        public static string RentalAdded = "The car is succesfully rented";
        public static string RentalUpdated = "The rental is succesfully updated";
        public static string RentalDeleted = "The rental is succesfully deleted";
        public static string RentalsListed = "Rentals are listed";
        public static string AvailableCarsListed = "Available cars are listed";
        public static string CarReturned = "The car is succesfully returned";
        public static string MaintenanceTime = "System is under maintenance";
        public static string CarImageAdded = "The car image is succesfully added.";
        public static string CarIdNotExist = "This car ID is not exists in database.";
        public static string CarIdExist = "This car ID exists in the database.";
        internal static string CarImageDeleted = "The car image is successfully deleted.";
        internal static string ImagesListedById = "Images are listed by ID.";
        internal static string CarImageUpdated = "The car image is successfully updated.";
        internal static string CarImagesListed = "Car images are successfully listed.";
        internal static string ImagesListedByCarId = "Car images are successfully listed by car ID.";
        internal static string CarImagesExistByCarId = "Car images exist in the database with this car ID.";
        internal static string CarImageLimitForCarIdReached = "The maximum number of images for this car ID has been reached. No more images can be added.";
        internal static string DefaultCarImageDisplayed = "Default car image is displayed.";
    }
}
