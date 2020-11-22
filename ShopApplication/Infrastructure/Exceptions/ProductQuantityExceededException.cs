using System;

namespace ShopApplication.Infrastructure.Exceptions
{
    public class ProductQuantityExceededException : Exception
    {
        public ProductQuantityExceededException(string message) : base(message) { }

    }
}
