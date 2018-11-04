using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpLab1.Models;

namespace CSharpLab1
{
    public class TeamsJournal
    {
        public string NameOfJournal { get; set; }
        public TeamsJournal() : this(journal:new List<TeamsJournalEntry>()) { }
        public TeamsJournal(List<TeamsJournalEntry> journal)
        {
            Journal = journal;
        }

        public List<TeamsJournalEntry> Journal { get; set; }
        public event ResearchTeamCollection.TeamListHandler ResearchTeamAdded;
        public event ResearchTeamCollection.TeamListHandler ResearchTeamInserted;

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Journal: " + NameOfJournal);
            foreach (var entry in Journal)
            {
                stringBuilder.Append(entry);
            }

            return stringBuilder.ToString();
        }
    }
}
