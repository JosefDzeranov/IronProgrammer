using System.Collections.Generic;

namespace IronProgrammer.Domain.Core.EF
{
    /// <summary>
    /// Тема задания
    /// </summary>
    public class Topic
    {
        public int Id { get; set; }

        /// <summary>
        /// Имя темы задания
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// К каким задачам относится
        /// </summary>
        public virtual ICollection<Problem> Problems { get; set; }
        public Topic()
        {
            Problems = new List<Problem>();
        }
    }
}