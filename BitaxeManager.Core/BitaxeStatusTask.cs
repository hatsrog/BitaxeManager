using BitaxeManager.Core.data;
using BitaxeManager.Core.models;
using Coravel.Invocable;

namespace BitaxeManager.Core
{
    public class BitaxeStatusTask : IInvocable
    {
        private readonly ApiService _apiService;
        private readonly AppDbContext _dbContext;

        public BitaxeStatusTask(ApiService apiService, AppDbContext dbContext) 
        { 
            _apiService = apiService;
            _dbContext = dbContext;
        }

        public async Task Invoke()
        {
            var deviceStatus = await _apiService.GetDeviceStatusAsync();
            if (deviceStatus != null)
            {
                var newStatus = new DeviceStatusLog
                {
                    HashRate = deviceStatus.HashRate,
                    Timestamp = DateTime.Now,
                    SharesAccepted = deviceStatus.SharesAccepted,
                    Temperature = deviceStatus.Temp
                };
                _dbContext.DeviceStatusLogs.Add(newStatus);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
