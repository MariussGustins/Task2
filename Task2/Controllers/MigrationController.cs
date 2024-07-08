using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Task2.Services;

namespace Task2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MigrationController : ControllerBase
    {
        private readonly MigrationService _migrationService;

        public MigrationController(MigrationService migrationService)
        {
            _migrationService = migrationService;
        }

        [HttpPost("migrate-residents-to-users")]
        public async Task<IActionResult> MigrateResidentsToUsers()
        {
            await _migrationService.MigrateResidentsToUsersAsync();
            return Ok(new { message = "Migration completed" });
        }
    }
}
