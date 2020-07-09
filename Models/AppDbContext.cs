using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ChatApp.Models.Config;

namespace ChatApp.Models
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new AppUserConfigurations { });
            builder.ApplyConfiguration(new RoomConfigurations { });
            builder.ApplyConfiguration(new MessageConfigurations { });
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<IdentityRole> IdentityRoles { get; set; }
    }
}
