using cw8.DTO;
using cw8.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace cw8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IDBService service;

        public ValuesController(IDBService service)
        {
            this.service = service;
        }
        [HttpGet("doctors")]
        [Authorize]
        public async Task<IActionResult> GetDoctors()
        {
            var result = await service.GetDoctorsAsync();

            if (result == null)
                return NoContent();

            return Ok();
        }
        [HttpPost("doctors")]
        [Authorize]
        public async Task<IActionResult> AddDoctor([FromBody] DoctorDTO doctorDTO)
        {
            var result = await service.AddDoctorAsync(doctorDTO);

            if (result != "Dodano lekarza")
                return BadRequest(result);

            return Ok();
        }
        [HttpPut("doctors/{id}")]
        [Authorize]
        public async Task<IActionResult> ModifyDoctor([FromRoute] int id, [FromBody] DoctorDTO doctorDTO)
        {
            var result = await service.ModifyDoctorAsync(id, doctorDTO);

            if (result != "zmieniono dane doktora")
                return NotFound(result);

            return Ok();
        }
        [HttpDelete("doctors/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteDoctor([FromRoute] int id)
        {
            var result = await service.DeleteDoctorAsync(id);

            if (result != "Usunieto doktora")
                return BadRequest(result);

            return Ok();
        }
        [HttpGet("prescriptions/{id}")]
        [Authorize]
        public async Task<IActionResult> GetPrescription([FromRoute] int id)
        {
            var result = await service.GetPrescriptionAsync(id);

            if (result == null)
                return NoContent();

            return Ok(result);
        }
    }
}
