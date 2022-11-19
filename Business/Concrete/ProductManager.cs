using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    //iş katmanının somut sınıfı
    public class ProductManager : IProductService
    {
        IProductDAL _productDAL;

        public ProductManager(IProductDAL productDAL)
        {
            _productDAL = productDAL;
        }

        public List<Product> GetAll()
        {
            //iş kodları
            //bir iş sınıfı başka sınıfları newlemez. bu yuzden public alanda _inMemoryProductDAL oluşturulur
            //yetki

            return _productDAL.GetAll();

        }
    }
}
