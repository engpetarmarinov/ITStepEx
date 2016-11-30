using System;
using System.Linq;
using System.Linq.Expressions;

namespace ChallengesProject.Services
{
    public interface IService<T> where T : class
    {
        IQueryable<T> GetAll();

        IQueryable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

            T Find(object id);

        void Update(T entity);

        void Add(T entity);

        void Delete(object id);

        int SaveChanges();
    }
}