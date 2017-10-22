using System;
using System.Collections.Generic;
using System.Data.Entity;
using IronProgrammer.Domain.Core.EF;
using IronProgrammer.Domain.Interfaces;
using IronProgrammer.Infrastructure.Data.EF;
using System.Linq;

namespace IronProgrammer.Infrastructure.Data.Repositories
{
    public class ComplexityRepository : IRepository<Complexity>
    {
        private readonly DatabaseContext _db;

        public ComplexityRepository(DatabaseContext db)
        {
            _db = db;
        }
        public IEnumerable<Complexity> GetItemList()
        {
            return _db.Complexities.ToList();
        }

        public Complexity GetItem(int id)
        {
            return _db.Complexities.Find(id);
        }

        public void Create(Complexity item)
        {
            _db.Complexities.Add(item);
        }

        public void Update(Complexity item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var complexity = _db.Complexities.Find(id);
            if (complexity != null)
            {
                _db.Complexities.Remove(complexity);
            }
        }

        public IEnumerable<Complexity> Find(Func<Complexity, bool> predicate)
        {
            return _db.Complexities.Where(predicate).ToList();
        }
    }
}
