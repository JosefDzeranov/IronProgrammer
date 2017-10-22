using System.Collections.Generic;

namespace IronProgrammer.Domain.Core.EF
{
    /// <summary>
    /// Тип задания
    /// </summary>
    public class TypeProblem
    {
        public int Id { get; set; }

        /// <summary>
        /// Название типа задания
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// К каким заданиям относится
        /// </summary>
        public virtual ICollection<Problem> Problems { get; set; }

        public TypeProblem()
        {
            Problems = new List<Problem>();
        }
    }
}