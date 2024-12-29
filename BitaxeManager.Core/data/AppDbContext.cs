using BitaxeManager.Core.models;
using Microsoft.EntityFrameworkCore;

namespace BitaxeManager.Core.data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<DeviceStatusLog> DeviceStatusLogs { get; set; }
    }
}
