using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDDTests
{
    [TestClass]
    public class ShoppingCartItemTests
    {
        // setup
        private int _qty = 5;

        [TestMethod]
        public void CartItemQuantity()
        {
            var Item = new CartItem(_qty);

            Assert.AreEqual(_qty, Item.Quantity);
        }
    }

    internal class CartItem
    {
        public int Quantity { get; set; }

        public CartItem(int _quantity)
        {
            this.Quantity = _quantity;
        }

    }
}
