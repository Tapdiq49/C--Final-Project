using System;

namespace ShopApplication.Infrastructure.Exceptions
{
    public class SaleNotFoundException : Exception
    {
        public SaleNotFoundException(string message) : base(message) { }

    }
}
