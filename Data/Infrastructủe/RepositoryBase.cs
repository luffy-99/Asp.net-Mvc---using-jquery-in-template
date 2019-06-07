using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infrastructủe
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        private ShopOnlineDbContext dbContext;
        private readonly IDbSet<T> dbSet;
        protected IDbFactory DbFactory
        {
            private set;
            get;
        }
        public ShopOnlineDbContext DbContext
        {
            get { return dbContext ?? (dbContext = DbFactory.Init()); }
        }
        public RepositoryBase(IDbFactory dbFactory)
        {
            this.DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }
        public T Add(T entity)
        {
            return dbSet.Add(entity);
        }

        public T Delete(int id)
        {
            var entity = dbSet.Find(id);
            return dbSet.Remove(entity);
        }

        public T Delete(T entity)
        {
            return dbSet.Remove(entity);
        }

        public IEnumerable<T> GetAll(string[] includes = null)
        {
            if(includes !=null && includes.Count() > 0)
            {
                var query = dbContext.Set<T>().Include(includes.First());
                foreach(var include in includes.Skip(1))
                {
                    query = query.Include(include);
                }
                return query.AsQueryable();
            }
            return dbContext.Set<T>().AsQueryable();
        }

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
