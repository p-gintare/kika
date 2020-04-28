using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace kika.NUnit.Pages
{
    public class CartPage : BasePage
    {
        IWebElement cartItemPriceElement => driver.FindElement(By.CssSelector("#cart_items .price"));
        IWebElement productNameElement => driver.FindElement(By.CssSelector(".product_name a"));
        IList<IWebElement> cartItemElementList => driver.FindElements(By.CssSelector("#cart_items .item"));

        IWebElement emptyCartMessageElement => driver.FindElement(By.CssSelector(".alert-warning"));

        IWebElement removeButton => driver.FindElement(By.CssSelector("#cart_items .cart_remove .icon-close"));

        public void AssertProductIsInCart(string name, string price, int count)
        {

            Assert.IsTrue(cartItemPriceElement.Text.Contains(price), "Prices are not the same");
            Assert.IsTrue(name.Contains(productNameElement.Text.Trim()), "Name is not the same");
            Assert.AreEqual(count, cartItemElementList.Count);
        }

        public CartPage RemoveProduct()
        {
            removeButton.Click();
            return this;
        }

        public void AssertCarIsEmpty()
        {
            Assert.NotNull(emptyCartMessageElement);
            Assert.AreEqual(0, cartItemElementList.Count);
        }
    }
}
