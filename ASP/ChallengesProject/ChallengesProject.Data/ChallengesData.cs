using System;
using System.Collections.Generic;
using ChallengesProject.Models;

namespace ChallengesProject.Data
{
    using ChallengesProject.Data.Repositories;

    public class ChallengesData
    {
        protected ChallengesDbContext Context { get; set; }
        protected Dictionary<Type, object> Repositories { get; set; }
        
        public IRepository<Challenge> Challenges => GetRepository<Challenge>();

        public IRepository<ApplicationUser> Users => GetRepository<ApplicationUser>();

        public ChallengesData() : this(new ChallengesDbContext())
        {
            
        }

        public ChallengesData(ChallengesDbContext context)
        {
            this.Context = context;
        }


        public IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.Repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(GenericRepository<T>), Context);
                this.Repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.Repositories[typeOfRepository];
        }

    }
}