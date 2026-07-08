using System.Data.SqlTypes;
using Ecomeal.API.Models;
using ecomea.api.Entities;
using EcoMeal.API.Entities;
using EcoMeal.API.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecomeal.Backend.Application;
[ApiController]
[Route("api/[controller]")]
public class BusinessController : ControllerBase
{
    private readonly EcoMealDbContext _context;

    public BusinessController(EcoMealDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BusinessDTO>>> GetAll()
    {
        var businessesDTOs = await _context.Business
            .Include(b => b.BusinessType)
            .Select(b => new BusinessDTO
            {
            ID = b.ID,
            Name = b.Name,
            Adress = b.Adress,
            Description = b.Description,
            Contact = b.Contact,
            BusinessTypeName = b.BusinessType.Name
        }).ToListAsync();
            return Ok(businessesDTOs);
    }
    [HttpDelete("{ID}")]
    public async Task<IActionResult> Delete(int ID)
    {
        var business = await _context.Business.FindAsync(ID);
        if(business is null)
        {
            return NotFound();
        }
        _context.Business.Remove(business);
        await _context.SaveChangesAsync();
        return NoContent();
    }


[HttpGet("{ID}")]
    public async Task<ActionResult<BusinessDetailsDTO>> GetOneById(int ID)
    {
        var business = await _context.Business
            .Include(b => b.Packages)
            .Select(b => new BusinessDetailsDTO
            {
                ID = b.ID,
                Name = b.Name,
                Adress = b.Adress,
                Description = b.Description,
                Contact = b.Contact,
                BusinessTypeName = b.BusinessType.Name,
            })
            .FirstOrDefaultAsync(b => b.ID == ID);
        if (business is null)
        {
            return NotFound();
        }

        return Ok(business);
    }
    [HttpGet("{ID}/packageTypes")]
    public async Task<ActionResult<IEnumerable<PackageType>>> GetPackageTypesForBusiness([FromRoute(Name = "ID")] int ID)
    {
        var business = await _context.Business
            .Include(b => b.BusinessType)
            .FirstOrDefaultAsync(b => b.ID == ID);

        if (business is null)
        {
            return NotFound();
        }

        var packageTypes = GetPackageTypeOptionsForBusinessType(business.BusinessType.Name);
        return Ok(packageTypes);
    }

    private static List<PackageType> GetPackageTypeOptionsForBusinessType(string businessTypeName)
    {
        var normalizedName = businessTypeName?.Trim().ToLowerInvariant() ?? string.Empty;

        if (normalizedName.Contains("fast") || normalizedName.Contains("burger") || normalizedName.Contains("pizza"))
        {
            return
            [
                new PackageType { ID = 1, Name = "Pizza margherita" },
                new PackageType { ID = 2, Name = "Pizza pepperoni" },
                new PackageType { ID = 3, Name = "Pizza veggie" }
            ];
        }

        if (normalizedName.Contains("patis") || normalizedName.Contains("cofet") || normalizedName.Contains("baker") || normalizedName.Contains("bakery"))
        {
            return
            [
                new PackageType { ID = 1, Name = "Pachet simplu" },
                new PackageType { ID = 2, Name = "Pachet de dimineata" },
                new PackageType { ID = 3, Name = "Pachet de post" }
            ];
        }

        if (normalizedName.Contains("restaurant") || normalizedName.Contains("cafe") || normalizedName.Contains("bar") || normalizedName.Contains("grill"))
        {
            return
            [
                new PackageType { ID = 1, Name = "Menu de zi" },
                new PackageType { ID = 2, Name = "Menu degustare" },
                new PackageType { ID = 3, Name = "Menu premium" }
            ];
        }

        return
        [
            new PackageType { ID = 1, Name = "Meniu local" },
            new PackageType { ID = 2, Name = "Meniu vegetarian" },
            new PackageType { ID = 3, Name = "Meniu premium" }
        ];
    }

    [HttpPost("{ID}/addPackage")]
    public async Task<IActionResult> AddPackageToBusiness([FromRoute(Name = "ID")] int ID,[FromBody]PackageAddDTO package)
    {
        _context.Package.Add(new Package
        {
            Name = package.Name,
            Description = package.Description,
            Price = package.Price,
            StartPickUp = package.StartPickup,
            EndPickUp = package.EndPickup,
            PackageType = package.PackageTypeId,
            BusinessID = ID,
            NoPackage = 1
        });
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetOneById), new { ID }, new { message = "Package created successfully." });
    }
}