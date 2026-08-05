namespace EcoMeal.Api.Models
{
    public class BusinessDetailsDTO : BusinessDTO
    {
        public required IEnumerable<PackageDTO> Packages { get; set; }
    }
}