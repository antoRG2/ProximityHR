using Proximity.HR.Data;
using Proximity.HR.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proximity.HR.Data.Repository
{
    public class UnitOfWork : IDisposable
    {
        private ProximityHREntities _dbContext = new ProximityHREntities();

        private bool disposed;

        public ProximityHREntities getContext()
        {
            return this._dbContext;
        }



        public GenericRepository<T> GetRepositoryInstance<T>() where T : class
        {
            return new GenericRepository<T>(_dbContext);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}