using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace CSharpLab1.Models
{
    public class ResearchTeamEnumerator : IEnumerator
    {
        public int CurrentIndex { get; set; } = -1;
        public List<Person> Persons { get; set; }
        public List<Paper> Papers { get; set; }
        public ResearchTeamEnumerator(List<Person> persons, List<Paper> papers)
        {
            Persons = persons;
            Papers = papers;
        }
        public bool MoveNext()
        {
            CurrentIndex++;
            return (CurrentIndex < Persons.Count);
        }
        public object Current
        {
            get
            {
                try
                {
                    return Persons[CurrentIndex];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public void Reset()
        {
            CurrentIndex = -1;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
