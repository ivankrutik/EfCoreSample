using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace _001_External_keys_and_navigation_properties
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
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TetsDB_001;Trusted_Connection=True;");
        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamInfoKey);
             // .HasPrincipalKey(t => t.Name)
        }*/
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

        public int TeamInfoKey { get; set; }
        [ForeignKey("TeamInfoKey")]
        public Team Team { get; set; }
    }
}
