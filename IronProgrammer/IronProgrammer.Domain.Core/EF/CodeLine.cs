using IronProgrammer.Models.EF;

namespace IronProgrammer.Domain.Core.EF
{
    public class CodeLine
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public virtual Problem Task { get; set; }
    }
}