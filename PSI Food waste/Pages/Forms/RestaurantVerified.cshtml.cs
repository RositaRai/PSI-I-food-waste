using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PSI_Food_waste.Models;
using PSI_Food_waste.Services;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace PSI_Food_waste.Pages.Forms
{
    
    public class RestaurantVerifiedModel : PageModel
    {
        [BindProperty]
        public Product NewProduct { get; set; }

        public List<Product> products;

        public Action<Product> DiscountPrice; //= _productRepository.NewPrice;  //TODO: fix error

        //public ProductService productService = new ProductService();

        public IRestaurantRepository _restaurantRepository;

        //public RestaurantVerifiedModel(IRestaurantRepository restaurantRepository)
        //{
        //    _restaurantRepository = restaurantRepository;
        //}

        public IProductRepository _productRepository;

        //public RestaurantVerifiedModel(IProductRepository productRepository)
        //{
        //    _productRepository = productRepository;
        //}

        public RestaurantVerifiedModel(IProductRepository productRepository, IRestaurantRepository restaurantRepository)
        {
            _productRepository = productRepository;
            _restaurantRepository = restaurantRepository;
            DiscountPrice = _productRepository.NewPrice;
        }

        public string GlutenFreeText(Product product)
        {
            if (product.IsGlutenFree)
                return "Gluten Free";
            return "Not Gluten Free";
        }
        public void OnGet()
        {
            ViewData["User"] = HttpContext.Session.GetString(key: "username");
            _productRepository.SortProducts();
            products = _productRepository.GetList(_restaurantRepository.GetNextID());

        }
        public IActionResult OnPost()
        {
            if(HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("/Forms/LoginScreen");
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _productRepository.Add(NewProduct);
            DiscountPrice.Invoke(NewProduct);
            return RedirectToAction("Get");
        }
        public IActionResult OnPostDelete(int id)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("/Forms/LoginScreen");
            }
            _productRepository.Delete(id);
            return RedirectToAction("Get");
        }
    }
}
