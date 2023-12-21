using BethanyPieShop.InventoryManagement.Domain.General;
using BethanyPieShop.InventoryManagement.Domain.ProductManagement;
using System.IO;

namespace BethanyPieShop.InventoryManagement
{
    public class ProductRepository
    {
        private string directory = @"E:\cursos\Projetos\Pluralsight\Object-oriented Programming in C# 10";
        private string productFileName = "product.txt";

        private void CheckForExistingProductFile()
        {
            string path = $"{directory}{productFileName}";

            bool existingFileFound = File.Exists(path);
            if (!existingFileFound)
            {
                //Create the directory
                if (Directory.Exists(path))
                    Directory.CreateDirectory(path);

                using FileStream fs = File.Create(path);
            }
        }

        public List<Product> LoadProductsFromFile()
        {
            List<Product> products = new List<Product>();

            string path = $"{directory}{productFileName}";
            try
            {
                CheckForExistingProductFile();

                string[] productsAsString = File.ReadAllLines(path);
                for (int i = 0; i < productsAsString.Length; i++)
                {
                    string[] productsSplits = productsAsString[i].Split(';');

                    bool success = int.TryParse(productsSplits[0], out int productId);
                    if (!success)
                        productId = 0;

                    string name = productsSplits[1];
                    string description = productsSplits[2];

                    success = int.TryParse(productsSplits[3], out int maxItemsInStock);
                    if (!success)
                        maxItemsInStock = 100;

                    success = int.TryParse(productsSplits[4], out int itemPrice);
                    if (!success)
                        itemPrice = 100;

                    success = Enum.TryParse(productsSplits[5], out Currency currency);
                    if (!success)
                        currency = Currency.Dollar; //default value

                    success = Enum.TryParse(productsSplits[5], out UnitType unitType);
                    if (!success)
                        unitType = UnitType.PerItem; //default value

                    Product product = new Product(productId, name, description, new Price { ItemPrice = itemPrice, Currency = currency }, unitType, maxItemsInStock);

                    products.Add(product);
                }
            }
            catch (IndexOutOfRangeException iex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong parsing the file, please check the data!");
                Console.WriteLine(iex.Message);
            }
            catch (FileNotFoundException fnfex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The file couldn't be found!");
                Console.WriteLine(fnfex.Message);
                Console.WriteLine(fnfex.StackTrace);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong while loading the file!");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ResetColor();
            }

            return products;
        }
    }
}