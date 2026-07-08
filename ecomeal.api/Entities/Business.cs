using System.ComponentModel.DataAnnotations;
namespace EcoMeal.API.Entities;
public class Business{
    [Key]
    public int ID {get;set;}
    
    public required string Name{get;set;}
    public required string Adress{get;set;}
    public string? Description{get;set;}
    public required string Contact {get;set;}
    public int BusinessTypeID{get;set;}
    public required BusinessType BusinessType{get;set;}
    public required ICollection<Package> Packages{get;set;}
}