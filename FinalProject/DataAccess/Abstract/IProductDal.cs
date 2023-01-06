using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //DataAccess katmanı Entities katmanını kullanır o nedenle proje referanslarına ekledik
    public interface IProductDal:IEntityRepository<Product>
    {
        List<ProductDetailDto> GetProductsDetails();
    }
}
