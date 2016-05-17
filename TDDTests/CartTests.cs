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
    class CartTests
    {
        [TestMethod]
        public void CartCanContainZeroItems()
        {
            var cart = new Cart();

            Assert.AreEqual(cart.Items.Count, 0);
        }
    }

    public class Cart
    {
        public List<CartItem> Items { get; set; }   

        public Cart()
        {

        }
    }
}
