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
        
        public string TournementName { get; set;  }
        public string MyTeam { get; }
        public string OpposingTeam { get; }
        public int MyTeamPoints { get; }
        public int OpposingTeamPoints { get; }
        public int MyPoints { get; }

        public virtual ICollection<SaveGames> Savegames { get; set; }
        public TeamGame() { }

        public TeamGame(string tournamentgname, 
            string myteam, 
            string opposingteam, 
            int myteampoints, 
            int opposingteampoints, 
            int mypoints)
        {
            TournementName = tournamentgname;
            MyTeam = myteam;
            OpposingTeam = opposingteam;
            MyTeamPoints = myteampoints;
            OpposingTeamPoints = opposingteampoints;
            MyPoints = mypoints;

        }

        public override string ToString()
        {
            return TournementName;
        }
    }
}