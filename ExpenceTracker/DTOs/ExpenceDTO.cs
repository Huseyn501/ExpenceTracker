namespace ExpenceTracker.DTOs
{
    public record ExpenceDTO
    {
        public int Id { get; set; }

        public string Title  { get; set; }

        public decimal Price { get; set; }



    }
}
