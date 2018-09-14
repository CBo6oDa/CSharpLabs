using System;
using System.Reflection;

namespace CSharpLab1
{
    public class Paper
    {
        public string Title { get; set; }
        public Person Person { get; set; }
        public DateTime DateOfPublishing { get; set; }

        public Paper() : this(title: "C# tutorial", person: new Person(), dateOfPublishing: DateTime.Now){ }
        public Paper(string title, Person person, DateTime dateOfPublishing)
        {
            Title = title;
            Person = person;
            DateOfPublishing = dateOfPublishing;
        }
        public override string ToString()
        {
            return $"\nPaper: \ntitle: {Title}\ndate of publishing: {DateOfPublishing}\n{Person}\n";
        }
    }
}
