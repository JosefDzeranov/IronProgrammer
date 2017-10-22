using IronProgrammer.Domain.Core.EF;

namespace IronProgrammer.Models.EF
{

    public enum Attributes
    {
        Description,
        Input,
        Output
    }
    public class ProblemAttribute
    {
        public int Id { get; set; }
        public virtual Problem Task { get; set; }
        public Attributes Attribute { get; set; }
        public string Value { get; set; }
    }

}