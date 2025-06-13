using System.ComponentModel.DataAnnotations;

namespace BananaStore.Models
{
    public class Banana
    {
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public Guid Box_ID { get; set; }
        [MinLength(5), MaxLength(255)]
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool Expired => (DateTime.UtcNow - CreatedAt).TotalDays > 7;
        public double Price => Math.Round(10.00 * Math.Max(1 - (DateTime.UtcNow - CreatedAt).TotalDays / 7 * (1 - 0.5), 0.5),2);
    }
}
