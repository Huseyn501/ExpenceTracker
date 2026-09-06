using ExpenceTracker.Entities;
using System.Text.Json.Serialization;

namespace ExpenceTracker.Models
{
    public class User
    {
        public string Id { get; set; }  = Guid.NewGuid().ToString();
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        [JsonIgnore]
        public List<Category> Categories { get; set; } = new();
        [JsonIgnore]
        public List<Expence> Expences { get; set; } = new();
    }
}
