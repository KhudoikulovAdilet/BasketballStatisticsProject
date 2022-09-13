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
    public class PersonalGameControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            var playername = Guid.NewGuid().ToString();
            var typeofgame = Guid.NewGuid().ToString();
            var usercontroller = new Usercontroller(playername);
            var gameresults = new PersonalGameController(usercontroller.CurrentUser);
            var personalgamecont = new PersonalGame(typeofgame);

            gameresults.Add(personalgamecont, 6, 8);

            Assert.AreEqual(typeofgame, gameresults.personalGame.First().Name);
        }
    }
}