using EcoMeal.Site.Models;
using EcoMeal.Site.Services;
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
        var success = await BusinessService.DeleteAsync(Business.ID);

        if (success)
        {
            await OnDeleteRequested.InvokeAsync(Business.ID);
        }
    }
    public void NavigateToDetails()
    {
        NavigationManager.NavigateTo($"/business/{Business.ID}");
    }

}