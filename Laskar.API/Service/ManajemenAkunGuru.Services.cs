using Laskar.Shared.Models;
using ManajemenAkunGuru.Models;
using System.Xml.Linq;
namespace ManajemenAkunGuru.Services;

public class GuruService
{
    private readonly List<GuruModel> _guruList = new();

    // READ - Ambil semua data guru
    public IEnumerable<GuruModel> GetAll() => _guruList;

    // READ - Ambil satu guru berdasarkan ID
    public GuruModel? GetById(string id) => _guruList.FirstOrDefault(g => g.Id == id);

    // CREATE - Tambah guru baru
    public bool Add(GuruModel guru)
    {
        if (!InputValidator.IsValidUsername(guru.Username)) return false;
        if (string.IsNullOrWhiteSpace(guru.Password) || guru.Password.Length < 6) return false;

        _guruList.Add(guru);
        return true;
    }

    // validasi username



    // UPDATE - Ubah data guru berdasarkan ID
    public bool Update(string id, GuruModel updatedGuru)
    {
        var existingGuru = GetById(id);
        if (existingGuru == null) return false;

        if (!InputValidator.IsValidUsername(updatedGuru.Username)) return false;
        if (string.IsNullOrWhiteSpace(updatedGuru.Password) || updatedGuru.Password.Length < 6) return false;

        existingGuru.Nama = updatedGuru.Nama;
        existingGuru.Username = updatedGuru.Username;
        existingGuru.Password = updatedGuru.Password;

        return true;
    }

    // DELETE - Hapus guru berdasarkan ID
    public bool Delete(string id)
    {
        var guru = GetById(id);
        if (guru == null) return false;
        return _guruList.Remove(guru);
    }
}
