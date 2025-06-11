using System;
using System.Collections.Generic;

namespace Laskar.Shared.Models
{
    public class PerkembanganSiswa
    {
        public int Id { get; set; }
        public string NamaSiswa { get; set; } = string.Empty;
        public string NomorInduk { get; set; } = string.Empty;
        public string Kelas { get; set; } = string.Empty;
        public int Semester { get; set; }
        public int TahunAjaran { get; set; }
        public DateTime Tanggal { get; set; } = DateTime.Now;
        public Dictionary<KategoriPerkembangan.Kategori, string> CatatanPerKategori { get; set; } = new();
    }
}