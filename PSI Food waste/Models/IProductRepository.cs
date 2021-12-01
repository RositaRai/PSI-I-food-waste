// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSI_Food_waste.Services;

namespace PSI_Food_waste.Models
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetList(Guid id);
        public void SortProducts();

        public void Add(Product product, Guid id);

        public void Delete(Guid id);

        public List<Product> GetAll();

        public void SetAll(List<Product> products);

        public Product Get(Guid id);

        public void NewPrice(Product product);
    }
}
