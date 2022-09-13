using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.BL.Model
{
    [Serializable]
    public class TeamGame
    {
        public string MyTeam { get; }
        public string OpposingTeam { get; set; }
        public int OpposingTeamPoints { get; set; }
        public int MyTeamPoints { get; set; }
        public int MyPoint { get; }

        public User User { get; set; }

        public TeamGame(string myteam,
            string opposingteam, 
            int opposingteampoints, 
            int myteampoints,
            int mypoint,
            User user) 
        {
            MyTeam = myteam;
            OpposingTeam = opposingteam;
            MyTeamPoints = myteampoints;
            OpposingTeamPoints = opposingteampoints;
            MyPoint = mypoint;
            User = user;
        }
    }
}