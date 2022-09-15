using System;
using System.Collections.Generic;
using System.Linq;

namespace Basketball.BL.Model
{
    [Serializable]
    public class SaveGames
    {
        public int Id { get; set; }
        public string Name { get; }
        public int UserID { get; set; }
        public virtual User User { get; set; }

        public SaveGames() { }


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
