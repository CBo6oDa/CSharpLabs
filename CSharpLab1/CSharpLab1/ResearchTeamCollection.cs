using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace CSharpLab1.Models
{
    public class ResearchTeamCollection
    {
        public delegate void TeamListHandler(object source, TeamListHandlerEventArgs args);
        public event TeamListHandler ResearchTeamAdded;
        public event TeamListHandler ResearchTeamInserted;

        private List<ResearchTeam> _researchTeams;
        public string NameOfCollection { get; set; }
        public int GetMinInRegistrationNumber
        {
            get
            {
                return ResearchTeams.Select(t => t.RegistrationNumber).Min();
            }
        }
        public List<ResearchTeam> GetTwoYearsLongResearchTeams => (from t in ResearchTeams
                                                                    where t.TimeOfExplore == TimeFrame.TwoYears
                                                                    select t).ToList();
        public List<ResearchTeam> NGroup(int value)
        {
            return (from t in ResearchTeams
                    where t.Persons.Count == value
                    select t).ToList();

        }
        public List<ResearchTeam> ResearchTeams { get => _researchTeams; set => _researchTeams = value; }
        public ResearchTeamCollection() : this(list: new List<ResearchTeam>()){}
        public ResearchTeamCollection(List<ResearchTeam> list){ ResearchTeams = list; }
        public void AddDefaults()
        {
            Person person = new Person("Petro", "Petrovskyi", new DateTime(2001, 11, 2, 12, 0, 0));
            Paper paper = new Paper("Science",person, new DateTime(2020, 11, 2, 12, 0, 0));
            ResearchTeam researchTeam = new ResearchTeam("Nature", "National Geographic", TimeFrame.Long);
            researchTeam.AddPersons(person,new Person());
            researchTeam.AddPapers(paper);
            researchTeam.AddPapers(paper);
            researchTeam.RegistrationNumber = 11;

            ResearchTeams.Add(researchTeam);

            if (ResearchTeamAdded != null)
                ResearchTeamAdded(researchTeam, new TeamListHandlerEventArgs(NameOfCollection, "Added", ResearchTeams.Count - 1));

            person = new Person("Ivan", "Ivanko", new DateTime(2000, 11, 2, 12, 0, 0));
            paper = new Paper("Science CHNU", person, new DateTime(2018, 11, 2, 12, 0, 0));
            researchTeam = new ResearchTeam("C#", "CHNU", TimeFrame.TwoYears);
            researchTeam.AddPersons(person, new Person(), new Person());
            researchTeam.AddPapers(paper);
            researchTeam.RegistrationNumber = 6;
            ResearchTeams.Add(researchTeam);

            ResearchTeamAdded(researchTeam, new TeamListHandlerEventArgs(NameOfCollection, "Added", ResearchTeams.Count - 1));

            person = new Person("Igor", "Kulich", new DateTime(1995, 11, 2, 12, 0, 0));
            paper = new Paper("Science paper CHNU", person, new DateTime(2015, 11, 2, 12, 0, 0));
            researchTeam = new ResearchTeam("Global Problems", "National Organization", TimeFrame.Year);
            researchTeam.AddPersons(person, new Person(), new Person());
            researchTeam.AddPapers(paper);
            researchTeam.RegistrationNumber = 4;
            ResearchTeams.Add(researchTeam);

            ResearchTeamAdded(researchTeam, new TeamListHandlerEventArgs(NameOfCollection, "Added", ResearchTeams.Count - 1));
        }
        public void AddResearchTeams(params ResearchTeam[] teams)
        {
            foreach (var researchTeam in teams)
            {
                ResearchTeams.Add(researchTeam);
                if (ResearchTeamAdded != null)
                    ResearchTeamAdded(researchTeam, new TeamListHandlerEventArgs(NameOfCollection, "Added", ResearchTeams.Count - 1));
            }   
            //ResearchTeams.AddRange(teams);
        }
        public void SortByRegistrationNumber()
        {
            ResearchTeams.Sort();
        }
        public void SortByExploreTheme()
        {
            ResearchTeams.Sort(new ResearchTeam());
        }
        public void SortByCountOfPublishing()
        {
            ResearchTeams.Sort(new ResearchTeamComparer());
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var researchTeam in ResearchTeams)
            {
                stringBuilder.Append(researchTeam);
            }
            return stringBuilder.ToString();
        }
        public virtual string ToShortString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var researchTeam in ResearchTeams)
            {
                stringBuilder.Append(researchTeam.ToShortString());
            }
            return stringBuilder.ToString();
        }
        public void InsertAt(int index, ResearchTeam researchTeam)
        {
            if (researchTeam == null)
                return;

            if (index >= ResearchTeams.Count)
            {
                ResearchTeams.Add(researchTeam);
                if (ResearchTeamAdded != null)
                    ResearchTeamAdded(researchTeam, new TeamListHandlerEventArgs(NameOfCollection, "Added", ResearchTeams.Count - 1));
            }
            else
            {
                ResearchTeams.Insert(index,researchTeam);
                if (ResearchTeamInserted != null)
                    ResearchTeamInserted(researchTeam, new TeamListHandlerEventArgs(NameOfCollection, "Inserted", ResearchTeams.IndexOf(researchTeam, index)));
            }
        }
        public ResearchTeam this[int index]
        {
            get
            {
                return (index >= 0 && index < ResearchTeams.Count)
                    ? ResearchTeams[index]
                    : throw new ArgumentOutOfRangeException($"Index has to be > 0 && index < ResearchTeams.Count");
            }
            set
            {
                ResearchTeams[index] = value;
            }
        }
    }
}
