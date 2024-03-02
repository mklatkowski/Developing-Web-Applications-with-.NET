using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab11Project.Data;
using Lab11Project.Models;

namespace Lab11Project.Pages.Shop
{
    public class IndexModel : PageModel
    {
        private readonly RP_ShopDbContext _context;

        public IndexModel(RP_ShopDbContext context)
        {
            _context = context;
        }

        public IList<Category> Categories { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Categories = await _context.Categories.ToListAsync();
            return Page();
        }
    }
}
