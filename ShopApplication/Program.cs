using ShopApplication.Infrastructure.Interfaces;
using ShopApplication.Infrastructure.Services;
using System;
using System.Text;
using ConsoleTables;
using ShopApplication.Infrastructure.Models;
using ShopApplication.Infrastructure.Enums;

namespace ShopApplication
{
    class Program
    {
        private static MarketableService _marketableService = new MarketableService();

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
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
                        Console.WriteLine("8. Sisteme qayit \n");
                        FirstCase();
                        break;
                    case 2:
                        Console.WriteLine("=============   Satishlarin idare edilmesi =============");
                        Console.WriteLine("\n1. Yeni satish elave et ");
                        Console.WriteLine("2. Satishdaki hansisa mehsulun geri qaytarilmasi( satishdan cixarilmasi)");
                        Console.WriteLine("3. Satishi sil ");
                        Console.WriteLine("4. Butun satislarin ekrana cixarilmasi (nomresi,meblegi,mehsul sayi,tarixi) ");
                        Console.WriteLine("5. Verilen tarix araligina gore satislarin gosterilmesi ");
                        Console.WriteLine("6. Verilen mebleg araligina gore satislarin gosterilmesi ");
                        Console.WriteLine("7. Verilmis bir tarixde olan satislarin gosterilmesi ");
                        Console.WriteLine("8. Verilmis nomreye esasen hemin nomreli satisin melumatlarinin gosterilmesi");
                        Console.WriteLine("9. Sisteme qayit");
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
            } while (selectInt != 3);
            

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

                switch (selectInt)
                {
                    case 1:
                        Console.WriteLine("1. Yeni mehsul elave et \n");
                        AddProducts();
                        Console.WriteLine("\nYeni sechiminizi edin veya 8-i basaraq sistemene tekrar qayidin");
                        break;
                    case 2:
                        Console.WriteLine("2. Mehsul uzerinde duzelish et\n");
                        break;
                    case 3:
                        Console.WriteLine("3. Mehsulu sil ");
                        break;
                    case 4:
                        Console.WriteLine("Sizin ashagidaki cedvel qeder mehsul sayiniz var\n");
                        ShowAllProducts();
                        Console.WriteLine("\nYeni sechiminizi edin veya 8-i basaraq sistemene tekrar qayidin");
                        break;
                    case 5:
                        Console.WriteLine("5. Kategoriyasina gore mehsullari goster ");
                        break;
                    case 6:
                        Console.WriteLine("6. Qiymet araligina gore mehsullari goster ");
                        break;
                    case 7:
                        Console.WriteLine("7. Mehsullar arasinda ada gore axtarish et ");
                        break;
                    case 8:
                        continue;
                    default:
                        Console.WriteLine("------------------------------------------------------------------------");
                        Console.WriteLine("| Siz yanlish sechim etdiniz, yalniz 0-8 arasi sechim ede bilersiniz ! |");
                        Console.WriteLine("------------------------------------------------------------------------");
                        break;
                }
            } while (selectInt != 8);
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

            Console.WriteLine("Mehsulun kategoriyasini daxil edin :");
            string inputEnum = Console.ReadLine();

            #endregion

            #region Product Quantity

            Console.WriteLine("Mehsulun sayini daxil edin:");
            string quantityInput = Console.ReadLine();
            int quantity;

            while (!int.TryParse(quantityInput, out quantity))
            {
                Console.WriteLine("Reqem daxil etmelisiniz!");
                quantityInput = Console.ReadLine();
            }

            product.Quantity = quantity;

            #endregion

            #region Product Name

            Console.WriteLine("Mehsulun kodunu daxil edin :");
            product.Code = Console.ReadLine();

            #endregion

            _marketableService.AddProduct(product);

            Console.WriteLine("-------------- Yeni mehsul ugurla elave edildi -------------");
        }

        #endregion

        #region Show All Products
        static void ShowAllProducts()
        {
            var table = new ConsoleTable("No", "Adi", "Qiymeti", "Kategoriyasi", "Sayi", "Kodu");
            int i = 0;
            foreach (var item in _marketableService.Products)
            {
                table.AddRow(i, item.Name, item.Price.ToString("#.##"), item.ProductCategory, item.Quantity, item.Code);
                i++;
            }
            table.Write();
        }

        #endregion

        #endregion

        #region Second Case

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

                switch (selectInt)
                {
                    case 1:
                        Console.WriteLine("\n1. Yeni satish elave et ");
                        break;
                    case 2:
                        Console.WriteLine("2. Satishdaki hansisa mehsulun geri qaytarilmasi( satishdan cixarilmasi)");
                        break;
                    case 3:
                        Console.WriteLine("3. Satishi sil ");
                        break;
                    case 4:
                        Console.WriteLine("4. Butun satislarin ekrana cixarilmasi (nomresi,meblegi,mehsul sayi,tarixi) ");
                        break;
                    case 5:
                        Console.WriteLine("5. Verilen tarix araligina gore satislarin gosterilmesi ");
                        break;
                    case 6:
                        Console.WriteLine("6. Verilen mebleg araligina gore satislarin gosterilmesi ");
                        break;
                    case 7:
                        Console.WriteLine("7. Verilmis bir tarixde olan satislarin gosterilmesi ");
                        break;
                    case 8:
                        Console.WriteLine("8. Verilmis nomreye esasen hemin nomreli satisin melumatlarinin gosterilmesi");
                        continue;
                    case 9:
                        continue;
                    default:
                        Console.WriteLine("------------------------------------------------------------------------");
                        Console.WriteLine("| Siz yanlish sechim etdiniz, yalniz 0-9 arasi sechim ede bilersiniz ! |");
                        Console.WriteLine("------------------------------------------------------------------------");
                        break;
                }
            } while (selectInt != 9);
        }

        #endregion
    }
}
