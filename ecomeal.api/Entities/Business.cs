using System.ComponentModel.DataAnnotations;

namespace ecomea.api.Entities ;
public class Business{
    [Key]
    public int ID {get;set;}
    
    public required string Name{get;set;}
    public required string Adress{get;set;}
    public string? Description{get;set;}
    public required string Contact {get;set;}
    public int BusinessTypeID{get;set;}
    public required BusinessType BusinessType{get;set;}
}