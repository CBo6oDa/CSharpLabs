using System;

namespace CSharpLab1
{
    public class Person
    {
        private string _name;
        private string _surname;
        private DateTime _dateOfBirth;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Surname
        {
            get { return _surname;} set { _surname = value; }
        }
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth;}
            set { _dateOfBirth = value; }
        }

        public Person() : this(name: "James", surname: "Bay", dateTime: DateTime.Now){ }
        public Person(String name, String surname, DateTime dateTime)
        {
            Name = name;
            Surname = surname;
            DateOfBirth = dateTime;
        }
        public int YearOfBirth
        {
            get
            {
                return _dateOfBirth.Year;
            }
            set
            {
                if (value > 0)
                {
                    _dateOfBirth = new DateTime(value, _dateOfBirth.Month, _dateOfBirth.Day,_dateOfBirth.Hour,_dateOfBirth.Minute,_dateOfBirth.Second);
                }
            }
        }
        public override string ToString()
        {
            return $"\nPerson: \nName: {Name}\nSurname: {Surname}\nDate of birth: {_dateOfBirth}\n";
        }

        public virtual string ToShortString()
        {
            return $"\nPerson: \nName: {Name}\nSurname: {Surname}\n";
        }

    }
 }
