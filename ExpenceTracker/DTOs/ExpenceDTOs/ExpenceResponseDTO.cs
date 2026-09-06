namespace ExpenceTracker.DTOs.ExpenceDTOs
{
    public record ExpenceResponseDTO
    {
        public int Id { get; set; }
        public decimal Price { get; set; }

        public string Title { get; set; }

        public DateTime dateTime { get; set; }

        public string UserId { get; set; }

    }
}
