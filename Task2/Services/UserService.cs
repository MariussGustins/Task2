using Task2.Interface;
using Task2.Models;
using Task2.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Task2.Services;

public class UserService : IUserService
{
    private readonly EstateContext _context;
    private readonly IMapper _mapper;

    public UserService(EstateContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDto>> GetUsersAsync()
    {
        var users = await _context.Users.ToListAsync();
        return _mapper.Map<IEnumerable<UserDto>>(users);
    }

    public async Task<int> CreateUserAsync(UserDto userDto)
    {
        var userEntity = _mapper.Map<User>(userDto);

        _context.Users.Add(userEntity);
        await _context.SaveChangesAsync();

        return userEntity.Id;
    }
    public async Task<UserDto> GetUserByUsernameAndPasswordAsync(string username, string password)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

        return _mapper.Map<UserDto>(user);
    }
}