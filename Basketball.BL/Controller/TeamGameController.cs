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

        private const string GAMES_FILE_NAME = "games.dat";

        public List<TeamGame> Teamgames { get; }

        public SaveGames saveGames { get; }

        public TeamGameController(User user)
        {
            this .user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым.", nameof (user));
            Teamgames = GetAllGames();
            saveGames = GetGames();

        }

        public void Add(TeamGame Teamgame, string myteam)
        {
            var tournament = Teamgames.SingleOrDefault(t => t.TournementName == Teamgame.TournementName);
            if (tournament == null)
            {
                Teamgames.Add(tournament);
                saveGames.Add(tournament, myteam);
                Save();
            }
            else
            {
                saveGames.Add(tournament, myteam);
                Save();
            }    
        }

        private SaveGames GetGames()
        {
            return new SaveGames(user) as SaveGames;
        }

        private List<TeamGame> GetAllGames()
        {
            return Load<List<TeamGame>>(GAMES_FILE_NAME) ?? new List<TeamGame>();
        }
        public void Save()
        {
            Save(GAMES_FILE_NAME, Teamgames);
        }
    }
   }
