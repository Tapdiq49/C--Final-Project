using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApplication.Infrastructure.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(string message) : base(message) { }
        
    }
}
