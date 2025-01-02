using BitaxeManager.Core.models;
using Microsoft.EntityFrameworkCore;

namespace BitaxeManager.UI.Services
{
    public class BitaxeStatsService(DbSet<DeviceStatusLog> deviceStatusLogs)
    {
        public List<DeviceStatusLog> GetLastStats()
        {
            return [.. deviceStatusLogs.OrderByDescending(d => d.Timestamp).Take(10)];
        }
    }
}
