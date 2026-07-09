namespace EcoMeal.API.Entities;
public class User
{
    public int ID {get;set;}
    public required string Name{get;set;}
    public required string Contact{get;set;}
    public ICollection<Order> Orders {get;set;} = new List<Order>();
    
}