using System;

namespace ShopApplication.Infrastructure.Exceptions
{
    public class SaleProductQuantityExceededException : Exception
    {
        public SaleProductQuantityExceededException(string message) : base(message) { }

    }
}
