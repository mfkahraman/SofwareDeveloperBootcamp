using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        public List<Car> GetCarsByBrandId(int id); 
        public List<Car> GetCarsByColorId(int id);
    }
}
