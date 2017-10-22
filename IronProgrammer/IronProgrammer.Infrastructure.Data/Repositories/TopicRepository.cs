using System;
using System.Collections.Generic;
using System.Linq;
using IronProgrammer.Domain.Core.EF;
using IronProgrammer.Domain.Interfaces;
using IronProgrammer.Infrastructure.Data.EF;

namespace IronProgrammer.Infrastructure.Data.Repositories
{
    public class TopicRepository : IRepository<Topic>
    {
        private readonly DatabaseContext _db;

        public TopicRepository(DatabaseContext db)
        {
            _db = db;
        }
        public IEnumerable<Topic> GetItemList()
        {
            return _db.Topics.ToList();
        }

        public Topic GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(Topic item)
        {
            throw new NotImplementedException();
        }

        public void Update(Topic item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Topic> Find(Func<Topic, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
