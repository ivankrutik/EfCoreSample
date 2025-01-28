using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace _003_Loading_related_data
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Context db = new Context())
            {
                Team team = db.Teams
                    .Include(t => t.Players)
                        .ThenInclude(p => p.Country)
                    .FirstOrDefault();

                Console.WriteLine($"Team: {team.Name}");
                foreach (var p in team.Players)
                    Console.WriteLine($"Player: {p.Name}    Country: {p.Country?.Name}");
            }
        }
    }
}
