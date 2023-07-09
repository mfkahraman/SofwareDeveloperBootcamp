using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstract
{
    public interface IBrandService
    {
        public List<Brand> GetAll();
        public Brand GetById(int id);
        public void Add(Brand brand);
        public void Update(Brand brand);
        public void Delete(Brand brand);
    }
}
