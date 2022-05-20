using ChattyDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChattyDAL.Data
{
    class ChattyContext : DbContext
    {
        const string connectionString = "Server=localhost; Database=chattyDB; Trusted_Connection=True;";
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasKey(u => u.Login);
            modelBuilder.Entity<Message>().HasKey(m => new { m.AuthorId, m.ReceiverId, m.SendingDate });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
