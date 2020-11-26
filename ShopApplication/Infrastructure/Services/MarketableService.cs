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

        #region MarketableService Construction
        //
        // Summary:
        //      default value if you want u can use it 
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
                Amount = 8500,
                Date = new DateTime(2020, 11, 25),
                SaleItems = new List<SaleItem> { new SaleItem(1, _products[0], 1), new SaleItem(2, _products[1], 2) }
            });
            _sales.Add(new Sale
            {
                No = 2,
                Amount = 8500,
                Date = new DateTime(2018, 11, 25),
                SaleItems = new List<SaleItem> { new SaleItem(1, _products[0], 1), new SaleItem(2, _products[1], 2) }
            });
        }
        #endregion

        #region Sale Methods

        #region Add Sale
        //
        // Summary:
        //     Adds new sale to sales list.
        //
        // Parameters:
        //   productsForSale:
        //     Dictionary of products for sale where key is product code and value count.
        //
        // Exceptions:
        //   T:SaleProductQuantityExceededException:
        //     There is no enough quantity of products
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
                if (saleItem.Product.Quantity < entry.Value)
                {
                    throw new SaleProductQuantityExceededException(string.Format("There is no enough quantity of products  "));
                }
                saleItem.No = saleItems.Count + 1;
                saleItems.Add(saleItem);
                amount += entry.Value * saleItem.Product.Price;
            }
            var saleNo = _sales.Count + 1;
            var saleDate = DateTime.Today;
            var sale = new Sale();
            sale.No = saleNo;
            sale.Amount = amount;
            sale.Date = saleDate;
            sale.SaleItems = saleItems;
            _sales.Add(sale);
        }
        #endregion

        #region Cancel Product From Sale
        //
        // Summary:
        //     Cancels product from sale
        //
        // Exceptions:
        //   T:ProductQuantityExceededException:
        //     There is no enough quantity of products
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
                    amount = saleItem.Product.Price * quantity;

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
        #endregion

        #region Get Sales
        //
        // Summary: 
        //    Returns:Sales 
        public List<Sale> GetSales()
        {
            return _sales;
        }
        #endregion

        #region Remove Sale
        //
        // Summary:
        //    Using GeTsaleByNo for find the number of sale to show sales and remove this sale
         
        public Sale RemoveSale(int no)
        {
            var sale = GetSaleByNo(no);
            _sales.Remove(sale);
            return sale;
        }
        #endregion

        #region Get Sales By Date Range
        //
        // Summary:
        //    Find the between two times in the sale to show sale  
        public List<Sale> GetSalesByDateRange(DateTime startDate, DateTime endDate)
        {
            List<Sale> sales = _sales.Where(s => s.Date >= startDate && s.Date <= endDate).ToList();
            return sales;
        }
        #endregion

        #region Get Sales By Date
        //
        // Summary:
        //    Give date and find for this date and to show sale   
        public List<Sale> GetSalesByDate(DateTime date)
        {
            List<Sale> sales = _sales.Where(s => s.Date == date).ToList();
            return sales;
        }
        #endregion

        #region Get Sales By Amount Range
        //
        // Summary:
        //   Give start amount and end amount  Find  between two this amount in sale and show sale  
        public List<Sale> GetSalesByAmountRange(double startAmount, double endAmount)
        {
            List<Sale> sales = _sales.Where(s => s.Amount >= startAmount && s.Amount <= endAmount).ToList();
            return sales;
        }
        #endregion

        #region Get Sale By Number
        //
        // Summary:
        //    Give the sale number and Find for this number in sale and show sale
        //     
        // Exceptions:
        //   T:SaleNotFoundException:
        //          Sale by number not found
        public Sale GetSaleByNo(int saleNo)
        {
            foreach (var sale in _sales.Where(sale => sale.No == saleNo))
            {
                return sale;
            }
            throw new SaleNotFoundException(string.Format("Sale by number {0} not found", saleNo));
        }
        #endregion

        #endregion

        #region Product Methods

        #region Add Product
        //
        // Summary:
        //    Add product
        public void AddProduct(Product product)
        {
            _products.Add(product);
        }
        #endregion

        #region Cahange Product
        //
        // Summary:
        //    Edit product 
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
        #endregion

        #region Remove Product
        //
        // Summary:
        //    Remove Product for this code
        public Product RemoveProduct(string productCode)
        {
            var product = GetProductByCode(productCode);
            _products.Remove(product);
            return product;
        }
        #endregion

        #region Get Product By Category
        //
        // Summary:
        //    Show the Product for given Category    
        public List<Product> GetProductsByCategory(Category category)
        {
            List<Product> products = _products.Where(p => p.ProductCategory == category).ToList();
            return products;
        }
        #endregion

        #region Get Products By Price Range
        //
        // Summary:
        //   Give start Price and end price find for this between  in the sale and show sale
        public List<Product> GetProductsByPriceRange(double startPrice, double endPrice)
        {
            List<Product> products = _products.Where(p => p.Price >= startPrice && p.Price <= endPrice).ToList();
            return products;
        }
        #endregion

        #region Get Products By Name
        //
        // Summary:
        //   Find for given name and show product 
        public List<Product> GetProductsByName(string name)
        {
            List<Product> products = _products.Where(p => p.Name.Contains(name)).ToList();
            return products;
        }
        #endregion

        #region Get Product By Code
        //
        // Summary:
        //    Find for given code and show product
        //       
        // Exceptions:
        //   T:ProductNotFoundException:
        //          Product by code not found
        public Product GetProductByCode(string code)
        {
            var product =  _products.Where(product => product.Code == code).FirstOrDefault();

            if (product == null)
            {
                throw new ProductNotFoundException(string.Format("Product by code {0} not found", code));
            }
            return product;
        }
        #endregion

        #endregion
    }
}