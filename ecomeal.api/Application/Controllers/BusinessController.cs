using System.Data.SqlTypes;
using Ecomeal.API.Models;
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


[HttpGet("{id}")]
    public async Task<ActionResult<BusinessDetailsDTO>> GetOneById(int id)
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
            .FirstOrDefaultAsync(b => b.ID == id);
        if (business is null)
        {
            return NotFound();
        }

        return Ok(business);
    }
    [HttpPost]
    [Route("{id}/addPackage")]
    public async Task<IActionResult> AddPackageToBusiness(int ID,[FromBody]PackageAddDTO package)
    {
        _context.Package.Add(new Package
        {
            Description = package.Description,
            Price = package.Price,
            StartPickUp = package.StartPickup,
            EndPickUp = package.EndPickup,
            PackageType = package.PackageTypeId,
            BusinessID = ID,
            NoPackage = 1
        });
        await _context.SaveChangesAsync();
        return Ok();
    }
}