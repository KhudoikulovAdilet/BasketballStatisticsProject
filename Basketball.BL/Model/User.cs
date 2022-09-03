using System;

namespace Basketball.BL.Model
{
    [Serializable]
    public class User
    {
        public string FirstName { get; set;  } // Имя
        public string LastName { get; set; } // Фамилия
        public DateTime BirthDate { get; set; } // Дата рождения

        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }

        public User(string firstname, string lastname, DateTime birthdate)
        {
            // Проверка условий
            #region Проверка условий
            if (string.IsNullOrWhiteSpace(firstname))
            {
                throw new ArgumentNullException("Поле имя не может быть пустой.", nameof(firstname)) ;
            }

            if (string.IsNullOrWhiteSpace(lastname))
            {
                throw new ArgumentNullException("Поле фамилия не может быть пустой.", nameof(lastname));
            }

            if (birthdate < DateTime.Parse("01.01.1900") && birthdate >= DateTime.Now)
            {
                throw new ArgumentException("Введите корректную дату рождения.", nameof(birthdate));
            }
            #endregion  // Проверка правильности ввода данных
            FirstName = firstname;
            LastName = lastname;
            BirthDate = birthdate;
        }
       
        public User(string firstname)
        {
            if(string.IsNullOrWhiteSpace(firstname))
            {
                throw new ArgumentNullException("Поле данных пользователя не может быть пустой", nameof(firstname));
            }

            FirstName = firstname;
        }
        public override string ToString()
        {
            return FirstName + " " + LastName + " " + Age + " лет";
        }
    }
}
