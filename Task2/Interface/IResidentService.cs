using Task2.Models;

namespace Task2.Interface
{
    public interface IResidentService
    {
        Task<IEnumerable<Resident>> GetResidentsAsync();
        Task<Resident> GetResidentAsync(int id);
        Task<int> CreateResidentAsync(ResidentDto residentDto);
        Task<bool> UpdateResidentAsync(int id, ResidentDto residentDto);
        Task<bool> DeleteResidentAsync(int id);
        Task <bool> ResidentExistsAsync(int id);
    }
}
