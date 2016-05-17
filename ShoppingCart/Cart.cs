using System.Collections.Generic;

namespace ShoppingCart
{
    public class Cart
    {
        public List<CartItem> Items { get; set; }   

        public Cart()
        {
            Items = new List<CartItem>();
        }

        public void AddItem(CartItem item)
        {
            if (!Items.Contains(item))
            {
                Items.Add(item); 
            }
        }

        public void RemoveItem(CartItem item)
        {
            Items.Remove(item);
        }

        public decimal GetCartTotal()
        {
            decimal total = 0m;

            foreach (var item in Items)
            {
                total += item.GetItemTotalPrice();
            }

            return total;
        }
    }
}