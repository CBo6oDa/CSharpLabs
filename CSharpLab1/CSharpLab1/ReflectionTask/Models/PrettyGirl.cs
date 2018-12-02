using CSharpLab1.Attributes;

namespace CSharpLab1.ReflectionTask.Models
{
    [Couple(Pair = "Student", Probability = 40, ChildType = "PrettyGirl")]
    [Couple(Pair = "Botan", Probability = 10, ChildType = "PrettyGirl")]
    public class PrettyGirl : Human
    {
        public PrettyGirl() : base("PrettyGirl")
        {
        }

        public PrettyGirl(string name) : base(name)
        {
        }
    }
}
