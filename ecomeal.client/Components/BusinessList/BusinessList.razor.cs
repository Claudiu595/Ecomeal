using Ecomeal.Site.Models;
using Ecomeal.Site.Services;
using Microsoft.AspNetCore.Components;

namespace Ecomeal.Site.Components.BusinessList;

public partial class BusinessList
{
    [Inject]
    public required BusinessService BusinessService { get; set; }

    private List<BusinessModel>? Businesses { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Businesses = await BusinessService.GetAllAsync();
    }

    private void HandleDelete(int id)
    {
        if (Businesses is null)
        {
            return;
        }

        Businesses = Businesses
            .Where(b => b.ID != id)
            .ToList();

        StateHasChanged();
    }
}
