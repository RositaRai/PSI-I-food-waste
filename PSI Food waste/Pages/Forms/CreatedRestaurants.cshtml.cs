using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PSI_Food_waste.Models;
using PSI_Food_waste.Services;
using System;
using System.Collections.Generic;

namespace PSI_Food_waste.Pages.Forms
{
    public class CreatedRestaurantsModel : PageModel
    {
        public IRegisterRepository _registerRepository;

        public CreatedRestaurantsModel(IRegisterRepository registerRepository)
            {
            _registerRepository = registerRepository;
        }
        public IActionResult OnGet()
        {
            ViewData["User"] = HttpContext.Session.GetString(key: "username");
            //authorization API
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("/Forms/LoginScreen");
            }
            return Page();
        }
        public void OnPost()
        {

        }
        public IActionResult OnPostSelect(int id)
        {
            RestaurantVerifiedModel.Id = id;
            return RedirectToPage("/Forms/RestaurantVerified");
        }
    }
}
