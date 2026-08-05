namespace EcoMeal.Client.Models
{
    public class OrderResult
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }

        public static OrderResult Ok() => new() { Success = true };
        public static OrderResult Fail(string message) => new() { Success = false, ErrorMessage = message };
    }
}
