using Bussiness.Abstract;
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
        public void Add(Brand brand)
        {
            _branddal.Add(brand);
        }

        public void Delete(Brand brand)
        {
            _branddal.Delete(brand);
        }

        public List<Brand> GetAll()
        {
            return _branddal.GetAll();
        }

        public Brand GetById(int id)
        {
            return _branddal.Get(p => p.Id == id);
        }

        public void Update(Brand brand)
        {
            _branddal.Update(brand);
        }
    }
}
