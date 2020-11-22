using System;

namespace ShopApplication.Infrastructure.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(string message) : base(message) { }

    }
}
