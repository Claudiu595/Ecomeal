using EcoMeal.API.Infrastructure;
using EcoMeal.API.Entities;
using EcoMeal.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcoMeal.API.Controllers;

[ApiController]
[Route("api/business/{id}/package")]
public class PackageController : ControllerBase
{
    private readonly EcoMealDbContext _context;

    public PackageController(EcoMealDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> AddPackageToBusiness(int id, [FromBody] PackageAddDTO package)
    {
        _context.Package.Add(new Package
        {
            Name = package.Name,
            Description = package.Description,
            Price = package.Price,
            StartPickUp = package.StartPickup,
            EndPickUp = package.EndPickup,
            PackageTypeID = package.PackageTypeId,
            BusinessID = id,
            //Business = package.Business,
            NoPackage = 1
        });

        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAllPackages), new { id }, new { message = "Package created successfully." });
    }

    [HttpDelete("{packageId}")]
    public async Task<ActionResult> DeletePackage(int packageId)
    {
        var package = await _context.Package.FirstOrDefaultAsync(p => p.ID == packageId);
        if (package is null)
        {
            return NotFound("Couldn't find the package");
        }

        _context.Package.Remove(package);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpPut("{packageId}")]
    public async Task<IActionResult> EditPackage(int packageId, [FromBody] PackageAddDTO package)
    {
        var existingPackage = await _context.Package.FirstOrDefaultAsync(p => p.ID == packageId);
        if (existingPackage is null)
        {
            return NotFound("Couldn't find the package");
        }

        existingPackage.Name = package.Name;
        existingPackage.Description = package.Description;
        existingPackage.Price = package.Price;
        existingPackage.StartPickUp = package.StartPickup;
        existingPackage.EndPickUp = package.EndPickup;
        existingPackage.PackageTypeID = package.PackageTypeId;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<List<PackageDTO>>> GetAllPackages(int id)
    {
        var packages = await _context.Package
            .Where(p => p.BusinessID == id)
            .Select(p => new PackageDTO
            {
                ID = p.ID,
                Name = p.Name,
                Description = p.Description ?? string.Empty,
                Price = p.Price,
                StartPickup = p.StartPickUp,
                EndPickup = p.EndPickUp,
                PackageType = p.PackageTypeID
            })
            .ToListAsync();

        return Ok(packages);
    }
}