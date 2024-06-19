using Task2.Models;
using Task2.Interface;

namespace Task2.Interface
{
    public interface IHousesService
    {
        Task<IEnumerable<House>> GetHousesAsync();
        Task<House> GetHouseAsync(int id);
        Task<int> CreateHouseAsync(HouseDto houseDto);
        Task<bool> UpdateHouseAsync(int id, HouseDto houseDto);
        Task<bool> DeleteHouseAsync(int id);

        Task<bool> HouseExistsAsync(int id);
    }


}
