using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    //Business katmanı DataAccess ve Entities katmanlarını kullanır o nedenle proje referanslarına ekledik
    //Arayüzden (ConsoleUI olarak simule ettik) kullanıcı bir işlem yapmak istediğinde
    //Business katmanı bu işlemlerin iş kurallarına uygun olup olmadığına bakar
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetAllByCategoryId(int id);
        List<Product> GetByUnitPrice(decimal min, decimal max);
        public List<ProductDetailDto> GetProductsDetails();
    }
}
