using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PSI_Food_waste.Models;
using PSI_Food_waste.Services;
namespace PSI_Food_waste.Pages.Forms
{
    public class AddWorkerModel : PageModel
    {
        [BindProperty]
        public Restaurant NewRestaurant {  get; set; }

        public IRestaurantRepository _restaurantRepository;

        public IRegisterRepository _registerRepository;

        public AddWorkerModel(IRestaurantRepository restaurantRepository, IRegisterRepository registerRepository)
        {
            _restaurantRepository = restaurantRepository;
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
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }
            if(NewRestaurant.PictureUrl == null)
                NewRestaurant.PictureUrl = "https://www.kenyons.com/wp-content/uploads/2017/04/default-image.jpg";
            await _restaurantRepository.AddAsync(NewRestaurant);
            _registerRepository.CurrentUser.CreatedRestaurants.Add(NewRestaurant);
            //RestaurantVerifiedModel.Id = _restaurantRepository.GetID();
            RestaurantVerifiedModel.Id = NewRestaurant.Id;
            return RedirectToPage("/Forms/RestaurantVerified");
        }
    }
}
