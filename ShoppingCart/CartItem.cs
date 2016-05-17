namespace ShoppingCart
{
    public class CartItem
    {
        public int Quantity { get; set; }
        public string Description   { get; private set; }

        public decimal UnitPrice { get; private set; }  

        public string PartNumber { get; private set; }

        public decimal Discount { get; set; } 
 

        public CartItem(int quantity, string description, decimal unitprice, string partnumber)
        {
            this.Quantity = quantity;
            this.Description = description;
            this.UnitPrice = unitprice;
            this.PartNumber = partnumber;
        }

        public decimal GetItemTotalPrice()
        {
            var totalPrice = Quantity*UnitPrice - Discount;

            return totalPrice <= 0m ? 0m : totalPrice;
        }

        public void ApplyDiscount(decimal discount)
        {
            this.Discount = discount;
        }
    }
}