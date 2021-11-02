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
    public class Sandbox : PageModel
    {
        public List<Product> products { get; set; }
        public List<Restaurant> restaurants { get; set; }


        public IRestaurantRepository _restaurantRepository;

        //public Sandbox(IRestaurantRepository restaurantRepository)
        //{
        //    _restaurantRepository = restaurantRepository;
        //}

        public IProductRepository _productRepository;

        //public Sandbox(IProductRepository productRepository)
        //{
        //    _productRepository = productRepository;
        //}

        public Sandbox(IProductRepository productRepository, IRestaurantRepository restaurantRepository)
        {
            _productRepository = productRepository;
            _restaurantRepository = restaurantRepository;
        }

        public void OnGet()
        {
            ViewData["User"] = HttpContext.Session.GetString(key: "username");
            restaurants = _restaurantRepository.GetAll();
            products = _productRepository.GetAll();
        }
    }
}
