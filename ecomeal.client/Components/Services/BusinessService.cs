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
    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _http.DeleteAsync($"api/business/{id}");
        return response.IsSuccessStatusCode;
    }
    public async Task<BusinessDetailsModel?> GetById(int id)
    {
        var business = await _http.GetFromJsonAsync<BusinessDetailsModel>($"api/business/{id}");
        return business;
    }
    public async Task AddPackage(int businessId, PackageAddModel package)
    {
        await _http.PostAsJsonAsync($"api/business/{businessId}/AddPackage", package);
    }
}