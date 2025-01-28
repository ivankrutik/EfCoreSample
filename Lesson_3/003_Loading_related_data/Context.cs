using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _003_Loading_related_data
{
    class Context : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public Context()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=relationsdb;Trusted_Connection=True;");
        }
    }
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int StadiumId { get; set; }
        public Stadium Stadium { get; set; } // стадион команды

        public List<Player> Players { get; set; } // игроки команды
    }

    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }  // команда игрока

        public int CountryId { get; set; }
        public Country Country { get; set; }    // страна игрока
    }

    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CapitalId { get; set; }
        public City Capital { get; set; }  // столица страны

        public List<Player> Players { get; set; }
    }

    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Stadium
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
