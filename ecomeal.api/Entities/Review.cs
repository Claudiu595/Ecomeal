namespace EcoMeal.Api.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public required User User { get; set; }
        public int OrderId { get; set; }
        public required Order Order { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}