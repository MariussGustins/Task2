using Microsoft.EntityFrameworkCore;
using Task2.Interface;
using Task2.Models;
using Task2.DTOs;
using AutoMapper;

namespace Task2.Services
{
    public class ApartmentService : IApartmentService
    {
        private readonly EstateContext _context;
        private readonly IMapper _mapper;

        public ApartmentService(EstateContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<ApartmentDto>> GetApartmentsAsync()
        {
            var apartments = await _context.Apartments.ToListAsync();
            return _mapper.Map<IEnumerable<ApartmentDto>>(apartments);
        }
        public async Task<IEnumerable<ApartmentDto>> GetApartmentsByHouseIdAsync(int houseId)
        {
            var apartments = await _context.Apartments
                .Where(a => a.HouseId == houseId)
                .ToListAsync();
            return _mapper.Map<IEnumerable<ApartmentDto>>(apartments);
        }

        public async Task<ApartmentDto> GetApartmentAsync(int id)
        {
            var apartment = await _context.Apartments.FindAsync(id);
            return _mapper.Map<ApartmentDto>(apartment);
        }

        public async Task<int> CreateApartmentAsync(ApartmentDto apartmentDto)
        {
            var apartment = _mapper.Map<Apartment>(apartmentDto);

            _context.Apartments.Add(apartment);
            await _context.SaveChangesAsync();

            return apartment.Id;
        }

        public async Task<bool> UpdateApartmentAsync(int id, ApartmentDto apartmentDto)
        {
            var apartment = await _context.Apartments.FindAsync(id);

            if (apartment == null)
                return false;

            _mapper.Map(apartmentDto, apartment);

            _context.Entry(apartment).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteApartmentAsync(int id)
        {
            var apartment = await _context.Apartments.FindAsync(id);

            if (apartment == null)
                return false;

            _context.Apartments.Remove(apartment);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ApartmentExistsAsync(int id)
        {
            return await _context.Apartments.AnyAsync(e => e.Id == id);
        }
        public async Task UpdatePrimaryResidentsAsync()
        {
            var apartments = await _context.Apartments.ToListAsync();

            foreach (var apartment in apartments)
            {
                var primaryResident = await _context.Residents
                    .FirstOrDefaultAsync(r => r.IsOwner && r.ApartmentId == apartment.Id);

                if (primaryResident != null)
                {
                    apartment.PrimaryResidentId = primaryResident.Id;
                }
                else
                {
                    apartment.PrimaryResidentId = null; 
                }
            }

            await _context.SaveChangesAsync();
        }
        public async Task<ApartmentDto> GetApartmentByUserEmailAsync(string userEmail)
        {
            var resident = await _context.Residents
                .Include(r => r.Apartment)
                .FirstOrDefaultAsync(r => r.User.Email == userEmail);

            if (resident == null || resident.Apartment == null)
            {
                return null;
            }

            return _mapper.Map<ApartmentDto>(resident.Apartment);
        }
    }
}
