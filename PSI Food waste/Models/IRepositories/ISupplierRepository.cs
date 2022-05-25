// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;

namespace PSI_Food_waste.Models
{
    public interface ISupplierRepository
    {
        public Supplier CurrentUser { get; set; }

        public void AddToList(Supplier user);
        public Supplier GetOne(int id);
        public List<Supplier> GetAll();
        public void Update(Supplier supplier);
        public void Delete(Supplier supplier);
    }
}
