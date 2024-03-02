using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace List10Csharp.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Article>? Articles { get; set; }

    }
}
