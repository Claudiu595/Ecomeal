using System.Net.Http.Json;
using EcoMeal.Client.Models;

namespace EcoMeal.Client.Services;

public class BusinessService
{
    private readonly HttpClient _http;

    public BusinessService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<BusinessModel>?> GetAllAsync()
    {
        return await _http.GetFromJsonAsync<List<BusinessModel>>("api/business");
    }

    public async Task<BusinessDetailsModel?> GetOneById(int id)
    {
        return await _http.GetFromJsonAsync<BusinessDetailsModel>($"api/business/{id}");
    }

    public async Task<List<BusinessTypeModel>> GetBusinessTypes()
{
    var types = await _http.GetFromJsonAsync<List<BusinessTypeModel>>("api/businesstype"); 
    return types ?? new List<BusinessTypeModel>();
}

    public async Task<bool> AddAsync(BusinessAddModel business)
    {
        var response = await _http.PostAsJsonAsync("api/business", business);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> EditAsync(int id, BusinessAddModel business)
    {
        var response = await _http.PutAsJsonAsync($"api/business/{id}", business);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _http.DeleteAsync($"api/business/{id}");
        return response.IsSuccessStatusCode;
    }
}