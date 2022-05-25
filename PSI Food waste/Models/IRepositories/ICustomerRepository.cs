// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;

namespace PSI_Food_waste.Models.IRepositories
{
    public interface ICustomerRepository
    {
        public void AddToList(Customer customer);
        public Customer GetOne(int id);
        public List<Customer> GetAll();
        public void Update(Customer customer);
        public void Delete(Customer customer);

    }
}
