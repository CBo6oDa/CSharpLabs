using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLab1.Models
{
    public class ResearchTeamComparer : IComparer<ResearchTeam>
    {
        public int Compare(ResearchTeam x, ResearchTeam y)
        {
            //if (ReferenceEquals(x.Papers, y.Papers))
            //    return 0;
            if (ReferenceEquals(x.Papers, null))
                return 1;
            if (ReferenceEquals(y.Papers, null))
                return -1;

            if (x.Papers.Count > y.Papers.Count)
                return 1;
            if (x.Papers.Count < y.Papers.Count)
                return -1;
           
            return 0;
        }
    }
}
