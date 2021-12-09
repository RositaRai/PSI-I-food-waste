using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PSI_Food_waste.Models;
using PSI_Food_waste.Pages.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSI_Food_waste.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty(SupportsGet = true)]
        public string City { get; set; }
        public string Username { get; set; }
        public void OnGet()
        {
            Username = HttpContext.Session.GetString( key : "username");
            if (string.IsNullOrWhiteSpace(City))
            {
                City = "the web";
            }
        }

        //public IActionResult OnGetLogout()
        //{
        //    HttpContext.Session.Remove("username");
        //    return RedirectToPage("/Index");
        //}

        public RedirectToPageResult OnPost()
        {
            HttpContext.Session.Remove( key : "username");
            return RedirectToPage("/Index");

        }


        public IActionResult OnPostPerson()
        {
            return RedirectToPage("/Forms/RestaurantList", new LocationModel { City = "None" });
        }
    }
}
