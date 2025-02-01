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

        public double GetAverageHashrate(DateTime? date = null)
        {
            var avg = 0D;
            if(date.HasValue)
            {
                var hashrateForDate = deviceStatusLogs.Where(d => d.Timestamp.Date == date);
                if (hashrateForDate.Any())
                {
                    hashrateForDate.Average(hashrate => hashrate.HashRate);
                }
            }
            else
            {
                avg = deviceStatusLogs.Average(d => d.HashRate);
            }
            return avg;
        }

        public double AverageHashrate(int minutes)
        {
            var avg = double.NaN;
            var lastMeasures = deviceStatusLogs.Where(status => status.Timestamp > DateTime.Now.AddMinutes(-minutes));
            if(lastMeasures.Count() > 5)
            {
                avg = lastMeasures.Average(d => d.Temperature);
            }
            return avg;
        }
    }
}
