using Microsoft.EntityFrameworkCore;
using Task2.Interface;
using Task2.Models;
using Task2.DTOs;
using AutoMapper;

namespace Task2.Services
{
    public class ResidentsService : IResidentService
    {
        private readonly EstateContext _context;
        private readonly IMapper _mapper;

        public ResidentsService(EstateContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResidentDto>> GetResidentsAsync()
        {
            var residents = await _context.Residents.ToListAsync();
            return _mapper.Map<IEnumerable<ResidentDto>>(residents);
        }

        public async Task<ResidentDto> GetResidentAsync(int id)
        {
            var resident = await _context.Residents.FindAsync(id);
            return _mapper.Map<ResidentDto>(resident);
        }

        public async Task<int> CreateResidentAsync(ResidentDto residentDto)
        {
            var residentEntity = _mapper.Map<Resident>(residentDto);

            _context.Residents.Add(residentEntity);
            await _context.SaveChangesAsync();

            return residentEntity.Id;
        }

        public async Task<bool> UpdateResidentAsync(int id, ResidentDto residentDto)
        {
            var resident = await _context.Residents.FindAsync(id);

            if (resident == null)
                return false;

            _mapper.Map(residentDto, resident);

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

        public async Task<bool> ResidentExistsAsync(int id)
        {
            return await _context.Residents.AnyAsync(e => e.Id == id);
        }
    }
}
