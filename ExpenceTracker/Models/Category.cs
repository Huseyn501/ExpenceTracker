using ExpenceTracker.Entities;

namespace ExpenceTracker.Models
{
    public class Category
    {
         public int Id { get; set; }
        public string CategoryName { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public List<Expence> Expences { get; set; } = new();
    }
}
