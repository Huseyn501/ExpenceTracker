namespace ExpenceTracker.DTOs.UserDTOs
{
    public record AuthResponseDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }

        public string Token { get; set; }
    }
}
