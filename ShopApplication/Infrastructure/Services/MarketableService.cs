using System;
using System.Collections.Generic;
using System.Linq;
using ShopApplication.Infrastructure.Enums;
using ShopApplication.Infrastructure.Exceptions;
using ShopApplication.Infrastructure.Interfaces;
using ShopApplication.Infrastructure.Models;


namespace ShopApplication.Infrastructure.Services
{
    public class MarketableService : IMarketable
    {
        private readonly List<Sale> _sales;
        public List<Sale> Sales => _sales;

        private readonly List<Product> _products;
        public List<Product> Products => _products;

        public MarketableService()
        {
            _products = new List<Product>();
            _products.Add(new Product
            {
                Name = "Iphone",
                Price = 3500,
                ProductCategory = Category.Phone,
                Quantity = 1,
                Code = "2323b"
            });
            _products.Add(new Product
            {
                Name = "Toshiba",
                Price = 2500,
                ProductCategory = Category.Computer,
                Quantity = 3,
                Code = "49T"
            });

            _sales = new List<Sale>();
            _sales.Add(new Sale
            {
                No = 1,
                Amount = 1500,
                Date = new DateTime(2020, 11, 25),
                SaleItems = new List<SaleItem> { new SaleItem(1, _products[0], 1), new SaleItem(2, _products[1], 2) }
            }) ;
        }

        public Product GetProductByCode(string code)
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

        //
        // Summary:
        //     Adds new sale to sales list.
        //
        // Parameters:
        //   productsForSale:
        //     Dictionary of products for sale where key is product code and value count.
        public void AddSale(Dictionary<string, int> productsForSale)
        {
            List<SaleItem> saleItems = new List<SaleItem>();
            double amount = 0;
            foreach (KeyValuePair<string, int> entry in productsForSale)
            {
                var saleItem = new SaleItem();
                var productCode = entry.Key;
                saleItem.Quantity = entry.Value;
                saleItem.Product = GetProductByCode(productCode);
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
        public double CancelProductFromSale(int saleNo, string productCode, int quantity)
        {
            var sale = GetSaleByNo(saleNo);
            double amount = 0;
            int saleItemToDeleteIndex = -1;
            for (int i = 0; i < sale.SaleItems.Count; i++)
            {
                var saleItem = sale.SaleItems[i];

                if (productCode == saleItem.Product.Code)
                {
                    amount = saleItem.Product.Price * sale.Amount;

                    if (saleItem.Quantity > quantity)
                    {
                        saleItem.Quantity -= quantity;
                    }
                    else if (saleItem.Quantity == quantity)
                    {
                        saleItemToDeleteIndex = i;
                    }
                    else
                    {
                        throw new ProductQuantityExceededException(string.Format("There is no enough quantity {0} of products  ", quantity));
                    }
                }
            }
            sale.Amount -= amount;
            if (saleItemToDeleteIndex >= 0)
            {
                sale.SaleItems.RemoveAt(saleItemToDeleteIndex);
            }
            return amount;
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
            var product = GetProductByCode(code);
            product.Name = name;
            product.Quantity = quantity;
            product.Price = price;
            product.ProductCategory = category;
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
            List<Product> products = new List<Product>();
            foreach (var product in _products)
            {
                if (product.Name.Contains(name))
                {
                    products.Add(product);
                }
            }
            return products;
        }

        public Product RemoveProduct(string productCode)
        {
            var product = GetProductByCode(productCode);
            _products.Remove(product);
            return product;
        }

        #endregion
    }
}