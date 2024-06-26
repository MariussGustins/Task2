using Microsoft.AspNetCore.Mvc;
using Task2.Interface;
using Task2.DTOs;

namespace Task2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentsController : ControllerBase
    {
        private readonly IApartmentService _apartmentService;

        public ApartmentsController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApartmentDto>>> GetApartments([FromQuery] int? houseId)
        {
            IEnumerable<ApartmentDto> apartments;
            if (houseId.HasValue)
            {
                apartments = await _apartmentService.GetApartmentsByHouseIdAsync(houseId.Value);
            }
            else
            {
                apartments = await _apartmentService.GetApartmentsAsync();
            }
            return Ok(apartments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApartmentDto>> GetApartment(int id)
        {
            var apartment = await _apartmentService.GetApartmentAsync(id);

            if (apartment == null)
            {
                return NotFound();
            }

            return Ok(apartment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutApartment(int id, ApartmentDto apartmentDto)
        {
            var result = await _apartmentService.UpdateApartmentAsync(id, apartmentDto);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ApartmentDto>> PostApartment(ApartmentDto apartmentDto)
        {
            var apartmentId = await _apartmentService.CreateApartmentAsync(apartmentDto);
            return CreatedAtAction(nameof(GetApartment), new { id = apartmentId }, null);
        }
        
        [HttpPost("update-primary-residents")]
        public async Task<IActionResult> UpdatePrimaryResidents()
        {
            try
            {
                await _apartmentService.UpdatePrimaryResidentsAsync();
                return Ok("Primary residents updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApartment(int id)
        {
            var apartmentExists = await _apartmentService.ApartmentExistsAsync(id);
            if (!apartmentExists)
            {
                return NotFound();
            }

            await _apartmentService.DeleteApartmentAsync(id);
            return NoContent();
        }
    }
}
