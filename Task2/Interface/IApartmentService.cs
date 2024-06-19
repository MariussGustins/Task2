using Task2.Models;

namespace Task2.Interface
{
    public interface IApartmentService
    {
        Task<IEnumerable<Apartment>> GetApartmentAsync();
        Task<Apartment> GetApartmentAsync(int id);
        Task<int> CreateApartmentAsync(ApartmentDto apartmentDto);
        Task<bool> UpdateApartmentAsync(int id, ApartmentDto apartmentDto);
        Task<bool> DeleteApartmentAsync(int id);
    }
}
