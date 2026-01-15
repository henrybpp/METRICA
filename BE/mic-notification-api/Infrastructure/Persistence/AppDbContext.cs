using System.Collections.Generic;
using mic_notification_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace mic_notification_api.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Notification> Notifications => Set<Notification>();
    }
}
