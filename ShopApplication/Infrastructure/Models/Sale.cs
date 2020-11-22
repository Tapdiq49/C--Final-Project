using System;
using System.Collections.Generic;

namespace ShopApplication.Infrastructure.Models
{
    public class Sale
    {
        public int No { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public List<SaleItem> SaleItems { get; set; }

    }
}