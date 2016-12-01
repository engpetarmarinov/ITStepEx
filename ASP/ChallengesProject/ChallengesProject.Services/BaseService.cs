using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengesProject.Data;
using ChallengesProject.Data.Repositories;
using System.Linq.Expressions;
using System.Web;
using System.IO;

namespace ChallengesProject.Services
{
    public abstract class BaseService<T> : IService<T> where T : class
    {
        protected IChallengesData Data { get; private set; }

        protected BaseService(IChallengesData data)
        {
            this.Data = data;
        }

        public IQueryable<T> GetAll()
        {
            return Data.GetRepository<T>().All();
        }

        public IQueryable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            return Data.GetRepository<T>().Get(filter, orderBy, includeProperties);
        }

        public T Find(object id)
        {
            return Data.GetRepository<T>().Find(id);
        }

        public void Update(T entity)
        {
            Data.GetRepository<T>().Update(entity);
        }

        public void Add(T entity)
        {
            Data.GetRepository<T>().Add(entity);
        }

        public void Delete(object id)
        {
            Data.GetRepository<T>().Delete(id);
        }

        public virtual int SaveChanges()
        {
            return Data.SaveChanges();
        }

        public void SaveFile(HttpPostedFileBase ImageFile, string path, string fileName)
        {
            if (!Directory.Exists(path))
            {
                // Try to create the directories recursively.
                Directory.CreateDirectory(path);
            }
            ImageFile.SaveAs(Path.Combine(path, fileName));
        }
    }
}
