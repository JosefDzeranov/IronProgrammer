using System;
using IronProgrammer.Infrastructure.Data.EF;

namespace IronProgrammer.Infrastructure.Data.Repositories
{
    public class UnitOfWork
    {
        private DatabaseContext _db = new DatabaseContext();
        private ProblemRepository _problemRepository;
        private TopicRepository _topicRepository;

        private bool _disposed = false;

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

        public TopicRepository Topics
        {
            get
            {
                if (_topicRepository == null)
                {
                    _topicRepository = new TopicRepository(_db);
                }
                return _topicRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

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
