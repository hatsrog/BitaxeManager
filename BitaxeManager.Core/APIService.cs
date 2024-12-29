using System.Net.Http.Json;

namespace BitaxeManager.Core
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DeviceStatus?> GetDeviceStatusAsync()
        {
            try
            {
                string apiUrl = "http://192.168.1.133/api/system/info";

                var response = await _httpClient.GetAsync(apiUrl);

                response.EnsureSuccessStatusCode();

                var deviceStatus = await response.Content.ReadFromJsonAsync<DeviceStatus>();
                return deviceStatus;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Erreur HTTP : {ex.Message}");
                return null;
            }
        }
    }
}
