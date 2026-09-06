namespace ExpenceTracker.DTOs.ExpenceDTOs
{
    public record UpdateExpenceDTO
    {
        public string Title { get; set; }
        public decimal Price { get; set; }

        public DateTime dateTime { get; set; }

        public int CategoryId { get; set; }
    }
}
