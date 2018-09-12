using System;
using System.Collections.Generic;

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
            get { return (Papers.Length != 0) ? Papers[Papers.Length - 1] : throw new NullReferenceException(); }
        }
        public bool this[TimeFrame duration] => TimeOfExplore.Equals(duration);
        public ResearchTeam()
        {
            _exploreTheme = "C#";
            _organization = "IT";
            _registrationNumber = 1;
            _timeOfExplore = TimeFrame.Year;
            _papers = new Paper[] { new Paper("Test", new Person(), DateTime.Now) };
        }
        public ResearchTeam(string exploreTheme, string organization, int registrationNumber, TimeFrame timeOfExplore, Paper[] papersList)
        {
            _exploreTheme = exploreTheme;
            _organization = organization;
            _registrationNumber = registrationNumber;
            _timeOfExplore = timeOfExplore;
            _papers = papersList;
        }

        public void AddPapers(params Paper[] papersList)
        {
            List<Paper> list = new List<Paper>();
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
            String list = "";
            foreach (var p in Papers)
            {
                list += p.ToString();
            }
            return list;
        }
    }
}
