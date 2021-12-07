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

        public IRestaurantRepository _restaurantRepository;

        public CreatedRestaurantsModel(IRegisterRepository registerRepository, IRestaurantRepository restaurantRepository)
            {
            _registerRepository = registerRepository;
            _restaurantRepository = restaurantRepository;
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
        public IActionResult OnPostSelect(Guid id)
        {
            RestaurantVerifiedModel.ID = id;
            return RedirectToPage("/Forms/RestaurantVerified");
        }
    }
}
