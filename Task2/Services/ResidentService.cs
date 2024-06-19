using Microsoft.EntityFrameworkCore;
using Task2.Interface;
using Task2.Models;

namespace Task2.Services
{
    public class ResidentService : IResidentService
    {
        private readonly EstateContext _context;

        public ResidentService(EstateContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable <Resident>> GetResidentsAsync()
        {
            return await _context.Residents.ToListAsync();
        }

        public async Task<Resident> GetResidentAsync(int id)
        {
            return await _context.Residents.FindAsync(id);
        }

        public async Task<int> CreateResidentAsync(ResidentDto residentDto)
        {
            var resident = new Resident
            {
                Name = residentDto.Name,
                LastName = residentDto.LastName,
                PersonalNumber = residentDto.PersonalNumber,
                Birthday = residentDto.Birthday,
                PhoneNumber = residentDto.PhoneNumber,
                Email = residentDto.Email,
            };

            _context.Residents.Add(resident);
            await _context.SaveChangesAsync();

            return resident.Id;
        }

        public async Task<bool> UpdateResidentAsync(int id, ResidentDto residentDto)
        {
            var resident = await _context.Residents.FindAsync(id);

            if (resident == null)
            return false;

            resident.Name = residentDto.Name;
            resident.LastName = residentDto.LastName;
            resident.PersonalNumber = residentDto.PersonalNumber;
            resident.Birthday = residentDto.Birthday;
            resident.PhoneNumber = residentDto.PhoneNumber;
            resident.Email = residentDto.Email;

            _context.Entry(resident).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<bool> DeleteResidentAsync(int id)
        {
            var resident = await _context.Residents.FindAsync(id);

            if (resident == null)
                return false;

            _context.Residents.Remove(resident);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool>ResidentExistsAsync(int id)
        {
            return await _context.Residents.AnyAsync(e => e.Id == id);
        }

    }
}
