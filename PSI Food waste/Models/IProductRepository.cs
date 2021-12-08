// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSI_Food_waste.Models
{
    public interface IProductRepository
    {

        public Task<List<Product>> GetList(Guid id);
        //public void SortProducts();

        public Task AddAsync(Product product, Guid restId);

        public void Delete(Guid Guid);

        public List<Product> GetAll();

        public void SetAll(List<Product> products);

        public Product Get(Guid id);

        public void NewPrice(Product product);
    }
}
