using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductTest();
            //CategoryTest();
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDAL(), new CategoryManager(new EfCategoryDAL()));

            var result = productManager.GetProductDetails();
            if (result.Success)
            {
                foreach (var item in productManager.GetProductDetails().Data)
                {
                    Console.WriteLine(item.ProductName + " / " + item.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDAL());

            foreach (var item in categoryManager.GetAll().Data)
            {
                Console.WriteLine(item.CategoryName);
            }
        }
    }
}
