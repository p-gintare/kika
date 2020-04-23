using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace kika.NUnit.Pages
{
    public class CartPage : BasePage
    {
        public CartPage(IWebDriver driver) : base(driver)
        {
        }

        IWebElement cartItemPriceElement => driver.FindElement(By.CssSelector("#cart_items .price"));
        IWebElement productNameElement => driver.FindElement(By.CssSelector(".product_name"));
        IList<IWebElement> cartItemElementList => driver.FindElements(By.CssSelector("#cart_items .item"));

        public void AssertProductIsInCart(string name, string price, int count)
        {
            Assert.IsTrue(cartItemPriceElement.Text.Contains(price), "Prices are not the same");
            Assert.AreEqual(name, productNameElement.Text);
            Assert.AreEqual(count, cartItemElementList.Count);
        }
    }
}
