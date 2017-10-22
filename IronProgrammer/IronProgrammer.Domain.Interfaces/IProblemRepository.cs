using System.Collections.Generic;
using IronProgrammer.Domain.Core.EF;

namespace IronProgrammer.Domain.Interfaces
{
    public interface IProblemRepository
    {
        IEnumerable<Problem> GetItemList();
        Problem GetItem(int id);
        void Create(Problem item);
        void Update(Problem item);
        void Delete(int id);
        void Save();
    }
}
