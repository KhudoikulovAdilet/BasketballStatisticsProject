using System;
using System.Collections.Generic;

namespace Basketball.BL.Model
{
    [Serializable]
    public class SaveGames
    {
        public DateTime GameDate { get; }
        public DateTime Moment { get; }

        public List<TeamGame> Savegame { get; }

        public User User { get; }

        public SaveGames(User user)
        {
            User = user ?? throw new ArgumentNullException("user don't null", nameof(user));
            Moment = DateTime.Now;
            Savegame = new List<TeamGame>();
        }
        public void Add(TeamGame teamgame)
        {
            Savegame.Add(teamgame);
        }
    }
}
