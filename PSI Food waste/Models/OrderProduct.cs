// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace PSI_Food_waste.Models
{
    public class OrderProduct
    {
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public double Sum { get; set; } 
    }
}
