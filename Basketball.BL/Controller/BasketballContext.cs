using Basketball.BL.Model;
using System;
using System.Data.Entity;

namespace Basketball.BL.Controller
{
    public class BasketballContext : DbContext
    {
        public BasketballContext() : base("DBConnection") { }

        public DbSet<PersonalGame> PersonalGames { get; set; }
        public DbSet<GameResults> GameResults { get; set; }
        public DbSet<TeamGame> TeamsGames { get; set; }
        public DbSet<SaveGames> SaveGames { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
