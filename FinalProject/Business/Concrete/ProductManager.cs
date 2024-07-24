using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        //Bir iş sınıfı başka bir sınıfı newlemez!!
        //Bu nedenle aşağıdaki gibi dependency injection yapıyoruz.
        //Soyut katman için uygulanır bu nedenle InMemoryProductDal değil IProductDal kullandık
        IProductDal _productDal;

        //Bir entity manager kendisi hariç başka bir DALı enjekte etmez.
        //Örneğin bu managere ICategoryDal enjeksiyonu yapamazsın böyle durumlarda servisi enjekte etmelisin.
        ICategoryService _categoryService;

        public ProductManager(IProductDal productDal,ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
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
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductsDetails()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductsDetails());
        }

        //alttaki attribute, metodu ProductValidatordaki kurallara göre validation yapar
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                CheckIfProductNameAvailable(product.ProductName), CheckIfCategoryLimitExceeded(product.CategoryId));

            //Run metodumuz parametre olarak gönderdiğimiz iş kuralı metodlarımızın sonucunda hata varsa
            //hata alınan metodun sonucunu döndürür.

            //Eğer sorun yoksa null döner. Yani null dönmesi gönderilen product tüm kurallardan geçiyor demek.
            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);

        }

        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result < 10)
            {
                return new SuccessResult(Messages.CategoryIsAvailable);
            }

            else
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
        }

        private IResult CheckIfProductNameAvailable(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();

            if (result)
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            else
                return new SuccessResult(Messages.ProductNameIsAvailable);
        }


        private IResult CheckIfCategoryLimitExceeded(int categoryId)
        {
            var result = _categoryService.GetAll().Data.Count;

            if (result >15)
                return new ErrorResult(Messages.CategoryLimitExceeded);
            else
                return new SuccessResult(Messages.CategoryIsAvailable);
        }

    }
}
