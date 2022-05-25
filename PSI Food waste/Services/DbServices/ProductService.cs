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
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace PSI_Food_waste.Services
{
    public class ProductService : IProductRepository
    {
        private readonly ProductContext _context;

        public ProductService(ProductContext context)
        {
            _context = context;
        }

        public void AddToList(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public Product GetOne(int id, int supId)
        {
            var list = _context.Products.Where(a => a.SupplierId == supId);
            var product = list.Where(a => a.ProductId == id).FirstOrDefault();
            if (product == null)
                return null;
            return product;

        }
        public List<Product> GetBySupplier(int SupplierId)
        {
            var list = _context.Products.Where(a => a.SupplierId == SupplierId).OrderBy(a => a.ProductId);
            return list.ToList<Product>();
        }

        public List<Product> GetAll()
        {
            var list = _context.Products.OrderBy(a => a.ProductId);
            return list.ToList<Product>();
        }

        public void Update(Product product)
        {
            NewPrice(product);
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Product product)
        {
            var sup = _context.Products.Find(product.ProductId);
            if (sup != null)
            {
                _context.Products.Remove(sup);
            }
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
