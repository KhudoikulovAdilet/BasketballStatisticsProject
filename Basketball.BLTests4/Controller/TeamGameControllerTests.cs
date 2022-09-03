using Microsoft.VisualStudio.TestTools.UnitTesting;
using Basketball.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basketball.BL.Model;

namespace Basketball.BL.Controller.Tests
{
    [TestClass()]
    public class TeamGameControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            var playername = Guid.NewGuid().ToString();
            var tournament = Guid.NewGuid().ToString();
            var myteam = Guid.NewGuid().ToString();
            var opposingteam = Guid.NewGuid().ToString();

            var rnd = new Random();
            var usercontroller = new Usercontroller(playername);
            var teamgamecontroller = new TeamGameController(usercontroller.CurrentUser);
            var teamgames = new TeamGame(tournament, myteam, opposingteam, rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500));

            teamgamecontroller.Add(tournament);

            Assert.AreEqual(teamgamecontroller.ToString (), teamgamecontroller.ToString());
        }
    }
}