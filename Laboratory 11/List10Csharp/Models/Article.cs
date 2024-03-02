using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Routing.Constraints;

namespace List10Csharp.Models
{
    public class Article
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string? ImagePath { get; set; }
        [NotMapped]
        public IFormFile? Image {  get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public Category? Category { get; set; }
        public int CategoryId { get; set; } 
    }
}
