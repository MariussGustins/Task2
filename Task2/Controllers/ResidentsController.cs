using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Task2.Interface;
using Task2.DTOs;

namespace Task2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResidentsController : ControllerBase
    {
        private readonly IResidentService _residentService;

        public ResidentsController(IResidentService residentService)
        {
            _residentService = residentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResidentDto>>> GetResidents()
        {
            var residents = await _residentService.GetResidentsAsync();
            return Ok(residents);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResidentDto>> GetResident(int id)
        {
            var resident = await _residentService.GetResidentAsync(id);

            if (resident == null)
            {
                return NotFound();
            }

            return Ok(resident);
        }

        [HttpPut("{id}")]
        // [Authorize(Roles = "Manager, Resident")]
        public async Task<IActionResult> PutResident(int id, ResidentDto residentDto)
        {
            var result = await _residentService.UpdateResidentAsync(id, residentDto);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        // [Authorize(Roles = "Manager")]
        public async Task<ActionResult<ResidentDto>> PostResident(ResidentDto residentDto)
        {
            
            var residentId = await _residentService.CreateResidentAsync(residentDto);
            return CreatedAtAction(nameof(GetResident), new { id = residentId }, null);
        }

        [HttpDelete("{id}")]
        // [Authorize(Roles = "Manager")]
        public async Task<IActionResult> DeleteResident(int id)
        {
            var residentExists = await _residentService.ResidentExistsAsync(id);
            if (!residentExists)
            {
                return NotFound();
            }

            await _residentService.DeleteResidentAsync(id);
            return NoContent();
        }
    }
}
