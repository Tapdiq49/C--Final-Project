using ShopApplication.Infrastructure.Enums;
using ShopApplication.Infrastructure.Exceptions;
using ShopApplication.Infrastructure.Interfaces;
using ShopApplication.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopApplication.Infrastructure.Services
{
    public class Marketable : IMarketable
    {
        private readonly List<Sale> _sales;
        public List<Sale> Sales => _sales;

        private readonly List<Product> _products;
        public List<Product> Products => _products;

        private Product _getProductByCode(string code)
        {
            foreach (var product in _products)
            {
                if (product.Code == code)
                {
                    return product;
                }
            }
            throw new ProductNotFoundException(string.Format("Product by code {0} not found", code));
        }
        
        #region Sale Methods

        public void AddSale(Dictionary<string, int> productsForSale)
        {
            List<SaleItem> saleItems = new List<SaleItem>();
            double amount = 0;
            foreach (KeyValuePair<string, int> entry in productsForSale)
            {
                var saleItem = new SaleItem();
                var productCode = entry.Key;
                saleItem.Quantity = entry.Value;
                saleItem.Product = _getProductByCode(productCode);
                saleItem.No = saleItems.Count + 1;
                saleItems.Add(saleItem);
                amount += entry.Value * saleItem.Product.Price;
            }
            var saleNo = _sales.Count + 1;
            var saleDate = DateTime.Now;
            var sale = new Sale();
            sale.No = saleNo;
            sale.Amount = amount;
            sale.Date = saleDate;
            sale.SaleItems = saleItems;
            _sales.Add(sale);
        }
        public int CancelProductFromSale(int saleNo, string productName)
        {
            throw new NotImplementedException();
        }
        public List<Sale> GetSales()
        {
            return _sales;
        }
        public List<Sale> GetSalesByDateRange(DateTime startDate, DateTime endDate)
        {
            List<Sale> sales = new List<Sale>();
            foreach (var sale in _sales)
            {
                if (startDate <= sale.Date && endDate >= sale.Date)
                {
                    sales.Add(sale);
                }
            }
            return sales;
        }
        public List<Sale> GetSalesByDate(int year, int month, int day)
        {
            List<Sale> sales = new List<Sale>();
            foreach (var sale in _sales)
            {
                if (year == sale.Date.Year && month == sale.Date.Month && 
                    day == sale.Date.Day)
                {
                    sales.Add(sale);
                }
            }
            return sales;
        }
        public List<Sale> GetSalesByAmountRange(double startAmount, double endAmount)
        {
            List<Sale> sales = new List<Sale>();

            foreach (var sale in Sales)
            {
                if (startAmount <= sale.Amount && endAmount >= sale.Amount)
                {
                    sales.Add(sale);
                }
            }
            return sales;
        }
        public Sale GetSaleByNo(int saleNo)
        {
            foreach (var sale in _sales)
            {
                if (sale.No == saleNo)
                {
                    return sale;
                }
            }
            throw new SaleNotFoundException(string.Format("Sale by number {0} not found", saleNo));
        }

        #endregion

        #region Product Methods

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void ChangeProductNameQuantityPriceCategoryByCode(string code,
                                                                 string name,
                                                                 int quantity, 
                                                                 double price, 
                                                                 Category category)
        {
            throw new NotImplementedException();
        }
        public List<Product> GetProductsByCategory(Category category)
        {
            List<Product> products = new List<Product>();
            foreach (var product in _products)
            {
                if (category == product.ProductCategory)
                {
                    products.Add(product);
                }
            }
            return products;
        }
        public List<Product> GetProductsByPriceRange(double startPrice, double endPrice)
        {
            List<Product> products = new List<Product>();

            foreach (var product in _products)
            {
                if (startPrice <= product.Price && endPrice >= product.Price)
                {
                    products.Add(product);
                }
            }
            return products;
        }
        public List<Product> GetProductsByName(string name)
        {
            throw new NotImplementedException();
        }

 

        #endregion
    }
}
