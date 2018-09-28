using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace CSharpLab1.Models
{
    public class ResearchTeamEnumerator : IEnumerator
    {
        public int CurrentIndex { get; set; } = -1;
        public ArrayList Persons { get; set; }
        public ArrayList Papers { get; set; }
        public ResearchTeamEnumerator(ArrayList papers, ArrayList persons)
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
