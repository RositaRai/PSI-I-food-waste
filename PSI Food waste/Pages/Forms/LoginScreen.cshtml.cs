using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PSI_Food_waste.Models;

namespace PSI_Food_waste.Pages.Forms
{
    public class LoginScreenModel : PageModel
    {
        [BindProperty]
        public User NewUser { get; set; }
        public List<User> users = new List<User>
        {
            new User {Username = "admin", Password = "admin"}
        };

        public void OnGet()
        {
        }

        public bool flag;
        public IActionResult OnPost()
        {
            flag = false;
            foreach(User user in users)
            {
                if (NewUser.Equals(user))
                {
                    flag = true;
                    break;
                }
            }
            if (flag)
                return RedirectToPage("/Index");
            else return Page();
        }
    }
}
