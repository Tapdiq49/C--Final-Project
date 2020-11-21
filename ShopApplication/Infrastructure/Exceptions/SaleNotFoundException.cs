using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApplication.Infrastructure.Exceptions
{
    public class SaleNotFoundException : Exception
    {
        public SaleNotFoundException(string message) : base(message) { }

    }
}
