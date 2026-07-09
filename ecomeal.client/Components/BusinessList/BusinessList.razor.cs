using Microsoft.AspNetCore.Components;
using EcoMeal.Client.Models;
using EcoMeal.Client.Services;

namespace EcoMeal.Client.Components.BusinessList
{
    public partial class BusinessList : ComponentBase, IDisposable
    {
        [Inject] public required BusinessService BusinessService { get; set; }
        [Inject] public required SearchService SearchService { get; set; }
        [Inject] public required NavigationManager NavigationManager { get; set; }

        public List<BusinessModel>? Businesses { get; private set; }
        private List<BusinessModel>? AllBusinesses { get; set; }

        protected override async Task OnInitializedAsync()
        {
            AllBusinesses = await BusinessService.GetAllAsync();
            SearchService.OnSearchChanged += ApplyFilter;
            ApplyFilter(SearchService.SearchTerm);
        }

        private void ApplyFilter(string query)
        {
            if (AllBusinesses == null) return;
            Businesses = string.IsNullOrWhiteSpace(query) ? AllBusinesses 
                : AllBusinesses.Where(b => b.Name.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
            StateHasChanged();
        }

        public async Task HandleDelete(int id)
        {
            if (await BusinessService.DeleteAsync(id))
            {
                AllBusinesses = await BusinessService.GetAllAsync();
                ApplyFilter(SearchService.SearchTerm);
            }
        }

        public void Dispose() => SearchService.OnSearchChanged -= ApplyFilter;
    }
}