using Microsoft.EntityFrameworkCore;
using Task2.Interface;
using Task2.Models;

namespace Task2.Services
{
    public class HousesService : IHousesService
    {
        private readonly EstateContext _context;

        public HousesService(EstateContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<House>> GetHousesAsync()
        {
            return await _context.Houses.ToListAsync();
        }

        public async Task<House> GetHouseAsync(int id)
        {
            return await _context.Houses.FindAsync(id);
        }

        public async Task<int> CreateHouseAsync(HouseDto houseDto)
        {
            var house = new House
            {
                Number = houseDto.Number,
                Street = houseDto.Street,
                City = houseDto.City,
                Country = houseDto.Country,
                Postcode = houseDto.Postcode
                
            };

            _context.Houses.Add(house);
            await _context.SaveChangesAsync();

            return house.Id;
        }
        public async Task<bool> UpdateHouseAsync(int id, HouseDto houseDto)
        {
            var house = await _context.Houses.FindAsync(id);

            if (house == null)
                return false;

            house.Number = houseDto.Number;
            house.Street = houseDto.Street;
            house.City = houseDto.City;
            house.Country = houseDto.Country;
            house.Postcode = houseDto.Postcode;

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
