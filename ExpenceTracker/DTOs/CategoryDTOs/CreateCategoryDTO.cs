namespace ExpenceTracker.DTOs.CategoryDTOs
{
    public record CreateCategoryDTO
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }
    }
}
