using Core.Utilities.Results;
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
        IDataResult<List<Product>> GetAll();
        //Getall List<Product> return ediyordu ancak mesaj da return etmek istiyoruz. IResult return edersek datayı döndüremeyiz.
        //Bu nedenle IDataResult interfacini oluşturduk. Bu sayede hem mesaj hem data döndürüyorz.
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductsDetails();
        IDataResult<Product> GetById(int productId);
        IResult Add (Product product);
        //Add metodunda product vs. bir data döndürmemize gerek yok sadece mesaj döndüreceğimiz için IResult döndürüyoruz.
    }
}
