using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            return _db.Topics.Find(id);
        }

        public void Create(Topic item)
        {
            _db.Topics.Add(item);
        }

        public void Update(Topic item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var topic = _db.Topics.Find(id);
            if (topic != null)
            {
                _db.Topics.Remove(topic);
            }
        }

        public IEnumerable<Topic> Find(Func<Topic, bool> predicate)
        {
            return _db.Topics.Where(predicate).ToList();
        }
    }
}
