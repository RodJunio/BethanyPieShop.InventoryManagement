namespace BethanyPieShop.InventoryManagement.Domain.ProductManagement;

public partial class Product
{
    private string CreateSimpleProductRepresentation()
    {
        return $"Product {id} ({name})";
    }

    private void Log(string message)
    {
        //this could be written to a file
        Console.WriteLine(message);
    }

    private void UpdateLowStock()
    {
        if (AmountInStock < 10)//for now a fixed value
        {
            IsBelowStockThreshold = true;
        }
    }
}
