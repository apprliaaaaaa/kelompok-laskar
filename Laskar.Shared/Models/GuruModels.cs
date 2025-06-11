namespace ManajemenAkunGuru.Models;

public class GuruModel
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Nama { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }
}
