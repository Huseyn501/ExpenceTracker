namespace ExpenceTracker.DTOs.UserDTOs
{
    public record LoginDto
    {
        public string Email { get; set; }
        public string Passoword { get; set; }
    }
}
