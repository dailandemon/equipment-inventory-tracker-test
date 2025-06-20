using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MissileSimulator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("🚀 Missile simulator started...");

            var httpClient = new HttpClient();
            int missileId = 1; // Update this ID if needed
            string apiUrl = $"https://localhost:5001/api/equipment/{missileId}/location"; // Update base URL if needed

            double centerLat = 27.994402;
            double centerLng = -81.760254;
            double radius = 1.0;

            while (true)
            {
                for (int angle = 0; angle < 360; angle += 10)
                {
                    double radians = angle * Math.PI / 180;
                    double lat = centerLat + radius * Math.Cos(radians);
                    double lng = centerLng + radius * Math.Sin(radians);

                    var payload = new
                    {
                        latitude = lat,
                        longitude = lng
                    };

                    var json = JsonSerializer.Serialize(payload);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    try
                    {
                        var response = await httpClient.PutAsync(apiUrl, content);
                        Console.WriteLine($"[✓] Updated to ({lat:F4}, {lng:F4}) - Status: {response.StatusCode}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[!] Failed: {ex.Message}");
                    }

                    await Task.Delay(1000); // 1 update/sec
                }
            }
        }
    }
}
