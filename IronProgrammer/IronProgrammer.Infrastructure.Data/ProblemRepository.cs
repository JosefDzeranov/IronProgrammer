using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using IronProgrammer.Domain.Core.EF;
using IronProgrammer.Domain.Interfaces;
namespace IronProgrammer.Infrastructure.Data
{
    public class ProblemRepository : IRepository<Problem>
    {
        private readonly ProblemContext _db;

        public ProblemRepository()
        {
            _db = new ProblemContext();
        }

        public IEnumerable<Problem> GetItemList()
        {
            return _db.Problems.ToList();
        }

        public Problem GetItem(int id)
        {
            return _db.Problems.Find(id);
        }

        public void Create(Problem item)
        {
            _db.Problems.Add(item);
        }

        public void Update(Problem item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var problem = _db.Problems.Find(id);
            if (problem != null)
            {
                _db.Problems.Remove(problem);
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
