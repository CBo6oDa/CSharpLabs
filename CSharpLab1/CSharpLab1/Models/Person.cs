using System;
using System.Collections.Generic;

namespace CSharpLab1.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Person() : this(name: "James", surname: "Bay", dateTime: new DateTime(2018,01,01,12,0,0)){ }
        public Person(String name, String surname, DateTime dateTime)
        {
            Name = name;
            Surname = surname;
            DateOfBirth = dateTime;
        }
        public int YearOfBirth
        {
            get => DateOfBirth.Year;
            set
            {
                if (value > 0)
                {
                    DateOfBirth = new DateTime(
                        value, 
                        DateOfBirth.Month,
                        DateOfBirth.Day,
                        DateOfBirth.Hour,
                        DateOfBirth.Minute,
                        DateOfBirth.Second);
                }
            }
        }
        public Person ShallowCopy()
        {
            return (Person)MemberwiseClone();
        }
        public virtual Person DeepCopy()
        {
            Person copy = (Person)MemberwiseClone();
            copy.Name = String.Copy(Name);
            copy.Surname = String.Copy(Surname);
            return copy;
        }
        public override bool Equals(object obj)
        {
            var person = obj as Person;
            return person != null &&
                   Name == person.Name &&
                   Surname == person.Surname &&
                   DateOfBirth == person.DateOfBirth;
        }
        public static bool operator ==(Person person1, Person person2)
        {
            if (ReferenceEquals(person1, person2))
            {
                return true;
            }
            if (ReferenceEquals(person2, null))
            {
                return false;
            }
            if (ReferenceEquals(person1, null))
            {
                return false;
            }
            return person1.Name == person2.Name &&
                   person1.Surname == person2.Surname &&
                   DateTime.Compare(person1.DateOfBirth,person2.DateOfBirth) == 0;
        }
        public static bool operator !=(Person person1, Person person2)
        {
            return !(person1 == person2);
        }
        public override int GetHashCode()
        {
            var hashCode = 1430107185;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Surname);
            hashCode = hashCode * -1521134295 + DateOfBirth.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"\nPerson:\nName: {Name}\nSurname: {Surname}\nDate of birth: {DateOfBirth}\n";
        }

        public virtual string ToShortString()
        {
            return $"\nPerson:\nName: {Name}\nSurname: {Surname}\n";
        }
    }
 }
