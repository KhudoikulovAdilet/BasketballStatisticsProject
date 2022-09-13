using Basketball.BL.Controller;
using Basketball.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Resources;

namespace Basketball.CMD
{
   // TODO: запись командных игр и тесты
    internal class Program
    {

        static void Main(string[] args)
        {
            //var culture = CultureInfo.CreateSpecificCulture("ru-ru");
            //var resourceMeneger = new ResourceManager("Basketball.CMD.Languages.Messages", typeof(Program).Assembly);

            Console.WriteLine("Добро пожаловать в моё приложение");

            Console.WriteLine("Введите ваше имя");
            var firstname = Console.ReadLine();

            var usercontroller = new Usercontroller(firstname);
            var teamgamecontroller = new TeamGameController(usercontroller.CurrentUser);
            var personalgamecontroller = new PersonalGameController(usercontroller.CurrentUser);

            if (usercontroller.IsNewUser)
            {
                Console.Write("Введите фамилию:");
                var lastname = Console.ReadLine();

                DateTime birthdate = ParseDateTime();

                usercontroller.SetNewUserData(lastname, birthdate);
            }
            Console.WriteLine(usercontroller.CurrentUser);

            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("G - ввести результаты командной игры");
                Console.WriteLine("W - ввести результаты прочих игр");
                Console.WriteLine("Q - Exit");
                var keys = Console.ReadKey();
                Console.WriteLine();


                switch (keys.Key)
                {
                    case ConsoleKey.G:
                        var games = EnterTeamGame();
                        teamgamecontroller.Add(games.Savegame, games.myteam, games.opposingteam, games.myteampoints, games.opposingteampoints, games.mypoint);

                        foreach (var item in teamgamecontroller.teamGame)
                        {
                            Console.WriteLine($"{item.MyTeam} : {item.OpposingTeam}");
                            Console.WriteLine($"{item.MyTeamPoints} : {item.OpposingTeamPoints}");
                        }
                        break;
                    case ConsoleKey.W:
                        var personal = EnterGamResults();
                        personalgamecontroller.Add(personal.Personalgame, personal.mypoint, personal.hispoint);
                       
                        foreach(var item in personalgamecontroller.gameResults)
                        {
                            Console.WriteLine($"Игра {item.TypeOfGame} счёт: {item.MyScore}:{item.HisScore}");
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
                Console.ReadLine();
            }
        }

        private static (int mypoint, int hispoint, PersonalGame Personalgame) EnterGamResults()
        {
            Console.WriteLine("Введите тип игры: ");
            var name = Console.ReadLine();

            Console.WriteLine("Введите ваши очки");
            int mypoint = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите очки соперника");
            int hispoint = Convert.ToInt32(Console.ReadLine());

            var personalgame = new PersonalGame(name);
            return (mypoint, hispoint, personalgame);
        }
                    
        private static (SaveGames Savegame, string myteam, string opposingteam,  int myteampoints, int opposingteampoints, int mypoint) EnterTeamGame()
        {
            Console.WriteLine("Введите название турнира:");
            var name = Console.ReadLine();

            Console.WriteLine("Введите имя вашей команды:");
            var myteam = Console.ReadLine();

            Console.WriteLine("Введите имя команды соперника:");
            var opposingteam = Console.ReadLine();

            Console.WriteLine("Введите колиство очков, набранных вашей командой:");
            var myteampoints = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите колиство очков, набранных командой соперника:");
            var opposingteampoints = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите количество ваших личных набранных очков:");
            var mypoints = Convert.ToInt32(Console.ReadLine());

            var tournamenttt = new SaveGames(name);

            return (tournamenttt, myteam, opposingteam, myteampoints, opposingteampoints, mypoints);
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthdate;

            while (true)
            {
                Console.Write("Введите дату рождения (дд.мм.гггг):");
                if (DateTime.TryParse(Console.ReadLine(), out birthdate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неправльный формат даты рождения.");
                }
            }
            return birthdate;
        }
    }
}
