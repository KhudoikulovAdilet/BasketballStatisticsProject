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
        public PersonalGame TypeOfGame { get; }
        public int MyScore { get; }
        public int HisScore { get; }

        public User User { get; }

        public GameResults(int myscore, int hisscore, User user)
        {
            MyScore = myscore;
            HisScore = hisscore;
            User = user;
        }
    }
}
