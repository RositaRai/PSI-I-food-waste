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
    public class DetailsModel : PageModel
    {
        private readonly PSI_Food_waste.Data.ProductContext _context;

        public DetailsModel(PSI_Food_waste.Data.ProductContext context)
        {
            _context = context;
        }

        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
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
    }
}
