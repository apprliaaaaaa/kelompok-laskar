using Microsoft.AspNetCore.Mvc;
using ManajemenAkunGuru.Models;
using ManajemenAkunGuru.Services;
using Laskar.Shared.Models;
using Laskar.API.Services;

namespace ManajemenAkunGuru.Controllers;

[ApiController]
[Route("api/guru")]


public class GuruController : ControllerBase
{
    private static readonly GuruService _service = new();
    private readonly LoginAutomataService _loginService;

    public GuruController(LoginAutomataService loginService)
    {
        _loginService = loginService;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAll());

    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        var guru = _service.GetById(id);
        if (guru == null)
            return NotFound("Guru tidak ditemukan.");
        return Ok(guru);
    }

    [HttpPost]
    public IActionResult Create([FromBody] GuruModel guru)
    {
        if (!_service.Add(guru))
            return BadRequest("Username harus huruf (3-10), password minimal 6 karakter.");

        // Tambahkan ke login system agar bisa login langsung
        var user = new User(guru.Username, guru.Password, UserRole.Guru);
        _loginService.AddUser(user);

        return Ok(new { message = "Guru ditambahkan." });
    }


    [HttpPut("{id}")]
    public IActionResult Update(string id, [FromBody] GuruModel guru)
    {
        if (!_service.Update(id, guru))
            return BadRequest("Data tidak valid atau guru tidak ditemukan.");
        return Ok(new { message = "Guru diperbarui." });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        if (!_service.Delete(id))
            return NotFound("Guru tidak ditemukan.");
        return Ok("Guru dihapus.");
    }
}
