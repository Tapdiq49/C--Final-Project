using ShopApplication.Infrastructure.Enums;
using ShopApplication.Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace ShopApplication.Infrastructure.Interfaces
{
    public interface IMarketable
    {
        List<Sale> Sales { get; }

        List<Product> Products { get; }

        #region Sale

        void AddSale(Dictionary<string, int> productsForSale);
        double CancelProductFromSale(int saleNo, string productCode, int quantity);
        List<Sale> GetSales();
        List<Sale> GetSalesByDateRange(DateTime startDate, DateTime endDate);
        List<Sale> GetSalesByDate(DateTime date);
        List<Sale> GetSalesByAmountRange(double startAmount, double endAmount);
        Sale GetSaleByNo(int saleNo);
        Sale RemoveSale(int no);

        #endregion

        #region Product

        void AddProduct(Product product);
        void ChangeProductNameQuantityPriceCategoryByCode(string code, 
                                                            string name,
                                                            int quantity,
                                                            double price,
                                                            Category category);
        List<Product> GetProductsByCategory(Category category);
        List<Product> GetProductsByPriceRange(double startPrice, double endPrice);
        List<Product> GetProductsByName(string name);
        Product RemoveProduct(string productCode);

        #endregion

    }
}