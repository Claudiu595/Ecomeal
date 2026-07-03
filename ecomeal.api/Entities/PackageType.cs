using System.ComponentModel.DataAnnotations;

namespace ecomea.api.Entities ;
public class PackageType{
    [Key]
    public int ID {get;set;}
    public required string Name{get;set;}
}