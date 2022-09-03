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
            Console.WriteLine("Вас приветствует приложение Адилета по сохранению игровой статистики");

            Console.WriteLine("Введите имя пользователя");
            var firstname = Console.ReadLine();

            var usercontroller = new Usercontroller(firstname);
            var teamgamecontroller = new TeamGameController(usercontroller.CurrentUser);

            if (usercontroller.IsNewUser)
            {
                Console.Write("Введите фамилию:");
                var lastname = Console.ReadLine();

                DateTime birthdate = ParseDateTime();

                usercontroller.SetNewUserData(lastname, birthdate);
            }
            Console.WriteLine(usercontroller.CurrentUser);

            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("Г - ввести результаты командной игры");
            var key = Console.ReadKey();
            Console.WriteLine();
            if(key.Key == ConsoleKey.G)
            {
                var games = EnterTeamGame();
                teamgamecontroller.Add(teamGame.);
                //eatingController.Add(foods.Food, foods.Weight);

                foreach (var item in teamgamecontroller.saveGames.)
                {
                    Console.WriteLine($"\t {item.Key}");
                }
            }

            Console.ReadLine();
        }

        private static (TeamGame teamGame, string myteam) EnterTeamGame()
        {
            Console.Write("Введите название турира");
            var tournamnetgame = Console.ReadLine();

            Console.Write("Введите имя вашей команды");
            var myteam = Console.ReadLine();

            Console.Write("Введите имя команды соперника");
            var opposingteam = Console.ReadLine();

            Console.Write("Введите колиство очков, набранных вашей командой");
            var myteampoints = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите колиство очков, набранных командой соперника");
            var opposingteampoints = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите количество ваших личных набранных очков");
            var mypoints = Convert.ToInt32(Console.ReadLine());

            var tg = new TeamGame(tournamnetgame, myteam, opposingteam, myteampoints, opposingteampoints, mypoints);

            return (teamgame: tg, myteam: myteam);
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
// study githud