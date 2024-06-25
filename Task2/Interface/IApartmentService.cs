// Task2/Interface/IApartmentService.cs

using System.Collections.Generic;
using System.Threading.Tasks;
using Task2.DTOs;

namespace Task2.Interface
{
    public interface IApartmentService
    {
        Task<IEnumerable<ApartmentDto>> GetApartmentsAsync();
        Task<ApartmentDto> GetApartmentAsync(int id);
        Task<int> CreateApartmentAsync(ApartmentDto apartmentDto);
        Task<bool> UpdateApartmentAsync(int id, ApartmentDto apartmentDto);
        Task<bool> DeleteApartmentAsync(int id);
        Task<bool> ApartmentExistsAsync(int id);
        
        Task UpdatePrimaryResidentsAsync();
    }
}