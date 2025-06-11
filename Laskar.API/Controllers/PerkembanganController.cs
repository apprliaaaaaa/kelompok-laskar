using Microsoft.AspNetCore.Mvc;
using Laskar.API.Services;
using Laskar.Shared.Models;

namespace Laskar.API.Controllers
{
    [ApiController]
    [Route("api/perkembangan")]
    public class PerkembanganController : ControllerBase
    {
        private readonly PerkembanganService _service;

        public PerkembanganController(PerkembanganService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var data = _service.GetById(id);
            return data == null ? NotFound(new { error = "Data tidak ditemukan" }) : Ok(data);
        }

        [HttpPost]
        public IActionResult Tambah([FromBody] InputPerkembanganDto dto)
        {
            try
            {
                var hasil = _service.Post(dto);
                return CreatedAtAction(nameof(GetById), new { id = hasil.Id }, hasil);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] InputPerkembanganDto dto)
        {
            try
            {
                var sukses = _service.Update(id, dto);
                return sukses ? Ok("Data berhasil diperbarui") : NotFound("Data tidak ditemukan");
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var sukses = _service.Delete(id);
            return sukses ? Ok("Data berhasil dihapus") : NotFound("Data tidak ditemukan");
        }
    }
}