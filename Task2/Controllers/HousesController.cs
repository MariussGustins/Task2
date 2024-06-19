using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task2.Interface;
using Task2.Models;

namespace Task2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HousesController : ControllerBase
    {
        private readonly IHousesService _housesService;

        public HousesController(IHousesService housesService)
        {
            _housesService = housesService;
        }

        // GET: api/Houses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<House>>> GetHouses()
        {
           var houses = await _housesService.GetHousesAsync();
            return Ok(houses);
        }

        // GET: api/Houses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<House>> GetHouse(int id)
        {
            var house = await _housesService.GetHouseAsync(id);

            if (house == null)
            {
                return NotFound();
            }
            return house;

        }

        // PUT: api/Houses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

        // POST: api/Houses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostHouse(HouseDto houseDto)
        {
            var houseId = await _housesService.CreateHouseAsync(houseDto);
            return CreatedAtAction(nameof(GetHouse), new { id = houseId }, null);
        }

        // DELETE: api/Houses/5
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
