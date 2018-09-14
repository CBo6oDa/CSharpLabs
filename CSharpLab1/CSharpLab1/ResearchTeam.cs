using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpLab1
{
    public class ResearchTeam
    {
        private string _exploreTheme;
        private string _organization;
        private int _registrationNumber;
        private TimeFrame _timeOfExplore;
        private Paper[] _papers;

        public string ExploreTheme { get { return _exploreTheme; } set { _exploreTheme = value; } }
        public string Organization { get { return _organization; } set { _organization = value; } }
        public int RegistrationNumber { get { return _registrationNumber; } set { _registrationNumber = value; } }
        public TimeFrame TimeOfExplore { get { return _timeOfExplore; } set { _timeOfExplore = value; } }
        public Paper[] Papers { get { return _papers; } set { _papers = value; } }
        public Paper GetLastArticle
        {
            get => Papers?[Papers.Length - 1];
        }
        public bool this[TimeFrame duration] => TimeOfExplore.Equals(duration);
        public ResearchTeam() : this(exploreTheme: "C#", organization: "IT", registrationNumber: 1, timeOfExplore: TimeFrame.Year, papersList: new Paper[] { new Paper("Test", new Person(), DateTime.Now) }) { }
        public ResearchTeam(string exploreTheme, string organization, int registrationNumber, TimeFrame timeOfExplore, Paper[] papersList)
        {
            ExploreTheme = exploreTheme;
            Organization = organization;
            RegistrationNumber = registrationNumber;
            TimeOfExplore = timeOfExplore;
            Papers = papersList;
        }
        public void AddPapers(params Paper[] papersList)
        {
            var list = new List<Paper>();
            list.AddRange(Papers);
            list.AddRange(papersList);
            Papers = list.ToArray();
        }

        public override string ToString()
        {
            return $"\nResearch Team: \nexplore theme: {ExploreTheme}\norganization: {Organization}\nregistration number: {RegistrationNumber}\ntime of explore: {TimeOfExplore}\nPapers: {GetStringOfPapers()}\n";
        }

        public virtual string ToShortString()
        {
            return $"\nResearch Team: \nexplore theme: {ExploreTheme}\norganization: {Organization}\nregistration number: {RegistrationNumber}\ntime of explore: {TimeOfExplore}\n";
        }

        private string GetStringOfPapers()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var p in Papers)
            {
                stringBuilder.Append(p.ToString());
            }
            return stringBuilder.ToString();
        }
    }
}
