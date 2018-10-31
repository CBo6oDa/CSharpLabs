using System;
using System.Collections.Generic;
using CSharpLab1.Interfaces;

namespace CSharpLab1.Models
{
    public class Team : INameAndCopy,IComparable
    {
        private int _registrationNumber;
        public int RegistrationNumber
        {
            get => _registrationNumber;
            set
            {
                if (value > 0)
                {
                    _registrationNumber = value;
                }
                else
                {
                    throw new ArgumentNullException($"Registration Number has to be bigger than 0.");
                }
            }
        }
        public string Name { get; set; }

        public Team() : this(name: "Fantastic fourth", registrationNumber: 1) {}
        public Team(string name, int registrationNumber)
        {
            RegistrationNumber = registrationNumber;
            Name = name;
        }

        public virtual object DeepCopy()
        {
            Team copy = (Team)MemberwiseClone();
            return copy;
        }
        public override bool Equals(object obj)
        {
            var team = obj as Team;
            return team != null &&
                   RegistrationNumber == team.RegistrationNumber &&
                   Name == team.Name;
        }
        public static bool operator ==(Team team1, Team team2)
        {
            if (ReferenceEquals(team1, team2))
            {
                return true;
            }
            if (ReferenceEquals(team1, null) || ReferenceEquals(team2, null))
            {
                return false;
            }
            return team1.Name == team2.Name &&
                   team1.RegistrationNumber == team2.RegistrationNumber;
        }
        public static bool operator !=(Team team1, Team team2)
        {
            return !(team1 == team2);
        }
        public override int GetHashCode()
        {
            var hashCode = 1545691223;
            hashCode = hashCode * -1521134295 + RegistrationNumber.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }

        public int CompareTo(object obj)
        {
            Team team = obj as Team;
            if (team != null)
            {
                return RegistrationNumber.CompareTo(team.RegistrationNumber);
            }
            throw new Exception("These objects cannot be compared!");
        }
        public override string ToString()
        {
            return $"\nTeam: \nOrganization: {Name}\nRegistration number: {RegistrationNumber}\n";
        }
    }
}
