using System.ComponentModel.DataAnnotations.Schema;

namespace EcoMeal.API.Models;
public class BusinessDTO{
    
    public int ID {get;set;}
    
    public required string Name{get;set;}
    public required string Adress{get;set;}
    public string? Description{get;set;}
    public required string Contact {get;set;}
    public required string BusinessTypeName{get;set;}
}