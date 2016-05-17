using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShoppingCart;

namespace TDDTests
{
    [TestClass]
    public class CartRepositoryTests
    {
        private MockRepository _mockRepository;
        private Mock<ICartDatabase> _cartDatabaseMock;
        private long _cartSaveReturnValue;
        private long _cartSaveExceptionValue;
        private Cart _cart;
        private CartRepository _cartRepository;

        [TestInitialize]
        public void Setup()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);
            _cartDatabaseMock = _mockRepository.Create<ICartDatabase>();
            _cartSaveReturnValue = 12345;
            _cartSaveExceptionValue = 0;

            _cart =  new Cart();
            _cartRepository = new CartRepository(_cartDatabaseMock.Object);
        }

        [TestMethod]
        public void CartRepoShouldSaveCart()
        {
            _cartDatabaseMock.Setup(c => c.SaveCart(_cart)).Returns(_cartSaveReturnValue);

            var result = _cartRepository.SaveCart(_cart);

            Assert.AreEqual(result, _cartSaveReturnValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void CartRepoSaveCartExceptionShouldReturnZero()
        {
            _cartDatabaseMock.Setup(c => c.SaveCart(_cart)).Throws<ApplicationException>();

            var result = _cartRepository.SaveCart(_cart);

            Assert.AreEqual(result, _cartSaveExceptionValue);
        }
    }

    internal class CartRepository
    {
        private readonly ICartDatabase _cartDatabase;

        public CartRepository(ICartDatabase cartDatabase)
        {
            this._cartDatabase = cartDatabase;
        }

        public long SaveCart(Cart cart )
        {
            long returnValue;

            try
            {
                returnValue = _cartDatabase.SaveCart(cart);
            }
            catch (Exception)
            {
                returnValue =  0;
            }
            return returnValue;
        }
    }
}
