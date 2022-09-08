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

        public List<TeamGame> Teamgames { get; }

        public SaveGames Savegames { get; }

        public TeamGameController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым.", nameof (user));
            Teamgames = GetAllGames();
            Savegames = GetGames();
        }

        public void Add(TeamGame Teamgame, string name)
        {
            var tournament = Teamgames.SingleOrDefault(t => t.Name == Teamgame.Name);
            if (tournament == null)
            {
                Teamgames.Add(tournament);
                Savegames.Add(tournament, name);
                Save();
            }
            else
            {
                Savegames.Add(tournament, name);
                Save();
            }    
        }

        private SaveGames GetGames()
        {
            return Load<SaveGames>().FirstOrDefault() ?? new SaveGames(user);
        }

        private List<TeamGame> GetAllGames()
        {
            return Load<TeamGame>() ?? new List<TeamGame>() ;
        }
        public void Save()
        {
            Save(Teamgames);
            Save(new List<SaveGames>() {});
        }
    }
   }
