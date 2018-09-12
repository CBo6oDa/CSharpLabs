using System;

namespace CSharpLab1
{
    public enum TimeFrame
    {
        Year,
        TwoYears,
        Long
    };
    public class Paper
    {
        public string Title { get; set; }
        public Person Person { get; set; }
        public DateTime DateOfPublishing { get; set; }

        public Paper()
        {
            Title = "C# tutorial";
            Person = new Person();
            DateOfPublishing = DateTime.Now;
        }
        public Paper(string title, Person person, DateTime dateOfPublishing)
        {
            Title = title;
            Person = person;
            DateOfPublishing = dateOfPublishing;
        }
        public override string ToString()
        {
            return $"\nPaper: \ntitle: {Title}\n{Person}\ndate of publishing: {DateOfPublishing}\n";
        }
    }
}
