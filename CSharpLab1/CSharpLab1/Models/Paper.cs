using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharpLab1.Models
{
    public class Paper
    {
        public string Title { get; set; }
        public Person Person { get; set; }
        public DateTime DateOfPublishing { get; set; }
        public Paper() : this(title: "C# tutorial", person: new Person(), dateOfPublishing: new DateTime(2018, 01, 01, 12, 0, 0)) { }
        public Paper(string title, Person person, DateTime dateOfPublishing)
        {
            Title = title;
            Person = person;
            DateOfPublishing = dateOfPublishing;
        }
        public override bool Equals(object obj)
        {
            var paper = obj as Paper;
            return paper != null &&
                   Title == paper.Title &&
                   Person.Equals(Person, paper.Person) &&
                   DateOfPublishing == paper.DateOfPublishing;
        }
        public static bool ArrayEquals(ArrayList papers1, ArrayList papers2)
        {
            if (papers1?.Count != papers2?.Count || papers1 == null && papers2 == null)
                return false;

            for (int i = 0; i < papers1.Count; i++)
                if (!papers1[i].Equals(papers2[i]))
                    return false;

            return true;
        }
        public static bool operator ==(Paper paper1, Paper paper2)
        {
            if (ReferenceEquals(paper1, paper2))
            {
                return true;
            }
            if (ReferenceEquals(paper1, null))
            {
                return false;
            }
            if (ReferenceEquals(paper2, null))
            {
                return false;
            }
            return paper1.Title == paper2.Title &&
                   paper1.Person == paper2.Person &&
                   paper1.DateOfPublishing == paper2.DateOfPublishing;
        }
        public static bool operator !=(Paper paper1, Paper paper2)
        {
            return !(paper1 == paper2);
        }
        public Paper ShallowCopy()
        {
            return (Paper)MemberwiseClone();
        }

        public virtual Paper DeepCopy()
        {
            Paper copy = (Paper)MemberwiseClone();
            copy.Title = String.Copy(Title);
            copy.Person = Person.DeepCopy();
            copy.DateOfPublishing = copy.DateOfPublishing;
            return copy;
        }
        public override int GetHashCode()
        {
            var hashCode = 1125929410;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + EqualityComparer<Person>.Default.GetHashCode(Person);
            hashCode = hashCode * -1521134295 + DateOfPublishing.GetHashCode();
            return hashCode;
        }
        public override string ToString()
        {
            return $"\nPaper:\nTitle: {Title}\nDate of publishing: {DateOfPublishing}\n{Person}\n";
        }

    }
}
