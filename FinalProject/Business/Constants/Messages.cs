using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        //Constants sabit demek, proje sabitleri buraya konulur. Metinler, mesajlar, enumlar vs.
        //static yaptığında o classı newlemen gerekmiyor

        public static string ProductAdded = "Ürün eklendi.";
        public static string ProductNameInvalid = "Ürün ismi geçersizdir";
        public static string MaintenanceTime = "Sistem bakımdadır";
        public static string ProductsListed = "Ürünler listelendi";
    }
}
