using BethanyPieShop.InventoryManagement.Domain.General;

namespace BethanyPieShop.InventoryManagement.Domain.ProductManagement;

public class FreshBoxedProduct : BoxedProduct
{
    public FreshBoxedProduct(int id, string name, string? description, Price price, int amountPerBox, int maxAmountInStock) : base(id, name, description, price, amountPerBox, maxAmountInStock)
    {
    }

    //public void UseFreshBoxedProduct(int items)
    //{
    //    UseBoxedProduct(3);
    //}
}
