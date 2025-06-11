namespace Laskar.Shared.Models
{
    public class KategoriPerkembangan
    {
        public string NilaiAgama { get; set; } = string.Empty;
        public string JatiDiri { get; set; } = string.Empty;
        public string LiterasiDanSTEM { get; set; } = string.Empty;
        public string ProyekPenguatanPancasila { get; set; } = string.Empty;

        public enum Kategori
        {
            NilaiAgama,
            JatiDiri,
            LiterasiDanSTEM,
            ProyekPenguatanPancasila
        }
    }
}