using System;
using System.Collections.Generic;
using System.Linq;

namespace Basketball.BL.Model
{
    [Serializable]
    public class SaveGames
    {
        public string Name { get; }
       
        public SaveGames(string name)
        { 
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
