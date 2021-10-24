using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PSI_Food_waste.Pages.Forms
{
    public class LogoutScreenModel : PageModel
    {
        [BindProperty]
        public string Msg { get; set; }

        public RedirectToPageResult OnGet()
        {
            HttpContext.Session.Remove(key: "username");
            if (HttpContext.Session.GetString("username") == null)
            {
                Msg = "success";
            }
            return RedirectToPage("/Index");
        }
    }
}
