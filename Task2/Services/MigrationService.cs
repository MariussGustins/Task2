using Microsoft.EntityFrameworkCore;
using Task2.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.Scripting;

namespace Task2.Services
{
    public class MigrationService
    {
        private readonly EstateContext _context;

        public MigrationService(EstateContext context)
        {
            _context = context;
        }

        public async Task MigrateResidentsToUsersAsync()
        {
            var residents = await _context.Residents
                .Where(r => r.UserId == null)
                .ToListAsync();

            foreach (var resident in residents)
            {
                string username = $"{resident.Name}{resident.LastName}";
                string password = GeneratePassword();

                var user = new User
                {
                    Username = username,
                    Password = password
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                resident.UserId = user.Id;

                _context.Entry(resident).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            
        }

        private string GeneratePassword()
        {
          
            return "DefaultPassword123"; 
        }

    }
}
