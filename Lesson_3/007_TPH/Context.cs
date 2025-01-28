using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _007_TPH
{
    class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public Context()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=TetsDB007;Trusted_Connection=True;");
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Employee : User
    {
        public int Salary { get; set; }
    }
    public class Manager : User
    {
        public string Departament { get; set; }
    }
}
