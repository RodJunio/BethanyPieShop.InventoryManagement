namespace BethanyPieShop.InventoryManagement.Domain.OrderManagement;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderFullFilmentDate { get; private set; }
    public List<OrdemItem> OrderItems { get; set; }
    public bool Fullfilled { get; set; }

    public Order()
    {
        Id = new Random().Next(9999999);

        int numberofSeconds = new Random().Next(100);
        OrderFullFilmentDate = DateTime.Now.AddSeconds(numberofSeconds);

        OrderItems = new List<OrdemItem>();
    }
}
