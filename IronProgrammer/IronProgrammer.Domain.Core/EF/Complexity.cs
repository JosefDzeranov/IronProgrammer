using System.Collections.Generic;

namespace IronProgrammer.Domain.Core.EF
{
    /// <summary>
    /// Сложность задачи
    /// </summary>
    public class Complexity
    {
        public int Id { get; set; }

        /// <summary>
        /// Название уровня сложности
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// К каким задачам относится
        /// </summary>
        public virtual ICollection<Problem> Problems { get; set; }

        public Complexity()
        {
            Problems = new List<Problem>();
        }
    }
}