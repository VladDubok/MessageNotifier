using MessageService.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MessageService.Data
{
    public class MessageApplicationContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageEvent> MessageEvents { get; set; }

        public MessageApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<MessageEvent>()
            .HasKey(x => x.Id);
        }
    }
}