using System;
using System.Collections.Generic;
using System.Linq;

namespace Basketball.BL.Model
{
    [Serializable]
    public class SaveGames
    {
        public DateTime GameDate { get; }
        public DateTime Moment { get; }

        public Dictionary<TeamGame, string> Savegame { get; set; }

        public User User { get; }

        public SaveGames(User user)
        {
            User = user ?? throw new ArgumentNullException("user don't null", nameof(user));
            Moment = DateTime.Now;
            Savegame = new Dictionary<TeamGame, string>();
        }
        public void Add(TeamGame teamgame, string myteam)
        {
            var tournament = Savegame.Keys.FirstOrDefault(t => t.MyTeam.Equals(myteam));

            if(tournament == null)
            {
                Savegame.Add(teamgame, myteam);
            }
            else
            {
                Savegame[tournament]+= myteam;
            }
        }
    }
}
