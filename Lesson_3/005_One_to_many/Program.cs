using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _005_One_to_many
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добавление и вывод:");

            using (Context db = new Context())
            {
                // создание и добавление моделей
                Team t1 = new Team { Name = "Барселона" };
                Team t2 = new Team { Name = "Реал Мадрид" };
                db.Teams.Add(t1);
                db.Teams.Add(t2);
                db.SaveChanges();

                Player pl1 = new Player { Name = "Роналду", Team = t2 };
                Player pl2 = new Player { Name = "Месси", Team = t1 };
                Player pl3 = new Player { Name = "Неймар", Team = t1 };
                db.Players.AddRange(new List<Player> { pl1, pl2, pl3 });
                db.SaveChanges();

                // вывод игроков
                var players = db.Players.Include(p => p.Team).ToList();
                foreach (Player pl in players)
                    Console.WriteLine($"{pl.Name} - {pl.Team?.Name}");

                // вывод команд
                var teams = db.Teams.Include(t => t.Players).ToList();
                foreach (Team t in teams)
                {
                    Console.WriteLine("\n Команда: {0}", t.Name);
                    foreach (Player pl in t.Players)
                    {
                        Console.WriteLine($"{pl.Name}");
                    }
                }
            }
            Console.WriteLine("Редактирование:");
            using (Context db = new Context())
            {
                Player player1 = db.Players.FirstOrDefault(p => p.Name == "Роналду");
                if (player1 != null)
                {
                    player1.Name = "Криштиану Роналду";
                    db.SaveChanges();
                }

                Team team1 = db.Teams.FirstOrDefault(p => p.Name == "Реал Мадрид");
                if (team1 != null)
                {
                    team1.Name = "Реал М.";
                    db.SaveChanges();
                }

                // смена команды игрока
                Player player2 = db.Players.FirstOrDefault(p => p.Name == "Неймар");
                if (player2 != null && team1 != null)
                {
                    player2.Team = team1;
                    db.SaveChanges();
                }
            }
            Console.WriteLine("Удаление:");
            using (Context db = new Context())
            {
                Player player1 = db.Players.FirstOrDefault(p => p.Name == "Криштиану Роналду");
                if (player1 != null)
                {
                    db.Players.Remove(player1);
                    db.SaveChanges();
                }

                Team team1 = db.Teams.FirstOrDefault();
                if (team1 != null)
                {
                    db.Teams.Remove(team1);
                    db.SaveChanges();
                }
            }
        }
    }
}
