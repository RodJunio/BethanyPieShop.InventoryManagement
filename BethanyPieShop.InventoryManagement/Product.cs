

using System.Text;

namespace BethanyPieShop.InventoryManagement;

public class Product
{
    private int id;
    private string name = string.Empty;
    private string? description;

    private int maxItemsInStock = 0;

    private UnitType? unitType;
    private int amountInStock = 0;
    private bool isBelowStockThreshold = false;

    public void UseProduct(int items)
    {
        if (items <= amountInStock)
        {
            //use the items
            amountInStock -= items;

            UpdateLowStock();

            Log($"Amount in stock update. Now {amountInStock} items in stock");
        }
        else
        {
            Log($"Not enough items on stock for {CreateSimpleProductRepresentation()}. {amountInStock} available but {items} requested");
        }
    }

    public void IncreaseStock()
    {
        amountInStock++;
    }

    public void decreaseStock(int items, string reason)
    {
        if (items <= amountInStock)
        {
            //decrease the stock with the specified number items
            amountInStock -= items;
        }
        else
        {
            amountInStock = 0;
        }

        UpdateLowStock();

        Log(reason);
    }

    public strint DisplayDetailsShort()
    {
        return $"{id}. {name} \n{amountInStock} items in stock";
    }

    public string DisplayDetailsFull()
    {
        StringBuilder sb = new();
        //ToDo: add price hero too
        sb.Append($"{id} {name} \n{description}\n{amountInStock} item(s) in strock");

        if(isBelowStockThreshold)
        {
            sb.Append("\n!!STOCK LOW!!");
        }
        return sb.ToString();
    }

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
        if (amountInStock < 10)//for now a fixed value
        {
            isBelowStockThreshold = true;
        }
    }
}