using System.Runtime.CompilerServices;
using Ecomeal.Site.Models;
using EcoMeal.Site.Models;

namespace Ecomeal.Site.Services;
public class BusinessService
{
    private readonly HttpClient _http;
    public BusinessService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<BusinessModel>> GetAllAsync()
    {
        
        var business = await _http.GetFromJsonAsync<List<BusinessModel>>("/api/business");
        return business ?? new List<BusinessModel>();
    }
    public async Task<bool> DeleteAsync(int ID)
    {
        var response = await _http.DeleteAsync($"api/business/{ID}");
        return response.IsSuccessStatusCode;
    }
    public async Task<BusinessDetailsModel?> GetById(int ID)
    {
        var business = await _http.GetFromJsonAsync<BusinessDetailsModel>($"api/business/{ID}");
        return business;
    }
    public async Task<List<PackageTypeModel>> GetPackageTypesAsync(int businessId)
    {
        var packageTypes = await _http.GetFromJsonAsync<List<PackageTypeModel>>($"api/business/{businessId}/packageTypes");
        return packageTypes ?? new List<PackageTypeModel>();
    }

    public async Task<bool> AddPackage(int businessId, PackageAddModel package)
    {
        var payload = new
        {
            name = package.Name,
            description = package.Description,
            price = package.Price,
            startPickup = package.StartPickup,
            endPickup = package.EndPickup,
            packageTypeId = package.PackageTypeId
        };

        var response = await _http.PostAsJsonAsync($"api/business/{businessId}/addPackage", payload);
        return response.IsSuccessStatusCode;
    }
}