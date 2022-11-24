using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //using Generic Repository Design Pattern
    //generic constraint
    //class can be referance type
    //new() : can newable
    public interface IEntityRepository<T> where T:class, IEntity,new()
    {
        //write expression for filter
        // filter can be null
        List<T> GetAll(Expression<Func<T, bool>> filter = null);

        //Refactoring//takes only an id
        //filter cannot be null
        T Get(Expression<Func<T, bool>> filter); 

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
