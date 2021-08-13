using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingCart.Test
{
    [TestClass]
    public class CartTest
    {
        CartItem _cartItem;
        CartManager _cartManager;

        [TestInitialize]
        public void TestInitialize()
        {
            //Arrange
            _cartManager = new CartManager();
            _cartItem = new CartItem
            {
                Product = new Product()
                {
                    ProductId = 1,
                    ProductName = "Laptop",
                    UnitPrice = 1500
                },
                Quantity = 1
            };
            _cartManager.Add(_cartItem);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _cartManager.Clear();
        }

        [TestMethod]
        public void AddToCart()
        {
            const int expectedProduct = 1;

            //Act
            var totalItem = _cartManager.TotalItem;

            //Assert
            Assert.AreEqual(expectedProduct, totalItem);
        }

        [TestMethod]
        public void RemoveFromCartProduct()
        {
            var sumCartProduct = _cartManager.TotalItem;
            //Act
            _cartManager.Remove(1);
            var lastCartProduct = _cartManager.TotalItem;

            //Assert
            Assert.AreEqual(sumCartProduct - 1, lastCartProduct);
        }

        [TestMethod]
        public void RemoveFromCart()
        {
            //Act
            _cartManager.Clear();
            //Assert
            Assert.AreEqual(0, _cartManager.TotalItem);
            Assert.AreEqual(0, _cartManager.TotalQuantity);
        }
    }
}
