﻿using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    //filtering is done here
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetAllByCategoryId(int id);
        List<Product> GetByUnitPrice(decimal min, decimal max);

    }
}
