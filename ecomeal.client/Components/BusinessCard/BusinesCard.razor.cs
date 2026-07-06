using Ecomeal.Site.Models;
using Ecomeal.Site.Services;
using Microsoft.AspNetCore.Components;

namespace Ecomeal.Site.Components.BusinessCard;

public partial class BusinessCard
{
    [Parameter]
    public required BusinessModel Business { get; set; }

    [Inject]
    public required BusinessService BusinessService { get; set; }

    [Parameter]
    public EventCallback<int> OnDeleteRequested { get; set; }

    private async Task DeleteClick()
    {
        var success = await BusinessService.DeleteAsync(Business.ID);

        if (success)
        {
            await OnDeleteRequested.InvokeAsync(Business.ID);
        }
    }
}