namespace BethanyPieShop.InventoryManagement.Domain.OrderManagement;

public class OrderItem
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int AmountOrdered { get; set; }

    public override string ToString()
    {
        return $"Product Id: {ProductId} - name: {ProductName} - Amount ordered: {AmountOrdered}";
    }
}
