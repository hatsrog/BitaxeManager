using BitaxeManager.Core.data;
using BitaxeManager.Core.models;
using Coravel.Invocable;

namespace BitaxeManager.Core
{
    public class BitaxeStatusTask(ApiService apiService, AppDbContext dbContext) : IInvocable
    {
        public async Task Invoke()
        {
            var deviceStatus = await apiService.GetDeviceStatusAsync();
            if (deviceStatus != null)
            {
                var newStatus = new DeviceStatusLog
                {
                    HashRate = deviceStatus.HashRate,
                    Timestamp = DateTime.Now,
                    SharesAccepted = deviceStatus.SharesAccepted,
                    Temperature = deviceStatus.Temp
                };
                dbContext.DeviceStatusLogs.Add(newStatus);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
