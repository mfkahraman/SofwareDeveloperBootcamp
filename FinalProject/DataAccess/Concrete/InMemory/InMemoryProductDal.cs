using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        //Alttaki products değişkenini bir classın içinde ama metotların dışında tanımladığımız için
        //buna global değişken deniyor ve "_" ile başlatılıyor, isimlendirme standardı.
        List<Product> _products;

        //consturactor oluşturuyoruz,referans aldığı zaman otomatik çalışan metoda constractor deniyor.
        //Biz InMemoryProductDal classını kullandığımızda alttaki metot otomatik çalışıyor
        //sanki DBden ürün bilgileri geliyormuş gibi simüle ediyoruz 
        public InMemoryProductDal()
        {
            _products = new List<Product>{
            new Product{ProductId = 1, CategoryId = 1, ProductName = "Bardak", UnitPrice = 15, UnitsInStock= 15},
            new Product{ProductId = 2, CategoryId = 1, ProductName = "Kamera", UnitPrice = 500, UnitsInStock= 3},
            new Product{ProductId = 3, CategoryId = 2, ProductName = "Telefon", UnitPrice = 1500, UnitsInStock= 2},
            new Product{ProductId = 4, CategoryId = 2, ProductName = "Klavye", UnitPrice = 150, UnitsInStock= 65},
            new Product{ProductId = 5, CategoryId = 2, ProductName = "Fare", UnitPrice = 85, UnitsInStock= 1}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        //"_products.Remove(product)" yapamıyoruz çünkü bu productların her biri referans tip
        //Bu durumda Linq kullanıyoruz ve primary key olan ProductIdye göre kodumuzu yazıyoruz
        //LINQ = Language Integrated Query - Dile gömülü sorgulama. "using System.Linq" gerekli
        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            //Single or default tek eleman bulmaya yarar, ürünleri tek tek dolaşır foreach gibi.
            //"=>" ifadesine Lambda denir. Değişkene "p" dedik ve pnin productidsi delete metoduna
            //gönderdiğimiz productın product idsi ile aynı olana kadar dolaşmasını sağladık.
            _products.Remove(productToDelete);
        }
        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }


        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return _products;
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductsDetails()
        {
            throw new NotImplementedException();
        }
    }
}
