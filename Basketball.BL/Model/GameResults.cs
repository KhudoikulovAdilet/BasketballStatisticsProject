using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.BL.Model
{
    [Serializable]
    public class GameResults
    {
        public int Id { get; set; }
        public PersonalGame TypeOfGame { get; }
        public int MyScore { get; set; }
        public int HisScore { get; set; }
        public virtual PersonalGame PersonalGame { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; }

        public GameResults() { }
        public GameResults(int myscore, int hisscore, User user)
        {
            MyScore = myscore;
            HisScore = hisscore;
            User = user;
        }
    }
}
