using System;
using System.Collections.Generic;

namespace IronProgrammer.Domain.Interfaces
{
    public interface IRepository<T> : IDisposable
    {
        IEnumerable<T> GetItemList();
        T GetItem(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}
