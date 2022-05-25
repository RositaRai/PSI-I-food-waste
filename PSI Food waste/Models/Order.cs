// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace PSI_Food_waste.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerId { get; set; }
        public int SupplierId { get; set; }
        double TotalPrice { get; set; }

    }
}
