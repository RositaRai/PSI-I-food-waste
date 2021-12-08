// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using PSI_Food_waste.Models;
using Newtonsoft.Json;
using PSI_Food_waste.Data;

namespace PSI_Food_waste.Services
{
    public class ProductService : IProductRepository
    {
        List<Product> Products { get; set; }
        List<Product> IdProducts = new List<Product>();
        //static int nextId = 7;

        //static ProductService()
        //{
        //    Products = new List<Product>
        //    {
        //        new Product { Id = 1, Name = "Classic Italian pizza", Price=20.00M, Size=ProductSize.Large, IsGlutenFree = false },
        //        new Product { Id = 2, Name = "Veggie pizza", Price=15.00M, Size=ProductSize.Small, IsGlutenFree = true }
        //    };
        //}

        


        public IRestaurantRepository _restaurantRepository;
        private readonly ProductContext _context;

        public ProductService(IRestaurantRepository restaurantRepository, ProductContext context)
        {
            _restaurantRepository = restaurantRepository;
            _context = context;
            Products = _context.Products.ToList();

            //Products = ReadFile();
        }

        private List<Product> ReadFile()
        {
            string initialData = (Directory.GetCurrentDirectory() + "\\text.json");
            string json = File.ReadAllText(@initialData);
            List<Product> myObj = JsonConvert.DeserializeObject<List<Product>>(json);
            return myObj;
        }

        public List<Product> GetAll() => Products;

        public void SetAll(List<Product> products)
        {
            Products = products;
        }

        public Product Get(Guid id) => Products.FirstOrDefault(p => p.PrID == id);

        public async Task<List<Product>> GetList(Guid id)                           
        {
            IEnumerable<Product> query = await Task.Run(() => QueryRestaurantProducts(id));

            IdProducts.Clear();
            if (query.Any())
            {
                foreach (var rez in query)
                {
                    IdProducts.Add(rez);
                }
            }
            IdProducts.Sort();
            return IdProducts;
           // IdProducts.Clear();
           //foreach(Product prod in Products ?? new List<Product>())
           // {
           //     if(prod.RestId == id)
           //         IdProducts.Add(prod);
           // }
           // return IdProducts;
        }

        private IEnumerable<Product> QueryRestaurantProducts(Guid id)
        {
            IEnumerable<Product> query = from Product product in Products          
                                         where product.RestId == id
                                         select product;
            return query;
        }


        public void AddToList(Product product)
        {
            IdProducts.Add(product);
        }

        //TODO: fix product adding to DB
        public async Task AddAsync(Product product, Guid restId)
        {
            if (Products == null)
            {
                Products = new List<Product>();
            }
            product.RestId = restId;
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            //++nextId;
            //product.PrID = nextId++;
            //Products.Add(product);
            
        }

        public void Delete(Guid id)
        {
            var product = _context.Products.Find(id);
            if (product is null)
                return;

            //Products.Remove(product);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
        public void Update(Product product)
        {
            var index = Products.FindIndex(p => p.PrID == product.PrID);
            if (index == -1)
                return;

            Products[index] = product;

        }
        public void NewPrice(Product product)
        {
            product.DiscountedPrice = product.Price * (1 - (double)product.Discount/ 100);
        }
        //public void SortProducts()
        //{
        //    if(!Products.Any())
        //    {
        //       throw new ProductListNotFoundException("list is empty");
        //    }
        //    Products.Sort();
        //}
    }
}
