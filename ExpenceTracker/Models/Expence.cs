using ExpenceTracker.Models;

namespace ExpenceTracker.Entities
{
    public class Expence
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public decimal Price { get; set; }

        public DateTime dateTime { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
