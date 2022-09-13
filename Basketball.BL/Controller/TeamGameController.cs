using Basketball.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Basketball.BL.Controller
{
    public class TeamGameController : ControllerBase
    {
        private readonly User user;

        public List<TeamGame> teamGame { get; }

        public List<SaveGames> saveGames { get; }

        public TeamGameController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));

            teamGame = GetAllGames();
            saveGames = GetGames();
        }

        public void Add(SaveGames Savegames, string ourteam, string opponentteam, int ourpoints, int theirpoints, int mypoints)
        {
            var turnir = saveGames.SingleOrDefault(t => t.Name == Savegames.Name);
            if (turnir == null)
            {
                saveGames.Add(Savegames);

                var igra = new TeamGame(ourteam, opponentteam, ourpoints, theirpoints, mypoints, user);
                teamGame.Add(igra);
            }
            else
            {
                var igra = new TeamGame(ourteam, opponentteam, ourpoints, theirpoints, mypoints, user);
                teamGame.Add(igra);
            }
            Save();
        }

        private List<SaveGames> GetGames()
        {
            return Load<SaveGames>() ?? new List<SaveGames>();
        }

        private List<TeamGame> GetAllGames()
        {
            return Load<TeamGame>() ?? new List<TeamGame>() ;
        }
        public void Save()
        {
            Save(saveGames);
            Save(teamGame);
            Save(new List<SaveGames>() {});
        }
    }
   }
