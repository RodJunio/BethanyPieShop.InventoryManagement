using BethanyPieShop.InventoryManagement.Domain.Contracts;
using BethanyPieShop.InventoryManagement.Domain.General;
using System.Text;

namespace BethanyPieShop.InventoryManagement.Domain.ProductManagement
{
    public class BoxedProduct : Product, ISaveable, ILoggable
    {
        private int amountPerBox;

        public BoxedProduct(int id, string name, string? description, Price price, int amountPerBox, int maxAmountInStock) : base(id, name, description, price, UnitType.PerBox, maxAmountInStock)
        {
            AmountPerbox = amountPerBox;
        }

        public int AmountPerbox
        {
            get { return amountPerBox; }
            set
            {
                amountPerBox = value;
            }
        }

        public string ConvertToStringForSaving()
        {
            return $"{Id};{Name};{Description};{maxItemsInStock};{Price.ItemPrice};{(int)Price.Currency};{(int)UnitType};1;{AmountPerbox};";
        }

        public string DisplayBoxedProductDetails()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Boxed Product\n");

            sb.Append($"{Id} {Name} \n{Description}zn{Price}\n{AmountInStock} item(s) in stock");

            if (IsBelowStockTreshold)
                sb.Append("\n!!STOCK LOW!!");

            return sb.ToString();
        }

        public override string DisplayDetailsFull()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Boxed Product\n");

            sb.AppendLine($"{Id} {Name} \n{Description}\n{Price}\n{AmountInStock} item(s) in stock");

            if (IsBelowStockTreshold)
                sb.AppendLine("\n!!STOCK LOW!!");

            return sb.ToString();
        }

        public override void IncreaseStock()
        {
            AmountInStock += AmountPerbox;
        }

        public override void IncreaseStock(int amount)
        {

            //it is possible to call the base here too, but we are assuming that this is handled differently

            int newStock = AmountInStock + amount * AmountPerbox;
            if (newStock <= maxItemsInStock)
            {
                AmountInStock += amount * AmountPerbox;
            }
            else
            {
                AmountInStock = maxItemsInStock;
                Log($"`{CreateSimpleProductRepresentation} stock overflow. {newStock - AmountInStock} item(s) ordere that couldn't be stored");
            }

            if (AmountInStock > StockTreshold)
            {
                IsBelowStockTreshold = false;
            }
        }

        public override void UseProduct(int items)
        {
            int smallestMultiple = 0;
            int batchSize;

            while (true)
            {
                smallestMultiple++;
                if(smallestMultiple * AmountPerbox > items )
                {
                    batchSize = smallestMultiple * AmountPerbox;
                    break;
                }
            }
            base.UseProduct(items);
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        public override object Clone()
        {
            return new BoxedProduct(0, this.Name, this.Description, new Price() { ItemPrice = this.Price.ItemPrice, Currency = this.Price.Currency }, this.maxItemsInStock, this.AmountPerbox);
        }

        //public void UseBoxedProduct(int items)
        //{
        //    int smallestMultiple = 0;
        //    int batchSize;

        //    while(true)
        //    {
        //        smallestMultiple++;
        //        if(smallestMultiple * amountPerBox > items)
        //        {
        //            batchSize = smallestMultiple * amountPerBox;
        //            break;
        //        }
        //    }

        //    UseProduct(batchSize);
        //}
    }
}
