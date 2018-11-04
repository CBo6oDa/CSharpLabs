using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLab1
{
    public class TeamsJournalEntry
    {
        public string NameOfCollection { get; set; }
        public string TypeOfChange { get; set; }
        public int IndexOfElement { get; set; }

        public TeamsJournalEntry(string name, string change, int index)
        {
            NameOfCollection = name;
            TypeOfChange = change;
            IndexOfElement = index;
        }
        public override string ToString()
        {
            return $"\n\nCollection : {NameOfCollection}" +
                   $"\nType of change : {TypeOfChange}" +
                   $"\nIndex of element : {IndexOfElement}\n";
        }
    }
}
