using EcoMeal.Api.Entities;
using EcoMeal.Api.Infrastructure;
using EcoMeal.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EcoMeal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Protejează ruta ca doar userii logați să comande
    public class OrderController : ControllerBase
    {
        private readonly EcoMealDbContext _context;

        public OrderController(EcoMealDbContext context)
        {
            _context = context;
        }

        private int GetCurrentUserId()
        {
            // Extrage ID-ul userului direct din Token-ul de securitate
            var claim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (claim == null) return 0;
            return int.Parse(claim);
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder([FromBody] PlaceOrderRequest request)
        {
            var userId = GetCurrentUserId();
            if (userId == 0) return Unauthorized(); // Nu a recunoscut user-ul

            var order = new Order
            {
                UserId = userId,
                User = null!, 
                PackageId = request.PackageId,
                Package = null!, 
                Status = "Plasată", 
                Date = DateTime.Now
            };

            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("my")]
        public async Task<ActionResult<IEnumerable<OrderGetDTO>>> GetMyOrders()
        {
            var userId = GetCurrentUserId();

            var orders = await _context.Order
                .Include(o => o.Package)
                .ThenInclude(p => p.Business)
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.Date)
                .Select(o => new OrderGetDTO
                {
                    Id = o.Id,
                    Date = o.Date,
                    Status = o.Status,
                    Price = o.Package.Price,
                    BusinessId = o.Package.BusinessId,
                    BusinessName = o.Package.Business != null ? o.Package.Business.Name : "N/A",
                    PackageName = o.Package.Name
                })
                .ToListAsync();

            return Ok(orders);
        }
    }
}