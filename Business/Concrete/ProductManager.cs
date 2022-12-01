using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    //iş katmanının somut sınıfı
    public class ProductManager : IProductService
    {
        IProductDAL _productDAL;
        ICategoryService _categoryService;
        public ProductManager(IProductDAL productDAL, ICategoryService categoryService)
        {
            _productDAL = productDAL;
            _categoryService = categoryService;
        }

        //[LogAspect] //AOP //autofact aop imkanı sunar
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //business codes
            //validation

            //bir kategoride en fazla 10 ürün olabilir.
            //aynı isimde ürün eklenemez
            var result = BusinessRules.Run(CheckIsSameProductName(product.ProductName), CheckIfProductCountOfCategoryCorrect(product.CategoryId), CheckIfCategoryLimitExceded());

            if (result != null)
            {
                return result;
            }

            _productDAL.Add(product);
            return new SuccessResult(ProductMessages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            //iş kodları
            //bir iş sınıfı başka sınıfları newlemez. bu yuzden public alanda _inMemoryProductDAL oluşturulur
            //yetkisi var mı

            //if (DateTime.Now.Hour == 15)
            //{
            //    return new ErrorDataResult<List<Product>>(ProductMessages.ProductMaintenanceTime);
            //}
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
            //if (DateTime.Now.Hour == 15)
            //{
            //    return new ErrorDataResult<List<ProductDetailDto>>(ProductMessages.ProductMaintenanceTime);
            //}
            return new SuccessDataResult<List<ProductDetailDto>>(_productDAL.GetProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            if (CheckIfProductCountOfCategoryCorrect(product.CategoryId).Success)
            {

            }
            return new ErrorResult();
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            //Select count(*) from products where categoryId=1
            var result = _productDAL.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(ProductMessages.ProductCountOfCategoryError);
            }

            return new SuccessResult();
        }

        private IResult CheckIsSameProductName(string productName)
        {
            var result = _productDAL.GetAll(p => p.ProductName == productName).Any();
            if (result == true)
            {
                return new ErrorResult(ProductMessages.ProductNameAlreadyExists);
            }

            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();

            if (result.Data.Count >15)
            {
                return new ErrorResult(CategoryMessages.CategoryLimitExceded);
            }

            return new SuccessResult();
        }
    }
}
