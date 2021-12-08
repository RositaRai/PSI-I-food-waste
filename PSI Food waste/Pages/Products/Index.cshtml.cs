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
    public class IndexModel : PageModel
    {
        private readonly PSI_Food_waste.Data.ProductContext _context;

        public IndexModel(PSI_Food_waste.Data.ProductContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Products.ToListAsync();
        }
    }
}
