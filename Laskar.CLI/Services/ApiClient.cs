using Laskar.Shared.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;


namespace LaporanPerkembanganCLI.Services
{
    public class ApiClient
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<PerkembanganSiswa?> GetReportByIdAsync(string id)
        {
            string apiUrl = $"http://localhost:5011/api/perkembangan/{id}";

            try
            {
                var response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<PerkembanganSiswa>(json);
                    return data;
                }
                else
                {
                    Console.WriteLine($"❌ Error: Status {response.StatusCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Gagal menghubungi API: " + ex.Message);
                return null;
            }
        }
    }
}
