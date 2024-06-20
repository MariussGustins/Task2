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
        public async Task<ActionResult<IEnumerable<ApartmentDto>>> GetApartments()
        {
            var apartments = await _apartmentService.GetApartmentsAsync();
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
