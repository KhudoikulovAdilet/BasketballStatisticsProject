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
        private string mypoints;

        public string TournementName { get; }
        public string MyTeam { get; }
        public string OpposingTeam { get; }
        public int MyTeamPoints { get; }
        public int OpposingTeamPoints { get; }
        public int MyPoints { get; }

        public TeamGame(string tournamnetgame, 
            string myteam, 
            string opposingteam, 
            int myteampoints, 
            int opposingteampoints, 
            int mypoints)
        {
            TournementName = tournamnetgame;
            MyTeam = myteam;
            OpposingTeam = opposingteam;
            MyTeamPoints = myteampoints;
            OpposingTeamPoints = opposingteampoints;
            MyPoints = mypoints;

        }

        public TeamGame(string mypoints)
        {
            this.mypoints = mypoints;
        }

        public override string ToString()
        {
            return TournementName;
        }
    }
}
// ckeck how it works