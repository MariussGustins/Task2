using Task2.Models;

namespace Task2.Interface
{
    public interface IApartmentService
    {
        Task<IEnumerable<Apartment>> GetApartmentsAsync();
        Task<Apartment> GetApartmentAsync(int id);
        Task<int> CreateApartmentAsync(ApartmentDto apartmentDto);
        Task<bool> UpdateApartmentAsync(int id, ApartmentDto apartmentDto);
        Task<bool> DeleteApartmentAsync(int id);
        
        Task<bool> ApartmentExistsAsync(int id);
    }
}
