using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using IronProgrammer.Domain.Core.EF;
using IronProgrammer.Domain.Interfaces;
using IronProgrammer.Infrastructure.Data.EF;

namespace IronProgrammer.Infrastructure.Data.Repositories
{
    public class ProblemRepository : IRepository<Problem>
    {
        private readonly DatabaseContext _db;

        public ProblemRepository(DatabaseContext db)
        {
            _db = db;
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

        public IEnumerable<Problem> Find(Func<Problem, bool> predicate)
        {
            return _db.Problems.Where(predicate).ToList();
        }
    }
}
