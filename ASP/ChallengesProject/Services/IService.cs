using System.Collections.Generic;

namespace ChallengesProject.Services
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> GetAll();

        T Find(object id);

        void Update(T entity);

        void Add(T entity);

        void Delete(object id);
    }
}