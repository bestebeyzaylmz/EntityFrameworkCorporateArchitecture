using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

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

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDAL.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDAL.GetAll(p=>p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDAL.GetProductDetails();
        }
    }
}
