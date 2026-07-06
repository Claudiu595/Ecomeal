using System.Data.SqlTypes;
using ecomea.api.Entities;
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
}