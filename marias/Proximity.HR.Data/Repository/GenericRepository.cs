using System;
using System.Linq;

namespace Proximity.HR.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ProximityHREntities _dbContext;

        public GenericRepository(ProximityHREntities dbContext)
        {
            this._dbContext = dbContext;
        }

        public IQueryable<T> Get()
        {
            IQueryable<T> query = this._dbContext.Set<T>();

            return query;
        }

        public IQueryable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = this._dbContext.Set<T>().Where(predicate);

            return query;
        }

        public void Add(T entity)
        {
            this._dbContext.Set<T>().Add(entity);
        }

        public void Edit(T entity)
        {
            this._dbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public void Edit2(T entity)
        {
            this._dbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(T entity)
        {
            this._dbContext.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            // this._dbContext.Set<T>().Remove(entity);
        }

        public void Save()
        {
            this._dbContext.SaveChanges();
        }

        public void Dispose()
        {
            this._dbContext.Dispose();
        }
    }
}
