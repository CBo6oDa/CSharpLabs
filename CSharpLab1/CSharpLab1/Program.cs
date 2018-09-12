using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Person();
            var paper = new Paper();
            var researchTeam = new ResearchTeam();

            Console.WriteLine(researchTeam[TimeFrame.TwoYears]);
            var researchTeam2 = new ResearchTeam("Nature", "National Geographic", 2, TimeFrame.Long, null);
            Console.WriteLine(researchTeam2[TimeFrame.Long]);
            try
            {
                researchTeam.AddPapers(new Paper());
                Console.WriteLine(researchTeam.GetLastArticle);
                researchTeam.AddPapers(new Paper("1", new Person(), DateTime.Now));
                Console.WriteLine(researchTeam.GetLastArticle);
                Console.WriteLine(researchTeam2.GetLastArticle);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("null");
            }

            Console.WriteLine("\n"+p.DateOfBirth);
            p.YearOfBirth = 2020;
            Console.WriteLine(p.DateOfBirth);

            Console.WriteLine("\nSize array: (example: 2*3)");
            string size = Console.ReadLine();
            int n = Convert.ToInt32(size.Split('*')[0]);
            int m = Convert.ToInt32(size.Split('*')[1]);


            DateTime start = DateTime.Now;
            Paper[] papers1 = new Paper[n * m];
            for (int i = 0; i < papers1.Length; ++i)
                papers1[i] = new Paper();
            TimeSpan duration = DateTime.Now - start;
            Console.WriteLine($"\nOne-dimensional array: {duration.TotalMilliseconds} ms");

            Paper[,] papers2 = new Paper[n, m];
            start = DateTime.Now;
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < m; ++j)
                    papers2[i, j] = new Paper();
            duration = DateTime.Now - start;
            Console.WriteLine($"Two-dimensional rectangular array: {duration.TotalMilliseconds} ms");
            
            DateTime star2 = DateTime.Now;
            Paper[][] papers3 = GetJuggedArray(n,m);
            duration = DateTime.Now - star2;
            Console.WriteLine($"Jugged array: {duration.TotalMilliseconds} ms");

            Console.WriteLine(p.ToString());
            Console.WriteLine(paper.ToString());
            Console.WriteLine(researchTeam.ToString());
            Console.ReadLine();
        }

        private static Paper[][] GetJuggedArray(int n,int m)
        {
            Random rnd = new Random();
            List<Paper[]> list = new List<Paper[]>();
            Paper[] papers;
            int length;
            int countOfElements = n * m;
            while (countOfElements > 0)
            {
                length = rnd.Next(1, countOfElements + 1);
                papers = new Paper[length];
                countOfElements -= length;
                for (int i = 0; i < length; i++)
                {
                    papers[i] = new Paper();
                }
                list.Add(papers);
            }

            Paper[][] juggedArray = new Paper[list.Count][];
            for (int i = 0; i < list.Count; i++)
            {
                juggedArray[i] = list.ElementAt(i);
            }
            return juggedArray;
        }
    }
}
