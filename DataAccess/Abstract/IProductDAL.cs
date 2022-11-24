using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    //interface/entity/katman-data access layer --> 
    public interface IProductDAL:IEntityRepository<Product>
    {
        List<ProductDetailDto> GetProductDetails();
    }
}
