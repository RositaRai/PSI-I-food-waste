using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PSI_Food_waste.Models;
using PSI_Food_waste.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSI_Food_waste.Pages.Forms
{
    public class RestaurantProductsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 10;
        public int TotalPages => (int)Math.Ceiling(Count / (double)PageSize);
        public List<Product> Data { get; set; }
        public bool ShowPrevious => CurrentPage > 1;
        public bool ShowNext => CurrentPage < TotalPages;

        public List<OrderProduct> orderProducts = new List<OrderProduct>(); 


        public List<Product> products { get; set; }
        public Restaurant restaurant {  get; set; }
        public Guid IdTest { get; set; }
        [BindProperty]
        public string searchCriteria { get; set; }

        public IRestaurantRepository _restaurantRepository;

        public IProductRepository _productRepository;

        public RestaurantProductsModel(IProductRepository productRepository, IRestaurantRepository restaurantRepository)
        {
            _productRepository = productRepository;
            _restaurantRepository = restaurantRepository;
        }

        public async Task OnGetAsync(Guid ID)
        {
            ViewData["User"] = HttpContext.Session.GetString(key: "username");
            restaurant = _restaurantRepository.Get(id : ID);
            products = await _productRepository.GetList(id : ID);
            Data = await _productRepository.GetPaginatedResult(products, CurrentPage, PageSize);
            Count = products.Count;
        }
        public async Task OnPostAsync(Guid ID)
        {
            ViewData["User"] = HttpContext.Session.GetString(key: "username");
            //return RedirectToPage("/Forms/RestaurantProducts", new {searchCriteria = this.searchCriteria});
            //restaurant = RestaurantServices.Get(id: IdTest);
            restaurant = _restaurantRepository.Get(id: ID);
            //products = ProductService.GetList(id: IdTest);
            products = await _productRepository.GetList(id: ID);
            Data = await _productRepository.GetPaginatedResult(products, CurrentPage, PageSize);
            Count = products.Count;
        }
        public string GlutenFreeText(Product product) 
        {
            if (product.IsGlutenFree)
                return "Gluten Free";
            return "Not Gluten Free";
        }

        public IActionResult OnPostAddToCart(Guid productId, Guid restId)
        {
            Product product = _productRepository.Get(productId);

            OrderProduct orderProduct = new OrderProduct();
            orderProduct.Product = product;
            orderProduct.Quantity = 1;

            orderProducts.Add(orderProduct);
            var json = JsonConvert.SerializeObject(orderProducts);
            ViewData["listas"] = orderProducts;
            return RedirectToPage("/Forms/ShoppingCart", new { json = json });

            return RedirectToAction("OnPostSelect", orderProducts);
        }

        public IActionResult OnPostSelect(List<OrderProduct> list)
        {
            //RestaurantProductsModel.IdTest = id;
            var json = JsonConvert.SerializeObject(orderProducts);  
            ViewData["listas"] = orderProducts;
            return RedirectToPage("/Forms/ShoppingCart", json);
        }

        protected void passvalue(object sender, EventArgs e)
        {
            var btn = (object)(sender);
            //String testval = btn.CommandArgument; //Returns 456
        }

        void Log(Guid id)
        {
            Product product = _productRepository.Get(id);

            OrderProduct orderProduct = new OrderProduct();
            orderProduct.Product = product;
            orderProduct.Quantity = 1;

            orderProducts.Add(orderProduct);
        }
    }
}
