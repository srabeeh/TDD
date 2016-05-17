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
        private CartItem _cartItem2;
        private decimal _expectedTotal;

        [TestInitialize]
        public void Setup()
        {
            _cart = new Cart();
            _cartItem = new CartItem(2, "Rubber Grommet", 5m, "XYZ1234");
            _cartItem2 = new CartItem(2, "Widgets", 2m, "WIDGET98");
            _expectedTotal = 14;
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

        [TestMethod]
        public void CartTotalEQualsSumOfCartItems()
        {
            _cart.AddItem(_cartItem);
            _cart.AddItem(_cartItem2);

            var actual = _cart.GetCartTotal();

            Assert.AreEqual(actual, _expectedTotal );
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
