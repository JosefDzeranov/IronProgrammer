using System.Collections.Generic;

namespace IronProgrammer.Domain.Core.EF
{
    /// <summary>
    /// Модель данных представляющее задание
    /// </summary>
    public class Problem
    {
        public int Id { get; set; }

        /// <summary>
        /// Название задачи
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Тип задания
        /// </summary>
        public int TypeProblemId { get; set; }
        public virtual TypeProblem TypeProblem { get; set; }

        /// <summary>
        /// Сложность задания
        /// </summary>
        public int? ComplexityId { get; set; }
        public virtual Complexity Complexity { get; set; }

        /// <summary>
        /// К каким тема относится задача
        /// </summary>
        public virtual ICollection<Topic> Topics { get; set; }

        public Problem()
        {
            Topics = new List<Topic>();
        }
    }
}