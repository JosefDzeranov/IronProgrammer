using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using IronProgrammer.Domain.Core.EF;
using IronProgrammer.Domain.Interfaces;
using IronProgrammer.Infrastructure.Data.EF;

namespace IronProgrammer.Infrastructure.Data.Repositories
{
    public class TypeProblemRepository : IRepository<TypeProblem>
    {
        private readonly DatabaseContext _db;

        public TypeProblemRepository(DatabaseContext db)
        {
            _db = db;
        }
        public IEnumerable<TypeProblem> GetItemList()
        {
            return _db.TypeProblems.ToList();
        }

        public TypeProblem GetItem(int id)
        {
            return _db.TypeProblems.Find(id);
        }

        public void Create(TypeProblem item)
        {
            _db.TypeProblems.Add(item);
        }

        public void Update(TypeProblem item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var typeProblem = _db.TypeProblems.Find(id);
            if (typeProblem != null)
            {
                _db.TypeProblems.Remove(typeProblem);
            }
        }

        public IEnumerable<TypeProblem> Find(Func<TypeProblem, bool> predicate)
        {
            return _db.TypeProblems.Where(predicate).ToList();
        }
    }
}
