using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace _005_One_to_many
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Player> Players { get; set; } // игроки команды
    }

    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }  // команда игрока
    }

    public class Context : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public Context()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=relationsdb;Trusted_Connection=True;");
        }
    }
}
