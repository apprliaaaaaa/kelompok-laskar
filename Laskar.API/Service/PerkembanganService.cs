using System.Xml.Linq;
using Laskar.Shared.Models;
using Laskar.API.Services;



namespace Laskar.API.Services
{
    public class PerkembanganService
    {
        private readonly RuntimeConfigService runtimeConfig;
        private static int idCounter = 1;
        private static readonly List<PerkembanganSiswa> database = new();

        public PerkembanganService(RuntimeConfigService config)
        {
            runtimeConfig = config;
        }

        public List<PerkembanganSiswa> GetAll() => database;
        public PerkembanganSiswa? GetById(int id) => database.FirstOrDefault(p => p.Id == id);

        public PerkembanganSiswa Post(InputPerkembanganDto dto)
        {
            if (string.IsNullOrEmpty(dto.NomorInduk))
                throw new ArgumentException("Nomor Induk tidak boleh kosong");

            if (dto.NomorInduk.Length > runtimeConfig.Config.MaxKarakterNomorInduk)
                throw new ArgumentException("Nomor Induk terlalu panjang");

            var catatan = new PerkembanganSiswa
            {
                Id = idCounter++,
                NamaSiswa = dto.NamaSiswa,
                NomorInduk = dto.NomorInduk,
                Kelas = dto.Kelas,
                Semester = dto.Semester,
                TahunAjaran = dto.TahunAjaran,
                CatatanPerKategori = ValidasiDanEkstrakKategori(dto.Kategori)
            };

            database.Add(catatan);
            return catatan;
        }

        public bool Update(int id, InputPerkembanganDto dto)
        {
            var existing = GetById(id);
            if (existing == null) return false;

            existing.NamaSiswa = dto.NamaSiswa;
            existing.NomorInduk = dto.NomorInduk;
            existing.Kelas = dto.Kelas;
            existing.Semester = dto.Semester;
            existing.TahunAjaran = dto.TahunAjaran;
            existing.CatatanPerKategori = ValidasiDanEkstrakKategori(dto.Kategori);

            return true;
        }

        public bool Delete(int id)
        {
            var existing = GetById(id);
            return existing != null && database.Remove(existing);
        }

        private Dictionary<KategoriPerkembangan.Kategori, string> ValidasiDanEkstrakKategori(KategoriPerkembangan kategoriDto)
        {
            if (kategoriDto == null)
                throw new ArgumentException("Data kategori tidak boleh kosong");

            var hasil = new Dictionary<KategoriPerkembangan.Kategori, string>();

            foreach (KategoriPerkembangan.Kategori kategori in Enum.GetValues(typeof(KategoriPerkembangan.Kategori)))
            {
                var propInfo = kategoriDto.GetType().GetProperty(kategori.ToString());
                if (propInfo == null) continue;

                string? value = propInfo.GetValue(kategoriDto)?.ToString();
                if (!string.IsNullOrEmpty(value))
                {
                    if (runtimeConfig.Config.MaxKarakterPerKategori.TryGetValue(kategori.ToString(), out int batas))
                    {
                        if (value.Length > batas)
                            throw new Exception($"Catatan untuk kategori {kategori} terlalu panjang (maksimal {batas} karakter).");
                    }

                    hasil[kategori] = value;
                }
            }

            return hasil;
        }

    }
}
