using BethanyPieShop.InventoryManagement.Domain.General;

namespace BethanyPieShop.InventoryManagement.Domain.ProductManagement;

public class RegularProduct : Product
{
    public RegularProduct(int id, string name, string? description, Price price, UnitType unitType, int maxAmountInStock) : base(id, name, description, price, unitType, maxAmountInStock)
    {
    }

    public override void IncreaseStock()
    {
        AmountInStock++;
    }
}
