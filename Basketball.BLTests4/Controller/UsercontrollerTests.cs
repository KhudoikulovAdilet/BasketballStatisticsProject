using Microsoft.VisualStudio.TestTools.UnitTesting;
using Basketball.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.BL.Controller.Tests
{
    [TestClass()]
    public class UsercontrollerTests
    {

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            // Arrange
            var playerName = Guid.NewGuid().ToString();
            var secondname = Guid.NewGuid().ToString();
            var birthdate = DateTime.Now.AddYears(-18);
            var controller = new Usercontroller(playerName);

            //Act
            controller.SetNewUserData(secondname, birthdate);
            var controller2 = new Usercontroller(playerName);

            // Assert
            Assert.AreEqual(playerName, controller2.CurrentUser.FirstName);
            Assert.AreEqual(secondname, controller2.CurrentUser.LastName);
            Assert.AreEqual(birthdate, controller2.CurrentUser.BirthDate);
        }

        [TestMethod()]
        public void  SaveTest()
        {
            // Arrange 
            var playerName = Guid.NewGuid().ToString();

            // Act
            var controller = new Usercontroller(playerName);

            //Assert
            Assert.AreEqual(playerName, controller.CurrentUser.FirstName);
        }
    }
}