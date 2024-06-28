using Task2.Models;
using Task2.DTOs;

namespace Task2.Interface
{
    public interface IResidentService
    {
        Task<IEnumerable<ResidentDto>> GetResidentsAsync();
        Task<IEnumerable<ResidentDto>> GetResidentsByApartmentIdAsync(int apartmentId);
        Task<ResidentDto> GetResidentAsync(int id);
        Task<int> CreateResidentAsync(ResidentDto residentDto);
        Task<bool> UpdateResidentAsync(int id, ResidentDto residentDto);
        Task<bool> DeleteResidentAsync(int id);
        Task <bool> ResidentExistsAsync(int id);
    }
}
