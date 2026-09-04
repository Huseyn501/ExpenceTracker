using ExpenceTracker.Entities;

namespace ExpenceTracker.Models
{
    public class User
    {
        public  int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public List<Category> Categories { get; set; } = new();
        public List<Expence> Expences { get; set; } = new();
    }
}
