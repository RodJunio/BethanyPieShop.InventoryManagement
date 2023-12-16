namespace BethanyPieShop.InventoryManagement;

public class Product
{
    private int id;
    private string name = string.Empty;
    private string? description;

    private int maxItemsInStock = 0;

    private UnitType? unitType;
    private int amoyntInStock = 0;
    private bool isBelowStockThreshold = false;
}
