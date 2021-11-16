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
using AspNetCoreHero.ToastNotification.Abstractions;

namespace PSI_Food_waste.Pages.Forms
{

    public class RestaurantVerifiedModel : PageModel
    {
        [BindProperty]
        public Product NewProduct { get; set; }

        public List<Product> products;

        [BindProperty]
        public static string Msg { get; set; } = "";

        public Action<Product> DiscountPrice; //= _productRepository.NewPrice;  //TODO: fix error

        public  readonly INotyfService _notyf;

        public IRestaurantRepository _restaurantRepository;

        public IProductRepository _productRepository;

        public INotificationEvent _notificationEvent;

        public RestaurantVerifiedModel(IProductRepository productRepository, IRestaurantRepository restaurantRepository, INotificationEvent notificationEvent,INotyfService notyf)
        {
            _productRepository = productRepository;
            _restaurantRepository = restaurantRepository;
            DiscountPrice = _productRepository.NewPrice;
            _notificationEvent = notificationEvent;
            _notyf = notyf;
        }

        public string GlutenFreeText(Product product)
        {
            if (product.IsGlutenFree)
                return "Gluten Free";
            return "Not Gluten Free";
        }
        public async Task OnGetAsync()
        {
            ViewData["User"] = HttpContext.Session.GetString(key: "username");
            _productRepository.SortProducts();
            products = await _productRepository.GetList(_restaurantRepository.GetID());

        }
        public IActionResult OnPost()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("/Forms/LoginScreen");
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _notificationEvent.RaiseEvent(this,NewProduct.Name, _notyf,0);
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
            Product DelProduct = _productRepository.Get(id);
            _notificationEvent.RaiseEvent(this, DelProduct.Name, _notyf, 1);
            _productRepository.Delete(id);
            return RedirectToAction("Get");
        }
    }
    public class ProductArgs : EventArgs
    {
        public string Msg;

        public string Name;
        public ProductArgs(string name, string msg)
        {
            Msg = msg;
            Name = name;
        }
    }
}
