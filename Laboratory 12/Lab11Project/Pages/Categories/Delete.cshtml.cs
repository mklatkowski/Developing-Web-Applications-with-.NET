using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab11Project.Data;
using Lab11Project.Models;

namespace Lab11Project.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly Lab11Project.Data.RP_ShopDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public DeleteModel(Lab11Project.Data.RP_ShopDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        [BindProperty]
        public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);

            if (category == null)
            {
                return NotFound();
            }
            else
            {
                Category = category;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);

            var shopDBContext = _context.Articles.Include(a => a.Category);
            var articles = shopDBContext.Where(a => a.CategoryId == category.Id).ToList();
            foreach (var a in articles)
            {
                if (a.ImagePath != null)
                {
                    var filePath = Path.Combine(_hostingEnvironment.WebRootPath, a.ImagePath);
                    if (System.IO.File.Exists(filePath) && a.ImagePath != Path.Combine("uploads", "default.jpg"))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }
            }

            if (category != null)
            {
                Category = category;
                _context.Categories.Remove(Category);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
