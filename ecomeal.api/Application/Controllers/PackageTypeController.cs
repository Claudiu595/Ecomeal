using EcoMeal.API.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcoMeal.Api.Models;

namespace EcoMeal.API.Controllers;

[Route("api/packagetype")]
[ApiController]
public class PackageTypeController : ControllerBase
{
    private readonly EcoMealDbContext _context;

    public PackageTypeController(EcoMealDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PackageTypeDTO>>> GetAllTypes()
    {
        var types = await _context.PackageType
            .OrderBy(t => t.ID)
            .Select(t => new PackageTypeDTO
            {
                ID = t.ID,
                Name = t.Name
            })
            .ToListAsync();

        return Ok(types);
    }
}