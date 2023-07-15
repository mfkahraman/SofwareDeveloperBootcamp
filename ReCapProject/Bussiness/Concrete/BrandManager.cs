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
    public class BrandManager : IBrandService
    {
        IBrandDal _branddal;
        public BrandManager(IBrandDal branddal)
        {
            _branddal= branddal;
        }
        public IResult Add(Brand brand)
        {
            _branddal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            _branddal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_branddal.GetAll(),Messages.BrandsListed);
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_branddal.Get(p => p.Id == id), Messages.BrandsListed);
        }

        public IResult Update(Brand brand)
        {
            _branddal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}
