using Task2.DTOs;

namespace Task2.Interface;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetUsersAsync();
    Task<int> CreateUserAsync(UserDto userDto);
    Task<UserDto> GetUserByUsernameAndPasswordAsync(string username, string password);
}