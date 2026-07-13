namespace EcoMeal.Client.Models
{
    public class OrderGetModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int BusinessId { get; set; }
        public string BusinessName { get; set; } = string.Empty;
        public string PackageName { get; set; } = string.Empty;
    }
}