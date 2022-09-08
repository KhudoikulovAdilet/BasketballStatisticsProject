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
        public string Name { get; set; }
        public string MyTeam { get; set; }
        public string OpposingTeam { get; set; }
        public int MyTeamPoints { get; set; }
        public int OpposingTeamPoints { get; set; }
        public int MyPoints { get; set; }

        public virtual ICollection<SaveGames> Savegames { get; set; }

        public TeamGame() { }

        public TeamGame(string name,
            string myteam, 
            string opposingteam, 
            int myteampoints, 
            int opposingteampoints, 
            int mypoints)
        {
            Name = name;
            MyTeam = myteam;
            OpposingTeam = opposingteam;
            MyTeamPoints = myteampoints;
            OpposingTeamPoints = opposingteampoints;
            MyPoints = mypoints;

        }

        public override string ToString()
        {
            return Name;
        }
    }
}