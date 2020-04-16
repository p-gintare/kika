using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace kika.NUnit.Pages
{
    public class KikaHomePage
    {
        private ChromeDriver _driver;
        public KikaHomePage(ChromeDriver driver)
        {
            _driver = driver;
        }
        IWebElement loginElement => _driver.FindElement(By.CssSelector(".need2login"));
        IWebElement menuElement => _driver.FindElementByCssSelector("#profile_menu.dropdown");

        private const string FirstItemElementSelector = ".owl-item.active";
        IWebElement firstItemPriceElement => _driver.FindElement(By.CssSelector(FirstItemElementSelector)).FindElement(By.CssSelector(".price"));
        IWebElement firstItemNameElement => _driver.FindElement(By.CssSelector($"{FirstItemElementSelector} .name"));
        IWebElement buyButton => _driver.FindElement(By.CssSelector($"{FirstItemElementSelector} .btn-primary"));

        IWebElement cartElement => _driver.FindElement(By.Id("cart_info"));

        IWebElement bubleCountElement => _driver.FindElement(By.CssSelector("#cart_info .cnt"));

        public AssertKikaHomePage Assert => new AssertKikaHomePage(_driver, bubleCountElement);

        public KikaHomePage GoTo()
        {
            _driver.Url = "https://www.kika.lt/";
            return this;
        }

        public KikaHomePage AssertMenuExists()
        {
            Assert.IsNotNull(menuElement, "User is not logged in");
            return this;
        }

        public LoginModal ClickOnLogin()
        {
            loginElement.Click();
            return new LoginModal(_driver);
        }

        public string GetFirstItemPrice()
        {
            return firstItemPriceElement.Text;
        }

        public string GetFirstItemName()
        {
            return firstItemNameElement.Text.Trim();
        }

        public KikaHomePage ClickFirstItemBuy()
        {
            buyButton.Click();
            return this;
        }

        public KikaHomePage ClickOnCart()
        {
            cartElement.Click();
            return this;
        }

        public KikaHomePage Click_on_cart()
        {
            cartElement.Click();
            return this;
        }

        public KikaHomePage AssertCartBubleNumberIs(int count)
        {
            Assert.AreEqual(count.ToString(), bubleCountElement.Text);
            return this;
        }

        public KikaHomePage AssertCartBubleNumberIs(string count)
        {
            Assert.AreEqual(count, bubleCountElement.Text);
            return this;
        }

    }
}
