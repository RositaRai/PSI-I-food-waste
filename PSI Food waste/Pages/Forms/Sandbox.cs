using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

        public IProductRepository _productRepository;

        public IRegisterRepository _registerRepository;

        public Sandbox(IProductRepository productRepository, IRestaurantRepository restaurantRepository, IRegisterRepository registerRepository)
        {
            _productRepository = productRepository;
            _restaurantRepository = restaurantRepository;
            _registerRepository = registerRepository;
        }

        public void OnGet()
        {
            ViewData["User"] = HttpContext.Session.GetString(key: "username");
            restaurants = _restaurantRepository.GetAll();
            products =  _productRepository.GetAll();
        }

        [BindProperty]
        public string Msg1 { get; set; }
        public string Msg2 { get; set; }
        //public PageResult OnPost(int id)
        //{
        //    if (id == 1)
        //    {
        //        Msg = "1";
        //    }
        //    else if (id == 2)
        //    {
        //        Msg = "2";
        //    }
        //    else Msg = "0";
        //    return Page();
        //}

        public void OnPostSelect1()
        {
            Msg1 = "waiting";
            SetLabelSync();
        }

        public async Task OnPostSelect2()
        {
            Msg2 = "2";
            await SetLabelAwait();
            //return Page();
        }

        public void OnPostSelect3()
        {
            Msg2 = "3";
        }


        private void SetLabelSync()
        {
            Msg1 = Calculate("Sync");
        }
        private string Calculate(string msg)
        {
            Thread.Sleep(1000);
            return msg;
        }


        private async Task SetLabelAwait()
        {
            Msg1 = await CalculateAsync("Await");
        }

        private Task<string> CalculateAsync(string msg)
        {
            return Task.Run(() => Calculate(msg));
        }
    }
}
