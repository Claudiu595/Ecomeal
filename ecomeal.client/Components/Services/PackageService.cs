using System.Globalization;
using System.Net.Http.Json;
using EcoMeal.Client.Models;

namespace EcoMeal.Client.Services;

public class PackageService
{
    private readonly HttpClient _http;

    public PackageService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<PackageTypeModel>> GetPackageTypes()
    {
        var types = await _http.GetFromJsonAsync<List<PackageTypeModel>>("api/packagetype");
        return types ?? new List<PackageTypeModel>();
    }

    public async Task<List<PackageGetModel>> GetByBusinessId(int businessId)
    {
        var packages = await _http.GetFromJsonAsync<List<PackageGetModel>>($"api/business/{businessId}/package");
        return packages ?? new List<PackageGetModel>();
    }

    public async Task<PackageGetModel?> GetById(int businessId, int packageId)
    {
        var packages = await GetByBusinessId(businessId);
        return packages.FirstOrDefault(p => p.Id == packageId);
    }

    public async Task<bool> AddAsync(int businessId, PackageAddModel package)
    {
        using var content = BuildFormContent(package);
        var response = await _http.PostAsync($"api/business/{businessId}/package", content);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> EditAsync(int businessId, int packageId, PackageAddModel package)
    {
        using var content = BuildFormContent(package);
        var response = await _http.PutAsync($"api/business/{businessId}/package/{packageId}", content);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int businessId, int packageId)
    {
        var response = await _http.DeleteAsync($"api/business/{businessId}/package/{packageId}");
        return response.IsSuccessStatusCode;
    }

    private static FormUrlEncodedContent BuildFormContent(PackageAddModel package)
    {
        var fields = new List<KeyValuePair<string, string>>
        {
            new(nameof(package.Name), package.Name),
            new(nameof(package.Description), package.Description),
            new(nameof(package.Price), package.Price.ToString(CultureInfo.InvariantCulture)),
            new(nameof(package.NoPackages), package.NoPackages.ToString(CultureInfo.InvariantCulture)),
            new("StartPickup", package.StartPickup.ToString("o", CultureInfo.InvariantCulture)),
            new("EndPickup", package.EndPickup.ToString("o", CultureInfo.InvariantCulture)),
            new(nameof(package.PackageTypeId), package.PackageTypeId.ToString(CultureInfo.InvariantCulture))
        };

        return new FormUrlEncodedContent(fields);
    }
}
