using System;
using System.Collections.Generic;
using IronProgrammer.Domain.Core.EF;

namespace IronProgrammer.Domain.Interfaces
{
    public interface IProblemRepository<T>
    {
        IEnumerable<T> GetItemList();
        T GetItem(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
    }
}
