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
        public void AddToList(Product product);
        public Product GetOne(int id, int supId);
        public List<Product> GetBySupplier(int SupplierId);
        public void Update(Product product);
        public void Delete(Product product);
        public List<Product> GetAll();

        public void NewPrice(Product product);
    }
}
