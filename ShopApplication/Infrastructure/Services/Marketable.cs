using ShopApplication.Infrastructure.Enums;
using ShopApplication.Infrastructure.Interfaces;
using ShopApplication.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApplication.Infrastructure.Services
{
    class Marketable : IMarketable
    {
        public List<Sale> Sales => throw new NotImplementedException();

        public List<Product> Products => throw new NotImplementedException();

        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void AddSale(Dictionary<int, int> productsForSale)
        {
            throw new NotImplementedException();
        }

        public int CancelProductFromSale(int saleNo, string productName)
        {
            throw new NotImplementedException();
        }

        public void ChangeProductNameQuantityPriceCategoryByCode(string code, string name, int quantity, double price, Category category)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsByCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsByPriceRange(double startPrice, double endPrice)
        {
            throw new NotImplementedException();
        }

        public Sale GetSaleByNo(int saleNo)
        {
            throw new NotImplementedException();
        }

        public List<Sale> GetSales()
        {
            throw new NotImplementedException();
        }

        public List<Sale> GetSalesByAmountRange(double startAmount, double endAmount)
        {
            throw new NotImplementedException();
        }

        public List<Sale> GetSalesByDate(int year, int month, int day)
        {
            throw new NotImplementedException();
        }

        public List<Sale> GetSalesByDateRange(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
    }
}
