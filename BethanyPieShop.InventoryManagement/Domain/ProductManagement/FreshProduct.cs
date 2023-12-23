using BethanyPieShop.InventoryManagement.Domain.Contracts;
using BethanyPieShop.InventoryManagement.Domain.General;
using System.Text;

namespace BethanyPieShop.InventoryManagement.Domain.ProductManagement
{
    public class FreshProduct : Product, ISaveable
    {

        public FreshProduct(int id, string name, string? description, Price price, UnitType unitType, int maxAmountInStock) : base(id, name, description, price, unitType, maxAmountInStock)
        {
        }

        public DateTime ExpiryDateTime { get; set; }
        public string? StorageInstructions { get; set; }

        public override object Clone()
        {
            return new FreshProduct(0, this.Name, this.Description, new Price() { ItemPrice = this.Price.ItemPrice, Currency = this.Price.Currency }, this.UnitType, this.maxItemsInStock);
        }

        public string ConvertToStringForSaving()
        {
            return $"{Id};{Name};{Description};{maxItemsInStock};{Price.ItemPrice};{(int)Price.Currency};{(int)UnitType};2;";
        }

        public override string DisplayDetailsFull()
        {
            StringBuilder sb = new StringBuilder();            

            sb.AppendLine($"{Id} {Name} \n{Description}\n{Price}\n{AmountInStock} item(s) in stock");

            if (IsBelowStockTreshold)
                sb.AppendLine("\n!!STOCK LOW!!");

            sb.AppendLine("Storage instructions: " + StorageInstructions);//since this line needs to go here, we can't the base here
            sb.AppendLine("Expiry date: " + ExpiryDateTime.ToShortDateString());

            return sb.ToString();
        }
        public override void IncreaseStock()
        {
            AmountInStock++;
        }
    }
}
