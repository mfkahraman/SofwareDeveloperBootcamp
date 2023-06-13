using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IDataResult<List<Product>> GetAll()
        {
            //Arayüzden (ConsoleUI olarak simule ettik) kullanıcı bir işlem yapmak istediğinde
            //Business katmanı bu işlemlerin iş kurallarına uygun olup olmadığına bakar
            //İş kodları, kurallar vs burada olur. Eğer kurallara uygunsa Datayı çağırır
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=> p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=> p.UnitPrice>=min && p.UnitPrice<=max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductsDetails()
        {
            if(DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductsDetails());
        }

        public IResult Add(Product product) 
        { 
            //business codes

            if (product.ProductName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }


    }
}
