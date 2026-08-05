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
        using var content = BuildFormContent(business);
        var response = await _http.PostAsync("api/business", content);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> EditAsync(int id, BusinessAddModel business)
    {
        using var content = BuildFormContent(business);
        var response = await _http.PutAsync($"api/business/{id}", content);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _http.DeleteAsync($"api/business/{id}");
        return response.IsSuccessStatusCode;
    }

    private static FormUrlEncodedContent BuildFormContent(BusinessAddModel business)
    {
        var fields = new List<KeyValuePair<string, string>>
        {
            new(nameof(business.Name), business.Name),
            new(nameof(business.Address), business.Address),
            new(nameof(business.Contact), business.Contact),
            new(nameof(business.BusinessTypeId), business.BusinessTypeId.ToString())
        };

        if (!string.IsNullOrEmpty(business.Description))
        {
            fields.Add(new(nameof(business.Description), business.Description));
        }

        return new FormUrlEncodedContent(fields);
    }
}
