using System.ComponentModel.DataAnnotations;

namespace ecomea.api.Entities ;
public class Order{
    [Key]
    public int ID {get;set;}
    
    public int UserID{get;set;}
    public int PackageID{get;set;}
    public required string Status{get;set;}
    public required DateTime Date{get;set;}
}