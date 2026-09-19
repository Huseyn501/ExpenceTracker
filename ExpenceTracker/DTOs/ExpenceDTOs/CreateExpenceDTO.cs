namespace ExpenceTracker.DTOs.ExpenceDTOs
{
    public record CreateExpenceDTO
    {
        public decimal  Price { get; set; }
        public string Title { get; set; }

         public int CategoryId { get; set; }

        public DateTime dateTime { get; set; }

        
    }
}
