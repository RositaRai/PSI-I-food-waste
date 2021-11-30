using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PSI_Food_waste.Models;
using PSI_Food_waste.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSI_Food_waste.Pages.Forms
{
    public class RestaurantProductsModel : PageModel
    {
        public List<Product> products { get; set; }
        public Restaurant restaurant {  get; set; }
        public static Guid IdTest { get; set; }
        [BindProperty]
        public string searchCriteria { get; set; }

        public IRestaurantRepository _restaurantRepository;

        public IProductRepository _productRepository;

        public RestaurantProductsModel(IProductRepository productRepository, IRestaurantRepository restaurantRepository)
        {
            _productRepository = productRepository;
            _restaurantRepository = restaurantRepository;
        }

        public async Task OnGetAsync()
        {
            ViewData["User"] = HttpContext.Session.GetString(key: "username");
            restaurant =  _restaurantRepository.Get(id : IdTest);
            products = await _productRepository.GetList(id : IdTest);
        }
        public async Task OnPostAsync()
        {
            ViewData["User"] = HttpContext.Session.GetString(key: "username");
            restaurant = _restaurantRepository.Get(id: IdTest);
            products = await _productRepository.GetList(id: IdTest);
        }
        public string GlutenFreeText(Product product) 
        {
            if (product.IsGlutenFree)
                return "Gluten Free";
            return "Not Gluten Free";
        }
    }
}
