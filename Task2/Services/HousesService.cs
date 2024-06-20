using Microsoft.EntityFrameworkCore;
using Task2.Interface;
using Task2.Models;
using Task2.DTOs;
using AutoMapper;

namespace Task2.Services
{
    public class HousesService : IHousesService
    {
        private readonly EstateContext _context;
        private readonly IMapper _mapper;

        public HousesService(EstateContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<HouseDto>> GetHousesAsync()
        {
            var houses = await _context.Houses.ToListAsync();
            return _mapper.Map<IEnumerable<HouseDto>>(houses);
        }

        public async Task<HouseDto> GetHouseAsync(int id)
        {
            var house = await _context.Houses.FindAsync(id);
            return _mapper.Map<HouseDto>(house);
        }

        public async Task<int> CreateHouseAsync(HouseDto houseDto)
        {
            var house = _mapper.Map<House>(houseDto);

            _context.Houses.Add(house);
            await _context.SaveChangesAsync();

            return house.Id;
        }

        public async Task<bool> UpdateHouseAsync(int id, HouseDto houseDto)
        {
            var house = await _context.Houses.FindAsync(id);

            if (house == null)
                return false;

            _mapper.Map(houseDto, house);

            _context.Entry(house).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteHouseAsync(int id)
        {
            var house = await _context.Houses.FindAsync(id);

            if (house == null)
                return false;

            _context.Houses.Remove(house);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> HouseExistsAsync(int id)
        {
            return await _context.Houses.AnyAsync(e => e.Id == id);
        }
    }
}