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
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<GameResults> GameResults { get; set; }
        public PersonalGame() { }

        public PersonalGame(string name)
        {
            Name = name;
        }
         
        public override string ToString()
        {
            return Name;
        }
    }
}
