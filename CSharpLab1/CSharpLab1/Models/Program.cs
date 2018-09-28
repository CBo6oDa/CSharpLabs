using System;
using System.Collections;
using System.Collections.Generic;
using static CSharpLab1.Models.ResearchTeam;

namespace CSharpLab1.Models
{
    public class Program
    {
        private static Paper[][] GetJuggedArray(int n, int m)
        {
            Paper[][] juggedArray = new Paper[n][];
            int count = n * m;
            int lenght = 1;
            for (int i = 0; i < juggedArray.Length; i++)
            {
                if (i == juggedArray.Length - 1 && lenght <= count)
                {
                    juggedArray[i] = new Paper[count];
                }
                else
                {
                    juggedArray[i] = new Paper[lenght];
                }
                count -= lenght;
                lenght++;

                for (int j = 0; j < juggedArray[i].Length; j++)
                {
                    juggedArray[i][j] = new Paper();
                }
            }
            return juggedArray;
        }
        static void Main(string[] args)
        {
            ResearchTeam researchTeam2 = new ResearchTeam();
            ResearchTeam researchTeam3 = (ResearchTeam)researchTeam2.DeepCopy();
            Console.WriteLine(researchTeam2.Persons.GetHashCode());
            Console.WriteLine(researchTeam3.Persons.GetHashCode());


            Team team1 = new Team("Dreem", 2);
            Team team2 = new Team("Dreem", 2);
            if (team1 == team2)
            {
                Console.WriteLine("We are equals!");
            }
            Console.WriteLine(team1.GetHashCode());
            Console.WriteLine(team2.GetHashCode());

            try
            {
                team1.RegistrationNumber = -1;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }

            ArrayList personsList = new ArrayList();
            personsList.Add(new Person());
            ArrayList paperList = new ArrayList();
            paperList.Add(new Paper());

            ResearchTeam researchTeam = new ResearchTeam();
            researchTeam.Persons = personsList;
            researchTeam.Papers = paperList;
            Console.WriteLine(researchTeam);
            Team team = researchTeam.GetTeam;
            Console.WriteLine(team.ToString());

            ResearchTeam researchTeam1 = (ResearchTeam)researchTeam.DeepCopy();
            researchTeam.ExploreTheme = "1";
            researchTeam.Name = "2";
            researchTeam.RegistrationNumber = 3;
            researchTeam.TimeOfExplore = TimeFrame.TwoYears;
            Paper paper = (Paper) researchTeam.Papers[0];
            paper.Title = "123456789";
            paper.Person.YearOfBirth = 2020;
            paper.DateOfPublishing = new DateTime(2020, 10, 25);
            Person p = (Person) researchTeam.Persons[0];
            p.Name = "Oleh";
            p.Surname = "Chornogirskiy";
            p.DateOfBirth = DateTime.Now.AddHours(1);

            Console.WriteLine(researchTeam.ToString());
            Console.WriteLine(researchTeam1.ToString());

            researchTeam1.AddPerson(new Person("Taras","Andrynuk",new DateTime(2000,11,2,12,0,0)));
            researchTeam1.AddPapers(new Paper("c#",new Person(),new DateTime(2000,11,2,12,0,0) ));

            Console.WriteLine("Persons without papers: ");
            foreach (Person pn in researchTeam1)
            {
                Console.WriteLine(pn);
            }

            Console.WriteLine("Latest papers in two years: ");
            foreach (Paper pn in researchTeam1.GetPublishingInRecentYear(2))
            {
                Console.WriteLine(pn);
            }

            Console.WriteLine("Persons with papers: ");
            ResearchTeamEnumerator researchTeamEnumerator = new ResearchTeamEnumerator(researchTeam1.Persons, researchTeam1.Papers);
            var enumerator = researchTeamEnumerator;
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }

            //Console.WriteLine("Persons with more than one paper: ");
            //foreach (Person pn in researchTeamEnumerator.GetPersonsWithMoreThanOnePaper())
            //{
            //    Console.WriteLine(pn);
            //}

            //Console.WriteLine("Persons with papers: ");
            //ResearchTeamEnumerator researchTeamEnumerator = new ResearchTeamEnumerator(researchTeam1.Persons, researchTeam1.Papers);

            //foreach (Person pn in researchTeamEnumerator)
            //{
            //    Console.WriteLine(pn);
            //}

            //Console.WriteLine("Persons with more than one paper: ");
            //foreach (Person pn in researchTeamEnumerator.GetPersonsWithMoreThanOnePaper())
            //{
            //    Console.WriteLine(pn);
            //}


            //var p = new Person();
            //var paper = new Paper();
            //var researchTeam = new ResearchTeam();

            //Console.WriteLine(researchTeam[TimeFrame.TwoYears]);
            //var researchTeam2 = new ResearchTeam("C#","CHNU",TimeFrame.Year);
            //Console.WriteLine(researchTeam2[TimeFrame.Long]);

            //researchTeam.AddPapers(new Paper());
            //Console.WriteLine(researchTeam.GetLastArticle);
            //researchTeam.AddPapers(new Paper("1", new Person(), DateTime.Now));
            //Console.WriteLine(researchTeam.GetLastArticle);
            //Console.WriteLine(researchTeam2.GetLastArticle);

            //Console.WriteLine($"\n{p.DateOfBirth}");
            //p.YearOfBirth = 2020;
            //Console.WriteLine(p.DateOfBirth);

            //Console.WriteLine("\nSize array: (example: 2*3)");
            //string size = Console.ReadLine();
            //int n = Convert.ToInt32(size.Split('*')[0]);
            //int m = Convert.ToInt32(size.Split('*')[1]);


            //var start = DateTime.Now;
            //var papers1 = new Paper[n * m];
            //for (int i = 0; i < papers1.Length; ++i)
            //    papers1[i] = new Paper();
            //TimeSpan duration = DateTime.Now - start;
            //Console.WriteLine($"\nOne-dimensional array: {duration.TotalMilliseconds} ms");

            //start = DateTime.Now;
            //var papers2 = new Paper[n, m];
            //for (int i = 0; i < n; ++i)
            //    for (int j = 0; j < m; ++j)
            //        papers2[i, j] = new Paper();
            //duration = DateTime.Now - start;
            //Console.WriteLine($"Two-dimensional rectangular array: {duration.TotalMilliseconds} ms");

            //DateTime start2 = DateTime.Now;
            //Paper[][] papers3 = GetJuggedArray(n, m);
            //duration = DateTime.Now - start2;
            //Console.WriteLine($"Jugged array: {duration.TotalMilliseconds} ms");

            //Console.WriteLine(p.ToString());
            //Console.WriteLine(paper.ToString());
            //Console.WriteLine(researchTeam.ToString());
            Console.ReadLine();
        }
    }
}
