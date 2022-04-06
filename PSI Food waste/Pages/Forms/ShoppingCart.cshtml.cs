using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using PSI_Food_waste.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PSI_Food_waste.Pages.Forms
{
    public class ShoppingCartModel : PageModel
    {
        public void OnGet()
        {
        }


        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 10;
        public int TotalPages => (int)Math.Ceiling(Count / (double)PageSize);
        public List<Product> Data { get; set; }
        public bool ShowPrevious => CurrentPage > 1;
        public bool ShowNext => CurrentPage < TotalPages;

        public List<OrderProduct> orderProducts     { get; set; }   


        public List<Product> products { get; set; }
        public Restaurant restaurant { get; set; }
        public Guid IdTest { get; set; }
        [BindProperty]
        public string searchCriteria { get; set; }

        public IRestaurantRepository _restaurantRepository;

        public IProductRepository _productRepository;

        public ShoppingCartModel(IProductRepository productRepository, IRestaurantRepository restaurantRepository)
        {
            _productRepository = productRepository;
            _restaurantRepository = restaurantRepository;
        }

        public Task OnGetAsync(string json)
        {
            orderProducts = JsonConvert.DeserializeObject<List<OrderProduct>>(json);
            ViewData["orders"] = orderProducts;
            ViewData["User"] = HttpContext.Session.GetString(key: "username");
            Count = orderProducts.Count;
            return Task.CompletedTask;
        }

        public string GlutenFreeText(Product product)
        {
            if (product.IsGlutenFree)
                return "Gluten Free";
            return "Not Gluten Free";
        }

        public IActionResult OnPostAddToCart(Guid id)
        {
            OrderProduct orderProduct = new OrderProduct();
            orderProduct.Product = _productRepository.Get(id: id);
            orderProduct.Quantity = 1;

            orderProducts.Add(orderProduct);
            return null;
        }
    }
}
