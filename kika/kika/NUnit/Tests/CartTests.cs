using kika.NUnit.Pages;
using kika.NUnit.Utils;
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

        [Test]
        public void TestRemoveItemFromCart()
        {
            kikaHomePage.Header.AssertCartBubbleNumberIs("0");
            kikaHomePage.Menu.NavigateToDogToys();
            //Navigation.GoToDogToysPage();
            
            var name = productPage.GetProductTitle();
            var price = productPage.GetProductPrice();

            productPage.AddProductToCart();
            kikaHomePage.Header.AssertCartBubbleNumberIs(1);

            kikaHomePage
                .ClickOnCart()
                .AssertProductIsInCart(name, price, 1);

            cartPage
                .RemoveProduct()
                .AssertCarIsEmpty();
        }
    }
}
