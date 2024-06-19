using Microsoft.EntityFrameworkCore;
using Task2.Interface;
using Task2.Models;

namespace Task2.Services
{
    public class ApartmentService: IApartmentService
    {
        private readonly EstateContext _context;

        public ApartmentService(EstateContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Apartment>> GetApartmentsAsync()
        {
            return await _context.Apartments.ToListAsync();
        }

        public async Task<Apartment> GetApartmentAsync(int id)
        {
            return await _context.Apartments.FindAsync(id);
        }

        public async Task<int> CreateApartmentAsync(ApartmentDto ApartmentDto)
        {
            var apartment = new Apartment
            {
                Number = ApartmentDto.Number,
                Floor = ApartmentDto.Floor,
                Rooms = ApartmentDto.Rooms,
                NumberOfResidents = ApartmentDto.NumberOfResidents,
                FullArea = ApartmentDto.FullArea,
                LivingArea = ApartmentDto.LivingArea,


            };
            _context.Apartments.Add(apartment);
            await _context.SaveChangesAsync();

            return apartment.Id;

        }

        public async Task<bool> UpdateApartmentAsync(int id, ApartmentDto apartmentDto)
        {
            var apartment = await _context.Apartments.FindAsync(id);

            if (apartment == null)
                return false;

            apartment.Number = apartmentDto.Number;
            apartment.Floor = apartmentDto.Floor;
            apartment.Rooms = apartmentDto.Rooms;
            apartment.NumberOfResidents = apartmentDto.NumberOfResidents;
            apartment.FullArea = apartmentDto.FullArea;
            apartment.LivingArea = apartmentDto.LivingArea;

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
    }
}
