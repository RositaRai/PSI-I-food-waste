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
    public class RestaurantListModel : PageModel
    {
        public List<Restaurant> restaurants { get; set; }

        [BindProperty]
        public string SearchByCity { get; set; }

        public static string UserLocation { get; set; }

        public IRestaurantRepository _restaurantRepository;

        public RestaurantListModel(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }


        public void OnGet()
        {
            ViewData["User"] = HttpContext.Session.GetString(key: "username");
            SearchByCity = UserLocation;
            //restaurants = RestaurantServices.GetAll();
            restaurants = _restaurantRepository.GetAll();

            if (SearchByCity == "None")
            {

            }
            else
            {
                restaurants = restaurants.Where((restaurants, SearchByCity) => restaurants.City.Equals(SearchByCity), SearchByCity);
            }
        }
        public void OnPostFilter()
        {
            //restaurants = RestaurantServices.GetAll();
            restaurants = _restaurantRepository.GetAll();
            if (SearchByCity == "None")
            {

            }
            else
            {
                restaurants = restaurants.Where((restaurants, SearchByCity) => restaurants.City.Equals(SearchByCity), SearchByCity);
            }
        }
        public IActionResult OnPostSelect(int id)
        {
            RestaurantProductsModel.IdTest = id;
            return RedirectToPage("/Forms/RestaurantProducts");
        }
    }
}
