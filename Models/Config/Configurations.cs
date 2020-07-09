using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ChatApp.Models;

namespace ChatApp.Models.Config
{
    public class AppUserConfigurations : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasIndex(b => b.Email).IsUnique();
            builder.HasIndex(b => b.UserName).IsUnique();

        }
    }
    public class MessageConfigurations : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.RoomId).IsRequired();
            builder.Property(b => b.Text).HasMaxLength(500);

        }
    }
    public class RoomConfigurations : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.Name).IsRequired();
            builder.HasIndex(b => b.Name).IsUnique();

        }
    }
}
