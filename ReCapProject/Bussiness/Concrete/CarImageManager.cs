using Bussiness.Abstract;
using Bussiness.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelperService _fileHelperService;


        public CarImageManager(ICarImageDal carImageDal, IFileHelperService fileHelperService)
        {
            _carImageDal = carImageDal;
            _fileHelperService = fileHelperService;

        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckForCarImageLimit(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = _fileHelperService.Upload(file, PathConstants.CarImagesPath);
            carImage.Date = DateTime.Now;

            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            _fileHelperService.Delete(PathConstants.CarImagesPath + carImage.ImagePath);
            _carImageDal.Delete(carImage);

            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<CarImage> GetById(int id)
        {
            var data = _carImageDal.Get(i => i.Id == id);
            return new SuccessDataResult<CarImage>(data, Messages.ImagesListedById);
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = _fileHelperService.Update(file, PathConstants.CarImagesPath + carImage.ImagePath,
                PathConstants.CarImagesPath);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);

            return new SuccessResult(Messages.CarImageUpdated);
        }
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImagesListed);
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            IResult result = BusinessRules.Run(CheckIfImageExists(id));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(id).Data, Messages.DefaultCarImageDisplayed);
            }
            else
                return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == id), Messages.ImagesListedByCarId);
        }

        //A car can have at most 5 images.
        private IResult CheckForCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.CarImageLimitForCarIdReached);
            }
            return new SuccessResult();

        }

        private IResult CheckIfImageExists(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId).Count;

            if (result > 0)
            {
                return new ErrorResult(Messages.CarImagesExistByCarId);
            }
            return new SuccessResult();

        }
        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {

            List<CarImage> carImages = new List<CarImage>();

            carImages.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "DefaultImage.jpg" });

            return new SuccessDataResult<List<CarImage>>(carImages);
        }

    }
}
