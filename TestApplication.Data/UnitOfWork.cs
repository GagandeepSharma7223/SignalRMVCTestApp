using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Data.Context;
using TestApplication.Data.Entities;

namespace TestApplication.Data
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        private TestDBContext context = new TestDBContext();
        private GenericRepository<DevTest> devRepository;
        public GenericRepository<DevTest> Developers
        {
            get
            {

                if (this.devRepository == null)
                {
                    this.devRepository = new GenericRepository<DevTest>(context);
                }
                return devRepository;
            }
        }
        public int Save()
        {
            return context.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
