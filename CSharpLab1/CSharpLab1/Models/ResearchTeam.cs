using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;

namespace CSharpLab1.Models
{
    [DataContract]
    public class ResearchTeam : Team, IEnumerable,IComparer<ResearchTeam>
    {
        [DataMember]
        public string ExploreTheme { get; set; }
        [DataMember]
        public TimeFrame TimeOfExplore { get; set; }
        [DataMember]
        public List<Person> Persons { get; set; }
        [DataMember]
        public List<Paper> Papers { get; set; }
        public Paper GetLastArticle => Papers?[Papers.Count - 1];
        public Team GetTeam
        {
            get => this;
            set
            {
                base.Name = value.Name;
                RegistrationNumber = value.RegistrationNumber;
            }
        }
        [DataMember]
        public new string Name { get => base.Name; set => base.Name = value; }
        public ResearchTeam() : this(exploreTheme: "C#", nameOfOrganization: "CHNU", timeOfExplore: TimeFrame.Year) {}
        public ResearchTeam(string exploreTheme,string nameOfOrganization, TimeFrame timeOfExplore)
        {
            ExploreTheme = exploreTheme;
            Name = nameOfOrganization;
            TimeOfExplore = timeOfExplore;
            Papers = new List<Paper>();
            Persons = new List<Person>();
        }

        public void AddPapers(params Paper[] papersList)
        {
            Papers.AddRange(papersList);
        }
        public void AddPersons(params Person[] personsList)
        {
            Persons.AddRange(personsList);
        }
        public bool this[TimeFrame duration] => TimeOfExplore.Equals(duration);
        public override bool Equals(object obj)
        {
                var team = obj as ResearchTeam;
                return team != null &&
                       ExploreTheme == team.ExploreTheme &&
                       RegistrationNumber == team.RegistrationNumber &&
                       TimeOfExplore == team.TimeOfExplore &&
                       Paper.ArrayEquals(Papers, team.Papers);
        }
        public static bool operator ==(ResearchTeam researchTeam1,ResearchTeam researchTeam2)
        {
            if (ReferenceEquals(researchTeam1, researchTeam2))
            {
                return true;
            }
            if (ReferenceEquals(researchTeam1, null))
            {
                return false;
            }
            if (ReferenceEquals(researchTeam2, null))
            {
                return false;
            }
            return researchTeam1.ExploreTheme == researchTeam2.ExploreTheme && 
                   researchTeam1.RegistrationNumber == researchTeam2.RegistrationNumber && 
                   researchTeam1.TimeOfExplore == researchTeam2.TimeOfExplore &&
                   Paper.ArrayEquals(researchTeam1.Papers,researchTeam2.Papers);
        }
        public static bool operator !=(ResearchTeam researchTeam1, ResearchTeam researchTeam2)
        {
            return !(researchTeam1 == researchTeam2);
        }

        public IEnumerable<Paper> GetPublishingInRecentYear(int n)
        {
            if (n < 0)
            {
                yield break;
            }
            
            DateTime now = DateTime.Now;
            DateTime deltaTime = now.AddYears(-n);
            foreach (Paper paper in Papers)
            {
                if (deltaTime < paper.DateOfPublishing)
                {
                    yield return paper;
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<Person> GetEnumerator()
        {
            bool flag;
            foreach (Person person in Persons)
            {
                flag = false;
                foreach (Paper paper in Papers)
                {
                    if (paper.Person == person)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                    yield return person;
            }
        }
        public ResearchTeam ShallowCopy()
        {
            return (ResearchTeam)MemberwiseClone();
        }
        public override object DeepCopy()
        {
            ResearchTeam copy = (ResearchTeam)MemberwiseClone();
            copy.ExploreTheme = String.Copy(ExploreTheme);
            copy.Name = String.Copy(Name);
            copy.TimeOfExplore = TimeOfExplore;
            copy.Papers = GetClonePapers();
            copy.Persons = GetClonePersons();
            return copy;
        }
        private List<Paper> GetClonePapers()
        {
            var list = new List<Paper>();
            foreach (Paper p in Papers)
            {
                list.Add(p.DeepCopy());
            }
            return list;
        }
        private List<Person> GetClonePersons()
        {
            var list = new List<Person>();
            foreach (Person p in Persons)
            {
                list.Add(p.DeepCopy());
            }
            return list;
        }
        public override int GetHashCode()
        {
            var hashCode = -703031920;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ExploreTheme);
            hashCode = hashCode * -1521134295 + TimeOfExplore.GetHashCode();
            hashCode = (int) (hashCode * -1521134295 + GetHashCodePapers());
            hashCode = (int) (hashCode * -1521134295 + GetHashCodePersons());
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
        private long GetHashCodePapers()
        {
            long lg = 0;
            foreach (Paper paper in Papers)
            {
                lg += paper.GetHashCode();
            }
            return lg;
        }
        private long GetHashCodePersons()
        {
            long lg = 0;
            foreach (Person person in Persons)
            {
                lg += person.GetHashCode();
            }
            return lg;
        }

        public int Compare(ResearchTeam x, ResearchTeam y)
        {
            if (x.ExploreTheme.Length > y.ExploreTheme.Length)
                return 1;
            if (x.ExploreTheme.Length < y.ExploreTheme.Length)
                return -1;
            
            return 0;  
        }
        public override string ToString()
        {
            return $"\nResearch Team: \nexplore theme: {ExploreTheme}\n" +
                   $"\nName of organization: {Name}" +
                   $"\ntime of explore: {TimeOfExplore}\n" +
                   $"Papers: {GetStringOfPapers()}\n" +
                   $"Persons: {GetStringOfPersons()}\n";
        }
        private string GetStringOfPapers()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var p in Papers)
            {
                stringBuilder.Append(p);
            }
            return stringBuilder.ToString();
        }
        private string GetStringOfPersons()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var p in Persons)
            {
                stringBuilder.Append(p);
            }
            return stringBuilder.ToString();
        }
        public virtual string ToShortString()
        {
            return $"\nResearch Team: \nexplore theme: {ExploreTheme}\n" +
                   $"\nName of organization: {Name}\n" +
                   $"time of explore: {TimeOfExplore}\n" +
                   $"Number of publishing: {Papers.Count}\n" +
                   $"Number of participants: {Persons.Count}";
        }
        public void Add(object o)
        {
            if (o as Paper != null)
            {
                Papers.Add(o as Paper);
            }
            else if (o as Person != null)
            {
                Persons.Add((o as Person));
            }
        }
        public static T DeepCopy<T>(object obj) where T : class
        {
            T serialisedObject = obj as T;
            if (serialisedObject != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
                    try
                    {
                        ser.WriteObject(ms, serialisedObject);
                        ms.Position = 0;
                        return ser.ReadObject(ms) as T;
                    }
                    catch (InvalidDataContractException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (SerializationException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    finally
                    {
                        ms.Close();
                    }
                }
            }
            throw new ArgumentException($"I cannot convert { nameof(serialisedObject) } to ResearchTeam");
        }

        public bool Save(string fileName)
        {
            string fileLocation = @"D:\";
            string fileFormat = ".txt";

            ResearchTeam researchTeam = new ResearchTeam(ExploreTheme, Name, TimeOfExplore);
            researchTeam.Papers = Papers;
            researchTeam.Persons = Persons;

            MemoryStream ms = new MemoryStream();
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ResearchTeam));
                ser.WriteObject(ms, researchTeam);
                byte[] json = ms.ToArray();

                var objectToJson = Encoding.UTF8.GetString(json, 0, json.Length);
                FileStream fstream = new FileStream(fileLocation + fileName + fileFormat, FileMode.OpenOrCreate);
                fstream.SetLength(0);
                byte[] array = Encoding.Default.GetBytes(objectToJson);
                fstream.Write(array, 0, array.Length);
                fstream.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                ms.Close();
            }
            return false;
        }

        public bool Load(string fileName)
        {
            string fileLocation = @"D:\";
            string fileFormat = ".txt";

            try
            {
                using (FileStream fstream = File.OpenRead(fileLocation + fileName + fileFormat))
                {
                    byte[] array = new byte[fstream.Length];
                    fstream.Read(array, 0, array.Length);
                    string json = Encoding.Default.GetString(array);

                    MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
                    ResearchTeam deserializedTeam = new ResearchTeam();
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedTeam.GetType());
                    deserializedTeam = ser.ReadObject(ms) as ResearchTeam;

                    Name = deserializedTeam.Name;
                    ExploreTheme = deserializedTeam.ExploreTheme;
                    TimeOfExplore = deserializedTeam.TimeOfExplore;
                    RegistrationNumber = deserializedTeam.RegistrationNumber;
                    Papers = deserializedTeam.Papers;
                    Persons = deserializedTeam.Persons;

                    ms.Close();
                    fstream.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public static bool Load(string fileName, ResearchTeam researchTeam)
        {
            string fileLocation = @"D:\";
            string fileFormat = ".txt";

            try
            {
                using (FileStream fstream = File.OpenRead(fileLocation + fileName + fileFormat))
                {
                    byte[] array = new byte[fstream.Length];
                    fstream.Read(array, 0, array.Length);
                    string json = Encoding.Default.GetString(array);

                    MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
                    ResearchTeam deserializedTeam = new ResearchTeam();
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedTeam.GetType());
                    deserializedTeam = ser.ReadObject(ms) as ResearchTeam;

                    researchTeam.Name = deserializedTeam.Name;
                    researchTeam.ExploreTheme = deserializedTeam.ExploreTheme;
                    researchTeam.TimeOfExplore = deserializedTeam.TimeOfExplore;
                    researchTeam.RegistrationNumber = deserializedTeam.RegistrationNumber;
                    researchTeam.Papers = deserializedTeam.Papers;
                    researchTeam.Persons = deserializedTeam.Persons;

                    ms.Close();
                    fstream.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public static bool Save(string fileName, ResearchTeam saveResearchTeam)
        {
            string fileLocation = @"D:\";
            string fileFormat = ".txt";

            ResearchTeam researchTeam = new ResearchTeam(saveResearchTeam.ExploreTheme, saveResearchTeam.Name, saveResearchTeam.TimeOfExplore);
            researchTeam.Papers = saveResearchTeam.Papers;
            researchTeam.Persons = saveResearchTeam.Persons;

            MemoryStream ms = new MemoryStream();
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ResearchTeam));
                ser.WriteObject(ms, researchTeam);
                byte[] json = ms.ToArray();

                var objectToJson = Encoding.UTF8.GetString(json, 0, json.Length);
                FileStream fstream = new FileStream(fileLocation + fileName + fileFormat, FileMode.OpenOrCreate);
                fstream.SetLength(0);
                byte[] array = Encoding.Default.GetBytes(objectToJson);
                fstream.Write(array, 0, array.Length);
                fstream.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                ms.Close();
            }
            return false;
        }

        public bool AddPaperFromConsole()
        {
            Console.WriteLine("Введiть данi для об'єкту Paper наступного формату: " +
                              "назва публiкацiї;дата публiкацiї;Автор: iм'я;прiзвище;дата народження(формат: YYYY:MM:DD)\n" +
                              "Приклад: C# tutorial;2018-01-11;James;Bay;1990-04-23");

            Person person = new Person();
            Paper paper = new Paper();
            var input = Console.ReadLine();
            string[] splitedString = new string[]{""};

            if (input != null)
            {
                splitedString = input.Split(';');
            }

            try
            {
                paper.Title = splitedString[0];
                var yearOfPublishing = int.Parse(splitedString[1].Split('-')[0]);
                var monthOfPublishing = int.Parse(splitedString[1].Split('-')[1]);
                var dayOfPublishing = int.Parse(splitedString[1].Split('-')[2]);
                paper.DateOfPublishing = new DateTime(yearOfPublishing, monthOfPublishing, dayOfPublishing);
               
                person.Name = splitedString[2];
                person.Surname = splitedString[3];
                var yearOfBirth = int.Parse(splitedString[4].Split('-')[0]);
                var monthOfBirth = int.Parse(splitedString[4].Split('-')[1]);
                var dayOfBirth = int.Parse(splitedString[4].Split('-')[2]);
                person.DateOfBirth = new DateTime(yearOfBirth, monthOfBirth, dayOfBirth);
                paper.Person = person;
                Papers.Add(paper);
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }
    }
}

