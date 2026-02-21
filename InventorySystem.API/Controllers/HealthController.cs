using InventorySystem.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.API.Controllers;

[ApiController]
[Route("api/health")]
public class HealthController : ControllerBase
{
    [HttpGet("db")]
    public async Task<IActionResult> Db([FromServices] OracleDbContext db)
    {
        var ok = await db.Database.CanConnectAsync();
        return Ok(new { ok });
    }
}