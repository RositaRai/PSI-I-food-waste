using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PSI_Food_waste.Services;
using PSI_Food_waste.Models;
using PSI_Food_waste.Data;

namespace PSI_Food_waste.Pages.Forms
{
    public class LoginScreenModel : PageModel
    {
        [BindProperty]
        public Supplier NewUser { get; set; }

        [BindProperty]
        public string Msg { get; set; }

        public List<User> users = new List<User>
        {
            new User {Email = "admin" , Username = "admin", Password = "admin"},
            new User {Email = "abc" , Username = "abc", Password = "123"}
        };
        //public RegisteredUser<RegisterForm> RegUsers { get; set; }

        public List<Supplier> suppliers { get; set; }
        public static Supplier CurrentUser { get; set; }
        //public static RegisterForm CurrentUser { get; set; }

        public ISupplierRepository supplierRepository;
        private readonly ProductContext _context;

        public LoginScreenModel(ISupplierRepository registerRepository, ProductContext context)
        {
            supplierRepository = registerRepository;
            _context = context;
        }

        public void OnGet()
        {
            //for testing
            //_registerRepository.AddToList(new RegisterForm(_context.Restaurants.ToList(), _context.Restaurants.ToList(), "admin", "admin", "admin", 0));
            //_registerRepository.AddToList(new RegisterForm(new List<Restaurant>(), new List<Restaurant>(), "email@name.com", "name", "name", 0));

            ViewData["User"] = HttpContext.Session.GetString(key: "username");
            //RegUsers = RegisterService.GetAll();
            Msg = "";
        }
        public bool flag;
        public IActionResult OnPost()
        {
            //TODO FIX: EMPTY EMAIL FIELD WILL THROW EXCEPTION
            if (!ModelState.IsValid)
            {
                return Page();
            }
            suppliers = supplierRepository.GetAll();
            flag = false;

            for (int i = 0; i < suppliers.Count(); i++)
            {
                if (NewUser.Email.Equals(suppliers[i].Email))
                { 
                    if (NewUser.Password.Equals(suppliers[i].Password))
                    {
                        CurrentUser = supplierRepository.GetOne(NewUser.SupplierId);
                        supplierRepository.CurrentUser = supplierRepository.GetOne(NewUser.SupplierId);
                        HttpContext.Session.SetString("username", suppliers[i].Username);
                        return RedirectToPage("/Index");
                    }
                }
            }
            foreach (User user in users)
            {
                if (NewUser.Equals(user))
                {
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                HttpContext.Session.SetString("username", "admin");
                return RedirectToPage("/Index");
            }
            else
            {
                Msg = "Incorrect credentials";
                return Page();
            }
        }
    }
}
