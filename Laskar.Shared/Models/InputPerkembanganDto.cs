namespace Laskar.Shared.Models
{
    public class InputPerkembanganDto
    {
        public string NamaSiswa { get; set; } = string.Empty;
        public string NomorInduk { get; set; } = string.Empty;
        public string Kelas { get; set; } = string.Empty;
        public int Semester { get; set; }
        public int TahunAjaran { get; set; }
        public KategoriPerkembangan Kategori { get; set; } = new();
    }
}
