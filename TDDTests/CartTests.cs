using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart;

namespace TDDTests
{
    [TestClass]
    public class CartTests
    {
        private Cart _cart;
        private CartItem _cartItem;

        [TestInitialize]
        public void Setup()
        {
            _cart = new Cart();
            _cartItem = new CartItem(2, "test", 5m, "XYZ1234");
        }

        [TestMethod]
        public void CartCanContainZeroItems()
        {
            Assert.AreEqual(_cart.Items.Count, 0);
        }

        [TestMethod]
        public void CartCanContainsAddedItem()
        {
            _cart.AddItem(_cartItem);

            Assert.IsTrue(_cart.Items.Contains(_cartItem));
        }

        [TestMethod]
        public void CartCanContaisNoDuplicateItems()
        {
            _cart.AddItem(_cartItem);
            _cart.AddItem(_cartItem);

            Assert.IsTrue(_cart.Items.Count < 2);
        }

        [TestMethod]
        public void CartCanRemoveItems()
        {
            _cart.AddItem(_cartItem);
            _cart.RemoveItem(_cartItem);

            Assert.IsTrue(_cart.Items.Count == 0);
        }
    }

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
    }
}
