using System.Collections.Generic;

namespace Laskar.Shared.Models
{
    public class RuntimeConfig
    {
        public int MaxKarakterNomorInduk { get; set; }
        public Dictionary<string, int> MaxKarakterPerKategori { get; set; } = new();
    }
}