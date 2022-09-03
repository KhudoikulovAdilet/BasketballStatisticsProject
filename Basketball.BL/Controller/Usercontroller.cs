using Basketball.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Basketball.BL.Controller
{

    /// <param name = "user"></param>
    public class Usercontroller : ControllerBase
    {
        // Сохранили данные пользователя и возможность получения данных существующего пользователя.
        public List<User> Users { get; }

        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;
        private const string USERS_FILE_NAME = "users.dat";
        public Usercontroller(string playerName)
        {

            if (string.IsNullOrWhiteSpace(playerName))
            {
                throw new ArgumentNullException("Данные пользователя не могут быть пустыми", nameof(playerName));
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.FirstName == playerName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(playerName);
                Users.Add(CurrentUser);
                IsNewUser = true;
            }
        }

        private List<User> GetUsersData()
        {
            return Load<List<User>>(USERS_FILE_NAME) ?? new List<User>();
        }
        public void SetNewUserData(string lastname, DateTime birthdate)
        {
            // proverka

            CurrentUser.LastName = lastname;
            CurrentUser.BirthDate = birthdate;
            Save();
        }
        public void Save()
        {
            Save(USERS_FILE_NAME, Users);
        }

    }
}
