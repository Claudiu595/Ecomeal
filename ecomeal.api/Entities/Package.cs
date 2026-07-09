using System.ComponentModel.DataAnnotations;

namespace EcoMeal.API.Entities; 
public class Package
{
    [Key]
    public int ID{get;set;}
    public required int NoPackage{get;set;}
    public required int BusinessID{get;set;}
    public Business? Business{get;set;}
    public required int PackageTypeID{get;set;}
    public EcoMeal.API.Entities.PackageType? PackageType{get;set;}
    public string Name { get; set; } = string.Empty;
    public string? Description{get;set;}
    public required int Price{get;set;}
    public required DateTime StartPickUp{get;set;}
    public required DateTime EndPickUp{get;set;}
    public ICollection<Order> Orders {get;set;} = new List<Order>();
}