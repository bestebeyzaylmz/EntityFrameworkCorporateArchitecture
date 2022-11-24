using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDAL _categoryDAL;

        public CategoryManager(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }

        public List<Category> GetAll()
        {
            //business code
            return _categoryDAL.GetAll();
        }

        public Category GetById(int categoryId)
        {
            return _categoryDAL.Get(p => p.CategoryId == categoryId) ;
        }
    }
}
