using System;

namespace EcoMeal.Client.Services
{
    public class SearchService
    {
        public string SearchTerm { get; private set; } = string.Empty;
        public event Action<string>? OnSearchChanged;

        public void UpdateSearch(string term)
        {
            SearchTerm = term;
            OnSearchChanged?.Invoke(term);
        }
    }
}