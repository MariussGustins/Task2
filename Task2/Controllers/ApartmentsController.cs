using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task2.Interface;
using Task2.Models;

namespace Task2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentsController : ControllerBase
    {
        private readonly IApartmentService _apartmentsService;

        public ApartmentsController(IApartmentService apartmentsService)
        {
            _apartmentsService = apartmentsService;
        }

        // GET: api/Apartments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Apartment>>> GetApartments()
        {
          var apartments = await _apartmentsService.GetApartmentsAsync();
            return Ok(apartments);
        }

        // GET: api/Apartments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Apartment>> GetApartment(int id)
        {
          var apartment = await _apartmentsService.GetApartmentAsync(id);

            if(apartment == null)
            {
                return NotFound();
            }
            return apartment;
        }

        // PUT: api/Apartments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApartment(int id, ApartmentDto apartmentDto)
        {
            var result = await _apartmentsService.UpdateApartmentAsync(id, apartmentDto);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        // POST: api/Apartments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Apartment>> PostApartment(ApartmentDto apartmentDto)
        {
            var apartmentId = await _apartmentsService.CreateApartmentAsync(apartmentDto);
            return CreatedAtAction(nameof(GetApartment), new { id = apartmentId }, null);
        }

        // DELETE: api/Apartments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApartment(int id)
        {
            var apartmentExists = await _apartmentsService.ApartmentExistsAsync(id);
            if(!apartmentExists)
            {
                return NotFound();
            }

            await _apartmentsService.DeleteApartmentAsync(id);
            return NoContent();
        }

        
    }
}
