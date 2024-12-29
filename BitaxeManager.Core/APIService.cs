using System.Net.Http.Json;

namespace BitaxeManager.Core
{
    public class ApiService(HttpClient httpClient)
    {
        public async Task<DeviceStatus?> GetDeviceStatusAsync()
        {
            try
            {
                var response = await httpClient.GetAsync(httpClient.BaseAddress);

                response.EnsureSuccessStatusCode();

                var deviceStatus = await response.Content.ReadFromJsonAsync<DeviceStatus>();
                return deviceStatus;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP Error : {ex.Message}");
                return null;
            }
        }
    }
}
