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

        public List<TeamGame> Games { get; }

        public SaveGames saveGames { get; }

        public TeamGameController(User user)
        {
            this .user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым.", nameof (user));
            Games = GetAllGames();
            saveGames = GetGames();

        }

        public void Add(string tournamentgame)
        {
            var tournament = Games.SingleOrDefault(t => t.TournementName == tournamentgame);
            if (tournament == null)
            {
                Games.Add(tournament);
                saveGames.Add(tournament);
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
            Save(GAMES_FILE_NAME, Games);
        }
    }
   }
