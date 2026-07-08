using Ecomeal.Site.Models;
using Ecomeal.Site.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;

namespace Ecomeal.Site.Components.BusinessList;

public partial class BusinessList
{
    [Inject]
    public required BusinessService BusinessService { get; set; }

    [Inject]
    public required NavigationManager NavigationManager { get; set; }

    private List<BusinessModel>? Businesses { get; set; }
    private List<BusinessModel>? AllBusinesses { get; set; }
    private string SearchText { get; set; } = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        AllBusinesses = await BusinessService.GetAllAsync();
        ApplyFilter();
    }

    protected override void OnParametersSet()
    {
        SearchText = GetSearchText();
        ApplyFilter();
    }

    private string GetSearchText()
    {
        var uri = NavigationManager.ToAbsoluteUri(NavigationManager.Uri);
        if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("search", out var value))
        {
            return value.ToString() ?? string.Empty;
        }

        return string.Empty;
    }

    private void ApplyFilter()
    {
        if (AllBusinesses is null)
        {
            Businesses = null;
            return;
        }

        var query = SearchText.Trim();
        if (string.IsNullOrWhiteSpace(query))
        {
            Businesses = AllBusinesses;
            return;
        }

        Businesses = AllBusinesses
            .Where(b =>
                b.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                b.Adress.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                b.Description?.Contains(query, StringComparison.OrdinalIgnoreCase) == true ||
                b.Contact.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                b.BusinessTypeName.Contains(query, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    private void HandleDelete(int id)
    {
        if (Businesses is null)
        {
            return;
        }

        AllBusinesses = AllBusinesses?
            .Where(b => b.ID != id)
            .ToList();

        ApplyFilter();
        StateHasChanged();
    }
}
