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

        [BindProperty]
        public RegisteredUser<RegisterForm> RegisteredUsers { get; set; }

        public Sandbox(IProductRepository productRepository, IRestaurantRepository restaurantRepository, IRegisterRepository registerRepository)
        {
            _productRepository = productRepository;
            _restaurantRepository = restaurantRepository;
            _registerRepository = registerRepository;
        }

        public void OnGet(int id = 1)
        {
            ViewData["User"] = HttpContext.Session.GetString(key: "username");
            restaurants = _restaurantRepository.GetAll();
            products =  _productRepository.GetAll();
            RegisteredUsers = _registerRepository.GetAll();
            CurrPage = id;
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


        public static IndexDemo<string> StringList = new IndexDemo<string>();
        public int Id = 0;
        public int ListLen = StringList.Length();
        public string ErrMsg;
        public void OnPostIncrease()
        {
            try
            {
                StringList.Add(Id.ToString());
                Id++;
            }
            catch (IndexOutOfRangeException ex)
            {
                ErrMsg = ex.Message;
            }
        }



        public int CalculatePages (int n)
        {

            int ps = 3;
            if (n < ps)
                return 1;
            if (n % ps == 0)
                return n / ps;
            else
                return n / ps + 1;
        }
        [BindProperty]
        public int ProductsPerPage { get; set; }
        [BindProperty(SupportsGet = true)]
        public int CurrPage { get; set; }

        public List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11};

        public void OnPostSetPages10()
        {
            ProductsPerPage = 3;
        }
        public void OnPostSetPages25()
        {
            ProductsPerPage = 5;
        }

        public IActionResult OnPostSelectPage(int id)
        {

            //return RedirectToPage($"/Forms/Sandbox/{id}");
            return RedirectToAction("Get");
        }

        public List<int> ToShow = new List<int>();

        //public void OnGet(int id)
        //{
        //    CurrPage = id;
        //}

    }
}
