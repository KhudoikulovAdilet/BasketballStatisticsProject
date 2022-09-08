using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.BL.Model
{
    [Serializable]
    public class PersonalGame
    {
        public string Name { get; }
        public string FinRez { get; }

        public PersonalGame(string name, string finrez)
        {
            Name = name;
            FinRez = finrez;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
