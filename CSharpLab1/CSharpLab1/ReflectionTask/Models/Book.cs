using CSharpLab1.Interfaces;

namespace CSharpLab1.ReflectionTask.Models
{
    public class Book : IHasName
    {
        public string Name { get; }
        public Book()
        {
            Name = "Book";
        }

        public Book(string name)
        {
            Name = name;
        }

    }
}
