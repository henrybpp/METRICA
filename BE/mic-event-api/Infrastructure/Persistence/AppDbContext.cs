using System.Collections.Generic;
using mic_event_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace mic_event_api.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Event> Events => Set<Event>();

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Event>().HasKey(p => p.Id);
            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("events"); // 👈 IMPORTANTE en PostgreSQL
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired();
            });
        }*/
    }
}
