namespace BethanyPieShop.InventoryManagement.Domain.ProductManagement;

public partial class Product
{
    public static int StockTreshold = 5;

    public static void ChangeStockThreshold(int newStockTreshhold)
    {
        //we will only allow this to go through if the value is > 0
        if (newStockTreshhold > 0)
            StockTreshold = newStockTreshhold;
    }
    public void UpdateLowStock()
    {
        if (AmountInStock < StockTreshold)//for now a fixed value
        {
            IsBelowStockTreshold = true;
        }
    }

    protected string CreateSimpleProductRepresentation()
    {
        return $"Product {id} ({name})";
    }

    protected void Log(string message)
    {
        //this could be written to a file
        Console.WriteLine(message);
    }
}
