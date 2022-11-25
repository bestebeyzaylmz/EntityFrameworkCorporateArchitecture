using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
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

        public IResult Add(Product product)
        {
            //business codes
            if (product.ProductName.Length < 2)
            {
                return new ErrorResult(ProductMessages.ProductNameInvalid);
            }
            _productDAL.Add(product);
            
            return new Result(true, ProductMessages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            //iş kodları
            //bir iş sınıfı başka sınıfları newlemez. bu yuzden public alanda _inMemoryProductDAL oluşturulur
            //yetkisi var mı

            if (DateTime.Now.Hour == 15)
            {
                return new ErrorDataResult<List<Product>>(ProductMessages.ProductMaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDAL.GetAll(), ProductMessages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDAL.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDAL.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDAL.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 15)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(ProductMessages.ProductMaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDAL.GetProductDetails());
        }
    }
}
