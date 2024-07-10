using Microsoft.EntityFrameworkCore;
using Task2.Interface;
using Task2.Models;
using Task2.DTOs;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace Task2.Services
{
    public class ResidentsService : IResidentService
    {
        private readonly EstateContext _context;
        private readonly IMapper _mapper;

        public ResidentsService(EstateContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResidentDto>> GetResidentsByApartmentIdAsync(int apartmentId)
        {
            var residents = await _context.Residents
                .Where(r => r.ApartmentId == apartmentId)
                .ToListAsync();
            return _mapper.Map<IEnumerable<ResidentDto>>(residents);
        }

        public async Task<IEnumerable<ResidentDto>> GetResidentsAsync()
        {
            var residents = await _context.Residents.ToListAsync();
            return _mapper.Map<IEnumerable<ResidentDto>>(residents);
        }

        public async Task<ResidentDto> GetResidentAsync(int id)
        {
            var resident = await _context.Residents.FindAsync(id);
            return _mapper.Map<ResidentDto>(resident);
        }

        public async Task<int> CreateResidentAsync(ResidentDto residentDto)
        {
            string username = $"{residentDto.Name}{residentDto.LastName}";
            string password = GeneratePassword();

            var user = new User
            {
                Username = username,
                Password = password
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var residentEntity = _mapper.Map<Resident>(residentDto);
            residentEntity.UserId = user.Id;

            _context.Residents.Add(residentEntity);
            await _context.SaveChangesAsync();

            return residentEntity.Id;
        }

        public async Task CreateUsersForResidentsAsync()
        {
            var residents = await _context.Residents.ToListAsync();

            foreach (var resident in residents)
            {
                if (resident.UserId == null)
                {
                    var username = $"{resident.Name}{resident.LastName}";
                    var password = GeneratePassword();
                    var email = resident.Email; // Fetch email from Resident entity

                    var user = new User
                    {
                        Username = username,
                        Password = password,
                        Email = email // Set email for User entity
                    };

                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();

                    resident.UserId = user.Id;
                    _context.Entry(resident).State = EntityState.Modified;
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateResidentAsync(string id, ResidentDto residentDto)
        {
            // Parse the ID to the appropriate type (e.g., int, Guid) based on your implementation
            // For example, if your Resident ID is an integer:
            if (!int.TryParse(id, out int residentId))
            {
                throw new ArgumentException("Invalid resident ID format.");
            }

            var resident = await _context.Residents.FindAsync(residentId);

            if (resident == null)
                return false;

            _mapper.Map(residentDto, resident);

            _context.Entry(resident).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<bool> DeleteResidentAsync(int id)
        {
            var resident = await _context.Residents.FindAsync(id);

            if (resident == null)
                return false;

            _context.Residents.Remove(resident);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ResidentExistsAsync(int id)
        {
            return await _context.Residents.AnyAsync(e => e.Id == id);
        }
        public async Task UpdateUsersWithEmailsFromResidentsAsync()
        {
            var residents = await _context.Residents.ToListAsync();

            foreach (var resident in residents)
            {
                if (resident.UserId != null && string.IsNullOrEmpty(resident.User.Email))
                {
                    var user = await _context.Users.FindAsync(resident.UserId);

                    if (user != null)
                    {
                        user.Email = resident.Email;
                        _context.Entry(user).State = EntityState.Modified;
                    }
                }
            }

            await _context.SaveChangesAsync();
        }

        private string GeneratePassword()
        {
            return "DefaultPassword123"; // Implement your password generation logic
        }
        
        public async Task<ResidentDto> GetResidentByEmailAsync(string email)
        {
            var resident = await _context.Residents.FirstOrDefaultAsync(r => r.Email == email);
            return _mapper.Map<ResidentDto>(resident);
        }
        public async Task<IEnumerable<ResidentDto>> GetResidentsByApartmentIdAndEmailAsync(int apartmentId, string email)
        {
            var residents = await _context.Residents
                .Where(r => r.ApartmentId == apartmentId && r.Email == email)
                .ToListAsync();

            return _mapper.Map<IEnumerable<ResidentDto>>(residents);
        }
        // public async Task UpdateResidentsWithUserPasswordsAsync()
        // {
        //     var residents = await _context.Residents.ToListAsync();
        //
        //     foreach (var resident in residents)
        //     {
        //         if (resident.UserId != null)
        //         {
        //             var user = await _context.Users.FindAsync(resident.UserId);
        //
        //             if (user != null && !string.IsNullOrEmpty(user.Password))
        //             {
        //                 resident.Password = user.Password; 
        //                 _context.Entry(resident).State = EntityState.Modified;
        //             }
        //         }
        //     }
        //
        //     await _context.SaveChangesAsync();
        // }

    }
}
