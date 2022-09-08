using Basketball.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.BL.Controller
{
    public class PersonalGameController : ControllerBase
    {
        private readonly User user;

        public List<PersonalGame> personalGame { get; } // Activity
        public List<GameResults> gameResults { get; }
        public PersonalGameController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));

            personalGame = GetAllGamesResults();
            gameResults = GetAllGames();
        }

       

        public void Add(PersonalGame personalgame, int mypoints, int hispoints)
        {
            var game = personalGame.SingleOrDefault(u => u.Name == personalgame.Name);

            if(game == null)
            {
                personalGame.Add(personalgame);

                var gg = new GameResults(mypoints, hispoints, user);
                gameResults.Add(gg);
            }
            else
            {
                var gg = new GameResults(mypoints, hispoints, user);
                gameResults.Add(gg);
            }
            Save();
        }

        private List<GameResults> GetAllGames()
        {
            return Load<GameResults>() ?? new List<GameResults>();
        }

        private List<PersonalGame> GetAllGamesResults()
        {
            return Load<PersonalGame>() ?? new List<PersonalGame>();
        }

        public void Save()
        {
            Save(personalGame);
            Save(gameResults);
            Save(new List<PersonalGame>() { });
        }
    }
}
