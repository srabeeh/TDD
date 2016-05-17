using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        private string _partNumber;
        private decimal _itemTotalPrice;

        [TestInitialize]
        public void Setup()
        {
            _qty = 2;
            _desc = "Cart Item";
            _unitPrice = 55m;
            _partNumber = "ABC9923";
            _itemTotalPrice = 110m;
            _item = new CartItem(_qty, _desc, _unitPrice, _partNumber);
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

        [TestMethod]
        public void CartItemUnitPrice()
        {
            Assert.AreEqual(_unitPrice, _item.UnitPrice);
        }

        [TestMethod]
        public void CartItemPartNumber()
        {
            Assert.AreEqual(_partNumber, _item.PartNumber);
        }

        [TestMethod]
        public void CartItemPriceIsQuantityTimesUnitPrice()
        {
            var actual = _item.GetItemTotalPrice();

            Assert.AreEqual(actual, _itemTotalPrice);
        }
    }

    internal class CartItem
    {
       public int Quantity { get; private set; }
       public string Description   { get; private set; }

        public decimal UnitPrice { get; private set; } 

        public string PartNumber { get; private set; }

        public CartItem(int quantity, string description, decimal unitprice, string partnumber)
        {
            this.Quantity = quantity;
            this.Description = description;
            this.UnitPrice = unitprice;
            this.PartNumber = partnumber;
        }

        public decimal GetItemTotalPrice()
        {
            return Quantity*UnitPrice;
        }
    }
}
