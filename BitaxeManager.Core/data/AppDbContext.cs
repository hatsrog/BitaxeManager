using BitaxeManager.Core.models;
using Microsoft.EntityFrameworkCore;

namespace BitaxeManager.Core.data
{
    public class AppDbContext : DbContext
    {
        public DbSet<DeviceStatusLog> DeviceStatusLogs { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
