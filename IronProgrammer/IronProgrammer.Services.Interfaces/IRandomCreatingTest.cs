using System;

namespace IronProgrammer.Services.Interfaces
{
    public interface IRandomCreatingTest<T>
    {
        T CreateTest(T begin, T end, Func<T, bool> condition);//
    }
}