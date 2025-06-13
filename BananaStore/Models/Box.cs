using System.ComponentModel.DataAnnotations;

namespace BananaStore.Models
{
    public class Box
    {
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();
        public List<Banana> Bananas = new();
        public string? HexColor { get; set; }
        public int Quantity => Bananas?.Count ?? 0;
        public double TotalPrice => Quantity * Bananas.Sum(b => b.Price);
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsFull => Quantity >= 5;
    }
}
