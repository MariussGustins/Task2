using Microsoft.AspNetCore.Mvc;
using Task2.Interface;
using Task2.DTOs;
using Task2.Services;

namespace Task2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HousesController : ControllerBase
    {
        private readonly IHousesService _housesService;
        private readonly IApartmentService _apartmentService;

        public HousesController(IHousesService housesService, IApartmentService apartmentService) 
        {
            _housesService = housesService;
            _apartmentService = apartmentService; 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HouseDto>>> GetHouses()
        {
            var houses = await _housesService.GetHousesAsync();
            return Ok(houses);
        }
        [HttpGet("{id}/Apartments")] 
        public async Task<ActionResult<IEnumerable<ApartmentDto>>> GetApartmentsByHouseId(int id)
        {
            var apartments = await _apartmentService.GetApartmentsByHouseIdAsync(id);
            return Ok(apartments);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<HouseDto>> GetHouse(int id)
        {
            var house = await _housesService.GetHouseAsync(id);

            if (house == null)
            {
                return NotFound();
            }

            return Ok(house);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHouse(int id, HouseDto houseDto)
        {
            var result = await _housesService.UpdateHouseAsync(id, houseDto);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<HouseDto>> PostHouse(HouseDto houseDto)
        {
            var houseId = await _housesService.CreateHouseAsync(houseDto);
            return CreatedAtAction(nameof(GetHouse), new { id = houseId }, null);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHouse(int id)
        {
            var houseExists = await _housesService.HouseExistsAsync(id);
            if (!houseExists)
            {
                return NotFound();
            }

            await _housesService.DeleteHouseAsync(id);
            return NoContent();
        }
    }
}