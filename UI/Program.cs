﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDAL());

            foreach (var item in productManager.GetAllByCategoryId(2))
            {
                Console.WriteLine(item.ProductName);
            }
        }
    }
}
