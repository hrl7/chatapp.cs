using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Models
{
    public class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (context.Rooms.Any())
                {
                    return;
                }
                context.AddRange(
                    new Room { Name = "test room 1" },
                    new Room { Name = "test room 2" },
                    new Room { Name = "test room 3" },
                    new Room { Name = "test room 4" },
                    new Room { Name = "test room 5" }
                );
                context.SaveChanges();
                var rooms = context.Rooms.ToList();
                foreach (var room in rooms)
                {
                    context.AddRange(
                       new Message
                       {
                           Room = room,
                           Text = "こんにちは",
                       },
                       new Message
                       {
                           Room = room,
                           Text = "こんばんは",
                       },
                       new Message
                       {
                           Room = room,
                           Text = "いい天気ですね",
                       }
                    );
                }
                context.SaveChanges();
            }
        }
    }
}
