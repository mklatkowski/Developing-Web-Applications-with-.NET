using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab11Project.Data;
using Lab11Project.Models;

namespace Lab11Project.Pages.Articles
{
    public class DeleteModel : PageModel
    {
        private readonly Lab11Project.Data.RP_ShopDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DeleteModel(Lab11Project.Data.RP_ShopDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public Article Article { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles.Include(a=>a.Category).FirstOrDefaultAsync(m => m.Id == id);

            if (article == null)
            {
                return NotFound();
            }
            else
            {
                Article = article;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles.FindAsync(id);
            if (article != null)
            {
                var imagePath = article.ImagePath;

                _context.Articles.Remove(article);

                await _context.SaveChangesAsync();

                if (!string.IsNullOrEmpty(imagePath))
                {
                    var filePath = Path.Combine(_webHostEnvironment.WebRootPath, imagePath);
                    if (System.IO.File.Exists(filePath) && article.ImagePath != Path.Combine("uploads", "default.jpg"))
                    {
                        Console.WriteLine(filePath);
                        System.IO.File.Delete(filePath);
                    }
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
