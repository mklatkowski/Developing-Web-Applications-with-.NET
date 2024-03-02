using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab11Project.Data;
using Lab11Project.Models;

namespace Lab11Project.Pages.Shop
{
    public class CategoryModel : PageModel
    {
        private readonly RP_ShopDbContext _context;

        public CategoryModel(RP_ShopDbContext context)
        {
            _context = context;
        }

        public Category Category { get; set; }
        public IList<Article> Articles { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Categories.FindAsync(id);

            if (Category == null)
            {
                return NotFound();
            }

            Articles = await _context.Articles
                .Where(a => a.CategoryId == id)
                .ToListAsync();

            return Page();
        }
    }
}
