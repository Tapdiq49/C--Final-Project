using System;
using System.Text;
using ShopApplication.Infrastructure.Services;
using ConsoleTables;
using ShopApplication.Infrastructure.Models;
using ShopApplication.Infrastructure.Enums;
using System.Collections.Generic;
using ShopApplication.Infrastructure.Exceptions;

namespace ShopApplication
{
    class Program
    {
        private static MarketableService _marketableService = new MarketableService();
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            #region Menu
            int selectInt = 0;
            do
            {
                Console.WriteLine("=============  Satishlar ve Mehsullarin idare edilmesi ============= \n");
                Console.WriteLine("1. Mehsullar uzerinde emeliyyat aparmaq ");
                Console.WriteLine("2. Satishlar uzerinde emeliyyat aparmaq ");
                Console.WriteLine("3. Sistemden chixmaq \n");

                Console.WriteLine("Sechiminizi edin : \n");
                string select = Console.ReadLine();

                while (!int.TryParse(select, out selectInt))
                {
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("| Yalniz reqem daxil etmelisiniz ! |");
                    Console.WriteLine("------------------------------------");
                    select = Console.ReadLine();
                }
                #region Cases
                switch (selectInt)
                {
                    case 1:
                        Console.WriteLine("=============   Mehsullarin idare edilmesi =============");
                        Console.WriteLine("\n1. Yeni mehsul elave et ");
                        Console.WriteLine("2. Mehsul uzerinde duzelish et");
                        Console.WriteLine("3. Mehsulu sil ");
                        Console.WriteLine("4. Butun mehsullari goster ");
                        Console.WriteLine("5. Kategoriyasina gore mehsullari goster ");
                        Console.WriteLine("6. Qiymet araligina gore mehsullari goster ");
                        Console.WriteLine("7. Mehsullar arasinda ada gore axtarish et ");
                        Console.WriteLine("0. Sisteme qayit \n");
                        FirstCase();
                        break;
                    case 2:
                        Console.WriteLine("=============   Satishlarin idare edilmesi =============");
                        Console.WriteLine("\n1. Yeni satish elave et ");
                        Console.WriteLine("2. Satishdaki hansisa mehsulun geri qaytarilmasi( satishdan cixarilmasi)");
                        Console.WriteLine("3. Satishi sil ");
                        Console.WriteLine("4. Butun satislarin ekrana cixarilmasi ");
                        Console.WriteLine("5. Verilen tarix araligina gore satislarin gosterilmesi ");
                        Console.WriteLine("6. Verilen mebleg araligina gore satislarin gosterilmesi ");
                        Console.WriteLine("7. Verilmis bir tarixde olan satislarin gosterilmesi ");
                        Console.WriteLine("8. Verilmis nomreye esasen hemin nomreli satisin melumatlarinin gosterilmesi");
                        Console.WriteLine("0. Sisteme qayit");
                        SecondCase();
                        break;
                    case 3:
                        continue;
                    default:
                        Console.WriteLine("-------------------------------------------------------------------");
                        Console.WriteLine("Siz yanlish sechim etdiniz, yalniz 0-3 arasi sechim ede bilersiniz !");
                        Console.WriteLine("-------------------------------------------------------------------");
                        break;
                }
                #endregion
            } while (selectInt != 3);
            #endregion
        }

        #region FirstCase

        #region Cases
        static void FirstCase()
        {
            int selectInt = 0;
            do
            {
                Console.WriteLine("Sechiminizi edin : \n");
                string select = Console.ReadLine();

                while (!int.TryParse(select, out selectInt))
                {
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("| Yalniz reqem daxil etmelisiniz ! |");
                    Console.WriteLine("------------------------------------");
                    select = Console.ReadLine();
                }
                #region Switch
                switch (selectInt)
                {
                    case 0:
                        continue;
                    case 1:
                        Console.WriteLine("1. Yeni mehsul elave et \n");
                        AddProducts();
                        Console.WriteLine("\nYeni sechiminizi edin veya 0-i basaraq sistemene tekrar qayidin");
                        break;
                    case 2:
                        Console.WriteLine("2. Mehsul uzerinde duzelish et\n");
                        ChangeProductByCode();
                        Console.WriteLine("\nYeni sechiminizi edin veya 0-i basaraq sistemene tekrar qayidin");
                        break;
                    case 3:
                        Console.WriteLine("3. Mehsulu sil ");
                        RemoveProductByCode();
                        Console.WriteLine("\nYeni sechiminizi edin veya 0-i basaraq sistemene tekrar qayidin");
                        break;
                    case 4:
                        Console.WriteLine("Sizin ashagidaki cedvel qeder mehsul sayiniz var\n");
                        ShowAllProducts();
                        Console.WriteLine("\nYeni sechiminizi edin veya 0-i basaraq sistemene tekrar qayidin");
                        break;
                    case 5:
                        Console.WriteLine("5. Kategoriyasina gore mehsullari goster ");
                        ShowProductsByCategory();
                        Console.WriteLine("\nYeni sechiminizi edin veya 0-i basaraq sistemene tekrar qayidin");
                        break;
                    case 6:
                        Console.WriteLine("6. Qiymet araligina gore mehsullari goster ");
                        ShowProductsByPriceRange();
                        Console.WriteLine("\nYeni sechiminizi edin veya 0-i basaraq sistemene tekrar qayidin");
                        break;
                    case 7:
                        Console.WriteLine("7. Mehsullar arasinda ada gore axtarish et ");
                        ShowProductsByName();
                        Console.WriteLine("\nYeni sechiminizi edin veya 8-i basaraq sistemene tekrar qayidin");
                        break;
                    default:
                        Console.WriteLine("------------------------------------------------------------------------");
                        Console.WriteLine("| Siz yanlish sechim etdiniz, yalniz 0-7 arasi sechim ede bilersiniz ! |");
                        Console.WriteLine("------------------------------------------------------------------------");
                        break;
                }
                #endregion
            } while (selectInt != 0);
        }
        #endregion

        #region Select Category
        static Category SelectCategory()
        {
            #region Product Category
            Category category = Category.Refrigerator;

            int selectInt;
            do
            {
                #region Product Category Menu 
                Console.WriteLine("\nKateqoriyanin nomresini daxil edin:");
                Console.WriteLine("1. Refrigerator");
                Console.WriteLine("2. TV");
                Console.WriteLine("3. Computer");
                Console.WriteLine("4. Phone");
                #endregion

                #region Product Category Selection
                Console.Write("Sechiminizi edin : ");
                string select = Console.ReadLine();

                while (!int.TryParse(select, out selectInt))
                {
                    Console.Write("Reqem daxil etmelisiniz !  ");
                    select = Console.ReadLine();
                }
                #endregion

                #region Product Category Switch
                switch (selectInt)
                {
                    case 1:
                        category = Category.Refrigerator;
                        break;
                    case 2:
                        category = Category.TV;
                        break;
                    case 3:
                        category = Category.Computer;
                        break;
                    case 4:
                        category = Category.Phone;
                        break;
                    default:
                        Console.WriteLine("---------------------------------------------------------------");
                        Console.WriteLine("|Siz yalnish sechim etdiniz, 1-4 araliginda sechim etmelisiniz|");
                        Console.WriteLine("---------------------------------------------------------------");
                        break;
                }
            #endregion

            } while (selectInt != 1 && selectInt != 2 && selectInt != 3 && selectInt != 4);
            return category;
            #endregion
        }
        #endregion

        #region Add Products
        static void AddProducts()
        {
            Product product = new Product();

            #region Product Name
            Console.WriteLine("Mehsulun adini daxil edin :");
            product.Name = Console.ReadLine();
            #endregion

            #region Product price
            Console.WriteLine("Mehsulun qiymetini daxil edin:");
            string priceInput = Console.ReadLine();
            double price;

            while (!double.TryParse(priceInput, out price))
            {
                Console.WriteLine("Reqem daxil etmelisiniz!");
                priceInput = Console.ReadLine();
            }

            product.Price = price;
            #endregion

            #region Product Category
            product.ProductCategory = SelectCategory();
            #endregion

            #region Product Quantity
            Console.WriteLine("\nMehsulun sayini daxil edin:");
            string quantityInput = Console.ReadLine();
            int quantity;

            while (!int.TryParse(quantityInput, out quantity))
            {
                Console.WriteLine("Reqem daxil etmelisiniz!");
                quantityInput = Console.ReadLine();
            }

            product.Quantity = quantity;
            #endregion

            #region Product Code
            Console.WriteLine("\nMehsulun kodunu daxil edin :");
            product.Code = Console.ReadLine();
            #endregion

            _marketableService.AddProduct(product);

            Console.WriteLine("-------------- Yeni mehsul ugurla elave edildi -------------");
        }

        #endregion

        #region Change Product Name Quantity Price Category By Code
        static void ChangeProductByCode()
        {
            #region Change Product By Code
            Console.WriteLine("Mehsulu deyishmek uchun mehsulun kodunu daxil edin:");
            string code = Console.ReadLine();
            _marketableService.GetProductByCode(code);
            #endregion

            #region Change Name
            Console.WriteLine("Mehsulun yeni adini daxil edin :");
            string name = Console.ReadLine();
            #endregion

            #region Change Quantity
            Console.WriteLine("Mehsulun yeni sayini daxil edin :");
            string quantityInput = Console.ReadLine();
            int quantity;

            while (!int.TryParse(quantityInput, out quantity))
            {
                Console.WriteLine("Reqem daxil etmelisiniz!");
                quantityInput = Console.ReadLine();
            }
            #endregion

            #region Price
            Console.WriteLine("Mehsulun yeni qiymetini daxil edin :");
            string priceInput = Console.ReadLine();
            double price;

            while (!double.TryParse(priceInput, out price))
            {
                Console.WriteLine("Reqem daxil etmelisiniz!");
                priceInput = Console.ReadLine();
            }
            #endregion

            #region Change Category
            Console.WriteLine("Mehsulun yeni kategoriyasini daxil edin :");
            Category productCategory = SelectCategory();
            #endregion

            _marketableService.ChangeProductNameQuantityPriceCategoryByCode(code, name, quantity, price, productCategory);
            Console.WriteLine("-------------- {0} - kodlu mehsul ugurla deyishildi -------------", code);
        }
        #endregion

        #region Remove Product By Code
        static void RemoveProductByCode()
        {
            Console.WriteLine("Legv etmek uchun mehsulun kodunu daxil edin:");
            string removeCode = Console.ReadLine();
            try
            {
                _marketableService.RemoveProduct(removeCode);
                Console.WriteLine("-------------- Mehsul legv edildi --------------");
            }
            catch (ProductNotFoundException e)
            {
                Console.WriteLine("Bu kodda satish yoxdur !");
            }

        }
        #endregion

        #region Show All Products
        static void ShowAllProducts()
        {
            var table = new ConsoleTable("No", "Adi", "Qiymeti", "Kategoriyasi", "Sayi", "Kodu");
            int i = 1;
            foreach (var item in _marketableService.Products)
            {
                table.AddRow(i, item.Name, item.Price.ToString("#.##"), item.ProductCategory, item.Quantity, item.Code);
                i++;
            }
            table.Write();
            Console.WriteLine("");
        }

        #endregion

        #region Get Products By Category
        static void ShowProductsByCategory()
        {
            Console.WriteLine("Mehsulun kategoriyasini daxil edin :");
            Category productCategory = SelectCategory();

            Console.WriteLine("\nDaxil etdiyiniz kategoriyada ashagidaki mehsullar movcuddur");
            var table = new ConsoleTable("No", "Adi", "Qiymeti", "Kategoriyasi", "Sayi", "Kodu");
            int i = 1;
            foreach (var item in _marketableService.GetProductsByCategory(productCategory))
            {
                table.AddRow(i, item.Name, item.Price.ToString("#.##"), item.ProductCategory, item.Quantity, item.Code);
                i++;
            }
            table.Write();
        }

        #endregion

        #region Show Products By Price Range
        static void ShowProductsByPriceRange()
        {

            #region Start Price
            Console.WriteLine("Minimum meblegi daxil edin :");
            string startInput = Console.ReadLine();
            double startPrice;

            while (!double.TryParse(startInput, out startPrice))
            {
                Console.WriteLine("Qiymet daxil etmelisiniz !");
                startInput = Console.ReadLine();
            }
            #endregion;

            #region End Price
            Console.WriteLine("Maksimum meblegi daxil edin :");
            string endInput = Console.ReadLine();
            double endPrice;

            while (!double.TryParse(endInput, out endPrice))
            {
                Console.WriteLine("Tarixi daxil etməlisiniz!");
                endInput = Console.ReadLine();
            }
            #endregion

            #region Result
            Console.WriteLine("\nDaxil etdiyiniz mebleg araliginda ashagidaki mehsullar movcuddur");
            var table = new ConsoleTable("No", "Adi", "Qiymeti", "Kategoriyasi", "Sayi", "Kodu");
            int i = 1;
            foreach (var item in _marketableService.GetProductsByPriceRange(startPrice, endPrice))
            {
                table.AddRow(i, item.Name, item.Price.ToString("#.##"), item.ProductCategory, item.Quantity, item.Code);
                i++;
            }
            table.Write();
            #endregion
        }

        #endregion

        #region Show Products By Name
        static void ShowProductsByName()
        {
            Console.WriteLine("Text daxil edin :");
            string text = Console.ReadLine();

            #region Result
            Console.WriteLine("\nDaxil etdiyiniz textde gore ashagidaki mehsullar movcuddur");
            var table = new ConsoleTable("No", "Adi", "Qiymeti", "Kategoriyasi", "Sayi", "Kodu");
            int i = 1;
            foreach (var item in _marketableService.GetProductsByName(text))
            {
                table.AddRow(i, item.Name, item.Price.ToString("#.##"), item.ProductCategory, item.Quantity, item.Code);
                i++;
            }
            table.Write();
            #endregion
        }
        #endregion

        #endregion

        #region Second Case

        #region Cases
        static void SecondCase()
        {
            int selectInt = 0;
            do
            {
                Console.WriteLine("Sechiminizi edin : \n");
                string select = Console.ReadLine();

                while (!int.TryParse(select, out selectInt))
                {
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("| Yalniz reqem daxil etmelisiniz ! |");
                    Console.WriteLine("------------------------------------");
                    select = Console.ReadLine();
                }
                #region Switch
                switch (selectInt)
                {
                    case 0:
                        continue;
                    case 1:
                        Console.WriteLine("\n1. Yeni satish elave et ");
                        break;
                    case 2:
                        Console.WriteLine("2. Satishdaki hansisa mehsulun geri qaytarilmasi( satishdan cixarilmasi)");
                        break;
                    case 3:
                        Console.WriteLine("3. Satishi sil ");
                        RemoveSaleByNo();
                        Console.WriteLine("\nYeni sechiminizi edin veya 0-i basaraq sistemene tekrar qayidin");
                        break;
                    case 4:
                        Console.WriteLine("4. Butun satislarin ekrana cixarilmasi");
                        ShowAllSales();
                        Console.WriteLine("\nYeni sechiminizi edin veya 0-i basaraq sistemene tekrar qayidin");
                        break;
                    case 5:
                        Console.WriteLine("5. Verilen tarix araligina gore satislarin gosterilmesi ");
                        ShowSaleByDateRange();
                        Console.WriteLine("\nYeni sechiminizi edin veya 0-i basaraq sistemene tekrar qayidin");
                        break;
                    case 6:
                        Console.WriteLine("6. Verilen mebleg araligina gore satislarin gosterilmesi ");
                        ShowSalesByAmountRange();
                        Console.WriteLine("\nYeni sechiminizi edin veya 0-i basaraq sistemene tekrar qayidin");
                        break;
                    case 7:
                        Console.WriteLine("7. Verilmis bir tarixde olan satislarin gosterilmesi ");
                        ShowSalesByDate();
                        Console.WriteLine("\nYeni sechiminizi edin veya 0-i basaraq sistemene tekrar qayidin");
                        break;
                    case 8:
                        Console.WriteLine("8. Verilmis nomreye esasen hemin nomreli satisin melumatlarinin gosterilmesi");
                        ShowSaleByNumber();
                        Console.WriteLine("\nYeni sechiminizi edin veya 0-i basaraq sistemene tekrar qayidin");
                        break;
                    default:
                        Console.WriteLine("------------------------------------------------------------------------");
                        Console.WriteLine("| Siz yanlish sechim etdiniz, yalniz 0-8 arasi sechim ede bilersiniz ! |");
                        Console.WriteLine("------------------------------------------------------------------------");
                        break;
                }
                #endregion
            } while (selectInt != 0);
        }
        #endregion

        #region Add Sale
        static void AddSale()
        {
            List<SaleItem> saleItems = new List<SaleItem>();

            #region Sale Number
            Console.WriteLine("Satishin nomresini daxil edin:");
            string numberInput = Console.ReadLine();
            int number;

            while (!int.TryParse(numberInput, out number))
            {
                Console.WriteLine("Reqem daxil etmelisiniz!");
                numberInput = Console.ReadLine();
            }
            #endregion

            #region Sale Amount
            Console.WriteLine("Satishin meblegini daxil edin:");
            string amountInput = Console.ReadLine();
            double amount;

            while (!double.TryParse(amountInput, out amount))
            {
                Console.WriteLine("Reqem daxil etmelisiniz!");
                amountInput = Console.ReadLine();
            }
            #endregion

            #region Sale Date
            Console.WriteLine("Satishin tarixini daxil edin (gun.ay.il):");
            string dateInput = Console.ReadLine();
            DateTime date;

            while (!DateTime.TryParse(dateInput, out date))
            {
                Console.WriteLine("Tarixi daxil etməlisiniz!");
                dateInput = Console.ReadLine();
            }
            #endregion

            #region Sale Item Count

            #endregion
        }

        #endregion

        #region Cancel Product From Sale

        #endregion

        #region Remove Sale
        static void RemoveSaleByNo()
        {
            Console.WriteLine("Legv etmek uchun satishin nomresini daxil edin:");
            string removeInput = Console.ReadLine();
            int number;

            while (!int.TryParse(removeInput, out number))
            {
                Console.WriteLine("Reqem daxil etmelisiniz!");
                removeInput = Console.ReadLine();
            }
            try
            {
                _marketableService.RemoveSale(number);
                Console.WriteLine("-------------- satish legv edildi --------------");
            }
            catch (SaleNotFoundException e)
            {
                Console.WriteLine("Bu nomrede satish yoxdur !");
            }

        }
        #endregion

        #region Show All Sales
        static void ShowAllSales()
        {
            var table = new ConsoleTable("No", "Nomresi", "Meblegi", "Mehsul sayi", "Tarixi");
            int i = 1;
            foreach (var item in _marketableService.Sales)
            {
                table.AddRow(i, item.No, item.Amount.ToString("#.##"), item.SaleItems.Count, item.Date.ToString("dd.MM.yyyy"));
                i++;
            }
            table.Write();
        }
        #endregion

        #region Show Sale By Date Range
        static void ShowSaleByDateRange()
        {
            #region Start Date
            Console.WriteLine("Bashlangic tarixi daxil edin (gun.ay.il):");
            string startDateInput = Console.ReadLine();
            DateTime startDate;

            while (!DateTime.TryParse(startDateInput, out startDate))
            {
                Console.WriteLine("Tarix daxil etmelisiniz !");
                startDateInput = Console.ReadLine();
            }
            #endregion;

            #region End Date
            Console.WriteLine("Maksimum meblegi daxil edin (gun.ay.il) :");
            string endDateInput = Console.ReadLine();
            DateTime endDate;

            while (!DateTime.TryParse(endDateInput, out endDate))
            {
                Console.WriteLine("Tarixi daxil etməlisiniz!");
                endDateInput = Console.ReadLine();
            }
            #endregion

            #region Result
            var table = new ConsoleTable("No", "Nomresi", "Meblegi", "Mehsul sayi", "Tarixi");
            int i = 1;
            foreach (var item in _marketableService.GetSalesByDateRange(startDate, endDate))
            {
                table.AddRow(i, item.No, item.Amount.ToString("#.##"), item.SaleItems.Count, item.Date.ToString("dd.MM.yyyy"));
                i++;
            }
            table.Write();
            #endregion
        }

        #endregion

        #region Show Sales By Amount Range
        static void ShowSalesByAmountRange()
        {
            #region Start Amount
            Console.WriteLine("Minimum meblegi daxil edin :");
            string startInput = Console.ReadLine();
            double startAmount;

            while (!double.TryParse(startInput, out startAmount))
            {
                Console.WriteLine("Mebleg daxil etmelisiniz !");
                startInput = Console.ReadLine();
            }
            #endregion;

            #region End Amount
            Console.WriteLine("Maksimum meblegi daxil edin :");
            string endInput = Console.ReadLine();
            double endAmount;

            while (!double.TryParse(endInput, out endAmount))
            {
                Console.WriteLine("Mebleg daxil etmelisiniz!");
                endInput = Console.ReadLine();
            }
            #endregion

            #region Result
            var table = new ConsoleTable("No", "Nomresi", "Meblegi", "Mehsul sayi", "Tarixi");
            int i = 1;
            foreach (var item in _marketableService.GetSalesByAmountRange(startAmount, endAmount))
            {
                table.AddRow(i, item.No, item.Amount.ToString("#.##"), item.SaleItems.Count, item.Date.ToString("dd.MM.yyyy"));
                i++;
            }
            table.Write();
            #endregion
        }

        #endregion

        #region Show Sales By Date
        static void ShowSalesByDate()
        {
            #region Date
            Console.WriteLine("Satishin tarixini daxil edin (gun.ay.il):");
            string dateInput = Console.ReadLine();
            DateTime date;

            while (!DateTime.TryParse(dateInput, out date))
            {
                Console.WriteLine("Tarix daxil etmelisiniz !");
                dateInput = Console.ReadLine();
            }
            #endregion

            #region Result
            var table = new ConsoleTable("No", "Nomresi", "Meblegi", "Mehsul sayi", "Tarixi");
            int i = 1;
            foreach (var item in _marketableService.GetSalesByDate(date))
            {
                table.AddRow(i, item.No, item.Amount.ToString("#.##"), item.SaleItems.Count, item.Date.ToString("dd.MM.yyyy"));
                i++;
            }
            table.Write();
            #endregion
        }

        #endregion

        #region Show Sale By Number
        static void ShowSaleByNumber()
        {
            #region Number
            Console.WriteLine("Satishin nomresini daxil edin :");
            string numberInput = Console.ReadLine();
            int saleNumber;

            while (!int.TryParse(numberInput, out saleNumber))
            {
                Console.WriteLine("Reqem daxil etmelisiniz !");
                numberInput = Console.ReadLine();
            }
            #endregion
        }

        #endregion

        #endregion
    }
}
