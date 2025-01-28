using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace _002_Cascading_delete
{

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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Player> Players { get; set; }
    }

    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? TeamId { get; set; } // внешний ключ
        public Team Team { get; set; }  // навигационное свойство
    }
}
