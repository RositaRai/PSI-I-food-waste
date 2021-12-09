using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PSI_Food_waste.Models;

namespace PSI_Food_waste.Pages.Forms
{
    public class EditProductModel : PageModel
    {
        private readonly PSI_Food_waste.Data.ProductContext _context;

        public EditProductModel(PSI_Food_waste.Data.ProductContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Product.DiscountedPrice = Product.Price * Product.Discount / 100;
            _context.Attach(Product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.PrID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./RestaurantVerified", "Get", new { ID = Product.RestId });
        }

        private bool ProductExists(Guid id)
        {
            return _context.Products.Any(e => e.PrID == id);
        }
    }
}
