using NUnit.Framework;
using System;

namespace kika.NUnit.Tests
{
    public class CartTests: BaseTest
    {
        [SetUp]
        public void Before()
        {
            //loginWithDefaultUser();
            weWorkModal.Close();

            kikaHomePage
                .ClickOnLogin()
                .Login("test@test.lt", "test123");

            weWorkModal.Close();
        }

        [Test]
        public void TestAddToCart()
        {
            kikaHomePage.Header.AssertCartBubbleNumberIs("0");

            var price = kikaHomePage.GetFirstItemPrice();
            var name = kikaHomePage.GetFirstItemName();

            kikaHomePage
                .ClickFirstItemBuy()
                .ClickOnCart()
                .AssertProductIsInCart(name, price, 1);

            kikaHomePage.Header.AssertCartBubbleNumberIs(1);
        }
    }
}
