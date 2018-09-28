using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CSharpLab1.Models
{
    public class ResearchTeam : Team, IEnumerable
    {
        public string ExploreTheme { get; set; }
        public TimeFrame TimeOfExplore { get; set; }
        public ArrayList Papers { get; set; }
        public ArrayList Persons { get; set; }
        public Paper GetLastArticle => (Paper) Papers?[Papers.Count - 1];
        public Team GetTeam
        {
            get => this;
            set
            {
                base.Name = value.Name;
                RegistrationNumber = value.RegistrationNumber;
            }
        }
        public new string Name { get => base.Name; set => base.Name = value; }
        public ResearchTeam() : this(exploreTheme: "C#", nameOfOrganization: "CHNU", timeOfExplore: TimeFrame.Year) {}
        public ResearchTeam(string exploreTheme,string nameOfOrganization, TimeFrame timeOfExplore)
        {
            ExploreTheme = exploreTheme;
            Name = nameOfOrganization;
            TimeOfExplore = timeOfExplore;
            Papers = new ArrayList();
            Persons = new ArrayList();
        }
        public void AddPapers(params Paper[] papersList)
        {
            Papers.AddRange(papersList);
        }
        public void AddPerson(params Person[] personsList)
        {
            Persons.AddRange(personsList);
        }
        public bool this[TimeFrame duration] => TimeOfExplore.Equals(duration);
        public override bool Equals(object obj)
        {
                var team = obj as ResearchTeam;
                return team != null &&
                       ExploreTheme == team.ExploreTheme &&
                       RegistrationNumber == team.RegistrationNumber &&
                       TimeOfExplore == team.TimeOfExplore &&
                       Paper.ArrayEquals(Papers, team.Papers);
        }
        public static bool operator ==(ResearchTeam researchTeam1,ResearchTeam researchTeam2)
        {
            if (ReferenceEquals(researchTeam1, researchTeam2))
            {
                return true;
            }
            if (ReferenceEquals(researchTeam1, null))
            {
                return false;
            }
            if (ReferenceEquals(researchTeam2, null))
            {
                return false;
            }
            return researchTeam1.ExploreTheme == researchTeam2.ExploreTheme && 
                   researchTeam1.RegistrationNumber == researchTeam2.RegistrationNumber && 
                   researchTeam1.TimeOfExplore == researchTeam2.TimeOfExplore &&
                   Paper.ArrayEquals(researchTeam1.Papers,researchTeam2.Papers);
        }
        public static bool operator !=(ResearchTeam researchTeam1, ResearchTeam researchTeam2)
        {
            return !(researchTeam1 == researchTeam2);
        }
        public IEnumerable<Paper> GetPublishingInRecentYear(int n)
        {
            if (n < 0)
            {
                yield break;
            }
            
            DateTime now = DateTime.Now;
            DateTime deltaTime = now.AddYears(-n);
            foreach (Paper paper in Papers)
            {
                if (deltaTime < paper.DateOfPublishing)
                {
                    yield return paper;
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<Person> GetEnumerator()
        {
            bool flag;
            foreach (Person person in Persons)
            {
                flag = false;
                foreach (Paper paper in Papers)
                {
                    if (paper.Person == person)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                    yield return person;
            }
        }
        public ResearchTeam ShallowCopy()
        {
            return (ResearchTeam)MemberwiseClone();
        }
        public override object DeepCopy()
        {
            ResearchTeam copy = (ResearchTeam)MemberwiseClone();
            copy.ExploreTheme = String.Copy(ExploreTheme);
            copy.Name = String.Copy(Name);
            copy.TimeOfExplore = TimeOfExplore;
            copy.Papers = GetClonePapers();
            copy.Persons = GetClonePersons();
            return copy;
        }
        private ArrayList GetClonePapers()
        {
            var list = new ArrayList();
            foreach (Paper p in Papers)
            {
                list.Add(p.DeepCopy());
            }
            return list;
        }
        private ArrayList GetClonePersons()
        {
            var list = new ArrayList();
            foreach (Person p in Persons)
            {
                list.Add(p.DeepCopy());
            }
            return list;
        }
        public override int GetHashCode()
        {
            var hashCode = -703031920;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ExploreTheme);
            hashCode = hashCode * -1521134295 + TimeOfExplore.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<ArrayList>.Default.GetHashCode(Papers);
            hashCode = hashCode * -1521134295 + EqualityComparer<ArrayList>.Default.GetHashCode(Persons);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }

        private string GetStringOfPapers()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var p in Papers)
            {
                stringBuilder.Append(p);
            }
            return stringBuilder.ToString();
        }
        private string GetStringOfPersons()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var p in Persons)
            {
                stringBuilder.Append(p);
            }
            return stringBuilder.ToString();
        }
        public override string ToString()
        {
            return $"\nResearch Team: \nexplore theme: {ExploreTheme}\n" +
                   $"\nName of organization: {Name}" +
                   $"\ntime of explore: {TimeOfExplore}\n" +
                   $"Papers: {GetStringOfPapers()}\n" +
                   $"Persons: {GetStringOfPersons()}\n";
        }
        public virtual string ToShortString()
        {
            return $"\nResearch Team: \nexplore theme: {ExploreTheme}\n" +
                   $"\nName of organization: {Name}" +
                   $"time of explore: {TimeOfExplore}\n";
        }
    }
}

