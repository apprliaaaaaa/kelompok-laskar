using System;
using System.Text.Json;
using Laskar.Shared.Models;

namespace Laskar.API.Services
{

    public class RuntimeConfigService
    {
        private const string filePath = "config.json";
        public RuntimeConfig Config { get; private set; }

        public RuntimeConfigService()
        {
            try
            {
                var json = File.ReadAllText(filePath);
                Config = JsonSerializer.Deserialize<RuntimeConfig>(json);
            }
            catch
            {
                Config = new RuntimeConfig
                {
                    MaxKarakterNomorInduk = 6,
                    MaxKarakterPerKategori = new Dictionary<string, int>
                {
                    { "NilaiAgama", 200 },
                    { "JatiDiri", 300 },
                    { "LiterasiDanSTEM", 400 },
                    { "ProyekPenguatanPancasila", 350 }
                }
                };

                var json = JsonSerializer.Serialize(Config, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);
            }

        }

    }

}
