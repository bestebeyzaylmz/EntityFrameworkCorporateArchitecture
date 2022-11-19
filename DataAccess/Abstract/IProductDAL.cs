using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //interface/entity/katman-data access layer --> 
    public interface IProductDAL:IEntityRepository<Product>
    {
        
    }
}
