
namespace EcoMeal.API.Models;
public class BusinessDetailsDTO : BusinessDTO
{
public List<PackageDTO> Packages { get; set; } = new();
}