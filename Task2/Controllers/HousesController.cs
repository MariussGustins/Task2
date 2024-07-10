using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task2.Interface;
using Task2.DTOs;
using Task2.Models;
using Task2.Services;

namespace Task2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HousesController : ControllerBase
    {
        private readonly IHousesService _housesService;
        private readonly IApartmentService _apartmentService;
        private readonly IUserService _userService;
        private readonly EstateContext _context;

        public HousesController(IHousesService housesService, IApartmentService apartmentService, IUserService userService)
        {
            _housesService = housesService;
            _apartmentService = apartmentService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetHouses()
        {
            var houses = await _housesService.GetHousesAsync();
            return Ok(houses);
        }

        [HttpGet("{email}/house")]
        public async Task<IActionResult> GetHouseByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email cannot be null or empty.");
            }

            var houseDto = await _housesService.GetHouseByEmailAsync(email);

            if (houseDto == null)
            {
                return NotFound();
            }

            return Ok(houseDto);
        }

        [HttpGet("{id}/Apartments")]
        // [Authorize(Roles = "Resident,Manager")]
        public async Task<ActionResult<IEnumerable<ApartmentDto>>> GetApartmentsByHouseId(int id)
        {
            var apartments = await _apartmentService.GetApartmentsByHouseIdAsync(id);
            return Ok(apartments);
        }

        [HttpGet("{id}")]
        // [Authorize(Roles = "Resident,Manager")]
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
        // [Authorize(Roles = "Manager")]
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
        // [Authorize(Roles = "Manager")]
        public async Task<ActionResult<HouseDto>> PostHouse(HouseDto houseDto)
        {
            var houseId = await _housesService.CreateHouseAsync(houseDto);
            return CreatedAtAction(nameof(GetHouse), new { id = houseId }, null);
        }

        [HttpDelete("{id}")]
        // [Authorize(Roles = "Manager")]
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
