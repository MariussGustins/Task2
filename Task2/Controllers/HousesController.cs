using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task2.Models;

namespace Task2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HousesController : ControllerBase
    {
        private readonly EstateContext _context;

        public HousesController(EstateContext context)
        {
            _context = context;
        }

        // GET: api/Houses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<House>>> GetHouses()
        {
            if (_context.Houses == null)
            {
                return NotFound();
            }
            return await _context.Houses.Include(h => h.Apartments).ToListAsync();
        }

        // GET: api/Houses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<House>> GetHouse(int id)
        {
            if (_context.Houses == null)
            {
                return NotFound();
            }
            var house = await _context.Houses.Include(h => h.Apartments).FirstOrDefaultAsync(h => h.Id == id);

            if (house == null)
            {
                return NotFound();
            }

            return house;
        }

        // PUT: api/Houses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHouse(int id, House house)
        {
            if (id != house.Id)
            {
                return BadRequest();
            }

            _context.Entry(house).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HouseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Houses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<House>> PostHouse(HouseDto houseDto)
        {
            if (_context.Houses == null)
            {
                return Problem("Entity set 'EstateContext.Houses' is null.");
            }

            var house = new House
            {
                Number = houseDto.Number,
                Street = houseDto.Street,
                City = houseDto.City,
                Country = houseDto.Country,
                Postcode = houseDto.Postcode,
                Apartments = houseDto.Apartments?.Select(a => new Apartment
                {
                    Number = a.Number,
                    Floor = a.Floor,
                    Rooms = a.Rooms,
                    NumberOfResidents = a.NumberOfResidents,
                    FullArea = a.FullArea,
                    LivingArea = a.LivingArea,
                    Residents = a.Residents?.Select(r => new Resident
                    {
                        Name = r.Name,
                        LastName = r.LastName,
                        PersonalNumber = r.PersonalNumber,
                        Birthday = r.Birthday,
                        PhoneNumber = r.PhoneNumber,
                        Email = r.Email
                    }).ToList()
                }).ToList()
            };

            _context.Houses.Add(house);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHouse), new { id = house.Id }, house);
        }

        // DELETE: api/Houses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHouse(int id)
        {
            if (_context.Houses == null)
            {
                return NotFound();
            }
            var house = await _context.Houses.FindAsync(id);
            if (house == null)
            {
                return NotFound();
            }

            _context.Houses.Remove(house);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HouseExists(int id)
        {
            return _context.Houses.Any(e => e.Id == id);
        }
    }
}
