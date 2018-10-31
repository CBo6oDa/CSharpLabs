using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLab1.Models
{
    public class TestCollections
    {
        public List<Team> Teams { get; set; }
        public List<string> StringList { get; set; }
        public Dictionary<Team, ResearchTeam> TDictionary { get; set; }
        public Dictionary<string, ResearchTeam> SDictionary { get; set; }

        public TestCollections()
        {
            Teams = new List<Team>();
            StringList = new List<string>();
            TDictionary = new Dictionary<Team, ResearchTeam>();
            SDictionary = new Dictionary<string,ResearchTeam>();
        }
        public TestCollections(List<Team> teams, List<string> stringList, Dictionary<Team,ResearchTeam> tDictionary, Dictionary<string, ResearchTeam> sDictionary)
        {
            Teams = teams;
            StringList = stringList;
            TDictionary = tDictionary;
            SDictionary = sDictionary;
        }

        public static void GetResearchTeam(int index)
        {
            const int amount = 5000;
            var researchTeamResult = new ResearchTeam();
            var testCollections = new TestCollections();
            for (var i = 1; i <= amount; i++)
            {
                var researchTeam = new ResearchTeam("Nature " + i, "CHNU " + i, TimeFrame.Year);
                var team = new Team("Fantastic fours" + i, i);
                var teamString = team.ToString();
                testCollections.Teams.Add(team);
                testCollections.StringList.Add(teamString);
                testCollections.TDictionary.Add(team,researchTeam);
                testCollections.SDictionary.Add(teamString,researchTeam);
            }

            var suggestedTeam = new Team("Fantastic fours" + index, index);
            var suggestedResearchTeam = new ResearchTeam("Nature " + index, "CHNU " + index, TimeFrame.Year);

            Console.WriteLine("Suggested team: ");
            Console.WriteLine(suggestedTeam);
            Console.WriteLine("Suggested researchTeam: ");
            Console.WriteLine(suggestedResearchTeam);

            Team resultTeam;
            var start = Environment.TickCount;
            if (testCollections.Teams.Contains(suggestedTeam))
                Console.WriteLine("Teams contain suggested team");
            var end = Environment.TickCount;
            Console.WriteLine("Suggested team in Teams: " + (end - start));

            start = Environment.TickCount;

            if (testCollections.StringList.Contains(suggestedTeam.ToString()))
                Console.WriteLine("StringList contain suggested team");

            end = Environment.TickCount;
            Console.WriteLine("Suggested team in string list: " + (end - start));

            start = Environment.TickCount;
            if (testCollections.TDictionary.ContainsKey(suggestedTeam))
                if (suggestedResearchTeam == testCollections.TDictionary[suggestedTeam])
                    Console.WriteLine("TeamDictionary contains suggested team and dictionary");
            end = Environment.TickCount;
            Console.WriteLine("Dictionary researchTeam find (key): " + (end - start));

            start = Environment.TickCount;
            
            if (testCollections.SDictionary.ContainsKey(suggestedTeam.ToString()))
                if(suggestedResearchTeam == testCollections.SDictionary[suggestedTeam.ToString()])
                    Console.WriteLine("StringDictionary contains suggested team and dictionary");
            end = Environment.TickCount;
            Console.WriteLine("Dictionary researchTeam find (key): " + (end - start));
            
        }

    }
}
