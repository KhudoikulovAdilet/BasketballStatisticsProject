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

        public Dictionary<TeamGame, string> Teamgames { get; set; }

        public virtual User User { get; }

        public SaveGames() { }

        public SaveGames(User user)
        {
            User = user ?? throw new ArgumentNullException("user don't null", nameof(user));
            Moment = DateTime.UtcNow;
            Teamgames = new Dictionary<TeamGame, string>();
        }
        public void Add(TeamGame teamgame, string name)
        {
            var tournament = Teamgames.Keys.FirstOrDefault(t => t.Name.Equals(teamgame.Name));

            if(tournament == null)
            {
                Teamgames.Add(teamgame, name);
            }
            else
            {
                Teamgames[tournament]+= name;
            }
        }
    }
}
