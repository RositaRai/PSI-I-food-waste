// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PSI_Food_waste.Data;
using PSI_Food_waste.Models;
using PSI_Food_waste.Models.IRepositories;

namespace PSI_Food_waste.Services.DbServices
{
    public class CustomerService : ICustomerRepository
    {

        private readonly ProductContext _context;

        public CustomerService(ProductContext context)
        {
            _context = context;
        }

        public void AddToList(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public Customer GetOne(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
                return null;
            return customer;

        }
        public List<Customer> GetAll()
        {
            var list = _context.Customers.OrderBy(a => a.CustomerId);
            return list.ToList<Customer>();
        }

        public void Update(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Customer customer)
        {
            var cust = _context.Customers.Find(customer.CustomerId);
            if (cust != null)
            {
                _context.Customers.Remove(cust);
            }
        }
    }
}
