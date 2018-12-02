using CSharpLab1.Attributes;

namespace CSharpLab1.ReflectionTask.Models
{
    [Couple(Pair = "Girl", Probability = 70, ChildType = "SmartGirl")]
    [Couple(Pair = "PrettyGirl", Probability = 100, ChildType = "PrettyGirl")]
    [Couple(Pair = "SmartGirl", Probability = 80, ChildType = "Book")]
    public class Botan : Human
    {
        public Botan() : base("Botan")
        {
        }

        public Botan(string name) : base(name)
        {
        }

    }
}
