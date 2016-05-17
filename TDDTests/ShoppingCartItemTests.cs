using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDDTests
{
    [TestClass]
    public class ShoppingCartItemTests
    {
        // setup
        private int _qty;
        private string _desc;
        private CartItem _item;
        private decimal _unitPrice;

        [TestInitialize]
        public void Setup()
        {
            _qty = 2;
            _desc = "Cart Item";
            _unitPrice = 55m;
            _item = new CartItem(-_qty, _desc, _unitPrice);
        }

        [TestMethod]
        public void CartItemQuantity()
        {   
            Assert.AreEqual(_qty, _item.Quantity);
        }

        [TestMethod]
        public void CartItemDescription()
        {
            Assert.AreEqual(_desc, _item.Description);
        }
 
    }

    internal class CartItem
    {
       public int Quantity { get; private set; }
       public string Description   { get; private set; }

        public decimal UnitPrice { get; set; } 

        public CartItem(int quantity, string description, decimal unitprice)
        {
            this.Quantity = quantity;
            this.Description = description;
            this.UnitPrice = unitprice;
        }

    }
}
