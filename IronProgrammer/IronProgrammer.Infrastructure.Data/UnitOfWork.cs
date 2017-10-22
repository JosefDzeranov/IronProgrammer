using System;

namespace IronProgrammer.Infrastructure.Data
{
    public class UnitOfWork
    {
        private ProblemContext _db = new ProblemContext();
        private ProblemRepository _problemRepository;

        public ProblemRepository Problems
        {
            get
            {
                if (_problemRepository == null)
                {
                    _problemRepository = new ProblemRepository(_db);
                }
                return _problemRepository;
            }
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
