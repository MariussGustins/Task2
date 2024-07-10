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
        [HttpGet("by-email/{email}")]
        public async Task<ActionResult<ResidentDto>> GetResidentByEmail(string email)
        {
            var resident = await _residentService.GetResidentByEmailAsync(email);

            if (resident == null)
            {
                return NotFound();
            }

            return Ok(resident);
        }
        [HttpGet("apartment/{apartmentId}/email/{email}")]
        public async Task<ActionResult<IEnumerable<ResidentDto>>> GetResidentsByApartmentIdAndEmail(int apartmentId, string email)
        {
            var residents = await _residentService.GetResidentsByApartmentIdAndEmailAsync(apartmentId, email);

            if (residents == null || !residents.Any())
            {
                return NotFound();
            }

            return Ok(residents);
        }

        [HttpPut("{id}")]
        // [Authorize(Roles = "Manager, Resident")]
        public async Task<IActionResult> PutResident(string id, ResidentDto residentDto)
        {
            var result = await _residentService.UpdateResidentAsync(id, residentDto);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpPost("create-users")]
        public async Task<IActionResult> CreateUsersForResidents()
        {
            await _residentService.CreateUsersForResidentsAsync();
            return Ok(new { message = "User accounts created for all residents" });
        }

        [HttpPost]
        // [Authorize(Roles = "Manager")]
        public async Task<ActionResult<ResidentDto>> PostResident(ResidentDto residentDto)
        {
            
            var residentId = await _residentService.CreateResidentAsync(residentDto);
            return CreatedAtAction(nameof(GetResident), new { id = residentId }, null);
        }
        // [HttpPost("update-residents-passwords")]
        // public async Task<IActionResult> UpdateResidentsPasswords()
        // {
        //     try
        //     {
        //         await _residentService.UpdateResidentsWithUserPasswordsAsync();
        //         return Ok("Residents' passwords updated successfully.");
        //     }
        //     catch (Exception ex)
        //     {
        //         return StatusCode(500, $"An error occurred: {ex.Message}");
        //     }
        // }

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
