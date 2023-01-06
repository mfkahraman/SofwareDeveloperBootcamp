using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        //Bir iş sınıfı başka bir sınıfı newlemez!!
        //Bu nedenle aşağıdaki gibi dependency injection yapıyoruz.
        //Soyut katman için uygulanır bu nedenle InMemoryProductDal değil IProductDal kullandık
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            //Arayüzden (ConsoleUI olarak simule ettik) kullanıcı bir işlem yapmak istediğinde
            //Business katmanı bu işlemlerin iş kurallarına uygun olup olmadığına bakar
            //İş kodları, kurallar vs burada olur. Eğer kurallara uygunsa Datayı çağırır
            return _productDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p=> p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p=> p.UnitPrice>=min && p.UnitPrice<=max);
        }

        public List<ProductDetailDto> GetProductsDetails()
        {
            return _productDal.GetProductsDetails();
        }
    }
}
