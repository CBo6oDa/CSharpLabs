using CSharpLab1.Attributes;

namespace CSharpLab1.ReflectionTask.Models
{
    [Couple(Pair = "Student", Probability = 20, ChildType = "Girl")]
    [Couple(Pair = "Botan", Probability = 50, ChildType = "Book")]
    public class SmartGirl : Human
    {
        public SmartGirl() : base("SmartGirl")
        {
        }

        public SmartGirl(string name) : base(name)
        {
        }
    }
}
