using System.ComponentModel.DataAnnotations;

namespace EcoMeal.API.Entities;
public class PackageType{
    [Key]
    public int ID {get;set;}
    public required string Name{get;set;}
    public ICollection<Package> Packages {get;set;} = new List<Package>();
}