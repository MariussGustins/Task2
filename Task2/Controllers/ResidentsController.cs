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
    public class ResidentsController : ControllerBase
    {
        private readonly IResidentService _residentService;

        public ResidentsController(IResidentService residentService)
        {
            _residentService = residentService;
        }

        // GET: api/Residents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resident>>> GetResidents()
        {
         var residents = await _residentService.GetResidentsAsync();
            return Ok(residents);
        }

        // GET: api/Residents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Resident>> GetResident(int id)
        {
          var resident = await _residentService.GetResidentAsync(id);

            if(resident == null)
            {
                return NotFound();
            }

            return resident;
        }

        // PUT: api/Residents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResident(int id, ResidentDto residentDto)
        {
            var result = await _residentService.UpdateResidentAsync(id, residentDto);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Residents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Resident>> PostResident(ResidentDto residentDto)
        {
          var residentId = await _residentService.CreateResidentAsync(residentDto);
            return CreatedAtAction(nameof(GetResident), new { id = residentId }, null);
        }

        // DELETE: api/Residents/5
        [HttpDelete("{id}")]
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
