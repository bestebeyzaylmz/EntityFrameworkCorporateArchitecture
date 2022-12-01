using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    //filtering is done here
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll(); //mesaj işlem sonucu ve data içermesi için Dataresult oluşturduk
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<Product> GetById(int productId);
        IResult Add(Product product);
        IResult Update(Product product);

    }
}
