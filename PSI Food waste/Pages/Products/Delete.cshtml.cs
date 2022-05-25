using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PSI_Food_waste.Data;
using PSI_Food_waste.Models;

namespace PSI_Food_waste.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly PSI_Food_waste.Data.ProductContext _context;

        public DeleteModel(PSI_Food_waste.Data.ProductContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }

        /*public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Products.FirstOrDefaultAsync(m => m.PrID == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Products.FindAsync(id);

            if (Product != null)
            {
                _context.Products.Remove(Product);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }*/
    }
}
