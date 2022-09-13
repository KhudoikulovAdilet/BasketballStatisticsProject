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
            var name = Guid.NewGuid().ToString();
            var ourteam = Guid.NewGuid().ToString();
            var opposingteam = Guid.NewGuid().ToString();
            var usercontroller = new Usercontroller(playername);
            var teamgamecontroller = new TeamGameController(usercontroller.CurrentUser);
            var teamgames = new SaveGames(name);

            teamgamecontroller.Add(teamgames, ourteam, opposingteam, 300, 300, 100);

            Assert.AreEqual(name, teamgamecontroller.saveGames.First().Name);
        }
    }
}