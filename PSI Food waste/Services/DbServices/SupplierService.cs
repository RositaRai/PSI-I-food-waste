// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PSI_Food_waste.Data;
using PSI_Food_waste.Models;

namespace PSI_Food_waste.Services
{
    public class SupplierService : ISupplierRepository
    {
        public Supplier CurrentUser { get ; set ; }

        private readonly ProductContext _context;

        public SupplierService(ProductContext context)
        {
            _context = context;
        }

        public void AddToList(Supplier user)
        {
            _context.Suppliers.Add(user);
            _context.SaveChanges();
        }

        public  Supplier GetOne(int id)
        {
            var supplier = _context.Suppliers.Find(id);
            if(supplier == null)
                return null;
            return supplier;

        }
        public List<Supplier> GetAll()
        {
            var list = _context.Suppliers.OrderBy(a => a.SupplierId);
            return list.ToList<Supplier>();
        }

        public void Update(Supplier supplier)
        {
            _context.Entry(supplier).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Supplier supplier)
        {
            var sup = _context.Suppliers.Find(supplier.SupplierId);
            if(sup != null)
            {
                _context.Suppliers.Remove(sup);
            }
        }

        /*public Supplier GetUserData(string email)
        {

        }
        public void SetAll(List<Supplier> suppliers)
        {

        }*/
    }
}
