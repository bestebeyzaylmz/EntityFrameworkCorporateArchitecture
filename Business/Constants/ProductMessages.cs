using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    //newlenmeyecekse static yaparız
    public static class ProductMessages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string ProductsListed = "Ürünler listelendi";
        public static string ProductMaintenanceTime = "Sistem bakımda";
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir";
        public static string ProductNameAlreadyExists = "Aynı isimli en az 1 ürün var. Ürün ismini değiştirin";
    }
}
