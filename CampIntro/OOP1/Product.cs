using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
    class Product
    {//forekey - referans anahtarları, Idler gibi. Kod okurunluğu için üst
     //satırlara yazılır.
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public int UnitInStock { get; set; }

        //CRUD Operasyonları - Create, Read, Update, Delete - Ürünlerle
        //ilgili yaptığımız işlemler, operasyonlar.
    }
}
