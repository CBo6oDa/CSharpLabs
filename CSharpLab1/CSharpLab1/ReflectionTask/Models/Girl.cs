using CSharpLab1.Attributes;

namespace CSharpLab1.ReflectionTask.Models
{
    [Couple(Pair = "Student", Probability = 70, ChildType = "Girl")]
    [Couple(Pair = "Botan", Probability = 30, ChildType = "SmartGirl")]
    public class Girl : Human
    {
        public Girl() : base("Girl")
        {
        }

        public Girl(string name) : base(name)
        {
        }
    }
}
