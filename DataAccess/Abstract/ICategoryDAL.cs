﻿using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICategoryDAL:IEntityRepository<Category>
    {
        //ürüne ait özel operasyonlar
        //ürün ve kategori tablolarına join atmak gibi

    }
}
