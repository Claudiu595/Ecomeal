using EcoMeal.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcoMeal.API.Infrastructure;

namespace EcoMeal.API.Application.Controllers;

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
                Description = b.Description ?? string.Empty,
                Contact = b.Contact,
                BusinessTypeName = b.BusinessType.Name
            })
            .ToListAsync();

        return Ok(businessesDTOs);
    }

    [HttpDelete("{ID}")]
    public async Task<IActionResult> Delete(int ID)
    {
        var business = await _context.Business.FindAsync(ID);
        if (business is null)
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
            .Include(b => b.BusinessType)
            .Include(b => b.Packages)
            .FirstOrDefaultAsync(b => b.ID == ID);

        if (business is null)
        {
            return NotFound();
        }

        var dto = new BusinessDetailsDTO
        {
            ID = business.ID,
            Name = business.Name,
            Adress = business.Adress,
            Description = business.Description ?? string.Empty,
            Contact = business.Contact,
            BusinessTypeName = business.BusinessType.Name,
            Packages = business.Packages.Select(p => new PackageDTO
            {
                ID = p.ID,
                Name = p.Name,
                Description = p.Description ?? string.Empty,
                Price = p.Price,
                StartPickup = p.StartPickUp,
                EndPickup = p.EndPickUp,
                PackageType = p.PackageTypeID
            }).ToList()
        };

        return Ok(dto);
    }

    [HttpPut("{ID}")]
    public async Task<IActionResult> EditBusiness(int ID, [FromBody] BusinessDTO business)
    {
        var existingBusiness = await _context.Business.FirstOrDefaultAsync(b => b.ID == ID);
        if (existingBusiness is null)
        {
            return NotFound();
        }

        existingBusiness.Name = business.Name;
        existingBusiness.Adress = business.Adress;
        existingBusiness.Description = business.Description;
        existingBusiness.Contact = business.Contact;

        await _context.SaveChangesAsync();
        return NoContent();
    }
}