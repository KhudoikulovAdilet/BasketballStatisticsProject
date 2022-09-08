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
            var resourceMeneger = new ResourceManager("Basketball.CMD.Languages.Messages", typeof(Program).Assembly);

            Console.WriteLine(resourceMeneger.GetString("hello"));

            Console.WriteLine(resourceMeneger.GetString("EnterName"));
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
            var keys = Console.ReadKey();
            Console.WriteLine();
            if(keys.Key == ConsoleKey.G)
            {
                var games = EnterTeamGame();
                teamgamecontroller.Add(games.TeamGame, games.name);
                
                foreach (var item in teamgamecontroller.Savegames.Teamgames)
                {
                    Console.WriteLine($"\t {item.Key} - {item.Value}");
                }
            }

            Console.ReadLine();
        }

        private static (TeamGame TeamGame, string name) EnterTeamGame()
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

            var tournament = new TeamGame( name, myteam, opposingteam, myteampoints, opposingteampoints, mypoints);

            return (TeamGame: tournament, name: name);
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
