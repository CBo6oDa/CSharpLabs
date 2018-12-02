using System;
using CSharpLab1.ReflectionTask;
using CSharpLab1.ReflectionTask.Models;

namespace CSharpLab1.Models
{
    public class Program
    {
        #region Lab1
        //private static Paper[][] GetJuggedArray(int n, int m)
        //{
        //    Paper[][] juggedArray = new Paper[n][];
        //    int count = n * m;
        //    int lenght = 1;
        //    for (int i = 0; i < juggedArray.Length; i++)
        //    {
        //        if (i == juggedArray.Length - 1 && lenght <= count)
        //        {
        //            juggedArray[i] = new Paper[count];
        //        }
        //        else
        //        {
        //            juggedArray[i] = new Paper[lenght];
        //        }
        //        count -= lenght;
        //        lenght++;

        //        for (int j = 0; j < juggedArray[i].Length; j++)
        //        {
        //            juggedArray[i][j] = new Paper();
        //        }
        //    }
        //    return juggedArray;
        //}
        #endregion
        #region  Lab4

        //public static TeamsJournal teamsJournal1 { get; set; }
        //public static TeamsJournal teamsJournal2 { get; set; }
        //public static void Show_Message(object source, TeamListHandlerEventArgs args)
        //{
        //    TeamsJournalEntry teamsJournalEntry = new TeamsJournalEntry(name: args.NameOfCollection, change: args.TypeOfChange, index: args.IndexOfElement);

        //    if (teamsJournalEntry.NameOfCollection == "researchTeam1")
        //    {
        //        teamsJournal1.Journal.Add(teamsJournalEntry);
        //    }
        //    teamsJournal2.Journal.Add(teamsJournalEntry);

        //    Console.WriteLine(args.ToString());
        //}
        #endregion
        #region Lab6
        
        #endregion
        public static void Main(string[] args)
        {
            #region Lab6
            ConsoleKey readKey;
            DateTime dateTime = DateTime.Now;
            if (dateTime.DayOfWeek != DayOfWeek.Sunday)
            {
                Human human = new Human();
                Human[] humans = {new Student(), new Botan(), new Girl(), new PrettyGirl(), new SmartGirl()};
                do
                {
                    Console.WriteLine("<-----------------------------------------------");
                    Random random = new Random();
                    var firstIndex = random.Next(humans.Length);
                    var secondIndex = random.Next(humans.Length);

                    Console.WriteLine("First instance: " + humans[firstIndex].GetType().Name);
                    Console.WriteLine("Second instance: " + humans[secondIndex].GetType().Name + "\n");
                    try
                    {
                        Human.ValidateCouple(humans[firstIndex], humans[secondIndex]);
                    }
                    catch (InvalidCoupleArguments e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    var child = human.Couple(humans[firstIndex], humans[secondIndex]);

                    Console.WriteLine("\nName: " + child.GetType().GetProperty("Name")?.GetValue(child));
                    Console.WriteLine("Surname: " + child.GetType().GetProperty("Surname")?.GetValue(child));
                    Console.WriteLine("ChildType: " + child);
                    Console.WriteLine("----------------------------------------------->");
                    readKey = Console.ReadKey(false).Key;
                } while (readKey != ConsoleKey.F10 && readKey != ConsoleKey.Q && readKey.ToString() != "q");
            }
            else
            {
                Console.WriteLine("Сьогоднi ми не працюємо! Вихiдний!!!");
            }

            #endregion
            #region Lab5

            //ResearchTeam researchTeam = new ResearchTeam();
            //Paper paper = new Paper();
            //Person person = new Person("PERSON","SURNAME",new DateTime(2018,11,12));

            //researchTeam.AddPersons(person);
            //researchTeam.AddPersons(person);
            //researchTeam.AddPapers(paper);

            //var deepCopy = DeepCopy<ResearchTeam>(researchTeam);

            //researchTeam.Name = "a";
            //Console.WriteLine(researchTeam.Name);
            //Console.WriteLine(deepCopy.Name);

            //if (researchTeam.Save("TEST"))
            //{
            //    Console.WriteLine("File is Saved");
            //}
            //ResearchTeam loadedObject = new ResearchTeam();
            //if (loadedObject.Load("TEST"))
            //{
            //    Console.WriteLine("File is Readed");
            //}

            //ResearchTeam researchTeamStatic = new ResearchTeam();
            //ResearchTeam.Load("TEST",researchTeamStatic);
            //Console.WriteLine(researchTeamStatic);
            //ResearchTeam.Save("TEST2", deepCopy);

            //researchTeam.AddPaperFromConsole();
            //researchTeam.Save("TEST2");
            #endregion
            #region lab4
            //ResearchTeamCollection researchTeam1 = new ResearchTeamCollection();
            //ResearchTeamCollection researchTeam2 = new ResearchTeamCollection();
            //teamsJournal1 = new TeamsJournal();
            //teamsJournal2 = new TeamsJournal();

            //teamsJournal1.NameOfJournal = nameof(teamsJournal1);
            //teamsJournal2.NameOfJournal = nameof(teamsJournal2);
            //researchTeam1.NameOfCollection = nameof(researchTeam1);
            //researchTeam2.NameOfCollection = nameof(researchTeam2);

            //researchTeam1.ResearchTeamAdded += Show_Message;
            //researchTeam1.ResearchTeamInserted += Show_Message;
            //researchTeam2.ResearchTeamAdded += Show_Message;
            //researchTeam2.ResearchTeamInserted += Show_Message;

            //researchTeam1.InsertAt(0, new ResearchTeam());
            //researchTeam1.InsertAt(0, new ResearchTeam());
            //researchTeam2.InsertAt(0, new ResearchTeam());
            //researchTeam2.InsertAt(1, new ResearchTeam());
            //researchTeam2.InsertAt(1, new ResearchTeam());
            //researchTeam2.InsertAt(3, new ResearchTeam());
            //researchTeam2.InsertAt(4, new ResearchTeam());
            //researchTeam2.InsertAt(6, new ResearchTeam());

            //Console.WriteLine("\n" + teamsJournal1);
            //Console.WriteLine(teamsJournal2.ToString());
            #endregion
            #region lab3
            // LAB3 
            //ResearchTeamCollection researchTeam = new ResearchTeamCollection();
            //researchTeam.AddDefaults();
            //researchTeam.SortByCountOfPublishing();
            //TestCollections.GetResearchTeam(10);

            //Console.WriteLine();
            //Console.ReadLine();
            #endregion
            #region lab2
            //LAB2

            //ResearchTeam researchTeam2 = new ResearchTeam();
            //ResearchTeam researchTeam3 = (ResearchTeam)researchTeam2.DeepCopy();
            //Console.WriteLine(researchTeam2.GetHashCode());
            //Console.WriteLine(researchTeam3.GetHashCode());

            //Team team1 = new Team("Dreem", 2);
            //Team team2 = new Team("Dreem", 2);
            //if (team1 == team2)
            //{
            //    Console.WriteLine("We are equals!");
            //}
            //Console.WriteLine(team1.GetHashCode());
            //Console.WriteLine(team2.GetHashCode());

            //try
            //{
            //    team1.RegistrationNumber = -1;
            //}
            //catch (ArgumentNullException e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            //List<Person> personsList = new List<Person>();
            //personsList.Add(new Person());
            //List<Paper> paperList = new List<Paper>();
            //paperList.Add(new Paper());

            //ResearchTeam researchTeam = new ResearchTeam();
            //researchTeam.Persons = personsList;
            //researchTeam.Papers = paperList;
            //Console.WriteLine(researchTeam);
            //Team team = researchTeam.GetTeam;
            //Console.WriteLine(team.ToString());

            //ResearchTeam researchTeam1 = (ResearchTeam)researchTeam.DeepCopy();
            //researchTeam.ExploreTheme = "1";
            //researchTeam.Name = "2";
            //researchTeam.RegistrationNumber = 3;
            //researchTeam.TimeOfExplore = TimeFrame.TwoYears;
            //Paper paper = (Paper) researchTeam.Papers[0];
            //paper.Title = "123456789";
            //paper.Person.YearOfBirth = 2020;
            //paper.DateOfPublishing = new DateTime(2020, 10, 25);
            //Person p = (Person) researchTeam.Persons[0];
            //p.Name = "Oleh";
            //p.Surname = "Chornogirskiy";
            //p.DateOfBirth = DateTime.Now.AddHours(1);

            //Console.WriteLine(researchTeam.ToString());
            //Console.WriteLine(researchTeam1.ToString());

            //researchTeam1.AddPerson(new Person("Taras","Andrynuk",new DateTime(2000,11,2,12,0,0)));
            //researchTeam1.AddPapers(new Paper("c#",new Person(),new DateTime(2000,11,2,12,0,0) ));

            //Console.WriteLine("Persons without papers: ");
            //foreach (Person pn in researchTeam1)
            //{
            //    Console.WriteLine(pn);
            //}

            //Console.WriteLine("Latest papers in two years: ");
            //foreach (Paper pn in researchTeam1.GetPublishingInRecentYear(2))
            //{
            //    Console.WriteLine(pn);
            //}

            //Console.WriteLine("Persons with papers: ");
            //ResearchTeamEnumerator researchTeamEnumerator = new ResearchTeamEnumerator(researchTeam1.Persons, researchTeam1.Papers);
            //var enumerator = researchTeamEnumerator;
            //while (enumerator.MoveNext())
            //{
            //    Console.WriteLine(enumerator.Current);
            //}
            #endregion
            #region lab1
            //LAB1

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
            #endregion

            Console.ReadLine();
        }
    }
}
