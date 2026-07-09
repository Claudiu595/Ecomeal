using EcoMeal.Client.Models; // Modificat din Site în Client
using EcoMeal.Client.Services; // Modificat din Site în Client
using Microsoft.AspNetCore.Components;

namespace EcoMeal.Site.Components.BusinessCard;

public partial class BusinessCard
{
    [Parameter]
    public required BusinessModel Business { get; set; }

    [Inject]
    public required BusinessService BusinessService { get; set; }

    [Parameter]
    public EventCallback<int> OnDeleteRequested { get; set; }
    
    [Inject]
    public required NavigationManager NavigationManager { get; set; }

    private async Task DeleteClick()
    {
        // Folosim Business.Id (cu "d" mic)
        var success = await BusinessService.DeleteAsync(Business.Id); 

        if (success)
        {
            await OnDeleteRequested.InvokeAsync(Business.Id);
        }
    }
    public void NavigateToDetails()
    {
        NavigationManager.NavigateTo($"/business/{Business.Id}");
    }
}